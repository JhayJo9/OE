<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCourseCode = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbStudentName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAssessmentType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Select Course Code"
        '
        'cmbCourseCode
        '
        Me.cmbCourseCode.FormattingEnabled = True
        Me.cmbCourseCode.Location = New System.Drawing.Point(67, 172)
        Me.cmbCourseCode.Name = "cmbCourseCode"
        Me.cmbCourseCode.Size = New System.Drawing.Size(209, 24)
        Me.cmbCourseCode.TabIndex = 28
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(150, 254)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(116, 37)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(46, 254)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 37)
        Me.btnBack.TabIndex = 26
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Select Student Name"
        '
        'cmbStudentName
        '
        Me.cmbStudentName.FormattingEnabled = True
        Me.cmbStudentName.Location = New System.Drawing.Point(67, 114)
        Me.cmbStudentName.Name = "cmbStudentName"
        Me.cmbStudentName.Size = New System.Drawing.Size(209, 24)
        Me.cmbStudentName.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Select Assessment Type"
        '
        'cmbAssessmentType
        '
        Me.cmbAssessmentType.FormattingEnabled = True
        Me.cmbAssessmentType.Items.AddRange(New Object() {"Short Quiz 1", "Short Quiz 2", "Short Quiz 3", "Short Quiz 4", "Long Quiz 1", "Long Quiz 2", "Long Quiz 3", "Long Quiz 4", " Examination ( Term )"})
        Me.cmbAssessmentType.Location = New System.Drawing.Point(67, 60)
        Me.cmbAssessmentType.Name = "cmbAssessmentType"
        Me.cmbAssessmentType.Size = New System.Drawing.Size(209, 24)
        Me.cmbAssessmentType.TabIndex = 20
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbCourseCode)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbStudentName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbAssessmentType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCourseCode As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbStudentName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbAssessmentType As ComboBox
End Class
