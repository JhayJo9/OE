<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExamSession
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtQuestions = New System.Windows.Forms.TextBox()
        Me.rbA = New System.Windows.Forms.RadioButton()
        Me.rbB = New System.Windows.Forms.RadioButton()
        Me.rbC = New System.Windows.Forms.RadioButton()
        Me.rbD = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(319, 58)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EXAM SESSION"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Question"
        '
        'txtQuestions
        '
        Me.txtQuestions.Enabled = False
        Me.txtQuestions.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuestions.Location = New System.Drawing.Point(40, 205)
        Me.txtQuestions.Multiline = True
        Me.txtQuestions.Name = "txtQuestions"
        Me.txtQuestions.ReadOnly = True
        Me.txtQuestions.Size = New System.Drawing.Size(975, 125)
        Me.txtQuestions.TabIndex = 3
        '
        'rbA
        '
        Me.rbA.AutoSize = True
        Me.rbA.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbA.Location = New System.Drawing.Point(19, 27)
        Me.rbA.Name = "rbA"
        Me.rbA.Size = New System.Drawing.Size(131, 26)
        Me.rbA.TabIndex = 4
        Me.rbA.TabStop = True
        Me.rbA.Text = "RadioButton1"
        Me.rbA.UseVisualStyleBackColor = True
        '
        'rbB
        '
        Me.rbB.AutoSize = True
        Me.rbB.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbB.Location = New System.Drawing.Point(19, 54)
        Me.rbB.Name = "rbB"
        Me.rbB.Size = New System.Drawing.Size(131, 26)
        Me.rbB.TabIndex = 5
        Me.rbB.TabStop = True
        Me.rbB.Text = "RadioButton2"
        Me.rbB.UseVisualStyleBackColor = True
        '
        'rbC
        '
        Me.rbC.AutoSize = True
        Me.rbC.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbC.Location = New System.Drawing.Point(19, 82)
        Me.rbC.Name = "rbC"
        Me.rbC.Size = New System.Drawing.Size(131, 26)
        Me.rbC.TabIndex = 6
        Me.rbC.TabStop = True
        Me.rbC.Text = "RadioButton3"
        Me.rbC.UseVisualStyleBackColor = True
        '
        'rbD
        '
        Me.rbD.AutoSize = True
        Me.rbD.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbD.Location = New System.Drawing.Point(19, 109)
        Me.rbD.Name = "rbD"
        Me.rbD.Size = New System.Drawing.Size(131, 26)
        Me.rbD.TabIndex = 7
        Me.rbD.TabStop = True
        Me.rbD.Text = "RadioButton4"
        Me.rbD.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbB)
        Me.GroupBox1.Controls.Add(Me.rbD)
        Me.GroupBox1.Controls.Add(Me.rbA)
        Me.GroupBox1.Controls.Add(Me.rbC)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(40, 346)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(975, 159)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnPrev
        '
        Me.btnPrev.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(43, 512)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(125, 36)
        Me.btnPrev.TabIndex = 9
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(174, 512)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(125, 36)
        Me.btnNext.TabIndex = 10
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'FormExamSession
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1059, 578)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtQuestions)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormExamSession"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtQuestions As TextBox
    Friend WithEvents rbA As RadioButton
    Friend WithEvents rbB As RadioButton
    Friend WithEvents rbC As RadioButton
    Friend WithEvents rbD As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnNext As Button
End Class
