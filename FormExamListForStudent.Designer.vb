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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.g = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTakeExam = New System.Windows.Forms.DataGridViewButtonColumn()
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
        Me.g.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.colTakeExam})
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
        'Column3
        '
        Me.Column3.HeaderText = "Schedule Date"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Total Questions"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        '
        'colTakeExam
        '
        Me.colTakeExam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colTakeExam.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTakeExam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.colTakeExam.HeaderText = "Take Exam"
        Me.colTakeExam.MinimumWidth = 6
        Me.colTakeExam.Name = "colTakeExam"
        Me.colTakeExam.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTakeExam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTakeExam.Text = "Take Exam"
        Me.colTakeExam.Width = 97
        '
        'FormExamListForStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.g)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormExamListForStudent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.g, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents colTakeExam As DataGridViewButtonColumn
    Public WithEvents g As DataGridView
End Class
