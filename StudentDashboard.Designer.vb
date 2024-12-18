<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentDashboard
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.btnResults = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSection = New System.Windows.Forms.Button()
        Me.btnRegisterStudents = New System.Windows.Forms.Button()
        Me.panelStudent = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.btnResults)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnSection)
        Me.Panel1.Controls.Add(Me.btnRegisterStudents)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 614)
        Me.Panel1.TabIndex = 15
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(58, 68)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(42, 16)
        Me.lblUser.TabIndex = 13
        Me.lblUser.Text = "User: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Student's dashboard"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(50, 96)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(146, 37)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "Dashboard"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'btnResults
        '
        Me.btnResults.Location = New System.Drawing.Point(50, 182)
        Me.btnResults.Name = "btnResults"
        Me.btnResults.Size = New System.Drawing.Size(146, 37)
        Me.btnResults.TabIndex = 8
        Me.btnResults.Text = "Results"
        Me.btnResults.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(43, 492)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(146, 39)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "LOGOUT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSection
        '
        Me.btnSection.Location = New System.Drawing.Point(50, 139)
        Me.btnSection.Name = "btnSection"
        Me.btnSection.Size = New System.Drawing.Size(146, 37)
        Me.btnSection.TabIndex = 6
        Me.btnSection.Text = "Exams"
        Me.btnSection.UseVisualStyleBackColor = True
        '
        'btnRegisterStudents
        '
        Me.btnRegisterStudents.Location = New System.Drawing.Point(50, 225)
        Me.btnRegisterStudents.Name = "btnRegisterStudents"
        Me.btnRegisterStudents.Size = New System.Drawing.Size(146, 37)
        Me.btnRegisterStudents.TabIndex = 4
        Me.btnRegisterStudents.Text = "Profile"
        Me.btnRegisterStudents.UseVisualStyleBackColor = True
        '
        'panelStudent
        '
        Me.panelStudent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelStudent.Location = New System.Drawing.Point(241, 0)
        Me.panelStudent.Name = "panelStudent"
        Me.panelStudent.Size = New System.Drawing.Size(1178, 614)
        Me.panelStudent.TabIndex = 16
        '
        'StudentDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1419, 614)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelStudent)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "StudentDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSection As Button
    Friend WithEvents btnRegisterStudents As Button
    Friend WithEvents panelStudent As Panel
    Friend WithEvents btnResults As Button
    Friend WithEvents lblUser As Label
End Class
