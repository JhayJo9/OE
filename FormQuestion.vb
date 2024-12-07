Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormQuestion

    Public Sub fetchCourse()
        Try
            If OPENDB() Then
                Dim fetch As String = "SELECT * FROM tb_course"
                Using cmd As New MySqlCommand(fetch, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read
                            Dim courseID As Integer = dtreader.GetInt32("courseID")
                            Dim courseTitle As String = dtreader.GetString("courseTitle")
                            Dim courseCode As String = dtreader.GetString("courseCode")


                            cmbCourse.Items.Add(courseTitle)
                            lblcoursecode.Text = courseCode
                        End While

                        'MsgBox("Course Fetched Successfully", MsgBoxStyle.Information, "Success")
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT COURSE: " & ex.Message)
        End Try
    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
        AdminDashboard.Show()
    End Sub

    Private Sub FormQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourse()
    End Sub
End Class