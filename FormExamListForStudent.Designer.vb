<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExamListForStudent
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.g = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExamStatus = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnVerifyExam = New System.Windows.Forms.Button()
        CType(Me.g, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'g
        '
        Me.g.AllowUserToAddRows = False
        Me.g.AllowUserToDeleteRows = False
        Me.g.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.g.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.g.BackgroundColor = System.Drawing.Color.Silver
        Me.g.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.g.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.g.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column3, Me.Column5, Me.Column6, Me.ExamStatus})
        Me.g.Location = New System.Drawing.Point(12, 33)
        Me.g.MultiSelect = False
        Me.g.Name = "g"
        Me.g.RowHeadersVisible = False
        Me.g.RowHeadersWidth = 51
        Me.g.RowTemplate.Height = 24
        Me.g.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.g.Size = New System.Drawing.Size(943, 522)
        Me.g.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Course"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Assessment Type"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Total Questions"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Schedule Date"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Schedule Time"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Room No."
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        '
        'ExamStatus
        '
        Me.ExamStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExamStatus.DefaultCellStyle = DataGridViewCellStyle1
        Me.ExamStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExamStatus.HeaderText = "Take Exam"
        Me.ExamStatus.MinimumWidth = 6
        Me.ExamStatus.Name = "ExamStatus"
        Me.ExamStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExamStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ExamStatus.Text = "Take Exam"
        Me.ExamStatus.Width = 97
        '
        'btnVerifyExam
        '
        Me.btnVerifyExam.Location = New System.Drawing.Point(117, 4)
        Me.btnVerifyExam.Name = "btnVerifyExam"
        Me.btnVerifyExam.Size = New System.Drawing.Size(75, 23)
        Me.btnVerifyExam.TabIndex = 1
        Me.btnVerifyExam.Text = "Button1"
        Me.btnVerifyExam.UseVisualStyleBackColor = True
        '
        'FormExamListForStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnVerifyExam)
        Me.Controls.Add(Me.g)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormExamListForStudent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.g, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents g As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents ExamStatus As DataGridViewButtonColumn
    Friend WithEvents btnVerifyExam As Button
End Class
