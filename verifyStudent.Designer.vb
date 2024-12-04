<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class verifyStudent
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
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.lblpassword = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(28, 107)
        Me.txtusername.Multiline = True
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(381, 30)
        Me.txtusername.TabIndex = 0
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(28, 143)
        Me.txtpassword.Multiline = True
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(381, 30)
        Me.txtpassword.TabIndex = 1
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(168, 179)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(127, 38)
        Me.btnVerify.TabIndex = 2
        Me.btnVerify.Text = "VERIFY"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Location = New System.Drawing.Point(25, 58)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(84, 16)
        Me.lblusername.TabIndex = 3
        Me.lblusername.Text = "USERNAME"
        '
        'lblpassword
        '
        Me.lblpassword.AutoSize = True
        Me.lblpassword.Location = New System.Drawing.Point(25, 83)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(86, 16)
        Me.lblpassword.TabIndex = 4
        Me.lblpassword.Text = "PASSWORD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(397, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "YOU NEED TO RE-TYPE YOUR USERNAME AND PASSWORD"
        '
        'verifyStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 220)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblpassword)
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Name = "verifyStudent"
        Me.Text = "verifyStudent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents btnVerify As Button
    Friend WithEvents lblusername As Label
    Friend WithEvents lblpassword As Label
    Friend WithEvents Label3 As Label
End Class
