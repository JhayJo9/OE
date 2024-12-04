Public Class verifyStudent
    Private Sub verifyStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblusername.Text = usernameClone
        lblpassword.Text = passwordClone


    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If txtusername.Text = usernameClone And txtpassword.Text = passwordClone Then
            MsgBox("Sucesss")

            Me.Dispose()

            Dim login As New formlogin()
            login.Show()

        End If
    End Sub
End Class