Imports MySql.Data.MySqlClient

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchstudent()
        fetchcourse()
    End Sub

    Public Sub fetchcourse()
        Try
            If OPENDB() Then
                Dim query As String = "SELECT courseCode FROM tb_course"
                Dim cmd As New MySqlCommand(query, conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                cmbCourseCode.Items.Clear()

                While reader.Read()
                    Dim courseCode As String = reader.GetString("courseCode")
                    cmbCourseCode.Items.Add(courseCode)
                End While

                reader.Close()
            End If
        Catch ex As Exception
            MsgBox("FETCH COURSE: " & ex.Message)
        End Try
    End Sub

    Public Sub fetchstudent()
        Try
            If OPENDB() Then
                Dim query As String = "
                SELECT 
                    CONCAT(FirstName, ' ', LastName) AS StudentName, 
                    s.studentNo AS StudentNumber 
                FROM tb_student s"
                Dim cmd As New MySqlCommand(query, conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                cmbStudentName.Items.Clear()
                'cmbStudentNumber.Items.Clear()

                While reader.Read()
                    Dim studentName As String = reader.GetString("StudentName")
                    Dim studentNumber As String = reader.GetString("StudentNumber")

                    cmbStudentName.Items.Add(studentNumber & ": " & studentName)
                    ' cmbStudentNumber.Items.Add(studentNumber)
                End While

                reader.Close()
            End If
        Catch ex As Exception
            MsgBox("FETCH STUDENT: " & ex.Message)
        End Try
    End Sub

    Public Sub insertdata()
        Try
            If OPENDB() Then
                'Dim save As String = "insert into"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class