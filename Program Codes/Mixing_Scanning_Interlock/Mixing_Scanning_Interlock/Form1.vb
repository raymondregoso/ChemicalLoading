Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread
Imports System.IO.Ports.SerialPort
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Public Class Form1
#Region "VALUES FOR DIMS FROM THE PATH"
    Dim tank1 As String
    Dim tank2 As String
    Dim tank3 As String
    Dim tank4 As String
    Dim tank5 As String
    Dim tank6 As String
    Dim tank7 As String
    Dim tank8 As String
    Dim tank9 As String
    Dim tank10 As String
    Dim tank11 As String
    Dim tank12 As String
    Dim tank13 As String
    Dim tank14 As String
#End Region
    Private selectedColor As Color
    Dim selectedBtn As Button
    Friend pinString As String
    Dim material_no As String

#Region "Global Variables"
    Dim WithEvents SerialPort As New IO.Ports.SerialPort
    'Dim Connect_String As String = "data source=barcode;user id=ramon;password=systems"
    'Dim CnnString_FX11 As String = "data source=FX11;user id=tscb;password=tscb"
    Dim Connect_String As String = "data source=192.168.1.1; user id=root; password=;database=send_report_output"
    Dim AllPath As String = AppDomain.CurrentDomain.BaseDirectory + "Settings.txt"
    Private sArticleNo, sLabelNo, sWeight, sExpDate As String
    Private _calculateActualLoad As Integer
#End Region
    Dim RXbyte As Byte
    <DllImport("user32")> _
    Private Shared Function HideCaret(ByVal hWnd As IntPtr) As Integer
    End Function
    Public Sub outputReset()

    End Sub
#Region "FORM LOADING"

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If (SerialPort.IsOpen() = True) Then
                SerialPort.Close()
            End If
        Catch ex As Exception
            End
        End Try
        End
    End Sub
    Dim allLines As List(Of String) = New List(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim reader As New System.IO.StreamReader(AllPath)

            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()
            ' Read Tags
            tank1 = ReadLine(6, allLines)
            tank2 = ReadLine(7, allLines)
            tank3 = ReadLine(8, allLines)
            tank4 = ReadLine(9, allLines)
            tank5 = ReadLine(10, allLines)
            tank6 = ReadLine(11, allLines)
            tank7 = ReadLine(12, allLines)
            tank8 = ReadLine(13, allLines)
            tank9 = ReadLine(14, allLines)
            tank10 = ReadLine(15, allLines)
            tank11 = ReadLine(16, allLines)
            tank12 = ReadLine(17, allLines)
            tank13 = ReadLine(18, allLines)
            tank14 = ReadLine(19, allLines)

            '  Label2.Visible = True
            Label8.Text = ReadLine(4, allLines)
            m_name.Text = ReadLine(2, allLines)
            lblplant.Text = ReadLine(3, allLines)
            
            ConnectSerial() ' --if the scanner is available uncomment this
           
            DateTimer.Enabled = True

            

            If Label8.Text = ReadLine(4, allLines) Then
                Try
                    SerialPort1.PortName = ReadLine(4, allLines)
                    SerialPort1.BaudRate = 9600
                    SerialPort1.ReadTimeout = 100
                    SerialPort1.WriteTimeout = 100
                    SerialPort1.DataBits = 8
                    SerialPort1.Handshake = IO.Ports.Handshake.None
                    SerialPort1.StopBits = IO.Ports.StopBits.One
                    SerialPort1.RtsEnable = True
                    SerialPort1.DtrEnable = True
                    SerialPort1.Open()
                Catch ex As Exception
                    MessageBox.Show("Cannot COnnect COmport" + Label8.Text + e.ToString _
                               , "Check Device Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MsgBox("CANNOT CONNECT COMPORT" + Label8.Text, _
                                                                          vbExclamation, _
                                                                          "PORT INCORRECT")
            End If
        Catch ex As Exception
            MsgBox("Please Check The Settings")
        End Try
    End Sub
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function
#End Region

#Region "SCANNER CONNECTION"
    Private Sub ConnectSerial()
        Try
            spScanner.BaudRate = 9600
            spScanner.ReadTimeout = 5000
            spScanner.PortName = "COM1"
            spScanner.Open()
        Catch ex As Exception
            cVar.WRITE_LOG(ex.ToString + "/" + "The Serial Port Is in Use") ' if Com1 is not ready/ is in use
            spScanner.Close()
        End Try
    End Sub
    Delegate Sub SetTextDeleg(ByVal text As String)
    Private Sub spScanner_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles spScanner.DataReceived
        Thread.Sleep(500)
        If spScanner.IsOpen Then
            Dim sTemp As String = spScanner.ReadExisting()
            Me.BeginInvoke(New SetTextDeleg(AddressOf si_Datareceived), New Object() {sTemp
                                   }
                        )
        End If
    End Sub
#End Region
    Private Sub si_Datareceived(sTemp As String)

        txtRead.Text = ""
        txtRead.Text = sTemp.ToString()

        If sTemp.IndexOf("\n") > -1 Or sTemp.IndexOf("\r") > -1 Then

        Else
            sTemp = sTemp.Replace("\n", "").Replace("\r", "")
            cVar.WRITE_LOG(sTemp)
            If lblIDNo.Text = "ID No.:" Then
                If sTemp.Length > 8 Or sTemp.ToString().Substring(3, 1).ToUpper() <> "-" Then
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "ERROR: Please scan your ID first."
                    cVar.sRead = sTemp
                    cVar.sErrorMsg = lblMsg.Text
                    sTemp = ""
                    Return
                End If

                If sTemp.Length = 8 And sTemp.ToString().Substring(3, 1).ToUpper() = "-" Then
                    cVar.sIDno = ""
                    cVar.sIDno = sTemp
                    txtRead.Text = sTemp
                    sTemp = ""
                    checkIDno()
                End If

            ElseIf cVar._status = "00051" Then
                If sTemp.Length = 8 And sTemp.ToString().Substring(3, 1).ToUpper() = "-" Then
                    cVar.sSVIDno = ""
                    cVar.sSVIDno = sTemp
                    txtRead.Text = sTemp
                    sTemp = ""
                    checkSVIDno()
                Else
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "ERROR: Please scan SV ID first."
                    sTemp = ""
                    Return
                End If
                If cVar.sSVIDerrmg = "SVIDERROR" Then
                    cVar.sSVIDerrmg = ""
                    Return

                End If
            Else

                If Not String.IsNullOrEmpty(sArticleNo) Then
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 18)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "NOTE:" + sArticleNo + " " + "is In-process.Scanning is possible after the cycle complete"
                    cVar.sErrorMsg = lblMsg.Text
                    Return
                End If
                If sTemp.Length = 44 Then
                    txtRead.Text = sTemp.ToUpper()
                    sArticleNo = sTemp.Substring(4, sTemp.Length - (39))
                    sLabelNo = sTemp.Substring(16, sTemp.Length - (36))
                    sWeight = sTemp.Substring(26, sTemp.Length - (40))
                    sExpDate = sTemp.Substring(30, sTemp.Length - (36))
                    'Check Articles
                    If allLines.Contains(sArticleNo) Then
                        lblMsg.Text = ""
                        Dim _getListChemData = cVar._getchemicalData(sArticleNo, lblplant.Text)
                        Dim listedData As List(Of String) = New List(Of String)()
                        listedData = _getListChemData
                        cVar._palletWt = ""
                        cVar._palletBags = ""
                        cVar._wtBags = ""
                        cVar._maxLoad = ""
                        cVar._palletWt = listedData(0).ToString()
                        cVar._palletBags = listedData(1).ToString()
                        cVar._wtBags = listedData(2).ToString()
                        cVar._maxLoad = listedData(3).ToString()
                        cVar._maxScanning = listedData(4).ToString()

                        perkg.Text = cVar._wtBags
                        Panel1.Visible = True
                        'Aweight.Text = "2"
                        ' AutoClick() ' Call button submit and check all the parameters



                    Else
                        lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                        lblMsg.ForeColor = Color.Red
                        lblMsg.Text = "NOTE: This Article" + "(" + sArticleNo + ")" + " is not Registered"
                        cVar.sRead = ""
                        sArticleNo = String.Empty
                        sLabelNo = ""
                        sWeight = ""
                        sExpDate = ""
                        cVar.sErrorMsg = lblMsg.Text
                        perkg.Text = ""
                        Panel1.Visible = False
                        sTemp = ""
                        Return
                    End If
                End If
            End If

        End If


    End Sub
    Private Sub checkIDno()
        Using _conn As MySqlConnection = New MySqlConnection(Connect_String)
            _conn.Open()
            Dim query As String = "SELECT EMP_NUMBER,FIRST_NAME  From hrd_employee1 where process_id in ('M1010','M1029') and Emp_status = 'A' AND EMP_NUMBER='" + cVar.sIDno + "'"
            Using _cmd As MySqlCommand = New MySqlCommand(query, _conn)
                Dim dr As MySqlDataReader = _cmd.ExecuteReader()
                If dr.Read() Then
                    lblIDNo.Text = dr("EMP_NUMBER").ToString()
                    lblPIC.Text = dr("FIRST_NAME").ToString()
                    cVar.sfullname = lblPIC.Text
                    lblMsg.Text = ""
                    pic.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "photos\" + cVar.sIDno + ".jpg"
                Else
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "Employee ID ''" + cVar.sIDno.ToUpper() + "'' couldn't be found."
                    lblIDNo.Text = "ID No.:"
                    cVar.sIDno = ""
                    Return
                End If

            End Using
            _conn.Close()
        End Using
    End Sub
#Region "RECEIVER OF ARDUINO"
    Private Sub Receiver(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        RXbyte = SerialPort1.ReadByte
        Me.Invoke(New MethodInvoker(AddressOf Display))
    End Sub
    Private Sub Display()
        Try
            txtReceived.Clear()
            txtReceived.Text = (ChrW(RXbyte))
            If txtReceived.Text = "5" Then
                Dim _getlastScan = _getStartScan(sLabelNo)
                cVar.updateRecord(Connect_String, sLabelNo, status_time.Text, _getlastScan)
                cVar.WRITE_LOG(status_time.Text + "_" + sLabelNo)
                lblSVinCHarge.Text = "SV Person In Charge:"
                cVar.sSVIDno = String.Empty
                pic2.Image = Nothing
                lblIDNo.Text = "ID No.:"
                lblPIC.Text = "Person In Charge:"
                cVar.sIDno = String.Empty
                pic.Image = Nothing
                lblMsg.Text = ""
                Panel8.Visible = False
                textBox1.Text = ""
                Aweight.Text = ""
                perkg.Text = ""
                sArticleNo = String.Empty
                sLabelNo = String.Empty
                sWeight = String.Empty
                sExpDate = String.Empty
                Panel1.Visible = False
                txtRead.Text = String.Empty
            End If
        Catch
        End Try
    End Sub

#End Region
#Region "DATE AND TIME DISPLAY USING STATUS STRIP                               DONE"
    Private Sub DateTimer_Tick(sender As Object, e As EventArgs) Handles DateTimer.Tick
        status_date.Text = DateTime.Now.ToString("MM-dd-yyyy")
        status_time.Text = Date.Now.ToString("h:mm:ss tt")

    End Sub
#End Region


#Region "SCANNING ID SUPERVISOR"
    Public Sub checkSVIDno()
        Using _conn As MySqlConnection = New MySqlConnection(Connect_String)
            _conn.Open()
            Dim query As String = "SELECT EMP_NUMBER,FIRST_NAME From hrd_employee1 where process_id in ('M1010','M1029') and Emp_status = 'A' and EMP_RANK IN ('SV','NV','SH') AND EMP_NUMBER='" + cVar.sSVIDno + "'"
            Using _cmd As MySqlCommand = New MySqlCommand(query, _conn)
                Dim dr As MySqlDataReader = _cmd.ExecuteReader()
                If dr.Read() Then
                    lblSVinCHarge.Text = dr("FIRST_NAME").ToString()
                    cVar.sSVName = lblSVinCHarge.Text
                    lblMsg.Text = ""
                    pic2.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "photos\" + cVar.sSVIDno + ".jpg"
                    btn_oK_Click(New Object(), New EventArgs())
                Else
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "Employee ID ''" + cVar.sSVIDno.ToUpper() + "'' is not SV ID"
                    lblSVinCHarge.Text = "SV Person In Charge:"
                    cVar.sSVIDno = String.Empty
                    cVar.sSVIDerrmg = "SVIDERROR"
                    Return
                End If

            End Using
            _conn.Close()
        End Using
    End Sub
#End Region


#Region "KEYPAD CODES"
    Private Sub keypad1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button11.Click, Button1.Click
        selectedBtn = CType(sender, Button)
        With Me
            Aweight.Text += selectedBtn.Text
            pinString += selectedBtn.Text
        End With
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Aweight.Text = String.Empty
    End Sub
#End Region



#Region "BUTTON TO CALL NORMAL INSERTING"
    Private Sub btn_oK_Click(ByVal sender As Object, e As EventArgs) Handles btn_oK.Click
        'Tank()
        ' deliveryScan.Enabled = False

        If Aweight.Text = "" Then
            Return
        End If
        If Convert.ToInt32(Aweight.Text) > Convert.ToInt32(cVar._maxLoad) Then
            cVar.sErrorMsg = ""
            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
            lblMsg.ForeColor = Color.Red
            lblMsg.Text = "ERROR: Load bags is higher than" + " " + cVar._maxLoad
            Aweight.Text = ""
            cVar.sErrorMsg = lblMsg.Text
        Else
            cVar._calculateActualWt = ""
            cVar.sErrorMsg = ""
            Dim _expirationDate = sExpDate.ToString()
            Dim _getyear
            Dim _getday
            Dim _getMonth
            Dim _reconstructDate

            _getyear = (_expirationDate.Remove(4, 4))
            _getday = (_expirationDate.Remove(0, 6))
            _getMonth = (_expirationDate.Remove(0, 4).Remove(2))
            _reconstructDate = _getMonth + "-" + _getday + "-" + _getyear

            Try
                Dim _xValue = _reconstructDate
                Dim _xDate As DateTime = Convert.ToDateTime(_xValue).Date
                Dim present As DateTime = DateTime.Now.Date

                If _xDate >= present Then
                    _calculateActualLoad = Convert.ToInt32(Aweight.Text) * Convert.ToInt32(perkg.Text)
                    Dim _getremainingPallet = _getremainingWeight(sLabelNo)

                    ' _getremainingbags
                    Dim _getremainingbagsperpallet = _getremainingbags(sLabelNo)

                    Dim _totalremainingbags As Integer = Convert.ToInt32(_getremainingbagsperpallet) -
                                                                     Convert.ToInt32(Aweight.Text)

                    Dim _totalremaining As Integer = Convert.ToInt32(_getremainingPallet) -
                                                 Convert.ToInt32(_calculateActualLoad)

                    Using conn As MySqlConnection = New MySqlConnection(Connect_String)
                        conn.Open()
                        Dim query As String = "SELECT COUNT(*) as cnt FROM output_tbl WHERE TAG_NO = '" + sLabelNo + "' and MACHINE_NAME = '" + m_name.Text + "'"
                        Using cmd As MySqlCommand = New MySqlCommand(query, conn)

                            Dim dr As MySqlDataReader = cmd.ExecuteReader()
                            If dr.Read() Then
                                Dim _countSeiban As String = dr("cnt").ToString() 'count seiban how many times inserted in DB
                                If Convert.ToInt32(_countSeiban) < Convert.ToInt32(cVar._maxScanning) Then
                                    '==========================TANK 1================================NORMAL
                                    If sArticleNo = ReadLine(6, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(10)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 2================================NORMAL
                                    If sArticleNo = ReadLine(7, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(20)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text

                                        End If
                                    End If
                                    '==========================TANK 3================================NORMAL
                                    If sArticleNo = ReadLine(8, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(30)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text

                                        End If
                                    End If
                                    '==========================TANK 4================================NORMAL
                                    If sArticleNo = ReadLine(9, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(40)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 5================================NORMAL
                                    If sArticleNo = ReadLine(10, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(50)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 6================================NORMAL
                                    If sArticleNo = ReadLine(11, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(60)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 7================================NORMAL
                                    If sArticleNo = ReadLine(12, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(21)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 8================================NORMAL
                                    If sArticleNo = ReadLine(13, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(22)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 9================================NORMAL
                                    If sArticleNo = ReadLine(14, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(23)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 10===============================NORMAL
                                    If sArticleNo = ReadLine(15, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(24)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 11===============================NORMAL
                                    If sArticleNo = ReadLine(16, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(25)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 12===============================NORMAL
                                    If sArticleNo = ReadLine(17, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(26)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 13===============================NORMAL
                                    If sArticleNo = ReadLine(18, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(27)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                    '==========================TANK 14===============================NORMAL
                                    If sArticleNo = ReadLine(19, allLines) And SerialPort1.IsOpen Then

                                        cVar.fRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, cVar._palletBags, _totalremainingbags)
                                        If cVar._status = "00000" Then
                                            SerialPort1.Write(ChrW(28)) ' send signal to arduino
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Successfully Saved!"
                                            Panel8.Visible = True
                                            Panel8.Location = New System.Drawing.Point(8, 127)
                                            Panel8.Size = New System.Drawing.Size(570, 348)
                                            textBox1.Text = sArticleNo.ToString()
                                            cVar.sErrorMsg = lblMsg.Text
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                        Else
                                            cVar.sErrorMsg = ""
                                            lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                            lblMsg.ForeColor = Color.Red
                                            lblMsg.Text = "Note:This" + " " + sArticleNo + " " + "Tag is Unable to insert in DB"
                                            Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags
                                            cVar.WRITE_Data_LOcal(_sample)
                                            cVar.sErrorMsg = lblMsg.Text
                                        End If
                                    End If
                                Else
                                    If lblSVinCHarge.Text = "SV Person In Charge:" Then
                                        cVar._status = "00051"
                                        cVar.sErrorMsg = ""
                                        lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                        lblMsg.ForeColor = Color.Red
                                        lblMsg.Text = "Note:Need Supervisor's ID. Please Scan SVID"
                                        cVar.sErrorMsg = lblMsg.Text
                                        Panel1.Visible = False
                                    Else
                                        '==========================TANK 1================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(6, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(10)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 2================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(7, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(20)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 3================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(8, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(30)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 4================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(9, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(40)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 5================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(10, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(50)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 6================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(11, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(60)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 7================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(12, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(21)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 8================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(13, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(22)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 9================================ WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(14, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(23)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 10=============================== WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(15, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(24)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 11=============================== WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(16, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(25)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 12=============================== WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(17, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(26)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 13=============================== WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(18, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(27)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                        '==========================TANK 14=============================== WITH SV CONFIRMATION
                                        If sArticleNo = ReadLine(19, allLines) And SerialPort1.IsOpen Then
                                            cVar.svRecord(Connect_String, m_name.Text, cVar.sIDno, cVar.sfullname, sArticleNo, sLabelNo, sWeight, sExpDate, status_time.Text, status_date.Text, _totalremaining, _calculateActualLoad, Aweight.Text, perkg.Text, lblSVinCHarge.Text, cVar._palletBags, _totalremainingbags)
                                            If cVar._status = "00000" Then
                                                SerialPort1.Write(ChrW(28)) ' send signal to arduino
                                                cVar.sErrorMsg = ""
                                                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                                                lblMsg.ForeColor = Color.Red
                                                lblMsg.Text = "Successfully Saved!"
                                                Panel8.Visible = True
                                                Panel8.Location = New System.Drawing.Point(8, 127)
                                                Panel8.Size = New System.Drawing.Size(570, 348)
                                                textBox1.Text = sArticleNo.ToString()
                                                cVar.sErrorMsg = lblMsg.Text
                                                Dim _sample As String = m_name.Text + " - " + cVar.sIDno + " - " + cVar.sfullname + " - " + sArticleNo + " - " + sLabelNo + " - " + sWeight + " - " + sExpDate + " - " + status_time.Text + " - " + status_date.Text + " - " + Convert.ToString(_totalremaining) + " - " + Convert.ToString(_calculateActualLoad) + " - " + Aweight.Text + " - " + perkg.Text + " - " + cVar._palletBags + " - " + lblSVinCHarge.Text
                                                cVar.WRITE_Data_LOcal(_sample)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            conn.Close()

                        End Using
                    End Using


                Else
                    cVar.sErrorMsg = ""
                    lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                    lblMsg.ForeColor = Color.Red
                    lblMsg.Text = "Note:Dispatch Tag Expired" + ":" + "Today is:" + DateTime.Now.ToString("MM/dd/yyyy")
                    Aweight.Text = ""
                    cVar.sErrorMsg = lblMsg.Text
                End If

            Catch ex As Exception
                cVar.sErrorMsg = ""
                lblMsg.Font = New Font(lblMsg.Font.FontFamily.Name, 25)
                lblMsg.ForeColor = Color.Red
                lblMsg.Text = "test" + ex.ToString()
            End Try

        End If
    End Sub
#End Region

    Private Function _getremainingWeight(_seiban As String)
        Dim _countRemaingwt = ""
        Using conn As MySqlConnection = New MySqlConnection(Connect_String)
            conn.Open()
            Dim query As String = "SELECT REM_WT_PALLET FROM output_tbl WHERE TAG_NO = '" + _seiban + "' order by SYS_DATE_TIME desc"
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then

                    _countRemaingwt = dr("REM_WT_PALLET").ToString() 'GET REMIANING WT
                Else
                    _countRemaingwt = sWeight
                End If

                conn.Close()

            End Using
        End Using
        Return _countRemaingwt
    End Function

    Private Function _getremainingbags(_seiban As String)
        Dim _countRemaingbags = ""
        Using conn As MySqlConnection = New MySqlConnection(Connect_String)
            conn.Open()
            Dim query As String = "SELECT REM_BAG_PALLET FROM output_tbl WHERE TAG_NO = '" + _seiban + "' order by SYS_DATE_TIME desc"
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then

                    _countRemaingbags = dr("REM_BAG_PALLET").ToString() 'GET REMIANING bags
                Else
                    _countRemaingbags = cVar._palletBags

                End If

                conn.Close()

            End Using
        End Using
        Return _countRemaingbags
    End Function

    Private Function _getStartScan(_seiban As String)
        Dim _getstartscanLast = ""
        Using conn As MySqlConnection = New MySqlConnection(Connect_String)
            conn.Open()
            Dim query As String = "SELECT STARTSCAN FROM output_tbl WHERE TAG_NO = '" + _seiban + "' order by SYS_DATE_TIME desc"
            Using cmd As MySqlCommand = New MySqlCommand(query, conn)

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then

                    _getstartscanLast = dr("STARTSCAN").ToString() 'GET REMIANING WT

                End If

                conn.Close()

            End Using
        End Using
        Return _getstartscanLast
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        lblSVinCHarge.Text = "SV Person In Charge:"
        cVar.sSVIDno = String.Empty
        pic2.Image = Nothing
        lblIDNo.Text = "ID No.:"
        lblPIC.Text = "Person In Charge:"
        cVar.sIDno = String.Empty
        pic.Image = Nothing
        lblMsg.Text = ""
        Panel8.Visible = False
        textBox1.Text = ""
        Aweight.Text = ""
        perkg.Text = ""
        sArticleNo = String.Empty
        sLabelNo = String.Empty
        sWeight = String.Empty
        sExpDate = String.Empty
        Panel1.Visible = False
        txtinputS.Text = ""
        txtRead.Text = ""
    End Sub

   

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        si_Datareceived(txtinputS.Text)
    End Sub
End Class
