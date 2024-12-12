Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class FormAssignedStudent

    Dim studentSectionCode As String = ""
    Dim studentid As Integer = 0
    Public Sub Fectch_Student()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            If OPENDB() Then
                Dim st As String = "select s.studentID,
                                            concat(studentNo ,': ' ,LastName, ', ', FirstName, ' ', MiddleName) as StudentName 
                                        from tb_student s;"
                Dim cmd As New MySqlCommand(st, conn)
                Dim readerstudent As MySqlDataReader = cmd.ExecuteReader

                While readerstudent.Read()
                    Dim studentid As Integer = readerstudent.GetInt32("studentID")
                    Dim studentname As String = readerstudent.GetString("StudentName")
                    cmbStudentName.Items.Add(studentname)
                End While
                readerstudent.Close()
            End If
        Catch ex As Exception
            MsgBox("SELECT STUDENT ERROR: " & ex.Message)
        End Try
    End Sub

    Public Sub Fetch_Course()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            If OPENDB() Then
                Dim fetch As String = "SELECT courseCode FROM tb_course"
                Dim cmd As New MySqlCommand(fetch, conn)
                Dim readerCourse As MySqlDataReader = cmd.ExecuteReader()

                While readerCourse.Read()
                    Dim courseCode As String = readerCourse.GetString("courseCode")
                    cmbCourseCode.Items.Add(courseCode)
                End While
                readerCourse.Close()
            End If
        Catch ex As Exception
            MsgBox("SELECT COURSE: " & ex.Message)
        End Try
    End Sub

    Public Sub insert_Data()
        Try
            conn.Open()
            Dim selectedStudent = cmbStudentName.SelectedItem
            Dim studentid As Integer = selectedStudent.ID
            Dim courseCode As String = cmbCourseCode.Text
            Dim sectionCode As String = txtSectionCode.Text
            Dim insert As String = "INSERT INTO tb_assignedstudent(studentID, courseCode, sectionCode) VALUES(@studentID, @courseCode, @sectionCode)"
            Dim cmd As New MySqlCommand(insert, conn)
            cmd.Parameters.AddWithValue("@studentID", studentid)
            cmd.Parameters.AddWithValue("@courseCode", courseCode)
            cmd.Parameters.AddWithValue("@sectionCode", sectionCode)
            cmd.ExecuteNonQuery()
            MsgBox("Student Assigned Successfully")
            conn.Close()
        Catch ex As Exception
            MsgBox("INSERT DATA: " & ex.Message)
        End Try
    End Sub

    Private Sub FormAssignedStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fectch_Student()
        Fetch_Course()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbStudentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStudentName.SelectedIndexChanged
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            Dim selectedStudent = cmbStudentName.SelectedItem
            studentid = selectedStudent.ID
            Dim stscode As String = "SELECT sectionCode FROM tb_student WHERE studentID = @studentID"
            Dim cmd As New MySqlCommand(stscode, conn)
            cmd.Parameters.AddWithValue("@studentID", studentid)
            Dim readerSection As MySqlDataReader = cmd.ExecuteReader
            txtSectionCode.Clear()
            While readerSection.Read()
                studentSectionCode = readerSection.GetString("sectionCode")
                txtSectionCode.Text = studentSectionCode
            End While
            readerSection.Close()
        Catch ex As Exception
            MsgBox("SELECT SECTION CODE: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    ' FIX REGISTRRATION OF STUDENT AND ASSGINED STUDENT TO COURSE THEN CRUD 
End Class
