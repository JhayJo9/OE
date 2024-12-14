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


End Class