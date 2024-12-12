Public Class FormAssignedStudentsList
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'MsgBox("fgfg")
        With FormAssignedStudent
            .ShowDialog()
        End With
    End Sub


    Private Sub FormAssignedStudentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class