Imports MySql.Data.MySqlClient

Public Class FormRegistrationStudentList
    Private Sub btnAddnew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With FormRegistrationStudent
            .ShowDialog()

        End With
    End Sub

    Public Sub fetchStudentList()
        Try

            DataGridView2.Rows.Clear()
            If OPENDB() Then
                Dim st As String = "SELECT * from tb_student"
                Using cmd As New MySqlCommand(st, conn)
                    Try
                        Using dtreader As MySqlDataReader = cmd.ExecuteReader

                            While dtreader.Read
                                Dim studentID As Integer = dtreader.GetInt32("studentID")
                                Dim Lastname As String = dtreader.GetString("Lastname")
                                Dim Firstname As String = dtreader.GetString("Firstname")
                                Dim Middlename As String = dtreader.GetString("Middlename")
                                Dim DateOfBirth As Date = dtreader.GetDateTime("DateOfBirth")
                                Dim gender As String = dtreader.GetString("Gender")
                                Dim email As String = dtreader.GetString("Email")
                                Dim contactNumber As String = dtreader.GetString("ContactNumber")

                                DataGridView2.Rows.Add(studentID, Lastname, Firstname, Middlename, DateOfBirth.ToString("yyyy-MM-dd"), gender, email, contactNumber)

                            End While
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormRegistrationStudentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchStudentList()
    End Sub
End Class