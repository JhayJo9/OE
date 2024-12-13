Imports System.Data
Imports MySql.Data.MySqlClient

Public Class FormRegistrationStudentList
    Private connnn As MySqlConnection
    Private connnnectionString As String = "server=localhost;user=Yohan;password=Yohan;port=3307;database=exam;sslmode=none;Convert Zero Datetime=True"

    Private Sub InitializeConnection()
        connnn = New MySqlConnection(connnnectionString)
    End Sub

    Private Sub SetupDataGridViewProperties()
        With dgwRegistrationList
            ' Basic Properties
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False

            ' Appearance
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.Fixed3D
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
            .ColumnHeadersHeight = 40
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .DefaultCellStyle.Font = New Font("Segoe UI", 9.75F)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 128, 255)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249)

            ' Set up columns with specific properties
            .Columns.Clear()

            ' Add Data Columns
            .Columns.Add("StudentNo", "Student No.")
            .Columns.Add("LastName", "Last Name")
            .Columns.Add("FirstName", "First Name")
            .Columns.Add("MiddleName", "Middle Name")
            .Columns.Add("DateOfBirth", "Date of Birth")
            .Columns.Add("Gender", "Gender")
            .Columns.Add("Email", "Email")
            .Columns.Add("ContactNo", "Contact No.")
            .Columns.Add("SectionCode", "Section")

            ' Configure column properties
            For Each col As DataGridViewColumn In .Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Select Case col.Name
                    Case "StudentNo"
                        col.Width = 80
                    Case "LastName", "FirstName", "MiddleName"
                        col.Width = 120
                    Case "DateOfBirth"
                        col.Width = 100
                    Case "Gender"
                        col.Width = 80
                    Case "Email"
                        col.Width = 150
                    Case "ContactNo"
                        col.Width = 100
                    Case "SectionCode"
                        col.Width = 80
                End Select
            Next

            ' Add Button Columns
            Dim viewBtn As New DataGridViewButtonColumn()
            With viewBtn
                .HeaderText = "View"
                .Name = "ViewButton"
                .Text = "View"
                .UseColumnTextForButtonValue = True
                .FlatStyle = FlatStyle.Flat
                .DefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183)
                .DefaultCellStyle.ForeColor = Color.White
                .Width = 60
            End With
            .Columns.Add(viewBtn)

            Dim editBtn As New DataGridViewButtonColumn()
            With editBtn
                .HeaderText = "Edit"
                .Name = "EditButton"
                .Text = "Edit"
                .UseColumnTextForButtonValue = True
                .FlatStyle = FlatStyle.Flat
                .DefaultCellStyle.BackColor = Color.FromArgb(92, 184, 92)
                .DefaultCellStyle.ForeColor = Color.White
                .Width = 60
            End With
            .Columns.Add(editBtn)

            Dim deleteBtn As New DataGridViewButtonColumn()
            With deleteBtn
                .HeaderText = "Delete"
                .Name = "DeleteButton"
                .Text = "Delete"
                .UseColumnTextForButtonValue = True
                .FlatStyle = FlatStyle.Flat
                .DefaultCellStyle.BackColor = Color.FromArgb(217, 83, 79)
                .DefaultCellStyle.ForeColor = Color.White
                .Width = 60
            End With
            .Columns.Add(deleteBtn)
        End With
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
        InitializeGridView()
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
                                        s.studentID = @studentID", connnn)
                    cmd.Parameters.AddWithValue("@studentID", studentNo)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            With FormRegistrationStudent
                                .txtStudentNo.Text = reader("studentNo").ToString()
                                .txtFirstname.Text = reader("FirstName").ToString()
                                .txtLastname.Text = reader("LastName").ToString()
                                .txtMiddlename.Text = reader("Middlename").ToString()
                                .chbGender.Text = reader("Gender").ToString()
                                .dtDateOfBirth.Value = Convert.ToDateTime(reader("DateOfBirth"))
                                .txtEmail.Text = reader("Email").ToString()
                                .txtContactNo.Text = reader("ContactNumber").ToString()
                                .cmbSectionCode.Text = reader("Section").ToString()

                                .SetControlsState(Not isViewOnly)
                                .btnRegister.Text = If(isViewOnly, "CLOSE", "UPDATE")
                                .ShowDialog()
                            End With
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("Error loading student details: " & ex.Message)
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