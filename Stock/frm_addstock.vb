Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_addstock
    Dim mycmd As New OdbcCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim procode As String
        Dim stock As String

        procode = txt_pcode.Text
        stock = txt_stock.Text

        con.Close()

        Try
            con.Open()

            With mycmd
                .Connection = con
                .CommandText = "update products_tbl set prod_code = '" & procode & "', stock = '" & stock & "' where prod_code = '" & procode & "' "
                .ExecuteNonQuery()

            End With

            MessageBox.Show("Record is updated!", "Update Stock Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frm_stock.refreshMe()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()

        End Try

    End Sub
End Class