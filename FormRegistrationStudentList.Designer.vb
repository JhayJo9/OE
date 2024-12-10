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
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMiddlename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContactNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnAddnew = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.colLastname, Me.colFirstname, Me.colMiddlename, Me.colDoB, Me.colGender, Me.colEmail, Me.colContactNum, Me.DataGridViewImageColumn1, Me.DataGridViewImageColumn2, Me.DataGridViewImageColumn3})
        Me.DataGridView2.Location = New System.Drawing.Point(18, 48)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1014, 491)
        Me.DataGridView2.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Student Number"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 121
        '
        'colLastname
        '
        Me.colLastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colLastname.HeaderText = "Lastname"
        Me.colLastname.MinimumWidth = 6
        Me.colLastname.Name = "colLastname"
        Me.colLastname.ReadOnly = True
        '
        'colFirstname
        '
        Me.colFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFirstname.HeaderText = "Firstname"
        Me.colFirstname.MinimumWidth = 6
        Me.colFirstname.Name = "colFirstname"
        Me.colFirstname.ReadOnly = True
        '
        'colMiddlename
        '
        Me.colMiddlename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colMiddlename.HeaderText = "Middlename"
        Me.colMiddlename.MinimumWidth = 6
        Me.colMiddlename.Name = "colMiddlename"
        Me.colMiddlename.ReadOnly = True
        '
        'colDoB
        '
        Me.colDoB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDoB.HeaderText = "Date of Birth"
        Me.colDoB.MinimumWidth = 6
        Me.colDoB.Name = "colDoB"
        Me.colDoB.ReadOnly = True
        Me.colDoB.Width = 76
        '
        'colGender
        '
        Me.colGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colGender.HeaderText = "Gender"
        Me.colGender.MinimumWidth = 6
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 81
        '
        'colEmail
        '
        Me.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEmail.HeaderText = "Email"
        Me.colEmail.MinimumWidth = 6
        Me.colEmail.Name = "colEmail"
        Me.colEmail.ReadOnly = True
        Me.colEmail.Width = 70
        '
        'colContactNum
        '
        Me.colContactNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colContactNum.HeaderText = "Contact No."
        Me.colContactNum.MinimumWidth = 6
        Me.colContactNum.Name = "colContactNum"
        Me.colContactNum.ReadOnly = True
        Me.colContactNum.Width = 97
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.HeaderText = "Edit"
        Me.DataGridViewImageColumn1.MinimumWidth = 6
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 36
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn2.HeaderText = "Delete"
        Me.DataGridViewImageColumn2.MinimumWidth = 6
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 53
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn3.HeaderText = "View"
        Me.DataGridViewImageColumn3.MinimumWidth = 6
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn3.Width = 65
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
        'FormRegistrationStudentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAddnew)
        Me.Controls.Add(Me.DataGridView2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormRegistrationStudentList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents colLastname As DataGridViewTextBoxColumn
    Friend WithEvents colFirstname As DataGridViewTextBoxColumn
    Friend WithEvents colMiddlename As DataGridViewTextBoxColumn
    Friend WithEvents colDoB As DataGridViewTextBoxColumn
    Friend WithEvents colGender As DataGridViewTextBoxColumn
    Friend WithEvents colEmail As DataGridViewTextBoxColumn
    Friend WithEvents colContactNum As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As DataGridViewImageColumn
    Friend WithEvents btnAddnew As Button
End Class
