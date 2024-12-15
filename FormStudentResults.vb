Imports MySql.Data.MySqlClient

Public Class FormStudentResults
    Private Sub FormStudentResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        LoadCourseAndAssessmentTypes()
    End Sub

    Private Sub SetupForm()
        ' Setup labels
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        lblUser.Text = "Current User's Login: " & _STUDENTD.ToString()

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
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)

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
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)
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
                (SUM(CASE WHEN sa.selectedAnswer = q.CorrectAnswer THEN 1 ELSE 0 END) * 100.0 / COUNT(DISTINCT sa.questionID)) as ScorePercentage,
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
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)
                cmd.Parameters.AddWithValue("@courseID", courseID)
                cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Display results
                        lblScore.Text = reader.GetInt32("ScorePercentage").ToString("N2") & "%"
                        lblExamDate.Text = CDate(reader("ExamDate")).ToString("yyyy-MM-dd HH:mm:ss")

                        ' Color code score
                        Dim score As Decimal = CDec(reader("ScorePercentage"))
                        If score >= 75 Then
                            lblScore.ForeColor = Color.Green
                        ElseIf score >= 50 Then
                            lblScore.ForeColor = Color.Orange
                        Else
                            lblScore.ForeColor = Color.Red
                        End If

                        pnlResults.Visible = True
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading results: " & ex.Message)
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