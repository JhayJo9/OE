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

                        'MsgBox("Course Fetched Successfully", MsgBoxStyle.Information, "Success")
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
                MsgBox("Course Deleted")
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
            If MsgBox("Delete course?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                deleteCourse()
                fetchCourse()
            End If
        ElseIf colName = "colEdit" Then
            With Formcourse
                .txtAddCourse.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txtsddcourseCode.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .btnAddCourse.Enabled = False
                .btnEdit.Enabled = True
                .ShowDialog()
            End With
        End If
    End Sub
End Class