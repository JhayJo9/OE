Imports MySql.Data.MySqlClient

Public Class FormStudentResults
    Private Sub FormStudentResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        LoadCourseAndAssessmentTypes()
    End Sub

    Private Sub SetupForm()
        ' Setup labels
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        lblUser.Text = "Current User's Login: " & UserSession.StudentId.ToString()

        ' Setup ComboBoxes
        With cmbCourse
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.None
        End With

        With cmbAssessType
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.None
            .Enabled = False ' Enable only after course selection
        End With

        ' Setup Results Panel (initially hidden)
        pnlResults.Visible = False
    End Sub

    Private Sub LoadCourseAndAssessmentTypes()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim courseQuery As String = "
                SELECT DISTINCT 
                    c.courseID,
                    c.courseCode
                FROM 
                    tb_student_answers sa
                INNER JOIN 
                    tb_course c ON c.courseID = sa.courseID
                WHERE 
                    sa.studentID = @studentID
                ORDER BY 
                    c.courseCode"

            Using cmd As New MySqlCommand(courseQuery, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)

                cmbCourse.Items.Clear()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim item As New ComboBoxItem With {
                            .Value = reader("courseID"),
                            .Text = reader("courseCode")
                        }
                        cmbCourse.Items.Add(item)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading courses: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAssessmentTypes(courseID As Integer)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String = "
                SELECT DISTINCT 
                    at.assessTypeID,
                    at.AssessmentType
                FROM 
                    tb_student_answers sa
                INNER JOIN 
                    tb_assessmenttype at ON at.assessTypeID = sa.assessTypeID
                WHERE 
                    sa.studentID = @studentID
                    AND sa.courseID = @courseID
                ORDER BY 
                    at.AssessmentType"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                cmd.Parameters.AddWithValue("@courseID", courseID)

                cmbAssessType.Items.Clear()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim item As New ComboBoxItem With {
                            .Value = reader("assessTypeID"),
                            .Text = reader("AssessmentType")
                        }
                        cmbAssessType.Items.Add(item)
                    End While
                End Using
            End Using

            cmbAssessType.Enabled = True

        Catch ex As Exception
            MsgBox("Error loading assessment types: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadExamResults(courseID As Integer, assessTypeID As Integer)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String = "
        SELECT 
            SUM(CASE WHEN sa.selectedAnswer = q.CorrectAnswer THEN 1 ELSE 0 END) as CorrectAnswers,
            COUNT(DISTINCT sa.questionID) as TotalQuestions,
            MAX(sa.submissionDateTime) as ExamDate
        FROM 
            tb_student_answers sa
        INNER JOIN 
            tb_questionanswer q ON q.questionID = sa.questionID
        WHERE 
            sa.studentID = @studentID
            AND sa.courseID = @courseID
            AND sa.assessTypeID = @assessTypeID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                cmd.Parameters.AddWithValue("@courseID", courseID)
                cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Get the raw scores
                        Dim correctAnswers As Integer = reader.GetInt32("CorrectAnswers")
                        Dim totalQuestions As Integer = reader.GetInt32("TotalQuestions")

                        ' Calculate percentage
                        Dim percentageScore As Decimal = (correctAnswers * 100.0) / totalQuestions

                        ' Display score as fraction and percentage
                        lblScore.Text = $"{correctAnswers}/{totalQuestions} ({percentageScore:N2}%)"
                        lblExamDate.Text = CDate(reader("ExamDate")).ToString("yyyy-MM-dd HH:mm:ss")

                        ' Color code score based on 75% passing grade
                        If percentageScore >= 75 Then
                            lblScore.ForeColor = Color.Green
                            MessageBox.Show($"Score: {correctAnswers}/{totalQuestions}" & vbCrLf &
                                     $"Percentage: {percentageScore:N2}%" & vbCrLf &
                                     "Status: PASSED",
                                     "Exam Result",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information)
                        Else
                            lblScore.ForeColor = Color.Red
                            MessageBox.Show($"Score: {correctAnswers}/{totalQuestions}" & vbCrLf &
                                     $"Percentage: {percentageScore:N2}%" & vbCrLf &
                                     "Status: FAILED" & vbCrLf &
                                     "Required to Pass: 75%",
                                     "Exam Result",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning)
                        End If

                        pnlResults.Visible = True
                    Else
                        MessageBox.Show("No exam results found.",
                                  "Information",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading results: " & ex.Message,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error)
        End Try
    End Sub

    ' ComboBox Item class
    Private Class ComboBoxItem
        Public Property Value As Integer
        Public Property Text As String

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    ' Event Handlers
    Private Sub cmbCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourse.SelectedIndexChanged
        If cmbCourse.SelectedItem IsNot Nothing Then
            Dim selectedCourse As ComboBoxItem = DirectCast(cmbCourse.SelectedItem, ComboBoxItem)
            LoadAssessmentTypes(selectedCourse.Value)
            pnlResults.Visible = False
        End If
    End Sub

    Private Sub cmbAssessType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssessType.SelectedIndexChanged
        If cmbCourse.SelectedItem IsNot Nothing AndAlso cmbAssessType.SelectedItem IsNot Nothing Then
            Dim selectedCourse As ComboBoxItem = DirectCast(cmbCourse.SelectedItem, ComboBoxItem)
            Dim selectedAssessType As ComboBoxItem = DirectCast(cmbAssessType.SelectedItem, ComboBoxItem)
            LoadExamResults(selectedCourse.Value, selectedAssessType.Value)
        End If
    End Sub
End Class