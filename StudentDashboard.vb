Imports System.Net.Http.Headers

Public Class StudentDashboard
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

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExam_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'loseConnection()

        Me.Close()
        formlogin.Show()
    End Sub
End Class