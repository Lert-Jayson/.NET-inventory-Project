Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class frm_group
    Dim mycmd As New OdbcCommand

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Dispose()
        frm_products.Refresh()
    End Sub
    Private Sub frm_group_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(gid),0) from group_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_gid()
        Else
            txt_id.Text = 1
        End If
        txt_group.Focus()

    End Sub

    Public Sub get_gid()
        Dim da As New OdbcDataAdapter("select max(gid) gid1 from group_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_id.Text = ds.Tables(0).Rows(0).Item("gid1") + 1
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        Dim gid As String
        Dim gname As String

        gid = txt_id.Text
        gname = txt_group.Text.ToUpper

        con.Close()

        Try
            con.Open()
            Dim dr As OdbcDataReader
            Dim cmd As New OdbcCommand("select * from group_tbl where gname = '" & gname & "'", con)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                MessageBox.Show("Error: Duplicate Record." & " " & gname & " is already created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            Else
                With mycmd
                    .Connection = con
                    .CommandText = "insert into group_tbl values ('" & gid & "','" & gname & "')"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Group Information Added", "Add Group Info", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Call get_gid()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub
End Class