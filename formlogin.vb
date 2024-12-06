Imports MySql.Data.MySqlClient

Public Class formlogin
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Public Sub checkadmin()
        conn.Close()
        Try
            Dim passwordfromdb As String = ""
            If OPENDB() Then
                'conn.Open()
                Dim query As String = "select password from tb_admins where username = @username"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    'conn.Open()
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader()

                        If dtreader.Read Then
                            passwordfromdb = dtreader.GetString("password")
                        Else
                            MsgBox("Invalid username or password.")
                            Return
                        End If
                    End Using

                    ' Checking 
                    If txtPassword.Text = passwordfromdb Then
                        MsgBox("Login successfully!")

                        Me.Dispose()

                        ' Open the next form
                        Dim fee As New formDashboard()
                        fee.Show()
                    Else
                        MsgBox("Invalid username or password.")
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox("check admin: " & ex.Message)
        End Try
    End Sub
    Public Sub CheckUser()
        Try
            ' Initialize variables
            Dim hashedPasswordFromDb As String = ""

            Dim query As String = "SELECT password FROM tb_generatedusernamepassword WHERE username = @username"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)

                ' Execute the query
                Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                    If dtreader.Read() Then
                        hashedPasswordFromDb = dtreader.GetString("password")
                    Else
                        'MsgBox("Invalid username or password.")
                        checkadmin() ' check admin table
                        'conn.Close()
                        Return
                    End If
                End Using
            End Using

            ' Checking 
            If txtPassword.Text = hashedPasswordFromDb Then
                MsgBox("Login successfully!")

                Me.Dispose()

                ' Open the next form
                Dim fee As New formDashboard()
                fee.Show()
            Else
                MsgBox("Invalid username or password.")
            End If

        Catch ex As Exception
            MsgBox("Error during login: " & ex.Message)

        End Try
    End Sub



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            ' Validation
            If Len(Trim(txtUsername.Text)) = 0 Then
                MessageBox.Show("Please Enter Username", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUsername.Focus()
                Exit Sub
            ElseIf Len(Trim(txtPassword.Text)) = 0 Then
                MessageBox.Show("Please Enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPassword.Focus()
                Exit Sub
            ElseIf Len(Trim(cmbusertype.Text)) = 0 Then
                MessageBox.Show("Please Enter User Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Check user credentials
            CheckUser()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub formlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OPENDB()
    End Sub
End Class