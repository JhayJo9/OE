Public Class FormAssignedStudentsList
    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With FormAssignedStudents
            .ShowDialog()
        End With
    End Sub
End Class