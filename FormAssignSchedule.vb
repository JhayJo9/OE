Imports MySql.Data.MySqlClient

Public Class FormAssignSchedule
    Private conn As MySqlConnection
    Public connectionString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"

    Dim _ASSESSMENTTYPEID As Integer



    Public Property ScheduleListForm As FormAssignScheduleList

    Private Sub FormAssignSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourses()
        fetchAssessmentTypes()
        fetchSections()
    End Sub

    Public Sub ClearFields()
        cmbCourse.SelectedIndex = -1
        cmbSection.SelectedIndex = -1
        cmbAssessmentType.SelectedIndex = -1
        dtpScheduleDate.Value = DateTime.Now
        dtpScheduleTime.Value = DateTime.Now
        txtLocation.Text = ""
    End Sub

    Private Sub fetchCourses()
        Try

            cmbCourse.Items.Clear()
            If conn Is Nothing Then
                conn = New MySqlConnection(connectionString)
            End If
            conn.Open()
            Dim query As String = "SELECT courseCode FROM tb_course"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        cmbCourse.Items.Add(reader.GetString("courseCode"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Fetch Courses Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub fetchAssessmentTypes()
        Try
            cmbAssessmentType.Items.Clear()
            If conn Is Nothing Then
                conn = New MySqlConnection(connectionString)
            End If
            conn.Open()
            Dim query As String = "SELECT assessTypeID, AssessmentType FROM tb_assessmenttype"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim dt As New DataTable()
                    dt.Load(reader)
                    cmbAssessmentType.DataSource = dt
                    cmbAssessmentType.DisplayMember = "AssessmentType"
                    cmbAssessmentType.ValueMember = "assessTypeID"
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Fetch Assessment Types Error: " & ex.Message)
            Debug.WriteLine("Fetch Assessment Types Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub fetchSections()
        Try
            cmbSection.Items.Clear()

            If conn Is Nothing Then
                conn = New MySqlConnection(connectionString)
            End If
            conn.Open()
            Dim query As String = "SELECT section FROM tb_section"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        cmbSection.Items.Add(reader.GetString("section"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Fetch Sections Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub InsertData()
        Debug.WriteLine(cmbAssessmentType.SelectedValue)
        MsgBox(cmbAssessmentType.SelectedValue)

        _ASSESSMENTTYPEID = cmbAssessmentType.SelectedValue
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection(connectionString)
            End If
            conn.Open()

            Dim query As String = "INSERT INTO tb_schedule VALUES (null, @courseCode, @section, @assessTypeID, @scheduleDate, @scheduleTime, @location)"
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@courseCode", cmbCourse.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@section", cmbSection.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@assessTypeID", cmbAssessmentType.SelectedValue)
                cmd.Parameters.AddWithValue("@scheduleDate", dtpScheduleDate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@scheduleTime", dtpScheduleTime.Value.ToString("hh\:mm\:ss"))
                cmd.Parameters.AddWithValue("@location", txtLocation.Text)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Schedule Assigned Successfully")
            ClearFields()

            ' Check if ScheduleListForm is not Nothing and call FetchData
            If ScheduleListForm IsNot Nothing Then
                ScheduleListForm.FetchData()
                MsgBox("Data refreshed successfully.")
            Else
                MsgBox("ScheduleListForm is not set.")
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox("Save Schedule Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        InsertData()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

End Class