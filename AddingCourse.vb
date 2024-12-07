Imports MySql.Data.MySqlClient

Public Class AddingCourse
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()

    End Sub

    Public Sub insertCourse()
        Dim insert As String = "INSERT INTO tb_course VALUES (null, @courseTitle, @courseCode)"
        Using cmd As New MySqlCommand(insert, conn)
            cmd.Parameters.AddWithValue("@courseTitle", txtAddCourse.Text)
            cmd.Parameters.AddWithValue("@courseCode", txtsddcourseCode.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Course Added Successfully", MsgBoxStyle.Information, "Success")

            With FormCourse
                .fetchCourse()
            End With

            ' Clear the textboxes
            'DataGridView1.Rows.Clear()
            txtAddCourse.Clear()
            txtsddcourseCode.Clear()
            'fetchCourse()
        End Using
    End Sub



    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
        insertCourse()
    End Sub
End Class