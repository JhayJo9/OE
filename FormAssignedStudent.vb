﻿Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Security.Cryptography.X509Certificates

Public Class FormAssignedStudent


    Private connnn As MySqlConnection
    Public connectionString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"
    Private studentDictionary As New Dictionary(Of String, Integer)

    Dim studentSectionCode As String = ""
    Dim studentid As Integer = 0
    Dim CourseID As Integer = 0
    Dim SectionID As Integer = 0
    Dim assessTypeID As Integer = 0
    Dim questionIDs As New List(Of Integer)
    Public Sub Fetch_Student()
        txtSectionCode.Clear()
        txtStudentID.Clear()
        cmbStudentName.Items.Clear()
        studentDictionary.Clear() ' Clear the dictionary

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Try
            conn.Open()
            If OPENDB() Then
                ' Modified query to get needed fields
                Dim st As String = "SELECT DISTINCT studentNo, studentID, LastName, FirstName, MiddleName " &
                             "FROM tb_student ORDER BY LastName, FirstName"
                Dim cmd As New MySqlCommand(st, conn)
                Dim readerstudent As MySqlDataReader = cmd.ExecuteReader

                While readerstudent.Read()
                    Try
                        Dim studentNo As String = readerstudent.GetString("studentNo")
                        Dim studentID As Integer = readerstudent.GetInt32("studentID")

                        ' Build the student name with a unique identifier
                        Dim lastName As String = readerstudent.GetString("LastName")
                        Dim firstName As String = readerstudent.GetString("FirstName")
                        Dim middleName As String = readerstudent.GetString("MiddleName")
                        Dim displayName As String = studentNo & ": " & lastName & ", " & firstName

                        ' Check if the key already exists before adding
                        If Not studentDictionary.ContainsKey(displayName) Then
                            cmbStudentName.Items.Add(displayName)
                            studentDictionary.Add(displayName, studentID)
                        End If

                    Catch ex As Exception
                        ' Log the error but continue with next record
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
                            ' Set the sectionID here
                            SectionID = reader.GetInt32("sectionID")
                            txtSectionCode.Text = sectionCode

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
            MsgBox(trimSec)
            'Using conn As New MySqlConnection(Your_Connection_String)
            ' Open the connection
            conn.Open()

            ' Query to fetch course codes matching the section code parameter
            Dim fetch As String = "SELECT courseID, CourseCode FROM tb_course WHERE CourseCode LIKE @prefix "

            Using cmd As New MySqlCommand(fetch, conn)
                ' Add parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@prefix", trimSec & "%")
                ' cmd.Parameters.AddWithValue("@prefix", "I%")

                ' Execute reader to fetch data
                Using readerCourse As MySqlDataReader = cmd.ExecuteReader()
                    If readerCourse.HasRows Then
                        While readerCourse.Read()
                            Dim courseCode As String = readerCourse.GetString("CourseCode")
                            CourseID = readerCourse.GetInt32("courseID")
                            cmbCourseCode.Items.Add(courseCode)
                        End While
                    Else
                        MessageBox.Show("Fetch_Course: No courses found for the given section code.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using ' reader will automatically close
            End Using
            'End Using ' connection will automatically close

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
                        MsgBox(questionIDs.Count)
                    End While
                Else
                    MsgBox("No questions found for the given CourseID and AssessmentTypeID.")
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

    Public Sub insert_Data()
        If studentid = 0 OrElse CourseID = 0 OrElse SectionID = 0 OrElse assessTypeID = 0 Then
            MessageBox.Show("One or more required IDs are not set. Please ensure all fields are selected.")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                MsgBox("STUDENT ID: " & studentid & " COURSE ID: " & CourseID & " SECTION ID: " & SectionID & " ASSESSMENT TYPE ID: " & assessTypeID)

                Dim insert As String = "INSERT INTO tb_assignedstudents VALUES(null, @studentID, @courseID, @sectionID, @assessTypeID)"
                Dim cmd As New MySqlCommand(insert, conn)
                cmd.Parameters.AddWithValue("@studentID", CInt(studentid))
                cmd.Parameters.AddWithValue("@courseID", CInt(CourseID))
                cmd.Parameters.AddWithValue("@sectionID", CInt(SectionID))
                cmd.Parameters.AddWithValue("@assessTypeID", CInt(assessTypeID))


                cmd.ExecuteNonQuery()
                MsgBox("Student Assigned Successfully")

                With FormAssignedStudentsList
                    .Fetch_Data()
                End With
            End Using
        Catch ex As Exception
            MsgBox("INSERT DATA: " & ex.Message)
        End Try
    End Sub

    Private Sub FormAssignedStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fetch_Student()
        Fetch_AsessementType()
        cmbStudentName_SelectedIndexChanged(cmbStudentName, EventArgs.Empty)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
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
                ' Get just the student number for display
                txtStudentID.Text = studentid.ToString()
                ' Fetch the section code for this student
                'Fetch_SectionCode(studentid)
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
            MsgBox("STUDENT ID: " & studentid & " COURSE ID: " & CourseID & " SECTION ID: " & SectionID & " ASSESSMENT TYPE ID: " & assessTypeID)
            Dim ud As String = "UPDATE tb_assignedstudents SET courseID = @courseID, sectionID = @sectionID, assessTypeID = @assessTypeID WHERE studentID = @studentID"
            Dim cmd As New MySqlCommand(ud, conn)
            cmd.Parameters.AddWithValue("@courseID", CourseID)
            cmd.Parameters.AddWithValue("@sectionID", SectionID)
            cmd.Parameters.AddWithValue("@assessTypeID", assessTypeID)
            cmd.Parameters.AddWithValue("@studentID", studentid)
            cmd.ExecuteNonQuery()

            cmd.ExecuteNonQuery()
            With FormAssignedStudentsList
                .Fetch_Data()
                MsgBox("fgdfg")
            End With
            MsgBox("Student Updated Successfully")
        Catch ex As Exception
            MsgBox("UPDATING DATE: " & ex.Message)
        End Try
    End Sub
    Private Sub ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbAssessmentType.KeyPress, cmbCourseCode.KeyPress, cmbStudentName.KeyPress
        e.Handled = True
    End Sub

    ' In FormAssignedStudent's save button click event
    ' In FormAssignedStudent's save button click event
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Call Fetch_Questions to ensure questionIDs are populated
        Fetch_Questions()

        ' Debugging information
        Debug.WriteLine("studentid: " & studentid)
        Debug.WriteLine("CourseID: " & CourseID)
        Debug.WriteLine("SectionID: " & SectionID)
        Debug.WriteLine("assessTypeID: " & assessTypeID)
        Debug.WriteLine("questionIDs count: " & questionIDs.Count)

        MsgBox("VALUES: " & studentid & " " & CourseID & " " & SectionID & " " & assessTypeID & " " & questionIDs.Count)
        ' Check if all required IDs are set and questions are available
        If studentid = 0 OrElse CourseID = 0 OrElse SectionID = 0 OrElse assessTypeID = 0 OrElse questionIDs.Count = 0 Then
            MessageBox.Show("One or more required IDs are not set or no questions found. Please ensure all fields are selected and questions are available.")
            Return
        End If

        Try
            If btnSave.Text = "SAVE" Then
                Assign_Questions_To_Student()
                insert_Data()
            ElseIf btnSave.Text = "UPDATE" Then
                Update_Data()
            End If

            Me.DialogResult = DialogResult.OK ' Add this line
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cmbAssessmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssessmentType.SelectedIndexChanged
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

    Private Sub txtSectionCode_TextChanged(sender As Object, e As EventArgs) Handles txtSectionCode.TextChanged

    End Sub

    ' FIX REGISTRRATION OF STUDENT AND ASSGINED STUDENT TO COURSE THEN CRUD 
End Class
