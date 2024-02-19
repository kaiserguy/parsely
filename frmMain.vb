Imports System.Management
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.ComponentModel

Public Class frmMain
    Private strStatus As String = String.Empty

    Private colWorkers As New Collection
    Private dteStart As Date

    Private Sub btnSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSource.Click
        If txtSource.Enabled Then
            Dim response As DialogResult = dlgSource.ShowDialog()
            If response = DialogResult.OK Then
                If frmLocations.lstLocations.Items.Count > 1 Then
                    If MsgBox("This will replace your existing search locations. To add this location to your current list, add it using the 'Choose More Search Locations button'.", MsgBoxStyle.OkCancel, "Just so you know...") = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End If
                frmLocations.lstLocations.Items.Clear()
                frmLocations.lstLocations.Items.Add(New Location("Folder", dlgSource.SelectedPath))
                txtSource.Text = dlgSource.SelectedPath
            End If
        Else
            frmLocations.ShowDialog()
        End If
    End Sub

    Private Sub btnDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestination.Click
        Dim response As DialogResult = dlgDestination.ShowDialog()
        If response = DialogResult.OK Then
            txtDestination.Text = dlgDestination.SelectedPath
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyFiles.Click
        If IO.Directory.Exists(txtDestination.Text) Then
            tmrRefresh.Start()
            For Each strFile As String In SelectedFiles
                strStatus = strFile
Retry:
                Try
                    IO.File.Copy(strFile, txtDestination.Text & "\" & IO.Path.GetFileName(strFile), True)
                Catch ex As Exception
                    Select Case MsgBox(ex.Message, MsgBoxStyle.AbortRetryIgnore, "Hold up a sec here...")
                        Case MsgBoxResult.Abort
                            Exit For
                        Case MsgBoxResult.Retry
                            GoTo Retry
                        Case MsgBoxResult.Ignore
                            GoTo Skip
                    End Select
                End Try
Skip:
            Next
            tmrRefresh.Stop()
            lblStatus.Text = ""
            MsgBox("Done!", MsgBoxStyle.Information, "Copying " & SelectedFiles.Length & " files")
        Else
            MsgBox("Need an existing destination folder first", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private boolSearching As Boolean = False
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If boolSearching Then
            stopSearch()
        Else
            startSearch()
        End If
    End Sub
    Private Sub stopSearch()
        boolSearching = False
        Me.CancelButton = Nothing
        Dim boolDone As Boolean
        Do While Not boolDone
            boolDone = True
            For Each myWorker As BackgroundWorker In colWorkers
                myWorker.CancelAsync()
                boolDone = boolDone And Not myWorker.IsBusy
            Next
            Threading.Thread.Sleep(100)
            Application.DoEvents()
        Loop
        UpdateThreadsWorkingCount()
        btnSearch.BackColor = Color.Green
        btnSearch.Text = "Search for files"
        boolSearching = False
        btnSearch.Refresh()
        tmrRefresh.Enabled = False
        'lstThreads.Enabled = True
        MsgBox("Done! Found " & lstFileResults.Items.Count & " in " & Int(Date.Now.Subtract(dteStart).TotalSeconds).ToString & " seconds.", MsgBoxStyle.Information, "Searching for files")
    End Sub

    Private Sub startSearch()
        boolSearching = True
        Me.CancelButton = btnSearch
        lstFileResults.Items.Clear()
        btnSearch.BackColor = Color.Red
        btnSearch.Text = "Searching for files"
        btnSearch.Refresh()
        tmrRefresh.Enabled = True
        If lstThreads.SelectedIndex < 0 Then
            setThreadCount(If(Environment.ProcessorCount / 2 > 1, Environment.ProcessorCount / 2, 1))
        End If
        lstThreads.Enabled = False
RetrySingle:
        If frmLocations.lstLocations.Items.Count = 1 Then
            If IO.Directory.Exists(txtSource.Text) Then
                frmLocations.lstLocations.Items.Clear()
                frmLocations.AddLocation(New Location("Folder", txtSource.Text))
            ElseIf IO.File.Exists(txtSource.Text) Then
                frmLocations.lstLocations.Items.Clear()
                frmLocations.AddLocation(New Location("File", txtSource.Text))
            Else
                Select Case MsgBox("Path does not exist.", MsgBoxStyle.AbortRetryIgnore, "Hold up a sec here...")
                    Case MsgBoxResult.Abort
                        Exit Sub
                    Case MsgBoxResult.Retry
                        GoTo RetrySingle
                    Case MsgBoxResult.Ignore
                        Exit Sub
                End Select
            End If
        End If
        dteStart = Date.Now
        For Each myLocation As Location In frmLocations.lstLocations.Items
            Select Case myLocation.strType
                Case "File"
                    lstFileResults.Items.Add(myLocation.strPath)
                Case "Folder"
                    Dim boolSuccess As Boolean = False
                    Do While Not boolSuccess
                        For i As Integer = 1 To (lstThreads.SelectedItem)
                            If Not colWorkers(i).IsBusy Then
                                Dim dirInfo As New IO.DirectoryInfo(myLocation.strPath)
                                Dim mySearchTerms As New SearchTerms(txtSearchPattern.Text, txtFileContentPattern.Text, dirInfo, Int(lstThreads.SelectedItem))
                                strStatus = myLocation.strPath
                                colWorkers(i).RunWorkerAsync(mySearchTerms)
                                boolSuccess = True
                                Exit For
                            End If
                        Next
                        Threading.Thread.Sleep(1)
                        Application.DoEvents()
                    Loop
            End Select
        Next
    End Sub

    Private Shared Function SubstringCount(ByVal search As String, ByVal find As String) As Integer
        Return (search.Length - Replace(search, find, "").Length) / find.Length
    End Function

    Public intCaseSensitive As RegexOptions = RegexOptions.IgnoreCase

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim mySearchTerms As SearchTerms = e.Argument

        If worker.CancellationPending = True Then
            e.Cancel = True
            Exit Sub
        End If

        Dim myResult As New SearchResult

        If (mySearchTerms.myDirInfo.Attributes <> IO.FileAttributes.System) And Not mySearchTerms.myDirInfo.FullName.Contains("$Recycle.Bin") Then
            Try
                If SubstringCount(mySearchTerms.myDirInfo.FullName, IO.Path.DirectorySeparatorChar) >= mySearchTerms.intDepth Then
                    Dim intCount As Integer = 0
                    For Each result As IO.FileInfo In mySearchTerms.myDirInfo.EnumerateFiles("*", IO.SearchOption.AllDirectories)
                        Try
                            strStatus = result.FullName
                            If worker.CancellationPending = True Then
                                e.Result = myResult
                                e.Cancel = True
                                Exit Sub
                            End If
                            intCount += 1
                            If Regex.Match(result.Name, mySearchTerms.strSearchPattern, intCaseSensitive).Success Then
                                If IsContentMatch(result.FullName, mySearchTerms.strFileContentPattern) And IsDetailsMatch(result) Then myResult.strFiles.Add(result.FullName)
                            End If
                        Catch ex As IO.PathTooLongException
                            'the path is too long for the VB.net Windows API to deal with. This should be handled better in the future somehow.
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    Next
                Else
                    For Each result As IO.FileInfo In mySearchTerms.myDirInfo.EnumerateFiles("*", IO.SearchOption.TopDirectoryOnly)
                        If worker.CancellationPending = True Then
                            e.Result = myResult
                            e.Cancel = True
                            Exit Sub
                        End If
                        If Regex.Match(result.Name, mySearchTerms.strSearchPattern, intCaseSensitive).Success Then
                            If IsContentMatch(result.FullName, mySearchTerms.strFileContentPattern) And IsDetailsMatch(result) Then myResult.strFiles.Add(result.FullName)
                        End If
                    Next
                    For Each myDir As IO.DirectoryInfo In mySearchTerms.myDirInfo.EnumerateDirectories("*", IO.SearchOption.TopDirectoryOnly)
                        myResult.myFolders.Add(myDir)
                    Next
                End If
            Catch ex As UnauthorizedAccessException
                'we are not allowed to dig into that directory. Move on.
            End Try
        End If
        e.Result = myResult
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Static DirsToSearch As New Collection
        Static intIndex As Integer = 1
        Try
            Dim myResult As SearchResult = DirectCast(e.Result, SearchResult)
            For Each strFile As String In myResult.strFiles
                lstFileResults.Items.Add(strFile)
            Next
            For Each myDir As IO.DirectoryInfo In myResult.myFolders
                DirsToSearch.Add(myDir)
            Next
            If Not boolSearching Then
                intIndex = 1
                DirsToSearch.Clear()
                Exit Sub
            End If

            Dim boolDone As Boolean = True
            For i As Integer = 1 To Int(lstThreads.SelectedItem)
                If Not colWorkers(i).IsBusy Then
                    If DirsToSearch.Count >= intIndex Then
                        Dim mySearchTerms As New SearchTerms(txtSearchPattern.Text, txtFileContentPattern.Text, DirsToSearch(intIndex), Int(lstThreads.SelectedItem))
                        strStatus = DirectCast(DirsToSearch(intIndex), IO.DirectoryInfo).FullName
                        intIndex += 1
                        colWorkers(i).RunWorkerAsync(mySearchTerms)
                        boolDone = False
                    End If
                End If
            Next

            For Each myWorker As BackgroundWorker In colWorkers
                boolDone = boolDone And Not myWorker.IsBusy
            Next
            If boolDone Then
                intIndex = 1
                DirsToSearch.Clear()
                stopSearch()
            End If
        Catch ex As Exception
            If ex.Message <> "Operation has been cancelled." Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "bw_RunWorkerCompleted")
            End If
        End Try
    End Sub

    Public boolMatchDate As Boolean = False
    Public strDateType As String = "Modified"
    Public strDateOrdinal As String = "before"
    Public dteFileDatePicked As Date = Date.Now

    Private Function IsDetailsMatch(ByRef myFileInfo As IO.FileInfo) As Boolean
        If boolMatchDate Then
            Dim fileDatePicked As Date = frmFileNameOptions.DateTimePicker1.MaxDate
            Dim fileDate As Date
            Select Case strDateType
                Case "Created"
                    fileDate = myFileInfo.CreationTime
                Case "Modified"
                    fileDate = myFileInfo.LastWriteTime
                Case "Accessed"
                    fileDate = myFileInfo.LastAccessTime
            End Select
            Select Case strDateOrdinal
                Case "is"
                    Return fileDate.ToShortDateString = dteFileDatePicked.ToShortDateString
                Case "before"
                    Select Case Date.Compare(fileDate, dteFileDatePicked)
                        Case 1
                            Return False
                        Case Else
                            Return True
                    End Select
                Case "after"
                    Select Case Date.Compare(fileDate, dteFileDatePicked)
                        Case -1
                            Return False
                        Case Else
                            Return True
                    End Select
            End Select
        End If
        Return True
    End Function

    Private Shared Function IsContentMatch(ByRef strFilePath As String, ByRef strFileContentPattern As String) As Boolean
        Static colErrors As New Collections.Specialized.StringCollection

        If strFileContentPattern = ".*" Then Return True
        If Len(strFileContentPattern) < 1 Then Return True
        Try
            Return Regex.IsMatch(IO.File.ReadAllText(strFilePath), strFileContentPattern, RegexOptions.IgnoreCase)
        Catch ex As Exception
            If Not colErrors.Contains(ex.HelpLink) Then
                MsgBox("File: " & strFilePath & vbNewLine & ex.Message & vbNewLine & "You will not be notified of future errors of this nature.", MsgBoxStyle.Exclamation, "File Content Matching Error. File will be skipped.")
                colErrors.Add(ex.HelpLink)
            End If
        End Try
    End Function

    Private Class SearchResult
        Public strFiles As New Collections.Specialized.StringCollection
        Public myFolders As New Collection
    End Class
    Private Class SearchTerms
        Public strSearchPattern As String
        Public strFileContentPattern As String
        Public myDirInfo As IO.DirectoryInfo
        Public intDepth As Integer
        Public Sub New(ByVal SearchPattern As String, ByVal FileContentPattern As String, DirInfo As IO.DirectoryInfo, Depth As Integer)
            strSearchPattern = SearchPattern
            strFileContentPattern = FileContentPattern
            myDirInfo = DirInfo
            intDepth = Depth
        End Sub
    End Class

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click, Me.FormClosing
        'Select Case MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Just checking...")
        '    Case MsgBoxResult.Yes
        My.Settings.strOutputLocation = dlgDestination.SelectedPath
        My.Settings.strBrowseLocation = dlgSource.SelectedPath
        My.Settings.strFileSearchPattern = txtSearchPattern.Text
        My.Settings.strSearchInsidePattern = txtSearchInsidePattern.Text
        My.Settings.strFileContentPattern = txtFileContentPattern.Text
        Dim strLocations As String = ""
        For Each myLocation As Location In frmLocations.lstLocations.Items
            strLocations &= myLocation.strType & "?" & myLocation.strPath & ","
        Next
        My.Settings.strLocations = strLocations.TrimEnd(",")
        My.Settings.Save()
        End
        '    Case MsgBoxResult.No
        ''Do nothing
        'End Select
    End Sub

    Private Sub btnRemoveDuplicates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveDuplicates.Click
        Dim colOld As Collection = New Collection
        For Each item As String In lstFileResults.Items
            colOld.Add(item)
        Next
        lstFileResults.Items.Clear()
        For Each item As String In colOld
            strStatus = item
            For Each otherItem As String In SelectedFiles
                If IO.Path.GetFileName(item) = IO.Path.GetFileName(otherItem) Then
                    'skip file
                Else
                    lstFileResults.Items.Add(item)
                End If
            Next
            'If Not String.Equals(IO.Path.GetExtension(item), ".psd") Then
            '    Dim strExt As String = IO.Path.GetExtension(item)
            '    Select Case strExt
            '        Case ".png", ".PNG"
            '            For Each item1 As String In colOld
            '                If IO.Path.GetFileNameWithoutExtension(item) = IO.Path.GetFileNameWithoutExtension(item1) And IO.Path.GetExtension(item1) = ".psd" Then
            '                    'skip entry line, thereby leaving the item out of the new list
            '                    GoTo Skip
            '                End If
            '            Next
            '        Case ".JPG", ".jpg"
            '            For Each item1 As String In colOld
            '                If IO.Path.GetFileNameWithoutExtension(item) = IO.Path.GetFileNameWithoutExtension(item1) And (IO.Path.GetExtension(item1) = ".psd" Or IO.Path.GetExtension(item1) = ".png") Then
            '                    'skip entry line, thereby leaving the item out of the new list
            '                    GoTo Skip
            '                End If
            '            Next
            '    End Select
            'End If
        Next
    End Sub

    Private Sub btnSearchInsideFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchInsideFiles.Click
        Dim regExPattern As Regex = New Regex(txtSearchInsidePattern.Text)
        For Each myLocation As Location In frmLocations.lstLocations.Items
            Select Case myLocation.strType
                Case "File"
                    lstFileResults.Items.Add(myLocation.strPath)
            End Select
        Next

        'Initialize progress bar
        prgSearchInside.Minimum = 0
        prgSearchInside.Maximum = lstFileResults.Items.Count
        prgSearchInside.Value = 0
        prgSearchInside.Step = 1
        Try
            If regExPattern.GroupNameFromNumber(0).Length > 1 Then
                'return formatted results
                For Each file As String In lstFileResults.Items
                    'keeps Microsoft Word temporary files from causing errors by not searching them
                    If Not IO.Path.GetFileName(file).StartsWith("~$") Then
                        lblCurrentFile.Text = file
                        Dim strFileContents As String = ""
                        Select Case IO.Path.GetExtension(file)
                            Case ".rtf"
                                Dim rtfBox As RichTextBox = New RichTextBox()
                                rtfBox.LoadFile(file)
                                strFileContents = rtfBox.Text
                                rtfBox.Dispose()
                            Case Else
                                strFileContents = IO.File.ReadAllText(file)
                        End Select
                        Dim strResultString As String = ""
                        For Each myMatch As Match In regExPattern.Matches(strFileContents)
                            For intGroup As Integer = 0 To myMatch.Groups.Count - 1
                                strResultString &= regExPattern.GetGroupNames(intGroup) & ":"
                                For Each groupCapture As System.Text.RegularExpressions.Capture In myMatch.Groups(intGroup).Captures
                                    strResultString += groupCapture.Value & ","
                                Next
                                strResultString = strResultString.TrimEnd(",")
                                strResultString &= ";"
                            Next
                            strResultString = strResultString.TrimEnd("; ")
                        Next

                        If strResultString.Length > 0 Then
                            If chkPrependFilenames.Checked Then
                                txtSearchInsideResults.Text &= IO.Path.GetFileName(file) & ":"
                            End If
                            txtSearchInsideResults.Text &= strResultString & vbNewLine
                        End If
                        prgSearchInside.PerformStep()
                        prgSearchInside.Refresh()
                        Application.DoEvents()
                    End If
                Next
            Else
                'Return simple results
                For Each file As String In lstFileResults.Items
                    'keeps Microsoft Word temporary files from causing errors by not searching them
                    If Not IO.Path.GetFileName(file).StartsWith("~$") Then
                        lblCurrentFile.Text = file
                        Dim strFileContents As String = ""
                        Select Case IO.Path.GetExtension(file)
                            Case ".rtf"
                                Dim rtfBox As RichTextBox = New RichTextBox()
                                rtfBox.LoadFile(file)
                                strFileContents = rtfBox.Text
                                rtfBox.Dispose()
                            Case Else
                                strFileContents = IO.File.ReadAllText(file)
                        End Select
                        For Each myMatch As Match In regExPattern.Matches(strFileContents)
                            If myMatch.Success And myMatch.Value.Length > 0 Then
                                If chkPrependFilenames.Checked Then
                                    txtSearchInsideResults.Text &= IO.Path.GetFileName(file) & ":"
                                End If
                                txtSearchInsideResults.Text &= myMatch.Value & vbNewLine
                            End If
                        Next
                        prgSearchInside.PerformStep()
                        prgSearchInside.Refresh()
                        Application.DoEvents()
                    End If
                Next
            End If

            lblCurrentFile.Text = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & lblCurrentFile.Text, MsgBoxStyle.Exclamation, "Unknown Error")
        End Try
        MsgBox("Search has ended", MsgBoxStyle.Information, "FYI")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearchInsideResults.Click
        Select Case MsgBox("Are you sure you want to clear all text results?", MsgBoxStyle.YesNo, "Just checking...")
            Case MsgBoxResult.Yes
                txtSearchInsideResults.Text = ""
            Case MsgBoxResult.No
                'Do nothing
        End Select
    End Sub

    Private Sub btnChooseLocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseLocations.Click
        frmLocations.ShowDialog()
    End Sub

    Private Sub btnMoveFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFiles.Click
        If MsgBox("Are you sure you want to delete all of the files selected? (" & SelectedFiles.Length & ")", MsgBoxStyle.YesNo, "Caution! Deletion is permanent!") = MsgBoxResult.Yes Then
            If IO.Directory.Exists(txtDestination.Text) Then
                tmrRefresh.Start()
                For Each strFile As String In SelectedFiles
                    strStatus = strFile
Retry:
                    Try
                        IO.File.Move(strFile, txtDestination.Text & "\" & IO.Path.GetFileName(strFile))
                    Catch ex As Exception
                        Select Case MsgBox(ex.Message, MsgBoxStyle.AbortRetryIgnore, "Hold up a sec here...")
                            Case MsgBoxResult.Abort
                                Exit For
                            Case MsgBoxResult.Retry
                                GoTo Retry
                            Case MsgBoxResult.Ignore
                                GoTo Skip
                        End Select
                    End Try
Skip:
                Next
                tmrRefresh.Stop()
                lblStatus.Text = ""
                MsgBox("Done!", MsgBoxStyle.Information, "Moving " & SelectedFiles.Length & " files")
            Else
                MsgBox("Need an existing destination folder first", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub txtDestination_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDestination.Text = txtDestination.Text.TrimEnd("\")
    End Sub

    Private Sub btnDeleteFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFiles.Click
        If MsgBox("Are you sure you want to delete all of the files selected? (" & SelectedFiles.Length & ")", MsgBoxStyle.YesNo, "Caution! Deletion is permanent!") = MsgBoxResult.Yes Then
            tmrRefresh.Start()
            For Each strFile As String In SelectedFiles
                strStatus = strFile
Retry:
                Try
                    IO.File.Delete(strFile)
                    lstFileResults.Items.Remove(strFile)
                Catch ex As Exception
                    Select Case MsgBox(ex.Message, MsgBoxStyle.AbortRetryIgnore, "Hold up a sec here...")
                        Case MsgBoxResult.Abort
                            Exit For
                        Case MsgBoxResult.Retry
                            GoTo Retry
                        Case MsgBoxResult.Ignore
                            GoTo Skip
                    End Select
                End Try
Skip:
            Next
        End If
        tmrRefresh.Stop()
        lblStatus.Text = ""
        MsgBox("Done!", MsgBoxStyle.Information, "Deleting " & SelectedFiles.Length & " files")
    End Sub

    Private Sub btnClearFileResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFileResults.Click
        Select Case MsgBox("Are you sure you want to clear all file results?", MsgBoxStyle.YesNo, "Just checking...")
            Case MsgBoxResult.Yes
                lstFileResults.Items.Clear()
            Case MsgBoxResult.No
                'Do nothing
        End Select
    End Sub

    Private Sub btnExportFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportFiles.Click
        'Dim fileOutput As IO.FileStream
        'Retry:
        '        Try
        '            fileOutput = New IO.FileStream(txtDestination.Text, IO.FileMode.CreateNew, IO.FileAccess.Write)
        '        Catch ex As Exception
        '            Select Case MsgBox(ex.Message, MsgBoxStyle.RetryCancel, "Hold up a sec here...")
        '                Case MsgBoxResult.Cancel
        '                    Exit Sub
        '                Case MsgBoxResult.Retry
        '                    GoTo Retry
        '            End Select
        '        End Try
        '        Dim myStreamWriter As IO.StreamWriter = New IO.StreamWriter(fileOutput)
        If Len(txtDestination.Text) > 0 Then
            Dim strFileList As String = ""
            For Each strFile As String In SelectedFiles
                strFileList &= strFile & vbNewLine
            Next
            Try
                IO.File.WriteAllText(txtDestination.Text, strFileList)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

            'Application.DoEvents()
            'fileOutput.Flush()
            'fileOutput.Close()
            MsgBox("Done!", MsgBoxStyle.Information, "Exporting " & SelectedFiles.Length & " files to list")
        Else
            MsgBox("Need a destination file path first", MsgBoxStyle.Exclamation)
        End If
        'fileOutput.Dispose()
    End Sub

    Private Sub txtSource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSource.TextChanged
        If txtSource.Text = frmLocations.strMultipleLocationsSelectedMessage Then
            txtSource.Enabled = False
        Else
            txtSource.Enabled = True
            If txtSource.Text.Length > 0 Then
                If IO.Directory.Exists(txtSource.Text) Then
                    frmLocations.lstLocations.Items.Clear()
                    frmLocations.AddLocation(New Location("Folder", txtSource.Text))
                Else
                    frmLocations.lstLocations.Items.Clear()
                    frmLocations.AddLocation(New Location("File", txtSource.Text))
                End If
            End If
        End If
    End Sub
    Private Sub setThreadCount(ByVal intCount As Integer)
        lstThreads.SelectedIndex = lstThreads.FindStringExact(intCount.ToString)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intProcCount As Integer = Environment.ProcessorCount
        For i As Integer = 1 To intProcCount
            lstThreads.Items.Add(i.ToString)
        Next
        Select Case My.Settings.strLocations.Split(",").Length
            Case 0
                'Do nothing
            Case 1
                frmLocations.AddLocation(New Location(My.Settings.strLocations.Split("?")(0), My.Settings.strLocations.Split("?")(1)))
                txtSource.Text = My.Settings.strLocations.Split("?")(1)
            Case Is > 1
                For Each myLocation As String In My.Settings.strLocations.Split(",")
                    frmLocations.lstLocations.Items.Add(New Location(myLocation.Split("?")(0), myLocation.Split("?")(1)))
                Next
                txtSource.Text = frmLocations.strMultipleLocationsSelectedMessage
        End Select
        dlgDestination.SelectedPath = My.Settings.strOutputLocation
        txtDestination.Text = My.Settings.strOutputLocation
        dlgSource.SelectedPath = My.Settings.strBrowseLocation
        txtSearchPattern.Text = My.Settings.strFileSearchPattern
        txtSearchInsidePattern.Text = My.Settings.strSearchInsidePattern
        txtFileContentPattern.Text = My.Settings.strFileContentPattern
    End Sub

    Private Sub txtSearchPattern_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchPattern.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, New EventArgs)
        End If
    End Sub

    Private Sub txtFileContentPattern_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFileContentPattern.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, New EventArgs)
        End If
    End Sub

    Private Sub txtSearchInsidePattern_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchInsidePattern.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSearchInsideFiles_Click(sender, New EventArgs)
        End If
    End Sub

    Private Sub tmrRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRefresh.Tick
        'lstFileResults.Refresh()
        lblStatus.Text = strStatus
        UpdateThreadsWorkingCount()
    End Sub
    Private Sub UpdateThreadsWorkingCount()
        Dim intCount As Integer = 0
        For Each myWorker As BackgroundWorker In colWorkers
            If myWorker.IsBusy Then intCount += 1
        Next
        lblThreadsWorking.Text = intCount
    End Sub

    Private Sub lstFileResults_DoubleClick(sender As Object, e As System.EventArgs) Handles lstFileResults.DoubleClick
        'launchSelectedFiles() 'this also triggers when doubleclicking on the scrollbar...not good...
    End Sub

    Private Sub lstFileResults_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lstFileResults.KeyUp
        Select Case e.Modifiers
            Case Keys.None
                Select Case e.KeyCode
                    Case Keys.Enter
                        launchSelectedFiles()
                    Case Keys.Delete
                        btnDeleteFiles_Click(sender, New System.EventArgs)
                End Select
            Case Keys.Control
                Select Case e.KeyCode
                    Case Keys.V
                        btnCopy_Click(sender, New System.EventArgs)
                    Case Keys.C
                        btnMoveFiles_Click(sender, New System.EventArgs)
                End Select
        End Select
    End Sub
    Private Sub launchSelectedFiles()
        For Each strFile As String In SelectedFiles
            If IO.File.Exists(strFile) Then
                Process.Start(strFile)
            End If
        Next
    End Sub
    Private ReadOnly Property SelectedFiles As String()
        Get
            If lstFileResults.SelectedItems.Count > 0 Then
                Dim strArray(lstFileResults.SelectedItems.Count - 1) As String
                lstFileResults.SelectedItems.CopyTo(strArray, 0)
                Return strArray
            Else
                Dim strArray(lstFileResults.Items.Count - 1) As String
                lstFileResults.Items.CopyTo(strArray, 0)
                Return strArray
            End If
        End Get
    End Property

    Private Sub txtSearchInsideResults_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtSearchInsideResults.MouseDown
        ' Start a drag.
        txtSearchInsideResults.DoDragDrop( _
            txtSearchInsideResults.Text.TrimEnd((vbLf & vbCr & vbCrLf).ToCharArray), _
            DragDropEffects.Copy)
    End Sub
    Dim strResults As New StringBuilder
    Private Sub lstFileResults_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstFileResults.MouseDown
        ' Start a drag.
        lstFileResults.DoDragDrop( _
            strResults.ToString.TrimEnd((vbLf & vbCr & vbCrLf).ToCharArray), _
            DragDropEffects.Copy)
    End Sub

    Private Sub lstFileResults_MouseEnter(sender As Object, e As System.EventArgs) Handles lstFileResults.MouseEnter
        strResults.Clear()
        Select Case lstFileResults.SelectedIndices.Count
            Case 0
                For Each strResult As String In lstFileResults.Items
                    strResults.AppendLine(strResult)
                Next
            Case Else
                For Each strResult As String In lstFileResults.SelectedItems
                    strResults.AppendLine(strResult)
                Next
        End Select
    End Sub

    Private Sub btnFileNameOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnFileNameOptions.Click
        frmFileNameOptions.ShowDialog()
    End Sub

    Private Sub lstThreads_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstThreads.SelectedIndexChanged
        If Int(lstThreads.SelectedItem) > -1 Then
            colWorkers.Clear()
            For i As Integer = 1 To Int(lstThreads.SelectedItem)
                Dim myWorker As New BackgroundWorker
                myWorker.WorkerSupportsCancellation = True
                'myWorker.WorkerReportsProgress = True
                AddHandler myWorker.DoWork, AddressOf bw_DoWork
                AddHandler myWorker.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

                colWorkers.Add(myWorker)
            Next
        End If
    End Sub
End Class
