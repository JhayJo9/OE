Imports System.Management
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormExamListForStudent

    Public Sub Fetch_Data()
        Try
            Dim s As String = "server=127.0.0.1;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"
            Using Fetch_DataConnection As New MySqlConnection(s)
                Dim q As String = "SELECT 
                    c.courseCode,
                    assess.AssessmentType
                FROM 
                    tb_student s
                INNER JOIN 
                    tb_assignedstudents assi ON s.studentID = assi.studentID
                INNER JOIN 
                    tb_course c ON c.courseID = assi.courseID
                INNER JOIN 
                    tb_assessmenttype assess ON assess.assessTypeID = assi.assessTypeID
                INNER JOIN 
                    tb_section ss ON ss.sectionID = assi.sectionID
                INNER JOIN 
                    tb_question_assignment qa ON qa.assignedID = assi.assesID
                INNER JOIN 
                    tb_questionanswer q ON q.questionID = qa.questionID
                where s.studentID = @studentID
                "
                Dim cmd As New MySqlCommand(q, Fetch_DataConnection)
                Fetch_DataConnection.Open()
                cmd.Parameters.AddWithValue("@studentID", _STUDENTD)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    dgvStudentExams.Rows.Add(reader("courseCode"), reader("AssessmentType"))
                End While
            End Using
        Catch ex As Exception
            MsgBox("FETCHING DATA: " & ex.Message)
        End Try
    End Sub
    Private Sub dgvStudentExams_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudentExams.CellContentClick
        Dim colanme As String = dgvStudentExams.Columns(e.ColumnIndex).Name
        If colanme = "colTakeExam" Then
            With FormExamSession
                .ShowDialog()
            End With
        Else
            MsgBox("No exam available")
        End If
    End Sub

    Private Sub FormExamListForStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_Data()
    End Sub
End Class