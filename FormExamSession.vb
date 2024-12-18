Imports MySql.Data.MySqlClient

Public Class FormExamSession
    Private currentQuestionIndex As Integer = 0
    Private studentAnswers As New Dictionary(Of Integer, String)
    Private questions As New List(Of Question)
    Public Property StudentID As Integer
    Public Property CourseID As Integer
    Public Property AssessTypeID As Integer
    Public Property AssesID As Integer

    ' Question class to store question data
    Private Class Question
        Public Property QuestionID As Integer
        Public Property QuestionText As String
        Public Property OptionA As String
        Public Property OptionB As String
        Public Property OptionC As String
        Public Property OptionD As String
    End Class

    'Private Sub FormExamSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    SetupForm()
    '    LoadQuestions()
    'End Sub

    Private Sub SetupForm()
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        lblUser.Text = $"Current User's Login: {UserSession.StudentId}"
        btnPrev.Enabled = False
        btnNext.Enabled = True
        btnSubmit.Visible = False
        Timer1.Interval = 1000
        Timer1.Start()
    End Sub

    Private Function LoadQuestions() As Boolean
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            questions.Clear()
            Dim query As String = "
                SELECT 
                    q.questionID, 
                    q.Question, 
                    q.OptionA, 
                    q.OptionB, 
                    q.OptionC, 
                    q.OptionD
                FROM tb_question_assignment qa
                INNER JOIN tb_questionanswer q ON q.questionID = qa.questionID
                WHERE qa.assignedID = @assesID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@assesID", AssesID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        questions.Add(New Question With {
                            .QuestionID = reader.GetInt32("questionID"),
                            .QuestionText = reader.GetString("Question"),
                            .OptionA = reader.GetString("OptionA"),
                            .OptionB = reader.GetString("OptionB"),
                            .OptionC = reader.GetString("OptionC"),
                            .OptionD = reader.GetString("OptionD")
                        })
                    End While
                End Using
            End Using

            Return questions.Count > 0

        Catch ex As Exception
            MessageBox.Show($"Error loading questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Private Sub FormExamSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        If Not LoadQuestions() Then
            MessageBox.Show("No questions available for this exam.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel  ' Set dialog result
            Me.Close()
            Exit Sub  ' Exit the sub to prevent further execution
        End If
        DisplayQuestion(0)  ' Only display if we have questions
    End Sub
    Private Sub DisplayQuestion(index As Integer)
        If index >= 0 AndAlso index < questions.Count Then
            currentQuestionIndex = index
            lblQuestionNumber.Text = $"Question {index + 1} of {questions.Count}"

            Dim currentQuestion = questions(index)
            txtQuestions.Text = currentQuestion.QuestionText
            rbA.Text = currentQuestion.OptionA
            rbB.Text = currentQuestion.OptionB
            rbC.Text = currentQuestion.OptionC
            rbD.Text = currentQuestion.OptionD

            ClearRadioButtons()
            If studentAnswers.ContainsKey(currentQuestion.QuestionID) Then
                ShowPreviousAnswer(currentQuestion.QuestionID)
            End If

            btnPrev.Enabled = (index > 0)
            btnNext.Enabled = (index < questions.Count - 1)
            btnSubmit.Visible = (index = questions.Count - 1)
        End If
    End Sub

    Private Sub ClearRadioButtons()
        rbA.Checked = False
        rbB.Checked = False
        rbC.Checked = False
        rbD.Checked = False
    End Sub

    Private Sub ShowPreviousAnswer(questionId As Integer)
        If studentAnswers.ContainsKey(questionId) Then
            Select Case studentAnswers(questionId)
                Case "A" : rbA.Checked = True
                Case "B" : rbB.Checked = True
                Case "C" : rbC.Checked = True
                Case "D" : rbD.Checked = True
            End Select
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _
            rbA.CheckedChanged, rbB.CheckedChanged, rbC.CheckedChanged, rbD.CheckedChanged

        ' First check if we have any questions
        If questions Is Nothing OrElse questions.Count = 0 Then Exit Sub

        ' Then check if we're within bounds
        If currentQuestionIndex < 0 OrElse currentQuestionIndex >= questions.Count Then Exit Sub

        If TypeOf sender Is RadioButton AndAlso DirectCast(sender, RadioButton).Checked Then
            Try
                Dim rb As RadioButton = DirectCast(sender, RadioButton)
                Dim answer As String = rb.Name.Replace("rb", "")
                studentAnswers(questions(currentQuestionIndex).QuestionID) = answer
            Catch ex As Exception
                Debug.WriteLine($"Error in RadioButton_CheckedChanged: {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentQuestionIndex < questions.Count - 1 Then
            DisplayQuestion(currentQuestionIndex + 1)
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If currentQuestionIndex > 0 Then
            DisplayQuestion(currentQuestionIndex - 1)
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim unansweredCount = questions.Count - studentAnswers.Count
        If unansweredCount > 0 Then
            If MessageBox.Show($"You have {unansweredCount} unanswered questions. Do you want to submit anyway?",
                             "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
        End If

        SaveAnswers()
    End Sub

    Private Sub SaveAnswers()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            Using transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    For Each answer In studentAnswers
                        Dim sql As String = "
                            INSERT INTO tb_student_answers 
                            (studentID, courseID, assessTypeID, questionID, selectedAnswer, submissionDateTime) 
                            VALUES 
                            (@studentID, @courseID, @assessTypeID, @questionID, @answer, @submitTime)"

                        Using cmd As New MySqlCommand(sql, conn, transaction)
                            cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                            cmd.Parameters.AddWithValue("@courseID", CourseID)
                            cmd.Parameters.AddWithValue("@assessTypeID", AssessTypeID)
                            cmd.Parameters.AddWithValue("@questionID", answer.Key)
                            cmd.Parameters.AddWithValue("@answer", answer.Value)
                            cmd.Parameters.AddWithValue("@submitTime", DateTime.Now)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()
                    MessageBox.Show("Exam submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()

                Catch ex As Exception
                    transaction.Rollback()
                    Throw
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error saving answers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub FormExamSession_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If questions Is Nothing OrElse questions.Count = 0 Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub
End Class