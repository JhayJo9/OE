<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormQuestionList
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
        Me.courseId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Question = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.questionA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorrectAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssessmentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateEdit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnAddnew = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.questionID, Me.courseId, Me.Question, Me.questionA, Me.optionB, Me.optionC, Me.optionD, Me.CorrectAnswer, Me.colAssessmentType, Me.dateEdit, Me.colEdit, Me.colDelete})
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
        Me.questionID.Width = 102
        '
        'courseId
        '
        Me.courseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.courseId.HeaderText = "CourseID"
        Me.courseId.MinimumWidth = 6
        Me.courseId.Name = "courseId"
        Me.courseId.ReadOnly = True
        Me.courseId.Width = 92
        '
        'Question
        '
        Me.Question.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Question.HeaderText = "Question"
        Me.Question.MinimumWidth = 6
        Me.Question.Name = "Question"
        Me.Question.ReadOnly = True
        '
        'questionA
        '
        Me.questionA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.questionA.HeaderText = "A"
        Me.questionA.MinimumWidth = 6
        Me.questionA.Name = "questionA"
        Me.questionA.ReadOnly = True
        Me.questionA.Width = 45
        '
        'optionB
        '
        Me.optionB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionB.HeaderText = "B"
        Me.optionB.MinimumWidth = 6
        Me.optionB.Name = "optionB"
        Me.optionB.ReadOnly = True
        Me.optionB.Width = 45
        '
        'optionC
        '
        Me.optionC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionC.HeaderText = "C"
        Me.optionC.MinimumWidth = 6
        Me.optionC.Name = "optionC"
        Me.optionC.ReadOnly = True
        Me.optionC.Width = 45
        '
        'optionD
        '
        Me.optionD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionD.HeaderText = "D"
        Me.optionD.MinimumWidth = 6
        Me.optionD.Name = "optionD"
        Me.optionD.ReadOnly = True
        Me.optionD.Width = 46
        '
        'CorrectAnswer
        '
        Me.CorrectAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CorrectAnswer.HeaderText = "Correct Answer"
        Me.CorrectAnswer.MinimumWidth = 6
        Me.CorrectAnswer.Name = "CorrectAnswer"
        Me.CorrectAnswer.ReadOnly = True
        Me.CorrectAnswer.Width = 116
        '
        'colAssessmentType
        '
        Me.colAssessmentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAssessmentType.HeaderText = "Assessment Type"
        Me.colAssessmentType.MinimumWidth = 6
        Me.colAssessmentType.Name = "colAssessmentType"
        Me.colAssessmentType.ReadOnly = True
        Me.colAssessmentType.Width = 133
        '
        'dateEdit
        '
        Me.dateEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dateEdit.HeaderText = "Date Edit"
        Me.dateEdit.MinimumWidth = 6
        Me.dateEdit.Name = "dateEdit"
        Me.dateEdit.ReadOnly = True
        Me.dateEdit.Width = 84
        '
        'colEdit
        '
        Me.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEdit.HeaderText = "Edit"
        Me.colEdit.MinimumWidth = 6
        Me.colEdit.Name = "colEdit"
        Me.colEdit.ReadOnly = True
        Me.colEdit.Width = 36
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Width = 53
        '
        'btnAddnew
        '
        Me.btnAddnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddnew.Location = New System.Drawing.Point(903, 14)
        Me.btnAddnew.Name = "btnAddnew"
        Me.btnAddnew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddnew.TabIndex = 2
        Me.btnAddnew.Text = "Add New"
        Me.btnAddnew.UseVisualStyleBackColor = True
        '
        'FormQuestionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 385)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAddnew)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormQuestionList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnAddnew As Button
    Friend WithEvents questionID As DataGridViewTextBoxColumn
    Friend WithEvents courseId As DataGridViewTextBoxColumn
    Friend WithEvents Question As DataGridViewTextBoxColumn
    Friend WithEvents questionA As DataGridViewTextBoxColumn
    Friend WithEvents optionB As DataGridViewTextBoxColumn
    Friend WithEvents optionC As DataGridViewTextBoxColumn
    Friend WithEvents optionD As DataGridViewTextBoxColumn
    Friend WithEvents CorrectAnswer As DataGridViewTextBoxColumn
    Friend WithEvents colAssessmentType As DataGridViewTextBoxColumn
    Friend WithEvents dateEdit As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
End Class
