Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormSection

    Public Sub fetchCourse()
        Try
            If OPENDB() Then
                Dim course As String = "SELECT courseCode FROM tb_course"
                Using cmd As New MySqlCommand(course, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader
                        While dtreader.Read
                            Dim courseCode As String = dtreader.GetString("courseCode")
                            cmbCourse.Items.Add(courseCode)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("Fetch Course: " & ex.Message)
        End Try
    End Sub

    Public Sub updateSection()
        Try
            If OPENDB() Then
                Dim upsec As String = "UPDATE tb_section SET section=@section, courseCode=@courseCode, scheduleDate=@scheduleDate,scheduleTime=@scheduleTime, location=@location  WHERE sectionID = @sectionID"
                Using cmd As New MySqlCommand(upsec, conn)
                    cmd.Parameters.AddWithValue("@section", txtSection.Text)
                    cmd.Parameters.AddWithValue("@courseCode", cmbCourse.Text)
                    cmd.Parameters.AddWithValue("@sectionID", FormSectionList.DataGridView1.CurrentRow.Cells(0).Value.ToString)
                    cmd.Parameters.AddWithValue("@scheduleDate", dobSection.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@scheduleTime", dtpTimer.Value.ToString("hh\\:mm\\:ss"))
                    cmd.Parameters.AddWithValue("@location", txtRm.Text)
                    cmd.ExecuteNonQuery()
                End Using

                txtSection.Clear()
                'cmbCourse.SelectedIndex = -1
                MsgBox("Section Updated")
            End If
        Catch ex As Exception
            MsgBox("Update Section: " & ex.Message)
        End Try
    End Sub

    Public Sub insertSectionAndCourse()
        Try
            If OPENDB() Then
                Dim stt As String = "INSERT INTO tb_section (section, CourseCode, scheduleDate,scheduleTime, location) VALUES (@section, @CourseCode,@scheduleDate ,@scheduleTime, @location)"
                Using cmd As New MySqlCommand(stt, conn)
                    cmd.Parameters.AddWithValue("@section", txtSection.Text)
                    cmd.Parameters.AddWithValue("@CourseCode", cmbCourse.Text)
                    cmd.Parameters.AddWithValue("@scheduleDate", dobSection.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@scheduleTime", dtpTimer.Value.ToString("hh:mm:ss tt"))
                    cmd.Parameters.AddWithValue("@location", txtRm.Text)
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Section Added")
            End If
        Catch ex As Exception
            MsgBox("Insert Section: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub FormSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourse()

        ' In your form load or designer
        dtpTimer.Format = DateTimePickerFormat.Custom
        dtpTimer.CustomFormat = "hh:mm:ss tt"
    End Sub

    Private Sub btnAddSection_Click(sender As Object, e As EventArgs) Handles btnAddSection.Click
        If txtSection.Text = "" Or cmbCourse.SelectedIndex = -1 Then
            MsgBox("Please fill up all fields")
            Exit Sub
        ElseIf MsgBox("Add Section?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            insertSectionAndCourse()

            With FormSectionList
                .fetchSection()
            End With
        Else
            txtSection.Clear()
            cmbCourse.SelectedIndex = -1
        End If


        If btnAddSection.Text = "UPDATE" Then
            updateSection()
            With FormSectionList
                .fetchSection()
            End With
            'ElseIf btnAddSection.Text = "SAVE" Then
            '    insertSectionAndCourse()
        End If

    End Sub

    Private Sub cmbCourse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCourse.KeyPress
        e.Handled = True
    End Sub
End Class