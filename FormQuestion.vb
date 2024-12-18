Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class FormQuestion

    Private assessmentTypeDict As New Dictionary(Of String, Integer)

    Private courseDict As New Dictionary(Of String, Integer)
    Public sectionDict As New Dictionary(Of String, Integer)
    Public Sub fetchAssessmentType()
        Try
            If OPENDB() Then
                Dim Astype As String = "SELECT assessTypeID, AssessmentType FROM tb_assessmenttype"
                Using cmd As New MySqlCommand(Astype, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader
                        While dtreader.Read
                            Dim assessTypeID As Integer = dtreader.GetInt32("assessTypeID")
                            Dim assessmentType As String = dtreader.GetString("AssessmentType")
                            cmbAssessmentType.Items.Add(assessmentType)
                            assessmentTypeDict(assessmentType) = assessTypeID
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT ASSESSMENT TYPE: " & ex.Message)
        End Try
    End Sub

    Public Sub fetchCourse()
        Try
            If OPENDB() Then
                Dim fetch As String = "SELECT courseID, courseCode FROM tb_course"
                Using cmd As New MySqlCommand(fetch, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader
                        While dtreader.Read
                            Dim courseID As Integer = dtreader.GetInt32("courseID")
                            Dim courseCode As String = dtreader.GetString("courseCode")
                            cmbCourse.Items.Add(courseCode)
                            courseDict(courseCode) = courseID
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT COURSE: " & ex.Message)
        End Try
    End Sub

    Private Sub fetchSections()
        Try
            If OPENDB() Then
                Dim query As String = "SELECT sectionID, section FROM tb_section"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim sectionID As Integer = reader.GetInt32("sectionID")
                            Dim sectionName As String = reader.GetString("section")
                            cmbSection.Items.Add(New With {.Text = sectionName, .Value = sectionID})
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("SELECT SECTION: " & ex.Message)
        End Try
    End Sub
    Public Sub insertQuestions()
        Try
            If OPENDB() Then
                ' Get the courseID, assessTypeID, and sectionID from the selected items
                Dim selectedCourse As String = cmbCourse.Text
                Dim selectedAssessmentType As String = cmbAssessmentType.Text
                Dim selectedSection As Object = cmbSection.SelectedItem

                If Not courseDict.ContainsKey(selectedCourse) Then
                    MsgBox("Course not found in dictionary: " & selectedCourse)
                    Return
                End If

                If Not assessmentTypeDict.ContainsKey(selectedAssessmentType) Then
                    MsgBox("Assessment type not found in dictionary: " & selectedAssessmentType)
                    Return
                End If

                If selectedSection Is Nothing Then
                    MsgBox("Section not selected.")
                    Return
                End If

                Dim courseID As Integer = courseDict(selectedCourse)
                Dim assessTypeID As Integer = assessmentTypeDict(selectedAssessmentType)
                Dim sectionID As Integer = selectedSection.Value

                ' Insert into tb_questionanswer
                Dim qu As String = "
            INSERT INTO tb_questionanswer
            VALUES (null, @question, @optionA, @optionB, @optionC, @optionD, @correctAnswer, @assessmentTypeID)"
                Using cmd As New MySqlCommand(qu, conn)
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text)
                    cmd.Parameters.AddWithValue("@optionA", txtA.Text)
                    cmd.Parameters.AddWithValue("@optionB", txtB.Text)
                    cmd.Parameters.AddWithValue("@optionC", txtC.Text)
                    cmd.Parameters.AddWithValue("@optionD", txtD.Text)
                    cmd.Parameters.AddWithValue("@correctAnswer", cmbCorrectAnswer.Text)
                    cmd.Parameters.AddWithValue("@assessmentTypeID", assessTypeID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Insert into tb_course_assessment_section_question using LAST_INSERT_ID()
                Dim qu2 As String = "
            INSERT INTO tb_course_assessment_section_question (courseID, assessTypeID, sectionID, questionID)
            VALUES (@courseID, @assessTypeID, @sectionID, LAST_INSERT_ID())"
                Using cmd2 As New MySqlCommand(qu2, conn)
                    cmd2.Parameters.AddWithValue("@courseID", courseID)
                    cmd2.Parameters.AddWithValue("@assessTypeID", assessTypeID)
                    cmd2.Parameters.AddWithValue("@sectionID", sectionID)
                    cmd2.ExecuteNonQuery()
                End Using

                MsgBox("Question added successfully!", MsgBoxStyle.Information, "Success")
                ' Clear form fields after successful insertion
                txtQuestion.Clear()
                txtA.Clear()
                txtB.Clear()
                txtC.Clear()
                txtD.Clear()
                cmbCorrectAnswer.SelectedIndex = -1
                cmbCourse.SelectedIndex = -1
                cmbAssessmentType.SelectedIndex = -1
                cmbSection.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("INSERTING QUESTION: " & ex.Message)
        End Try
    End Sub

    Public Sub updateQuestion()
        Try
            If OPENDB() Then
                ' Update the question in tb_questionanswer
                Dim upQues As String = "
                UPDATE tb_questionanswer
                SET
                    Question = @question,
                    OptionA = @OptionA,
                    OptionB = @OptionB,
                    OptionC = @OptionC,
                    OptionD = @OptionD,
                    CorrectAnswer = @CorrectAnswer,
                    AssessmentTypeID = @AssessmentTypeID
                WHERE questionID = @questionID"
                Using cmd As New MySqlCommand(upQues, conn)
                    ' Fetch questionID from the DataGridView
                    Dim questionID As Integer = Convert.ToInt32(FormQuestionList.DataGridView1.CurrentRow.Cells(0).Value)
                    Dim assessTypeID As Integer = assessmentTypeDict(cmbAssessmentType.Text)

                    cmd.Parameters.AddWithValue("@questionID", questionID)
                    cmd.Parameters.AddWithValue("@question", txtQuestion.Text)
                    cmd.Parameters.AddWithValue("@OptionA", txtA.Text)
                    cmd.Parameters.AddWithValue("@OptionB", txtB.Text)
                    cmd.Parameters.AddWithValue("@OptionC", txtC.Text)
                    cmd.Parameters.AddWithValue("@OptionD", txtD.Text)
                    cmd.Parameters.AddWithValue("@CorrectAnswer", cmbCorrectAnswer.Text)
                    cmd.Parameters.AddWithValue("@AssessmentTypeID", assessTypeID)

                    ' Execute the update query
                    cmd.ExecuteNonQuery()
                End Using

                ' Update the courseID only if it's necessary
                If cmbCourse.SelectedIndex <> -1 Then
                    Dim upCourseQues As String = "
                    UPDATE tb_coursequestion
                    SET courseID = @courseID
                    WHERE questionID = @questionID"
                    Using cmd As New MySqlCommand(upCourseQues, conn)
                        ' Fetch courseID from the combo box
                        Dim courseID As Integer = courseDict(cmbCourse.Text)

                        cmd.Parameters.AddWithValue("@courseID", courseID)
                        cmd.Parameters.AddWithValue("@questionID", FormQuestionList.DataGridView1.CurrentRow.Cells(0).Value.ToString())

                        ' Execute the update query
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                ' Success message
                MsgBox("Question Updated Successfully", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox("Update Question Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub FormQuestion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchCourse()
        fetchAssessmentType()
        fetchSections()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If MsgBox("Are you sure you want to add this question?", MsgBoxStyle.YesNo, "Add Question") = MsgBoxResult.Yes Then
                insertQuestions()
                'Dim courseID As Integer = courseDict(cmbCourse.Text)
                'Dim assessTypeID As Integer = assessmentTypeDict(cmbAssessmentType.Text)

                'Debug.WriteLine($"Course ID: {courseID}, Assessment Type ID: {assessTypeID}")
                With FormQuestionList
                    .fetchQuestion()
                End With
            End If
        ElseIf btnSave.Text = "Update" Then
            If MsgBox("Are you sure you want to update this question?", MsgBoxStyle.YesNo, "Update Question") = MsgBoxResult.Yes Then
                updateQuestion()
                With FormQuestionList
                    .fetchQuestion()
                End With
            End If
        End If
    End Sub

    Private Sub cmbAssessmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssessmentType.SelectedIndexChanged

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

    End Sub
End Class