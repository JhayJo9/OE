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


                            cmbCourse.Items.Add(courseCode)
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
                ' Insert into tb_questionanswer
                Dim qu As String = "
                INSERT INTO tb_questionanswer 
                VALUES (null, @question, @optionA, @optionB, @optionC, @optionD, @correctAnswer, @assessmentType)"
                Using cmd As New MySqlCommand(qu, conn)
                    ' Add parameters for the question
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text)
                    cmd.Parameters.AddWithValue("@optionA", txtA.Text)
                    cmd.Parameters.AddWithValue("@optionB", txtB.Text)
                    cmd.Parameters.AddWithValue("@optionC", txtC.Text)
                    cmd.Parameters.AddWithValue("@optionD", txtD.Text)
                    cmd.Parameters.AddWithValue("@correctAnswer", cmbCorrectAnswer.Text)
                    cmd.Parameters.AddWithValue("@assessmentType", cmbAssessmentType.Text)

                    ' Execute the insert
                    cmd.ExecuteNonQuery()
                End Using

                ' Insert into tb_coursequestion using LAST_INSERT_ID()
                Dim qu2 As String = "
                INSERT INTO tb_coursequestion (courseID, questionID)
                VALUES (@courseID, LAST_INSERT_ID())"
                Using cmd2 As New MySqlCommand(qu2, conn)
                    ' Add parameter for courseID
                    cmd2.Parameters.AddWithValue("@courseID", cmbCourse.SelectedIndex + 1) ' Replace 1 with the actual course ID
                    ' Execute the insert
                    cmd2.ExecuteNonQuery()
                End Using

                ' Optional success message or clearing input fields
                MsgBox("Question added successfully!", MsgBoxStyle.Information, "Success")
                txtQuestion.Clear()
                txtA.Clear()
                txtB.Clear()
                txtC.Clear()
                txtD.Clear()
            End If
        Catch ex As Exception
            MsgBox("INSERTING QUESTION: " & ex.Message)
        End Try
    End Sub


    Public Sub updateQuestion()
        Try
            If OPENDB() Then
                ' Update the question in tb_questionanswer
                Dim upQues As String = "
                UPDATE tb_questionanswer 
                SET 
                    Question = @question, 
                    OptionA = @OptionA, 
                    OptionB = @OptionB, 
                    OptionC = @OptionC, 
                    OptionD = @OptionD, 
                    CorrectAnswer = @CorrectAnswer, 
                    AssessmentType = @AssessmentType 
                WHERE questionID = @questionID"
                Using cmd As New MySqlCommand(upQues, conn)
                    ' Fetch questionID from the DataGridView
                    Dim questionID As Integer = Convert.ToInt32(FormQuestionList.DataGridView1.CurrentRow.Cells(0).Value)

                    cmd.Parameters.AddWithValue("@questionID", questionID)
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text)
                    cmd.Parameters.AddWithValue("@OptionA", txtA.Text)
                    cmd.Parameters.AddWithValue("@OptionB", txtB.Text)
                    cmd.Parameters.AddWithValue("@OptionC", txtC.Text)
                    cmd.Parameters.AddWithValue("@OptionD", txtD.Text)
                    cmd.Parameters.AddWithValue("@CorrectAnswer", cmbCorrectAnswer.Text)
                    cmd.Parameters.AddWithValue("@AssessmentType", cmbAssessmentType.Text)

                    ' Execute the update query
                    cmd.ExecuteNonQuery()
                End Using

                ' Update the courseID only if it's necessary
                If cmbCourse.SelectedIndex <> -1 Then
                    Dim upCourseQues As String = "
                    UPDATE tb_coursequestion 
                    SET courseID = @courseID 
                    WHERE questionID = @questionID"
                    Using cmd As New MySqlCommand(upCourseQues, conn)
                        ' Fetch courseID from the combo box
                        Dim courseID As Integer = Convert.ToInt32(cmbCourse.SelectedValue)

                        cmd.Parameters.AddWithValue("@courseID", courseID)
                        cmd.Parameters.AddWithValue("@questionID", FormQuestionList.DataGridView1.CurrentRow.Cells(0).Value.ToString())

                        ' Execute the update query
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                ' Success message
                MsgBox("Question Updated Successfully", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox("Update Question Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub FormQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourse()
        'fetchAssessmentType()
        'Dim tm As String = timer.Text
        'MsgBox(tm)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If MsgBox("Are you sure you want to add this question?", MsgBoxStyle.YesNo, "Add Question") = MsgBoxResult.Yes Then
                insertQuestions()
                With FormQuestionList
                    .fetchQuestion()
                End With
            End If
        ElseIf btnSave.Text = "Update" Then
            If MsgBox("Are you sure you want to update this question?", MsgBoxStyle.YesNo, "Update Question") = MsgBoxResult.Yes Then
                updateQuestion()
                With FormQuestionList
                    .fetchQuestion()
                End With
            End If

        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

    End Sub
End Class