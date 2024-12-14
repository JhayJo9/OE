<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegistrationStudentList
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.questionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Question = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.questionA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorrectAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssessmentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCourseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colView = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnAddnew = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgwRegistrationList = New System.Windows.Forms.DataGridView()
        Me.studentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Firstnamef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EDITT = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DELETEE = New System.Windows.Forms.DataGridViewImageColumn()
        Me.VIEWW = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwRegistrationList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.questionID, Me.Question, Me.questionA, Me.optionB, Me.optionC, Me.optionD, Me.CorrectAnswer, Me.colAssessmentType, Me.colCourseCode, Me.colEdit, Me.colDelete, Me.colView})
        Me.DataGridView1.Location = New System.Drawing.Point(18, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(960, 325)
        Me.DataGridView1.TabIndex = 1
        '
        'questionID
        '
        Me.questionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.questionID.HeaderText = "QuestionID"
        Me.questionID.MinimumWidth = 6
        Me.questionID.Name = "questionID"
        Me.questionID.ReadOnly = True
        Me.questionID.Width = 125
        '
        'Question
        '
        Me.Question.HeaderText = "Question"
        Me.Question.MinimumWidth = 6
        Me.Question.Name = "Question"
        Me.Question.ReadOnly = True
        Me.Question.Width = 165
        '
        'questionA
        '
        Me.questionA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.questionA.HeaderText = "A"
        Me.questionA.MinimumWidth = 6
        Me.questionA.Name = "questionA"
        Me.questionA.ReadOnly = True
        Me.questionA.Width = 125
        '
        'optionB
        '
        Me.optionB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionB.HeaderText = "B"
        Me.optionB.MinimumWidth = 6
        Me.optionB.Name = "optionB"
        Me.optionB.ReadOnly = True
        Me.optionB.Width = 125
        '
        'optionC
        '
        Me.optionC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionC.HeaderText = "C"
        Me.optionC.MinimumWidth = 6
        Me.optionC.Name = "optionC"
        Me.optionC.ReadOnly = True
        Me.optionC.Width = 125
        '
        'optionD
        '
        Me.optionD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionD.HeaderText = "D"
        Me.optionD.MinimumWidth = 6
        Me.optionD.Name = "optionD"
        Me.optionD.ReadOnly = True
        Me.optionD.Width = 125
        '
        'CorrectAnswer
        '
        Me.CorrectAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CorrectAnswer.HeaderText = "Correct Answer"
        Me.CorrectAnswer.MinimumWidth = 6
        Me.CorrectAnswer.Name = "CorrectAnswer"
        Me.CorrectAnswer.ReadOnly = True
        Me.CorrectAnswer.Width = 125
        '
        'colAssessmentType
        '
        Me.colAssessmentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAssessmentType.HeaderText = "Assessment Type"
        Me.colAssessmentType.MinimumWidth = 6
        Me.colAssessmentType.Name = "colAssessmentType"
        Me.colAssessmentType.ReadOnly = True
        Me.colAssessmentType.Width = 125
        '
        'colCourseCode
        '
        Me.colCourseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCourseCode.HeaderText = "Course Code"
        Me.colCourseCode.MinimumWidth = 6
        Me.colCourseCode.Name = "colCourseCode"
        Me.colCourseCode.ReadOnly = True
        Me.colCourseCode.Width = 125
        '
        'colEdit
        '
        Me.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEdit.HeaderText = "Edit"
        Me.colEdit.MinimumWidth = 6
        Me.colEdit.Name = "colEdit"
        Me.colEdit.ReadOnly = True
        Me.colEdit.Width = 125
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Width = 125
        '
        'colView
        '
        Me.colView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colView.HeaderText = "View"
        Me.colView.MinimumWidth = 6
        Me.colView.Name = "colView"
        Me.colView.ReadOnly = True
        Me.colView.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colView.Width = 125
        '
        'btnAddnew
        '
        Me.btnAddnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddnew.Location = New System.Drawing.Point(957, 19)
        Me.btnAddnew.Name = "btnAddnew"
        Me.btnAddnew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddnew.TabIndex = 3
        Me.btnAddnew.Text = "Add new"
        Me.btnAddnew.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(763, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(179, 22)
        Me.txtSearch.TabIndex = 4
        '
        'dgwRegistrationList
        '
        Me.dgwRegistrationList.AllowUserToAddRows = False
        Me.dgwRegistrationList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwRegistrationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwRegistrationList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.studentNo, Me.ff, Me.Firstnamef, Me.Column2, Me.gg, Me.colGender, Me.colEmail, Me.Column3, Me.Column1, Me.EDITT, Me.DELETEE, Me.VIEWW})
        Me.dgwRegistrationList.Location = New System.Drawing.Point(18, 48)
        Me.dgwRegistrationList.Name = "dgwRegistrationList"
        Me.dgwRegistrationList.ReadOnly = True
        Me.dgwRegistrationList.RowHeadersVisible = False
        Me.dgwRegistrationList.RowHeadersWidth = 51
        Me.dgwRegistrationList.RowTemplate.Height = 24
        Me.dgwRegistrationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwRegistrationList.Size = New System.Drawing.Size(1014, 491)
        Me.dgwRegistrationList.TabIndex = 2
        '
        'studentNo
        '
        Me.studentNo.HeaderText = "Student Number"
        Me.studentNo.MinimumWidth = 6
        Me.studentNo.Name = "studentNo"
        Me.studentNo.ReadOnly = True
        Me.studentNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.studentNo.Width = 121
        '
        'ff
        '
        Me.ff.HeaderText = "Lastname"
        Me.ff.MinimumWidth = 6
        Me.ff.Name = "ff"
        Me.ff.ReadOnly = True
        Me.ff.Width = 125
        '
        'Firstnamef
        '
        Me.Firstnamef.HeaderText = "Firstname"
        Me.Firstnamef.MinimumWidth = 6
        Me.Firstnamef.Name = "Firstnamef"
        Me.Firstnamef.ReadOnly = True
        Me.Firstnamef.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "Middlename"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 125
        '
        'gg
        '
        Me.gg.HeaderText = "Date of Birth"
        Me.gg.MinimumWidth = 6
        Me.gg.Name = "gg"
        Me.gg.ReadOnly = True
        Me.gg.Width = 125
        '
        'colGender
        '
        Me.colGender.HeaderText = "Gender"
        Me.colGender.MinimumWidth = 6
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 81
        '
        'colEmail
        '
        Me.colEmail.HeaderText = "Email"
        Me.colEmail.MinimumWidth = 6
        Me.colEmail.Name = "colEmail"
        Me.colEmail.ReadOnly = True
        Me.colEmail.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "Contact No."
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Section Code"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 108
        '
        'EDITT
        '
        Me.EDITT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EDITT.HeaderText = "Edit"
        Me.EDITT.MinimumWidth = 6
        Me.EDITT.Name = "EDITT"
        Me.EDITT.ReadOnly = True
        Me.EDITT.Width = 36
        '
        'DELETEE
        '
        Me.DELETEE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DELETEE.HeaderText = "Delete"
        Me.DELETEE.MinimumWidth = 6
        Me.DELETEE.Name = "DELETEE"
        Me.DELETEE.ReadOnly = True
        Me.DELETEE.Width = 53
        '
        'VIEWW
        '
        Me.VIEWW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VIEWW.HeaderText = "View"
        Me.VIEWW.MinimumWidth = 6
        Me.VIEWW.Name = "VIEWW"
        Me.VIEWW.ReadOnly = True
        Me.VIEWW.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VIEWW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.VIEWW.Width = 65
        '
        'FormRegistrationStudentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnAddnew)
        Me.Controls.Add(Me.dgwRegistrationList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormRegistrationStudentList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwRegistrationList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents questionID As DataGridViewTextBoxColumn
    Friend WithEvents Question As DataGridViewTextBoxColumn
    Friend WithEvents questionA As DataGridViewTextBoxColumn
    Friend WithEvents optionB As DataGridViewTextBoxColumn
    Friend WithEvents optionC As DataGridViewTextBoxColumn
    Friend WithEvents optionD As DataGridViewTextBoxColumn
    Friend WithEvents CorrectAnswer As DataGridViewTextBoxColumn
    Friend WithEvents colAssessmentType As DataGridViewTextBoxColumn
    Friend WithEvents colCourseCode As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
    Friend WithEvents colView As DataGridViewImageColumn
    Friend WithEvents btnAddnew As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgwRegistrationList As DataGridView
    Friend WithEvents studentNo As DataGridViewTextBoxColumn
    Friend WithEvents ff As DataGridViewTextBoxColumn
    Friend WithEvents Firstnamef As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents gg As DataGridViewTextBoxColumn
    Friend WithEvents colGender As DataGridViewTextBoxColumn
    Friend WithEvents colEmail As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents EDITT As DataGridViewImageColumn
    Friend WithEvents DELETEE As DataGridViewImageColumn
    Friend WithEvents VIEWW As DataGridViewImageColumn
End Class
