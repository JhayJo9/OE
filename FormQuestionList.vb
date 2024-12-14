Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormQuestionList

    Public Sub fetchQuestion()
        Try

            DataGridView1.Rows.Clear()

            If OPENDB() Then
                Dim qu As String = "
                        SELECT 
                            q.QuestionID, 
                            q.Question, 
                            q.OptionA, 
                            q.OptionB, 
                            q.OptionC, 
                            q.OptionD, 
                            q.CorrectAnswer,
                            c.CourseCode 
                        FROM 
                            tb_questionanswer q
                        INNER JOIN 
                            tb_coursequestion cq ON q.QuestionID = cq.QuestionID
                        INNER JOIN 
                            tb_course c ON c.CourseID = cq.CourseID"
                Using cmd As New MySqlCommand(qu, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read

                            Dim questionID As Integer = dtreader.GetInt32("questionID")
                            Dim question As String = dtreader.GetString("Question")
                            Dim optionA As String = dtreader.GetString("OptionA")
                            Dim optionB As String = dtreader.GetString("OptionB")
                            Dim optionC As String = dtreader.GetString("OptionC")
                            Dim optionD As String = dtreader.GetString("OptionD")
                            Dim correctAnswer As String = dtreader.GetString("CorrectAnswer")
                            'Dim dateCreated As Date = dtreader.GetDateTime("dateEdited")
                            'Dim assessmentType As String = dtreader.GetString("AssessmentType")
                            Dim courseCode As String = dtreader.GetString("courseCode")


                            DataGridView1.Rows.Add(questionID, question, optionA, optionB, optionC, optionD, correctAnswer, courseCode)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT QUESTION: " & ex.Message)
        End Try
    End Sub




    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name


        If colName = "colView" Then

            With FormQuestion

                .txtQuestion.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txtA.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txtB.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                .txtC.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .txtD.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
                .cmbCorrectAnswer.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
                .cmbCourse.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
                .cmbAssessmentType.Enabled = False
                .cmbCorrectAnswer.Enabled = False
                .cmbCourse.Enabled = False
                .txtQuestion.Enabled = False
                .txtA.Enabled = False
                .txtB.Enabled = False
                .txtC.Enabled = False
                .txtD.Enabled = False
                .cmbCorrectAnswer.Enabled = False
                .btnSave.Visible = False
                .btnNext.Visible = False
                .ShowDialog()
            End With
        ElseIf colName = "colEdit" Then
            With FormQuestion
                .txtQuestion.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txtA.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txtB.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                .txtC.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .txtD.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
                .cmbCorrectAnswer.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString

                .cmbCourse.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
                .btnSave.Text = "Update"
                .btnNext.Visible = False
                .ShowDialog()
            End With

        End If
    End Sub


    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With FormQuestion
            .ShowDialog()
        End With
    End Sub

    Private Sub FormQuestionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchQuestion()
    End Sub
End Class