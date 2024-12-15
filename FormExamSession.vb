Imports MySql.Data.MySqlClient

Public Class FormExamSession
    Private currentQuestionIndex As Integer = 0
    Private studentAnswers As New Dictionary(Of Integer, String)
    Private questionIDs As New List(Of Integer)
    Private questionTexts As New List(Of String)
    Private optionsA As New List(Of String)
    Private optionsB As New List(Of String)
    Private optionsC As New List(Of String)
    Private optionsD As New List(Of String)

    Public Property StudentID As Integer
    Public Property CourseID As Integer
    Public Property AssessTypeID As Integer
    Public Property AssesID As Integer

    Private Sub ClearRadioButtons()
        rbA.Checked = False
        rbB.Checked = False
        rbC.Checked = False
        rbD.Checked = False
    End Sub

    Private Sub EnableRadioButtons()
        rbA.Enabled = True
        rbB.Enabled = True
        rbC.Enabled = True
        rbD.Enabled = True
    End Sub

    Private Sub DisableRadioButtons()
        rbA.Enabled = False
        rbB.Enabled = False
        rbC.Enabled = False
        rbD.Enabled = False
    End Sub

    Public Sub Fetch_Data()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            ' Clear existing data first
            questionIDs.Clear()
            questionTexts.Clear()
            optionsA.Clear()
            optionsB.Clear()
            optionsC.Clear()
            optionsD.Clear()

            Dim q As String = "SELECT 
                                q.questionID, 
                                q.Question, 
                                q.OptionA, 
                                q.OptionB, 
                                q.OptionC, 
                                q.OptionD
                             FROM tb_question_assignment qa
                             INNER JOIN tb_questionanswer q ON q.questionID = qa.questionID
                             WHERE qa.assignedID = @assesID"

            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@assesID", AssesID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        questionIDs.Add(reader.GetInt32("questionID"))
                        questionTexts.Add(reader.GetString("Question"))
                        optionsA.Add(reader.GetString("OptionA"))
                        optionsB.Add(reader.GetString("OptionB"))
                        optionsC.Add(reader.GetString("OptionC"))
                        optionsD.Add(reader.GetString("OptionD"))
                    End While
                End Using
            End Using

            If questionIDs.Count > 0 Then
                DisplayQuestion(0)
            Else
                MsgBox("No questions found for this exam!")
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("FETCHING DATA: " & ex.Message)
            Me.Close()
        End Try
    End Sub
    Private Sub ShowPreviousAnswer(index As Integer)
        If studentAnswers.ContainsKey(questionIDs(index)) Then
            Select Case studentAnswers(questionIDs(index))
                Case "A"
                    rbA.Checked = True
                Case "B"
                    rbB.Checked = True
                Case "C"
                    rbC.Checked = True
                Case "D"
                    rbD.Checked = True
            End Select
        End If
    End Sub

    Private Sub SetupForm()
        ' Setup labels
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        lblUser.Text = "Current User's Login: " & StudentID.ToString()

        ' Setup navigation buttons
        btnPrev.Enabled = False
        btnNext.Enabled = True
        btnSubmit.Visible = False ' Will show on last question

        ' Initialize timer for datetime update
        InitializeTimer()
    End Sub

    ' Timer for updating datetime
    Private WithEvents Timer1 As New Timer()
    Private Sub InitializeTimer()
        Timer1.Interval = 1000 ' Update every second
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    ' Radio button event handler
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _
            rbA.CheckedChanged, rbB.CheckedChanged, rbC.CheckedChanged, rbD.CheckedChanged

        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        If rb.Checked Then
            ' Store the answer
            Dim answer As String = ""
            Select Case rb.Name
                Case "rbA"
                    answer = "A"
                Case "rbB"
                    answer = "B"
                Case "rbC"
                    answer = "C"
                Case "rbD"
                    answer = "D"
            End Select

            If Not String.IsNullOrEmpty(answer) Then
                studentAnswers(questionIDs(currentQuestionIndex)) = answer
                'DisableRadioButtons()
            End If
        End If
    End Sub

    ' Navigation buttons
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentQuestionIndex < questionIDs.Count - 1 Then
            DisplayQuestion(currentQuestionIndex + 1)
            ' Show submit button on last question
            btnSubmit.Visible = (currentQuestionIndex = questionIDs.Count - 1)
        End If
    End Sub
    Private Sub DisplayQuestion(index As Integer)
        If index >= 0 And index < questionIDs.Count Then
            ' Display question number and total questions
            lblQuestionNumber.Text = $"Question {index + 1} of {questionIDs.Count}"

            ' Display the question and options
            txtQuestions.Text = questionTexts(index)
            rbA.Text = optionsA(index)
            rbB.Text = optionsB(index)
            rbC.Text = optionsC(index)
            rbD.Text = optionsD(index)

            ' Clear radio buttons
            ClearRadioButtons()

            ' If question was previously answered, show the answer
            If studentAnswers.ContainsKey(questionIDs(index)) Then
                ShowPreviousAnswer(index)
                'DisableRadioButtons()
            Else
                EnableRadioButtons()
            End If

            ' Update navigation buttons
            btnPrev.Enabled = (index > 0)
            btnNext.Enabled = (index < questionIDs.Count - 1)

            ' Show submit button only on last question
            btnSubmit.Visible = (index = questionIDs.Count - 1)

            ' Update current question index
            currentQuestionIndex = index
        End If
    End Sub
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If currentQuestionIndex > 0 Then
            DisplayQuestion(currentQuestionIndex - 1)
            btnSubmit.Visible = False
        End If
    End Sub

    ' Submit button
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim unansweredCount = questionIDs.Count - studentAnswers.Count
        If unansweredCount > 0 Then
            If MessageBox.Show($"You have {unansweredCount} unanswered questions. Do you want to submit anyway?",
                             "Confirm Submit", MessageBoxButtons.YesNo) = DialogResult.No Then
                Return
            End If
        End If

        SaveAnswers()
    End Sub

    Private Sub SaveAnswers()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Debug.WriteLine($"Saving answers for studentID: {UserSession.StudentId}, courseID: {CourseID}, assessTypeID: {AssessTypeID}, _STUDENTID: {UserSession.StudentId}")

            ' Check if studentID exists in tb_student table
            Dim checkStudentSql As String = "SELECT COUNT(1) FROM tb_student WHERE studentID = @studentID"
            Using checkCmd As New MySqlCommand(checkStudentSql, conn)
                checkCmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                Dim studentExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If studentExists = 0 Then
                    MsgBox("Error: studentID does not exist in tb_student table.")
                    Return
                End If
            End Using

            For Each answer In studentAnswers
                Dim sql As String = "INSERT INTO tb_student_answers 
                               (studentID, courseID, assessTypeID, questionID, 
                                selectedAnswer, submissionDateTime) 
                               VALUES 
                               (@studentID, @courseID, @assessTypeID, @questionID, 
                                @answer, @submitTime)"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                    cmd.Parameters.AddWithValue("@courseID", CourseID)
                    cmd.Parameters.AddWithValue("@assessTypeID", AssessTypeID)
                    cmd.Parameters.AddWithValue("@questionID", answer.Key)
                    cmd.Parameters.AddWithValue("@answer", answer.Value)
                    cmd.Parameters.AddWithValue("@submitTime", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            Next
            MsgBox("Exam submitted successfully!")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error saving answers: " & ex.Message)
        End Try
    End Sub

    Private Sub FormExamSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        Fetch_Data()

        ' Disable radio buttons until data is loaded
        'DisableRadioButtons()
    End Sub

    Private Sub LogDebugInfo(message As String)
        Try
            Debug.WriteLine($"Debug: {message}")
            ' You can also write to a file if needed
        Catch ex As Exception
            ' Ignore logging errors
        End Try
    End Sub
End Class