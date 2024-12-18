<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
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
        Me.btnAddCourse = New System.Windows.Forms.Button()
        Me.btnAddQuestion = New System.Windows.Forms.Button()
        Me.btnRegisterStudents = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnSection = New System.Windows.Forms.Button()
        Me.btnShedule = New System.Windows.Forms.Button()
        Me.btnAssginStudent = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panell = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddCourse
        '
        Me.btnAddCourse.Location = New System.Drawing.Point(50, 132)
        Me.btnAddCourse.Name = "btnAddCourse"
        Me.btnAddCourse.Size = New System.Drawing.Size(146, 37)
        Me.btnAddCourse.TabIndex = 2
        Me.btnAddCourse.Text = "Course"
        Me.btnAddCourse.UseVisualStyleBackColor = True
        '
        'btnAddQuestion
        '
        Me.btnAddQuestion.Location = New System.Drawing.Point(50, 240)
        Me.btnAddQuestion.Name = "btnAddQuestion"
        Me.btnAddQuestion.Size = New System.Drawing.Size(146, 37)
        Me.btnAddQuestion.TabIndex = 3
        Me.btnAddQuestion.Text = "Question"
        Me.btnAddQuestion.UseVisualStyleBackColor = True
        '
        'btnRegisterStudents
        '
        Me.btnRegisterStudents.Location = New System.Drawing.Point(50, 312)
        Me.btnRegisterStudents.Name = "btnRegisterStudents"
        Me.btnRegisterStudents.Size = New System.Drawing.Size(146, 37)
        Me.btnRegisterStudents.TabIndex = 4
        Me.btnRegisterStudents.Text = "Register Students"
        Me.btnRegisterStudents.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(50, 347)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(146, 37)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Statistics"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnSection
        '
        Me.btnSection.Location = New System.Drawing.Point(50, 168)
        Me.btnSection.Name = "btnSection"
        Me.btnSection.Size = New System.Drawing.Size(146, 37)
        Me.btnSection.TabIndex = 6
        Me.btnSection.Text = "Section"
        Me.btnSection.UseVisualStyleBackColor = True
        '
        'btnShedule
        '
        Me.btnShedule.Location = New System.Drawing.Point(50, 204)
        Me.btnShedule.Name = "btnShedule"
        Me.btnShedule.Size = New System.Drawing.Size(146, 37)
        Me.btnShedule.TabIndex = 7
        Me.btnShedule.Text = "Schedules"
        Me.btnShedule.UseVisualStyleBackColor = True
        '
        'btnAssginStudent
        '
        Me.btnAssginStudent.Location = New System.Drawing.Point(50, 276)
        Me.btnAssginStudent.Name = "btnAssginStudent"
        Me.btnAssginStudent.Size = New System.Drawing.Size(146, 37)
        Me.btnAssginStudent.TabIndex = 8
        Me.btnAssginStudent.Text = "Assign Studens"
        Me.btnAssginStudent.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(50, 423)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(146, 37)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
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
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(50, 466)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(146, 39)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.btnAssginStudent)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnShedule)
        Me.Panel1.Controls.Add(Me.btnAddCourse)
        Me.Panel1.Controls.Add(Me.btnSection)
        Me.Panel1.Controls.Add(Me.btnAddQuestion)
        Me.Panel1.Controls.Add(Me.btnRegisterStudents)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 659)
        Me.Panel1.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Admin's dashboard"
        '
        'panell
        '
        Me.panell.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panell.Location = New System.Drawing.Point(241, 0)
        Me.panell.Name = "panell"
        Me.panell.Size = New System.Drawing.Size(1194, 659)
        Me.panell.TabIndex = 15
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 659)
        Me.ControlBox = False
        Me.Controls.Add(Me.panell)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AdminDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddCourse As Button
    Friend WithEvents btnAddQuestion As Button
    Friend WithEvents btnRegisterStudents As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btnSection As Button
    Friend WithEvents btnShedule As Button
    Friend WithEvents btnAssginStudent As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents panell As Panel
End Class
