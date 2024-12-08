Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormQuestionList

    Public Sub fetchQuestion()
        Try
            If OPENDB() Then
                Dim qu As String = "SELECT * FROM tb_questionanswer"
                Using cmd As New MySqlCommand(qu, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read

                            Dim questionID As Integer = dtreader.GetInt32("questionID")
                            Dim courseID As Integer = dtreader.GetInt32("courseID")
                            Dim question As String = dtreader.GetString("Question")
                            Dim optionA As String = dtreader.GetString("OptionA")
                            Dim optionB As String = dtreader.GetString("OptionB")
                            Dim optionC As String = dtreader.GetString("OptionC")
                            Dim optionD As String = dtreader.GetString("OptionD")
                            Dim correctAnswer As String = dtreader.GetString("CorrectAnswer")
                            'Dim dateCreated As Date = dtreader.GetDateTime("dateEdited")
                            Dim assessmentType As String = dtreader.GetString("AssessmentType")

                            DataGridView1.Rows.Add(questionID, courseID, question, optionA, optionB, optionC, optionD, correctAnswer, "wala", assessmentType)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT QUESTION: " & ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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