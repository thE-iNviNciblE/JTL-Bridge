Imports System.Drawing.Printing

Public Class frmRechnungsdruck
    Public dgvArtikel As DataGridView
    Public lvwKunden As ListView
    Public bPrintSofort As Boolean = False
    Public bIsLoading As Boolean = True

    ' Declare the PrintDocument object.
    Private WithEvents docToPrint As New PrintDocument
    Private Sub frmRechnungsdruck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rdoJTLWaWiSave.Checked = My.Settings.bestellung_opt_jtl_add.Item(My.Settings.mandant_position)

        chkRechnungsdetailsVerkäuferAnzeigen.Checked = My.Settings.chkRechnungsdetailVerkäuferAnzeigen(My.Settings.mandant_position)

        Me.Text &= strVersionsNummer

        '#
        If My.Settings.absender_vorname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_nachname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_straße(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_plz(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_ort(My.Settings.mandant_position).ToString.Length = 0 Then
            Dim frmEinstellungenDialoag As New frmEinstellungen
            frmEinstellungenDialoag.Show()
        End If

        '# Sofort drucken 
        If bPrintSofort = False Then
            Call getRechnung_show()
        Else
            'Me.Visible = False
            'Me.ShowInTaskbar = False
            Call getRechnung_show()
            Application.DoEvents()
            btnBestellungADD.PerformClick()
            Application.DoEvents()
        End If
        bIsLoading = False

    End Sub

    '#####################################################################
    '# >> Rechnung generieren 
    '#####################################################################
    Private Function getRechnung(ByVal strVorlage As String) As String
        Dim strRechnung As String = ""
        Try
            '# RECHNUNG ABSENDER
            If chkRechnungsdetailsVerkäuferAnzeigen.Checked = True Then
                strRechnung = strVorlage.Replace("###ABSENDER_FIRMA###", My.Settings.absender_firma.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_VORNAME###", My.Settings.absender_vorname.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_NACHNAME###", My.Settings.absender_nachname.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_STRASSE###", My.Settings.absender_straße.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_PLZ###", My.Settings.absender_plz.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_ORT###", My.Settings.absender_ort.Item(My.Settings.mandant_position))
                strRechnung = strRechnung.Replace("###ABSENDER_LAND###", My.Settings.absender_land.Item(My.Settings.mandant_position))
            Else
                strRechnung = strVorlage.Replace("###ABSENDER_FIRMA###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_VORNAME###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_NACHNAME###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_STRASSE###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_PLZ###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_ORT###", "")
                strRechnung = strRechnung.Replace("###ABSENDER_LAND###", "")
            End If

            '# RECHNUNG EMPFÄNGER
            If lvwKunden.Items.Count > 0 Then
                strRechnung = strRechnung.Replace("###EMPFÄNGER_FIRMA###", lvwKunden.Items(0).SubItems(7).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_VORNAME###", lvwKunden.Items(0).SubItems(1).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_NACHNAME###", lvwKunden.Items(0).SubItems(2).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_STRASSE###", lvwKunden.Items(0).SubItems(4).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_PLZ###", lvwKunden.Items(0).SubItems(5).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_ORT###", lvwKunden.Items(0).SubItems(3).Text)
                strRechnung = strRechnung.Replace("###EMPFÄNGER_LAND###", lvwKunden.Items(0).SubItems(6).Text)
            Else
                strRechnung = strRechnung.Replace("###EMPFÄNGER_FIRMA###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_VORNAME###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_NACHNAME###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_STRASSE###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_PLZ###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_ORT###", "")
                strRechnung = strRechnung.Replace("###EMPFÄNGER_LAND###", "")
            End If

            '# RECHNUNGSNR
            Dim strTime() As String = Date.Now.TimeOfDay.ToString.Split(".")

            If rdoJTLWaWiSave.Checked = True Then
                Dim strRechnungNr As String = frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'"))
                strRechnung = strRechnung.Replace("###RNR###", strRechnungNr)
            Else
                strRechnung = strRechnung.Replace("###RNR###", Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & "-" & strTime(0))
            End If


            '# ARTIKEL EINFÜGEN 
            Dim strArtikel As String = ""
            Dim iCount As Integer = 0
            Dim dblNettGes As Double = 0
            Dim dblBruttoGes As Double = 0
            Dim iLoopMax As Integer = 0

            If My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position) = True Then
                iLoopMax = 2
            Else
                iLoopMax = 1
            End If

            For iCount = 0 To dgvArtikel.Rows.Count - iLoopMax

                '# POS
                strArtikel &= "<tr><td  align=""right"">"
                strArtikel &= iCount + 1
                strArtikel &= "</td>"
                '# Menge
                strArtikel &= "<td align=""center""><font color=""red"">"
                strArtikel &= dgvArtikel.Rows(iCount).Cells(2).Value
                strArtikel &= "</font></td>"
                '# ArtNr.
                strArtikel &= "<td>"
                strArtikel &= dgvArtikel.Rows(iCount).Cells(3).Value
                strArtikel &= "</td>"

                '# NAme
                strArtikel &= "<td>"
                strArtikel &= dgvArtikel.Rows(iCount).Cells(4).Value
                strArtikel &= "</td>"
                '# MwSt.
                strArtikel &= "<td align=""center"">"
                strArtikel &= "19%"
                strArtikel &= "</td>"

                '# E-Netto
                strArtikel &= "<td  align=""right"">"
                strArtikel &= CDbl(dgvArtikel.Rows(iCount).Cells(5).Value).ToString("C").Replace("€", "")
                strArtikel &= "</td>"
                '# E-Brutto 
                strArtikel &= "<td  align=""right"">"
                strArtikel &= CDbl(dgvArtikel.Rows(iCount).Cells(6).Value).ToString("C").Replace("€", "")
                strArtikel &= "</td>"
                '# G-Netto 
                strArtikel &= "<td  align=""right"">"
                strArtikel &= CDbl(dgvArtikel.Rows(iCount).Cells(7).Value).ToString("C").Replace("€", "")
                strArtikel &= "</td>"
                dblNettGes += CDbl(dgvArtikel.Rows(iCount).Cells(7).Value).ToString("C").Replace("€", "")

                '# G-Brutto 
                strArtikel &= "<td  align=""right"">"
                strArtikel &= CDbl(dgvArtikel.Rows(iCount).Cells(8).Value).ToString("C").Replace("€", "")
                strArtikel &= "</td></tr>"
                dblBruttoGes += CDbl(dgvArtikel.Rows(iCount).Cells(8).Value)
            Next
            strRechnung = strRechnung.Replace("###ARTIKEL_DATA###", strArtikel)

            '# Summenbereich
            Dim dblMwSt As Double = dblBruttoGes - dblNettGes
            strRechnung = strRechnung.Replace("###SUMME_NETTO###", dblNettGes.ToString("C").Replace("€", "") & " EUR")
            strRechnung = strRechnung.Replace("###SUMME_MWST###", dblMwSt.ToString("C").Replace("€", "") & " EUR")
            strRechnung = strRechnung.Replace("###SUMME_BRUTTO###", dblBruttoGes.ToString("C").Replace("€", "") & " EUR")

            Return strRechnung
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return "-1"
        End Try
    End Function
    Private Sub ÖffnenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenToolStripButton.Click
        Dim strPathVorlage As String

        OpenFileDialog1.Title = "HTML Rechnungsimport"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            strPathVorlage = OpenFileDialog1.FileName

            DHTMLControll1.DOM.body.innerHTML = ""
            txtVorlageQuellcode.Text = ""

            If LinkLabel1.Text = "HTML" Then
                DHTMLControll1.DOM.body.innerHTML = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Else
                txtVorlageQuellcode.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            End If

        End If
    End Sub

    Private Sub SpeichernToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernToolStripButton.Click
        Dim strHTMLExport As String = ""

        SaveFileDialog1.Title = "JTL Rechnung -> HTML Export"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strHTMLExport = SaveFileDialog1.FileName
        Else
            MsgBox("Es ist ein Fehler beim Speichern aufgetretten", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "JTL Bridge -> Fehler beim Speichern")
        End If


        If LinkLabel1.Text = "HTML" Then
            ' My.Computer.FileSystem.WriteAllText(strHTMLExport, DHTMLControll.DOM.body.innerHTML, False)
        Else
            My.Computer.FileSystem.WriteAllText(strHTMLExport, txtVorlageQuellcode.Text, False)
        End If

        MsgBox("Datei wurde unter '" & strHTMLExport & "' gespeichert", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "JTL Bridge - Datei gespeichert")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Call setLinkLabel1_action(False)
    End Sub
    Private Function setLinkLabel1_action(bEditModeSwitch As Boolean) As Boolean
        If LinkLabel1.Text = "HTML Ansicht" And bEditModeSwitch = False Then
            LinkLabel1.Text = "Design Ansicht"
            txtVorlageQuellcode.Visible = True
            txtVorlageQuellcode.Text = DHTMLControll1.DOM.body.innerHTML
            DHTMLControll1.Visible = False
        Else
            LinkLabel1.Text = "HTML Ansicht"
            DHTMLControll1.DOM.body.innerHTML = txtVorlageQuellcode.Text
            txtVorlageQuellcode.Visible = False
            DHTMLControll1.Visible = True
        End If
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestellungADD.Click
        btnBestellungADD.Enabled = False
        Dim bError As Boolean = False
        Dim bKundeAdd As Boolean = False
        Dim iBestellID As Integer = 0
        Try

            If lvwKunden.Items.Count = 0 Then
                MessageBox.Show("Kann Bestellung nicht in JTL Rechnung anlegen, weil keine Kundendaten für die Bestellung ausgewählt sind!", "Bestellung in JTL anlegen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnBestellungADD.Enabled = True
                Exit Sub
            End If

            '###############################################
            '# Bestellung in JTL übernehmen
            '###############################################
            If rdoJTLWaWiSave.Checked = True Then

                '###############################################
                '# Kein Kunde importiert ? 
                '###############################################
                If lvwKunden.Items(0).SubItems(10).Text = "False" Then
                    'MessageBox.Show("Kundenimport....")
                    Dim frmAddKunde As New frmKunde_neu
                    frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
                    frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
                    frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
                    frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
                    frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
                    frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
                    frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
                    frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
                    frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text
                    frmAddKunde.txtKundengruppe.Text = "Endkunden"
                    If frmJTLRechnung.clsDB.setKunde_neu(frmAddKunde, "tkunde") = True Then
                        bKundeAdd = True
                        MessageBox.Show("Kunde wurde nachträglich in JTL Importiert", "Import Kunde", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show("Kunde wurde nicht Importiert", "Import Kunde", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bError = True
                    End If
                End If

                '###############################################
                '# >> Bestellung Kopfdaten
                '###############################################
                If bError = False Then

                    '########################################################
                    '# Prüfung ob Lieferadresse / Rechnungsadresse vorhanden
                    '########################################################
                    Dim iKID As Integer = 0
                    Dim strJTLKundenNummer As String

                    If bKundeAdd = True Then
                        iKID = frmJTLRechnung.clsDB.iKID
                        strJTLKundenNummer = frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Kunde'"))
                    Else
                        iKID = CInt(lvwKunden.Items(0).SubItems(11).Text)
                        strJTLKundenNummer = lvwKunden.Items(0).Text
                    End If

                    Dim iLieferAdresse As Integer = frmJTLRechnung.clsDB.getAdressKEYS("tlieferadresse", "kLieferAdresse", iKID)
                    If iLieferAdresse = -1 Then
                        Dim frmAddKunde As New frmKunde_neu
                        frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
                        frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
                        frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
                        frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
                        frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
                        frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
                        frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
                        frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
                        frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text
                        frmAddKunde.txtKundengruppe.Text = "Endkunden"

                        frmJTLRechnung.clsDB.setKunde_Lieferadresse(frmAddKunde, strJTLKundenNummer, iKID)
                    End If

                    Dim iRechnungsAdresse As Integer = frmJTLRechnung.clsDB.getAdressKEYS("trechnungsadresse", "kRechnungsAdresse", iKID)
                    If iRechnungsAdresse = -1 Then
                        Dim frmAddKunde As New frmKunde_neu
                        frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
                        frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
                        frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
                        frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
                        frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
                        frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
                        frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
                        frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
                        frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text
                        frmAddKunde.txtKundengruppe.Text = "Endkunden"

                        frmJTLRechnung.clsDB.setKunde_Rechnungsadresse(frmAddKunde, strJTLKundenNummer, iKID)
                    End If

                    '##########################################
                    '# >> Kunden eingefügt
                    '##########################################
                    If bKundeAdd = True Then

                        '#####################
                        '# HEADER EINFÜGEN 
                        '#####################
                        iBestellID = frmJTLRechnung.clsDB.setBestellung_header("-1", "tbestellung")
                        If iBestellID = -1 Then
                            Exit Sub
                        Else
                            '#########################
                            '# Bestell Daten einfügen 
                            '#########################
                            frmJTLRechnung.clsDB.setBestellung_data(dgvArtikel, iBestellID, "tbestellpos")
                        End If
                    Else

                        iBestellID = frmJTLRechnung.clsDB.setBestellung_header(lvwKunden.Items(0).SubItems(11).Text, "tbestellung")
                        If iBestellID = -1 Then
                            Exit Sub
                        Else
                            '#########################
                            '# Bestell Daten einfügen 
                            '######################### 
                            frmJTLRechnung.clsDB.setBestellung_data(dgvArtikel, iBestellID, "tbestellpos")
                        End If
                    End If
                End If
            Else
                '##########################################################################
                '#
                '# >> JTL Zwischenspeicher
                '#
                '##########################################################################
                Dim frmAddKunde As New frmKunde_neu
                frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
                frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
                frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
                frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
                frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
                frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
                frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
                frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
                frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text
                frmAddKunde.txtKundengruppe.Text = "Endkunden"
                frmAddKunde.txtKundenNummer.Text = lvwKunden.Items(0).Text
                If frmJTLRechnung.clsDB.setKunde_neu(frmAddKunde, "cubss_rechnung_kunde") = True Then
                    bKundeAdd = True
                    'MessageBox.Show("Kunde in JTL temporär gespeichert", "Import Kunde", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("Kunde wurde nicht Importiert", "Import Kunde", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bError = True
                End If

                '##########################################
                '# >> Kunden eingefügt
                '##########################################
                If bKundeAdd = True Then

                    '#####################
                    '# HEADER EINFÜGEN 
                    '#####################
                    iBestellID = frmJTLRechnung.clsDB.setBestellung_header("-1", "cubss_rechnung_bestellung")
                    If iBestellID = -1 Then
                        Exit Sub
                    Else
                        '#########################
                        '# Bestell Daten einfügen 
                        '#########################
                        frmJTLRechnung.clsDB.setBestellung_data(dgvArtikel, iBestellID, "cubss_rechnung_bestellung_pos")
                    End If
                Else

                    iBestellID = frmJTLRechnung.clsDB.setBestellung_header(lvwKunden.Items(0).SubItems(11).Text, "cubss_rechnung_bestellung_pos")
                    If iBestellID = -1 Then
                        Exit Sub
                    Else
                        '#########################
                        '# Bestell Daten einfügen 
                        '######################### 
                        frmJTLRechnung.clsDB.setBestellung_data(dgvArtikel, iBestellID, "cubss_rechnung_bestellung_pos")
                    End If
                End If

            End If '# Ende Zwischenspeicher 

            If bError = True Then
                btnBestellungADD.Enabled = True
                If bError = True Then
                    If MessageBox.Show("Vorgang abbrechen, weil Fehler aufgetaucht sind? " & vbCrLf & "Ja: Druckauftrag abbruch und nicht löschen der Bestellung!", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            '# Drucken starten 
            Dim bPrinted As Boolean = False
            If MessageBox.Show("Soll Rechnung ausgedruckt werden?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                webYabeRechnung.Print()
                bPrinted = True
            End If



            '# Archivieren von Rechnungen 
            If chkArchiv.Checked = True Then
                Dim strFilename As String = "RNr." & Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & "--" & Date.Now.Hour & "-" & Date.Now.Minute & ".html"
                Try
                    If IO.Directory.Exists(My.Settings.export_pfad.Item(My.Settings.mandant_position)) = True Then
                        My.Computer.FileSystem.WriteAllText(My.Settings.export_pfad.Item(My.Settings.mandant_position) & "\" & strFilename, webYabeRechnung.DocumentText, False)
                    Else
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\archiv\" & strFilename, webYabeRechnung.DocumentText, False)
                    End If

                Catch ex As Exception

                End Try

            End If

            btnBestellungADD.Enabled = True
            dgvArtikel.Rows.Clear()
            ' My.Settings.mwst = 1.19
            My.Settings.Save()

            Dim strMessageADD As String = ""

            If bPrinted = True Then
                strMessageADD = "Auftrag wird ausgedruckt"
            End If

            '# Meldung schreiben 
            If rdoJTLWaWiSave.Checked = True Then
                MessageBox.Show("Bestellung wurde als Auftrag in JTL WaWi gespeichert!" & vbCrLf & strMessageADD, "JTL WaWi Datenübernahme", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Der Auftrag wurde erfolgreich in das interne Bestellarchiv gespeichert", MsgBoxStyle.Information)
            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Bestellübernahme/Rechnungsdruck" & vbCrLf & "Versuchen Sie den vorgang wiederholen!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBestellungADD.Enabled = True
        End Try
    End Sub

    Private Sub DruckenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DruckenToolStripButton.Click
        DHTMLControll1.PrintDocument()
    End Sub

    Private Sub Bold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bold.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_BOLD)
    End Sub

    Private Sub Hyperlink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hyperlink.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_HYPERLINK)
    End Sub

    Private Sub Suchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Suchen.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_FINDTEXT)
    End Sub

    Private Sub Bild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bild.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_IMAGE)
    End Sub

    Private Sub Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Redo.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_REDO)
    End Sub

    Private Sub Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Undo.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_UNDO)
    End Sub

    Private Sub tabelle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabelle.Click
        'DHTMLControll.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_INSERTTABLE)
    End Sub

    Private Sub webYabeRechnung_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Static bStatic As Boolean

        If bStatic = False Then
            DHTMLControll1.Visible = True
            Application.DoEvents()
            DHTMLControll1.DOM.body.innerHTML = webYabeRechnung.DocumentText
            webYabeRechnung.Visible = False
            bStatic = True
            btnBestellungADD.Enabled = False
            LinkLabel2.Text = "Editiermodus &beenden"
            LinkLabel1.Visible = True
            Call setLinkLabel1_action(True)

        Else
            Dim strFile As String = Application.StartupPath & "\vorlagen\tmp_rechnung.html"
            My.Computer.FileSystem.WriteAllText(strFile, DHTMLControll1.DOM.body.innerHTML, False)
            btnBestellungADD.Enabled = True
            webYabeRechnung.Visible = True
            webYabeRechnung.Navigate(strFile)
            LinkLabel2.Text = "Rechnung &editieren"
            DHTMLControll1.Visible = False
            LinkLabel1.Visible = False
            bStatic = False
        End If


    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub chkArchiv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArchiv.CheckedChanged

    End Sub

    Private Sub chkJTLBestellung_addOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If bIsLoading = False Then
            My.Settings.bestellung_opt_jtl_add.Item(My.Settings.mandant_position) = rdoJTLWaWiSave.Checked
            My.Settings.Save()
            Call getRechnung_show()
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click


        PrintDialog1.Document = docToPrint
        PrintDialog1.UseEXDialog = True
        PrintDialog1.ShowDialog()

        'PageSetupDialog1.AllowPrinter = True        

        'PageSetupDialog1.PageSettings = New System.Drawing.Printing.PageSettings

        ' PageSetupDialog1.PrinterSettings = New System.Drawing.Printing.PrinterSettings

        'PageSetupDialog1.ShowNetwork = True


        'PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub document_PrintPage(ByVal sender As Object,
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
           Handles docToPrint.PrintPage

        Dim text As String = DHTMLControll1.DocumentHTML
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)

        ' Draw the content.
        e.Graphics.DrawString(text, printFont,
            System.Drawing.Brushes.Black, 10, 10)
    End Sub

    Private Sub chkRechnungsdetailsVerkäuferAnzeigen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkRechnungsdetailsVerkäuferAnzeigen.CheckedChanged

        If bIsLoading = False Then

            My.Settings.chkRechnungsdetailVerkäuferAnzeigen(My.Settings.mandant_position) = chkRechnungsdetailsVerkäuferAnzeigen.Checked
            My.Settings.Save()



            Call getRechnung_show()

        End If

    End Sub
    '##########################################################
    '# >> getRechnung_show
    '# Rechnung anzeigen und neuladen 
    '##########################################################
    Private Function getRechnung_show() As Boolean
        Try
            '# Rechnung holen und anzeigen 
            Dim strText As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\vorlagen\master_vorlage.htm")
            strText = getRechnung(strText)
            'DHTMLControll1.DOM.body.innerHTML = "TEST" 
            txtVorlageQuellcode.Text = strText
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\vorlagen\tmp_rechnung.html", strText, False)
            webYabeRechnung.Navigate(Application.StartupPath & "\vorlagen\tmp_rechnung.html")
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei: " & ex.Message, "getRechnung_show", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub NeuToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NeuToolStripButton.Click

    End Sub

    Private Sub AusschneidenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AusschneidenToolStripButton.Click

    End Sub

    Private Sub KopierenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles KopierenToolStripButton.Click

    End Sub

    Private Sub EinfügenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EinfügenToolStripButton.Click

    End Sub

    Private Sub rdoJTLWaWiNotSave_CheckedChanged(sender As Object, e As EventArgs) Handles rdoJTLWaWiNotSave.CheckedChanged
        My.Settings.bestellung_opt_jtl_add.Item(My.Settings.mandant_position) = rdoJTLWaWiSave.Checked
        My.Settings.Save()
    End Sub

    Private Sub rdoJTLWaWiSave_CheckedChanged(sender As Object, e As EventArgs) Handles rdoJTLWaWiSave.CheckedChanged
        My.Settings.bestellung_opt_jtl_add.Item(My.Settings.mandant_position) = rdoJTLWaWiSave.Checked
        My.Settings.Save()
    End Sub
End Class