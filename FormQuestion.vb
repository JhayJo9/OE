Public Class FormQuestion
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
        formDashboard.Show()
    End Sub
End Class