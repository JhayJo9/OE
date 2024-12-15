Imports System.Diagnostics.Eventing
Imports System.Net.Http.Headers

Public Class StudentDashboard

    Private _studentId As Integer  ' Add this field to store the ID

    Public Property StudentId As Integer
        Get
            Return _studentId
        End Get
        Set(value As Integer)
            _studentId = value
            lblUser.Text = value.ToString()  ' Update the label when ID is set
        End Set
    End Property
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

    Private Sub StudentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("StudentId in Dashboard: " & UserSession.StudentId.ToString()) ' Debug message
        lblUser.Text = UserSession.StudentId.ToString()
    End Sub
End Class