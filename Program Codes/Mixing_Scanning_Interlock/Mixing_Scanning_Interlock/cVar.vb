Imports System.IO
Imports System.Windows.Forms
Imports System
Imports MySql.Data.MySqlClient
Public Class cVar
    Public Shared _palletWt As String = ""
    Public Shared _palletBags As String = ""
    Public Shared _wtBags As String = ""
    Public Shared _maxBagsperLoad As String = ""
    Public Shared _maxScan As String = ""
    Public Shared _maxLoad, _maxScanning, _calculateActualWt As String
    Public Shared _status As String
    Public Shared sRead, sErrorMsg As String
    Public Shared sIDno, sfullname, sSVIDerrmg, sSVIDno, sSVName As String


    Public Shared Sub WRITE_LOG(Value As String)
        If Value <> "" And Value <> String.Empty Then
            If File.Exists(Application.StartupPath + "\Logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt") Then
                Dim fs As New FileStream(Application.StartupPath + "\Logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt", FileMode.Append, FileAccess.Write, FileShare.None)
                Dim stWriter As New StreamWriter(fs)
                stWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " " + Value)
                stWriter.Close()
            Else
                Dim strwrtr As New StreamWriter(Application.StartupPath + "\Logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt")
                strwrtr.Close()
            End If
        End If
    End Sub
    Public Shared Sub WRITE_Data_LOcal(Value As String)
        If Value <> "" And Value <> String.Empty Then
            If File.Exists(Application.StartupPath + "\Local Data\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt") Then
                Dim fs As New FileStream(Application.StartupPath + "\Local Data\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt", FileMode.Append, FileAccess.Write, FileShare.None)
                Dim stWriter As New StreamWriter(fs)
                stWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " " + Value)
                stWriter.Close()
            Else
                Dim strwrtr As New StreamWriter(Application.StartupPath + "\Local Data\" + DateTime.Now.ToString("MM-dd-yyyy") + "_log.txt")
                strwrtr.Close()
            End If
        End If
    End Sub

    Public Shared Function _getchemicalData(_artNO As String, _plant As String) As List(Of String)
        Using _conn As MySqlConnection = New MySqlConnection("data source=192.168.1.1; user id=root; password=;database=send_report_output")
            _conn.Open()
            Dim query As String = "SELECT WEIGHT_PALLET,BAGS_PALLET,WEIGHT_BAG,MAX_LOAD_BAG,MAX_SCAN FROM mixing_chemicals_data WHERE ITEM_CODE = '" + _artNO + "' and PLANT = '" + _plant + "'"
            Using _da As MySqlDataAdapter = New MySqlDataAdapter(query, _conn)
                Dim ds3 As DataSet = New DataSet()
                _da.Fill(ds3)

                If ds3.Tables(0).Rows.Count > 0 Then
                    _palletWt = Convert.ToString(ds3.Tables(0).Rows(0)(0))
                    _palletBags = Convert.ToString(ds3.Tables(0).Rows(0)(1))
                    _wtBags = Convert.ToString(ds3.Tables(0).Rows(0)(2))
                    _maxBagsperLoad = Convert.ToString(ds3.Tables(0).Rows(0)(3))
                    _maxScan = Convert.ToString(ds3.Tables(0).Rows(0)(4))

                End If
            End Using
            _conn.Close()
        End Using
        Dim _listrange As List(Of String) = New List(Of String)()
        _listrange.Add(_palletWt)
        _listrange.Add(_palletBags)
        _listrange.Add(_wtBags)
        _listrange.Add(_maxBagsperLoad)
        _listrange.Add(_maxScan)

        Return _listrange
    End Function

    Public Shared Function fRecord(constring As String, cMcName As String, cidnum As String, cFullname As String, cArticle As String, cLabel As String, cWeight As String, cExpDate As String, cStartScan As String, cStartDateScan As String, _remaining_pallet_wt As String, tot_act_wt As String, _loadbags As String, _loadperkg As String, _totalbagspallet As String,_remainingbags As string)


        Try
            Using _conn As MySqlConnection = New MySqlConnection(constring)
                _conn.Open()
                Dim query As String = "INSERT INTO output_tbl(MACHINE_NAME," +
                                                   "IDNUM," +
                                                   "FULLNAME," +
                                                   "MATERIAL_NO," +
                                                   "TAG_NO," +
                                                   "WEIGHT," +
                                                   "EXPIRED_DATE," +
                                                   "REM_WT_PALLET," +
                                                   "TOT_ACT_WT," +
                                                   "LOADBAGS," +
                                                   "LOADPERKG," +
                                                   "STARTSCAN," +
                                                   "TOTALBAGPERPALLET," +
                                                   "REM_BAG_PALLET," +
                                                   "SYS_DATE_TIME," +
                                                   "STARTDATESCAN) VALUES('" + cMcName + "'," +
                                                   "'" + cidnum + "'," +
                                                   "'" + cFullname + "'," +
                                                   "'" + cArticle + "'," +
                                                   "'" + cLabel + "'," +
                                                   "'" + cWeight + "'," +
                                                   "'" + cExpDate + "'," +
                                                   "'" + _remaining_pallet_wt + "'," +
                                                   "'" + tot_act_wt + "'," +
                                                   "'" + _loadbags + "'," +
                                                   "'" + _loadperkg + "'," +
                                                   "'" + cStartScan + "'," +
                                                   "'" + _totalbagspallet + "'," +
                                                   "'" + _remainingbags + "'," +
                                                   "'" + DateTime.Now.ToString + "'," +
                                                   "'" + cStartDateScan + "')"

                Using cmd As MySqlCommand = New MySqlCommand(query, _conn)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i = 1 Then
                        _status = "00000"
                    End If

                End Using
                _conn.Close()
            End Using
        Catch ex As Exception
            Dim errmsg As String = ex.ToString()
        End Try
        Return _status
    End Function
    Public Shared Function svRecord(constring As String, cMcName As String, cidnum As String, cFullname As String, cArticle As String, cLabel As String, cWeight As String, cExpDate As String, cStartScan As String, cStartDateScan As String, _remaining_pallet_wt As String, tot_act_wt As String, _loadbags As String, _loadperkg As String, cSVfullname As String, _totalbagpallet As String, _remainingbags As String)
        Try
            Using _conn As MySqlConnection = New MySqlConnection(constring)
                _conn.Open()
                Dim query As String = "INSERT INTO output_tbl(MACHINE_NAME," +
                                                   "IDNUM," +
                                                   "FULLNAME," +
                                                   "MATERIAL_NO," +
                                                   "TAG_NO," +
                                                   "WEIGHT," +
                                                   "EXPIRED_DATE," +
                                                   "REM_WT_PALLET," +
                                                   "TOT_ACT_WT," +
                                                   "LOADBAGS," +
                                                   "LOADPERKG," +
                                                   "STARTSCAN," +
                                                   "STARTDATESCAN," +
                                                   "TOTALBAGPERPALLET," +
                                                   "REM_BAG_PALLET," +
                                                   "SYS_DATE_TIME," +
                                                   "ACCOUNTABILITY) VALUES('" + cMcName + "'," +
                                                   "'" + cidnum + "'," +
                                                   "'" + cFullname + "'," +
                                                   "'" + cArticle + "'," +
                                                   "'" + cLabel + "'," +
                                                   "'" + cWeight + "'," +
                                                   "'" + cExpDate + "'," +
                                                   "'" + _remaining_pallet_wt + "'," +
                                                   "'" + tot_act_wt + "'," +
                                                   "'" + _loadbags + "'," +
                                                   "'" + _loadperkg + "'," +
                                                   "'" + cStartScan + "'," +
                                                   "'" + cStartDateScan + "'," +
                                                   "'" + _totalbagpallet + "'," +
                                                   "'" + _remainingbags + "'," +
                                                   "'" + DateTime.Now.ToString + "'," +
                                                   "'" + cSVfullname + "')"

                Using cmd As MySqlCommand = New MySqlCommand(query, _conn)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i = 1 Then
                        _status = "00000"
                    End If

                End Using
                _conn.Close()
            End Using
        Catch ex As Exception
            Dim errmsg As String = ex.ToString()
        End Try
        Return _status
    End Function
    Public Shared Function updateRecord(constring As String, cLabel As String, cStopScan As String, timeget As String)
        Try
            Using _conn As MySqlConnection = New MySqlConnection(constring)
                _conn.Open()
                Dim query As String = "UPDATE output_tbl  SET STOPSCAN='" + cStopScan + "' WHERE TAG_NO='" + cLabel + "' and STARTSCAN= '" + timeget + "'"
                Using cmd As MySqlCommand = New MySqlCommand(query, _conn)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i = 1 Then
                        _status = "00000"
                    End If

                End Using
                _conn.Close()
            End Using
        Catch ex As Exception
            Dim errmsg As String = ex.ToString()
        End Try
        Return _status
    End Function
End Class
