Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_customer
    Dim mycmd As New OdbcCommand
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frm_customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(cust_id),0) from customer_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_cid()
        Else
            txt_cid.Text = 1
        End If
        txt_cname.Focus()

        Dim mycmd As New OdbcCommand("select cust_id as 'Customer ID',cname as 'Customer Name', pnum as 'Phone Number', addr as 'Address' from customer_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "customer_tbl")

        dg_clist.DataSource = ds.Tables(0)
        dg_clist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_clist.Refresh()

        btn_edit.Enabled = False
        btn_update.Enabled = False
        btn_delete.Enabled = False

        If usertype = "USER" Then
            btn_edit.Hide()
            btn_update.Hide()
            btn_delete.Hide()
        End If

    End Sub

    Public Sub get_cid()
        Dim da As New OdbcDataAdapter("select max(cust_id) cid1 from customer_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_cid.Text = ds.Tables(0).Rows(0).Item("cid1") + 1
    End Sub

    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select cust_id as 'Customer ID',cname as 'Customer Name', pnum as 'Phone Number', addr as 'Address' from customer_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "customer_tbl")

            dg_clist.DataSource = ds.Tables(0)
            dg_clist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_clist.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim id As String
        Dim cname As String

        Dim pnum As String
        Dim addr As String

        id = txt_cid.Text
        cname = txt_cname.Text.ToUpper

        pnum = txt_pnum.Text
        addr = txt_addr.Text.ToUpper

        con.Close()

        Try
            con.Open()
            Dim dr As OdbcDataReader
            Dim cmd As New OdbcCommand("select * from customer_tbl where cname = '" & cname & "' ", con)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                MessageBox.Show("Error: Duplicate Record." & " " & cname & " is already created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            Else
                With mycmd
                    .Connection = con
                    .CommandText = "insert into customer_tbl values ('" & id & "','" & cname & "','" & pnum & "','" & addr & "')"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Customer Information Added", "Add Customer Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                frm_home.Refresh()
                txt_cname.Clear()

                txt_pnum.Clear()
                txt_addr.Clear()

                Call get_cid()

                txt_cname.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dg_clist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_clist.CellContentClick
        Dim i As Integer
        i = dg_clist.CurrentRow.Index
        txt_cid.Text = dg_clist.Item(0, i).Value
        txt_cname.Text = dg_clist.Item(1, i).Value

        txt_pnum.Text = dg_clist.Item(2, i).Value
        txt_addr.Text = dg_clist.Item(3, i).Value

        txt_cname.Enabled = False

        txt_pnum.Enabled = False
        txt_addr.Enabled = False

        btn_save.Enabled = False
        btn_edit.Enabled = True
        btn_update.Enabled = True
        btn_delete.Enabled = True

    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        txt_cname.Enabled = True

        txt_pnum.Enabled = True
        txt_addr.Enabled = True

        btn_save.Enabled = False
        btn_delete.Enabled = False

    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim id1 As String
        Dim cname1 As String

        Dim pnum1 As String
        Dim addr1 As String

        id1 = txt_cid.Text
        cname1 = txt_cname.Text.ToUpper

        pnum1 = txt_pnum.Text
        addr1 = txt_addr.Text.ToUpper

        con.Close()

        Try
            con.Open()

            With mycmd
                .Connection = con
                .CommandText = "update customer_tbl set cust_id = '" & id1 & "', cname = '" & cname1 & "', pnum = '" & pnum1 & "', addr = '" & addr1 & "' where cust_id = '" & id1 & "' "
                .ExecuteNonQuery()

            End With

            MessageBox.Show("Record is updated!", "Update Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshMe()


            txt_cname.Clear()

            txt_pnum.Clear()
            txt_addr.Clear()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()

        End Try

    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim id2 As String
        Dim result1 As New DialogResult

        id2 = txt_cid.Text

        con.Close()
        Try
            con.Open()

            result1 = MessageBox.Show("Are you sure you want to delete the record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result1 = System.Windows.Forms.DialogResult.Yes Then
                With mycmd
                    .Connection = con
                    .CommandText = "delete from customer_tbl where cust_id= '" & id2 & "'"
                    .ExecuteNonQuery()
                End With
                MessageBox.Show("Record is deleted!", "Delete Student Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshMe()

                txt_cname.Clear()

                txt_pnum.Clear()
                txt_addr.Clear()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    

    Private Sub txt_cname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cname.KeyDown
        If e.KeyCode = 13 Then
            If txt_cname.Text = "" Then
                MessageBox.Show("Fill in First Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_cname.Focus()
            Else
                txt_pnum.Focus()
            End If
        End If
    End Sub

 

    Private Sub txt_pnum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pnum.KeyDown
        If e.KeyCode = 13 Then
            If txt_pnum.Text = "" Then
                MessageBox.Show("Fill in Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_pnum.Focus()
            Else
                txt_addr.Focus()
            End If
        End If
    End Sub

    Private Sub txt_addr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_addr.KeyDown
        If e.KeyCode = 13 Then
            If txt_addr.Text = "" Then
                MessageBox.Show("Fill in Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_addr.Focus()
            Else
                btn_save.Focus()
            End If
        End If
    End Sub



    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        Dim mycmd As New OdbcCommand("select cust_id as 'Customer ID',cname as 'Customer Name', pnum as 'Phone Number', addr as 'Address' from customer_tbl where cname like '%" & txt_search.Text & "%'", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "customer_tbl")

        dg_clist.DataSource = ds.Tables(0)
        dg_clist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg_clist.Refresh()
    End Sub
End Class