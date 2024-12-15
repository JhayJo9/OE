Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormCourseList
    Public Sub fetchCourse()
        Try
            DataGridView1.Rows.Clear()

            If OPENDB() Then
                Dim fetch As String = "SELECT * FROM tb_course"
                Using cmd As New MySqlCommand(fetch, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read
                            Dim courseID As Integer = dtreader.GetInt32("courseID")
                            Dim courseTitle As String = dtreader.GetString("courseTitle")
                            Dim courseCode As String = dtreader.GetString("courseCode")

                            DataGridView1.Rows.Add(courseID, courseTitle, courseCode)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT COURSE: " & ex.Message)
        End Try
    End Sub

    Public Sub deleteCourse()
        Try
            If OPENDB() Then
                Dim st As String = "DELETE FROM tb_course WHERE courseID = @courseID"
                Using cmd As New MySqlCommand(st, conn)
                    cmd.Parameters.AddWithValue("@courseID", DataGridView1.CurrentRow.Cells(0).Value.ToString)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Delete Course: " & ex.Message)
        End Try
    End Sub

    Private Sub FormCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OPENDB()
        fetchCourse()
    End Sub

    Private Sub FormCourse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closeConnection()
    End Sub

    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With Formcourse

            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name

        If colName = "colDelete" Then

            If MessageBox.Show("Are you sure you want to delete this course?: " & DataGridView1.CurrentRow.Cells(1).Value.ToString, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    deleteCourse()
                    fetchCourse()
                Catch ex As Exception
                    MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf colName = "colEdit" Then
            With Formcourse
                .btnAddCourse.Text = "UPDATE"
                .txtAddCourse.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txtsddcourseCode.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .ShowDialog()
            End With
        End If
    End Sub
End Class