<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_printoutbound
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_exit = New System.Windows.Forms.Button
        Me.rptv_outbound = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.outbound_rpt1 = New InventorySample.outbound_rpt
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(902, 98)
        Me.Panel1.TabIndex = 35
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_exit.Location = New System.Drawing.Point(853, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(46, 39)
        Me.btn_exit.TabIndex = 1
        Me.btn_exit.Text = "X"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'rptv_outbound
        '
        Me.rptv_outbound.ActiveViewIndex = 0
        Me.rptv_outbound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptv_outbound.DisplayGroupTree = False
        Me.rptv_outbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptv_outbound.Location = New System.Drawing.Point(0, 98)
        Me.rptv_outbound.Name = "rptv_outbound"
        Me.rptv_outbound.ReportSource = Me.outbound_rpt1
        Me.rptv_outbound.Size = New System.Drawing.Size(902, 436)
        Me.rptv_outbound.TabIndex = 36
        '
        'frm_printoutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 534)
        Me.ControlBox = False
        Me.Controls.Add(Me.rptv_outbound)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frm_printoutbound"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents rptv_outbound As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents outbound_rpt1 As InventorySample.outbound_rpt
End Class
