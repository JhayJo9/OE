Imports MySql.Data.MySqlClient

Public Class FormExamListForStudent
    Private Sub FormExamListForStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure your DataGridView (g) has these columns defined in the designer
        If g.Columns.Count = 0 Then
            g.Columns.Add("CourseCode", "Course Code")
            g.Columns.Add("AssessmentType", "Assessment Type")
            g.Columns.Add("QuestionCount", "Questions")
            g.Columns.Add("ScheduleDate", "Date")
            g.Columns.Add("ScheduleTime", "Time")
            g.Columns.Add("Location", "Location")
            g.Columns.Add("ExamStatus", "Status")
        End If
        Fetch_Data()
    End Sub

    Public Sub Fetch_Data()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            g.Rows.Clear()

            Dim query As String = "
                SELECT
                    c.courseCode,
                    assess.AssessmentType,
                    COUNT(DISTINCT q.questionID) AS QuestionCount,
                    sch.scheduleDate,
                    sch.scheduleTime,
                    sch.location,
                    CASE 
                        WHEN EXISTS (
                            SELECT 1 
                            FROM tb_student_answers sa 
                            WHERE sa.studentID = s.studentID 
                            AND sa.courseID = c.courseID 
                            AND sa.assessTypeID = assess.assessTypeID
                        ) THEN 'Completed'
                        ELSE 'Take Exam'
                    END AS ExamStatus,
                    c.courseID,
                    assess.assessTypeID,
                    assi.assesID
                FROM tb_student s
                INNER JOIN tb_assignedstudents assi ON s.studentID = assi.studentID
                INNER JOIN tb_course c ON c.courseID = assi.courseID
                INNER JOIN tb_assessmenttype assess ON assess.assessTypeID = assi.assessTypeID
                INNER JOIN tb_section sec ON sec.sectionID = assi.sectionID
                LEFT JOIN tb_course_assessment_section_question cq ON cq.courseID = c.courseID
                LEFT JOIN tb_questionanswer q ON q.assessmentTypeID = assess.assessTypeID AND q.questionID = cq.questionID
                LEFT JOIN tb_schedule sch ON sch.courseCode = c.courseCode AND sch.section = sec.section AND sch.assessTypeID = assess.assessTypeID
                WHERE s.studentID = @studentID
                GROUP BY c.courseID, c.courseCode, assess.assessTypeID, assess.AssessmentType, assi.assesID, sch.scheduleDate, sch.scheduleTime, sch.location"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Create a dictionary to store the row data
                        Dim rowData As New Dictionary(Of String, Object)
                        rowData.Add("courseID", reader("courseID"))
                        rowData.Add("assessTypeID", reader("assessTypeID"))
                        rowData.Add("assesID", reader("assesID"))
                        rowData.Add("questionCount", reader("QuestionCount"))
                        'MsgBox()
                        ' Add the row to the grid
                        Dim row As Integer = g.Rows.Add(
                            If(reader.IsDBNull(reader.GetOrdinal("courseCode")), "", reader("courseCode")),
                            If(reader.IsDBNull(reader.GetOrdinal("AssessmentType")), "", reader("AssessmentType")),
                            If(reader.IsDBNull(reader.GetOrdinal("QuestionCount")), 0, reader("QuestionCount")),
                            If(reader.IsDBNull(reader.GetOrdinal("scheduleDate")), DateTime.MinValue, reader("scheduleDate")),
                            If(reader.IsDBNull(reader.GetOrdinal("scheduleTime")), "", reader("scheduleTime")),
                            If(reader.IsDBNull(reader.GetOrdinal("location")), "", reader("location")),
                            reader("ExamStatus")
                        )

                        ' Store the dictionary in the row's Tag property
                        g.Rows(row).Tag = rowData

                        ' Color completed exams
                        If reader("ExamStatus").ToString() = "Completed" Then
                            g.Rows(row).DefaultCellStyle.BackColor = Color.LightGray
                        End If
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error fetching data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub g_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                Dim rowData As Dictionary(Of String, Object) = DirectCast(g.Rows(e.RowIndex).Tag, Dictionary(Of String, Object))
                Dim status As String = g.Rows(e.RowIndex).Cells("ExamStatus").Value.ToString()

                ' First diagnose the exam setup
                DiagnoseExamSetup(CInt(rowData("assesID")))

                If status = "Completed" Then
                    MsgBox("You have already taken this exam.", MsgBoxStyle.Information)
                    Return
                End If

                If CInt(rowData("questionCount")) = 0 Then
                    MsgBox("No questions available for this exam.")
                    Return
                End If

                ' Only create and show exam form if we have questions
                Dim examForm As New FormExamSession With {
                    .StudentID = UserSession.StudentId,
                    .CourseID = CInt(rowData("courseID")),
                    .AssessTypeID = CInt(rowData("assessTypeID")),
                    .AssesID = CInt(rowData("assesID"))
                }
                examForm.ShowDialog()

                ' Refresh the list after exam completion
                Fetch_Data()

            Catch ex As Exception
                MsgBox("Error starting exam: " & ex.Message)
            End Try
        End If
    End Sub
    Public Sub DiagnoseExamSetup(assesID As Integer)
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            ' 1. First check the assigned students table
            Dim queryAssigned As String = "
                SELECT 
                    a.assesID,
                    a.studentID,
                    a.courseID,
                    a.assessTypeID,
                    c.courseCode,
                    ast.AssessmentType
                FROM tb_assignedstudents a
                LEFT JOIN tb_course c ON c.courseID = a.courseID
                LEFT JOIN tb_assessmenttype ast ON ast.assessTypeID = a.assessTypeID
                WHERE a.assesID = @assesID"

            Using cmdAssigned As New MySqlCommand(queryAssigned, conn)
                cmdAssigned.Parameters.AddWithValue("@assesID", assesID)
                Using reader As MySqlDataReader = cmdAssigned.ExecuteReader()
                    If reader.Read() Then
                        MsgBox($"Exam Assignment Details:" & vbCrLf &
                              $"AssesID: {reader("assesID")}" & vbCrLf &
                              $"Student ID: {reader("studentID")}" & vbCrLf &
                              $"Course: {reader("courseCode")}" & vbCrLf &
                              $"Assessment Type: {reader("AssessmentType")}")
                    Else
                        MsgBox("No exam assignment found!")
                    End If
                End Using
            End Using

            ' 2. Check available questions in questionanswer table
            Dim queryQuestions As String = "
                SELECT COUNT(*) as TotalQuestions 
                FROM tb_questionanswer q
                WHERE q.assessmentTypeID = (
                    SELECT assessTypeID 
                    FROM tb_assignedstudents 
                    WHERE assesID = @assesID
                )"

            Using cmdQuestions As New MySqlCommand(queryQuestions, conn)
                cmdQuestions.Parameters.AddWithValue("@assesID", assesID)
                Dim totalQuestions As Integer = Convert.ToInt32(cmdQuestions.ExecuteScalar())
                MsgBox($"Total available questions for this assessment type: {totalQuestions}")
            End Using

            ' 3. Check question assignments
            Dim queryAssignments As String = "
                SELECT COUNT(*) as AssignedQuestions 
                FROM tb_question_assignment 
                WHERE assignedID = @assesID"

            Using cmdAssignments As New MySqlCommand(queryAssignments, conn)
                cmdAssignments.Parameters.AddWithValue("@assesID", assesID)
                Dim assignedQuestions As Integer = Convert.ToInt32(cmdAssignments.ExecuteScalar())
                MsgBox($"Questions assigned to this exam: {assignedQuestions}")
            End Using

        Catch ex As Exception
            MsgBox($"Error in diagnosis: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub VerifyExamSetup(assesID As Integer)
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            ' 1. Check questions in tb_question_assignment
            Dim queryAssigned As String = "
            SELECT COUNT(*) as AssignedCount 
            FROM tb_question_assignment 
            WHERE assignedID = @assesID"

            Using cmdAssigned As New MySqlCommand(queryAssigned, conn)
                cmdAssigned.Parameters.AddWithValue("@assesID", assesID)
                Dim assignedCount As Integer = Convert.ToInt32(cmdAssigned.ExecuteScalar())
                MsgBox($"Number of questions assigned to this exam: {assignedCount}")
            End Using

            ' 2. Check if assesID exists and get its details
            Dim queryAssesDetails As String = "
            SELECT 
                a.assesID,
                c.courseCode,
                at.AssessmentType
            FROM tb_assignedstudents a
            INNER JOIN tb_course c ON c.courseID = a.courseID
            INNER JOIN tb_assessmenttype at ON at.assessTypeID = a.assessTypeID
            WHERE a.assesID = @assesID"

            Using cmdAssesDetails As New MySqlCommand(queryAssesDetails, conn)
                cmdAssesDetails.Parameters.AddWithValue("@assesID", assesID)
                Using reader As MySqlDataReader = cmdAssesDetails.ExecuteReader()
                    If reader.Read() Then
                        MsgBox($"AssesID {assesID} exists for:" & vbCrLf &
                              $"Course: {reader("courseCode")}" & vbCrLf &
                              $"Assessment Type: {reader("AssessmentType")}")
                    Else
                        MsgBox($"AssesID {assesID} not found in tb_assignedstudents!")
                    End If
                End Using
            End Using

            ' 3. Check if questions exist in tb_questionanswer
            Dim queryQuestions As String = "
            SELECT 
                COUNT(*) as TotalQuestions,
                COUNT(DISTINCT qa.questionID) as AssignedQuestions
            FROM tb_question_assignment qa
            LEFT JOIN tb_questionanswer q ON q.questionID = qa.questionID
            WHERE qa.assignedID = @assesID"

            Using cmdQuestions As New MySqlCommand(queryQuestions, conn)
                cmdQuestions.Parameters.AddWithValue("@assesID", assesID)
                Using reader As MySqlDataReader = cmdQuestions.ExecuteReader()
                    If reader.Read() Then
                        MsgBox($"Questions found in tb_questionanswer: {reader("TotalQuestions")}" & vbCrLf &
                              $"Questions properly linked: {reader("AssignedQuestions")}")
                    End If
                End Using
            End Using

            ' 4. Check relationships (detailed check)
            Dim queryRelationships As String = "
            SELECT 
                qa.questionID,
                CASE WHEN q.questionID IS NULL THEN 'Missing in tb_questionanswer'
                     ELSE 'Present' END as QuestionStatus,
                q.Question as QuestionText
            FROM tb_question_assignment qa
            LEFT JOIN tb_questionanswer q ON q.questionID = qa.questionID
            WHERE qa.assignedID = @assesID"

            Using cmdRelationships As New MySqlCommand(queryRelationships, conn)
                cmdRelationships.Parameters.AddWithValue("@assesID", assesID)
                Using reader As MySqlDataReader = cmdRelationships.ExecuteReader()
                    Dim message As String = "Question Relationship Status:" & vbCrLf
                    While reader.Read()
                        message &= $"Question ID {reader("questionID")}: {reader("QuestionStatus")}" & vbCrLf
                        If reader("QuestionStatus").ToString() = "Present" Then
                            message &= $"Text: {reader("QuestionText")}" & vbCrLf
                        End If
                        message &= "-------------------" & vbCrLf
                    End While
                    MsgBox(message)
                End Using
            End Using

        Catch ex As Exception
            MsgBox($"Error verifying exam setup: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub
End Class