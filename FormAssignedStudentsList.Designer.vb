<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssignedStudentsList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvAssignedStudents = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssignedcourse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssignedAsesseType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colView = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgvAssignedStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAssignedStudents
        '
        Me.dgvAssignedStudents.AllowUserToAddRows = False
        Me.dgvAssignedStudents.AllowUserToResizeColumns = False
        Me.dgvAssignedStudents.AllowUserToResizeRows = False
        Me.dgvAssignedStudents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssignedStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAssignedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssignedStudents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.colStudentNo, Me.colStudentName, Me.colAssignedcourse, Me.colAssignedAsesseType, Me.Column1, Me.colEdit, Me.colDelete, Me.colView})
        Me.dgvAssignedStudents.Location = New System.Drawing.Point(16, 57)
        Me.dgvAssignedStudents.Name = "dgvAssignedStudents"
        Me.dgvAssignedStudents.ReadOnly = True
        Me.dgvAssignedStudents.RowHeadersVisible = False
        Me.dgvAssignedStudents.RowHeadersWidth = 51
        Me.dgvAssignedStudents.RowTemplate.Height = 24
        Me.dgvAssignedStudents.Size = New System.Drawing.Size(959, 477)
        Me.dgvAssignedStudents.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(900, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "ID"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 49
        '
        'colStudentNo
        '
        Me.colStudentNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colStudentNo.HeaderText = "Student No."
        Me.colStudentNo.MinimumWidth = 6
        Me.colStudentNo.Name = "colStudentNo"
        Me.colStudentNo.ReadOnly = True
        Me.colStudentNo.Width = 105
        '
        'colStudentName
        '
        Me.colStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStudentName.HeaderText = "Student Name"
        Me.colStudentName.MinimumWidth = 6
        Me.colStudentName.Name = "colStudentName"
        Me.colStudentName.ReadOnly = True
        '
        'colAssignedcourse
        '
        Me.colAssignedcourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAssignedcourse.HeaderText = "Course Code"
        Me.colAssignedcourse.MinimumWidth = 6
        Me.colAssignedcourse.Name = "colAssignedcourse"
        Me.colAssignedcourse.ReadOnly = True
        Me.colAssignedcourse.Width = 115
        '
        'colAssignedAsesseType
        '
        Me.colAssignedAsesseType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAssignedAsesseType.HeaderText = "Assigned Assess. type"
        Me.colAssignedAsesseType.MinimumWidth = 6
        Me.colAssignedAsesseType.Name = "colAssignedAsesseType"
        Me.colAssignedAsesseType.ReadOnly = True
        Me.colAssignedAsesseType.Width = 173
        '
        'Column1
        '
        Me.Column1.HeaderText = "Section Code"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
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
        'colView
        '
        Me.colView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colView.HeaderText = "View"
        Me.colView.MinimumWidth = 6
        Me.colView.Name = "colView"
        Me.colView.ReadOnly = True
        Me.colView.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colView.Width = 65
        '
        'FormAssignedStudentsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 546)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgvAssignedStudents)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormAssignedStudentsList"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAssignedStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvAssignedStudents As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents colStudentNo As DataGridViewTextBoxColumn
    Friend WithEvents colStudentName As DataGridViewTextBoxColumn
    Friend WithEvents colAssignedcourse As DataGridViewTextBoxColumn
    Friend WithEvents colAssignedAsesseType As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
    Friend WithEvents colView As DataGridViewImageColumn
End Class
