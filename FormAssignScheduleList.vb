Imports MySql.Data.MySqlClient

Public Class FormAssignScheduleList
    Private connn As MySqlConnection
    Public connectionStringg As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"


    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        conn.Close()
        With FormAssignSchedule
            .ScheduleListForm = Me ' Set the ScheduleListForm property
            .ShowDialog()
        End With
    End Sub

    Public Sub FetchData()
        Try
            If connn Is Nothing Then
                connn = New MySqlConnection(connectionStringg)
            End If

            If connn.State = ConnectionState.Open Then
                connn.Close()
            End If
            connn.Open()

            dgwScheduleList.Rows.Clear()

            Dim query As String = "SELECT * FROM tb_schedule"
            Using cmd As New MySqlCommand(query, connn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read
                    Dim scheduleId As Integer = reader.GetInt32("scheduleID")
                    Dim courseCode As String = reader.GetString("courseCode")
                    Dim section As String = reader.GetString("section")
                    Dim assessTypeID As Integer = reader.GetInt32("assessTypeID")
                    Dim scheduleDate As DateTime = reader.GetDateTime("scheduleDate")
                    Dim scheduleTime As String = If(Not reader.IsDBNull(reader.GetOrdinal("scheduleTime")),
                                                reader.GetTimeSpan("scheduleTime").ToString("hh\:mm\:ss"), "00:00:00")
                    Dim location As String = reader.GetString("location")

                    dgwScheduleList.Rows.Add(scheduleId, courseCode, section, assessTypeID,
                                         scheduleDate.ToString("yyyy-MM-dd"), scheduleTime, location)
                End While
            End Using
        Catch ex As Exception
            MsgBox("FETCHING SCHEDULE LIST ERROR: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If connn IsNot Nothing AndAlso connn.State = ConnectionState.Open Then
                connn.Close()
            End If
        End Try
    End Sub

    Private Sub FormAssignScheduleList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FetchData()
    End Sub

    Private Sub dgwScheduleList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwScheduleList.CellContentClick
        Dim colName As String = dgwScheduleList.Columns(e.ColumnIndex).Name

        If colName = "colEdit" Then
            Using frm As New FormAssignSchedule
                With frm
                    ' Update the form controls with the selected row's data
                    .btnSave.Text = "UPDATE"
                    .cmbCourse.Text = dgwScheduleList.Rows(e.RowIndex).Cells(1).Value.ToString()
                    .cmbSection.Text = dgwScheduleList.Rows(e.RowIndex).Cells(2).Value.ToString()
                    .cmbAssessmentType.Text = dgwScheduleList.Rows(e.RowIndex).Cells(3).Value.ToString()
                    .dtpScheduleDate.Value = Convert.ToDateTime(dgwScheduleList.Rows(e.RowIndex).Cells(4).Value)

                    Dim scheduleTime As Object = dgwScheduleList.Rows(e.RowIndex).Cells(5).Value
                    If scheduleTime IsNot Nothing AndAlso Not IsDBNull(scheduleTime) Then
                        Dim parsedTime As DateTime
                        If DateTime.TryParse(scheduleTime.ToString(), parsedTime) Then
                            .dtpScheduleTime.Value = parsedTime
                        Else
                            .dtpScheduleTime.Value = DateTime.Now
                        End If
                    Else
                        .dtpScheduleTime.Value = DateTime.Now
                    End If

                    .txtLocation.Text = dgwScheduleList.Rows(e.RowIndex).Cells(6).Value.ToString()

                    ' Show the form as a dialog
                    .ShowDialog()
                End With
            End Using

            ' Refresh the data after editing
            FetchData()
        End If
    End Sub
End Class
