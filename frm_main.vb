Public Class frm_main


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_manageuser.Click
        'With frm_manageuser
        '    .TopLevel = False
        '    panel_display.Controls.Add(frm_manageuser)
        '    .BringToFront()
        '    .Show()
        'End With

        frm_manageuser.ShowDialog()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim result1 As New DialogResult

        result1 = MessageBox.Show("Are you sure you want to exit the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result1 = System.Windows.Forms.DialogResult.Yes Then
            End
        End If



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frm_home.Dispose()
        With frm_customer
            .TopLevel = False
            panel_display.Controls.Add(frm_customer)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frm_home.Dispose()
        With frm_products
            .TopLevel = False
            panel_display.Controls.Add(frm_products)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frm_home.Dispose()
        With frm_stock
            .TopLevel = False
            panel_display.Controls.Add(frm_stock)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frm_home.Dispose()
        With frm_inbound
            .TopLevel = False
            panel_display.Controls.Add(frm_inbound)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frm_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_uname.Text = username1.ToUpper.Trim
        lbl_role.Text = usertype.ToUpper.Trim

        Dim mstream As New System.IO.MemoryStream(picture)
        pic.Image = Image.FromStream(mstream)


        If usertype = "USER" Then
            btn_manageuser.Hide()
        End If

        With frm_home
            .TopLevel = False
            panel_display.Controls.Add(frm_home)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_home
            .Refresh()
            .TopLevel = False
            panel_display.Controls.Add(frm_home)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frm_home.Dispose()
        With frm_outbound
            .TopLevel = False
            panel_display.Controls.Add(frm_outbound)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Dispose()
        frm_login.Show()
    End Sub

End Class