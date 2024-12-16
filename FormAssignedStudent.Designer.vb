<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAssignedStudent
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
        Me.cmbAssessmentType = New System.Windows.Forms.ComboBox()
        Me.cmbStudentName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.cmbCourseCode = New System.Windows.Forms.ComboBox()
        Me.lblStudentId = New System.Windows.Forms.Label()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.dtpScheduleDate = New System.Windows.Forms.DateTimePicker()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.sdfasdf = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpScheduleTime = New System.Windows.Forms.DateTimePicker()
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbAssessmentType
        '
        Me.cmbAssessmentType.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAssessmentType.FormattingEnabled = True
        Me.cmbAssessmentType.Location = New System.Drawing.Point(59, 76)
        Me.cmbAssessmentType.Name = "cmbAssessmentType"
        Me.cmbAssessmentType.Size = New System.Drawing.Size(212, 23)
        Me.cmbAssessmentType.TabIndex = 0
        '
        'cmbStudentName
        '
        Me.cmbStudentName.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStudentName.FormattingEnabled = True
        Me.cmbStudentName.Location = New System.Drawing.Point(59, 129)
        Me.cmbStudentName.Name = "cmbStudentName"
        Me.cmbStudentName.Size = New System.Drawing.Size(321, 23)
        Me.cmbStudentName.Sorted = True
        Me.cmbStudentName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Assessment Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Select Student"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Course Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(413, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Section Code"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(140, 220)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 33)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(59, 220)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 33)
        Me.btnBack.TabIndex = 10
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'cmbCourseCode
        '
        Me.cmbCourseCode.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCourseCode.FormattingEnabled = True
        Me.cmbCourseCode.Location = New System.Drawing.Point(59, 182)
        Me.cmbCourseCode.Name = "cmbCourseCode"
        Me.cmbCourseCode.Size = New System.Drawing.Size(321, 23)
        Me.cmbCourseCode.TabIndex = 11
        '
        'lblStudentId
        '
        Me.lblStudentId.AutoSize = True
        Me.lblStudentId.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentId.Location = New System.Drawing.Point(306, 54)
        Me.lblStudentId.Name = "lblStudentId"
        Me.lblStudentId.Size = New System.Drawing.Size(66, 15)
        Me.lblStudentId.TabIndex = 13
        Me.lblStudentId.Text = "Student ID "
        '
        'txtStudentID
        '
        Me.txtStudentID.Enabled = False
        Me.txtStudentID.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStudentID.Location = New System.Drawing.Point(309, 78)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.Size = New System.Drawing.Size(228, 23)
        Me.txtStudentID.TabIndex = 14
        '
        'dtpScheduleDate
        '
        Me.dtpScheduleDate.Enabled = False
        Me.dtpScheduleDate.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpScheduleDate.Location = New System.Drawing.Point(416, 184)
        Me.dtpScheduleDate.Name = "dtpScheduleDate"
        Me.dtpScheduleDate.Size = New System.Drawing.Size(200, 23)
        Me.dtpScheduleDate.TabIndex = 15
        '
        'txtLocation
        '
        Me.txtLocation.Enabled = False
        Me.txtLocation.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(594, 78)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(228, 23)
        Me.txtLocation.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(413, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Schedule Date"
        '
        'sdfasdf
        '
        Me.sdfasdf.AutoSize = True
        Me.sdfasdf.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sdfasdf.Location = New System.Drawing.Point(591, 54)
        Me.sdfasdf.Name = "sdfasdf"
        Me.sdfasdf.Size = New System.Drawing.Size(53, 15)
        Me.sdfasdf.TabIndex = 18
        Me.sdfasdf.Text = "Location"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(630, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Schedule Time"
        '
        'dtpScheduleTime
        '
        Me.dtpScheduleTime.Enabled = False
        Me.dtpScheduleTime.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpScheduleTime.Location = New System.Drawing.Point(633, 184)
        Me.dtpScheduleTime.Name = "dtpScheduleTime"
        Me.dtpScheduleTime.ShowUpDown = True
        Me.dtpScheduleTime.Size = New System.Drawing.Size(200, 23)
        Me.dtpScheduleTime.TabIndex = 19
        '
        'cmbSection
        '
        Me.cmbSection.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(416, 129)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(321, 23)
        Me.cmbSection.TabIndex = 21
        '
        'FormAssignedStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbSection)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpScheduleTime)
        Me.Controls.Add(Me.sdfasdf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.dtpScheduleDate)
        Me.Controls.Add(Me.txtStudentID)
        Me.Controls.Add(Me.lblStudentId)
        Me.Controls.Add(Me.cmbCourseCode)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbStudentName)
        Me.Controls.Add(Me.cmbAssessmentType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormAssignedStudent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbAssessmentType As ComboBox
    Friend WithEvents cmbStudentName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblStudentId As Label
    Public WithEvents txtStudentID As TextBox
    Public WithEvents cmbCourseCode As ComboBox
    Friend WithEvents dtpScheduleDate As DateTimePicker
    Public WithEvents txtLocation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents sdfasdf As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpScheduleTime As DateTimePicker
    Public WithEvents cmbSection As ComboBox
End Class
