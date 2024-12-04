<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditQuestionList
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.questionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.courseId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Question = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.questionA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorrectAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateEdit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.questionID, Me.courseId, Me.Question, Me.questionA, Me.optionB, Me.optionC, Me.optionD, Me.CorrectAnswer, Me.dateEdit})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1139, 490)
        Me.DataGridView1.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(0, 445)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 45)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'questionID
        '
        Me.questionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.questionID.HeaderText = "QuestionID"
        Me.questionID.MinimumWidth = 6
        Me.questionID.Name = "questionID"
        Me.questionID.Width = 102
        '
        'courseId
        '
        Me.courseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.courseId.HeaderText = "CourseID"
        Me.courseId.MinimumWidth = 6
        Me.courseId.Name = "courseId"
        Me.courseId.Width = 92
        '
        'Question
        '
        Me.Question.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Question.HeaderText = "Question"
        Me.Question.MinimumWidth = 6
        Me.Question.Name = "Question"
        '
        'questionA
        '
        Me.questionA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.questionA.HeaderText = "A"
        Me.questionA.MinimumWidth = 6
        Me.questionA.Name = "questionA"
        Me.questionA.Width = 45
        '
        'optionB
        '
        Me.optionB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionB.HeaderText = "B"
        Me.optionB.MinimumWidth = 6
        Me.optionB.Name = "optionB"
        Me.optionB.Width = 45
        '
        'optionC
        '
        Me.optionC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionC.HeaderText = "C"
        Me.optionC.MinimumWidth = 6
        Me.optionC.Name = "optionC"
        Me.optionC.Width = 45
        '
        'optionD
        '
        Me.optionD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.optionD.HeaderText = "D"
        Me.optionD.MinimumWidth = 6
        Me.optionD.Name = "optionD"
        Me.optionD.Width = 46
        '
        'CorrectAnswer
        '
        Me.CorrectAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CorrectAnswer.HeaderText = "Correct Answer"
        Me.CorrectAnswer.MinimumWidth = 6
        Me.CorrectAnswer.Name = "CorrectAnswer"
        Me.CorrectAnswer.Width = 116
        '
        'dateEdit
        '
        Me.dateEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dateEdit.HeaderText = "Date Edit"
        Me.dateEdit.MinimumWidth = 6
        Me.dateEdit.Name = "dateEdit"
        Me.dateEdit.Width = 84
        '
        'FormEditQuestionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormEditQuestionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEditQuestionList"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExit As Button
    Friend WithEvents questionID As DataGridViewTextBoxColumn
    Friend WithEvents courseId As DataGridViewTextBoxColumn
    Friend WithEvents Question As DataGridViewTextBoxColumn
    Friend WithEvents questionA As DataGridViewTextBoxColumn
    Friend WithEvents optionB As DataGridViewTextBoxColumn
    Friend WithEvents optionC As DataGridViewTextBoxColumn
    Friend WithEvents optionD As DataGridViewTextBoxColumn
    Friend WithEvents CorrectAnswer As DataGridViewTextBoxColumn
    Friend WithEvents dateEdit As DataGridViewTextBoxColumn
End Class
