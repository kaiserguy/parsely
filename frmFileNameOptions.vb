Public Class frmFileNameOptions

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.Hide()
    End Sub

    Private Sub chkCaseSensitive_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCaseSensitive.CheckedChanged
        Select Case chkCaseSensitive.Checked
            Case True
                frmMain.intCaseSensitive = System.Text.RegularExpressions.RegexOptions.None
            Case False
                frmMain.intCaseSensitive = System.Text.RegularExpressions.RegexOptions.IgnoreCase
        End Select
    End Sub

    Private Sub chkDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDate.CheckedChanged
        frmMain.boolMatchDate = chkDate.Checked
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDate.SelectedIndexChanged
        frmMain.strDateType = cboDate.SelectedItem
        chkDate.Checked = True
    End Sub

    Private Sub cboOrdinal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrdinal.SelectedIndexChanged
        frmMain.strDateOrdinal = cboOrdinal.SelectedItem
        chkDate.Checked = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        frmMain.dteFileDatePicked = DateTimePicker1.Value
        chkDate.Checked = True
    End Sub

    Private Sub frmFileNameOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If chkDate.Checked = False Then
            cboDate.SelectedIndex = 0
            cboOrdinal.SelectedIndex = 1
            chkDate.Checked = False
        End If
    End Sub
End Class