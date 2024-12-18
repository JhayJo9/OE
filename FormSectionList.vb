Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.Cms

Public Class FormSectionList

    'Dim scheduleTime As TimeSpan = dtpTimer.Value.TimeOfDay
    Public Sub fetchSection()
        Try
            DataGridView1.Rows.Clear()
            If OPENDB() Then
                Dim st As String = "SELECT * FROM tb_section"
                Using cmd As New MySqlCommand(st, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader
                        While dtreader.Read
                            Dim id As Integer = dtreader.GetInt32("sectionID")
                            Dim section As String = dtreader.GetString("section")
                            Dim courseCode As String = dtreader.GetString("courseCode")

                            ' Handle the date more safely
                            'Dim shed As DateTime = dtreader.GetDateTime("scheduleDate")
                            ' Alternative TimeSpan handling
                            'Dim scheduleTime As String
                            'If Not dtreader.IsDBNull(dtreader.GetOrdinal("scheduleTime")) Then
                            '    Dim timeSpan As TimeSpan = dtreader.GetTimeSpan("scheduleTime")
                            '    scheduleTime = timeSpan.ToString("hh\:mm\:ss")
                            'Else
                            '    scheduleTime = "00:00:00"
                            'End If

                            'Dim room As String = dtreader.GetString("location")

                            ' Add to DataGridView
                            DataGridView1.Rows.Add(id, section, courseCode)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("Fetch Section: " & ex.Message)
        End Try
    End Sub

    Public Sub deleteSection()
        Try
            If OPENDB() Then
                Dim st As String = "DELETE FROM tb_section WHERE sectionID = @sectionID"
                Using cmd As New MySqlCommand(st, conn)
                    cmd.Parameters.AddWithValue("@sectionID", DataGridView1.CurrentRow.Cells(0).Value.ToString)
                    cmd.ExecuteNonQuery()
                End Using
                MsgBox("Section Deleted")
            End If
        Catch ex As Exception
            MsgBox("Delete Section: " & ex.Message)
        End Try
    End Sub



    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click


        With FormSection
            .ShowDialog()
        End With
    End Sub

    Private Sub FormSectionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchSection()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name

        If colName = "colDelete" Then
            If MsgBox("Delete Section?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                deleteSection()
                fetchSection()
            End If
        ElseIf colName = "colEdit" Then
            With FormSection
                .btnAddSection.Text = "UPDATE"
                .txtSection.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .cmbCourse.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .dobSection.Value = DataGridView1.CurrentRow.Cells(3).Value

                ' Fix for the time value
                Dim scheduleTime As String = DataGridView1.CurrentRow.Cells(4).Value.ToString()
                If Not String.IsNullOrEmpty(scheduleTime) Then
                    ' Combine today's date with the time value
                    Dim timeOnly As TimeSpan
                    If TimeSpan.TryParse(scheduleTime, timeOnly) Then
                        .dtpTimer.Value = DateTime.Today.Add(timeOnly)
                    End If
                Else
                    ' Set to current time if no value
                    .dtpTimer.Value = DateTime.Now
                End If

                .txtRm.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()

                .btnAddSection.Enabled = True
                .ShowDialog()
            End With
        End If


    End Sub
End Class