<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.btnSource = New System.Windows.Forms.Button()
        Me.dlgSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtSearchPattern = New System.Windows.Forms.TextBox()
        Me.lstFileResults = New System.Windows.Forms.ListBox()
        Me.dlgDestination = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnCopyFiles = New System.Windows.Forms.Button()
        Me.chkAllDirectories = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRemoveDuplicates = New System.Windows.Forms.Button()
        Me.txtSearchInsidePattern = New System.Windows.Forms.TextBox()
        Me.txtSearchInsideResults = New System.Windows.Forms.TextBox()
        Me.btnSearchInsideFiles = New System.Windows.Forms.Button()
        Me.btnClearSearchInsideResults = New System.Windows.Forms.Button()
        Me.btnChooseLocations = New System.Windows.Forms.Button()
        Me.btnDestination = New System.Windows.Forms.Button()
        Me.btnMoveFiles = New System.Windows.Forms.Button()
        Me.btnDeleteFiles = New System.Windows.Forms.Button()
        Me.lblFileSearchResults = New System.Windows.Forms.Label()
        Me.lblSearchInsidePattern = New System.Windows.Forms.Label()
        Me.lblSearchLocation = New System.Windows.Forms.Label()
        Me.lblFileSearchPattern = New System.Windows.Forms.Label()
        Me.btnExportFiles = New System.Windows.Forms.Button()
        Me.lblSearchInsideResults = New System.Windows.Forms.Label()
        Me.lblOutputLocation = New System.Windows.Forms.Label()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClearFileResults = New System.Windows.Forms.Button()
        Me.prgSearchInside = New System.Windows.Forms.ProgressBar()
        Me.lblCurrentFile = New System.Windows.Forms.Label()
        Me.txtFileContentPattern = New System.Windows.Forms.TextBox()
        Me.lblFileContentPatternLabel = New System.Windows.Forms.Label()
        Me.chkPrependFilenames = New System.Windows.Forms.CheckBox()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lstThreads = New System.Windows.Forms.ComboBox()
        Me.lblThreadsLabel = New System.Windows.Forms.Label()
        Me.lblThreadsWorking = New System.Windows.Forms.Label()
        Me.btnFileNameOptions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(12, 25)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(558, 20)
        Me.txtSource.TabIndex = 0
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(575, 22)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSource.TabIndex = 1
        Me.btnSource.Text = "Browse"
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'txtSearchPattern
        '
        Me.txtSearchPattern.Location = New System.Drawing.Point(12, 66)
        Me.txtSearchPattern.Name = "txtSearchPattern"
        Me.txtSearchPattern.Size = New System.Drawing.Size(272, 20)
        Me.txtSearchPattern.TabIndex = 2
        Me.txtSearchPattern.Text = ".+\.txt"
        '
        'lstFileResults
        '
        Me.lstFileResults.FormattingEnabled = True
        Me.lstFileResults.HorizontalScrollbar = True
        Me.lstFileResults.Location = New System.Drawing.Point(12, 116)
        Me.lstFileResults.Name = "lstFileResults"
        Me.lstFileResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileResults.Size = New System.Drawing.Size(558, 147)
        Me.lstFileResults.TabIndex = 3
        '
        'btnCopyFiles
        '
        Me.btnCopyFiles.Location = New System.Drawing.Point(577, 116)
        Me.btnCopyFiles.Name = "btnCopyFiles"
        Me.btnCopyFiles.Size = New System.Drawing.Size(73, 44)
        Me.btnCopyFiles.TabIndex = 7
        Me.btnCopyFiles.Text = "Copy Files"
        Me.btnCopyFiles.UseVisualStyleBackColor = True
        '
        'chkAllDirectories
        '
        Me.chkAllDirectories.AutoSize = True
        Me.chkAllDirectories.Checked = True
        Me.chkAllDirectories.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllDirectories.Location = New System.Drawing.Point(437, 8)
        Me.chkAllDirectories.Name = "chkAllDirectories"
        Me.chkAllDirectories.Size = New System.Drawing.Size(131, 17)
        Me.chkAllDirectories.TabIndex = 8
        Me.chkAllDirectories.Text = "Include Subdirectories"
        Me.chkAllDirectories.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(656, 216)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 44)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRemoveDuplicates
        '
        Me.btnRemoveDuplicates.Location = New System.Drawing.Point(656, 166)
        Me.btnRemoveDuplicates.Name = "btnRemoveDuplicates"
        Me.btnRemoveDuplicates.Size = New System.Drawing.Size(75, 44)
        Me.btnRemoveDuplicates.TabIndex = 10
        Me.btnRemoveDuplicates.Text = "Remove Duplicates"
        Me.btnRemoveDuplicates.UseVisualStyleBackColor = True
        Me.btnRemoveDuplicates.Visible = False
        '
        'txtSearchInsidePattern
        '
        Me.txtSearchInsidePattern.Location = New System.Drawing.Point(12, 319)
        Me.txtSearchInsidePattern.Name = "txtSearchInsidePattern"
        Me.txtSearchInsidePattern.Size = New System.Drawing.Size(558, 20)
        Me.txtSearchInsidePattern.TabIndex = 11
        '
        'txtSearchInsideResults
        '
        Me.txtSearchInsideResults.Location = New System.Drawing.Point(12, 400)
        Me.txtSearchInsideResults.Multiline = True
        Me.txtSearchInsideResults.Name = "txtSearchInsideResults"
        Me.txtSearchInsideResults.ReadOnly = True
        Me.txtSearchInsideResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSearchInsideResults.Size = New System.Drawing.Size(719, 164)
        Me.txtSearchInsideResults.TabIndex = 12
        '
        'btnSearchInsideFiles
        '
        Me.btnSearchInsideFiles.Location = New System.Drawing.Point(576, 319)
        Me.btnSearchInsideFiles.Name = "btnSearchInsideFiles"
        Me.btnSearchInsideFiles.Size = New System.Drawing.Size(74, 36)
        Me.btnSearchInsideFiles.TabIndex = 13
        Me.btnSearchInsideFiles.Text = "Search Inside Files"
        Me.btnSearchInsideFiles.UseVisualStyleBackColor = True
        '
        'btnClearSearchInsideResults
        '
        Me.btnClearSearchInsideResults.Location = New System.Drawing.Point(656, 319)
        Me.btnClearSearchInsideResults.Name = "btnClearSearchInsideResults"
        Me.btnClearSearchInsideResults.Size = New System.Drawing.Size(75, 36)
        Me.btnClearSearchInsideResults.TabIndex = 14
        Me.btnClearSearchInsideResults.Text = "Clear Text Results"
        Me.btnClearSearchInsideResults.UseVisualStyleBackColor = True
        '
        'btnChooseLocations
        '
        Me.btnChooseLocations.Location = New System.Drawing.Point(656, 22)
        Me.btnChooseLocations.Name = "btnChooseLocations"
        Me.btnChooseLocations.Size = New System.Drawing.Size(75, 64)
        Me.btnChooseLocations.TabIndex = 15
        Me.btnChooseLocations.Text = "Choose More Search Locations"
        Me.btnChooseLocations.UseVisualStyleBackColor = True
        '
        'btnDestination
        '
        Me.btnDestination.Location = New System.Drawing.Point(576, 279)
        Me.btnDestination.Name = "btnDestination"
        Me.btnDestination.Size = New System.Drawing.Size(75, 23)
        Me.btnDestination.TabIndex = 6
        Me.btnDestination.Text = "Browse"
        Me.btnDestination.UseVisualStyleBackColor = True
        '
        'btnMoveFiles
        '
        Me.btnMoveFiles.Location = New System.Drawing.Point(577, 166)
        Me.btnMoveFiles.Name = "btnMoveFiles"
        Me.btnMoveFiles.Size = New System.Drawing.Size(73, 44)
        Me.btnMoveFiles.TabIndex = 16
        Me.btnMoveFiles.Text = "Move Files"
        Me.btnMoveFiles.UseVisualStyleBackColor = True
        '
        'btnDeleteFiles
        '
        Me.btnDeleteFiles.Location = New System.Drawing.Point(577, 216)
        Me.btnDeleteFiles.Name = "btnDeleteFiles"
        Me.btnDeleteFiles.Size = New System.Drawing.Size(73, 44)
        Me.btnDeleteFiles.TabIndex = 17
        Me.btnDeleteFiles.Text = "Delete Files"
        Me.btnDeleteFiles.UseVisualStyleBackColor = True
        '
        'lblFileSearchResults
        '
        Me.lblFileSearchResults.AutoSize = True
        Me.lblFileSearchResults.Location = New System.Drawing.Point(9, 100)
        Me.lblFileSearchResults.Name = "lblFileSearchResults"
        Me.lblFileSearchResults.Size = New System.Drawing.Size(98, 13)
        Me.lblFileSearchResults.TabIndex = 18
        Me.lblFileSearchResults.Text = "File Search Results"
        '
        'lblSearchInsidePattern
        '
        Me.lblSearchInsidePattern.AutoSize = True
        Me.lblSearchInsidePattern.Location = New System.Drawing.Point(9, 303)
        Me.lblSearchInsidePattern.Name = "lblSearchInsidePattern"
        Me.lblSearchInsidePattern.Size = New System.Drawing.Size(111, 13)
        Me.lblSearchInsidePattern.TabIndex = 19
        Me.lblSearchInsidePattern.Text = "Content Parse Pattern"
        '
        'lblSearchLocation
        '
        Me.lblSearchLocation.AutoSize = True
        Me.lblSearchLocation.Location = New System.Drawing.Point(9, 9)
        Me.lblSearchLocation.Name = "lblSearchLocation"
        Me.lblSearchLocation.Size = New System.Drawing.Size(85, 13)
        Me.lblSearchLocation.TabIndex = 20
        Me.lblSearchLocation.Text = "Search Location"
        '
        'lblFileSearchPattern
        '
        Me.lblFileSearchPattern.AutoSize = True
        Me.lblFileSearchPattern.Location = New System.Drawing.Point(9, 50)
        Me.lblFileSearchPattern.Name = "lblFileSearchPattern"
        Me.lblFileSearchPattern.Size = New System.Drawing.Size(97, 13)
        Me.lblFileSearchPattern.TabIndex = 22
        Me.lblFileSearchPattern.Text = "File Search Pattern"
        '
        'btnExportFiles
        '
        Me.btnExportFiles.Location = New System.Drawing.Point(656, 116)
        Me.btnExportFiles.Name = "btnExportFiles"
        Me.btnExportFiles.Size = New System.Drawing.Size(76, 44)
        Me.btnExportFiles.TabIndex = 23
        Me.btnExportFiles.Text = "Export File List"
        Me.btnExportFiles.UseVisualStyleBackColor = True
        '
        'lblSearchInsideResults
        '
        Me.lblSearchInsideResults.AutoSize = True
        Me.lblSearchInsideResults.Location = New System.Drawing.Point(12, 384)
        Me.lblSearchInsideResults.Name = "lblSearchInsideResults"
        Me.lblSearchInsideResults.Size = New System.Drawing.Size(120, 13)
        Me.lblSearchInsideResults.TabIndex = 24
        Me.lblSearchInsideResults.Text = "Content Parsing Results"
        '
        'lblOutputLocation
        '
        Me.lblOutputLocation.AutoSize = True
        Me.lblOutputLocation.Location = New System.Drawing.Point(9, 266)
        Me.lblOutputLocation.Name = "lblOutputLocation"
        Me.lblOutputLocation.Size = New System.Drawing.Size(83, 13)
        Me.lblOutputLocation.TabIndex = 27
        Me.lblOutputLocation.Text = "Output Location"
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(12, 282)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(558, 20)
        Me.txtDestination.TabIndex = 26
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Green
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(575, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 35)
        Me.btnSearch.TabIndex = 25
        Me.btnSearch.Text = "Search For Files"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClearFileResults
        '
        Me.btnClearFileResults.Location = New System.Drawing.Point(656, 279)
        Me.btnClearFileResults.Name = "btnClearFileResults"
        Me.btnClearFileResults.Size = New System.Drawing.Size(75, 36)
        Me.btnClearFileResults.TabIndex = 28
        Me.btnClearFileResults.Text = "Clear File Results"
        Me.btnClearFileResults.UseVisualStyleBackColor = True
        '
        'prgSearchInside
        '
        Me.prgSearchInside.Location = New System.Drawing.Point(12, 345)
        Me.prgSearchInside.Name = "prgSearchInside"
        Me.prgSearchInside.Size = New System.Drawing.Size(558, 23)
        Me.prgSearchInside.TabIndex = 29
        '
        'lblCurrentFile
        '
        Me.lblCurrentFile.AutoSize = True
        Me.lblCurrentFile.Location = New System.Drawing.Point(12, 371)
        Me.lblCurrentFile.Name = "lblCurrentFile"
        Me.lblCurrentFile.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentFile.TabIndex = 30
        '
        'txtFileContentPattern
        '
        Me.txtFileContentPattern.Location = New System.Drawing.Point(290, 66)
        Me.txtFileContentPattern.Name = "txtFileContentPattern"
        Me.txtFileContentPattern.Size = New System.Drawing.Size(279, 20)
        Me.txtFileContentPattern.TabIndex = 31
        Me.txtFileContentPattern.Text = ".*"
        '
        'lblFileContentPatternLabel
        '
        Me.lblFileContentPatternLabel.AutoSize = True
        Me.lblFileContentPatternLabel.Location = New System.Drawing.Point(287, 47)
        Me.lblFileContentPatternLabel.Name = "lblFileContentPatternLabel"
        Me.lblFileContentPatternLabel.Size = New System.Drawing.Size(100, 13)
        Me.lblFileContentPatternLabel.TabIndex = 32
        Me.lblFileContentPatternLabel.Text = "File Content Pattern"
        '
        'chkPrependFilenames
        '
        Me.chkPrependFilenames.AutoSize = True
        Me.chkPrependFilenames.Checked = True
        Me.chkPrependFilenames.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrependFilenames.Location = New System.Drawing.Point(577, 361)
        Me.chkPrependFilenames.Name = "chkPrependFilenames"
        Me.chkPrependFilenames.Size = New System.Drawing.Size(116, 17)
        Me.chkPrependFilenames.TabIndex = 33
        Me.chkPrependFilenames.Text = "Prepend Filenames"
        Me.chkPrependFilenames.UseVisualStyleBackColor = True
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 500
        '
        'lblStatus
        '
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 87)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(717, 13)
        Me.lblStatus.TabIndex = 34
        Me.lblStatus.Text = "Status: "
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstThreads
        '
        Me.lstThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstThreads.Enabled = False
        Me.lstThreads.FormattingEnabled = True
        Me.lstThreads.Location = New System.Drawing.Point(383, 2)
        Me.lstThreads.Name = "lstThreads"
        Me.lstThreads.Size = New System.Drawing.Size(48, 21)
        Me.lstThreads.TabIndex = 35
        '
        'lblThreadsLabel
        '
        Me.lblThreadsLabel.AutoSize = True
        Me.lblThreadsLabel.Location = New System.Drawing.Point(330, 8)
        Me.lblThreadsLabel.Name = "lblThreadsLabel"
        Me.lblThreadsLabel.Size = New System.Drawing.Size(46, 13)
        Me.lblThreadsLabel.TabIndex = 36
        Me.lblThreadsLabel.Text = "Threads"
        '
        'lblThreadsWorking
        '
        Me.lblThreadsWorking.AutoSize = True
        Me.lblThreadsWorking.Location = New System.Drawing.Point(679, 2)
        Me.lblThreadsWorking.Name = "lblThreadsWorking"
        Me.lblThreadsWorking.Size = New System.Drawing.Size(0, 13)
        Me.lblThreadsWorking.TabIndex = 37
        '
        'btnFileNameOptions
        '
        Me.btnFileNameOptions.Font = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileNameOptions.Location = New System.Drawing.Point(234, 47)
        Me.btnFileNameOptions.Name = "btnFileNameOptions"
        Me.btnFileNameOptions.Size = New System.Drawing.Size(47, 16)
        Me.btnFileNameOptions.TabIndex = 38
        Me.btnFileNameOptions.Text = "Options"
        Me.btnFileNameOptions.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 585)
        Me.Controls.Add(Me.btnFileNameOptions)
        Me.Controls.Add(Me.lblThreadsWorking)
        Me.Controls.Add(Me.lblThreadsLabel)
        Me.Controls.Add(Me.lstThreads)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkPrependFilenames)
        Me.Controls.Add(Me.lblFileContentPatternLabel)
        Me.Controls.Add(Me.txtFileContentPattern)
        Me.Controls.Add(Me.lblCurrentFile)
        Me.Controls.Add(Me.prgSearchInside)
        Me.Controls.Add(Me.btnClearFileResults)
        Me.Controls.Add(Me.lblOutputLocation)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblSearchInsideResults)
        Me.Controls.Add(Me.btnExportFiles)
        Me.Controls.Add(Me.lblFileSearchPattern)
        Me.Controls.Add(Me.lblSearchLocation)
        Me.Controls.Add(Me.lblSearchInsidePattern)
        Me.Controls.Add(Me.lblFileSearchResults)
        Me.Controls.Add(Me.btnDeleteFiles)
        Me.Controls.Add(Me.btnMoveFiles)
        Me.Controls.Add(Me.btnChooseLocations)
        Me.Controls.Add(Me.btnClearSearchInsideResults)
        Me.Controls.Add(Me.btnSearchInsideFiles)
        Me.Controls.Add(Me.txtSearchInsideResults)
        Me.Controls.Add(Me.txtSearchInsidePattern)
        Me.Controls.Add(Me.btnRemoveDuplicates)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.chkAllDirectories)
        Me.Controls.Add(Me.btnCopyFiles)
        Me.Controls.Add(Me.btnDestination)
        Me.Controls.Add(Me.lstFileResults)
        Me.Controls.Add(Me.txtSearchPattern)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.txtSource)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parsely  -  by Stephen Kaiser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents dlgSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtSearchPattern As System.Windows.Forms.TextBox
    Friend WithEvents lstFileResults As System.Windows.Forms.ListBox
    Friend WithEvents dlgDestination As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCopyFiles As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnRemoveDuplicates As System.Windows.Forms.Button
    Friend WithEvents txtSearchInsidePattern As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchInsideResults As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchInsideFiles As System.Windows.Forms.Button
    Friend WithEvents btnClearSearchInsideResults As System.Windows.Forms.Button
    Private WithEvents chkAllDirectories As System.Windows.Forms.CheckBox
    Friend WithEvents btnChooseLocations As System.Windows.Forms.Button
    Friend WithEvents btnDestination As System.Windows.Forms.Button
    Friend WithEvents btnMoveFiles As System.Windows.Forms.Button
    Friend WithEvents btnDeleteFiles As System.Windows.Forms.Button
    Friend WithEvents lblFileSearchResults As System.Windows.Forms.Label
    Friend WithEvents lblSearchInsidePattern As System.Windows.Forms.Label
    Friend WithEvents lblSearchLocation As System.Windows.Forms.Label
    Friend WithEvents lblFileSearchPattern As System.Windows.Forms.Label
    Friend WithEvents btnExportFiles As System.Windows.Forms.Button
    Friend WithEvents lblSearchInsideResults As System.Windows.Forms.Label
    Friend WithEvents lblOutputLocation As System.Windows.Forms.Label
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClearFileResults As System.Windows.Forms.Button
    Friend WithEvents prgSearchInside As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCurrentFile As System.Windows.Forms.Label
    Friend WithEvents txtFileContentPattern As System.Windows.Forms.TextBox
    Friend WithEvents lblFileContentPatternLabel As System.Windows.Forms.Label
    Private WithEvents chkPrependFilenames As System.Windows.Forms.CheckBox
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lstThreads As System.Windows.Forms.ComboBox
    Friend WithEvents lblThreadsLabel As System.Windows.Forms.Label
    Friend WithEvents lblThreadsWorking As System.Windows.Forms.Label
    Friend WithEvents btnFileNameOptions As System.Windows.Forms.Button

End Class
