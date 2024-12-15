<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStudentResults
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
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.cmbAssessType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlResults = New System.Windows.Forms.Panel()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lblExamDateTitle = New System.Windows.Forms.Label()
        Me.lblExamDate = New System.Windows.Forms.Label()
        Me.lblScoreTitle = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpFilters.SuspendLayout()
        Me.pnlResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Location = New System.Drawing.Point(87, 48)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(48, 16)
        Me.lblDateTime.TabIndex = 0
        Me.lblDateTime.Text = "Label1"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(87, 92)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(48, 16)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "Label2"
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.cmbAssessType)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.cmbCourse)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Location = New System.Drawing.Point(77, 122)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(482, 175)
        Me.grpFilters.TabIndex = 2
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "GroupBox1"
        '
        'cmbAssessType
        '
        Me.cmbAssessType.FormattingEnabled = True
        Me.cmbAssessType.Location = New System.Drawing.Point(13, 116)
        Me.cmbAssessType.Name = "cmbAssessType"
        Me.cmbAssessType.Size = New System.Drawing.Size(306, 24)
        Me.cmbAssessType.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Label2"
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(13, 48)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(306, 24)
        Me.cmbCourse.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'pnlResults
        '
        Me.pnlResults.Controls.Add(Me.lblScore)
        Me.pnlResults.Controls.Add(Me.lblExamDateTitle)
        Me.pnlResults.Controls.Add(Me.lblExamDate)
        Me.pnlResults.Controls.Add(Me.lblScoreTitle)
        Me.pnlResults.Location = New System.Drawing.Point(77, 336)
        Me.pnlResults.Name = "pnlResults"
        Me.pnlResults.Size = New System.Drawing.Size(668, 127)
        Me.pnlResults.TabIndex = 3
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Location = New System.Drawing.Point(10, 38)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(48, 16)
        Me.lblScore.TabIndex = 7
        Me.lblScore.Text = "Label2"
        '
        'lblExamDateTitle
        '
        Me.lblExamDateTitle.AutoSize = True
        Me.lblExamDateTitle.Location = New System.Drawing.Point(10, 65)
        Me.lblExamDateTitle.Name = "lblExamDateTitle"
        Me.lblExamDateTitle.Size = New System.Drawing.Size(48, 16)
        Me.lblExamDateTitle.TabIndex = 6
        Me.lblExamDateTitle.Text = "Label2"
        '
        'lblExamDate
        '
        Me.lblExamDate.AutoSize = True
        Me.lblExamDate.Location = New System.Drawing.Point(10, 94)
        Me.lblExamDate.Name = "lblExamDate"
        Me.lblExamDate.Size = New System.Drawing.Size(48, 16)
        Me.lblExamDate.TabIndex = 5
        Me.lblExamDate.Text = "Label2"
        '
        'lblScoreTitle
        '
        Me.lblScoreTitle.AutoSize = True
        Me.lblScoreTitle.Location = New System.Drawing.Point(10, 12)
        Me.lblScoreTitle.Name = "lblScoreTitle"
        Me.lblScoreTitle.Size = New System.Drawing.Size(48, 16)
        Me.lblScoreTitle.TabIndex = 4
        Me.lblScoreTitle.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "EXAM RESULTS"
        '
        'FormStudentResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 493)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlResults)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblDateTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormStudentResults"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.pnlResults.ResumeLayout(False)
        Me.pnlResults.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents cmbAssessType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlResults As Panel
    Friend WithEvents lblScore As Label
    Friend WithEvents lblExamDateTitle As Label
    Friend WithEvents lblExamDate As Label
    Friend WithEvents lblScoreTitle As Label
    Friend WithEvents Label3 As Label
End Class
