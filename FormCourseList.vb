Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormCourseList
    Public Sub FetchCourse()
        Try
            DataGridView1.Rows.Clear()

            ' Check if connection exists and is open
            If OPENDB() Then
                Const query As String = "SELECT courseID, courseTitle, courseCode FROM tb_course ORDER BY courseID"

                Using cmd As New MySqlCommand(query, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                        ' Check if there are rows
                        If dtreader.HasRows Then
                            While dtreader.Read()
                                ' Use IsDBNull check to prevent null errors
                                Dim courseID As Integer = If(dtreader.IsDBNull(0), 0, dtreader.GetInt32(0))
                                Dim courseTitle As String = If(dtreader.IsDBNull(1), String.Empty, dtreader.GetString(1))
                                Dim courseCode As String = If(dtreader.IsDBNull(2), String.Empty, dtreader.GetString(2))

                                DataGridView1.Rows.Add(courseID, courseTitle, courseCode)
                            End While
                        End If
                    End Using
                End Using
            Else
                MessageBox.Show("Database connection failed.", "Connection Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As MySqlException
            MessageBox.Show($"Database Error: {ex.Message}", "Database Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
            End If
        Catch ex As Exception
            ' Log the error
        Finally
            MyBase.OnFormClosing(e)
        End Try
    End Sub
End Class