Imports MySql.Data.MySqlClient
Imports System.Text
Imports MySql.Data
Imports System.Diagnostics.Eventing

Public Class FormRegistrationStudent
    Public Function ValidateTexboxes() As Boolean
        If txtFirstname.Text.Trim() = "" Then
            MessageBox.Show("Please enter Firstname", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirstname.Focus()
            Return False
        End If
        If txtLastname.Text.Trim() = "" Then
            MessageBox.Show("Please enter Lastname", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLastname.Focus()
            Return False
        End If
        If txtMiddlename.Text.Trim() = "" Then
            MessageBox.Show("Please enter Middlename", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMiddlename.Focus()
            Return False
        End If
        If txtEmail.Text.Trim() = "" OrElse Not txtEmail.Text.Trim().Contains("@") Then
            MessageBox.Show("Please enter Email", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.Focus()
            Return False
        End If
        If txtContactNo.Text.Trim() = "" OrElse Not IsNumeric(txtContactNo.Text) Then
            MessageBox.Show("Please enter Contact number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub fetchCourse()
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

    Public Sub fetchSection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            If OPENDB() Then
                Dim st As String = "SELECT * FROM tb_section"
                Dim cmd As New MySqlCommand(st, conn)
                Dim readerSection As MySqlDataReader = cmd.ExecuteReader()
                While readerSection.Read()
                    Dim section As String = readerSection.GetString("section")
                    cmbSectionCode.Items.Add(section)
                End While

                readerSection.Close()
            End If
        Catch ex As Exception
            MsgBox("Fetch Section " & ex.Message)
        End Try
    End Sub

    Public Sub insertData()

        If Not ValidateTexboxes() Then
            Return
        End If

        Dim currentYear As String = DateTime.Now.ToString("yyyy")
        Dim lastStudentNumber As Integer = 0
        Dim newStudentNumber As Integer

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT MAX(CAST(SUBSTRING(studentNo, 5) AS UNSIGNED)) AS lastNumber FROM tb_student WHERE studentNo LIKE @YearPrefix"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@YearPrefix", currentYear & "%")
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() AndAlso Not IsDBNull(reader("lastNumber")) Then
                lastStudentNumber = Convert.ToInt32(reader("lastNumber"))
            End If

            reader.Close()
        Catch ex As Exception
            MsgBox("GETTING THE LAST STUDENT NUMBER: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        newStudentNumber = lastStudentNumber + 1
        Dim rs As String = currentYear & newStudentNumber.ToString("D4")


        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim query As String = "INSERT INTO tb_student (studentNo, Firstname, Lastname, Middlename, DateOfBirth, Gender, Email, ContactNumber, CourseCode, SectionCode) " &
                              "VALUES (@studentNo, @Firstname, @Lastname, @Middlename, @DateOfBirth, @Gender, @Email, @ContactNumber, @CourseCode, @SectionCode)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@studentNo", rs)
            cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text)
            cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text)
            cmd.Parameters.AddWithValue("@Middlename", txtMiddlename.Text)
            cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@CourseCode", cmbCourseCode.Text)
            cmd.Parameters.AddWithValue("@SectionCode", cmbSectionCode.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Successfully Registered")

            FormRegistrationStudentList.fetchStudentList()

        Catch ex As MySqlException When ex.Number = 1062 ' Duplicate entry error code
            MsgBox("Duplicate entry detected: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message)
        Finally

            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub Update_Data()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            If OPENDB() Then
                Dim up As String = "UPDATE tb_student SET Lastname = @Lastname, Firstname = @Firstname, Middlename = @Middlename, DateOfBirth = @DateOfBirth, Gender=@Gender, Email = @Email, ContactNumber = @ContactNumber, 
                        CourseCode = @CourseCode, SectionCode = @SectionCode WHERE studentNo = @studentNo"
                Dim cmd As New MySqlCommand(up, conn)
                cmd.Parameters.AddWithValue("@studentNo", txtStudentNo.Text)
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text)
                cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text)
                cmd.Parameters.AddWithValue("@Middlename", txtMiddlename.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@CourseCode", cmbCourseCode.Text)
                cmd.Parameters.AddWithValue("@SectionCode", cmbSectionCode.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Updated")
            End If
        Catch ex As Exception
            MsgBox("Error Updating: " & ex.Message)
        End Try
    End Sub
    Public Function getFirstName(name As String) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim rnd As New Random()
        Dim result As New StringBuilder()
        Dim s As String = ""
        For i As Integer = 1 To 5
            result.Append(chars(rnd.Next(chars.Length)))
            s = result.ToString() & name
        Next
        Return s
    End Function

    Public Sub GenerateUsernamePassword()
        Dim username As String = getFirstName(txtFirstname.Text)
        Dim password As String = GenerateRandomString(12)
        Dim userID As Integer = 0

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            If OPENDB() Then
                Dim query As String = "SELECT MAX(studentNo) as studentNo FROM tb_student"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        userID = reader.GetInt32("studentNo")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("SELECTING MAX ID: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            If OPENDB() Then
                Dim query As String = "INSERT INTO tb_generatedusernamepassword values(null,@userID, @username, @password, @role)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@role", "Student")
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("INSERTING G-P: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        usernameClone = username
        passwordClone = password

        MessageBox.Show("Generated Username: " & usernameClone & vbCrLf & "Generated Password: " & passwordClone)

        Dim verify As New verifyStudent()
        verify.Show()

        Dim formm As New Form1()
        formm.Close()
    End Sub

    Private Function GenerateRandomString(length As Integer) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim random As New Random()
        Dim result As New StringBuilder()
        For i As Integer = 1 To length
            result.Append(chars(random.Next(chars.Length)))
        Next
        Return result.ToString()
    End Function

    Public Sub FetchDate_For_View(studentNo As Integer)
        'isFormOpen = True
        Try
            If OPENDB() Then
                Dim query As String = "SELECT 
                                        studentNo,
                                        FirstName,
                                        LastName,
                                        MiddleName,
                                        Gender,
                                        DateOfBirth,
                                        Email,
                                        ContactNumber,
                                        CourseCode,
                                        SectionCode
                                   FROM tb_student
                                   WHERE studentNo = @studentNo"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentNo", studentNo)

                Dim dtreader As MySqlDataReader = cmd.ExecuteReader()
                If dtreader.Read() Then
                    ' Populate FormRegistrationStudent

                    txtStudentNo.Text = dtreader.GetString("studentNo")
                    txtFirstname.Text = dtreader.GetString("FirstName")
                    txtLastname.Text = dtreader.GetString("LastName")
                    txtMiddlename.Text = dtreader.GetString("MiddleName")
                    chbGender.Text = dtreader.GetString("Gender")
                    dtDateOfBirth.Value = DateTime.Parse(dtreader.GetDateTime("DateOfBirth")).ToString("yyyy-MM-dd")
                    txtEmail.Text = dtreader.GetString("Email")
                    txtContactNo.Text = dtreader.GetString("ContactNumber")
                    cmbCourseCode.Text = dtreader.GetString("CourseCode")
                    cmbSectionCode.Text = dtreader.GetString("SectionCode")

                    ' Disable fields
                    txtFirstname.Enabled = False
                    txtLastname.Enabled = False
                    txtMiddlename.Enabled = False
                    chbGender.Enabled = False
                    dtDateOfBirth.Enabled = False
                    txtEmail.Enabled = False
                    txtContactNo.Enabled = False
                    cmbCourseCode.Enabled = False
                    cmbSectionCode.Enabled = False

                    btnClear.Enabled = False
                    btnRegister.Enabled = False



                Else
                    MsgBox("No details found for the selected student.")
                End If
                dtreader.Close()
            End If
        Catch ex As Exception
            MsgBox("Error fetching student details: " & ex.Message)
            'Finally
            '    isFormOpen = False
        End Try
    End Sub

    Public Sub FetchDate_For_Edit(studentNo As Integer)
        'isFormOpen = True
        Try
            If OPENDB() Then
                Dim query As String = "SELECT 
                                        studentNo,
                                        FirstName,
                                        LastName,
                                        MiddleName,
                                        Gender,
                                        DateOfBirth,
                                        Email,
                                        ContactNumber,
                                        CourseCode,
                                        SectionCode
                                   FROM tb_student
                                   WHERE studentNo = @studentNo"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentNo", studentNo)

                Dim dtreader As MySqlDataReader = cmd.ExecuteReader()
                If dtreader.Read() Then
                    ' Populate FormRegistrationStudent

                    btnRegister.Text = "UPDATE"
                    txtStudentNo.Text = dtreader.GetString("studentNo")
                    txtFirstname.Text = dtreader.GetString("FirstName")
                    txtLastname.Text = dtreader.GetString("LastName")
                    txtMiddlename.Text = dtreader.GetString("MiddleName")
                    chbGender.Text = dtreader.GetString("Gender")
                    dtDateOfBirth.Value = DateTime.Parse(dtreader.GetDateTime("DateOfBirth")).ToString("yyyy-MM-dd")
                    txtEmail.Text = dtreader.GetString("Email")
                    txtContactNo.Text = dtreader.GetString("ContactNumber")
                    cmbCourseCode.Text = dtreader.GetString("CourseCode")
                    cmbSectionCode.Text = dtreader.GetString("SectionCode")

                    btnClear.Enabled = True
                    btnRegister.Enabled = True


                Else
                    MsgBox("No details found for the selected student.")
                End If
                dtreader.Close()
            End If
        Catch ex As Exception
            MsgBox("Error fetching student details: " & ex.Message)
        Finally
            'isFormOpen = False
        End Try
    End Sub

    Private Sub FormRegistrationStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If btnRegister.Text = "REGISTER" Then
            fetchCourse()
            fetchSection()
        End If
        OPENDB()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If btnRegister.Text = "REGISTER" Then
            insertData()
            'GenerateUsernamePassword()
        ElseIf btnRegister.Text = "UPDATE" Then
            Update_Data()
        End If
    End Sub

    Private Sub cmbSectionCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSectionCode.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbCourseCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCourseCode.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmbSectionCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSectionCode.SelectedIndexChanged

    End Sub
End Class
