Imports MySql.Data.MySqlClient

Public Class formlogin
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Form1.Show()
    End Sub


    Public Sub CheckUser()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try

            conn.Open()

            Dim query As String = "SELECT password, role, studentID FROM tb_generatedusernamepassword WHERE username = @username"
            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())

                Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                    If dtreader.Read() Then
                        Dim passwordHash As String = dtreader.GetString("password")
                        Dim role As String = dtreader.GetString("role")

                        ' Use a proper password verification method
                        If txtPassword.Text = passwordHash Then
                            Select Case role.ToLower()
                                Case "admin"
                                    OpenNewForm(New AdminDashboard())
                                Case "student"
                                    Dim dashboard As New StudentDashboard()
                                    dashboard.StudentId = dtreader.GetInt32("studentID")
                                    OpenNewForm(dashboard)
                                    MsgBox(dtreader.GetInt32("studentID")) ' 1
                                    Debug.WriteLine(_STUDENTD)
                                Case Else
                                    ShowError("Invalid user role")
                            End Select
                        Else
                            ShowError("Invalid credentials")
                        End If
                    Else
                        ShowError("Invalid credentials")
                    End If
                End Using
            End Using

        Catch ex As MySqlException
            LogError(ex)
            ShowError("Database error occurred. Please try again later.")
        Catch ex As Exception
            MsgBox("CHECK USER: " & ex.Message)
        End Try
    End Sub

    Private Sub OpenNewForm(form As Form)
        MsgBox("Login successful!")
        Me.Dispose()
        form.Show()
    End Sub

    Private Sub ShowError(message As String)
        MsgBox(message)
    End Sub

    Private Function VerifyPassword(inputPassword As String, storedHash As String) As Boolean
        ' Implement proper password verification here
        ' Example using BCrypt:
        ' Return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash)

        ' This is temporary and should be replaced with proper password hashing
        Return inputPassword = storedHash
    End Function

    Private Sub LogError(ex As Exception)
        ' Implement proper error logging here
        ' Example:
        ' Logger.LogError($"Login error: {ex.Message}", ex)
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class