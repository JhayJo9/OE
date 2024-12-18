Imports MySql.Data.MySqlClient

Public Class FormExamListForStudent
    Public Sub Fetch_Data()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            ' Modified query to include question count, date, time, and location
            Dim q As String = "
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
                ) THEN 1 
                ELSE 0 
            END AS HasTakenExam
        FROM 
            tb_student s
        INNER JOIN 
            tb_assignedstudents assi ON s.studentID = assi.studentID
        INNER JOIN 
            tb_course c ON c.courseID = assi.courseID
        INNER JOIN 
            tb_assessmenttype assess ON assess.assessTypeID = assi.assessTypeID
        INNER JOIN 
            tb_section sec ON sec.sectionID = assi.sectionID
        LEFT JOIN 
            tb_coursequestion cq ON cq.courseID = c.courseID
        LEFT JOIN 
            tb_questionanswer q ON q.assessmentTypeID = assess.assessTypeID AND q.questionID = cq.questionID
        LEFT JOIN
            tb_schedule sch ON sch.courseCode = c.courseCode AND sch.section = sec.section AND sch.assessTypeID = assess.assessTypeID
        WHERE 
            s.studentID = @studentID
        GROUP BY 
            c.courseID, c.courseCode, assess.assessTypeID, assess.AssessmentType, assi.assesID, sch.scheduleDate, sch.scheduleTime, sch.location;"

            ' Use DataTable for simpler loading
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                Using DataTableReader As MySqlDataReader = cmd.ExecuteReader()

                    While DataTableReader.Read()
                        Dim course As String = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("courseCode")), String.Empty, DataTableReader("courseCode").ToString())
                        Dim assessType As String = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("AssessmentType")), String.Empty, DataTableReader("AssessmentType").ToString())
                        Dim questionCount As Integer = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("QuestionCount")), 0, Convert.ToInt32(DataTableReader("QuestionCount")))
                        Dim scheduleDate As Date = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("scheduleDate")), Date.MinValue, Convert.ToDateTime(DataTableReader("scheduleDate")))
                        Dim scheduleTime As TimeSpan = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("scheduleTime")), TimeSpan.Zero, TimeSpan.Parse(DataTableReader("scheduleTime").ToString()))
                        Dim location As String = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("location")), String.Empty, DataTableReader.GetString("location").ToString())
                        Dim hasTakenExam As Boolean = If(DataTableReader.IsDBNull(DataTableReader.GetOrdinal("HasTakenExam")), False, Convert.ToBoolean(DataTableReader("HasTakenExam")))

                        g.Rows.Add(course, assessType, questionCount, scheduleDate, scheduleTime, location, hasTakenExam)
                    End While
                End Using
            End Using
            'FIX DataGridView
            ' Bind DataTable directly to DataGridView
            ' g.DataSource = dt

            ' Optional: Set column formats or rename headers if needed
            'g.Columns("QuestionCount").HeaderText = "Total Questions"
            'g.Columns("scheduleDate").HeaderText = "Date"
            'g.Columns("scheduleTime").HeaderText = "Time"
            'g.Columns("HasTakenExam").HeaderText = "Exam Status"

            ' You can format specific cells here, like disabling buttons for completed exams
            For Each row As DataGridViewRow In g.Rows
                Dim hasTaken As Boolean = Convert.ToBoolean(row.Cells("HasTakenExam").Value)
                If hasTaken Then
                    row.Cells("HasTakenExam").Value = "Completed"
                    row.DefaultCellStyle.BackColor = Color.LightGray
                Else
                    row.Cells("HasTakenExam").Value = "Take Exam"
                End If
            Next

        Catch ex As Exception
            MsgBox("FETCHING DATA: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub FormExamListForStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView

        ' Load the data
        Fetch_Data()
    End Sub

    Private Sub g_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles g.CellContentClick
        If e.ColumnIndex = g.Columns("colTakeExam").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim rowData As Dictionary(Of String, Object) = DirectCast(g.Rows(e.RowIndex).Tag, Dictionary(Of String, Object))
                ' Check if exam was already taken
                If CBool(rowData("hasTakenExam")) Then
                    MsgBox("You have already taken this exam and cannot retake it.", MsgBoxStyle.Information, "Exam Already Taken")
                    Return
                End If
                ' Check if there are questions
                If CInt(rowData("questionCount")) = 0 Then
                    MsgBox("No questions available for this exam.")
                    Return
                End If
                ' Double-check if exam was taken (in case of concurrent access)
                If HasTakenExam(CInt(rowData("courseID")), CInt(rowData("assessTypeID"))) Then
                    MsgBox("You have already taken this exam and cannot retake it.", MsgBoxStyle.Information, "Exam Already Taken")
                    Fetch_Data() ' Refresh the grid
                    Return
                End If
                ' Create and show exam form
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

    Private Function HasTakenExam(courseID As Integer, assessTypeID As Integer) As Boolean
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            Dim query As String = "SELECT COUNT(*) FROM tb_student_answers 
                                 WHERE studentID = @studentID 
                                 AND courseID = @courseID 
                                 AND assessTypeID = @assessTypeID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentID", UserSession.StudentId)
                cmd.Parameters.AddWithValue("@courseID", courseID)
                cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using

        Catch ex As Exception
            MsgBox("Error checking exam status: " & ex.Message)
            Return False
        End Try
    End Function
End Class