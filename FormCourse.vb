Imports MySql.Data.MySqlClient
Imports Mysqlx.Cursor

Public Class Formcourse


    Public Sub insertCourse()
        Try

            Dim insert As String = "INSERT INTO tb_course VALUES (null, @courseTitle, @courseCode)"
            Using cmd As New MySqlCommand(insert, conn)
                cmd.Parameters.AddWithValue("@courseTitle", txtAddCourse.Text)
                cmd.Parameters.AddWithValue("@courseCode", txtsddcourseCode.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Course Added Successfully", MsgBoxStyle.Information, "Success")

                txtAddCourse.Clear()
                txtsddcourseCode.Clear()
                'fetchCourse()
            End Using
        Catch ex As Exception
            MsgBox("INSERT COURSE: " & ex.Message)
        End Try
    End Sub


    Public Sub updateCourse()
        Try
            If OPENDB() Then
                Dim upsec As String = "UPDATE tb_course SET courseTitle=@courseTitle, CourseCode=@CourseCode WHERE courseID = @courseID"
                Using cmd As New MySqlCommand(upsec, conn)
                    cmd.Parameters.AddWithValue("@courseTitle", txtAddCourse.Text)
                    cmd.Parameters.AddWithValue("@CourseCode", txtsddcourseCode.Text)
                    cmd.Parameters.AddWithValue("@courseID", FormCourseList.DataGridView1.CurrentRow.Cells(0).Value.ToString)
                    cmd.ExecuteNonQuery()
                End Using

                txtAddCourse.Clear()
                txtsddcourseCode.Clear()
                MsgBox("Section Updated")
            End If
        Catch ex As Exception
            MsgBox("Update Section: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
        If MsgBox("Are you sure you want to add this course?", MsgBoxStyle.YesNo, "Add Course") = MsgBoxResult.Yes Then
            insertCourse()
            With FormCourseList
                .fetchCourse()
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If MsgBox("Are you sure you want to update this course?", MsgBoxStyle.YesNo, "Update Course") = MsgBoxResult.Yes Then
            updateCourse()
            With FormCourseList

                .fetchCourse()
            End With
        End If
    End Sub

    Private Sub Formcourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class