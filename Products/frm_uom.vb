Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class frm_uom
    Dim mycmd As New OdbcCommand

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Dispose()
        frm_products.Refresh()
    End Sub

    Private Sub frm_uom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(id),0) from uom_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_uid()
        Else
            txt_id.Text = 1
        End If
        txt_name.Focus()

    End Sub
    Public Sub get_uid()
        Dim da As New OdbcDataAdapter("select max(id) uid1 from uom_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_id.Text = ds.Tables(0).Rows(0).Item("uid1") + 1
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim uid As String
        Dim uom As String

        uid = txt_id.Text
        uom = txt_name.Text.ToUpper

        con.Close()

        Try
            con.Open()
            Dim dr As OdbcDataReader
            Dim cmd As New OdbcCommand("select * from uom_tbl where uom = '" & uom & "'", con)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                MessageBox.Show("Error: Duplicate Record." & " " & uom & " is already created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            Else
                With mycmd
                    .Connection = con
                    .CommandText = "insert into uom_tbl values ('" & uid & "','" & uom & "')"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("UOM Information Added", "Add UOM Info", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Call get_uid()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub
End Class