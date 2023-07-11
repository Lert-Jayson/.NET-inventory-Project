Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_inbound
    Dim mycmd As New OdbcCommand

    Private Sub frm_inbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        custname()
        prodname()
      
        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(in_id),0) from inbound_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_pid()
        Else
            txt_inid.Text = 1
        End If
        cb_cname.Focus()

        Dim mycmd As New OdbcCommand("select in_id as 'Inbound ID', date as 'Date',cname as 'Customer Name', pname as 'Product Name', prod_code as 'Product Code', grp as 'Group', uom as 'UOM', price as 'Price', qty as 'Quantity' from inbound_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "inbound_tbl")

        dg_inlist.DataSource = ds.Tables(0)
        dg_inlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_inlist.Refresh()


        If usertype = "USER" Then
            btn_edit.Hide()
            btn_update.Hide()
            btn_delete.Hide()
        End If


    End Sub

    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select in_id as 'Inbound ID',date as 'Date',cname as 'Customer Name', pname as 'Product Name', prod_code as 'Product Code', grp as 'Group', uom as 'UOM', price as 'Price', qty as 'Quantity' from inbound_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "inbound_tbl")

            dg_inlist.DataSource = ds.Tables(0)
            dg_inlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_inlist.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub get_pid()
        Dim da As New OdbcDataAdapter("select max(in_id) inid1 from inbound_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_inid.Text = ds.Tables(0).Rows(0).Item("inid1") + 1
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Sub custname()

        cb_cname.Items.Clear()
        Dim mycmd As New OdbcCommand("select cust_id, cname from customer_tbl", con)
        Dim dr = mycmd.ExecuteReader
        While dr.Read
            cb_cname.Items.Add(dr.GetString(1))
        End While
        dr.Close()


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
                    Dim price As Integer = dr("price")
                    Dim uom As String = dr("uom")

                    txt_pcode.Text = procode
                    txt_grp.Text = progroup
                    txt_uom.Text = uom
                    txt_price.Text = price

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
            Dim totalstock As Integer = stock + qty

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
        Dim inid As String
        Dim dtp As String
        Dim cname As String
        Dim pname As String
        Dim qty As String
        Dim pcode As String
        Dim grp As String
        Dim uom As String
        Dim price As String

        inid = txt_inid.Text
        dtp = dtp_inbound.Text
        cname = cb_cname.SelectedItem
        pname = cb_pname.SelectedItem
        qty = txt_qty.Text
        pcode = txt_pcode.Text
        grp = txt_grp.Text
        uom = txt_uom.Text
        price = txt_price.Text



        con.Close()
        Try
            con.Open()
            
            With mycmd
                .Connection = con
                .CommandText = "insert into inbound_tbl values ('" & inid & "','" & dtp & "','" & cname & "','" & pname & "','" & pcode & "','" & qty & "','" & grp & "','" & uom & "','" & price & "')"
                .ExecuteNonQuery()
            End With
            MessageBox.Show("Inbound Information Added", "Add Inbound Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            refreshMe()
            frm_home.Refresh()

            addstock()
            cb_cname.SelectedIndex = -1
            cb_pname.SelectedIndex = -1
            txt_qty.Clear()
            txt_pcode.Clear()
            txt_grp.Clear()
            txt_uom.Clear()
            txt_price.Clear()


            Call get_pid()
            cb_pname.Focus()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        Dim mycmd As New OdbcCommand("select in_id as 'Inbound ID', date as 'Date',cname as 'Customer Name', pname as 'Product Name', prod_code as 'Product Code', grp as 'Group', uom as 'UOM', price as 'Price', qty as 'Quantity' from inbound_tbl where pname like '%" & txt_search.Text & "%'", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "inbound_tbl")

        dg_inlist.DataSource = ds.Tables(0)
        dg_inlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_inlist.Refresh()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        cb_cname.Enabled = True
        cb_pname.Enabled = True
        txt_qty.Enabled = True
        dtp_inbound.Enabled = True

        btn_save.Enabled = False
        btn_edit.Enabled = True
        btn_update.Enabled = True
        btn_delete.Enabled = False
    End Sub

    Private Sub dg_inlist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_inlist.CellContentClick
        Dim i As Integer
        i = dg_inlist.CurrentRow.Index
        txt_inid.Text = dg_inlist.Item(0, i).Value
        dtp_inbound.Text = dg_inlist.Item(1, i).Value
        cb_cname.Text = dg_inlist.Item(2, i).Value
        cb_cname.SelectedValue = dg_inlist.Item(2, i).Value
        cb_pname.Text = dg_inlist.Item(3, i).Value
        cb_pname.SelectedValue = dg_inlist.Item(3, i).Value
        txt_pcode.Text = dg_inlist.Item(4, i).Value
        txt_grp.Text = dg_inlist.Item(5, i).Value
        txt_uom.Text = dg_inlist.Item(6, i).Value
        txt_price.Text = dg_inlist.Item(7, i).Value
        txt_qty.Text = dg_inlist.Item(8, i).Value


        cb_cname.Enabled = False
        cb_pname.Enabled = False
        txt_qty.Enabled = False
        dtp_inbound.Enabled = False

        btn_save.Enabled = False

    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim inid1 As String
        Dim cname1 As String
        Dim pname1 As String
        Dim dtp1 As String
        Dim qty1 As String

        inid1 = txt_inid.Text
        dtp1 = dtp_inbound.Text
        cname1 = cb_cname.SelectedItem
        pname1 = cb_pname.SelectedItem
        qty1 = txt_qty.Text

        con.Close()
        Try
            con.Open()

            With mycmd
                .Connection = con
                .CommandText = "update inbound_tbl set in_id = '" & inid1 & "', date = '" & dtp1 & "', cname = '" & cname1 & "', pname = '" & pname1 & "', qty = '" & qty1 & "' where in_id = '" & inid1 & "'"
                .ExecuteNonQuery()

            End With

            MessageBox.Show("Record is updated!", "Update Inbound Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshMe()


            cb_cname.SelectedIndex = -1
            cb_pname.SelectedIndex = -1
            txt_qty.Clear()
            txt_pcode.Clear()
            txt_grp.Clear()
            txt_uom.Clear()
            txt_price.Clear()

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

        id2 = txt_inid.Text

        con.Close()
        Try
            con.Open()

            result1 = MessageBox.Show("Are you sure you want to delete the record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result1 = System.Windows.Forms.DialogResult.Yes Then
                With mycmd
                    .Connection = con
                    .CommandText = "delete from inbound_tbl where in_id= '" & id2 & "'"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Record is deleted!", "Delete Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                cb_cname.SelectedIndex = -1
                cb_pname.SelectedIndex = -1
                txt_qty.Clear()
                txt_pcode.Clear()
                txt_grp.Clear()
                txt_uom.Clear()
                txt_price.Clear()

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim mycmd As New OdbcCommand("select in_id as 'Inbound ID', date as 'Date',cname as 'Customer Name', pname as 'Product Name', prod_code as 'Product Code', grp as 'Group', uom as 'UOM', price as 'Price', qty as 'Quantity' from inbound_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "inbound_tbl")

        dg_inlist.DataSource = ds.Tables(0)
        dg_inlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_inlist.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim inbound_rpt As New inbound_rpt
        Dim da As New OdbcDataAdapter
        Dim ds As New inbound_ds



        con.Close()

        Try
            con.Open()
            inbound_rpt.Load(System.Windows.Forms.Application.StartupPath & "\\inbound_rpt.rpt")
            da = New OdbcDataAdapter("select * from inbound_tbl", con)
            da.Fill(ds, "Inbound")
            inbound_rpt.SetDataSource(ds)
            frm_printinbound.inbound_rpt.ReportSource = inbound_rpt
            frm_printinbound.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
End Class