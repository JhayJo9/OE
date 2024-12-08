Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormQuestion

    Public Sub fetchAssessmentType()
        Try
            If OPENDB() Then
                Dim Astype As String = "SELECT AssessmentType from tb_questionanswer"
                Using cmd As New MySqlCommand(Astype, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader
                        While dtreader.Read
                            Dim assessmentType As String = dtreader.GetString("AssessmentType")
                            cmbAssessmentType.Items.Add(assessmentType)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fetchCourse()
        Try
            If OPENDB() Then
                Dim fetch As String = "SELECT * FROM tb_course"
                Using cmd As New MySqlCommand(fetch, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read
                            Dim courseID As Integer = dtreader.GetInt32("courseID")
                            Dim courseTitle As String = dtreader.GetString("courseTitle")
                            Dim courseCode As String = dtreader.GetString("courseCode")


                            cmbCourse.Items.Add(courseTitle)
                            lblcoursecode.Text = courseCode
                        End While

                        'MsgBox("Course Fetched Successfully", MsgBoxStyle.Information, "Success")
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT COURSE: " & ex.Message)
        End Try
    End Sub

    Public Sub insertQuestions()
        Try

            If OPENDB() Then
                Dim qu As String = "INSERT INTO tb_questionanswer VALUES (null, @courseID, @question, @optionA, @optionB, @optionC, @optionD, @correctAnswer,@assessmentType)"
                Using cmd As New MySqlCommand(qu, conn)
                    cmd.Parameters.AddWithValue("@courseID", 1)
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text)
                    cmd.Parameters.AddWithValue("@optionA", txtA.Text)
                    cmd.Parameters.AddWithValue("@optionB", txtB.Text)
                    cmd.Parameters.AddWithValue("@optionC", txtC.Text)
                    cmd.Parameters.AddWithValue("@optionD", txtD.Text)
                    cmd.Parameters.AddWithValue("@correctAnswer", cmbCorrectAnswer.Text)
                    cmd.Parameters.AddWithValue("@assessmentType", cmbAssessmentType.Text)
                    cmd.ExecuteNonQuery()
                    MsgBox("Question Added Successfully", MsgBoxStyle.Information, "Success")
                    txtQuestion.Clear()
                    txtA.Clear()
                    txtB.Clear()
                    txtC.Clear()
                    txtD.Clear()

                End Using
            End If
        Catch ex As Exception
            MsgBox("INSERTING QUESTION: " & ex.Message)
        End Try
    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub FormQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourse()
        'fetchAssessmentType()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure you want to add this question?", MsgBoxStyle.YesNo, "Add Question") = MsgBoxResult.Yes Then
            insertQuestions()
            With FormQuestionList
                .fetchQuestion()
            End With
        End If
    End Sub
End Class