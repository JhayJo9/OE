<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSection
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnAddSection = New System.Windows.Forms.Button()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(27, 178)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(140, 31)
        Me.btnBack.TabIndex = 31
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnAddSection
        '
        Me.btnAddSection.Location = New System.Drawing.Point(199, 178)
        Me.btnAddSection.Name = "btnAddSection"
        Me.btnAddSection.Size = New System.Drawing.Size(140, 31)
        Me.btnAddSection.TabIndex = 28
        Me.btnAddSection.Text = "ADD"
        Me.btnAddSection.UseVisualStyleBackColor = True
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(149, 88)
        Me.txtSection.Multiline = True
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(366, 30)
        Me.txtSection.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Section"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Course Code: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 25)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Adding Section"
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(149, 129)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(366, 24)
        Me.cmbCourse.TabIndex = 32
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(375, 178)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(140, 31)
        Me.btnEdit.TabIndex = 33
        Me.btnEdit.Text = "UPDATE"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'FormSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 247)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnAddSection)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormSection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents btnAddSection As Button
    Friend WithEvents txtSection As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents btnEdit As Button
End Class
