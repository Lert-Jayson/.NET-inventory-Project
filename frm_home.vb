Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_home
    Dim mycmd As New OdbcCommand

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbl_time.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub frm_home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Refresh()

        connectMe()

        lbl_date.Text = DateTime.Now.ToLongDateString()


        Dim mycmd As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', stock as 'Quantity' from products_tbl where stock = 0", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "products_tbl")

        dg_zero.DataSource = ds.Tables(0)
        dg_zero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_zero.Refresh()

        Dim mycmd1 As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', stock as 'Quantity' from products_tbl where stock < 0", con)
        Dim da1 As New OdbcDataAdapter(mycmd1)
        Dim ds1 As New System.Data.DataSet

        da1.Fill(ds1, "products_tbl")

        dg_nega.DataSource = ds1.Tables(0)
        dg_nega.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_nega.Refresh()

        Dim cmd As New OdbcCommand("select count(`cust_id`) from customer_tbl ", con)
        lbl_customer.Text = cmd.ExecuteScalar.ToString

        Dim cmd1 As New OdbcCommand("select count(`prod_code`) from products_tbl ", con)
        lbl_products.Text = cmd1.ExecuteScalar.ToString

        Dim cmd2 As New OdbcCommand("select count(`in_id`) from inbound_tbl ", con)
        lbl_inbound.Text = cmd2.ExecuteScalar.ToString

        Dim cmd3 As New OdbcCommand("select count(`oid`) from outbound_tbl ", con)
        lbl_outbound.Text = cmd3.ExecuteScalar.ToString
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class