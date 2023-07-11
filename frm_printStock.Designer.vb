<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_printStock
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
        Me.cb_search = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.print_stockreport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.stock_report1 = New InventorySample.stock_report
        Me.Button1 = New System.Windows.Forms.Button
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.cb_search)
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 117)
        Me.Panel1.TabIndex = 33
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_exit.Location = New System.Drawing.Point(873, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(46, 39)
        Me.btn_exit.TabIndex = 1
        Me.btn_exit.Text = "X"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'cb_search
        '
        Me.cb_search.FormattingEnabled = True
        Me.cb_search.Location = New System.Drawing.Point(47, 22)
        Me.cb_search.Name = "cb_search"
        Me.cb_search.Size = New System.Drawing.Size(198, 20)
        Me.cb_search.TabIndex = 31
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(251, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 25)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "View"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'print_stockreport
        '
        Me.print_stockreport.ActiveViewIndex = 0
        Me.print_stockreport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.print_stockreport.DisplayGroupTree = False
        Me.print_stockreport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.print_stockreport.Location = New System.Drawing.Point(0, 123)
        Me.print_stockreport.Name = "print_stockreport"
        Me.print_stockreport.ReportSource = Me.stock_report1
        Me.print_stockreport.Size = New System.Drawing.Size(922, 421)
        Me.print_stockreport.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(47, 69)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 31)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(417, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(151, 23)
        Me.RadioButton1.TabIndex = 36
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Negative Stocks"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(417, 69)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(118, 23)
        Me.RadioButton2.TabIndex = 37
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Zero Stocks"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'frm_printStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(922, 544)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.print_stockreport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frm_printStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents print_stockreport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents stock_report1 As InventorySample.stock_report
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents cb_search As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
