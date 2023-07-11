Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Security.Cryptography
Imports System.Data.DataSet
Imports System.Data.DataTable
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frm_login
    Dim mycmd As New OdbcCommand
    Dim readUser As OdbcDataReader


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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            txt_pass.UseSystemPasswordChar = False

        Else

            txt_pass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        connectMe()
        Try

            With mycmd
                .Connection = con
                .CommandText = "select * from user_tbl where uname = '" & txt_uname.Text & "' and pass = MD5('" & txt_pass.Text & "')"
                .ExecuteNonQuery()
            End With
            readUser = mycmd.ExecuteReader
            If readUser.HasRows Then
                readUser.Read()
                username1 = readUser!fname & " " & readUser!lname
                usertype = readUser!pos
                picture = readUser!img

                

                Dim loading As New frm_loadscreen

                Me.Hide()
                loading.Show()

                txt_uname.Clear()
                txt_pass.Clear()
                txt_uname.Focus()
            Else
                MessageBox.Show("Username and password do not match.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_uname.Clear()
                txt_pass.Clear()

                txt_uname.Focus()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
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
                MessageBox.Show("Fill in Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_pass.Focus()
            Else
                btn_login.Focus()
            End If
        End If
    End Sub

    Private Sub frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
   
End Class