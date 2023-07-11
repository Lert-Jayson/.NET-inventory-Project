<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_manageuser
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_exit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_fname = New System.Windows.Forms.TextBox
        Me.txt_lname = New System.Windows.Forms.TextBox
        Me.txt_uname = New System.Windows.Forms.TextBox
        Me.txt_pass = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.dg_user = New System.Windows.Forms.DataGridView
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btn_inpic = New System.Windows.Forms.Button
        Me.cb_pos = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_id = New System.Windows.Forms.TextBox
        Me.pic1 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.dg_user, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Location = New System.Drawing.Point(-1, -5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(738, 72)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cooper Black", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(215, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Manage Users"
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_exit.Location = New System.Drawing.Point(684, 17)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(34, 30)
        Me.btn_exit.TabIndex = 0
        Me.btn_exit.Text = "X"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name"
        '
        'txt_fname
        '
        Me.txt_fname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fname.Location = New System.Drawing.Point(201, 94)
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.Size = New System.Drawing.Size(194, 22)
        Me.txt_fname.TabIndex = 3
        '
        'txt_lname
        '
        Me.txt_lname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lname.Location = New System.Drawing.Point(401, 94)
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.Size = New System.Drawing.Size(158, 22)
        Me.txt_lname.TabIndex = 4
        '
        'txt_uname
        '
        Me.txt_uname.Location = New System.Drawing.Point(242, 153)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.Size = New System.Drawing.Size(268, 22)
        Me.txt_uname.TabIndex = 5
        '
        'txt_pass
        '
        Me.txt_pass.Location = New System.Drawing.Point(242, 205)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.Size = New System.Drawing.Size(268, 22)
        Me.txt_pass.TabIndex = 6
        Me.txt_pass.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(346, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Username"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(349, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Password"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Image = Global.InventorySample.My.Resources.Resources._287323758_526645515918416_5866577058563273420_n
        Me.Button1.Location = New System.Drawing.Point(594, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 40)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Save"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dg_user
        '
        Me.dg_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_user.Location = New System.Drawing.Point(91, 318)
        Me.dg_user.Name = "dg_user"
        Me.dg_user.RowTemplate.Height = 24
        Me.dg_user.Size = New System.Drawing.Size(566, 170)
        Me.dg_user.TabIndex = 11
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(516, 207)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_inpic
        '
        Me.btn_inpic.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btn_inpic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_inpic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_inpic.Location = New System.Drawing.Point(79, 207)
        Me.btn_inpic.Name = "btn_inpic"
        Me.btn_inpic.Size = New System.Drawing.Size(75, 23)
        Me.btn_inpic.TabIndex = 14
        Me.btn_inpic.Text = "Insert Photo"
        Me.btn_inpic.UseVisualStyleBackColor = False
        '
        'cb_pos
        '
        Me.cb_pos.FormattingEnabled = True
        Me.cb_pos.Location = New System.Drawing.Point(242, 255)
        Me.cb_pos.Name = "cb_pos"
        Me.cb_pos.Size = New System.Drawing.Size(268, 20)
        Me.cb_pos.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(349, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Position"
        '
        'txt_id
        '
        Me.txt_id.Enabled = False
        Me.txt_id.Location = New System.Drawing.Point(79, 255)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(63, 22)
        Me.txt_id.TabIndex = 17
        '
        'pic1
        '
        Me.pic1.BackgroundImage = Global.InventorySample.My.Resources.Resources.d5b04cc3dcd8c17702549ebc5f1acf1a
        Me.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic1.Location = New System.Drawing.Point(61, 96)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(117, 105)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic1.TabIndex = 13
        Me.pic1.TabStop = False
        '
        'frm_manageuser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(729, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.txt_id)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cb_pos)
        Me.Controls.Add(Me.btn_inpic)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.dg_user)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_pass)
        Me.Controls.Add(Me.txt_uname)
        Me.Controls.Add(Me.txt_lname)
        Me.Controls.Add(Me.txt_fname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_manageuser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg_user, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents txt_pass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dg_user As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_inpic As System.Windows.Forms.Button
    Friend WithEvents cb_pos As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
End Class
