Imports MySql.Data.MySqlClient

Public Class FormEditAssignedStudent
    Private _studentId As Integer
    Private connString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"
    Public Property StudentID As Integer
        Get
            Return _studentId
        End Get
        Set(value As Integer)
            _studentId = value
            LoadStudentData()
        End Set
    End Property

    Private Sub LoadStudentData()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                ' Get student and assignment details
                Dim query As String = "SELECT 
                                    s.studentID,
                                    s.studentNo,
                                    CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS StudentName,
                                    sec.section,
                                    sec.sectionID,
                                    c.CourseCode,
                                    assess.AssessmentType
                                FROM tb_student s
                                INNER JOIN tb_assignedstudents assi ON s.studentID = assi.studentID
                                INNER JOIN tb_section sec ON assi.sectionID = sec.sectionID
                                INNER JOIN tb_course c ON assi.courseID = c.courseID
                                INNER JOIN tb_assessmenttype assess ON assi.assessTypeID = assess.assessTypeID
                                WHERE s.studentID = @studentID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@studentID", _studentId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtStudentID.Text = reader("studentNo").ToString()
                            txtStudentName.Text = reader("StudentName").ToString()
                            txtSectionCode.Text = reader("section").ToString()
                            LoadCourses(reader("section").ToString())
                            cmbCourseCode.Text = reader("CourseCode").ToString()
                            LoadAssessmentTypes()
                            cmbAssessmentType.Text = reader("AssessmentType").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCourses(sectionCode As String)
        Try
            cmbCourseCode.Items.Clear()
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim trimSec As String = ""
                If sectionCode.Contains("BSCS") Then
                    trimSec = sectionCode.Substring(2, 2)
                ElseIf sectionCode.Contains("BSIT") Then
                    trimSec = sectionCode.Substring(2, 1)
                End If

                Dim query As String = "SELECT CourseCode FROM tb_course WHERE CourseCode LIKE @prefix"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@prefix", trimSec & "%")
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cmbCourseCode.Items.Add(reader("CourseCode").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAssessmentTypes()
        Try
            cmbAssessmentType.Items.Clear()
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT AssessmentType FROM tb_assessmenttype"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cmbAssessmentType.Items.Add(reader("AssessmentType").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading assessment types: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                ' Get IDs for the selected values
                Dim courseId As Integer = GetCourseId(cmbCourseCode.Text)
                Dim assessTypeId As Integer = GetAssessmentTypeId(cmbAssessmentType.Text)

                Dim query As String = "UPDATE tb_assignedstudents 
                                     SET courseID = @courseID, 
                                         assessTypeID = @assessTypeID 
                                     WHERE studentID = @studentID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@courseID", courseId)
                    cmd.Parameters.AddWithValue("@assessTypeID", assessTypeId)
                    cmd.Parameters.AddWithValue("@studentID", _studentId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Update successful!")
                DialogResult = DialogResult.OK
                Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message)
        End Try
    End Sub

    Private Function GetCourseId(courseCode As String) As Integer
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT courseID FROM tb_course WHERE CourseCode = @courseCode"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@courseCode", courseCode)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Function GetAssessmentTypeId(assessmentType As String) As Integer
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT assessTypeID FROM tb_assessmenttype WHERE AssessmentType = @assessType"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@assessType", assessmentType)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class