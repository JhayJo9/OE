﻿Imports MySql.Data.MySqlClient
Imports MySql.Data
Module connection
    Public conn As MySqlConnection
    Public _STUDENTD As Integer
    Public _STUDENTNAME As String
    Dim strConn As String
    Dim result As Boolean

    Public usernameClone As String
    Public passwordClone As String

    'Public verifyUsername As String
    'Public verifyPassword As String

    'Private connection As MySqlConnection
    'Private connectionString As String = "Server=localhost;Database=exam;Uid=Yohan;Pwd=Yohan;"

    ' Public connectionStringFormS As New MySqlConnection(connectionString)
    Public Function OPENDB() As Boolean
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection()
            End If

            If conn.State = ConnectionState.Closed Then
                strConn = "server=127.0.0.1;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"
                conn.ConnectionString = strConn
                conn.Open()
            End If

            result = conn.State = ConnectionState.Open
        Catch ex As Exception
            MsgBox(ex.Message)
            result = False
        End Try
        Return result
    End Function

    Public Sub closeConnection()
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
