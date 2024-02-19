<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileNameOptions
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
        Me.chkCaseSensitive = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.cboOrdinal = New System.Windows.Forms.ComboBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkCaseSensitive
        '
        Me.chkCaseSensitive.AutoSize = True
        Me.chkCaseSensitive.Location = New System.Drawing.Point(12, 12)
        Me.chkCaseSensitive.Name = "chkCaseSensitive"
        Me.chkCaseSensitive.Size = New System.Drawing.Size(98, 18)
        Me.chkCaseSensitive.TabIndex = 0
        Me.chkCaseSensitive.Text = "Case Sensitive"
        Me.chkCaseSensitive.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(389, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(320, 36)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 3
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Items.AddRange(New Object() {"Modified", "Created", "Accessed"})
        Me.cboDate.Location = New System.Drawing.Point(66, 34)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(121, 22)
        Me.cboDate.TabIndex = 4
        '
        'cboOrdinal
        '
        Me.cboOrdinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrdinal.FormattingEnabled = True
        Me.cboOrdinal.Items.AddRange(New Object() {"before", "is", "after"})
        Me.cboOrdinal.Location = New System.Drawing.Point(193, 34)
        Me.cboOrdinal.Name = "cboOrdinal"
        Me.cboOrdinal.Size = New System.Drawing.Size(121, 22)
        Me.cboOrdinal.TabIndex = 5
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(12, 36)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(48, 18)
        Me.chkDate.TabIndex = 6
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'frmFileNameOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 72)
        Me.Controls.Add(Me.chkDate)
        Me.Controls.Add(Me.cboOrdinal)
        Me.Controls.Add(Me.cboDate)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkCaseSensitive)
        Me.Name = "frmFileNameOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FileNameOptions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCaseSensitive As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrdinal As System.Windows.Forms.ComboBox
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
End Class
