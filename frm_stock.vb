Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_stock
    Dim mycmd As New OdbcCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frm_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        Dim mycmd As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', loc as 'Location', stock as 'Stock Quantity' from products_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "products_tbl")

        dg_slist.DataSource = ds.Tables(0)
        dg_slist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_slist.Refresh()


        prodgruop()


        If usertype = "USER" Then
            dg_slist.Enabled = False
        End If

    End Sub
    Sub prodgruop()

        cb_search.Items.Clear()
        Dim mycmd As New OdbcCommand("select * from group_tbl", con)
        Dim dr = mycmd.ExecuteReader
        While dr.Read
            cb_search.Items.Add(dr.GetString(1))
        End While
        dr.Close()

    End Sub
    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', loc as 'Location', stock as 'Stock Quantity' from products_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "products_tbl")

            dg_slist.DataSource = ds.Tables(0)
            dg_slist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_slist.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dg_slist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_slist.CellContentClick

        With frm_addstock
            Dim i As Integer
            i = dg_slist.CurrentRow.Index

            .txt_pcode.Text = dg_slist.Item(0, i).Value
            .txt_pname.Text = dg_slist.Item(1, i).Value
            .txt_stock.Text = dg_slist.Item(5, i).Value
        End With
        frm_addstock.ShowDialog()
    End Sub

  

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        refreshMe()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim pgroup As String
        pgroup = cb_search.Text

        con.Close()

        Try
            con.Open()
            Dim dr1 As OdbcDataReader
            Dim mycmd1 As New OdbcCommand("select * from products_tbl where prod_group = '" & pgroup & "'", con)
            dr1 = mycmd1.ExecuteReader
            If dr1.HasRows Then

                Dim mycmd As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', loc as 'Location', stock as 'Stock Quantity' from products_tbl where prod_group = '" & pgroup & "'", con)
                Dim da As New OdbcDataAdapter(mycmd)
                Dim ds As New System.Data.DataSet

                da.Fill(ds, "products_tbl")

                dg_slist.DataSource = ds.Tables(0)
                dg_slist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dg_slist.Refresh()
            Else
                MessageBox.Show("No records found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim stock_rpt As New stock_report
        Dim da As New OdbcDataAdapter
        Dim ds As New stockDs



        con.Close()

        Try
            con.Open()
            stock_rpt.Load(System.Windows.Forms.Application.StartupPath & "\\stock_report.rpt")
            da = New OdbcDataAdapter("select prod_code,prod_name , prod_group , uom , loc , stock from products_tbl", con)
            da.Fill(ds, "Stock")
            stock_rpt.SetDataSource(ds)
            frm_printStock.print_stockreport.ReportSource = stock_rpt
            frm_printStock.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    
    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged

        Dim mycmd As New OdbcCommand("select prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', loc as 'Location', stock as 'Stock Quantity' from products_tbl where prod_code like '%" & txt_search.Text & "%' or prod_name like '%" & txt_search.Text & "%'", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "products_tbl")

        dg_slist.DataSource = ds.Tables(0)
        dg_slist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_slist.Refresh()
    End Sub
End Class