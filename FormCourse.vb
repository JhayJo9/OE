Public Class FormCourse
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
        formDashboard.Show()
    End Sub
End Class