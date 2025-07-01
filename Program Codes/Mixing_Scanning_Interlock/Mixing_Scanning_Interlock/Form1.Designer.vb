<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.m_name = New System.Windows.Forms.Label()
        Me.lblplant = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.appendTagId = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status_date = New System.Windows.Forms.ToolStripStatusLabel()
        Me.status_time = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.login = New System.Windows.Forms.Timer(Me.components)
        Me.Substring = New System.Windows.Forms.Timer(Me.components)
        Me.concatenateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Blink = New System.Windows.Forms.Timer(Me.components)
        Me.Aweight = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.btn_oK = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.perkg = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtReceived = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.sv_loginTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.spScanner = New System.IO.Ports.SerialPort(Me.components)
        Me.txtRead = New System.Windows.Forms.TextBox()
        Me.lblPIC = New System.Windows.Forms.Label()
        Me.lblIDNo = New System.Windows.Forms.Label()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.lblSVinCHarge = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.txtinputS = New System.Windows.Forms.TextBox()
        Me.Panel4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.m_name)
        Me.Panel4.Controls.Add(Me.lblplant)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(651, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(351, 66)
        Me.Panel4.TabIndex = 407
        '
        'm_name
        '
        Me.m_name.AutoSize = True
        Me.m_name.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.m_name.ForeColor = System.Drawing.Color.White
        Me.m_name.Location = New System.Drawing.Point(31, 12)
        Me.m_name.Name = "m_name"
        Me.m_name.Size = New System.Drawing.Size(60, 32)
        Me.m_name.TabIndex = 444
        Me.m_name.Text = "-----"
        '
        'lblplant
        '
        Me.lblplant.AutoSize = True
        Me.lblplant.Location = New System.Drawing.Point(308, 3)
        Me.lblplant.Name = "lblplant"
        Me.lblplant.Size = New System.Drawing.Size(36, 13)
        Me.lblplant.TabIndex = 443
        Me.lblplant.Text = "[plant]"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(247, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 426
        Me.Label9.Text = "Version : 12012015"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(117, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 32)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = " INTERLOCK"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.lblID.Location = New System.Drawing.Point(143, 46)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 18)
        Me.lblID.TabIndex = 403
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.Location = New System.Drawing.Point(143, 69)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(0, 18)
        Me.lblDepartment.TabIndex = 404
        '
        'lblTitleR
        '
        Me.lblTitleR.AutoSize = True
        Me.lblTitleR.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleR.Location = New System.Drawing.Point(143, 94)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(0, 18)
        Me.lblTitleR.TabIndex = 405
        '
        'appendTagId
        '
        Me.appendTagId.BackColor = System.Drawing.SystemColors.Control
        Me.appendTagId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.appendTagId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.appendTagId.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.appendTagId.Location = New System.Drawing.Point(749, 727)
        Me.appendTagId.MaxLength = 500
        Me.appendTagId.Name = "appendTagId"
        Me.appendTagId.ReadOnly = True
        Me.appendTagId.Size = New System.Drawing.Size(270, 12)
        Me.appendTagId.TabIndex = 408
        Me.appendTagId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status_date, Me.status_time})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 692)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1016, 26)
        Me.StatusStrip1.TabIndex = 409
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status_date
        '
        Me.status_date.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.status_date.ForeColor = System.Drawing.Color.Red
        Me.status_date.Name = "status_date"
        Me.status_date.RightToLeftAutoMirrorImage = True
        Me.status_date.Size = New System.Drawing.Size(500, 21)
        Me.status_date.Spring = True
        Me.status_date.Text = "00-00-0000"
        Me.status_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'status_time
        '
        Me.status_time.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.status_time.ForeColor = System.Drawing.Color.Red
        Me.status_time.Name = "status_time"
        Me.status_time.Size = New System.Drawing.Size(500, 21)
        Me.status_time.Spring = True
        Me.status_time.Text = "00:00:00 00"
        Me.status_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimer
        '
        '
        'login
        '
        Me.login.Interval = 300
        '
        'Substring
        '
        Me.Substring.Interval = 500
        '
        'concatenateTimer
        '
        Me.concatenateTimer.Interval = 1500
        '
        'Aweight
        '
        Me.Aweight.BackColor = System.Drawing.Color.Black
        Me.Aweight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Aweight.Font = New System.Drawing.Font("Arial", 100.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aweight.ForeColor = System.Drawing.Color.White
        Me.Aweight.Location = New System.Drawing.Point(30, 16)
        Me.Aweight.MaxLength = 4
        Me.Aweight.Name = "Aweight"
        Me.Aweight.ReadOnly = True
        Me.Aweight.Size = New System.Drawing.Size(277, 154)
        Me.Aweight.TabIndex = 412
        Me.Aweight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button12)
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.btn_oK)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(8, 127)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 348)
        Me.Panel1.TabIndex = 416
        Me.Panel1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(542, 46)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "INPUT DESIRE LOAD BAGS"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.Red
        Me.Button12.Location = New System.Drawing.Point(397, 235)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(112, 83)
        Me.Button12.TabIndex = 84
        Me.Button12.Text = "CLEAR"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(397, 64)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(112, 83)
        Me.Button11.TabIndex = 83
        Me.Button11.Text = "0"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'btn_oK
        '
        Me.btn_oK.BackColor = System.Drawing.Color.White
        Me.btn_oK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_oK.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_oK.Location = New System.Drawing.Point(397, 150)
        Me.btn_oK.Name = "btn_oK"
        Me.btn_oK.Size = New System.Drawing.Size(112, 83)
        Me.btn_oK.TabIndex = 82
        Me.btn_oK.Text = "OK"
        Me.btn_oK.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(282, 235)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(112, 83)
        Me.Button9.TabIndex = 81
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(168, 235)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(112, 83)
        Me.Button8.TabIndex = 80
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(53, 235)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(112, 83)
        Me.Button7.TabIndex = 79
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(282, 150)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(112, 83)
        Me.Button6.TabIndex = 78
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(168, 150)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(112, 83)
        Me.Button5.TabIndex = 77
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(53, 150)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 83)
        Me.Button4.TabIndex = 76
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(282, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 83)
        Me.Button3.TabIndex = 75
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(168, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 83)
        Me.Button2.TabIndex = 74
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(53, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 83)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Aweight)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 175)
        Me.GroupBox1.TabIndex = 417
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LOAD BAGS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.perkg)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(7, 184)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 175)
        Me.GroupBox2.TabIndex = 418
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "KILOGRAM/BAGS"
        '
        'perkg
        '
        Me.perkg.BackColor = System.Drawing.Color.Black
        Me.perkg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.perkg.Font = New System.Drawing.Font("Arial", 100.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.perkg.ForeColor = System.Drawing.Color.White
        Me.perkg.Location = New System.Drawing.Point(28, 16)
        Me.perkg.MaxLength = 4
        Me.perkg.Name = "perkg"
        Me.perkg.ReadOnly = True
        Me.perkg.Size = New System.Drawing.Size(279, 154)
        Me.perkg.TabIndex = 412
        Me.perkg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SerialPort1
        '
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(498, 555)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "COMPORT NAME:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(599, 556)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 422
        Me.Label8.Text = "0000"
        '
        'txtReceived
        '
        Me.txtReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceived.Location = New System.Drawing.Point(663, 539)
        Me.txtReceived.Name = "txtReceived"
        Me.txtReceived.Size = New System.Drawing.Size(43, 30)
        Me.txtReceived.TabIndex = 424
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(659, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 15)
        Me.Label10.TabIndex = 425
        '
        'sv_loginTimer
        '
        Me.sv_loginTimer.Interval = 300
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Location = New System.Drawing.Point(792, 82)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(210, 36)
        Me.Panel3.TabIndex = 427
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.GroupBox2)
        Me.Panel5.Location = New System.Drawing.Point(662, 121)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(351, 366)
        Me.Panel5.TabIndex = 428
        '
        'spScanner
        '
        '
        'txtRead
        '
        Me.txtRead.Location = New System.Drawing.Point(5, 575)
        Me.txtRead.Name = "txtRead"
        Me.txtRead.ReadOnly = True
        Me.txtRead.Size = New System.Drawing.Size(1008, 20)
        Me.txtRead.TabIndex = 435
        Me.txtRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPIC
        '
        Me.lblPIC.BackColor = System.Drawing.SystemColors.Control
        Me.lblPIC.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.lblPIC.ForeColor = System.Drawing.Color.Black
        Me.lblPIC.Location = New System.Drawing.Point(112, 67)
        Me.lblPIC.Name = "lblPIC"
        Me.lblPIC.Size = New System.Drawing.Size(441, 30)
        Me.lblPIC.TabIndex = 438
        Me.lblPIC.Text = "Person In Charge:"
        Me.lblPIC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDNo
        '
        Me.lblIDNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblIDNo.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.lblIDNo.ForeColor = System.Drawing.Color.Black
        Me.lblIDNo.Location = New System.Drawing.Point(112, 37)
        Me.lblIDNo.Name = "lblIDNo"
        Me.lblIDNo.Size = New System.Drawing.Size(441, 30)
        Me.lblIDNo.TabIndex = 437
        Me.lblIDNo.Text = "ID No.:"
        Me.lblIDNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pic
        '
        Me.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic.ErrorImage = CType(resources.GetObject("pic.ErrorImage"), System.Drawing.Image)
        Me.pic.Location = New System.Drawing.Point(0, 1)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(107, 96)
        Me.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic.TabIndex = 436
        Me.pic.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.Black
        Me.lblMsg.Font = New System.Drawing.Font("Verdana", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMsg.Location = New System.Drawing.Point(1, 598)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(1012, 90)
        Me.lblMsg.TabIndex = 439
        Me.lblMsg.Text = "lblMessage"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Teal
        Me.Panel8.Controls.Add(Me.textBox1)
        Me.Panel8.Controls.Add(Me.Label29)
        Me.Panel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(518, 481)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(60, 24)
        Me.Panel8.TabIndex = 445
        Me.Panel8.Visible = False
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.Color.Teal
        Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBox1.Font = New System.Drawing.Font("Arial", 120.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.textBox1.Location = New System.Drawing.Point(3, 108)
        Me.textBox1.MaxLength = 4
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(564, 184)
        Me.textBox1.TabIndex = 413
        Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 34.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(0, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(572, 53)
        Me.Label29.TabIndex = 85
        Me.Label29.Text = "CHEMICAL  IN-PROCESS"
        '
        'pic2
        '
        Me.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic2.ErrorImage = CType(resources.GetObject("pic2.ErrorImage"), System.Drawing.Image)
        Me.pic2.Location = New System.Drawing.Point(5, 491)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(96, 78)
        Me.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic2.TabIndex = 447
        Me.pic2.TabStop = False
        '
        'lblSVinCHarge
        '
        Me.lblSVinCHarge.BackColor = System.Drawing.SystemColors.Control
        Me.lblSVinCHarge.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.lblSVinCHarge.ForeColor = System.Drawing.Color.Black
        Me.lblSVinCHarge.Location = New System.Drawing.Point(107, 539)
        Me.lblSVinCHarge.Name = "lblSVinCHarge"
        Me.lblSVinCHarge.Size = New System.Drawing.Size(361, 30)
        Me.lblSVinCHarge.TabIndex = 446
        Me.lblSVinCHarge.Text = "SV Person In Charge:"
        Me.lblSVinCHarge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.DarkRed
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(902, 504)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 64)
        Me.btnCancel.TabIndex = 448
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(420, 482)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 449
        Me.Button10.Text = "Send"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'txtinputS
        '
        Me.txtinputS.Location = New System.Drawing.Point(116, 484)
        Me.txtinputS.Name = "txtinputS"
        Me.txtinputS.Size = New System.Drawing.Size(298, 20)
        Me.txtinputS.TabIndex = 450
        Me.txtinputS.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 718)
        Me.Controls.Add(Me.txtinputS)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pic2)
        Me.Controls.Add(Me.lblSVinCHarge)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblPIC)
        Me.Controls.Add(Me.lblIDNo)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.txtRead)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtReceived)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.appendTagId)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.lblTitleR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents lblTitleR As System.Windows.Forms.Label
    Friend WithEvents appendTagId As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status_date As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents status_time As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DateTimer As System.Windows.Forms.Timer
    Friend WithEvents login As System.Windows.Forms.Timer
    Friend WithEvents Substring As System.Windows.Forms.Timer
    Friend WithEvents concatenateTimer As System.Windows.Forms.Timer
    Friend WithEvents Blink As System.Windows.Forms.Timer
    Friend WithEvents Aweight As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents btn_oK As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents perkg As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents sv_loginTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents spScanner As System.IO.Ports.SerialPort
    Private WithEvents txtRead As System.Windows.Forms.TextBox
    Protected WithEvents lblPIC As System.Windows.Forms.Label
    Protected WithEvents lblIDNo As System.Windows.Forms.Label
    Private WithEvents pic As System.Windows.Forms.PictureBox
    Private WithEvents lblMsg As System.Windows.Forms.Label
    Private WithEvents lblplant As System.Windows.Forms.Label
    Friend WithEvents m_name As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents pic2 As System.Windows.Forms.PictureBox
    Protected WithEvents lblSVinCHarge As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents txtinputS As System.Windows.Forms.TextBox

End Class
