Imports MySql.Data.MySqlClient

Public Class FormExamListForStudent
    Public Sub Fetch_Data()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            ' Modified query to include exam completion status
            Dim q As String = "SELECT 
                    c.courseID,
                    c.courseCode,
                    assess.assessTypeID,
                    assess.AssessmentType,
                    assi.assesID,   
                    COUNT(DISTINCT qa.questionID) as QuestionCount,
                    CASE 
                        WHEN EXISTS (
                            SELECT 1 FROM tb_student_answers sa 
                            WHERE sa.studentID = s.studentID 
                            AND sa.courseID = c.courseID 
                            AND sa.assessTypeID = assess.assessTypeID
                        ) THEN 1 
                        ELSE 0 
                    END as HasTakenExam
                FROM 
                    tb_student s
                INNER JOIN 
                    tb_assignedstudents assi ON s.studentID = assi.studentID
                INNER JOIN 
                    tb_course c ON c.courseID = assi.courseID
                INNER JOIN 
                    tb_assessmenttype assess ON assess.assessTypeID = assi.assessTypeID
                LEFT JOIN 
                    tb_question_assignment qa ON qa.assignedID = assi.assesID
                WHERE 
                    s.studentID = @studentID
                GROUP BY 
                    c.courseID, c.courseCode, assess.assessTypeID, 
                    assess.AssessmentType, assi.assesID"

            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    g.Rows.Clear()
                    While reader.Read()
                        Dim hasTaken As Boolean = Convert.ToBoolean(reader("HasTakenExam"))

                        ' Add row with question count and status
                        Dim rowIndex As Integer = g.Rows.Add(
                            reader("courseCode"),
                            reader("AssessmentType"),
                            reader("QuestionCount").ToString() & " Questions",
                            If(hasTaken, "Completed", "Take Exam")
                        )

                        ' Store IDs and exam status in row's Tag property
                        g.Rows(rowIndex).Tag = New Dictionary(Of String, Object) From {
                            {"courseID", reader("courseID")},
                            {"assessTypeID", reader("assessTypeID")},
                            {"assesID", reader("assesID")},
                            {"questionCount", reader("QuestionCount")},
                            {"hasTakenExam", hasTaken}
                        }

                        ' Disable "Take Exam" button if already taken
                        If hasTaken Then
                            g.Rows(rowIndex).Cells("colTakeExam").Style.BackColor = Color.LightGray
                            g.Rows(rowIndex).Cells("colTakeExam").Style.ForeColor = Color.DarkGray
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("FETCHING DATA: " & ex.Message)
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
                    .StudentID = _STUDENTD,
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
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)
                cmd.Parameters.AddWithValue("@courseID", courseID)
                cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using

        Catch ex As Exception
            MsgBox("Error checking exam status: " & ex.Message)
            Return False
        End Try
    End Function
    ' Optional: Add refresh button
    'Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
    '    Fetch_Data()
    'End Sub

    ' Optional: Add search/filter functionality
    'Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    '    For Each row As DataGridViewRow In dgvStudentExams.Rows
    '        If row.Cells("Course").Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()) OrElse
    '       row.Cells("Assessment").Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()) Then
    '            row.Visible = True
    '        Else
    '            row.Visible = False
    '        End If
    '    Next
    'End Sub
End Class
