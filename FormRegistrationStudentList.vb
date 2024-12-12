Imports System.Globalization
Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient

Public Class FormRegistrationStudentList
    Private isFormOpen As Boolean = False

    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With FormRegistrationStudent
            .ShowDialog()
        End With
    End Sub

    Public Sub fetchStudentList()
        Try
            dgwRegistrationList.Rows.Clear()
            If OPENDB() Then
                Dim st As String = "select
	                                    s.studentNo,
	                                    concat(s.LastName, ', ' , s.FirstName, ' ',s.MiddleName ) as StudentName,
                                        s.Gender,
                                        s.Email,
                                        s.CourseCode,
                                        s.SectionCode
                                    from tb_student s"
                Dim cmd As New MySqlCommand(st, conn)
                Try
                    Dim dtreader As MySqlDataReader = cmd.ExecuteReader

                    While dtreader.Read
                        Dim studentID As Integer = dtreader.GetInt32("studentNo")
                        Dim studentName As String = dtreader.GetString("StudentName")
                        Dim gender As String = dtreader.GetString("Gender")
                        Dim email As String = dtreader.GetString("Email")
                        Dim courseCode As String = dtreader.GetString("CourseCode")
                        Dim sectionCode As String = dtreader.GetString("SectionCode")

                        dgwRegistrationList.Rows.Add(studentID, studentName, gender, email, courseCode, sectionCode)
                    End While
                    dtreader.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Search_Data()
        Try
            dgwRegistrationList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim st As String = "SELECT * FROM tb_student WHERE studentNo LIKE @search OR Lastname LIKE @search OR Firstname LIKE @search OR Middlename LIKE @search OR Email LIKE @search OR ContactNumber LIKE @search"
            Dim cmd As New MySqlCommand(st, conn)
            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
            Dim dtreader As MySqlDataReader = cmd.ExecuteReader()
            While dtreader.Read()
                Dim studentID As Integer = dtreader.GetInt32("studentNo")
                Dim gender As String = dtreader.GetString("Gender")
                Dim email As String = dtreader.GetString("Email")
                Dim courseCode As String = dtreader.GetString("CourseCode")
                Dim sectionCode As String = dtreader.GetString("SectionCode")

                dgwRegistrationList.Rows.Add(studentID, gender, email, courseCode, sectionCode)
            End While
            dtreader.Close()
        Catch ex As Exception
            MsgBox("ERROR SEARCH: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub FormRegistrationStudentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchStudentList()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search_Data()
    End Sub

    Public Sub Delete_Data()
        Try
            If OPENDB() Then
                Dim st As String = "DELETE FROM tb_student WHERE studentNo = @studentNo"
                Dim cmd As New MySqlCommand(st, conn)
                cmd.Parameters.AddWithValue("@studentNo", dgwRegistrationList.CurrentRow.Cells(0).Value.ToString)
                cmd.ExecuteNonQuery()
                MsgBox("Student Deleted")
                fetchStudentList()
            End If
        Catch ex As Exception
            MsgBox("Delete Student: " & ex.Message)
        End Try
    End Sub

    Public Sub dgwRegistrationList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwRegistrationList.CellContentClick
        Dim colname As String = dgwRegistrationList.Columns(e.ColumnIndex).HeaderText
        Dim studentNo As Integer = dgwRegistrationList.CurrentRow.Cells(0).Value
        If colname = "Edit" Then
            With FormRegistrationStudent


                .FetchDate_For_Edit(studentNo)
                MsgBox(studentNo)
                .btnRegister.Text = "UPDATE"
                '.txtStudentNo.Text = dgwRegistrationList.CurrentRow.Cells(0).Value
                '.txtFirstname.Text = dgwRegistrationList.CurrentRow.Cells(1).Value
                '.txtLastname.Text = dgwRegistrationList.CurrentRow.Cells(2).Value
                '.txtMiddlename.Text = dgwRegistrationList.CurrentRow.Cells(3).Value
                '.chbGender.Text = dgwRegistrationList.CurrentRow.Cells(5).Value
                '.dtDateOfBirth.Value = DateTime.Parse(dgwRegistrationList.CurrentRow.Cells(4).Value).ToString("yyyy-MM-dd")
                '.txtEmail.Text = dgwRegistrationList.CurrentRow.Cells(6).Value
                '.txtContactNo.Text = dgwRegistrationList.CurrentRow.Cells(7).Value
                '.cmbCourseCode.Text = dgwRegistrationList.CurrentRow.Cells(8).Value
                '.cmbSectionCode.Text = dgwRegistrationList.CurrentRow.Cells(9).Value
                '.btnClear.Enabled = True
                '.btnRegister.Enabled = True
                .ShowDialog()
            End With

        ElseIf colname = "View" Then
            With FormRegistrationStudent

                .FetchDate_For_View(studentNo)
                MsgBox(studentNo)
                '.txtStudentNo.Text = dgwRegistrationList.CurrentRow.Cells(0).Value
                '.txtFirstname.Text = dgwRegistrationList.CurrentRow.Cells(1).Value
                '.txtLastname.Text = dgwRegistrationList.CurrentRow.Cells(2).Value
                '.txtMiddlename.Text = dgwRegistrationList.CurrentRow.Cells(3).Value
                '.chbGender.Text = dgwRegistrationList.CurrentRow.Cells(5).Value
                '.dtDateOfBirth.Value = DateTime.Parse(dgwRegistrationList.CurrentRow.Cells(4).Value)
                '.txtEmail.Text = dgwRegistrationList.CurrentRow.Cells(6).Value
                '.txtContactNo.Text = dgwRegistrationList.CurrentRow.Cells(7).Value
                '.cmbCourseCode.Text = dgwRegistrationList.CurrentRow.Cells(8).Value
                '.cmbSectionCode.Text = dgwRegistrationList.CurrentRow.Cells(9).Value
                '.txtFirstname.Enabled = False
                '.txtLastname.Enabled = False
                '.txtMiddlename.Enabled = False
                '.chbGender.Enabled = False
                '.dtDateOfBirth.Enabled = False
                '.txtEmail.Enabled = False
                '.txtContactNo.Enabled = False
                '.cmbCourseCode.Enabled = False
                '.cmbSectionCode.Enabled = False
                '.btnClear.Enabled = False
                '.btnRegister.Enabled = False
                .ShowDialog()

            End With
            'FetchDate_For_View(dgwRegistrationList.CurrentRow.Cells(0).Value)
        ElseIf colname = "Delete" Then
            Delete_Data()
        End If
    End Sub


End Class
