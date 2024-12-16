Public Class StudentDashboard

    Private Sub StudentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = UserSession.StudentId.ToString()
    End Sub

    Private Sub btnSection_Click(sender As Object, e As EventArgs) Handles btnSection.Click
        With FormExamListForStudent
            .TopLevel = False
            panelStudent.Controls.Add(FormExamListForStudent)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnResults_Click(sender As Object, e As EventArgs) Handles btnResults.Click
        With FormStudentResults
            .TopLevel = False
            panelStudent.Controls.Add(FormStudentResults)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        formlogin.Show()
    End Sub
End Class