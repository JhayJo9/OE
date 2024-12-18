<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAssignSchedule
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.cmbAssessmentType = New System.Windows.Forms.ComboBox()
        Me.dtpScheduleDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpScheduleTime = New System.Windows.Forms.DateTimePicker()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Course"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Section"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Assessment Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Schedule Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(75, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Schedule Time"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(75, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Location"
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(78, 92)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(121, 24)
        Me.cmbCourse.TabIndex = 6
        '
        'cmbSection
        '
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(78, 138)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(121, 24)
        Me.cmbSection.TabIndex = 7
        '
        'cmbAssessmentType
        '
        Me.cmbAssessmentType.FormattingEnabled = True
        Me.cmbAssessmentType.Location = New System.Drawing.Point(78, 184)
        Me.cmbAssessmentType.Name = "cmbAssessmentType"
        Me.cmbAssessmentType.Size = New System.Drawing.Size(121, 24)
        Me.cmbAssessmentType.TabIndex = 8
        '
        'dtpScheduleDate
        '
        Me.dtpScheduleDate.Location = New System.Drawing.Point(78, 232)
        Me.dtpScheduleDate.Name = "dtpScheduleDate"
        Me.dtpScheduleDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpScheduleDate.TabIndex = 9
        '
        'dtpScheduleTime
        '
        Me.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpScheduleTime.Location = New System.Drawing.Point(78, 278)
        Me.dtpScheduleTime.Name = "dtpScheduleTime"
        Me.dtpScheduleTime.ShowUpDown = True
        Me.dtpScheduleTime.Size = New System.Drawing.Size(200, 22)
        Me.dtpScheduleTime.TabIndex = 10
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(78, 323)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(100, 22)
        Me.txtLocation.TabIndex = 11
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(78, 365)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 12
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(180, 365)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FormAssignSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.dtpScheduleTime)
        Me.Controls.Add(Me.dtpScheduleDate)
        Me.Controls.Add(Me.cmbAssessmentType)
        Me.Controls.Add(Me.cmbSection)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormAssignSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents cmbAssessmentType As ComboBox
    Friend WithEvents dtpScheduleDate As DateTimePicker
    Friend WithEvents dtpScheduleTime As DateTimePicker
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents btnSave As Button
End Class
