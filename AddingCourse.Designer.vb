﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddingCourse
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnAddCourse = New System.Windows.Forms.Button()
        Me.txtAddCourse = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtsddcourseCode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Adding Course"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(33, 153)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 31)
        Me.btnBack.TabIndex = 20
        Me.btnBack.Text = "Close"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnAddCourse
        '
        Me.btnAddCourse.Location = New System.Drawing.Point(128, 153)
        Me.btnAddCourse.Name = "btnAddCourse"
        Me.btnAddCourse.Size = New System.Drawing.Size(140, 31)
        Me.btnAddCourse.TabIndex = 19
        Me.btnAddCourse.Text = "ADD COURSE"
        Me.btnAddCourse.UseVisualStyleBackColor = True
        '
        'txtAddCourse
        '
        Me.txtAddCourse.Location = New System.Drawing.Point(155, 63)
        Me.txtAddCourse.Multiline = True
        Me.txtAddCourse.Name = "txtAddCourse"
        Me.txtAddCourse.Size = New System.Drawing.Size(366, 30)
        Me.txtAddCourse.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Course Code: "
        '
        'txtsddcourseCode
        '
        Me.txtsddcourseCode.Location = New System.Drawing.Point(156, 101)
        Me.txtsddcourseCode.Multiline = True
        Me.txtsddcourseCode.Name = "txtsddcourseCode"
        Me.txtsddcourseCode.Size = New System.Drawing.Size(365, 31)
        Me.txtsddcourseCode.TabIndex = 21
        '
        'AddingCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnAddCourse)
        Me.Controls.Add(Me.txtAddCourse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsddcourseCode)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddingCourse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnAddCourse As Button
    Friend WithEvents txtAddCourse As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtsddcourseCode As TextBox
End Class
