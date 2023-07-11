Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_outbound
    Dim mycmd As New OdbcCommand

    Private Sub frm_outbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        prodname()

        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(oid),0) from outbound_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_pid()
        Else
            txt_oid.Text = 1
        End If
        cb_pname.Focus()

        Dim mycmd As New OdbcCommand("select oid as 'Outbound ID',date as 'Date', pname as 'Product Name', pcode as 'Product Code', grp as 'Group', uom as 'UOM',  qty as 'Quantity', balstock as 'Balance Stock' from outbound_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "outbound_tbl")

        dg_olist.DataSource = ds.Tables(0)
        dg_olist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_olist.Refresh()


        If usertype = "USER" Then
            btn_edit.Hide()
            btn_update.Hide()
            btn_delete.Hide()
        End If

    End Sub

    Public Sub get_pid()
        Dim da As New OdbcDataAdapter("select max(oid) inid1 from outbound_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_oid.Text = ds.Tables(0).Rows(0).Item("inid1") + 1

    End Sub

    Sub prodname()

        cb_pname.Items.Clear()
        Dim mycmd As New OdbcCommand("select prod_id, prod_name from products_tbl", con)
        Dim dr = mycmd.ExecuteReader
        While dr.Read
            cb_pname.Items.Add(dr.GetString(1))
        End While
        dr.Close()


    End Sub
    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select oid as 'Outbound ID',date as 'Date', pname as 'Product Name', pcode as 'Product Code', grp as 'Group', uom as 'UOM',  qty as 'Quantity', balstock as 'Balance Stock' from outbound_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "outbound_tbl")

            dg_olist.DataSource = ds.Tables(0)
            dg_olist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_olist.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Sub addtolist()
        con.Close()
        Try
            con.Open()
            Dim mycmd As New OdbcCommand("SELECT * FROM products_tbl where prod_name = '" & cb_pname.Text & "'", con)
            Dim dr As OdbcDataReader
            dr = mycmd.ExecuteReader
            While dr.Read()
                If cb_pname.Text = "" Then

                Else

                    Dim procode As String = dr("prod_code")

                    Dim progroup As String = dr("prod_group")

                    Dim uom As String = dr("uom")

                    txt_pcode.Text = procode
                    txt_grp.Text = progroup
                    txt_uom.Text = uom


                End If
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cb_pname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_pname.SelectedIndexChanged
        addtolist()
    End Sub

    Sub addstock()
        con.Close()
        Try
            con.Open()
            Dim mycmd As New OdbcCommand("SELECT * FROM products_tbl where prod_name = '" & cb_pname.Text & "'", con)
            Dim dr As OdbcDataReader
            dr = mycmd.ExecuteReader
            dr.Read()

            Dim stock As Integer = dr("stock")
            Dim qty As Integer = txt_qty.Text
            Dim totalstock As Integer = stock - qty

            Dim pcode As String = txt_pcode.Text

            con.Close()

            Try
                con.Open()

                With mycmd
                    .Connection = con
                    .CommandText = "update products_tbl set prod_code = '" & pcode & "', stock = '" & totalstock & "' where prod_code = '" & pcode & "' "
                    .ExecuteNonQuery()

                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()

            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim oid As String
        Dim dtp As String

        Dim pname As String
        Dim qty As String
        Dim pcode As String
        Dim grp As String
        Dim uom As String


        oid = txt_oid.Text
        dtp = dtp_obound.Text

        pname = cb_pname.SelectedItem
        qty = txt_qty.Text
        pcode = txt_pcode.Text
        grp = txt_grp.Text
        uom = txt_uom.Text

        con.Close()
        Try
            con.Open()
            Dim mycmd As New OdbcCommand("SELECT * FROM products_tbl where prod_name = '" & cb_pname.Text & "'", con)
            Dim dr As OdbcDataReader
            dr = mycmd.ExecuteReader
            dr.Read()

            Dim stock As Integer = dr("stock")

            Dim totalstock As Integer = stock - qty



            con.Close()
            Try
                con.Open()

                With mycmd
                    .Connection = con
                    .CommandText = "insert into outbound_tbl values ('" & oid & "','" & dtp & "','" & pname & "','" & pcode & "','" & grp & "','" & uom & "','" & qty & "','" & totalstock & "')"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Outbound Information Added", "Add Outbound Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                refreshMe()
                frm_home.Refresh()

                addstock()

                cb_pname.SelectedIndex = -1
                txt_qty.Clear()
                txt_pcode.Clear()
                txt_grp.Clear()
                txt_uom.Clear()



                Call get_pid()
                cb_pname.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        Dim mycmd As New OdbcCommand("select oid as 'Outbound ID',date as 'Date', pname as 'Product Name', pcode as 'Product Code', grp as 'Group', uom as 'UOM',  qty as 'Quantity', balstock as 'Balance Stock' from outbound_tbl where pname like '%" & txt_search.Text & "%'", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "outbound_tbl")

        dg_olist.DataSource = ds.Tables(0)
        dg_olist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_olist.Refresh()
    End Sub

    Private Sub dg_olist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_olist.CellContentClick
        Dim i As Integer
        i = dg_olist.CurrentRow.Index
        txt_oid.Text = dg_olist.Item(0, i).Value
        dtp_obound.Text = dg_olist.Item(1, i).Value
        cb_pname.Text = dg_olist.Item(2, i).Value
        cb_pname.SelectedValue = dg_olist.Item(2, i).Value
        txt_pcode.Text = dg_olist.Item(3, i).Value
        txt_grp.Text = dg_olist.Item(4, i).Value
        txt_uom.Text = dg_olist.Item(5, i).Value
        txt_qty.Text = dg_olist.Item(6, i).Value



        cb_pname.Enabled = False
        txt_qty.Enabled = False
        dtp_obound.Enabled = False

        btn_save.Enabled = False
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        cb_pname.Enabled = True
        txt_qty.Enabled = True
        dtp_obound.Enabled = True

        btn_save.Enabled = False
        btn_edit.Enabled = True
        btn_update.Enabled = True
        btn_delete.Enabled = False

    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim oid As String
        Dim dtp As String

        Dim pname As String
        Dim qty As String
       

        oid = txt_oid.Text
        dtp = dtp_obound.Text

        pname = cb_pname.SelectedItem
        qty = txt_qty.Text
     

        con.Close()
        Try
            con.Open()

            With mycmd
                .Connection = con
                .CommandText = "update outbound_tbl set oid = '" & oid & "', date = '" & dtp & "', pname = '" & pname & "', qty = '" & qty & "' where oid = '" & oid & "'"
                .ExecuteNonQuery()

            End With

            MessageBox.Show("Record is updated!", "Update Outbound Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshMe()



            cb_pname.SelectedIndex = -1
            txt_qty.Clear()
            txt_pcode.Clear()
            txt_grp.Clear()
            txt_uom.Clear()

            btn_save.Enabled = True
            btn_edit.Enabled = True
            btn_update.Enabled = True
            btn_delete.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim id2 As String
        Dim result1 As New DialogResult

        id2 = txt_oid.Text

        con.Close()
        Try
            con.Open()

            result1 = MessageBox.Show("Are you sure you want to delete the record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result1 = System.Windows.Forms.DialogResult.Yes Then
                With mycmd
                    .Connection = con
                    .CommandText = "delete from outbound_tbl where oid= '" & id2 & "'"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Record is deleted!", "Delete Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                cb_pname.SelectedIndex = -1
                txt_qty.Clear()
                txt_pcode.Clear()
                txt_grp.Clear()
                txt_uom.Clear()

                btn_save.Enabled = False
                btn_edit.Enabled = True
                btn_update.Enabled = True
                btn_delete.Enabled = True

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim outbound_rpt As New outbound_rpt
        Dim da As New OdbcDataAdapter
        Dim ds As New ds_outbound



        con.Close()

        Try
            con.Open()
            outbound_rpt.Load(System.Windows.Forms.Application.StartupPath & "\\outbound_rpt.rpt")
            da = New OdbcDataAdapter("select * from outbound_tbl", con)
            da.Fill(ds, "Outbound")
            outbound_rpt.SetDataSource(ds)
            frm_printoutbound.rptv_outbound.ReportSource = outbound_rpt
            frm_printoutbound.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim mycmd As New OdbcCommand("select oid as 'Outbound ID',date as 'Date', pname as 'Product Name', pcode as 'Product Code', grp as 'Group', uom as 'UOM',  qty as 'Quantity', balstock as 'Balance Stock' from outbound_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "outbound_tbl")

        dg_olist.DataSource = ds.Tables(0)
        dg_olist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_olist.Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub
End Class