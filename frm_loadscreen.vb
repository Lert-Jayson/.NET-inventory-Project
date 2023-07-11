Public Class frm_loadscreen

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            frm_main.Show()
            Me.Close()

        End If
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click
        Timer1.Start()
    End Sub
End Class