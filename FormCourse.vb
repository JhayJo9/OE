Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormCourse

    Public Sub insertCourse()
        Dim insert As String = "INSERT INTO tb_course VALUES (null, @courseTitle, @courseCode)"
        Using cmd As New MySqlCommand(insert, conn)
            'cmd.Parameters.AddWithValue("@courseTitle", txtAddCourse.Text)
            'cmd.Parameters.AddWithValue("@courseCode", txtsddcourseCode.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Course Added Successfully", MsgBoxStyle.Information, "Success")

            ' Clear the textboxes
            DataGridView1.Rows.Clear()
            'txtAddCourse.Clear()
            'txtsddcourseCode.Clear()
            fetchCourse()
        End Using
    End Sub

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



    Private Sub FormCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OPENDB()
        fetchCourse()
    End Sub

    Private Sub FormCourse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closeConnection()
    End Sub

    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs)
        'insertCourse()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addingCourse As New AddingCourse()
        addingCourse.Show()
    End Sub
End Class