<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class users
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
        Me.userID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRole = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userID, Me.colFirstname, Me.colLastname, Me.colRole, Me.colEdit, Me.colDelete})
        Me.DataGridView1.Location = New System.Drawing.Point(27, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(750, 367)
        Me.DataGridView1.TabIndex = 0
        '
        'userID
        '
        Me.userID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.userID.HeaderText = "ID"
        Me.userID.MinimumWidth = 6
        Me.userID.Name = "userID"
        Me.userID.Width = 49
        '
        'colFirstname
        '
        Me.colFirstname.HeaderText = "Firstname"
        Me.colFirstname.MinimumWidth = 6
        Me.colFirstname.Name = "colFirstname"
        '
        'colLastname
        '
        Me.colLastname.HeaderText = "Lastname"
        Me.colLastname.MinimumWidth = 6
        Me.colLastname.Name = "colLastname"
        '
        'colRole
        '
        Me.colRole.HeaderText = "Role"
        Me.colRole.MinimumWidth = 6
        Me.colRole.Name = "colRole"
        Me.colRole.ReadOnly = True
        Me.colRole.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRole.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colEdit
        '
        Me.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEdit.HeaderText = "Edit"
        Me.colEdit.MinimumWidth = 6
        Me.colEdit.Name = "colEdit"
        Me.colEdit.ReadOnly = True
        Me.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colEdit.Width = 59
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDelete.Width = 76
        '
        'users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "users"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents userID As DataGridViewTextBoxColumn
    Friend WithEvents colFirstname As DataGridViewTextBoxColumn
    Friend WithEvents colLastname As DataGridViewTextBoxColumn
    Friend WithEvents colRole As DataGridViewComboBoxColumn
    Friend WithEvents colEdit As DataGridViewImageColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
End Class
