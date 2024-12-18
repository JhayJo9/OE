Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
    End Sub

    Private Sub picbxLogin_Click(sender As Object, e As EventArgs) Handles picbxLogin.Click
        Me.Hide()
        formlogin.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        formRegister.Show()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        Me.Hide()
        formFeeDetail.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Me.Hide()
        'ad.Show()
    End Sub
End Class
