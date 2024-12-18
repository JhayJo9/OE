Imports System.Data
Imports MySql.Data.MySqlClient

Public Class FormRegistrationStudentList
    Private connnn As MySqlConnection
    Private connnnectionString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"

    Private Sub InitializeConnection()
        connnn = New MySqlConnection(connnnectionString)
    End Sub

    Private Function OPENDB() As Boolean
        Try
            If connnn Is Nothing Then
                InitializeConnection()
            End If
            If connnn.State = ConnectionState.Closed Then
                connnn.Open()
            End If
            Return True
        Catch ex As Exception
            MsgBox("Connection Error: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub FormRegistrationStudentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitializeGridView()
        'SetupDataGridViewProperties()
        fetchStudentList()
    End Sub

    Private Sub InitializeGridView()
        ' Setup DataGridView columns
        With dgwRegistrationList
            .ColumnCount = 9
            .Columns(0).Name = "Student No"
            .Columns(1).Name = "Last Name"
            .Columns(2).Name = "First Name"
            .Columns(3).Name = "Middle Name"
            .Columns(4).Name = "Date of Birth"
            .Columns(5).Name = "Gender"
            .Columns(6).Name = "Email"
            .Columns(7).Name = "Contact No"
            .Columns(8).Name = "Section Code"

            ' Add button columns
            Dim viewButton As New DataGridViewButtonColumn()
            viewButton.HeaderText = "View"
            viewButton.Text = "View"
            viewButton.UseColumnTextForButtonValue = True
            .Columns.Add(viewButton)

            Dim editButton As New DataGridViewButtonColumn()
            editButton.HeaderText = "Edit"
            editButton.Text = "Edit"
            editButton.UseColumnTextForButtonValue = True
            .Columns.Add(editButton)

            Dim deleteButton As New DataGridViewButtonColumn()
            deleteButton.HeaderText = "Delete"
            deleteButton.Text = "Delete"
            deleteButton.UseColumnTextForButtonValue = True
            .Columns.Add(deleteButton)
        End With
    End Sub

    Public Sub RefreshData()
        fetchStudentList()

    End Sub
    Public Sub fetchStudentList()
        Try
            Using connnn As New MySqlConnection(connnnectionString)
                dgwRegistrationList.Rows.Clear()
                connnn.Open()

                Using cmd As New MySqlCommand("SELECT 
                                        s.studentNo,
                                         s.Lastname,
                                        s.Firstname,
	                                    s.MiddleName,
                                        s.DateOfBirth,
                                        s.Gender,
                                        s.Email,
                                        s.ContactNumber,
                                        sec.section
                                    FROM 
                                        tb_student s
                                    JOIN 
                                        tb_assignedsection asg ON s.studentID = asg.studentID
                                    JOIN 
                                        tb_section sec ON asg.sectionID = sec.sectionID;", connnn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                        While dtreader.Read
                            dgwRegistrationList.Rows.Add(
                            dtreader.GetString("studentNo"),
                            dtreader.GetString("LastName"),
                            dtreader.GetString("FirstName"),
                            dtreader.GetString("Middlename"),
                            dtreader.GetDateTime("DateOfBirth").ToString("yyyy-MM-dd"),
                            dtreader.GetString("Gender"),
                            dtreader.GetString("Email"),
                            dtreader.GetString("ContactNumber"),
                            dtreader.GetString("section")
                        )
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            dgwRegistrationList.Rows.Clear()
            If OPENDB() Then
                Dim query As String = "SELECT * FROM tb_student WHERE studentNo LIKE @search " &
                                    "OR LastName LIKE @search " &
                                    "OR FirstName LIKE @search " &
                                    "OR Middlename LIKE @search"

                Using cmd As New MySqlCommand(query, connnn)
                    cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader()
                        While dtreader.Read
                            dgwRegistrationList.Rows.Add(
                                dtreader.GetString("studentNo"),
                                dtreader.GetString("LastName"),
                                dtreader.GetString("FirstName"),
                                dtreader.GetString("Middlename"),
                                dtreader.GetDateTime("DateOfBirth").ToString("yyyy-MM-dd"),
                                dtreader.GetString("Gender"),
                                dtreader.GetString("Email"),
                                dtreader.GetString("ContactNumber"),
                                dtreader.GetString("SectionCode")
                            )
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("Search Error: " & ex.Message)
        Finally
            If connnn IsNot Nothing AndAlso connnn.State = ConnectionState.Open Then
                connnn.Close()
            End If
        End Try
    End Sub
    Public Sub Delete_Data(studentNo As Integer)
        If MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If OPENDB() Then
                    Using cmd As New MySqlCommand("DELETE FROM tb_student WHERE studentNo = @studentNo", connnn)
                        cmd.Parameters.AddWithValue("@studentNo", studentNo)
                        cmd.ExecuteNonQuery()
                        MsgBox("Student successfully deleted")
                        fetchStudentList()
                    End Using
                End If
            Catch ex As Exception
                MsgBox("Delete Error: " & ex.Message)
            Finally
                If connnn IsNot Nothing AndAlso connnn.State = ConnectionState.Open Then
                    connnn.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub dgwRegistrationList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwRegistrationList.CellClick
        If e.RowIndex < 0 Then Return

        Dim cellValue = dgwRegistrationList.Rows(e.RowIndex).Cells(0).Value
        Dim studentNo As Integer

        If Not IsDBNull(cellValue) AndAlso Integer.TryParse(cellValue.ToString(), studentNo) Then
            ' Proceed with the valid studentNo
            Select Case dgwRegistrationList.Columns(e.ColumnIndex).HeaderText
                Case "View"
                    ShowStudentDetails(studentNo, True)
                    MsgBox("VIEW CLICKED")
                Case "Edit"
                    ShowStudentDetails(studentNo, False)
                Case "Delete"
                    Delete_Data(studentNo)
            End Select
        Else
            MsgBox("Invalid student number format.")
        End If
    End Sub

    Private Sub ShowStudentDetails(studentNo As Integer, isViewOnly As Boolean)
        Try
            If OPENDB() Then
                Using cmd As New MySqlCommand("SELECT 
                                    s.studentNo,
                                    s.Lastname,
                                    s.Firstname,
                                    s.MiddleName,
                                    s.DateOfBirth,
                                    s.Gender,
                                    s.Email,
                                    s.ContactNumber,
                                    sec.section
                                FROM 
                                    tb_student s
                                JOIN 
                                    tb_assignedsection asg ON s.studentID = asg.studentID
                                JOIN 
                                    tb_section sec ON asg.sectionID = sec.sectionID
                                WHERE 
                                    s.studentNo = @studentNo", connnn)  ' Changed from studentID to studentNo
                    cmd.Parameters.AddWithValue("@studentNo", studentNo)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Create a new instance of FormRegistrationStudent
                            Dim studentForm As New FormRegistrationStudent()

                            Debug.WriteLine("Student data found")
                            Debug.WriteLine($"Student No: {reader("studentNo")}")
                            ' Set the form properties
                            With studentForm
                                .txtStudentNo.Text = reader("studentNo").ToString()
                                .txtFirstname.Text = reader("FirstName").ToString()
                                .txtLastname.Text = reader("LastName").ToString()
                                .txtMiddlename.Text = reader("Middlename").ToString()
                                .chbGender.Text = reader("Gender").ToString()
                                .dtDateOfBirth.Value = Convert.ToDateTime(reader("DateOfBirth"))
                                .txtEmail.Text = reader("Email").ToString()
                                .txtContactNo.Text = reader("ContactNumber").ToString()
                                .cmbSectionCode.Text = reader("section").ToString()

                                .SetControlsState(Not isViewOnly)

                                .btnRegister.Text = If(isViewOnly, "CLOSE", "UPDATE")
                                .ShowDialog()
                            End With
                        Else
                            MessageBox.Show("No student found with the given student number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading student details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connnn IsNot Nothing AndAlso connnn.State = ConnectionState.Open Then
                connnn.Close()
            End If
        End Try
    End Sub
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        With FormRegistrationStudent
            .ClearControls()
            .SetControlsState(True)
            .btnRegister.Text = "REGISTER"
            .ShowDialog()
        End With
        fetchStudentList()
    End Sub

    Private Sub dgwRegistrationList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwRegistrationList.CellContentClick

    End Sub
End Class