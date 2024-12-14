<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormQuestion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.cmbCorrectAnswer = New System.Windows.Forms.ComboBox()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.txtB = New System.Windows.Forms.TextBox()
        Me.txtC = New System.Windows.Forms.TextBox()
        Me.txtD = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblcoursecode = New System.Windows.Forms.Label()
        Me.cmbAssessmentType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Course:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Question:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(87, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "A."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(87, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "B."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(87, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "C."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(86, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "D."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Answer:"
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(192, 60)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(223, 24)
        Me.cmbCourse.TabIndex = 9
        '
        'cmbCorrectAnswer
        '
        Me.cmbCorrectAnswer.FormattingEnabled = True
        Me.cmbCorrectAnswer.Items.AddRange(New Object() {"A", "B", "C", "D"})
        Me.cmbCorrectAnswer.Location = New System.Drawing.Point(149, 323)
        Me.cmbCorrectAnswer.Name = "cmbCorrectAnswer"
        Me.cmbCorrectAnswer.Size = New System.Drawing.Size(195, 24)
        Me.cmbCorrectAnswer.TabIndex = 10
        '
        'txtQuestion
        '
        Me.txtQuestion.Location = New System.Drawing.Point(149, 107)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(638, 72)
        Me.txtQuestion.TabIndex = 12
        '
        'txtA
        '
        Me.txtA.Location = New System.Drawing.Point(149, 185)
        Me.txtA.Name = "txtA"
        Me.txtA.Size = New System.Drawing.Size(638, 22)
        Me.txtA.TabIndex = 13
        '
        'txtB
        '
        Me.txtB.Location = New System.Drawing.Point(149, 221)
        Me.txtB.Name = "txtB"
        Me.txtB.Size = New System.Drawing.Size(638, 22)
        Me.txtB.TabIndex = 14
        '
        'txtC
        '
        Me.txtC.Location = New System.Drawing.Point(149, 252)
        Me.txtC.Name = "txtC"
        Me.txtC.Size = New System.Drawing.Size(638, 22)
        Me.txtC.TabIndex = 15
        '
        'txtD
        '
        Me.txtD.Location = New System.Drawing.Point(149, 288)
        Me.txtD.Name = "txtD"
        Me.txtD.Size = New System.Drawing.Size(638, 22)
        Me.txtD.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(175, 396)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 40)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(304, 396)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(99, 40)
        Me.btnNext.TabIndex = 18
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(55, 396)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(94, 42)
        Me.btnBack.TabIndex = 20
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblcoursecode
        '
        Me.lblcoursecode.AutoSize = True
        Me.lblcoursecode.Location = New System.Drawing.Point(593, 68)
        Me.lblcoursecode.Name = "lblcoursecode"
        Me.lblcoursecode.Size = New System.Drawing.Size(48, 16)
        Me.lblcoursecode.TabIndex = 21
        Me.lblcoursecode.Text = "Label2"
        '
        'cmbAssessmentType
        '
        Me.cmbAssessmentType.FormattingEnabled = True
        Me.cmbAssessmentType.Location = New System.Drawing.Point(192, 30)
        Me.cmbAssessmentType.Name = "cmbAssessmentType"
        Me.cmbAssessmentType.Size = New System.Drawing.Size(223, 24)
        Me.cmbAssessmentType.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Select Assessmenr Typ:"
        '
        'FormQuestion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 467)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbAssessmentType)
        Me.Controls.Add(Me.lblcoursecode)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtD)
        Me.Controls.Add(Me.txtC)
        Me.Controls.Add(Me.txtB)
        Me.Controls.Add(Me.txtA)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.cmbCorrectAnswer)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormQuestion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents cmbCorrectAnswer As ComboBox
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents txtA As TextBox
    Friend WithEvents txtB As TextBox
    Friend WithEvents txtC As TextBox
    Friend WithEvents txtD As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblcoursecode As Label
    Friend WithEvents cmbAssessmentType As ComboBox
    Friend WithEvents Label2 As Label
End Class
