Imports MySql.Data.MySqlClient

Public Class formlogin
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Form1.Show()
    End Sub
    Public Sub CheckUser()
        Try
            ' Initialize variables
            Dim passwordfromdb As String = ""
            Dim role As String = ""

            Dim query As String = "SELECT password, role FROM tb_generatedusernamepassword WHERE username = @username"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)

                ' Execute the query
                Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                    If dtreader.Read() Then
                        passwordfromdb = dtreader.GetString("password")
                        role = dtreader.GetString("role")
                    Else

                        Return
                    End If
                End Using
            End Using

            ' Checking 
            If txtPassword.Text = passwordfromdb And role = "admin" Then
                MsgBox("Login successfully!")
                Me.Dispose()
                ' Open the next form
                Dim fee As New AdminDashboard()
                fee.Show()
            ElseIf txtPassword.Text = passwordfromdb And role = "Student" Then
                MsgBox("Login successfully!")
                Me.Dispose()
                ' Open the next form
                Dim fee As New StudentDashboard()
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