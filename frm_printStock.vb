Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_printStock
    Dim mycmd As New OdbcCommand

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Dispose()
    End Sub

    Private Sub frm_printStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()
        prodgruop()

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

                Dim stock_rpt As New stock_report
                Dim da As New OdbcDataAdapter
                Dim ds As New stockDs


                da = New OdbcDataAdapter("select prod_code,prod_name , prod_group , uom , loc , stock from products_tbl where prod_group = '" & pgroup & "' ", con)
                da.Fill(ds, "Stock")
                stock_rpt.SetDataSource(ds)
                print_stockreport.ReportSource = stock_rpt


            Else
                MessageBox.Show("No records found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            print_stockreport.ReportSource = stock_rpt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim stock_rpt As New stock_report
        Dim da As New OdbcDataAdapter
        Dim ds As New stockDs



        con.Close()

        Try
            con.Open()
            stock_rpt.Load(System.Windows.Forms.Application.StartupPath & "\\stock_report.rpt")
            da = New OdbcDataAdapter("select prod_code,prod_name , prod_group , uom , loc , stock from products_tbl where stock < 0", con)
            da.Fill(ds, "Stock")
            stock_rpt.SetDataSource(ds)
            print_stockreport.ReportSource = stock_rpt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim stock_rpt As New stock_report
        Dim da As New OdbcDataAdapter
        Dim ds As New stockDs



        con.Close()

        Try
            con.Open()
            stock_rpt.Load(System.Windows.Forms.Application.StartupPath & "\\stock_report.rpt")
            da = New OdbcDataAdapter("select prod_code,prod_name , prod_group , uom , loc , stock from products_tbl where stock = 0", con)
            da.Fill(ds, "Stock")
            stock_rpt.SetDataSource(ds)
            print_stockreport.ReportSource = stock_rpt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub
End Class