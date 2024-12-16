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

    Private Sub btnAddQuestionList_Click(sender As Object, e As EventArgs) Handles btnRegisterStudents.Click
        With FormRegistrationStudentList
            .TopLevel = False
            panell.Controls.Add(FormRegistrationStudentList)
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

    Private Sub btnExam_Click(sender As Object, e As EventArgs) Handles btnShedule.Click
        With FormAssignScheduleList
            .TopLevel = False
            panell.Controls.Add(FormAssignScheduleList)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With adminMain
            .TopLevel = False
            panell.Controls.Add(adminMain)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub btnAssginStudent_Click(sender As Object, e As EventArgs) Handles btnAssginStudent.Click
        With FormAssignedStudentsList
            .TopLevel = False
            panell.Controls.Add(FormAssignedStudentsList)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub panell_Paint(sender As Object, e As PaintEventArgs) Handles panell.Paint

    End Sub
End Class