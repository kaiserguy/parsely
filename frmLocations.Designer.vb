<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocations
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
        Me.lstLocations = New System.Windows.Forms.ListBox
        Me.btnAddFolders = New System.Windows.Forms.Button
        Me.btnAddFile = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.dlgFiles = New System.Windows.Forms.FolderBrowserDialog
        Me.dlgFolders = New System.Windows.Forms.FolderBrowserDialog
        Me.btnDone = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lstLocations
        '
        Me.lstLocations.AllowDrop = True
        Me.lstLocations.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstLocations.FormattingEnabled = True
        Me.lstLocations.Location = New System.Drawing.Point(0, 55)
        Me.lstLocations.Name = "lstLocations"
        Me.lstLocations.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstLocations.Size = New System.Drawing.Size(350, 433)
        Me.lstLocations.TabIndex = 0
        '
        'btnAddFolders
        '
        Me.btnAddFolders.Location = New System.Drawing.Point(96, 0)
        Me.btnAddFolders.Name = "btnAddFolders"
        Me.btnAddFolders.Size = New System.Drawing.Size(81, 53)
        Me.btnAddFolders.TabIndex = 1
        Me.btnAddFolders.Text = "Add Folder(s)"
        Me.btnAddFolders.UseVisualStyleBackColor = True
        '
        'btnAddFile
        '
        Me.btnAddFile.Location = New System.Drawing.Point(0, 0)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(90, 53)
        Me.btnAddFile.TabIndex = 2
        Me.btnAddFile.Text = "Add File(s)"
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnRemove.Location = New System.Drawing.Point(269, 0)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(81, 55)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove Item(s)"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDone.Location = New System.Drawing.Point(182, 0)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(81, 29)
        Me.btnDone.TabIndex = 4
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(182, 29)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 488)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.btnAddFolders)
        Me.Controls.Add(Me.lstLocations)
        Me.Name = "frmLocations"
        Me.Text = "Search Locations"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstLocations As System.Windows.Forms.ListBox
    Friend WithEvents btnAddFolders As System.Windows.Forms.Button
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents dlgFiles As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dlgFolders As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
