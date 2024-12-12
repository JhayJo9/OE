Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Public Class Form3

    Public Sub insertData()

        Dim currentYear As String = DateTime.Now.ToString("yyyy")
        Dim lastStudentNumber As Integer = 0
        Dim newStudentNumber As Integer

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT MAX(CAST(SUBSTRING(studentNo, 5) AS UNSIGNED)) AS lastNumber FROM tb_student WHERE studentNo LIKE @YearPrefix"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@YearPrefix", currentYear & "%")
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not IsDBNull(reader("lastNumber")) Then
                        lastStudentNumber = Convert.ToInt32(reader("lastNumber"))
                    End If
                End Using
            End Using
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
            ' Open the connection if it is closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Generate the student number
            'Dim studentNumber As String = fg()

            ' Define the query
            Dim query As String = "INSERT INTO tb_student (studentNo, Firstname, Lastname, Middlename, DateOfBirth, Gender, Email, ContactNumber) " &
                              "VALUES (@studentNo, @Firstname, @Lastname, @Middlename, @DateOfBirth, @Gender, @Email, @ContactNumber)"

            ' Execute the query
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@studentNo", rs)
                cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text)
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text)
                cmd.Parameters.AddWithValue("@Middlename", txtMiddlename.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", dtDateOfBirth.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@Gender", chbGender.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@ContactNumber", txtContactNo.Text)

                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Successfully Registered")
        Catch ex As MySqlException When ex.Number = 1062 ' Duplicate entry error code
            MsgBox("Duplicate entry detected: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message)
        Finally
            ' Ensure the connection is closed
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        insertData()
        'MsgBox(fg)
    End Sub
End Class