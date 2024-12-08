Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormSectionList

    Public Sub fetchSection()
        Try

            DataGridView1.Rows.Clear()
            If OPENDB() Then
                Dim st As String = "SELECT * FROM tb_section"
                Using cmd As New MySqlCommand(st, conn)
                    Using dtreader As MySqlDataReader = cmd.ExecuteReader

                        While dtreader.Read
                            ' Dim lv As  = lvSection.Items.Add(dtreader("id").ToString)
                            Dim id As Integer = dtreader.GetInt32("sectionID")
                            Dim section As String = dtreader.GetString("section")
                            Dim courseCode As String = dtreader.GetString("courseCode")

                            DataGridView1.Rows.Add(id, section, courseCode)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("Fetch Section " & ex.Message)
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
                .txtSection.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .cmbCourse.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .btnAddSection.Enabled = False
                .btnEdit.Enabled = True
                .ShowDialog()
            End With
        End If


    End Sub
End Class