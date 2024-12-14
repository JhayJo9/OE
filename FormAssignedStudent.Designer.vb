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
        Me.txtSectionCode = New System.Windows.Forms.TextBox()
        Me.lblStudentId = New System.Windows.Forms.Label()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmbAssessmentType
        '
        Me.cmbAssessmentType.FormattingEnabled = True
        Me.cmbAssessmentType.Location = New System.Drawing.Point(59, 76)
        Me.cmbAssessmentType.Name = "cmbAssessmentType"
        Me.cmbAssessmentType.Size = New System.Drawing.Size(212, 24)
        Me.cmbAssessmentType.TabIndex = 0
        '
        'cmbStudentName
        '
        Me.cmbStudentName.FormattingEnabled = True
        Me.cmbStudentName.Location = New System.Drawing.Point(59, 129)
        Me.cmbStudentName.Name = "cmbStudentName"
        Me.cmbStudentName.Size = New System.Drawing.Size(321, 24)
        Me.cmbStudentName.Sorted = True
        Me.cmbStudentName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Assessment Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Select Student"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Course Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(413, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Section Code"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(74, 239)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(179, 239)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 10
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'cmbCourseCode
        '
        Me.cmbCourseCode.FormattingEnabled = True
        Me.cmbCourseCode.Location = New System.Drawing.Point(59, 182)
        Me.cmbCourseCode.Name = "cmbCourseCode"
        Me.cmbCourseCode.Size = New System.Drawing.Size(321, 24)
        Me.cmbCourseCode.TabIndex = 11
        '
        'txtSectionCode
        '
        Me.txtSectionCode.Enabled = False
        Me.txtSectionCode.Location = New System.Drawing.Point(416, 130)
        Me.txtSectionCode.Name = "txtSectionCode"
        Me.txtSectionCode.Size = New System.Drawing.Size(228, 22)
        Me.txtSectionCode.TabIndex = 12
        '
        'lblStudentId
        '
        Me.lblStudentId.AutoSize = True
        Me.lblStudentId.Location = New System.Drawing.Point(306, 54)
        Me.lblStudentId.Name = "lblStudentId"
        Me.lblStudentId.Size = New System.Drawing.Size(71, 16)
        Me.lblStudentId.TabIndex = 13
        Me.lblStudentId.Text = "Student ID "
        '
        'txtStudentID
        '
        Me.txtStudentID.Enabled = False
        Me.txtStudentID.Location = New System.Drawing.Point(309, 78)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.Size = New System.Drawing.Size(228, 22)
        Me.txtStudentID.TabIndex = 14
        '
        'FormAssignedStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtStudentID)
        Me.Controls.Add(Me.lblStudentId)
        Me.Controls.Add(Me.txtSectionCode)
        Me.Controls.Add(Me.cmbCourseCode)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbStudentName)
        Me.Controls.Add(Me.cmbAssessmentType)
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
    Public WithEvents txtSectionCode As TextBox
End Class
