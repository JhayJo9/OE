<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCourse
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAddCourse = New System.Windows.Forms.TextBox()
        Me.cbAddedCourse = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddCourse = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add Course: "
        '
        'txtAddCourse
        '
        Me.txtAddCourse.Location = New System.Drawing.Point(128, 42)
        Me.txtAddCourse.Name = "txtAddCourse"
        Me.txtAddCourse.Size = New System.Drawing.Size(168, 22)
        Me.txtAddCourse.TabIndex = 1
        '
        'cbAddedCourse
        '
        Me.cbAddedCourse.FormattingEnabled = True
        Me.cbAddedCourse.Location = New System.Drawing.Point(128, 69)
        Me.cbAddedCourse.Name = "cbAddedCourse"
        Me.cbAddedCourse.Size = New System.Drawing.Size(168, 24)
        Me.cbAddedCourse.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Added Course: "
        '
        'btnAddCourse
        '
        Me.btnAddCourse.Location = New System.Drawing.Point(25, 124)
        Me.btnAddCourse.Name = "btnAddCourse"
        Me.btnAddCourse.Size = New System.Drawing.Size(140, 31)
        Me.btnAddCourse.TabIndex = 4
        Me.btnAddCourse.Text = "ADD COURSE"
        Me.btnAddCourse.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 176)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 53)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'FormCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnAddCourse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbAddedCourse)
        Me.Controls.Add(Me.txtAddCourse)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormCourse"
        Me.Text = "FormCourse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtAddCourse As TextBox
    Friend WithEvents cbAddedCourse As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddCourse As Button
    Friend WithEvents btnBack As Button
End Class
