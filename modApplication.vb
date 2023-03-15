Imports JTLRechnung.lvwSorter
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Module modApplication
    Public WithEvents clsUpdateDownloader As WebFileDownloader
    Public pgrUpdater_global As ProgressBar
    Public strServerInfo() As String
    Public strVersionsNummer As String = "2.2.0 BETA"
    Public iUpdateNummer As Integer = 2
    Public bExitProgramm As Boolean = False
    Public bRegistered As Boolean = False
    Public Enum mgetUpdaterMessage
        getNewVersion = 0
        sendAuthCode = 1
        getAuthCode = 2
        getIstBuyed = 3
        getProgramUpdateCheck = 4
    End Enum

    Private col As Integer

    Public gbl_KeyCode As String

    '######################################################
    '# >> Schlüssel berechnen 
    '######################################################
    Public Function getWMI_KeyCode() As String
        Dim strHDD As String = ""
        Dim strCPU As String = ""
        Dim strKeyCode As String = ""
        Try

            strHDD = getWMI_HDD_Serial()
            If strHDD = "-1" Or strHDD = "" Then
                MsgBox("Fehler beim Empfangen der HDD Serial", MsgBoxStyle.Critical)
                Exit Function
            End If

            strCPU = getWMI_CPU()
            If strCPU = "-1" Or strCPU = "" Then
                MsgBox("Fehler beim empfangen der MAC Addresse", MsgBoxStyle.Critical)
                Exit Function
            End If

            Dim strProg As String = "JTL Bridge"
            strKeyCode = Encrypt(strHDD & strCPU)

            strKeyCode = strKeyCode.Replace("+", "")
            strKeyCode = strKeyCode.Replace("=", "")
            'strKeyCode = strKeyCode.Substring(0, 7)

            Return strKeyCode
        Catch ex As Exception
            MessageBox.Show("Kann WMI Daten für Schlüsselgenerierung nicht erzeugen!", "getWMI_KeyCode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '##############################################################
    '# >> Encrypt
    '# Verschlüsseln von DATEN 
    '##############################################################
    Public Function Encrypt(ByVal plainText As String) As String
        ' Declare a UTF8Encoding object so we may use the GetByte
        ' method to transform the plainText into a Byte array.
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim bytValue() As Byte
        Dim gstrHash As String
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText & "JTL Bridge")

        ' Create a new TripleDES service provider
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

        ' The ICryptTransform interface uses the TripleDES
        ' crypt provider along with encryption key and init vector
        ' information
        bytValue = System.Text.Encoding.UTF8.GetBytes(plainText)
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(bytValue, bytValue)

        ' All cryptographic functions need a stream to output the
        ' encrypted information. Here we declare a memory stream
        ' for this purpose.
        Dim encryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)

        ' Write the encrypted information to the stream. Flush the information
        ' when done to ensure everything is out of the buffer.
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0

        ' Read the stream back into a Byte array and return it to the calling
        ' method.
        Dim result(encryptedStream.Length - 1) As Byte
        encryptedStream.Read(result, 0, encryptedStream.Length)
        cryptStream.Close()

        gstrHash = Convert.ToBase64String(result)
        Return gstrHash
    End Function
    '# WMI MAC 
    Private Function getWMI_CPU() As String
        Dim strCPU As String = ""
        Dim objWMIService As Object
        Dim colItems As Object
        Dim objItem As Object
        Dim strComputer As String = "."

        Try

            objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
            colItems = objWMIService.ExecQuery("Select * from Win32_Processor")

            For Each objItem In colItems
                Application.DoEvents()
                'lstServerMessage.Items.Add("-- HDD INFO --")
                'lstServerMessage.Items.Add("Prozessor ID:" & objItem.ProcessorId)
                strCPU = objItem.ProcessorId
                'lstServerMessage.Items.Add("Geschwindigkeit:" & objItem.MaxClockSpeed & " Mhz")
                'lstServerMessage.Items.Add("BUS-System:" & objItem.DataWidth & " Bit")
                'lstServerMessage.Items.Add("Datum:" & objItem.InstallDate)
                'lstServerMessage.Items.Add("-- ENDE --")
                'lstServerMessage.Items.Add("")
            Next

            Return strCPU
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    '#  WMI HDD Serial 
    Private Function getWMI_HDD_Serial() As String
        Dim strHDD As String = ""
        Dim colDisks As Object
        Dim objDisk As Object

        Try
            colDisks = GetObject( _
               "Winmgmts:").ExecQuery("Select * from Win32_LogicalDisk")

            For Each objDisk In colDisks
                Application.DoEvents()
                Select Case objDisk.DriveType

                    Case 3
                        'lstServerMessage.Items.Add("-- HDD INFO --")
                        'lstServerMessage.Items.Add("Bezeichnung: " & objDisk.Caption & " - " & objDisk.VolumeName & " - Typ: Festplatte")
                        'lstServerMessage.Items.Add("Seriennummer: " & objDisk.VolumeSerialNumber)
                        'lstServerMessage.Items.Add("Dateisystem: " & objDisk.FileSystem)
                        'lstServerMessage.Items.Add("-- ENDE --")
                        'lstServerMessage.Items.Add("")
                        strHDD = objDisk.VolumeSerialNumber
                        Exit For
                End Select
            Next

            Return strHDD
        Catch ex As Exception

            Return "-1"
        End Try
    End Function

    '######################################################################
    '# >> Spaltenansicht speichern
    '######################################################################
    Public Function setLVWColumOrder(ByVal lvwData As ListView) As Boolean
        Try
            Dim iCount As Integer = 0
            Dim strData As String = ""
            For iCount = 0 To lvwData.Columns.Count - 1
                strData &= iCount & "-" & lvwData.Columns(iCount).DisplayIndex & "-" & lvwData.Columns(iCount).Width & vbCrLf
            Next

            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "/colums_" & lvwData.Name & ".dat", strData, False)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Speichern der Spalten", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '######################################################################
    '# >> Spaltenansicht laden 
    '######################################################################
    Public Function getLVWColumOrder(ByVal lvwData As ListView) As Boolean
        Try
            Dim strFilename As String = Application.StartupPath & "/colums_" & lvwData.Name & ".dat"

            If IO.File.Exists(strFilename) = True Then
                Dim strData As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "/colums_" & lvwData.Name & ".dat")
                Dim strZeilen() As String = strData.Split(vbCrLf)
                Dim iCount As Integer = 0

                For iCount = 0 To strZeilen.Length - 2
                    Dim strZeilen_sub() As String = strZeilen(iCount).Split("-")
                    lvwData.Columns(iCount).DisplayIndex = strZeilen_sub(1)
                    lvwData.Columns(iCount).Width = strZeilen_sub(2)
                Next
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Laden der Spalten", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '#################################################################
    '# >> Sortieren 
    '#################################################################
    Public Function setSort(ByRef listview1 As ListView, ByVal e As  _
      System.Windows.Forms.ColumnClickEventArgs) As Boolean
        Try

            If col = e.Column Then
                If listview1.Sorting = SortOrder.Descending Then
                    listview1.Sorting = SortOrder.Ascending
                Else
                    listview1.Sorting = SortOrder.Descending
                End If
            Else
                listview1.Sorting = SortOrder.Ascending
            End If

            col = e.Column

            '################################
            '# >> Kundenauswahl: Alle Kunden
            '################################
            Select Case listview1.Name
                Case "lvwKunde"
                    Select Case col
                        Case 5
                            listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                        Case Else
                            listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                    End Select
                    Call repaint(listview1)
            End Select
            '#############################
            '# >> Hauptform: Alle Artikel 
            '#############################
            Select Case listview1.Name
                Case "lvwArtikel_alle"
                    Select Case col
                        Case 3
                            'MessageBox.Show(e.Column.GetType.ToString)
                            listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                        Case 4
                            listview1.ListViewItemSorter = New lvsorter(Of Decimal)(e.Column)
                        Case 5
                            listview1.ListViewItemSorter = New lvsorter(Of Integer)(e.Column)
                        Case 6
                            listview1.ListViewItemSorter = New lvsorter(Of Decimal)(e.Column)
                        Case 7
                            listview1.ListViewItemSorter = New lvsorter(Of Decimal)(e.Column)
                        Case 8
                            listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                        Case 9
                            listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                        Case Else
                            listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                    End Select
                    Call repaint(listview1)
            End Select
            '####################################
            '# >> Hauptform: Kategorien anzeigen 
            '####################################
            Select Case listview1.Name
                Case "lvwArtikel_kategorien"
                    Select Case col
                        Case 5
                            listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                        Case Else
                            listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                    End Select
                    Call repaint(listview1)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Sortieren", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub repaint(ByVal listview1 As ListView)
        '# Neu einfärben
        Dim i As Integer = 0
        For i = 0 To listview1.Items.Count - 1

            If i Mod 2 = 0 Then
                listview1.Items(i).BackColor = Color.White
            Else
                listview1.Items(i).BackColor = Color.WhiteSmoke
            End If


        Next
    End Sub
    '########################################################################
    '# >> setUpdateDatabase
    '# Datenbank Update durchführen 
    '########################################################################
    Public Function setUpdateDatabase(strDatenbank As String, bUpdate As Boolean) As Boolean

        '# Existieren fehlende Tabellen 
        Dim strFilename As String = Application.StartupPath & "\SQL\table_list.txt"

        '# Basis Tabellen install_tables.sql installieren!
        If bUpdate = True Then
            strFilename = Application.StartupPath & "\SQL\alter_tables.sql"
            If IO.File.Exists(strFilename) = True Then
                If frmJTLRechnung.clsDB.setInstallUpdateByDatabase(strFilename, strDatenbank) = True Then
                    MessageBox.Show("Datenbank aktuallisierung wurde abgeschlossen", "Datenbankaktuallisierung", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            If IO.File.Exists(strFilename) = True Then
                '# Im Fehlerfall Tabellen installieren 
                Dim strUpdateTabelle As String = frmJTLRechnung.clsDB.chkInstallTableExists(strFilename)
                If Not strUpdateTabelle = "1" Then
                    strFilename = Application.StartupPath & "\SQL\install_tables.sql"
                    If IO.File.Exists(strFilename) = True Then
                        If frmJTLRechnung.clsDB.setInstallUpdateByDatabase(strFilename, strDatenbank) = True Then
                            MessageBox.Show("Neue Tabelle '" & strUpdateTabelle & " ' wurde installiert", "MS-SQL: Update Tabelle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End If
        End If
        Return True
    End Function

    '#####################################################################
    '# Ausgeben des Namens von einer URL 
    '#####################################################################
    Public Function GetFileNameFromURL(ByVal URL As String) As String
        If URL.IndexOf("/"c) = -1 Then Return String.Empty

        Return "\" & URL.Substring(URL.LastIndexOf("/"c) + 1)
    End Function

    '#################################################################################################
    '# >> UPDATER: Programm Updates durch Server Verteilen 
    '#################################################################################################
    Public Function setUpdateCheck(ByVal pgrUpdate As ProgressBar, ByVal lblUpdater As Label) As Boolean

        Dim strMessage As String
        Dim iAPPID As Integer = 2  ' YABE UPDATE ID 

        'PRÜFEN ob Datei existiert
        If Not IO.Directory.Exists(Application.StartupPath & "\Updater\") Then
            ' MessageBox.Show("Kein gültiges Verzeichnis", "Fehler beim Aktualisieren", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Return
        End If

        pgrUpdater_global = pgrUpdate
        strMessage = "https://api.bludau-media.de/SafeSandy/Download.php?version=" & strVersionsNummer & "&name=JTL%20Bridge&key=" & gbl_KeyCode & "&programID=1&versionsnummer=" & strVersionsNummer

        Dim strServerInfo() As String = getHTTPResponseMessage(strMessage, mgetUpdaterMessage.getNewVersion, True)

        'Download starten 
        Try
            pgrUpdate.Visible = True
            lblUpdater.Visible = True

            clsUpdateDownloader = New WebFileDownloader
            'txtDownloadTo.Text.TrimEnd("\"c) 
            Application.DoEvents()
            clsUpdateDownloader.DownloadFileWithProgress(strServerInfo(1).ToString.Replace("br/>URL=", ""), Application.StartupPath & "\Updater\" & GetFileNameFromURL(strServerInfo(1).ToString.Replace("br/>URL=", "")))
            pgrUpdate.Visible = False
            lblUpdater.Visible = False

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        End Try



    End Function
    '#################################################################################################
    '# >> UPDATER: Dateigröße 
    '#################################################################################################
    Public Sub _Downloader_FileDownloadSizeObtained(ByVal iFileSize As Long) Handles clsUpdateDownloader.FileDownloadSizeObtained
        pgrUpdater_global.Value = 0
        pgrUpdater_global.Maximum = Convert.ToInt32(iFileSize)
    End Sub
    Public Function setBR(ByVal strData As String) As String
        Try

            strData = vbCrLf & strData.Replace("|br|", vbCrLf)
        Catch ex As Exception
            'Call debug_message(ex, strQuery & vbCrLf & "setBR")
            Return "-1"
        End Try

        Return strData
    End Function
    '#################################################################################################
    '# >> UPDATER: Wieviel wurder heruntergeladen 
    '#################################################################################################
    Private Sub _Downloader_AmountDownloadedChanged(ByVal iNewProgress As Long) Handles clsUpdateDownloader.AmountDownloadedChanged
        pgrUpdater_global.Value = Convert.ToInt32(iNewProgress)
        'lblUpdater.Text = WebFileDownloader.FormatFileSize(iNewProgress) & " von " & WebFileDownloader.FormatFileSize(pgrUpdater_global.Maximum) & " downloaded"
        Application.DoEvents()
    End Sub

    '#################################################################################################
    '# >> UPDATER: Download beendet 
    '#################################################################################################
    Public Sub _Downloader_FileDownloadComplete() Handles clsUpdateDownloader.FileDownloadComplete
        Dim strMessage As String

        Try
            pgrUpdater_global.Value = pgrUpdater_global.Maximum
            Application.DoEvents()
            strMessage = setBR(strServerInfo(4))
        Catch ex As Exception

        End Try


        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = Application.StartupPath & "\Updater" & GetFileNameFromURL(strServerInfo(1))
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()



    End Sub

    '#################################################################################################
    '# >> UPDATER: Nachricht abgreifen 
    '#################################################################################################
    Public Function getHTTPResponseMessage(ByVal strURL As String, ByVal mModus As mgetUpdaterMessage, ByVal bMessage As Boolean) As String()
        Dim strData As String = ""
        Try


            '# Request erzeugen 
            'MsgBox(strURL)

            Dim request As WebRequest = WebRequest.Create(strURL)

            '# Server - Login 
            request.Credentials = CredentialCache.DefaultCredentials

            '# Server - Antwort 
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            '# Status anzeigen 
            Console.WriteLine(response.StatusDescription)

            '# Hole den Stream 
            Dim dataStream As Stream = response.GetResponseStream()

            '# Benutzerstream Reader zum einlesen 
            Dim reader As New StreamReader(dataStream)

            '# Alles einlesen 
            Dim responseFromServer As String = reader.ReadToEnd()


            strServerInfo = responseFromServer.Split("<br/>")




            '# Welcher Modus 
            Select Case mModus

                Case mgetUpdaterMessage.getNewVersion

                    If strServerInfo.Length >= 2 Then
                        strServerInfo(1) = strServerInfo(1).Replace("br>", "")
                        strServerInfo(1) = strServerInfo(1).Replace("URL:", "")
                    End If

                    If strServerInfo.Length >= 3 Then
                        strServerInfo(2) = strServerInfo(2).Replace("br>", "")
                        strServerInfo(2) = strServerInfo(2).Replace("ZEITPUNKT:", "")
                    End If

                    If strServerInfo.Length >= 4 Then
                        strServerInfo(3) = strServerInfo(3).Replace("br>", "")
                        strServerInfo(3) = strServerInfo(3).Replace("VERSION:", "")
                    End If

                    If strServerInfo.Length >= 5 Then
                        strServerInfo(4) = strServerInfo(4).Replace("br>", "")
                        strServerInfo(4) = strServerInfo(4).Replace("COMMENT:", "")
                    End If

                    If strServerInfo.Length > 0 Then

                        Select Case strServerInfo(0)
                            Case "NEUSTE_VERSION_VORHANDEN"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.ok
                                frmJTLRechnung.msgMaster.Text = "Neuste Version vorhanden: " & Date.Now

                                Exit Function
                            Case "FEHLER:Kein_Versionsstring"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.fehler
                                frmJTLRechnung.msgMaster.Text = "Fehler kein Versionsstring gefunden, bitte manuell von https://bludau-media.de/ herunterladen.."

                                Exit Function
                            Case "DOWNLOAD_NOW"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.update
                                frmJTLRechnung.msgMaster.Text = "Neues Update vom " & strServerInfo(2) & " | Version: " & strServerInfo(3) & " : " & Date.Now

                        End Select

                    End If
                Case mgetUpdaterMessage.sendAuthCode
                    Return strServerInfo
                    '############################################################
                    '# ABRUFEN DES AUTHCODES + DEMOENDE DATUM 
                    '############################################################
                Case mgetUpdaterMessage.getAuthCode

                    Return strServerInfo


                Case mgetUpdaterMessage.getIstBuyed
                    Return strServerInfo
                Case mgetUpdaterMessage.getProgramUpdateCheck
                    Return strServerInfo

            End Select


            '# Alle Resourcen schließen 
            reader.Close()
            dataStream.Close()
            response.Close()
            Return strServerInfo
        Catch ex As Exception
            MessageBox.Show("Fehler bei " & ex.Message, "getHTTPResponseMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function getDateTimeVar(strmySQLDatum As String) As DateTime
        Try
            Dim strDatumSplit() As String = strmySQLDatum.Split(" ")
            Dim strDatumReal() As String = strDatumSplit(0).Split("-")

            Return strDatumReal(2) & "." & strDatumReal(1) & "." & strDatumReal(0) & " " & strDatumSplit(1)
        Catch ex As Exception

        End Try
    End Function

    '##########################################################
    '# >> getBenzinPreisAPI
    '# Benzinpreis abrufen
    '##########################################################
    Public Function getBenzinPreisAPI() As Boolean
        Try
            Dim url As String = "https://api.bludau-media.de/api/benzinpreis_api.php"


            Dim request As WebRequest = _
              WebRequest.Create(url)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            'Console.WriteLine(responseFromServer)

            '# Diesel Preis 
            My.Settings.txtBenzinpreis.Item(My.Settings.mandant_position) = responseFromServer.ToString.Trim
            frmJTLRechnung.lblGoogleBenzin.Text = "| Dieselpreis: " & My.Settings.txtBenzinpreis.Item(My.Settings.mandant_position) & " Euro"
            My.Settings.Save()

            reader.Close()
            response.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler beim abrufen des Dieselpreises!", "getBenzinPreisAPI", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '##########################################################
    '# >> getGoogleMapsDistanz
    '# Google Maps abrufen
    '##########################################################
    Public Function getGoogleMapsDistanz()
        Try
            Dim strStart As String = My.Settings.absender_straße.Item(My.Settings.mandant_position) & "," & My.Settings.absender_plz.Item(My.Settings.mandant_position) & " " & My.Settings.absender_ort.Item(My.Settings.mandant_position)
            Dim strEnde As String = frmJTLRechnung.lvwKunde.Items(0).SubItems(4).Text & "," & frmJTLRechnung.lvwKunde.Items(0).SubItems(5).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(3).Text
            Dim url As String = "http://maps.google.de/maps?f=d&source=s_d&saddr=" & strStart.Replace(" ", "+") & "&daddr=" & strEnde.Replace(" ", "+") & "&oi=nojs"


            Dim request As WebRequest = _
              WebRequest.Create(url)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            'Console.WriteLine(responseFromServer)

            If responseFromServer.IndexOf("Dieser Ort ist uns unbekannt.") > 0 Then

            Else
                'MessageBox.Show(responseFromServer)
                Dim iStartPos As Integer = responseFromServer.IndexOf("<div class=""altroute-rcol altroute-info"">")
                Dim iEndPos As Integer = responseFromServer.IndexOf("</div>", iStartPos)
                responseFromServer = responseFromServer.Substring(iStartPos, iEndPos - iStartPos)
                responseFromServer = responseFromServer.Replace("<div class=""altroute-rcol altroute-info"">", "").Replace("<span>", "").Replace("</span>", "")

                Dim iEndPosDistanz As Integer = responseFromServer.IndexOf("km", 0)
                Dim strDistanz As String = responseFromServer.Substring(0, iEndPosDistanz)


                Dim strDauer As String = responseFromServer.Substring(0, responseFromServer.Length)
                Dim strDauer1() As String = strDauer.Split(",")
                Dim strBenzinpreis As String = Convert.ToDecimal(My.Settings.txtBenzinpreis.Item(My.Settings.mandant_position).ToString.Replace(".", ",")) * Convert.ToInt16(strDistanz)
                frmJTLRechnung.lblGoogleBenzin.Text = "| Distanz:" & strDistanz & "km | " & strDauer1(1).Trim & " | Benzinpreis: " & strBenzinpreis & " €"
            End If
            reader.Close()
            response.Close()

        Catch ex As Exception
            frmJTLRechnung.lblGoogleBenzin.Text = "| Keine Distanzberechnung möglich"
        End Try
    End Function
End Module
