<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_products
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btn_g = New System.Windows.Forms.Button
        Me.txt_id = New System.Windows.Forms.TextBox
        Me.cb_uom = New System.Windows.Forms.ComboBox
        Me.cb_group = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_pname = New System.Windows.Forms.TextBox
        Me.txt_price = New System.Windows.Forms.TextBox
        Me.txt_pcode = New System.Windows.Forms.TextBox
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_update = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.dg_plist = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_search = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_adduom = New InventorySample.RoundButton
        Me.btn_addgroup = New InventorySample.RoundButton
        Me.txt_loc = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dg_plist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 77)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 34)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Manage Products"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 77)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "<"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel2.Controls.Add(Me.btn_g)
        Me.Panel2.Controls.Add(Me.txt_id)
        Me.Panel2.Controls.Add(Me.cb_uom)
        Me.Panel2.Controls.Add(Me.cb_group)
        Me.Panel2.Controls.Add(Me.btn_adduom)
        Me.Panel2.Controls.Add(Me.btn_addgroup)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txt_loc)
        Me.Panel2.Controls.Add(Me.txt_pname)
        Me.Panel2.Controls.Add(Me.txt_price)
        Me.Panel2.Controls.Add(Me.txt_pcode)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(37, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(840, 197)
        Me.Panel2.TabIndex = 1
        '
        'btn_g
        '
        Me.btn_g.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_g.Location = New System.Drawing.Point(334, 37)
        Me.btn_g.Name = "btn_g"
        Me.btn_g.Size = New System.Drawing.Size(71, 25)
        Me.btn_g.TabIndex = 17
        Me.btn_g.Text = "Generate"
        Me.btn_g.UseVisualStyleBackColor = True
        '
        'txt_id
        '
        Me.txt_id.Enabled = False
        Me.txt_id.Location = New System.Drawing.Point(43, 12)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(40, 21)
        Me.txt_id.TabIndex = 16
        Me.txt_id.Visible = False
        '
        'cb_uom
        '
        Me.cb_uom.FormattingEnabled = True
        Me.cb_uom.Location = New System.Drawing.Point(450, 89)
        Me.cb_uom.Name = "cb_uom"
        Me.cb_uom.Size = New System.Drawing.Size(284, 23)
        Me.cb_uom.TabIndex = 15
        '
        'cb_group
        '
        Me.cb_group.FormattingEnabled = True
        Me.cb_group.Location = New System.Drawing.Point(43, 89)
        Me.cb_group.Name = "cb_group"
        Me.cb_group.Size = New System.Drawing.Size(284, 23)
        Me.cb_group.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(561, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Location"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(547, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Unit of Measure"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(547, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Product Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(159, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Price "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(143, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Product Code"
        '
        'txt_pname
        '
        Me.txt_pname.Location = New System.Drawing.Point(450, 42)
        Me.txt_pname.Name = "txt_pname"
        Me.txt_pname.Size = New System.Drawing.Size(284, 21)
        Me.txt_pname.TabIndex = 3
        '
        'txt_price
        '
        Me.txt_price.Location = New System.Drawing.Point(43, 132)
        Me.txt_price.Name = "txt_price"
        Me.txt_price.Size = New System.Drawing.Size(284, 21)
        Me.txt_price.TabIndex = 2
        '
        'txt_pcode
        '
        Me.txt_pcode.Location = New System.Drawing.Point(43, 42)
        Me.txt_pcode.Name = "txt_pcode"
        Me.txt_pcode.Size = New System.Drawing.Size(284, 21)
        Me.txt_pcode.TabIndex = 0
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btn_delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_delete.Image = Global.InventorySample.My.Resources.Resources._281354233_1217761045703395_6220257735197044251_n
        Me.btn_delete.Location = New System.Drawing.Point(762, 311)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(103, 39)
        Me.btn_delete.TabIndex = 22
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'btn_update
        '
        Me.btn_update.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btn_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_update.Image = Global.InventorySample.My.Resources.Resources._285542725_506663994541582_4938205829804285708_n
        Me.btn_update.Location = New System.Drawing.Point(653, 311)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(103, 39)
        Me.btn_update.TabIndex = 21
        Me.btn_update.Text = "Update"
        Me.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_update.UseVisualStyleBackColor = False
        '
        'btn_edit
        '
        Me.btn_edit.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btn_edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_edit.Image = Global.InventorySample.My.Resources.Resources._286996311_369707855048562_4211644717428734689_n
        Me.btn_edit.Location = New System.Drawing.Point(540, 311)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(103, 39)
        Me.btn_edit.TabIndex = 20
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_edit.UseVisualStyleBackColor = False
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_save.Image = Global.InventorySample.My.Resources.Resources._287323758_526645515918416_5866577058563273420_n
        Me.btn_save.Location = New System.Drawing.Point(431, 311)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(103, 39)
        Me.btn_save.TabIndex = 19
        Me.btn_save.Text = "Save"
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'dg_plist
        '
        Me.dg_plist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_plist.BackgroundColor = System.Drawing.Color.White
        Me.dg_plist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_plist.Location = New System.Drawing.Point(37, 378)
        Me.dg_plist.Name = "dg_plist"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_plist.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_plist.RowTemplate.Height = 24
        Me.dg_plist.Size = New System.Drawing.Size(840, 218)
        Me.dg_plist.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(99, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(194, 12)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "(Enter Product Name or Code to Search)"
        '
        'txt_search
        '
        Me.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_search.Location = New System.Drawing.Point(37, 323)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(366, 22)
        Me.txt_search.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.InventorySample.My.Resources.Resources._277105611_3083367841925090_4463837430406016997_n
        Me.PictureBox1.Location = New System.Drawing.Point(206, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btn_adduom
        '
        Me.btn_adduom.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btn_adduom.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btn_adduom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_adduom.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_adduom.Location = New System.Drawing.Point(740, 79)
        Me.btn_adduom.Name = "btn_adduom"
        Me.btn_adduom.Size = New System.Drawing.Size(49, 36)
        Me.btn_adduom.TabIndex = 13
        Me.btn_adduom.Text = "+"
        Me.btn_adduom.UseVisualStyleBackColor = False
        '
        'btn_addgroup
        '
        Me.btn_addgroup.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btn_addgroup.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btn_addgroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_addgroup.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_addgroup.Location = New System.Drawing.Point(333, 79)
        Me.btn_addgroup.Name = "btn_addgroup"
        Me.btn_addgroup.Size = New System.Drawing.Size(49, 36)
        Me.btn_addgroup.TabIndex = 12
        Me.btn_addgroup.Text = "+"
        Me.btn_addgroup.UseVisualStyleBackColor = False
        '
        'txt_loc
        '
        Me.txt_loc.Location = New System.Drawing.Point(450, 132)
        Me.txt_loc.Name = "txt_loc"
        Me.txt_loc.Size = New System.Drawing.Size(284, 21)
        Me.txt_loc.TabIndex = 5
        '
        'frm_products
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(889, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.dg_plist)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_products"
        Me.Text = "frm_products"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dg_plist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_pname As System.Windows.Forms.TextBox
    Friend WithEvents txt_price As System.Windows.Forms.TextBox
    Friend WithEvents txt_pcode As System.Windows.Forms.TextBox
    Friend WithEvents btn_adduom As InventorySample.RoundButton
    Friend WithEvents btn_addgroup As InventorySample.RoundButton
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents dg_plist As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents cb_uom As System.Windows.Forms.ComboBox
    Friend WithEvents cb_group As System.Windows.Forms.ComboBox
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents btn_g As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_loc As System.Windows.Forms.TextBox
End Class
