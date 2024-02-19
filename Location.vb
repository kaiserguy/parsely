Public Class Location
    Public strType As String = String.Empty
    Public strPath As String = String.Empty
    Public Sub New(ByVal Type As String, ByVal Path As String)
        Try
            If Type = "File" Or Type = "Folder" Then
                strType = Type
            End If
            If Path.Length > 0 Then
                strPath = Path
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Location Class New()")
            Exit Sub
        End Try
    End Sub
    Overrides Function toString() As String
        Return strPath
    End Function
End Class
