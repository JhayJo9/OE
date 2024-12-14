<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExamList
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
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.cmbAssessementType = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colQuestion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCorrectAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCourse
        '
        Me.cmbCourse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(859, 31)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(146, 24)
        Me.cmbCourse.TabIndex = 1
        '
        'cmbAssessementType
        '
        Me.cmbAssessementType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAssessementType.FormattingEnabled = True
        Me.cmbAssessementType.Location = New System.Drawing.Point(707, 31)
        Me.cmbAssessementType.Name = "cmbAssessementType"
        Me.cmbAssessementType.Size = New System.Drawing.Size(146, 24)
        Me.cmbAssessementType.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colQuestion, Me.colOptionA, Me.colOptionB, Me.colOptionC, Me.colOptionD, Me.colCorrectAnswer, Me.ColEdit, Me.colDelete})
        Me.DataGridView1.Location = New System.Drawing.Point(17, 61)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(988, 373)
        Me.DataGridView1.TabIndex = 3
        '
        'colQuestion
        '
        Me.colQuestion.HeaderText = "Question"
        Me.colQuestion.MinimumWidth = 6
        Me.colQuestion.Name = "colQuestion"
        '
        'colOptionA
        '
        Me.colOptionA.HeaderText = "Option A"
        Me.colOptionA.MinimumWidth = 6
        Me.colOptionA.Name = "colOptionA"
        '
        'colOptionB
        '
        Me.colOptionB.HeaderText = "Option B"
        Me.colOptionB.MinimumWidth = 6
        Me.colOptionB.Name = "colOptionB"
        '
        'colOptionC
        '
        Me.colOptionC.HeaderText = "Option C"
        Me.colOptionC.MinimumWidth = 6
        Me.colOptionC.Name = "colOptionC"
        '
        'colOptionD
        '
        Me.colOptionD.HeaderText = "Option D"
        Me.colOptionD.MinimumWidth = 6
        Me.colOptionD.Name = "colOptionD"
        '
        'colCorrectAnswer
        '
        Me.colCorrectAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCorrectAnswer.HeaderText = "Correct Answer"
        Me.colCorrectAnswer.MinimumWidth = 6
        Me.colCorrectAnswer.Name = "colCorrectAnswer"
        Me.colCorrectAnswer.Width = 116
        '
        'ColEdit
        '
        Me.ColEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColEdit.HeaderText = "Edit"
        Me.ColEdit.MinimumWidth = 6
        Me.ColEdit.Name = "ColEdit"
        Me.ColEdit.Width = 36
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Width = 53
        '
        'FormExamList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmbAssessementType)
        Me.Controls.Add(Me.cmbCourse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormExamList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents cmbAssessementType As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colQuestion As DataGridViewTextBoxColumn
    Friend WithEvents colOptionA As DataGridViewTextBoxColumn
    Friend WithEvents colOptionB As DataGridViewTextBoxColumn
    Friend WithEvents colOptionC As DataGridViewTextBoxColumn
    Friend WithEvents colOptionD As DataGridViewTextBoxColumn
    Friend WithEvents colCorrectAnswer As DataGridViewTextBoxColumn
    Friend WithEvents ColEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
End Class
