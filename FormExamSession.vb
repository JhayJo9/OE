Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormExamSession

    Public Sub Fetch_Data()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            Dim q As String = "select 
                                q.questionID, 
                                q.Question, 
                                q.OptionA, 
                                q.OptionB, 
                                q.OptionC, 
                                q.OptionD, 
                                q.CorrectAnswer
                                from tb_questionanswer q"
            Dim cmd As New MySqlCommand(q, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtQuestions.Text = reader("Question")
                rbA.Text = reader("OptionA")
                rbB.Text = reader("OptionB")
                rbC.Text = reader("OptionC")
                rbD.Text = reader("OptionD")
            End While
        Catch ex As Exception
            MsgBox("FETCHING DATA: " & ex.Message)
        End Try
    End Sub
    Private Sub FormExamSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_Data()
    End Sub
End Class