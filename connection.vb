Imports MySql.Data.MySqlClient
Module connection
    Public conn As MySqlConnection
    Dim strConn As String
    Dim result As Boolean

    Public usernameClone As String
    Public passwordClone As String

    'Public verifyUsername As String
    'Public verifyPassword As String

    Public Function OPENDB() As Boolean
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection()
            End If

            If conn.State = ConnectionState.Closed Then

                strConn = "server=127.0.0.1;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none"
                conn.ConnectionString = strConn

                conn.Open()

            End If
            Return conn.State = ConnectionState.Open


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return result
    End Function

    Public Sub closeConnection()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
