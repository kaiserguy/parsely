Imports Parsely.Location

Public Class frmLocations
    Private oldLstLocations As ListBox = New ListBox
    Public Const strMultipleLocationsSelectedMessage As String = "{Multiple Sources Selected}"

    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click
        If dlgFiles.ShowDialog = Windows.Forms.DialogResult.OK Then
            lstLocations.Items.Add(New Location("File", dlgFiles.SelectedPath))
        End If
    End Sub

    Private Sub btnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFolders.Click
        If dlgFolders.ShowDialog = Windows.Forms.DialogResult.OK Then
            lstLocations.Items.Add(New Location("Folder", dlgFolders.SelectedPath))
        End If
    End Sub

    Private Sub lstLocations_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstLocations.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each file As String In CType(e.Data.GetData(DataFormats.FileDrop), Array)
                If Not lstLocations.Items.Contains(file) Then
                    lstLocations.Items.Add(New Location("File", file))
                End If
            Next
        End If
    End Sub

    Private Sub lstLocations_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstLocations.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstLocations.SelectedItems IsNot Nothing Then
            Dim colLocationsToRemove As Collection = New Collection
            For Each strLocation As Location In lstLocations.SelectedItems
                colLocationsToRemove.Add(strLocation)
            Next
            For Each strLocation As Location In colLocationsToRemove
                lstLocations.Items.Remove(strLocation)
            Next
        End If
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Select Case lstLocations.Items.Count
            Case Is > 1
                frmMain.txtSource.Text = strMultipleLocationsSelectedMessage
            Case 0
                frmMain.txtSource.Text = ""
            Case 1
                frmMain.txtSource.Text = lstLocations.Items(0).ToString
        End Select

        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lstLocations.Items.Clear()
        For Each item As Location In oldLstLocations.Items
            lstLocations.Items.Add(item)
        Next
        oldLstLocations.Items.Clear()
        Me.Hide()
    End Sub

    Private Sub frmLocations_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        oldLstLocations.Items.Clear()
        For Each item As Location In lstLocations.Items
            oldLstLocations.Items.Add(item)
        Next
    End Sub
    Public Sub AddLocation(ByVal newLocation As Location)
        lstLocations.Items.Add(newLocation)
    End Sub
End Class