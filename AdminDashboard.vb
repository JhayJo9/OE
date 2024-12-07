Public Class AdminDashboard
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
        Me.Dispose()
        FormCourse.Show()
    End Sub

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        Me.Dispose()
        FormQuestion.Show()
    End Sub

    Private Sub btnAddQuestionList_Click(sender As Object, e As EventArgs) Handles btnAddQuestionList.Click
        Me.Dispose()
        FormEditQuestionList.Show()
    End Sub
End Class