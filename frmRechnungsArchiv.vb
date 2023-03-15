Public Class frmRechnungsArchiv

    Private Sub frmRechnungsArchiv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Convert.ToBoolean(My.Settings.lvw_colum_save.Item(My.Settings.mandant_position)) = True Then
            Call setLVWColumOrder(lvwRechnungen)
        End If

    End Sub

    Private Sub frmRechnungsArchiv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmRechnungsArchiv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call frmJTLRechnung.setMainWindowTitle("Rechnungsarchiv", Me)

        If Convert.ToBoolean(My.Settings.lvw_colum_save.Item(My.Settings.mandant_position)) = True Then
            Call getLVWColumOrder(lvwRechnungen)
        End If

        Call getData()

    End Sub

    Private Sub lvwRechnungen_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwRechnungen.DoubleClick
        'Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_bestellung.kBestellung=" & lvwRechnungen.SelectedItems(0).SubItems(3).Text, lblSumme, True)
        btnBestellungEditieren.PerformClick()
        'If lvwRechnungen.Items.Count > 0 Then
        '    lblMasterHeader.Text = "Bestellung ansehen"
        '    btnBestellungOpen.Text = "Bestellarchiv"
        '    btnJTLImport.Enabled = True
        '    btnBestellungOpen.Enabled = True
        '    btnBestellungAdd.Enabled = True
        '    btnBestellungEditieren.Enabled = True
        'Else
        '    lblMasterHeader.Text = "Rechnungsarchiv"
        '    btnJTLImport.Enabled = False
        '    btnBestellungAdd.Enabled = False
        '    btnBestellungOpen.Enabled = True
        '    btnBestellungEditieren.Enabled = False
        'End If
    End Sub

    Private Sub AlleAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAnzeigenToolStripMenuItem.Click
        Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported is NULL", lblSumme, DateTimePicker1)
        lblMasterHeader.Text = "Rechnungsarchiv"
        btnJTLImport.Enabled = False
        btnBestellungOpen.Enabled = True
    End Sub

    Private Sub txtSuchenKunde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSuchenKunde.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_kunde.cName like '%" & txtSuchenKunde.Text & "%' OR cubss_rechnung_bestellung_pos.cString LIKE '%" & txtSuchenKunde.Text & "%' ", lblSumme, DateTimePicker1)
            lblMasterHeader.Text = "Rechnungsarchiv"
            btnJTLImport.Enabled = False
            btnBestellungOpen.Enabled = True
        End If
    End Sub

    Private Sub txtSuchenKunde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuchenKunde.TextChanged

    End Sub

    Private Sub BestellungAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BestellungAnzeigenToolStripMenuItem.Click

        If lvwRechnungen.SelectedItems.Count > 0 Then
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_bestellung.kBestellung=" & lvwRechnungen.SelectedItems(0).SubItems(3).Text, lblSumme, DateTimePicker1, True)
            lblMasterHeader.Text = "Bestellung ansehen"
            Call btnSwitcher()
        End If

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If lblMasterHeader.Text = "Bestellung ansehen" Then
            BestellungAnzeigenToolStripMenuItem.Enabled = False
            btnBestellungOpen.Enabled = False
        Else
            BestellungAnzeigenToolStripMenuItem.Enabled = True
            btnBestellungOpen.Enabled = True
        End If
    End Sub

    Private Sub btnBestellungOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestellungOpen.Click

        If btnBestellungOpen.Text.IndexOf("öffnen") > 0 Then
            btnBestellungOpen.Text = "Bestellarchiv"
            lblMasterHeader.Text = "Bestellung ansehen"
            Call btnSwitcher()
            If lvwRechnungen.SelectedItems.Count > 0 Then
                Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_bestellung.kBestellung=" & lvwRechnungen.SelectedItems(0).SubItems(3).Text, lblSumme, DateTimePicker1, True)
                lvwRechnungen.Columns(2).Width = 0
                lvwRechnungen.Columns(4).Width = 0
                lvwRechnungen.Columns(8).Width = 0
                lvwRechnungen.Columns(9).Width = 0
                lvwRechnungen.Columns(10).Width = 0
                lvwRechnungen.Columns(12).Width = 0
                lvwRechnungen.Columns(13).Width = 0
                lvwRechnungen.Columns(14).Width = 0
            End If
        Else
            btnBestellungOpen.Text = "Bestellung öffnen"
            lblMasterHeader.Text = "Bestellarchiv"
            lvwRechnungen.Columns(2).Width = 150
            lvwRechnungen.Columns(4).Width = 100
            lvwRechnungen.Columns(8).Width = 60
            lvwRechnungen.Columns(9).Width = 200
            lvwRechnungen.Columns(10).Width = 80
            lvwRechnungen.Columns(12).Width = 120
            lvwRechnungen.Columns(13).Width = 100
            lvwRechnungen.Columns(14).Width = 120
            Call btnSwitcher()
            If chkImported.Checked = False Then
                Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported is NULL", lblSumme, DateTimePicker1)
            Else
                Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported='1'", lblSumme, DateTimePicker1)
            End If
        End If

    End Sub

    Private Sub btnJTLImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJTLImport.Click

        If lvwRechnungen.SelectedItems.Count > 0 Then

            Dim strKID As String = frmJTLRechnung.clsDB.getKunde_Nr2ID(lvwRechnungen.SelectedItems(0).SubItems(7).Text)

            If strKID = "-1" Then
                Dim frmAddKunde As New frmKunde_neu
                frmAddKunde.txtVorname.Text = lvwRechnungen.SelectedItems(0).SubItems(10).Text
                frmAddKunde.txtNachname.Text = lvwRechnungen.SelectedItems(0).SubItems(2).Text
                frmAddKunde.txtStraße.Text = lvwRechnungen.SelectedItems(0).SubItems(9).Text
                frmAddKunde.txtOrt.Text = lvwRechnungen.SelectedItems(0).SubItems(4).Text
                frmAddKunde.txtPostleitzahl.Text = lvwRechnungen.SelectedItems(0).SubItems(8).Text
                frmAddKunde.txtLand.Text = lvwRechnungen.SelectedItems(0).SubItems(13).Text
                frmAddKunde.txtFirma.Text = lvwRechnungen.SelectedItems(0).SubItems(14).Text
                frmAddKunde.txtTelefon.Text = lvwRechnungen.SelectedItems(0).SubItems(12).Text
                frmAddKunde.txtEmail.Text = lvwRechnungen.SelectedItems(0).SubItems(11).Text
                frmAddKunde.txtKundengruppe.Text = "Endkunden"
                If frmJTLRechnung.clsDB.setKunde_neu(frmAddKunde, "tkunde") = True Then
                    strKID = frmJTLRechnung.clsDB.iKID
                End If
            End If

            Dim iLieferAdresse As Integer = frmJTLRechnung.clsDB.getAdressKEYS("tlieferadresse", "kLieferAdresse", strKID)
            If iLieferAdresse = -1 Then
                Dim frmAddKunde As New frmKunde_neu
                frmAddKunde.txtVorname.Text = lvwRechnungen.SelectedItems(0).SubItems(10).Text
                frmAddKunde.txtNachname.Text = lvwRechnungen.SelectedItems(0).SubItems(2).Text
                frmAddKunde.txtStraße.Text = lvwRechnungen.SelectedItems(0).SubItems(9).Text
                frmAddKunde.txtOrt.Text = lvwRechnungen.SelectedItems(0).SubItems(4).Text
                frmAddKunde.txtPostleitzahl.Text = lvwRechnungen.SelectedItems(0).SubItems(8).Text
                frmAddKunde.txtLand.Text = lvwRechnungen.SelectedItems(0).SubItems(13).Text
                frmAddKunde.txtFirma.Text = lvwRechnungen.SelectedItems(0).SubItems(14).Text
                frmAddKunde.txtTelefon.Text = lvwRechnungen.SelectedItems(0).SubItems(12).Text
                frmAddKunde.txtEmail.Text = lvwRechnungen.SelectedItems(0).SubItems(11).Text
                frmAddKunde.txtKundengruppe.Text = "Endkunden"

                frmJTLRechnung.clsDB.setKunde_Lieferadresse(frmAddKunde, lvwRechnungen.SelectedItems(0).SubItems(7).Text, strKID)
            End If

            Dim iRechnungsAdresse As Integer = frmJTLRechnung.clsDB.getAdressKEYS("trechnungsadresse", "kRechnungsAdresse", strKID)
            If iRechnungsAdresse = -1 Then
                Dim frmAddKunde As New frmKunde_neu
                frmAddKunde.txtVorname.Text = lvwRechnungen.SelectedItems(0).SubItems(10).Text
                frmAddKunde.txtNachname.Text = lvwRechnungen.SelectedItems(0).SubItems(2).Text
                frmAddKunde.txtStraße.Text = lvwRechnungen.SelectedItems(0).SubItems(9).Text
                frmAddKunde.txtOrt.Text = lvwRechnungen.SelectedItems(0).SubItems(4).Text
                frmAddKunde.txtPostleitzahl.Text = lvwRechnungen.SelectedItems(0).SubItems(8).Text
                frmAddKunde.txtLand.Text = lvwRechnungen.SelectedItems(0).SubItems(13).Text
                frmAddKunde.txtFirma.Text = lvwRechnungen.SelectedItems(0).SubItems(14).Text
                frmAddKunde.txtTelefon.Text = lvwRechnungen.SelectedItems(0).SubItems(12).Text
                frmAddKunde.txtEmail.Text = lvwRechnungen.SelectedItems(0).SubItems(11).Text
                frmAddKunde.txtKundengruppe.Text = "Endkunden"

                frmJTLRechnung.clsDB.setKunde_Rechnungsadresse(frmAddKunde, lvwRechnungen.SelectedItems(0).SubItems(7).Text, strKID)
            End If

            '# Rechnungskopf eintragen 
            Dim iBestellID_header As Integer = frmJTLRechnung.clsDB.setBestellung_import_bestellHeader(strKID, lvwRechnungen.SelectedItems(0).SubItems(3).Text)
            If iBestellID_header >= 0 Then

                '# Rechnungsbestellpositionen
                If frmJTLRechnung.clsDB.setBestellung_import_bestellPos(lvwRechnungen.SelectedItems(0).SubItems(3).Text, iBestellID_header) = True Then

                    Call frmJTLRechnung.clsDB.setBestellung_imported(lvwRechnungen.SelectedItems(0).SubItems(3).Text)

                    MessageBox.Show("Ihre Bestellung wurde in JTL importiert", "JTL Bestellung Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub chkImported_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImported.CheckedChanged
        If chkImported.Checked = False Then
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported is NULL", lblSumme, DateTimePicker1)
            Call btnSwitcher()
        Else
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported='1'", lblSumme, DateTimePicker1)
            Call btnSwitcher()
        End If
    End Sub

    Private Sub lvwRechnungen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwRechnungen.KeyDown
        If lvwRechnungen.SelectedItems.Count > 0 Then

            If e.KeyCode = Keys.Enter Then
                If frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_bestellung.kBestellung=" & lvwRechnungen.SelectedItems(0).SubItems(3).Text, lblSumme, DateTimePicker1, True) = True Then

                    If lvwRechnungen.Items.Count > 0 Then
                        lblMasterHeader.Text = "Bestellung ansehen"
                        btnJTLImport.Enabled = True
                        btnBestellungOpen.Enabled = False
                    Else
                        lblMasterHeader.Text = "Rechnungsarchiv"
                        btnJTLImport.Enabled = False
                        btnBestellungOpen.Enabled = True
                    End If
                End If
            End If

            If e.KeyCode = Keys.Back Then
                If chkImported.Checked = False Then
                    Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported is NULL", lblSumme, DateTimePicker1)
                    lblMasterHeader.Text = "Rechnungsarchiv"
                    btnJTLImport.Enabled = False
                    btnBestellungOpen.Enabled = True
                Else
                    Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported='1'", lblSumme, DateTimePicker1)
                    lblMasterHeader.Text = "Rechnungsarchiv"
                    btnJTLImport.Enabled = False
                    btnBestellungOpen.Enabled = True
                End If
            End If

        End If
    End Sub

    Private Sub lvwRechnungen_ColumnReordered(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnReorderedEventArgs) Handles lvwRechnungen.ColumnReordered
        '  Call setLVWColumOrder(lvwRechnungen)
    End Sub

    Private Sub lvwRechnungen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwRechnungen.SelectedIndexChanged
        Call btnSwitcher()
    End Sub

    Private Sub btnSwitcher()
        If btnBestellungOpen.Text = "Bestellarchiv" And lvwRechnungen.SelectedItems.Count > 0 Then
            btnJTLImport.Enabled = True
            btnBestellungAdd.Enabled = True
            btnBestellungAdd.Enabled = True
            ' btnBestellungEditieren.Enabled = True
        Else
            btnJTLImport.Enabled = False
            btnBestellungAdd.Enabled = False
            btnBestellungAdd.Enabled = False
            '  btnBestellungEditieren.Enabled = False
        End If
    End Sub

    Private Sub btnBestellungAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnBestellungAdd.Click
        Dim frmRechnung As New frmRechnungsdruck
        'Dim lvwKunde As New ListView
        Dim lvwKundeItem As New ListViewItem
        lvwKundeItem.Text = lvwRechnungen.SelectedItems(0).SubItems(7).Text

        'If lvwKunden.Items(0).SubItems(10).Text = "False" Then
        '    'MessageBox.Show("Kundenimport....")
        '    Dim frmAddKunde As New frmKunde_neu
        '    frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
        '    frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
        '    frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
        '    frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
        '    frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
        '    frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
        '    frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
        '    frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
        '    frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text

        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(10).Text) ' 1 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(2).Text) ' 2 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(4).Text) ' 3 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(9).Text) ' 4
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(8).Text) ' 5
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(13).Text) ' 6
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(14).Text) '7 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(12).Text) ' 8
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(11).Text) ' 9 
        lvwKundeItem.SubItems.Add("true") ' 10 
        Dim strKID As String = frmJTLRechnung.clsDB.getKunde_Nr2ID(lvwRechnungen.SelectedItems(0).SubItems(7).Text)

        lvwKundeItem.SubItems.Add(strKID)

        lvwKunde.Items.Add(lvwKundeItem)

        frmRechnung.lvwKunden = lvwKunde


        Dim iCount As Integer = 0
        Dim dblNettoGes As Double = 0
        Dim dblBruttoGes As Double = 0
        dgvArtikel.Rows.Clear()
        For iCount = 0 To lvwRechnungen.Items.Count - 1
            'dgvArtikel.Rows.Add() ' 0
            'dgvArtikel.Rows.Add("") ' 1 
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 2  Menge 
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(17).Text) ' 3 Art-Nr
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(0).Text) '4  Produktbezeichnung
            'dgvArtikel.Rows.Add("12") '5  E-Netto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 6  E Brutto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 7  G Netto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) '8 G Brutto 
            dblNettoGes = Convert.ToDouble(lvwRechnungen.Items(iCount).SubItems(5).Text) * CDbl(lvwRechnungen.Items(iCount).SubItems(18).Text.Replace(".", ","))
            dblBruttoGes = Convert.ToDouble(lvwRechnungen.Items(iCount).SubItems(5).Text) * CDbl(lvwRechnungen.Items(iCount).SubItems(1).Text.Replace(".", ","))

            dgvArtikel.Rows.Add("", "", lvwRechnungen.Items(iCount).SubItems(5).Text, lvwRechnungen.Items(iCount).SubItems(17).Text, lvwRechnungen.Items(iCount).SubItems(0).Text, lvwRechnungen.Items(iCount).SubItems(18).Text.Replace("€", "").Replace(".", ","), lvwRechnungen.Items(iCount).SubItems(1).Text.Replace("€", "").Replace(".", ","), dblNettoGes.ToString("C").Replace("€", ""), dblBruttoGes.ToString("C").Replace("€", ""), "1", lvwRechnungen.Items(iCount).SubItems(19).Text, "0")

        Next
        frmRechnung.dgvArtikel = dgvArtikel
        frmRechnung.ShowDialog()
    End Sub

    Private Sub btnBestellungEditieren_Click(sender As System.Object, e As System.EventArgs) Handles btnBestellungEditieren.Click
        Dim iCount As Integer = 0
        Dim dblNettoGes As Double = 0
        Dim dblBruttoGes As Double = 0

        If frmJTLRechnung.dgvArtikel.Rows.Count > 0 Then
            If MessageBox.Show("Es befinden sich noch Bestellungen in der Bestellansicht, möchten Sie die aktuelle Bestellung verwerfen?", "Bestellung anlegen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                frmJTLRechnung.dgvArtikel.Rows.Clear()
            Else
                MessageBox.Show("Bitte löschen Sie die Artikel aus der Bestellansicht", "Bestellung anlegen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE cubss_rechnung_bestellung.kBestellung=" & lvwRechnungen.SelectedItems(0).SubItems(3).Text, lblSumme, DateTimePicker1, True)
        Application.DoEvents()
        'frmJTLRechnung.dgvArtikel.Rows.Clear()
        For iCount = 0 To lvwRechnungen.Items.Count - 1
            'dgvArtikel.Rows.Add() ' 0
            'dgvArtikel.Rows.Add("") ' 1 
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 2  Menge 
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(17).Text) ' 3 Art-Nr
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(0).Text) '4  Produktbezeichnung
            'dgvArtikel.Rows.Add("12") '5  E-Netto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 6  E Brutto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) ' 7  G Netto
            'dgvArtikel.Rows.Add(lvwRechnungen.SelectedItems(0).SubItems(5).Text) '8 G Brutto 
            dblNettoGes = Convert.ToDouble(lvwRechnungen.Items(iCount).SubItems(5).Text) * CDbl(lvwRechnungen.Items(iCount).SubItems(18).Text.Replace(".", ","))
            dblBruttoGes = Convert.ToDouble(lvwRechnungen.Items(iCount).SubItems(5).Text) * CDbl(lvwRechnungen.Items(iCount).SubItems(1).Text.Replace(".", ","))
            Dim nImageCell As New DataGridViewImageCell
            If IO.File.Exists(Application.StartupPath & "\bilderexport\" & lvwRechnungen.Items(iCount).SubItems(17).Text & ".jpg") = True Then
                nImageCell.Value = System.Drawing.Image.FromFile(Application.StartupPath & "\bilderexport\" & lvwRechnungen.Items(iCount).SubItems(17).Text & ".jpg")
            Else
                nImageCell.Value = System.Drawing.Image.FromFile(Application.StartupPath & "\keinbild.jpg")
            End If
            frmJTLRechnung.dgvArtikel.Rows.Add(frmJTLRechnung.ImageList2.Images.Item(0), nImageCell.Value, lvwRechnungen.Items(iCount).SubItems(5).Text, lvwRechnungen.Items(iCount).SubItems(17).Text, lvwRechnungen.Items(iCount).SubItems(0).Text, lvwRechnungen.Items(iCount).SubItems(18).Text.Replace("€", "").Replace(".", ","), lvwRechnungen.Items(iCount).SubItems(1).Text.Replace("€", "").Replace(".", ","), dblNettoGes.ToString("C").Replace("€", ""), dblBruttoGes.ToString("C").Replace("€", ""), "1", lvwRechnungen.Items(iCount).SubItems(19).Text, "0")

        Next
        frmJTLRechnung.getDGV_sum()
        frmJTLRechnung.lvwKunde.Items.Clear()

        Dim lvwKundeItem As New ListViewItem
        lvwKundeItem.Text = lvwRechnungen.SelectedItems(0).SubItems(7).Text

        'If lvwKunden.Items(0).SubItems(10).Text = "False" Then
        '    'MessageBox.Show("Kundenimport....")
        '    Dim frmAddKunde As New frmKunde_neu
        '    frmAddKunde.txtVorname.Text = lvwKunden.Items(0).SubItems(1).Text
        '    frmAddKunde.txtNachname.Text = lvwKunden.Items(0).SubItems(2).Text
        '    frmAddKunde.txtStraße.Text = lvwKunden.Items(0).SubItems(4).Text
        '    frmAddKunde.txtOrt.Text = lvwKunden.Items(0).SubItems(3).Text
        '    frmAddKunde.txtPostleitzahl.Text = lvwKunden.Items(0).SubItems(5).Text
        '    frmAddKunde.txtLand.Text = lvwKunden.Items(0).SubItems(6).Text
        '    frmAddKunde.txtFirma.Text = lvwKunden.Items(0).SubItems(7).Text
        '    frmAddKunde.txtTelefon.Text = lvwKunden.Items(0).SubItems(8).Text
        '    frmAddKunde.txtEmail.Text = lvwKunden.Items(0).SubItems(9).Text

        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(10).Text) ' 1 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(2).Text) ' 2 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(4).Text) ' 3 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(9).Text) ' 4
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(8).Text) ' 5
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(13).Text) ' 6
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(14).Text) '7 
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(12).Text) ' 8
        lvwKundeItem.SubItems.Add(lvwRechnungen.SelectedItems(0).SubItems(11).Text) ' 9 
        lvwKundeItem.SubItems.Add("true") ' 10 
        Dim strKID As String = frmJTLRechnung.clsDB.getKunde_Nr2ID(lvwRechnungen.SelectedItems(0).SubItems(7).Text)

        lvwKundeItem.SubItems.Add(strKID)

        frmJTLRechnung.lvwKunde.Items.Add(lvwKundeItem)

        frmJTLRechnung.lblKundenData.Text = "Kunde: " & frmJTLRechnung.lvwKunde.Items(0).SubItems(7).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(1).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(2).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(5).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(3).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(4).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(8).Text & " " & frmJTLRechnung.lvwKunde.Items(0).SubItems(9).Text
        frmJTLRechnung.lblKundennummer.Text = frmJTLRechnung.lvwKunde.Items(0).SubItems(0).Text
        Call getGoogleMapsDistanz()

        Me.Close()
    End Sub
    Private Sub getData()
        If chkImported.Checked = False Then
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported is NULL AND dErstellt  >= @dErstelltam AND dErstellt  <= @dErstelltam2", lblSumme, DateTimePicker1, False)
        Else
            Call frmJTLRechnung.clsDB.getArchiv(lvwRechnungen, " WHERE bImported='1' AND dErstellt  >= @dErstelltam AND dErstellt  <= @dErstelltam2", lblSumme, DateTimePicker1, False)
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Call getData()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-1)
    End Sub

    Private Sub btnVor_Click(sender As Object, e As EventArgs) Handles btnVor.Click
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(+1)
    End Sub

    Private Sub BestellungLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BestellungLöschenToolStripMenuItem.Click

        If MessageBox.Show("Möchten Sie diese Bestellung löschen?", "Bestellung löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            frmJTLRechnung.clsDB.setDeleteArchiv_bestellung(lvwRechnungen.SelectedItems(0).SubItems(3).Text, lvwRechnungen.SelectedItems(0).SubItems(7).Text)
            lvwRechnungen.SelectedItems(0).Remove()
        End If
    End Sub
End Class