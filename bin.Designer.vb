﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bin
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
        Me.courseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.courseTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.courseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnAddCourse = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAddCourse = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtsddcourseCode = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.courseID, Me.courseTitle, Me.courseCode})
        Me.DataGridView1.Location = New System.Drawing.Point(318, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(386, 150)
        Me.DataGridView1.TabIndex = 14
        '
        'courseID
        '
        Me.courseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.courseID.HeaderText = "course ID"
        Me.courseID.MinimumWidth = 6
        Me.courseID.Name = "courseID"
        Me.courseID.Width = 93
        '
        'courseTitle
        '
        Me.courseTitle.HeaderText = "Course Title"
        Me.courseTitle.MinimumWidth = 6
        Me.courseTitle.Name = "courseTitle"
        Me.courseTitle.Width = 125
        '
        'courseCode
        '
        Me.courseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.courseCode.HeaderText = "Course Code"
        Me.courseCode.MinimumWidth = 6
        Me.courseCode.Name = "courseCode"
        Me.courseCode.Width = 115
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(19, 122)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 31)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnAddCourse
        '
        Me.btnAddCourse.Location = New System.Drawing.Point(133, 122)
        Me.btnAddCourse.Name = "btnAddCourse"
        Me.btnAddCourse.Size = New System.Drawing.Size(140, 31)
        Me.btnAddCourse.TabIndex = 12
        Me.btnAddCourse.Text = "ADD COURSE"
        Me.btnAddCourse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(315, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Added Course: "
        '
        'txtAddCourse
        '
        Me.txtAddCourse.Location = New System.Drawing.Point(27, 49)
        Me.txtAddCourse.Name = "txtAddCourse"
        Me.txtAddCourse.Size = New System.Drawing.Size(168, 22)
        Me.txtAddCourse.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Add Course: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Add Course Code: "
        '
        'txtsddcourseCode
        '
        Me.txtsddcourseCode.Location = New System.Drawing.Point(27, 94)
        Me.txtsddcourseCode.Name = "txtsddcourseCode"
        Me.txtsddcourseCode.Size = New System.Drawing.Size(168, 22)
        Me.txtsddcourseCode.TabIndex = 15
        '
        'bin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 554)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnAddCourse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAddCourse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtsddcourseCode)
        Me.Name = "bin"
        Me.Text = "bin"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents courseID As DataGridViewTextBoxColumn
    Friend WithEvents courseTitle As DataGridViewTextBoxColumn
    Friend WithEvents courseCode As DataGridViewTextBoxColumn
    Friend WithEvents btnBack As Button
    Friend WithEvents btnAddCourse As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAddCourse As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtsddcourseCode As TextBox
End Class
