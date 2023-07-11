Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_products
    Dim mycmd As New OdbcCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frm_products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()



        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(prod_id),0) from products_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_pid()
        Else
            txt_id.Text = 1
        End If
        txt_pname.Focus()


        Dim mycmd As New OdbcCommand("select prod_id as 'ID', prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', price as 'Price', loc as 'Location' from products_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "products_tbl")

        dg_plist.DataSource = ds.Tables(0)
        dg_plist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_plist.Refresh()

        'Dim mycmd2 As New OdbcCommand("select gname from group_tbl order by gname asc", con)
        'Dim da1 As New OdbcDataAdapter(mycmd2)
        'Dim dt As New System.Data.DataTable
        'Dim st As Integer
        'st = 0

        'da1.Fill(dt)
        'While st <> dt.Rows.Count
        '    cb_group.Items.Add(dt.Rows.Item(st).Item("gname"))
        '    st += 1
        'End While
        prodgruop()
        produom()
        'Dim mycmd3 As New OdbcCommand("select uom from uom_tbl order by uom asc", con)
        'Dim da2 As New OdbcDataAdapter(mycmd3)
        'Dim dt1 As New System.Data.DataTable
        'Dim st1 As Integer
        'st1 = 0

        'da2.Fill(dt)
        'While st1 <> dt1.Rows.Count
        '    cb_uom.Items.Add(dt1.Rows.Item(st1).Item("uom"))
        '    st1 += 1
        'End While



        If usertype = "USER" Then
            btn_edit.Hide()
            btn_update.Hide()
            btn_delete.Hide()
        End If
    End Sub
    Function getTransno() As String
        Try
            Dim sdate As String = Now.ToString("yyyy")
            Dim cmd As New OdbcCommand("select * from products_tbl where prod_code like '" & sdate & "%' order by prod_id desc", con)
            Dim dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                getTransno = CLng(dr.Item("prod_code").ToString) + 1
            Else
                getTransno = sdate & "0001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Function

    Sub produom()

        cb_uom.Items.Clear()
        Dim mycmd As New OdbcCommand("select * from uom_tbl", con)
        Dim dr = mycmd.ExecuteReader
        While dr.Read
            cb_uom.Items.Add(dr.GetString(1))
        End While
        dr.Close()


    End Sub
    Sub prodgruop()

        cb_group.Items.Clear()
        Dim mycmd As New OdbcCommand("select * from group_tbl", con)
        Dim dr = mycmd.ExecuteReader
        While dr.Read
            cb_group.Items.Add(dr.GetString(1))
        End While
        dr.Close()


    End Sub
    Public Sub get_pid()
        Dim da As New OdbcDataAdapter("select max(prod_id) pid1 from products_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_id.Text = ds.Tables(0).Rows(0).Item("pid1") + 1
    End Sub

    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select prod_id as 'ID', prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', price as 'Price', loc as 'Location' from products_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "products_tbl")

            dg_plist.DataSource = ds.Tables(0)
            dg_plist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_plist.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim id As String
        Dim prodcode As String
        Dim prodname As String
        Dim grp As String
        Dim uom As String
        Dim price As String
        Dim loc As String
        Dim stock As Integer

        id = txt_id.Text
        prodcode = txt_pcode.Text
        prodname = txt_pname.Text.ToUpper
        grp = cb_group.SelectedItem
        uom = cb_uom.SelectedItem
        price = txt_price.Text
        loc = txt_loc.Text

        stock = 0

        con.Close()

        Try
            con.Open()
            Dim dr As OdbcDataReader
            Dim cmd As New OdbcCommand("select * from products_tbl where prod_code = '" & prodcode & "' and prod_name = '" & prodname & "'", con)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                MessageBox.Show("Error: Duplicate Record." & " " & prodcode & " " & prodname & " is already created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            Else
                With mycmd
                    .Connection = con
                    .CommandText = "insert into products_tbl values ('" & id & "','" & prodcode & "','" & prodname & "','" & grp & "','" & uom & "','" & price & "','" & loc & "','" & stock & "')"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Product Information Added", "Add Product Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                txt_pcode.Clear()
                txt_pname.Clear()
                cb_group.SelectedIndex = -1
                cb_uom.SelectedIndex = -1
                txt_price.Clear()
                txt_loc.Clear()

                frm_stock.Refresh()
                frm_home.Refresh()
                Call get_pid()
                txt_pcode.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btn_addgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addgroup.Click
        frm_group.ShowDialog()
    End Sub

    Private Sub btn_adduom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_adduom.Click
        frm_uom.ShowDialog()
    End Sub

    Private Sub dg_plist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_plist.CellContentClick
        Dim i As Integer
        i = dg_plist.CurrentRow.Index
        txt_id.Text = dg_plist.Item(0, i).Value
        txt_pcode.Text = dg_plist.Item(1, i).Value
        txt_pname.Text = dg_plist.Item(2, i).Value
        cb_group.Text = dg_plist.Item(3, i).Value
        cb_group.SelectedValue = dg_plist.Item(3, i).Value
        cb_uom.Text = dg_plist.Item(4, i).Value
        cb_uom.SelectedValue = dg_plist.Item(4, i).Value
        txt_price.Text = dg_plist.Item(5, i).Value
        txt_loc.Text = dg_plist.Item(6, i).Value

        txt_pcode.Enabled = False
        txt_pname.Enabled = False
        cb_group.Enabled = False
        cb_uom.Enabled = False
        txt_price.Enabled = False
        txt_loc.Enabled = False

        btn_save.Enabled = False
        btn_edit.Enabled = True
        btn_update.Enabled = True
        btn_delete.Enabled = True
        

    End Sub

    Private Sub btn_g_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_g.Click
        txt_pcode.Text = getTransno()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        txt_pcode.Enabled = True
        txt_pname.Enabled = True
        cb_group.Enabled = True
        cb_uom.Enabled = True
        txt_price.Enabled = True
        txt_loc.Enabled = True

        btn_save.Enabled = False
        btn_edit.Enabled = True
        btn_update.Enabled = True
        btn_delete.Enabled = False
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim id1 As String
        Dim prodcode1 As String
        Dim prodname1 As String
        Dim grp1 As String
        Dim uom1 As String
        Dim price1 As String
        Dim loc1 As String

        id1 = txt_id.Text
        prodcode1 = txt_pcode.Text
        prodname1 = txt_pname.Text.ToUpper
        grp1 = cb_group.SelectedItem
        uom1 = cb_uom.SelectedItem
        price1 = txt_price.Text
        loc1 = txt_loc.Text

        con.Close()
        Try
            con.Open()

            With mycmd
                .Connection = con
                .CommandText = "update products_tbl set prod_id = '" & id1 & "', prod_code = '" & prodcode1 & "', prod_name = '" & prodname1 & "', prod_group = '" & grp1 & "', uom = '" & uom1 & "', price = '" & price1 & "', loc = '" & loc1 & "' where prod_id = '" & id1 & "'"
                .ExecuteNonQuery()

            End With

            MessageBox.Show("Record is updated!", "Update Products Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshMe()

            txt_id.Clear()
            txt_pcode.Clear()
            txt_pname.Clear()
            cb_group.SelectedIndex = -1
            cb_uom.SelectedIndex = -1
            txt_price.Clear()
            txt_loc.Clear()

            btn_save.Enabled = False
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

        id2 = txt_id.Text

        con.Close()
        Try
            con.Open()

            result1 = MessageBox.Show("Are you sure you want to delete the record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result1 = System.Windows.Forms.DialogResult.Yes Then
                With mycmd
                    .Connection = con
                    .CommandText = "delete from products_tbl where prod_id= '" & id2 & "'"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Record is deleted!", "Delete Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                txt_id.Clear()
                txt_pcode.Clear()
                txt_pname.Clear()
                cb_group.SelectedIndex = -1
                cb_uom.SelectedIndex = -1
                txt_price.Clear()
                txt_loc.Clear()

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

   

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged

        Dim mycmd As New OdbcCommand("select prod_id as 'ID', prod_code as 'Product Code',prod_name as 'Product Name', prod_group as 'Group', uom as 'Unit of Measure', price as 'Price', loc as 'Location' from products_tbl where prod_code like '%" & txt_search.Text & "%' or prod_name like '%" & txt_search.Text & "%'", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "products_tbl")

        dg_plist.DataSource = ds.Tables(0)
        dg_plist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_plist.Refresh()

    End Sub
End Class