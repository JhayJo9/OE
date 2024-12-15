Imports MySql.Data.MySqlClient
Imports System.Text
Imports MySql.Data
Imports System.Diagnostics.Eventing

Public Class FormRegistrationStudent
    Public Function ValidateInputs() As Boolean
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

    Public Sub ClearControls()
        txtStudentNo.Clear()
        txtFirstname.Clear()
        txtLastname.Clear()
        txtMiddlename.Clear()
        txtEmail.Clear()
        txtContactNo.Clear()
        chbGender.SelectedIndex = -1
        cmbSectionCode.SelectedIndex = -1
        dtDateOfBirth.Value = DateTime.Now
    End Sub

    Public Sub SetControlsState(enabled As Boolean)
        txtFirstname.Enabled = enabled
        txtLastname.Enabled = enabled
        txtMiddlename.Enabled = enabled
        txtEmail.Enabled = enabled
        txtContactNo.Enabled = enabled
        chbGender.Enabled = enabled
        cmbSectionCode.Enabled = enabled
        dtDateOfBirth.Enabled = enabled
        btnRegister.Enabled = enabled
        btnClear.Enabled = enabled
    End Sub

    Public Sub fetchSection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            If OPENDB() Then
                Dim st As String = "SELECT section FROM tb_section"
                Dim cmd As New MySqlCommand(st, conn)
                Dim readerSection As MySqlDataReader = cmd.ExecuteReader()
                While readerSection.Read()
                    Dim section As String = readerSection.GetString("section")
                    cmbSectionCode.Items.Add(section)
                End While
            End If
        Catch ex As Exception
            MsgBox("Fetch Section " & ex.Message)
        End Try
    End Sub

    Public Sub InsertStudent()

        If Not ValidateInputs() Then
            Return
        End If

        Dim currentYear As String = DateTime.Now.ToString("yyyy")
        Dim lastStudentNumber As Integer = 0
        Dim newStudentNumber As Integer

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()
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
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "INSERT INTO tb_student (studentNo, Firstname, Lastname, Middlename, DateOfBirth, Gender, Email, ContactNumber) " &
                          "VALUES (@studentNo, @Firstname, @Lastname, @Middlename, @DateOfBirth, @Gender, @Email, @ContactNumber)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@studentNo", rs)
            cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text)
            cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text)
            cmd.Parameters.AddWithValue("@Middlename", txtMiddlename.Text)
            cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)

            cmd.ExecuteNonQuery()
            'MsgBox("Successfully Registered")
            ' After successfully inserting a student

            'FormRegistrationStudentList.FetchStudentList()

        Catch ex As MySqlException When ex.Number = 1062 ' Duplicate entry error code
            MsgBox("Duplicate entry detected: " & ex.Message)
            ' Handle the duplicate error, possibly by retrying with a new student number
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Try

            Dim maxxID As Integer = 0

            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim d As String = "select max(studentID) as StudIDMAX from tb_student"
            Dim cmdd As New MySqlCommand(d, conn)
            Dim rede As MySqlDataReader = cmdd.ExecuteReader

            If rede.Read Then
                maxxID = rede.GetInt32("StudIDMAX")
            End If

            AssignSectionToStudent(maxxID, cmbSectionCode.SelectedItem.ToString())

            MsgBox("Successfully Registered")
        Catch ex As Exception
            MsgBox("Max ID: " & ex.Message)
        End Try
    End Sub
    Public Sub UpdateStudent()
        'If conn.State = ConnectionState.Open Then
        '    conn.Close()
        'End If
        Try
            'conn.Open()
            If OPENDB() Then
                Dim up As String = "UPDATE tb_student SET Lastname = @Lastname, Firstname = @Firstname, Middlename = @Middlename, DateOfBirth = @DateOfBirth, Gender=@Gender, Email = @Email, ContactNumber = @ContactNumber, 
                     SectionCode = @SectionCode WHERE studentNo = @studentNo"
                Dim cmd As New MySqlCommand(up, conn)
                cmd.Parameters.AddWithValue("@studentNo", txtStudentNo.Text)
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text)
                cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text)
                cmd.Parameters.AddWithValue("@Middlename", txtMiddlename.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)
                'cmd.Parameters.AddWithValue("@CourseCode", cmbCourseCode.Text)
                cmd.Parameters.AddWithValue("@SectionCode", cmbSectionCode.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Updated")
                ' Find the main form and refresh it
                With FormRegistrationStudentList
                    .fetchStudentList()
                End With
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

    Public Sub AssignSectionToStudent(studentID As String, sectionCode As String)

        MsgBox(studentID)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            ' Get sectionID using sectionCode
            Dim sectionID As Integer
            Dim getSectionIDQuery As String = "SELECT sectionID FROM tb_section WHERE section = @sectionCode"
            Dim cmdGetSectionID As New MySqlCommand(getSectionIDQuery, conn)
            cmdGetSectionID.Parameters.AddWithValue("@sectionCode", sectionCode)
            Dim reader As MySqlDataReader = cmdGetSectionID.ExecuteReader()
            If reader.Read() Then
                sectionID = Convert.ToInt32(reader("sectionID"))

                MsgBox("Section ID: " & sectionID)
            Else
                MsgBox("Section not found")
                Return
            End If
            reader.Close()

            ' Insert into tb_assignedsection
            Dim insertQuery As String = "INSERT INTO tb_assignedsection VALUES (null, @studentID, @sectionID)"
            Dim cmdInsert As New MySqlCommand(insertQuery, conn)
            cmdInsert.Parameters.AddWithValue("@studentID", CStr(studentID))
            cmdInsert.Parameters.AddWithValue("@sectionID", CStr(sectionID))
            cmdInsert.ExecuteNonQuery()

            MsgBox("StudID: " & studentID & " SectionID: " & sectionID)

            MsgBox("Section assigned to student successfully")

        Catch ex As Exception
            MsgBox("Error assigning section to student: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub GenerateUsernamePassword()
        Dim userID As Integer = 0
        Dim studentID As Integer = 0
        Dim studentNo As Integer = 0
        Try
            If OPENDB() Then
                ' First, get the latest studentID from tb_student
                Dim queryStudentID As String = "SELECT MAX(studentNo) as studentNo FROM tb_student"
                Using cmd As New MySqlCommand(queryStudentID, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        studentID = reader.GetInt32("studentID")
                        studentNo = reader.GetInt32("studentNo")
                    End If
                    reader.Close()
                End Using

                ' Then get the latest userID
                Dim queryUserID As String = "SELECT MAX(userID) as userID FROM tb_users"
                Using cmd As New MySqlCommand(queryUserID, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        userID = reader.GetInt32("userID")
                    End If
                    reader.Close()
                End Using

                ' Generate random password
                Dim password As String = GenerateRandomString(12)

                ' Insert into tb_generatedusernamepassword
                Dim query As String = "INSERT INTO tb_generatedusernamepassword values(null, @userID, @username, @password, @role, @studentID)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    cmd.Parameters.AddWithValue("@username", studentID.ToString())  ' Using studentID as username
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@role", "Student")
                    cmd.Parameters.AddWithValue("@studentID", studentID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Store the credentials for later use
                usernameClone = studentNo.ToString()
                passwordClone = password

                MessageBox.Show("Your Student ID/Username: " & usernameClone & vbCrLf & "Generated Password: " & passwordClone)

                Dim verify As New verifyStudent()
                verify.Show()

                Dim formm As New Form1()
                formm.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in GenerateUsernamePassword")
        Finally
            conn.Close()
        End Try
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
    Private Sub FormRegistrationStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If btnRegister.Text = "REGISTER" Then
            fetchSection()
        End If
        OPENDB()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If ValidateInputs() Then
            If btnRegister.Text = "REGISTER" Then
                InsertStudent()
                GenerateUsernamePassword()
                Me.Dispose()
            ElseIf btnRegister.Text = "UPDATE" Then
                If MsgBox("Are you sure you want to update this student?", MsgBoxStyle.YesNo, "Update Student") = MsgBoxResult.Yes Then
                    UpdateStudent()
                End If
            End If
        End If
    End Sub

    Private Sub cmbSectionCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSectionCode.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
