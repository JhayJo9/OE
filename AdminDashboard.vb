Public Class AdminDashboard
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
        With FormCourseList
            .TopLevel = False
            panell.Controls.Add(FormCourseList)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        With FormQuestionList
            .TopLevel = False
            panell.Controls.Add(FormQuestionList)
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub btnAddQuestionList_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        With users
            .TopLevel = False
            panell.Controls.Add(users)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnSection.Click
        With FormSectionList
            .TopLevel = False
            panell.Controls.Add(FormSectionList)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnExam_Click(sender As Object, e As EventArgs) Handles btnExam.Click
        With FormExamList
            .TopLevel = False
            panell.Controls.Add(FormExamList)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class