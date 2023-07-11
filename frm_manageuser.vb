Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO


Public Class frm_manageuser
    Dim mycmd As New OdbcCommand
    Dim result As Integer
    Dim imgpath As String
    Dim arrImage() As Byte
    Dim conn As New MySqlConnection
    Dim Myconnection As String = "server=localhost;user id=root;password=;database=inventory_db"
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim sql As String


    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            txt_pass.UseSystemPasswordChar = False

        Else

            txt_pass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub frm_manageuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connectMe()

        txt_fname.Focus()

        cb_pos.Items.Add("ADMIN")
        cb_pos.Items.Add("USER")

        Dim sid As Integer
        Dim cmd As New OdbcCommand("select ifnull(max(id),0) from user_tbl", con)
        sid = cmd.ExecuteScalar

        If sid > 0 Then
            Call get_id()
        Else
            txt_id.Text = 1
        End If
        txt_fname.Focus()

        Dim mycmd As New OdbcCommand("select fname as 'First Name', lname as 'Last Name', uname as 'UserName', pos as 'Designation', img from user_tbl", con)
        Dim da As New OdbcDataAdapter(mycmd)
        Dim ds As New System.Data.DataSet

        da.Fill(ds, "user_tbl")
        dg_user.DataSource = ds.Tables(0)
        dg_user.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
     
        dg_user.Refresh()

    End Sub
    Public Sub refreshMe()
        con.Close()

        Try
            con.Open()

            Dim mycmd As New OdbcCommand("select fname as 'First Name', lname as 'Last Name', uname as 'UserName', pos as 'Designation', img from user_tbl", con)
            Dim da As New OdbcDataAdapter(mycmd)
            Dim ds As New System.Data.DataSet

            da.Fill(ds, "user_tbl")
            dg_user.DataSource = ds.Tables(0)
            dg_user.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dg_user.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim mstream As New System.IO.MemoryStream()
            pic1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = mstream.GetBuffer()
            Dim FileSize As UInt32
            FileSize = mstream.Length

            mstream.Close()
            conn.ConnectionString = Myconnection
            conn.Open()
            sql = "INSERT INTO user_tbl(id,fname,lname, uname, pass, pos, img) VALUES (@id,@fname, @lname, @uname, @pass, @pos, @img)"
            cmd.Connection = conn
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@id", txt_id.Text)
            cmd.Parameters.AddWithValue("@fname", txt_fname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@lname", txt_lname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@uname", txt_uname.Text)
            cmd.Parameters.AddWithValue("@pass", MD5(txt_pass.Text))
            cmd.Parameters.AddWithValue("@pos", cb_pos.SelectedItem)
            cmd.Parameters.AddWithValue("@img", arrImage)
            Dim r As Integer
            r = cmd.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("User info hass been Saved!")
            Else
                MsgBox("No record has been saved!")
            End If
            cmd.Parameters.Clear()
            conn.Close()

            txt_fname.Clear()
            txt_lname.Clear()
            txt_uname.Clear()
            txt_pass.Clear()
            cb_pos.SelectedIndex = -1
            pic1.Image = Nothing

            Call get_id()

            txt_fname.Focus()

            refreshMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

       

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inpic.Click
        Try
            Dim OFD As FileDialog = New OpenFileDialog()

            OFD.Filter = "Image File (*.jpg;*.bmp;*.gif) |*.jpg;*.bmp;*.gif"

            If OFD.ShowDialog() = DialogResult.OK Then
                imgpath = OFD.FileName
                pic1.ImageLocation = imgpath

            End If

            OFD = Nothing


        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try

    End Sub
    Private Function MD5(ByVal sPassword As String) As String
        Dim p As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(sPassword)
        bs = p.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Return s.ToString()
    End Function

    Private Sub dg_user_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_user.CellContentClick
        Dim i As Integer
        i = dg_user.CurrentRow.Index
        txt_fname.Text = dg_user.Item(0, i).Value
        txt_lname.Text = dg_user.Item(1, i).Value
        txt_uname.Text = dg_user.Item(2, i).Value
        cb_pos.Text = dg_user.Item(3, i).Value
        cb_pos.SelectedValue = dg_user.Item(3, i).Value

        Dim bytes As [Byte]() = dg_user.CurrentRow.Cells(4).Value
        Dim ms As New MemoryStream(bytes)
        pic1.Image = Image.FromStream(ms)

        txt_lname.Enabled = False
        txt_fname.Enabled = False
        txt_uname.Enabled = False
        txt_pass.Enabled = False
        cb_pos.Enabled = False
        btn_inpic.Enabled = False


    End Sub

    Public Sub get_id()
        Dim da As New OdbcDataAdapter("select max(id) id1 from user_tbl", con)
        Dim ds As New System.Data.DataSet
        da.Fill(ds)

        txt_id.Text = ds.Tables(0).Rows(0).Item("id1") + 1
    End Sub

    Private Sub txt_fname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fname.KeyDown
        If e.KeyCode = 13 Then
            If txt_fname.Text = "" Then
                MessageBox.Show("Fill in First Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_fname.Focus()
            Else
                txt_lname.Focus()
            End If
        End If
    End Sub

    Private Sub txt_lname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_lname.KeyDown
        If e.KeyCode = 13 Then
            If txt_lname.Text = "" Then
                MessageBox.Show("Fill in Last Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_lname.Focus()
            Else
                txt_uname.Focus()
            End If
        End If
    End Sub

    Private Sub txt_uname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_uname.KeyDown
        If e.KeyCode = 13 Then
            If txt_uname.Text = "" Then
                MessageBox.Show("Fill in Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_uname.Focus()
            Else
                txt_pass.Focus()
            End If
        End If
    End Sub

    Private Sub txt_pass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pass.KeyDown
        If e.KeyCode = 13 Then
            If txt_pass.Text = "" Then
                MessageBox.Show("Fill in password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_pass.Focus()
            Else
                cb_pos.Focus()
            End If
        End If
    End Sub
End Class