Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Security.Cryptography.X509Certificates

Public Class FormAssignedStudent

    ' Existing variables...
    Private connnn As MySqlConnection
    Public connectionString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"
    Private studentDictionary As New Dictionary(Of String, Integer)

    Dim studentSectionCode As String = ""
    Dim studentid As Integer = 0
    Dim CourseID As Integer = 0
    Dim SectionID As Integer = 0
    Dim assessTypeID As Integer = 0
    Dim questionIDs As New List(Of Integer)

    Private Sub FetchSections()
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection(connectionString)
            End If

            If conn.State = ConnectionState.Open Then
                conn.Close()
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

    Public Sub Fetch_Student()
        txtStudentID.Clear()
        cmbStudentName.Items.Clear()
        studentDictionary.Clear()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            If OPENDB() Then
                Dim st As String = "SELECT DISTINCT studentNo, studentID, LastName, FirstName, MiddleName " &
                                   "FROM tb_student ORDER BY LastName, FirstName"
                Dim cmd As New MySqlCommand(st, conn)
                Dim readerstudent As MySqlDataReader = cmd.ExecuteReader

                While readerstudent.Read()
                    Try
                        Dim studentNo As String = readerstudent.GetString("studentNo")
                        Dim studentID As Integer = readerstudent.GetInt32("studentID")

                        Dim lastName As String = readerstudent.GetString("LastName")
                        Dim firstName As String = readerstudent.GetString("FirstName")
                        Dim middleName As String = readerstudent.GetString("MiddleName")
                        Dim displayName As String = studentNo & ": " & lastName & ", " & firstName

                        If Not studentDictionary.ContainsKey(displayName) Then
                            cmbStudentName.Items.Add(displayName)
                            studentDictionary.Add(displayName, studentID)
                        End If

                    Catch ex As Exception
                        Debug.WriteLine($"Error processing student record: {ex.Message}")
                    End Try
                End While
                readerstudent.Close()
            End If
        Catch ex As Exception
            MsgBox("SELECT STUDENT ERROR: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Fetch_AsessementType()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            Dim type As String = "SELECT assessTypeID, AssessmentType FROM tb_assessmenttype"
            Dim cmd As New MySqlCommand(type, conn)
            Dim readerType As MySqlDataReader = cmd.ExecuteReader

            While readerType.Read()
                assessTypeID = readerType.GetInt32("assessTypeID")
                Dim assessmentType As String = readerType.GetString("AssessmentType")
                cmbAssessmentType.Items.Add(assessmentType)
            End While
        Catch ex As Exception
            MsgBox("ASSESMENT TYPE: " & ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub FetchSectionCode(studentID As Integer)
        Dim query As String = "SELECT 
                                s.studentID,
                                sec.section,
                                sec.sectionID  
                            FROM 
                                tb_student s
                            JOIN 
                                tb_assignedsection asg ON s.studentID = asg.studentID
                            JOIN 
                                tb_section sec ON asg.sectionID = sec.sectionID
                            WHERE 
                                s.studentID = @studentID;"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@studentID", CInt(studentID))
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Dim sectionCode As String = reader("section").ToString()
                            SectionID = reader.GetInt32("sectionID")
                            Fetch_Course(sectionCode)
                        Else
                            MessageBox.Show("No section found for the given student ID.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("FETCH SECTION: " & ex.Message)
        End Try
    End Sub

    Public Sub Fetch_Course(secCode As String)
        cmbCourseCode.Items.Clear()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            Dim trimSec As String = ""
            If secCode.Contains("BSCS") Then
                trimSec = secCode.Substring(2, 2)
            ElseIf secCode.Contains("BSIT") Then
                trimSec = secCode.Substring(2, 1)
            End If

            conn.Open()

            Dim fetch As String = "SELECT courseID, CourseCode FROM tb_course WHERE CourseCode LIKE @prefix"
            Using cmd As New MySqlCommand(fetch, conn)
                cmd.Parameters.AddWithValue("@prefix", trimSec & "%")
                Using readerCourse As MySqlDataReader = cmd.ExecuteReader()
                    If readerCourse.HasRows Then
                        While readerCourse.Read()
                            Dim courseCode As String = readerCourse.GetString("CourseCode")
                            CourseID = readerCourse.GetInt32("courseID")
                            cmbCourseCode.Items.Add(courseCode)
                        End While
                    Else
                        MessageBox.Show("Fetch Course: No courses found for the given section code.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Fetch_Questions()
        questionIDs.Clear()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            Dim query As String = "SELECT q.questionID FROM tb_questionanswer q 
                               JOIN tb_coursequestion cq ON q.questionID = cq.questionID 
                               WHERE cq.courseID = @courseID AND q.assessmentTypeID = @assessmentTypeID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@courseID", CourseID)
            cmd.Parameters.AddWithValue("@assessmentTypeID", assessTypeID)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        questionIDs.Add(reader.GetInt32("questionID"))
                    End While
                Else
                    MsgBox("No questions found for the given Course and AssessmentType.")
                End If
            End Using

        Catch ex As Exception
            MsgBox("FETCH QUESTIONS: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Assign_Questions_To_Student()
        If studentid = 0 OrElse CourseID = 0 OrElse SectionID = 0 OrElse assessTypeID = 0 OrElse questionIDs.Count = 0 Then
            MessageBox.Show("One or more required IDs are not set or no questions found. Please ensure all fields are selected and questions are available.")
            Return
        End If

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            For Each questionID In questionIDs
                Dim insert As String = "INSERT INTO tb_student_question_assignment (studentID, questionID, courseID, sectionID, assessTypeID) VALUES(@studentID, @questionID, @courseID, @sectionID, @assessTypeID)"
                Dim cmd As New MySqlCommand(insert, conn)
                cmd.Parameters.AddWithValue("@studentID", studentid)
                cmd.Parameters.AddWithValue("@questionID", questionID)
                cmd.Parameters.AddWithValue("@courseID", CourseID)
                cmd.Parameters.AddWithValue("@sectionID", SectionID)
                cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)
                cmd.ExecuteNonQuery()
            Next
            MsgBox("Questions Assigned Successfully to the Student")
        Catch ex As Exception
            MsgBox("ASSIGN QUESTIONS: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub FetchScheduleDetails(courseCode As String, section As String, assessTypeID As Integer)
        Dim query As String = "SELECT scheduleDate, scheduleTime, location FROM tb_schedule WHERE courseCode = @courseCode AND section = @section AND assessTypeID = @assessTypeID"
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@courseCode", courseCode)
                    command.Parameters.AddWithValue("@section", section)
                    command.Parameters.AddWithValue("@assessTypeID", assessTypeID)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            dtpScheduleDate.Value = Convert.ToDateTime(reader("scheduleDate"))
                            Dim scheduleTime As TimeSpan = TimeSpan.Parse(reader("scheduleTime").ToString())
                            dtpScheduleTime.Value = DateTime.Today.Add(scheduleTime)
                            txtLocation.Text = reader("location").ToString()
                        Else
                            MessageBox.Show("No schedule found for the given details.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Fetch Schedule Details Error: " & ex.Message)
        End Try
    End Sub

    Public Sub insert_Data()
        If studentid = 0 OrElse CourseID = 0 OrElse SectionID = 0 OrElse assessTypeID = 0 Then
            MessageBox.Show("One or more required IDs are not set. Please ensure all fields are selected.")
            Return
        End If

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()

            Dim insert As String = "INSERT INTO tb_assignedstudents VALUES  (null, @studentID, @courseCode, @sectionCode, @assessTypeID, @scheduleDate, @scheduleTime, @location)"
            Using cmd As New MySqlCommand(insert, conn)
                cmd.Parameters.AddWithValue("@studentID", CInt(studentid))
                cmd.Parameters.AddWithValue("@courseCode", CInt(CourseID))
                cmd.Parameters.AddWithValue("@sectionCode", CInt(SectionID))
                cmd.Parameters.AddWithValue("@assessTypeID", CInt(assessTypeID))
                cmd.Parameters.AddWithValue("@scheduleDate", dtpScheduleDate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@scheduleTime", dtpScheduleTime.Value.ToString("HH:mm:ss"))
                cmd.Parameters.AddWithValue("@location", txtLocation.Text)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Student Assigned Successfully")

            With FormAssignedStudentsList
                .Fetch_Data()
            End With

            conn.Close()
        Catch ex As Exception
            MsgBox("INSERT DATA: " & ex.Message)
        End Try
    End Sub

    Private Sub FormAssignedStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_Student()
        Fetch_AsessementType()
        FetchSections()
        cmbStudentName_SelectedIndexChanged(cmbStudentName, EventArgs.Empty)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub cmbCourseCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourseCode.SelectedIndexChanged
        If cmbCourseCode.SelectedIndex <> -1 AndAlso cmbSection.SelectedIndex <> -1 AndAlso cmbAssessmentType.SelectedIndex <> -1 Then
            FetchScheduleDetails(cmbCourseCode.SelectedItem.ToString(), cmbSection.SelectedItem.ToString(), assessTypeID)
        End If
    End Sub

    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        If cmbCourseCode.SelectedIndex <> -1 AndAlso cmbSection.SelectedIndex <> -1 AndAlso cmbAssessmentType.SelectedIndex <> -1 Then
            FetchScheduleDetails(cmbCourseCode.SelectedItem.ToString(), cmbSection.SelectedItem.ToString(), assessTypeID)
        End If
    End Sub

    Private Sub cmbAssessmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssessmentType.SelectedIndexChanged
        If cmbCourseCode.SelectedIndex <> -1 AndAlso cmbSection.SelectedIndex <> -1 AndAlso cmbAssessmentType.SelectedIndex <> -1 Then
            FetchScheduleDetails(cmbCourseCode.SelectedItem.ToString(), cmbSection.SelectedItem.ToString(), assessTypeID)
        End If

        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            Dim query As String = "SELECT assessTypeID FROM tb_assessmenttype WHERE AssessmentType = @type"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@type", cmbAssessmentType.SelectedItem.ToString())
                assessTypeID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            MsgBox("Error getting assessment type ID: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmbStudentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStudentName.SelectedIndexChanged
        FetchSectionID()
    End Sub

    Public Sub FetchSectionID()
        cmbCourseCode.Text = ""

        If cmbStudentName.SelectedIndex <> -1 Then
            Dim selectedName As String = cmbStudentName.SelectedItem.ToString()

            If studentDictionary.ContainsKey(selectedName) Then
                studentid = studentDictionary(selectedName)
                txtStudentID.Text = studentid.ToString()
                FetchSectionCode(studentid)
            Else
                MsgBox("Student not found in dictionary.")
            End If
        End If
    End Sub

    Public Sub Update_Data()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Try
            conn.Open()
            Dim ud As String = "UPDATE tb_assignedstudents SET courseID = @courseID, sectionID = @sectionID, assessTypeID = @assessTypeID, scheduleDate = @scheduleDate, scheduleTime = @scheduleTime, location = @location WHERE studentID = @studentID"
            Dim cmd As New MySqlCommand(ud, conn)
            cmd.Parameters.AddWithValue("@courseID", CourseID)
            cmd.Parameters.AddWithValue("@sectionID", SectionID)
            cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)
            cmd.Parameters.AddWithValue("@scheduleDate", dtpScheduleDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@scheduleTime", dtpScheduleTime.Value.ToString("HH:mm:ss"))
            cmd.Parameters.AddWithValue("@location", txtLocation.Text)
            cmd.Parameters.AddWithValue("@studentID", studentid)
            cmd.ExecuteNonQuery()

            With FormAssignedStudentsList
                .Fetch_Data()
            End With
            MsgBox("Student Updated Successfully")
        Catch ex As Exception
            MsgBox("UPDATING DATA: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbAssessmentType.KeyPress, cmbCourseCode.KeyPress, cmbStudentName.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Fetch_Questions()

        Debug.WriteLine("studentid: " & studentid)
        Debug.WriteLine("CourseID: " & CourseID)
        Debug.WriteLine("SectionID: " & SectionID)
        Debug.WriteLine("assessTypeID: " & assessTypeID)
        Debug.WriteLine("questionIDs count: " & questionIDs.Count)

        ' MsgBox("VALUES: " & studentid & " " & CourseID & " " & SectionID & " " & assessTypeID & " " & questionIDs.Count)
        If studentid = 0 OrElse CourseID = 0 OrElse SectionID = 0 OrElse assessTypeID = 0 OrElse questionIDs.Count = 0 Then
            MessageBox.Show("One or more required IDs are not set or no questions found. Please ensure all fields are selected and questions are available.")
            Return
        End If

        Try
            If btnSave.Text = "SAVE" Then
                insert_Data()
            ElseIf btnSave.Text = "UPDATE" Then
                Update_Data()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

