Imports MySql.Data.MySqlClient
Imports System.Text

Public Class FormRegistrationStudent
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Public Sub insertData()

        Try
            Dim query As String = "INSERT into tb_users values (null, @Firstname, @LastName, @MiddleName, @DateOfBirth, @Gender, @Email, @ContactNumber, @role)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text)
                cmd.Parameters.AddWithValue("@LastName", txtLastname.Text)
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddlename.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@role", "Student")
                cmd.ExecuteNonQuery()

                MsgBox("Successfully Registered")
            End Using
        Catch ex As Exception
            MsgBox("REGISTRATION " & ex.Message)
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
        Try
            If OPENDB() Then

                Dim query As String = "SELECT MAX(userID) as userID FROM tb_users"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        userID = reader.GetInt32("userID")
                        'MsgBox(studentID)
                    End If

                    conn.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SELECTING")
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

                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "INSERTING")
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
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

    End Sub
End Class