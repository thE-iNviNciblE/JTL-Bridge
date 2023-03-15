Public Class frmJTLRechnung

    Public clsDB As New clsDatenbank
    Public bSetMwst_rewrite As Boolean = False
    Public dblRabatt_newPrice As Double = 0
    Public btnArray(30) As Button ' Dies wird das Control-Array!
    Public bIsLoading As Boolean = True
    Dim btnAlleKategorien As Button
    '###################################################################
    '# >> Spracheinstellungen laden 
    '###################################################################
    Public Sub New()
        MyBase.New()
        Try
            'System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.app_language.Item(My.Settings.mandant_position))
            If My.Settings.mandant_position < 0 Then
            Else
                System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(My.Settings.app_language.Item(My.Settings.mandant_position))
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(My.Settings.app_language.Item(My.Settings.mandant_position))
            End If

            InitializeComponent()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmJTLRechnung_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        ' Shell(Application.StartupPath & "\JTL Bridge.exe", AppWinStyle.MaximizedFocus, True)
    End Sub

    '###################################################################
    '# >> Speichern der Spalteneinstellungen
    '###################################################################
    Private Sub frmJTLRechnung_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.lvw_colum_save.Item(My.Settings.mandant_position) = True Then
            If My.Settings.first_start = False Then
                Call setLVWColumOrder(lvwArtikel_alle)
            Else
                MessageBox.Show("Bitte das Programm gleich selbst neustarten!", "JTL Bridge neustarten", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    '###################################################################
    '# >> Fenstertitel anzeigen 
    '###################################################################
    Public Function setMainWindowTitle(ByVal strFormularName As String, ByVal frmForm As Form) As Boolean
        Try
            If strFormularName.Length > 0 Then
                frmForm.Text = "JTL Bridge - " & strFormularName & " - Mandant: " & My.Settings.mandant_letzter_name & " v." & strVersionsNummer
            Else
                frmForm.Text = "JTL Bridge - Mandant: " & My.Settings.mandant_letzter_name & " v." & strVersionsNummer
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "setMainWindowTitle", MessageBoxButtons.OK)
            Return False
        End Try
    End Function

    '#############################################################################
    '# >> Aktuell ausgewählten Datensatz anzeigen im Listview 
    '#############################################################################
    Public Function setLvwKundenUpdate(ByVal lvwItem As ListViewItem) As Boolean
        Try
            lvwKunde.Items.Clear()
            lvwKunde.Items.Add(lvwItem)
            lvwKunde.Items(lvwKunde.Items.Count - 1).Selected = True
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "setLvwKundenUpdate")
            Return False
        End Try
    End Function
    Private Sub frmJTLRechnung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call setMainWindowTitle("", Me)

        bIsLoading = True
        Application.DoEvents()
        '###################################################################
        '# >> Demoversion
        '###################################################################
        '# KEY - Crypt holen 
        gbl_KeyCode = getWMI_KeyCode()
        Dim strServerInfo() As String = getHTTPResponseMessage("https://api.bludau-media.de/SafeSandy/IsRegistered.php?key=" & gbl_KeyCode & "&versionsnummer=" & strVersionsNummer, mgetUpdaterMessage.getIstBuyed, True)
        If Not strServerInfo(0) = "GEKAUFT" Then
            Dim frmRegisterJTLBridge As New frmDemoVersion
            frmRegisterJTLBridge.ShowDialog()
        End If


        '#################################################################
        '# >> Keine Datenbankverbindungsmöglichkeiten vorhanden erster Start 
        '#################################################################
        If My.Settings.mandant_position = -1 Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
            Me.Close()
            Exit Sub
        End If
        Application.DoEvents()
        My.Settings.first_start = False
        My.Settings.Save()




        '##################################################
        '# >> Standarddatenbank easzybusiness Connection 
        '##################################################
        If clsDB.strConnectionString_eazybusiness = "" Then
            Dim iDefaultDB As Integer = getMySettingsPositionByDatabase("eazybusiness")

            '# Es konnte keine Standarddatenbank gefunden werden 
            If iDefaultDB = -1 Then
                iDefaultDB = 0
            End If

            Dim strCon2 As String = "server=" & My.Settings.db_server.Item(iDefaultDB) & ";uid=" & My.Settings.db_username.Item(iDefaultDB) & ";pwd=" & My.Settings.db_passwort.Item(iDefaultDB) & ";database=" & My.Settings.db_datenbankname.Item(iDefaultDB) & ";"
            If clsDB.getDBConnect(strCon2, True) = False Then
                Dim frmDBSetting As New frmDatenbankEinstellungen
                frmDBSetting.ShowDialog()
            End If
        End If

        '######################################################
        '# >> Mandantendatenbank auswählen 
        '######################################################
        If My.Settings.db_server(My.Settings.mandant_position) = "" Or My.Settings.db_datenbankname(My.Settings.mandant_position) = "" Or My.Settings.db_passwort(My.Settings.mandant_position) = "" Or My.Settings.db_username(My.Settings.mandant_position) = "" Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
        End If

        Dim strCon As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"

        If clsDB.getDBConnect(strCon) = False Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()

        End If


        '################################
        '# >> Login einbauen
        '################################
        Dim bLoginOK As Boolean = False
        If My.Settings.login_automodus.Item(My.Settings.mandant_position) = True And My.Settings.login_passwort.Item(My.Settings.mandant_position).Length > 0 Then
            If clsDB.getJTLLogin(My.Settings.login_username.Item(My.Settings.mandant_position), My.Settings.login_passwort.Item(My.Settings.mandant_position)) = True Then
                bLoginOK = True
            End If
        End If

        '###################################################
        '# >> Spaltensortierung laden 
        '####################################################
        Try
            If My.Settings.lvw_colum_save.Item(My.Settings.mandant_position) = True Then
                Application.DoEvents()
                Call getLVWColumOrder(lvwArtikel_alle)
            End If
        Catch ex As Exception
            '# Kein gültiger Mandant gefunden Fehler ... 
        End Try

        'If bLoginOK = False Then
        '    My.Settings.login_ok = False
        '    While My.Settings.login_ok = False
        '        Dim frmLogin As New frmLogin
        '        Try
        '            If frmLogin.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
        '                If My.Settings.login_ok = False Then
        '                    If MessageBox.Show("Programm beenden?", "Beenden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '                        Application.Exit()
        '                        Exit While
        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception
        '            Application.Exit()
        '            Exit While
        '        End Try
        '    End While
        'End If

        '######################################
        '# >> Sprachauswahl laden 
        '#######################################
        Select Case My.Settings.app_language.Item(My.Settings.mandant_position)
            Case "en"
                EnglischToolStripMenuItem.Checked = True
            Case "de-DE"
                DeutschToolStripMenuItem.Checked = True
            Case "vi"
                VietnamesischToolStripMenuItem.Checked = True
        End Select

        If Convert.ToBoolean(My.Settings.bLagerverwaltung.Item(My.Settings.mandant_position)) = True Then
            LagerverwaltungAktivierenToolStripMenuItem.PerformClick()
        End If

        '#########################################################
        '# >> Datagrid in Artikelansicht Vorschaubilder erlauben 
        '#########################################################
        Try
            lvwArtikel_alle.SmallImageList = ImageList1
            lvwArtikel_alle.LargeImageList = ImageList1
        Catch ex As Exception
            ' Bilder könnnen nicht angezeigt werden 
        End Try

        dgvArtikel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Try
            dgvArtikel.AllowUserToAddRows = Convert.ToBoolean(My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position))
        Catch ex As Exception
            dgvArtikel.AllowUserToAddRows = False
        End Try




        '#################################################################
        '# >> Standardmandanten laden - eazybusiness Standarddatenbank
        '#################################################################
        Call clsDB.setMandantbyCombobox(cmbMandantenauswahl, False)

        '# Datenbank Update
        If IO.File.Exists(Application.StartupPath & "\SQL\Update.txt") = True Then
            Dim strDatenbank As String = ""
            For iCount As Integer = 0 To cmbMandantenauswahl.Items.Count - 1
                strDatenbank = clsDB.getMandantDatabaseByMandantName(cmbMandantenauswahl.Items(iCount))
                If setUpdateDatabase(strDatenbank, True) = False Then
                    MessageBox.Show("Fehler beim Datenbankupdate", "btnDBTest", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
            IO.File.Delete(Application.StartupPath & "\SQL\Update.txt")
        End If

        '#####################################################################
        '# Kategorie Knöpfe erzeugen
        '#####################################################################
        Call setCategoryAddButtons()
        'SplitContainer4.SplitterDistance = FlowLayoutPanel1.Height
        SplitContainer4.SplitterDistance = FlowLayoutPanel1.VerticalScroll.Maximum + 2

        '#########################################################################
        '# Datagrid Spalten Ausrichten
        '#########################################################################
        'dgvArtikel.Columns("colBestellNetto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        'dgvArtikel.Columns("colBestellBrutto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvArtikel.Columns("colBestellNettoGes").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvArtikel.Columns("colBestellBruttoGes").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


        '#############################################
        '# Benzinpreis API abrufen
        '#############################################
        If My.Settings.bGoogleBenzinpreis(My.Settings.mandant_position) = True Then
            Call getBenzinPreisAPI()
        End If


        '# Programm beenden, weil Demoversion
        If bExitProgramm = True Then
            Me.Close()
        End If

        If My.Settings.chkEinkaufsspalte = True Then
            lvwArtikel_alle.Columns(6).Width = 0
            lvwArtikel_alle.Columns(7).Width = 0
        End If

        Dim strServerInfo1() As String = getHTTPResponseMessage("https://api.bludau-media.de/SafeSandy/Update.php?key=" & gbl_KeyCode & "&programID=1&versionsnummer=" & strVersionsNummer & "&KeinUpdate=1", mgetUpdaterMessage.getProgramUpdateCheck, True)

        If Not strServerInfo1(0) = "VERSION_AKTUELL" Then
            Dim frmUpdater As New frmUpdater
            frmUpdater.ShowDialog()
        End If

        If My.Settings.strKassenKundenID(My.Settings.mandant_position).Length = 0 Then
            Me.Text &= " - Kein Kassenkunde ausgewählt!"
        Else
            Me.clsDB.getKundenListe_suchen(My.Settings.strKassenKundenID(My.Settings.mandant_position), lvwKunde)
            If lvwKunde.Items.Count > 0 Then
                Me.lblKundenData.Text = "Kunde: " & lvwKunde.Items(0).SubItems(7).Text & " >> " & lvwKunde.Items(0).SubItems(1).Text & " " & lvwKunde.Items(0).SubItems(2).Text & " | " & lvwKunde.Items(0).SubItems(3).Text & " | " & lvwKunde.Items(0).SubItems(5).Text & " " & lvwKunde.Items(0).SubItems(4).Text & " | " & lvwKunde.Items(0).SubItems(8).Text
                Me.lblKundennummer.Text = lvwKunde.Items(0).SubItems(0).Text

            End If
        End If

        bIsLoading = False



    End Sub

    '################################################################################
    '# >> Dynamische Knöpfe löschen
    '################################################################################
    Public Function setCategoryDeleteButtons() As Boolean
        Try

            Me.FlowLayoutPanel1.Controls.Remove(btnAlleKategorien)

            '# dynamische Buttons neu erzeugen
            For i As Integer = 0 To clsDB.getKategorieOberKategorie_count(0) - 1
                Me.FlowLayoutPanel1.Controls.Remove(btnArray(i))
            Next

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "setCategoryDeleteButtons", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '################################################################################
    '# >> Knopf Alle Kategorien 
    '################################################################################
    Public Function funcAlleKategorien() As Boolean

        Try
            'clsDB.getArtikelListe_alle(lvwArtikel_alle, ImageList1)
            'TabControl1.SelectedIndex = 0
            'msgMaster.Text = "Artikel: " & lvwArtikel_alle.Items.Count - 1
            TabControl1.SelectedIndex = 1
            'btnCatAlle.Enabled = False
            lvwArtikel_kategorien.Items.Clear()

            '# Alle Kategorien + Unterkategorien anzeigen 
            Call clsDB.getKategorie(0, lvwArtikel_kategorien, 0)

            'btnCatAlle.Enabled = True
            lblÜberschrift.Text = "Alle Hauptkategorien"
            msgMaster.Text = "| Kategorien: " & lvwArtikel_kategorien.Items.Count

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler beim Anlegen des Knopfs für alle Kategorien")
            Return False
        End Try
    End Function
    '################################################################################
    '# >> Dynamische Knöpfe erzeugen 
    '################################################################################
    Public Function setCategoryAddButtons() As Boolean
        Try
            Dim iAbstandX As Integer = 10 ' px 
            Dim iAbstandY As Integer = 4 ' px 
            Dim strArrayButton(1) As String


            '##########################################################
            '# Alle Kategorien 
            '##########################################################
            '# Neuen Button erzeugen
            btnAlleKategorien = New Button
            btnAlleKategorien.Parent = FlowLayoutPanel1
            btnAlleKategorien.Parent.Controls.Add(btnAlleKategorien)

            '# Verwaltungsinformationen zuweisen
            btnAlleKategorien.Name = "Button(Alle)"
            btnAlleKategorien.TabIndex = 0
            btnAlleKategorien.Text = "Alle"
            btnAlleKategorien.Size = New Size(100, 36)

            '# Auf das Click-Ereignis reagieren können!!!
            AddHandler btnAlleKategorien.Click, AddressOf funcAlleKategorien


            '# dynamische Buttons neu erzeugen
            For i As Integer = 0 To clsDB.getKategorieOberKategorie_count(0) - 1

                '# Neuen Button erzeugen
                btnArray(i) = New Button

                '# Den erzeugten Button verwenden:
                With btnArray(i)

                    '# Parent festlegen und Controls-Collection erweitern
                    '.Parent = SplitContainer4.Panel1
                    .Parent = FlowLayoutPanel1
                    .Parent.Controls.Add(btnArray(i))

                    '# Verwaltungsinformationen zuweisen
                    .Name = "Button(" & CStr(i) & ")"
                    .TabIndex = i

                    '# Darstellung: Beschriften und positionieren
                    strArrayButton = clsDB.getKategorieOberKategorie(0, i)
                    If strArrayButton(0).IndexOf("&") >= 0 Then
                        strArrayButton(0) = strArrayButton(0).Replace("&", " && ") '# Label setzen 
                    End If

                    .Text = strArrayButton(0)
                    .Size = New Size(100, 36)

                    '# Abstand auf der X-Achse 
                    If i = 0 Then
                        iAbstandX = 0
                    Else
                        iAbstandX += 105
                    End If

                    '# Abstand auf der Y-Achse 
                    If i = 7 Then
                        iAbstandY += 40
                        iAbstandX = 0
                    End If

                    .Location = New Point(64 + iAbstandX, iAbstandY) '* .Height)
                    .Visible = True

                    '# Auf das Click-Ereignis reagieren können!!!
                    AddHandler .Click, AddressOf btnArray_Click

                End With

            Next i

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "setCategoryAddButtons", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '#################################################################
    '# >> Kategorie Artikel auswählen
    '#################################################################
    Private Sub btnArray_Click(ByVal sender As Object, _
                           ByVal e As System.EventArgs)
        '# Click-Ereignis des Button-Arrays auswerten
        Dim itemClicked As Button = CType(sender, Button)
        Dim index As Integer = -1I
        Dim strOutput(1) As String

        '# Das betroffene Element im Array suchen (allgemein);
        '# Möglich wäre etwa auch das Vorgehen über die eigens
        '# zugewiesene Name-Eigenschaft des Buttons.
        For i As Integer = LBound(btnArray) To UBound(btnArray)
            If btnArray(i) Is itemClicked Then
                index = i
                Exit For
            End If
        Next

        If index >= 0 Then '# Element im Array gefunden (sonst index = -1)
            '# Kurze MessageBox
            'MessageBox.Show("Sie haben den Button Nr. " & CStr(index) & " angeklickt")


            strOutput = clsDB.getKategorieOberKategorie(0, index)

            TabControl1.SelectedIndex = 1

            '# Kategorien abrufen in Listview 
            lvwArtikel_kategorien.Items.Clear() ' Listview löschen
            Call clsDB.getKategorie(strOutput(1), lvwArtikel_kategorien, 0)

            If Not strOutput(0).IndexOf("amp;") >= 0 Then
                lblÜberschrift.Text = strOutput(0).Trim  '# Label setzen 
            Else
                lblÜberschrift.Text = strOutput(0).Replace("amp;", "&").Trim  '# Label setzen 
            End If

            msgMaster.Text = "| Kategorien: " & lvwArtikel_kategorien.Items.Count

            '#############################################
            '# Keine Kategorie gefunden
            '#############################################
            If lvwArtikel_kategorien.Items.Count = 0 Then

                TabControl1.SelectedIndex = 0
                Call clsDB.getKategorie2Artikel(strOutput(1), lvwArtikel_alle, ImageList1)
                lvwArtikel_kategorien.Enabled = True

                '# Überschrift ausgeben
                Dim str() As String = lblÜberschrift.Text.Split("->")
                If str.Length > 0 Then
                    lblÜberschrift.Text = str(0).Trim & " -> " & strOutput(0).Replace("amp;", "&").Trim
                Else
                    lblÜberschrift.Text &= " -> " & strOutput(0).Replace("amp;", "&").Trim
                End If

                msgMaster.Text = "| Artikel in der Kategorie: " & lvwArtikel_alle.Items.Count
            End If
        End If

    End Sub

    Private Function getTest() As Boolean
        Dim lvwItem As New ListViewItem




        lvwItem.SubItems.Add("T-E")
        'Dim imageListLarge As New ImageList()

        ' imageListLarge.Images.Add(Bitmap.FromFile("C:\Users\illixi\Desktop\test.bmqp"))
        ImageList1.Images.Add("name", Bitmap.FromFile("E:\Programmierung - Codeing\VB .NET\Visual Basic Projekte_illixi\Visual Basic Projekte_illixi\maiwell_form\maiwell_form\bin\Debug\bilderexport\test.jpg"))

        lvwItem.ImageKey = "name"
        lvwArtikel_alle.Items.Add(lvwItem)

        Dim lvwItem2 As New ListViewItem
        lvwItem2.ImageKey = "spa.jpg"
        lvwItem2.SubItems.Add("Test")
        lvwArtikel_alle.Items.Add(lvwItem2)
        Return True
    End Function

    Private Sub DatenbankeinstellungenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatenbankeinstellungenToolStripMenuItem.Click
        Dim frmDBSetting As New frmDatenbankEinstellungen
        frmDBSetting.ShowDialog()
 
    End Sub

    Private Sub btnCatAlle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clsDB.getArtikelListe_alle(lvwArtikel_alle, ImageList1)
        TabControl1.SelectedIndex = 0
        msgMaster.Text = "| Artikel in der Kategorie: " & lvwArtikel_alle.Items.Count - 1
    End Sub

    Private Sub txtSuchbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtSuchbox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
 



    Private Sub txtSuchenKunde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub lvwArtikel_alle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)



    End Sub

    Public Function setDataToGrid(ByVal dgv As DataGridView, ByVal lvwDataArtikel As ListView) As Boolean
        Try
            Dim iMenge As Integer = 1
            Dim dblNettoGes As Double = 0
            Dim dblBruttoGes As Double = 0
            Dim iCount As Integer = 0
            Dim bNew As Boolean = True
            Dim iPos As Integer = -1
            Dim dblEndNettoGes As Double = 0
            Dim dblEndBruttoGes As Double = 0

            For iCount = 0 To dgv.Rows.Count - 1
                If dgv.Rows(iCount).Cells(3).Value = lvwDataArtikel.SelectedItems(0).SubItems(1).Text Then
                    bNew = False
                    iPos = iCount
                    iMenge = CInt(dgv.Rows(iCount).Cells(2).Value)
                    iMenge += 1
                    Exit For
                End If
            Next
            'Dim iLast As Integer = dgv.Rows.Count - 1
            'DataGridView1.Rows.Item(0).Cells(0).Value = lvwDataArtikel.SelectedItems(0).Text
            'DataGridView1.Rows.Item(0).Cells(1).Value = lvwDataArtikel.SelectedItems(0).SubItems(2).Text
            'DataGridView1.Rows.Item(0).Cells(2).Value = lvwDataArtikel.SelectedItems(0).SubItems(3).Text
            'DataGridView1.Rows.Item(0).Cells(3).Value = lvwDataArtikel.SelectedItems(0).SubItems(4).Text
            'DataGridView1.Rows.Item(0).Cells(4).Value = "1"
            'DataGridView1.Rows.Insert(0, 1)
            dblNettoGes = iMenge * CDbl(lvwDataArtikel.SelectedItems(0).SubItems(3).Text)
            dblBruttoGes = iMenge * CDbl(lvwDataArtikel.SelectedItems(0).SubItems(4).Text)

            'Dim img As New DataGridViewImageColumn()
            ' Dim inImg As Image = Image.FromFile("E:\Programmierung - Codeing\VB .NET\Visual Basic Projekte_illixi\Visual Basic Projekte_illixi\maiwell_form\maiwell_form\bin\Debug\bilderexport\AC0004.jpg")
            'img.Image = inImg
            ' DataGridView1.Columns.Add(img)
            Dim nImageCell As New DataGridViewImageCell
            If IO.File.Exists(Application.StartupPath & "\bilderexport\" & lvwDataArtikel.SelectedItems(0).SubItems(1).Text & ".jpg") = True Then
                nImageCell.Value = System.Drawing.Image.FromFile(Application.StartupPath & "\bilderexport\" & lvwDataArtikel.SelectedItems(0).SubItems(1).Text & ".jpg")
            Else
                nImageCell.Value = System.Drawing.Image.FromFile(Application.StartupPath & "\keinbild.jpg")
            End If

            If bNew = True Then
                'dgv.Rows.Add(nImageCell.Value, iMenge, lvwDataArtikel.SelectedItems(0).SubItems(1).Text, lvwDataArtikel.SelectedItems(0).SubItems(2).Text, lvwDataArtikel.SelectedItems(0).SubItems(3).Text.Replace("€", ""), lvwDataArtikel.SelectedItems(0).SubItems(4).Text.Replace("€", ""), dblNettoGes, dblBruttoGes, lvwDataArtikel.SelectedItems(0).SubItems(5).Text)

                dgv.Rows.Add(ImageList2.Images.Item(0), nImageCell.Value, iMenge, lvwDataArtikel.SelectedItems(0).SubItems(1).Text, lvwDataArtikel.SelectedItems(0).SubItems(2).Text, lvwDataArtikel.SelectedItems(0).SubItems(3).Text.Replace("€", ""), lvwDataArtikel.SelectedItems(0).SubItems(4).Text.Replace("€", ""), dblNettoGes.ToString("C").Replace("€", ""), dblBruttoGes.ToString("C").Replace("€", ""), lvwDataArtikel.SelectedItems(0).SubItems(5).Text, lvwDataArtikel.SelectedItems(0).SubItems(9).Text, lvwDataArtikel.SelectedItems(0).SubItems(8).Text)
                dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1
            Else

                dgv.Rows(iPos).Cells(2).Value = iMenge
                dgv.Rows(iPos).Cells(7).Value = dblNettoGes.ToString("C").Replace("€", "")
                dgv.Rows(iPos).Cells(8).Value = dblBruttoGes.ToString("C").Replace("€", "")
                dgv.Rows(iPos).Cells(9).Value = lvwDataArtikel.SelectedItems(0).SubItems(5).Text
                dgv.Rows(iPos).Cells(10).Value = lvwDataArtikel.SelectedItems(0).SubItems(9).Text
                dgv.Rows(iPos).Cells(11).Value = lvwDataArtikel.SelectedItems(0).SubItems(8).Text
                dgv.FirstDisplayedScrollingRowIndex = iPos
            End If

            lblGesammtsumme.Text = "| Netto: " & Math.Round(dblEndNettoGes, 2) & "Euro | Brutto: " & Math.Round(dblEndBruttoGes, 2) & " Euro | "
            Return (True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim hinzufügen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub DataGridView1_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvArtikel.CellStateChanged

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtikel.CellValueChanged

    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtikel.CellEndEdit
        Dim iMenge As Integer = 0
        Dim dblNettoGes As Double = 0
        Dim dblBruttoGes As Double = 0

        '# Brutto Änderung
        If e.ColumnIndex = 5 Then
            Dim sum As Double = dgvArtikel.Rows(e.RowIndex).Cells(5).Value * (dgvArtikel.Rows(e.RowIndex).Cells(10).Value / 100) '+ 1
            sum = Math.Round(sum, 2) + dgvArtikel.Rows(e.RowIndex).Cells(5).Value
            dgvArtikel.Rows(e.RowIndex).Cells(6).Value = sum.ToString("C").Replace("€", "")
        End If

        '# Netto Änderung 
        If e.ColumnIndex = 6 Then
            Dim sum As Double = (CDbl(dgvArtikel.Rows(e.RowIndex).Cells(6).Value) / ((100 / dgvArtikel.Rows(e.RowIndex).Cells(10).Value) + 1))
            sum = CDbl(dgvArtikel.Rows(e.RowIndex).Cells(6).Value) - Math.Round(sum, 2)
            dgvArtikel.Rows(e.RowIndex).Cells(5).Value = sum.ToString("C").Replace("€", "")
        End If

        '# Daten übernehmen 
        iMenge = CInt(dgvArtikel.Rows(e.RowIndex).Cells(2).Value)
        dblNettoGes = iMenge * CDbl(dgvArtikel.Rows(e.RowIndex).Cells(5).Value)
        dblBruttoGes = iMenge * CDbl(dgvArtikel.Rows(e.RowIndex).Cells(6).Value)
        dgvArtikel.Rows(e.RowIndex).Cells(7).Value = dblNettoGes.ToString("C").Replace("€", "")
        dgvArtikel.Rows(e.RowIndex).Cells(8).Value = dblBruttoGes.ToString("C").Replace("€", "")
        'End If

        Call getDGV_sum()
    End Sub

    Public Function getDGV_sum() As Boolean

        Dim iCount As Integer = 0
        Dim dblNettoGes As Double
        Dim dblBruttoGes As Double = 0
        Dim iMenge As Integer = 0
        Dim dblGewicht As Double = 0

        For iCount = 0 To dgvArtikel.Rows.Count - 1
            dblNettoGes += dgvArtikel.Rows(iCount).Cells(7).Value
            dblBruttoGes += dgvArtikel.Rows(iCount).Cells(8).Value
            iMenge += CInt(dgvArtikel.Rows(iCount).Cells(2).Value)
            dblGewicht += Convert.ToDouble(dgvArtikel.Rows(iCount).Cells(11).Value)
            Application.DoEvents()
        Next

        lblGesammtsumme.Text = "| Netto: " & Math.Round(dblNettoGes, 2) & " € | Brutto: " & Math.Round(dblBruttoGes, 2) & " € | MwSt: " & Math.Round(dblBruttoGes - dblNettoGes, 2) & " € | Gewicht: " & dblGewicht & " KG"
        lblArtikelanzahl.Text = "    Artikelmenge: " & iMenge & " x"
        Return True
    End Function
    Private Sub EinstellungenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinstellungenToolStripMenuItem1.Click
        Dim frmSetting As New frmEinstellungen
        frmSetting.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArtikel.CellContentClick

    End Sub

    Private Sub btnVorschau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestellungAnlegen.Click


        If lblKundenData.Text.ToString = "Kundenauswahl" Then

            If My.Settings.strKassenKundenID(My.Settings.mandant_position).ToString.Length = 0 Then
                If MessageBox.Show("Möchten Sie ohne selektierten Kunden fortfahren?", "Kunden auswählen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                    Dim frmKundenauswahl As New frmKundenauswahl
                    frmKundenauswahl.Show()
                    Exit Sub
                End If

            End If

        Else

        End If

            If dgvArtikel.Rows.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie mindestens einen Artikel aus, damit die Rechnung erstellt werden kann", "Artikel auswählen", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If My.Settings.absender_vorname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_nachname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_straße(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_plz(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_ort(My.Settings.mandant_position).ToString.Length = 0 Then
            Dim frmEinstellungenDialoag As New frmEinstellungen
            frmEinstellungenDialoag.ShowDialog()
        End If

        Dim frmRechnung As New frmRechnungsdruck
        frmRechnung.lvwKunden = lvwKunde
        frmRechnung.dgvArtikel = dgvArtikel
        frmRechnung.ShowDialog()
    End Sub

    Private Sub btnDrucken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestellungDrucken.Click
        Dim strMessage As String = ""

        If lblKundenData.Text.ToString = "Kundenauswahl" Then
            If My.Settings.strKassenKundenID(My.Settings.mandant_position).ToString.Length = 0 Then
                If MessageBox.Show("Möchten Sie ohne ausgewählten Kunden fortfahren?", "Kunden auswählen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                    Exit Sub
                End If
            End If


        End If

        If dgvArtikel.Rows.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie mindestens einen Artikel aus, damit die Rechnung erstellt werden kann", "Artikel auswählen", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If My.Settings.bestellung_opt_jtl_add.Item(My.Settings.mandant_position) = True Then
            strMessage = vbCrLf & "- Auftrag wird in JTL angelegt!"
        Else
            strMessage = vbCrLf & "- Auftrag wird NICHT in JTL angelegt!"
        End If

        If MessageBox.Show("Möchten Sie den Auftrag direkt drucken!" & strMessage, "Auftragsdruck JTL Bridge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If My.Settings.absender_vorname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_nachname(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_straße(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_plz(My.Settings.mandant_position).ToString.Length = 0 Or My.Settings.absender_ort(My.Settings.mandant_position).ToString.Length = 0 Then
            Dim frmEinstellungenDialoag As New frmEinstellungen
            frmEinstellungenDialoag.ShowDialog()
        End If

        Dim frmRechnung As New frmRechnungsdruck
        frmRechnung.lvwKunden = lvwKunde
        frmRechnung.dgvArtikel = dgvArtikel
        'frmRechnung.Visible = False
        'frmRechnung.ShowInTaskbar = False
        frmRechnung.bPrintSofort = True
        frmRechnung.ShowDialog()
    End Sub

    Private Sub btnCatSalonausstattung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub



    Private Sub lvwArtikel_kategorien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clsDB.getArtikel2Picture()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getTest()
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        Dim iRow As Integer = dgvArtikel.CurrentRow.Index
        If dgvArtikel.Rows(iRow).IsNewRow = False Then
            dgvArtikel.Rows.RemoveAt(iRow)
            Call getDGV_sum()
        End If

    End Sub

    Private Sub lvwArtikel_alle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSuchenArtikel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lvwArtikel_alle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call setDataToGrid(dgvArtikel, lvwArtikel_alle)
            Application.DoEvents()
            Call getDGV_sum()
        End If
    End Sub

    Private Sub btnLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLöschen.Click
        dgvArtikel.Rows.Clear()
        Call getDGV_sum()
    End Sub

    Public Function setNewKunde() As Boolean
        Dim frmNeuerKunde As New frmKunde_neu
        frmNeuerKunde.lvwKunden = lvwKunde
        frmNeuerKunde.ShowDialog()
        Return True
    End Function

    Public Function getRoutenPlaner(ByVal lvwRoutenplaner As ListView) As Boolean
        If lvwRoutenplaner.Items.Count > 0 Then

            Dim strStart As String = My.Settings.absender_straße.Item(My.Settings.mandant_position) & "," & My.Settings.absender_plz.Item(My.Settings.mandant_position) & " " & My.Settings.absender_ort.Item(My.Settings.mandant_position)
            Dim strEnde As String = lvwRoutenplaner.Items(0).SubItems(4).Text & "," & lvwRoutenplaner.Items(0).SubItems(5).Text & " " & lvwRoutenplaner.Items(0).SubItems(3).Text
            Dim url As String = "http://maps.google.de/maps?f=d&source=s_d&saddr=" & strStart.Replace(" ", "+") & "&daddr=" & strEnde.Replace(" ", "+") & "&oi=nojs"

            Dim frmBrowser As New frmMapsBrowser
            frmBrowser.strURL = url
            frmBrowser.Show()

            ' lblDistanz.Text = getDistanz(strStart, strEnde)
        End If
        Return True
    End Function
    Private Function getDistanz(ByVal strStart As String, ByVal strEnde As String) As String
        Try
            Dim strResult As String = ""
            Dim url As String = "http://maps.google.de/maps?f=d&source=s_d&saddr=" & strStart.Replace(" ", "+") & "&daddr=" & strEnde.Replace(" ", "+") & "&oi=nojs"
            Dim webClient As New Net.WebClient()
            Dim iLänge As Integer = 0
            webClient.Encoding = System.Text.Encoding.Default
            strResult = webClient.DownloadString(url)

            Return strResult
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Maps abrufen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return "-1"
        End Try
    End Function

    Private Sub MehrwertsteuerAnpassenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MehrwertsteuerAnpassenToolStripMenuItem.Click
        Call setMwst()
    End Sub
    Private Function setMwst() As Boolean
        Dim frmMwSt As New frmMehrwertSteuer
        frmMwSt.ShowDialog()

        If bSetMwst_rewrite = True Then
            Dim iCount As Integer = 0
            Dim iMenge As Integer = 0
            Dim dblNettoGes As Double = 0
            Dim dblBruttoGes As Double = 0
            Dim iRows As Integer

            If My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position) = True Then
                iRows = 2
            Else
                iRows = 1
            End If

            For iCount = 0 To dgvArtikel.Rows.Count - iRows
                dgvArtikel.Rows(iCount).Cells(10).Value = My.Settings.mwst_tmp.Item(My.Settings.mandant_position)
                '# Brutto Änderung
                Dim sum As Double = dgvArtikel.Rows(iCount).Cells(5).Value * ((dgvArtikel.Rows(iCount).Cells(10).Value / 100) + 1)
                sum = Math.Round(sum, 2)
                dgvArtikel.Rows(iCount).Cells(6).Value = sum.ToString("C").Replace("€", "")

                '# Netto Änderung 
                'Dim sum2 = CDbl(dgvArtikel.Rows(iCount).Cells(5).Value) / My.Settings.mwst
                'dgvArtikel.Rows(iCount).Cells(4).Value = Math.Round(sum2, 2)


                '# Daten übernehmen 
                iMenge = CInt(dgvArtikel.Rows(iCount).Cells(2).Value)
                dblNettoGes = iMenge * CDbl(dgvArtikel.Rows(iCount).Cells(5).Value)
                dblBruttoGes = iMenge * CDbl(dgvArtikel.Rows(iCount).Cells(6).Value)
                dgvArtikel.Rows(iCount).Cells(7).Value = dblNettoGes.ToString("C").Replace("€", "")
                dgvArtikel.Rows(iCount).Cells(8).Value = dblBruttoGes.ToString("C").Replace("€", "")
            Next

        End If

        bSetMwst_rewrite = False
        Return True
    End Function


    Private Sub RoutenplanerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoutenplanerToolStripMenuItem.Click
        Call getRoutenPlaner(lvwKunde)
    End Sub

    Private Sub MengeVerändernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MengeVerändernToolStripMenuItem.Click
        Call setRabatt()
    End Sub

    Private Function setRabatt() As Boolean
        Dim frmRatbatt As New frmRabatt
        frmRatbatt.dgv = dgvArtikel
        frmRatbatt.ShowDialog()

        If dblRabatt_newPrice > 0 Then
            dgvArtikel.CurrentRow.Cells("colBestellNetto").Value = dblRabatt_newPrice.ToString("C").Replace("€", "")

            Dim sum As Double = dgvArtikel.CurrentRow.Cells(5).Value * ((dgvArtikel.CurrentRow.Cells(10).Value / 100) + 1)
            sum = Math.Round(sum, 2)
            dgvArtikel.CurrentRow.Cells(6).Value = sum.ToString("C").Replace("€", "")

            Dim iMenge As Integer = 0
            Dim dblNettoGes As Double = 0
            Dim dblBruttoGes As Double = 0
            'Dim sum As Double = CDbl(dgvArtikel.CurrentRow.Cells(5).Value) / My.Settings.mwst
            '    sum = Math.Round(sum, 2)
            'dgvArtikel.CurrentRow.Cells(4).Value = sum.ToString("C").Replace("€", "")

            '# Daten übernehmen 
            iMenge = CInt(dgvArtikel.CurrentRow.Cells(2).Value)
            dblNettoGes = iMenge * CDbl(dgvArtikel.CurrentRow.Cells(5).Value)
            dblBruttoGes = iMenge * CDbl(dgvArtikel.CurrentRow.Cells(6).Value)
            dgvArtikel.CurrentRow.Cells(8).Value = dblNettoGes.ToString("C").Replace("€", "")
            dgvArtikel.CurrentRow.Cells(9).Value = dblBruttoGes.ToString("C").Replace("€", "")
        End If

        Return True
    End Function

    Private Sub StartnummernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartnummernToolStripMenuItem.Click
        Dim frmStartnummern As New frmStartnummern
        frmStartnummern.ShowDialog()
    End Sub

    Private Sub DeutschToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeutschToolStripMenuItem.Click
        My.Settings.app_language.Item(My.Settings.mandant_position) = "DE-de"
        My.Settings.Save()
        EnglischToolStripMenuItem.Checked = False
        DeutschToolStripMenuItem.Checked = True
        VietnamesischToolStripMenuItem.Checked = False
        System.Windows.Forms.Application.Restart()
    End Sub

    Private Sub EnglischToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglischToolStripMenuItem.Click
        My.Settings.app_language.Item(My.Settings.mandant_position) = "en"
        My.Settings.Save()
        EnglischToolStripMenuItem.Checked = True
        DeutschToolStripMenuItem.Checked = False
        VietnamesischToolStripMenuItem.Checked = False
        System.Windows.Forms.Application.Restart()
    End Sub

    Private Sub VietnamesischToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VietnamesischToolStripMenuItem.Click
        My.Settings.app_language.Item(My.Settings.mandant_position) = "vi"
        My.Settings.Save()
        EnglischToolStripMenuItem.Checked = False
        DeutschToolStripMenuItem.Checked = False
        VietnamesischToolStripMenuItem.Checked = True
        System.Windows.Forms.Application.Restart()
    End Sub

    Private Sub RechnungenAuflistenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechnungenAuflistenToolStripMenuItem.Click
        Dim frmRechnungArchiv As New frmRechnungsArchiv
        frmRechnungArchiv.ShowDialog()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LagerbestandÄndernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagerbestandÄndernToolStripMenuItem.Click

        If lvwArtikel_alle.SelectedItems.Count > 0 Then
            Dim frmLager As New frmLagerverwaltung
            frmLager.lblTitel.Text = lvwArtikel_alle.SelectedItems(0).SubItems(2).Text
            frmLager.lblArtikelnummer.Text = lvwArtikel_alle.SelectedItems(0).SubItems(1).Text
            frmLager.lblPreis.Text = lvwArtikel_alle.SelectedItems(0).SubItems(4).Text & " EUR"
            frmLager.txtLagerbestand_alt.Text = lvwArtikel_alle.SelectedItems(0).SubItems(5).Text
            frmLager.ShowDialog()
        End If

    End Sub

    Private Sub btnLagerverwaltung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    '##################################################################################
    '# >> geteazybusinessSettings()
    '# Findet die Position an der Sich die Hauptdatenbank befindet 
    '##################################################################################
    Public Function getMySettingsPositionByDatabase(ByVal strDatabaseName As String) As Integer
        Try
            Dim i As Byte
            Dim iGefunden As Integer = -1
            Dim bGefunden As Boolean = False

            '# Keine Einstellung gefunden 
            If My.Settings.db_datenbankname.Count = 0 Then
                Return -1
                Exit Function
            End If

            For i = 0 To My.Settings.db_datenbankname.Count - 1
                If My.Settings.db_datenbankname(i) = strDatabaseName Then
                    bGefunden = True
                    iGefunden = i
                    Exit For
                End If
            Next
            '# Nicht gefunden Position 0 
            If bGefunden = False Then
                iGefunden = -1
            End If

            My.Settings.Save()
            Return iGefunden
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "geteMySettingsbyDatabase()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    '#################################################
    '# >> setSettingsInit
    '# My.Settings.xxx String Collection initalisieren
    '#################################################
    Public Function setSettingsInit(ByVal iSize As Integer) As Integer
        Try
            Dim txtShopURL_test As String = ""
            Dim iCount_insert As Integer = 0

            If My.Settings.db_server.Count - 1 < iSize Then
                For iCount As Integer = My.Settings.db_server.Count To iSize
                    Try
                        txtShopURL_test = My.Settings.db_server(iCount).ToString
                    Catch ex As Exception
                        My.Settings.db_server.Insert(iCount, "")
                        My.Settings.db_datenbankname.Insert(iCount, "")
                        My.Settings.db_username.Insert(iCount, "")
                        My.Settings.db_passwort.Insert(iCount, "")
                        My.Settings.absender_vorname.Insert(iCount, "")
                        My.Settings.absender_firma.Insert(iCount, "")
                        My.Settings.absender_nachname.Insert(iCount, "")
                        My.Settings.absender_straße.Insert(iCount, "")
                        My.Settings.absender_plz.Insert(iCount, "")
                        My.Settings.absender_ort.Insert(iCount, "")
                        My.Settings.absender_land.Insert(iCount, "")
                        My.Settings.export_pfad.Insert(iCount, "")
                        My.Settings.mwst_tmp.Insert(iCount, "")
                        My.Settings.nr_kunden_prefix.Insert(iCount, "")
                        My.Settings.nr_kunden_suffix.Insert(iCount, "")
                        My.Settings.nr_auftrag_prefix.Insert(iCount, "")
                        My.Settings.nr_auftrag_suffix.Insert(iCount, "")
                        My.Settings.app_language.Insert(iCount, "DE-de")
                        My.Settings.kunde_opt_jtl_add.Insert(iCount, "false") 'init wert false 
                        My.Settings.bestellung_opt_jtl_add.Insert(iCount, "false") ' init wert false 
                        My.Settings.login_username.Insert(iCount, "")
                        My.Settings.login_userid.Insert(iCount, "")
                        My.Settings.login_automodus.Insert(iCount, "false")
                        My.Settings.login_passwort.Insert(iCount, "")
                        My.Settings.lvw_colum_save.Insert(iCount, "true")
                        My.Settings.bLagerverwaltung.Insert(iCount, "false")
                        My.Settings.dvgArtikel_allowAddRow.Insert(iCount, "false")
                        My.Settings.chkWarehouseAddDelTotal.Insert(iCount, "true")
                        My.Settings.chkRechnungsdetailVerkäuferAnzeigen.Insert(iCount, "true")
                        My.Settings.txtBenzinpreis.Insert(iCount, "1,39")
                        My.Settings.bGoogleBenzinpreis.Insert(iCount, "true")
                        My.Settings.chkLagerwarnmeldung.Insert(iCount, "true")
                        My.Settings.strKassenKundenID.Insert(iCount, "")

                        iCount_insert += 1
                    End Try
                Next

            End If
            Return iCount_insert
        Catch ex As Exception
            MessageBox.Show("Fehler bei setInitSettings: " & ex.Message, "setInitSettings()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    '#################################################
    '# >> setSettingsDelete
    '# My.Settings.xxx String Collection alle löschen
    '#################################################
    Public Function setSettingsDelete() As Boolean
        Dim i As Integer
        For i = 0 To My.Settings.db_server.Count - 1
            Try
                My.Settings.db_server.RemoveAt(0)
            Catch ex As Exception

            End Try
            Try
                My.Settings.db_datenbankname.RemoveAt(0)
            Catch ex As Exception

            End Try
            Try
                My.Settings.db_username.RemoveAt(0)
            Catch ex As Exception

            End Try
            Try
                My.Settings.db_passwort.RemoveAt(0)
            Catch ex As Exception

            End Try
            'msgMaster.Text = "Es existieren noch " & My.Settings.db_server.Count & " Einstellungen"
        Next
        Return True
    End Function

    Private Sub MandantenwechselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MandantenwechselToolStripMenuItem.Click
        Dim frmBenutzerLogin As New frmLogin
        frmBenutzerLogin.ShowDialog()
    End Sub

    Private Sub btnCatAlle_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.SelectedIndex = 1
        lvwArtikel_kategorien.Items.Clear()

        '# Alle Kategorien + Unterkategorien anzeigen 
        Call clsDB.getKategorie(0, lvwArtikel_kategorien, 0)
        lblÜberschrift.Text = "Alle Hauptkategorien"
        msgMaster.Text = "| Kategorien: " & lvwArtikel_kategorien.Items.Count

        'TabControl1.SelectedIndex = 1
        'btnCatSalonausstattung.Enabled = False
        'Call clsDB.getKategorie(13, lvwArtikel_kategorien)
        'btnCatSalonausstattung.Enabled = True
        'lblÜberschrift.Text = "Salonausstattung"
        'lblStatus.Text = "Kategorien: " & lvwArtikel_kategorien.Items.Count
    End Sub

    Private Sub LagerverwaltungAktivierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagerverwaltungAktivierenToolStripMenuItem.Click
        If LagerverwaltungAktivierenToolStripMenuItem.Text = "Lagerverwaltung aktivieren" Then
            LagerverwaltungAktivierenToolStripMenuItem.Text = "Lagerverwaltung deaktivieren"
            lblGesammtsumme.Text = "Lagerverwaltung ist jetzt aktiv"
            SplitContainer1.Panel1Collapsed = True
            lblKundenData.Visible = False
            My.Settings.bLagerverwaltung.Item(My.Settings.mandant_position) = True
            My.Settings.Save()
        Else
            LagerverwaltungAktivierenToolStripMenuItem.Text = "Lagerverwaltung aktivieren"
            lblGesammtsumme.Text = "Lagerverwaltung ist jetzt wieder inaktiv"
            SplitContainer1.Panel1Collapsed = False
            lblKundenData.Visible = True
            My.Settings.bLagerverwaltung.Item(My.Settings.mandant_position) = False
            My.Settings.Save()
        End If
    End Sub
 
    '#############################################################
    '# >> setComboFrmMainMandantWechsel
    '# Combobox Wechsel laden 
    '#############################################################
    Public Function setComboFrmMainMandantWechsel() As Boolean
        Try
            'If bIsLoading = False Then
            My.Settings.mandant_letzter_name = cmbMandantenauswahl.Text
            My.Settings.mandant_position = clsDB.chkMandantPosition(clsDB.getMandantDatabaseByMandantName(My.Settings.mandant_letzter_name))

            '# Settings initalisieren 
            Call setSettingsInit(My.Settings.mandant_position)

            '# Fehlerfall Profil wird angezeigt, es wurden aber keine Benutzerdaten hinterlegt 
            If My.Settings.db_username(My.Settings.mandant_position) = "" And Not My.Settings.db_datenbankname(My.Settings.mandant_position) = "" Then
                msgMaster.Text = "| Es muss das Datenbankprofil für ' " & My.Settings.mandant_letzter_name & "' vervollständigt werden!"
                Dim frmDatenbankEinstellungen As New frmDatenbankEinstellungen
                frmDatenbankEinstellungen.Show()
            End If

            '#####################################################################
            '# Kategorie Knöpfe löschen
            '#####################################################################
            If bIsLoading = False Then
                Call setCategoryDeleteButtons()


                '###################################################################
                '# >> Datenbank wechseln
                '###################################################################
                My.Settings.mandant_position = clsDB.chkMandantPosition(clsDB.getMandantDatabaseByMandantName(cmbMandantenauswahl.Text))
                My.Settings.mandant_letzter_name = cmbMandantenauswahl.Text
                msgMaster.Text = "| Es wurde das Datenbankprofil ' " & My.Settings.mandant_letzter_name & "' geladen!"
                Dim strCon2 As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
                If clsDB.getDBConnect(strCon2, False) = False Then
                    Dim frmDBSetting As New frmDatenbankEinstellungen
                    frmDBSetting.ShowDialog()
                End If

                '#####################################################################
                '# Kategorie Knöpfe erzeugen
                '#####################################################################
                Call setCategoryAddButtons()
            End If
            My.Settings.Save()

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei setComboFrmMainMandantWechsel: " & ex.Message, "setComboFrmMainMandantWechsel()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function
 
    Private Sub lblKundenData_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Static bCollapsed As Boolean = True

        If bCollapsed = True Then
            SplitContainer2.Panel1Collapsed = True
            bCollapsed = False
        Else
            SplitContainer2.Panel1Collapsed = False
            bCollapsed = True
        End If

    End Sub

    Private Sub cmbMandantenauswahl_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call setComboFrmMainMandantWechsel()
        msgMaster.Text = "| Neuer Mandant ausgewählt " & cmbMandantenauswahl.Text & " bei Einstellungsposition " & My.Settings.mandant_position
        Call setMainWindowTitle("", Me)
        'bIsLoading = False ' fehler bei setComboFrmMainMandantWechsel möglich bei true
    End Sub

    Private Sub txtSuchenKunde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtSuchenKunde.Enabled = False
            lvwKunde.Enabled = False
            lvwKunde.Items.Clear()
            clsDB.getKundenListe_suchen(txtSuchenKunde.Text, lvwKunde)
            txtSuchenKunde.Enabled = True
            lvwKunde.Enabled = True
        End If
    End Sub

    Private Sub txtSuchenKunde_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnViewSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSelector.Click
        Static iViewModus As Integer = 0
        If iViewModus = 0 Then
            SplitContainer1.Panel1Collapsed = True
            lblKundenData.Visible = False
            btnViewSelector.Text = "&Bestellansicht"
            iViewModus = 1
        ElseIf iViewModus = 1 Then
            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = True
            lblKundenData.Visible = True
            btnViewSelector.Text = "&Beide Ansichten"
            iViewModus = 2
        ElseIf iViewModus = 2 Then
            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = False
            lblKundenData.Visible = True
            btnViewSelector.Text = "&Artikelansicht"
            iViewModus = 0
        End If
    End Sub

    Private Sub frmJTLRechnung_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        'SplitContainer4.Panel1.PreferredSize.Height = FlowLayoutPanel1.Size.Height
        SplitContainer4.SplitterDistance = FlowLayoutPanel1.VerticalScroll.Maximum + 2
    End Sub

    Private Sub frmJTLRechnung_ResizeEnd(sender As System.Object, e As System.EventArgs) Handles MyBase.ResizeEnd

    End Sub

    Private Sub SplitContainer4_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitContainer4.Resize

        If FlowLayoutPanel1.VerticalScroll.Visible = True Then
            SplitContainer4.SplitterDistance = FlowLayoutPanel1.VerticalScroll.Maximum + 3
        Else
            SplitContainer4.SplitterDistance = FlowLayoutPanel1.VerticalScroll.Maximum / 2
        End If

        'SplitContainer4.Panel1.Height = Me.Size.Height - SplitContainer4.Panel2.Height
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblGoogleMaps.LinkClicked
        Call getGoogleMapsDistanz()
        Call getRoutenPlaner(lvwKunde)
    End Sub

    Private Sub btnCatAlle_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSuchenKunde_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSuchenKunde.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtSuchenKunde.Enabled = False
            lvwKunde.Enabled = False
            lvwKunde.Items.Clear()
            clsDB.getKundenListe_suchen(txtSuchenKunde.Text, lvwKunde)
            txtSuchenKunde.Enabled = True
            lvwKunde.Enabled = True
            lblGoogleMaps.Visible = True
        End If
    End Sub

    Private Sub txtSuchenKunde_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuchenKunde.TextChanged

    End Sub

    Private Sub cmbMandantenauswahl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMandantenauswahl.SelectedIndexChanged
        If bIsLoading = False Then

            Call setComboFrmMainMandantWechsel()
            msgMaster.Text = "| Neuer Mandant ausgewählt " & cmbMandantenauswahl.Text & " bei Einstellungsposition " & My.Settings.mandant_position
            Call setMainWindowTitle("", Me)

            '# Alle Kategorien anzeigen
            btnAlleKategorien.PerformClick()

            '# Rechnungsdetail löschen
            dgvArtikel.Rows.Clear()

        End If
        'bIsLoading = False ' fehler bei setComboFrmMainMandantWechsel möglich bei true
    End Sub

    Private Sub lvwArtikel_kategorien_Click(sender As Object, e As System.EventArgs) Handles lvwArtikel_kategorien.Click
        If lvwArtikel_kategorien.SelectedItems.Count > 0 Then

            '# Weitere Spalte anzeigen 
            If My.Settings.chkEinkaufsspalte = True Then
                lvwArtikel_alle.Columns(6).Width = 0
                lvwArtikel_alle.Columns(7).Width = 0
            Else
                lvwArtikel_alle.Columns(6).Width = 60
                lvwArtikel_alle.Columns(7).Width = 60
            End If

            TabControl1.SelectedIndex = 0
            lvwArtikel_kategorien.Enabled = False
            Call clsDB.getKategorie2Artikel(lvwArtikel_kategorien.SelectedItems(0).Text, lvwArtikel_alle, ImageList1)
            lvwArtikel_kategorien.Enabled = True


            '# Überschrift ausgeben
            Dim str() As String = lblÜberschrift.Text.Split("->")
            If str.Length > 0 Then
                lblÜberschrift.Text = str(0).Trim & " -> " & lvwArtikel_kategorien.SelectedItems(0).SubItems(1).Text.Trim
            Else
                lblÜberschrift.Text &= " -> " & lvwArtikel_kategorien.SelectedItems(0).SubItems(1).Text.Trim
            End If

            msgMaster.Text = "| Artikel in der Kategorie: " & lvwArtikel_alle.Items.Count
        End If
    End Sub

    Private Sub lvwArtikel_kategorien_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwArtikel_kategorien.ColumnClick

        lvwArtikel_alle.BeginUpdate()
 
        Call setSort(lvwArtikel_kategorien, e)

        lvwArtikel_alle.EndUpdate()
    End Sub

    Private Sub lvwArtikel_kategorien_MouseLeave(sender As Object, e As System.EventArgs) Handles lvwArtikel_kategorien.MouseLeave

    End Sub

    Private Sub lvwArtikel_kategorien_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwArtikel_kategorien.SelectedIndexChanged

    End Sub

    Private Sub lvwArtikel_alle_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwArtikel_alle.ColumnClick
        lvwArtikel_alle.BeginUpdate()
        Call setSort(lvwArtikel_alle, e)
        lvwArtikel_alle.EndUpdate()
    End Sub

    Private Sub lvwArtikel_alle_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwArtikel_alle.DoubleClick
        If Convert.ToBoolean(My.Settings.bLagerverwaltung.Item(My.Settings.mandant_position)) = False Then

            If Convert.ToInt16(lvwArtikel_alle.SelectedItems(0).SubItems(5).Text) <= 0 And My.Settings.chkLagerwarnmeldung(My.Settings.mandant_position).ToString = "True" Then
                If MessageBox.Show("Es befinden sich '" & lvwArtikel_alle.SelectedItems(0).SubItems(5).Text & "' Artikel im Lager, es sind weniger oder Null Artikel im Lager" & vbCrLf & "Möchten Sie fortfahren?", "Lagerbestand nicht in Ordnung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Call setDataToGrid(dgvArtikel, lvwArtikel_alle)
                    Application.DoEvents()
                    Call getDGV_sum()
                End If
            Else
                Call setDataToGrid(dgvArtikel, lvwArtikel_alle)
                Application.DoEvents()
                Call getDGV_sum()
            End If
        Else
            Dim frmLager As New frmLagerverwaltung
            frmLager.lblTitel.Text = lvwArtikel_alle.SelectedItems(0).SubItems(2).Text
            frmLager.lblArtikelnummer.Text = lvwArtikel_alle.SelectedItems(0).SubItems(1).Text
            frmLager.lblPreis.Text = lvwArtikel_alle.SelectedItems(0).SubItems(4).Text
            frmLager.txtLagerbestand_alt.Text = lvwArtikel_alle.SelectedItems(0).SubItems(5).Text
            frmLager.ShowDialog()
        End If
    End Sub

    Private Sub lvwArtikel_alle_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwArtikel_alle.MouseWheel

    End Sub

    Private Sub lvwArtikel_alle_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwArtikel_alle.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(FlowLayoutPanel1.VerticalScroll.Maximum & " " & SplitContainer4.Panel1.Height)
    End Sub

    Private Sub txtSuchenKunde_Click(sender As Object, e As EventArgs) Handles txtSuchenKunde.Click
        Dim frmKunden As New frmKundenauswahl
        frmKunden.ShowDialog()
        Call getGoogleMapsDistanz()
        lblGoogleMaps.Visible = True
    End Sub

    Private Sub txtSuchenArtikel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSuchenArtikel.KeyUp
        If e.KeyCode = Keys.Enter Then
            lvwArtikel_alle.Items.Clear()
            txtSuchenArtikel.Enabled = False
            lvwArtikel_alle.Enabled = False
            lblÜberschrift.Text = txtSuchenArtikel.Text
            clsDB.getArtikelListe_suchen(txtSuchenArtikel.Text, lvwArtikel_alle, ImageList1)

            '# Auto hinzufügen
            If lvwArtikel_alle.Items.Count = 1 Then
                lvwArtikel_alle.Items(0).Selected = True
                Call setDataToGrid(dgvArtikel, lvwArtikel_alle)
                Application.DoEvents()
                Call getDGV_sum()
            End If

            lvwArtikel_alle.Enabled = True
            txtSuchenArtikel.Enabled = True
            msgMaster.Text = "| Artikel in der Kategorie: " & lvwArtikel_alle.Items.Count - 1
            txtSuchenArtikel.Text = ""
            txtSuchenArtikel.Focus()
        End If
    End Sub

    Private Sub txtSuchenArtikel_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuchenArtikel.TextChanged

    End Sub

    Private Sub dgvArtikel_Click(sender As System.Object, e As System.EventArgs) Handles dgvArtikel.Click
        If dgvArtikel.Rows.Count > 0 Then

            If dgvArtikel.CurrentCell.ColumnIndex = 0 Then
                If MessageBox.Show("Möchten Sie die aktuelle Bestellposition löschen?", "Bestellposition löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim iRow As Integer = dgvArtikel.CurrentRow.Index

                    Try
                        dgvArtikel.Rows.RemoveAt(iRow)
                    Catch ex As Exception
                        MessageBox.Show("Kann nicht gelöscht werden, weil erste Zeile erforderlich ist! Kann in den Programmeinstellungen verändert werden", "Fehler beim Löschen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub lvwKunde_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwKunde.SelectedIndexChanged

    End Sub


    Private Sub FreipositionHinzufügenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FreipositionHinzufügenToolStripMenuItem.Click
        dgvArtikel.Rows.Add()
    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frmVersandkostenAnzeigen As New frmVersandkosten
        frmVersandkostenAnzeigen.Show()
    End Sub

    Private Sub btnBestellliste_Click(sender As System.Object, e As System.EventArgs) Handles btnBestellliste.Click
        Dim frmRechnungsArchiv As New frmRechnungsArchiv
        frmRechnungsArchiv.Show()
    End Sub

    Private Sub UpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpdatesToolStripMenuItem.Click
        Dim frmUpdates As New frmUpdater
        frmUpdates.Show()
    End Sub

    Private Sub WebseiteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebseiteToolStripMenuItem.Click
        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = "https://bludau-media.de"
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()
    End Sub

    Private Sub KontaktierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KontaktierenToolStripMenuItem.Click
        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = "https://bludau-media.de"
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()
    End Sub

    Private Sub lblBarkunde_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblBarkunde.LinkClicked
        If My.Settings.strKassenKundenID(My.Settings.mandant_position).Length = 0 Then
            Me.Text &= " - Kein Kassenkunde ausgewählt!"
        Else
            Me.clsDB.getKundenListe_suchen(My.Settings.strKassenKundenID(My.Settings.mandant_position), lvwKunde)
            If lvwKunde.Items.Count > 0 Then
                Me.lblKundenData.Text = "Kunde: " & lvwKunde.Items(0).SubItems(7).Text & " >> " & lvwKunde.Items(0).SubItems(1).Text & " " & lvwKunde.Items(0).SubItems(2).Text & " | " & lvwKunde.Items(0).SubItems(3).Text & " | " & lvwKunde.Items(0).SubItems(5).Text & " " & lvwKunde.Items(0).SubItems(4).Text & " | " & lvwKunde.Items(0).SubItems(8).Text
                Me.lblKundennummer.Text = lvwKunde.Items(0).SubItems(0).Text

            End If
        End If
    End Sub
End Class
