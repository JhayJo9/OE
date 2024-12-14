Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class FormAssignedStudentsList
    ' Add a refresh flag to handle form updates
    Private needsRefresh As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Using frm As New FormAssignedStudent
                frm.btnSave.Text = "SAVE"
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    Fetch_Data()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error opening form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Fetch_Data()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            dgvAssignedStudents.Rows.Clear()

            Dim query As String = "
SELECT
                                s.studentID,
                                s.studentNo,
                                CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS StudentName,
                                c.CourseCode,
                                ss.section AS SectionCode,
                                assess.AssessmentType
                            FROM tb_student s
                            INNER JOIN tb_assignedstudents assi
                                ON s.studentID = assi.studentID
                            INNER JOIN tb_course c
                                ON c.courseID = assi.courseID
                            INNER JOIN tb_assessmenttype assess
                                ON assess.assessTypeID = assi.assessTypeID
                            INNER JOIN tb_section ss
                                ON ss.sectionID = assi.sectionID
                            INNER JOIN tb_assignedsection asg
                                ON s.studentID = asg.studentID;"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        dgvAssignedStudents.Rows.Add(
                        reader.GetInt32("studentID"),
                        reader.GetString("studentNo"),
                        If(reader.IsDBNull(reader.GetOrdinal("StudentName")), String.Empty, reader.GetString("StudentName")),
                        If(reader.IsDBNull(reader.GetOrdinal("CourseCode")), String.Empty, reader.GetString("CourseCode")),
                        If(reader.IsDBNull(reader.GetOrdinal("AssessmentType")), String.Empty, reader.GetString("AssessmentType")),
                        If(reader.IsDBNull(reader.GetOrdinal("SectionCode")), String.Empty, reader.GetString("SectionCode"))
                    )
                    End While
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Function Delete_Record(studentID As Integer) As Boolean
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            Using cmd As New MySqlCommand("DELETE FROM tb_assignedstudents WHERE studentID = @studentID", conn)
                cmd.Parameters.AddWithValue("@studentID", studentID)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Sub FormAssignedStudentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_Data()
    End Sub

    Private Sub dgvAssignedStudents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAssignedStudents.CellContentClick
        If e.RowIndex < 0 Then Return ' Ignore header clicks

        Dim colName As String = dgvAssignedStudents.Columns(e.ColumnIndex).Name

        Select Case colName
            Case "colEdit"
                Try
                    Using frm As New FormAssignedStudent
                        frm.btnSave.Text = "UPDATE"
                        With frm
                            .txtStudentID.Text = dgvAssignedStudents.Rows(e.RowIndex).Cells(1).Value.ToString()
                            .cmbStudentName.Text = dgvAssignedStudents.Rows(e.RowIndex).Cells(2).Value.ToString()

                            ' First fetch the section data
                            '.FetchSectionID(True)

                            ' Then set the values
                            .cmbCourseCode.Text = dgvAssignedStudents.Rows(e.RowIndex).Cells(3).Value.ToString()
                            .cmbAssessmentType.Text = dgvAssignedStudents.Rows(e.RowIndex).Cells(4).Value.ToString()
                            .txtSectionCode.Text = dgvAssignedStudents.Rows(e.RowIndex).Cells(5).Value.ToString()

                            .cmbStudentName.Enabled = False

                            If .ShowDialog() = DialogResult.OK Then
                                Fetch_Data()
                            End If
                        End With
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Error editing record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case "colDelete"
                Dim studentID As Integer = Convert.ToInt32(dgvAssignedStudents.Rows(e.RowIndex).Cells(0).Value)
                Dim studentName As String = dgvAssignedStudents.Rows(e.RowIndex).Cells(2).Value.ToString()

                If MessageBox.Show($"Are you sure you want to delete the record for {studentName}?",
                                 "Confirm Delete",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) = DialogResult.Yes Then

                    If Delete_Record(studentID) Then
                        MessageBox.Show("Record deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Fetch_Data()
                    End If
                End If
        End Select
    End Sub
End Class