<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRechnungsArchiv
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRechnungsArchiv))
        Me.lvwRechnungen = New System.Windows.Forms.ListView()
        Me.colArchivArtikelName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivPreis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivKundeName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivBestellID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivStadt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivAnzahl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivErstellt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivKNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivPLZ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivStrasse = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivVorname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivEmail = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivTelefon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivLand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivFirma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivImported = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivBenutzer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArchivcArtNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colVerkaufsPreisNetto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMwSt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BestellungAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnJTLImport = New System.Windows.Forms.Button()
        Me.lblMasterHeader = New System.Windows.Forms.Label()
        Me.txtSuchenKunde = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBestellungOpen = New System.Windows.Forms.Button()
        Me.chkImported = New System.Windows.Forms.CheckBox()
        Me.lblSumme = New System.Windows.Forms.Label()
        Me.btnBestellungAdd = New System.Windows.Forms.Button()
        Me.lvwKunde = New System.Windows.Forms.ListView()
        Me.colKundenNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenVorname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenNachname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenStadt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenStrasse = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenPLZ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenLand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenFirma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenTel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenEmail = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenExists = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colKundenID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgvArtikel = New System.Windows.Forms.DataGridView()
        Me.colLöschen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellBild = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellMenge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArtNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellNetto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellBrutto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellNettoGes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBestellBruttoGes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lagerbestand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MwSt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gewicht = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBestellungEditieren = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnVor = New System.Windows.Forms.Button()
        Me.BestellungLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwRechnungen
        '
        Me.lvwRechnungen.AllowColumnReorder = True
        Me.lvwRechnungen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwRechnungen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwRechnungen.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colArchivArtikelName, Me.colArchivPreis, Me.colArchivKundeName, Me.colArchivBestellID, Me.colArchivStadt, Me.colArchivAnzahl, Me.colArchivErstellt, Me.colArchivKNr, Me.colArchivPLZ, Me.colArchivStrasse, Me.colArchivVorname, Me.colArchivEmail, Me.colArchivTelefon, Me.colArchivLand, Me.colArchivFirma, Me.colArchivImported, Me.colArchivBenutzer, Me.colArchivcArtNr, Me.colVerkaufsPreisNetto, Me.colMwSt})
        Me.lvwRechnungen.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvwRechnungen.FullRowSelect = True
        Me.lvwRechnungen.GridLines = True
        Me.lvwRechnungen.HideSelection = False
        Me.lvwRechnungen.Location = New System.Drawing.Point(16, 73)
        Me.lvwRechnungen.MultiSelect = False
        Me.lvwRechnungen.Name = "lvwRechnungen"
        Me.lvwRechnungen.Size = New System.Drawing.Size(985, 473)
        Me.lvwRechnungen.TabIndex = 0
        Me.lvwRechnungen.UseCompatibleStateImageBehavior = False
        Me.lvwRechnungen.View = System.Windows.Forms.View.Details
        '
        'colArchivArtikelName
        '
        Me.colArchivArtikelName.DisplayIndex = 6
        Me.colArchivArtikelName.Text = "Produktbezeichnung"
        Me.colArchivArtikelName.Width = 250
        '
        'colArchivPreis
        '
        Me.colArchivPreis.DisplayIndex = 8
        Me.colArchivPreis.Text = "Preis"
        Me.colArchivPreis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colArchivPreis.Width = 80
        '
        'colArchivKundeName
        '
        Me.colArchivKundeName.DisplayIndex = 5
        Me.colArchivKundeName.Text = "Nachname"
        Me.colArchivKundeName.Width = 150
        '
        'colArchivBestellID
        '
        Me.colArchivBestellID.DisplayIndex = 0
        Me.colArchivBestellID.Text = "JB.Nr."
        Me.colArchivBestellID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colArchivBestellID.Width = 43
        '
        'colArchivStadt
        '
        Me.colArchivStadt.DisplayIndex = 9
        Me.colArchivStadt.Text = "Stadt"
        Me.colArchivStadt.Width = 100
        '
        'colArchivAnzahl
        '
        Me.colArchivAnzahl.DisplayIndex = 7
        Me.colArchivAnzahl.Text = "Menge"
        Me.colArchivAnzahl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colArchivErstellt
        '
        Me.colArchivErstellt.DisplayIndex = 1
        Me.colArchivErstellt.Text = "Erstellt"
        Me.colArchivErstellt.Width = 120
        '
        'colArchivKNr
        '
        Me.colArchivKNr.DisplayIndex = 2
        Me.colArchivKNr.Text = "KNr."
        Me.colArchivKNr.Width = 80
        '
        'colArchivPLZ
        '
        Me.colArchivPLZ.DisplayIndex = 10
        Me.colArchivPLZ.Text = "PLZ"
        '
        'colArchivStrasse
        '
        Me.colArchivStrasse.DisplayIndex = 11
        Me.colArchivStrasse.Text = "Straße"
        Me.colArchivStrasse.Width = 200
        '
        'colArchivVorname
        '
        Me.colArchivVorname.DisplayIndex = 4
        Me.colArchivVorname.Text = "Vorname"
        Me.colArchivVorname.Width = 80
        '
        'colArchivEmail
        '
        Me.colArchivEmail.DisplayIndex = 12
        Me.colArchivEmail.Text = "Email"
        Me.colArchivEmail.Width = 120
        '
        'colArchivTelefon
        '
        Me.colArchivTelefon.DisplayIndex = 13
        Me.colArchivTelefon.Text = "Telefon"
        Me.colArchivTelefon.Width = 100
        '
        'colArchivLand
        '
        Me.colArchivLand.DisplayIndex = 14
        Me.colArchivLand.Text = "Land "
        Me.colArchivLand.Width = 120
        '
        'colArchivFirma
        '
        Me.colArchivFirma.DisplayIndex = 3
        Me.colArchivFirma.Text = "Firma"
        Me.colArchivFirma.Width = 150
        '
        'colArchivImported
        '
        Me.colArchivImported.Text = "Importiert"
        Me.colArchivImported.Width = 0
        '
        'colArchivBenutzer
        '
        Me.colArchivBenutzer.Text = "Ersteller"
        Me.colArchivBenutzer.Width = 70
        '
        'colArchivcArtNr
        '
        Me.colArchivcArtNr.Text = "A.Nr."
        '
        'colVerkaufsPreisNetto
        '
        Me.colVerkaufsPreisNetto.Text = "NettoPreis"
        '
        'colMwSt
        '
        Me.colMwSt.Text = "MwSt"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BestellungAnzeigenToolStripMenuItem, Me.ToolStripSeparator1, Me.BestellungLöschenToolStripMenuItem, Me.ToolStripSeparator2, Me.AlleAnzeigenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(254, 104)
        '
        'AlleAnzeigenToolStripMenuItem
        '
        Me.AlleAnzeigenToolStripMenuItem.Name = "AlleAnzeigenToolStripMenuItem"
        Me.AlleAnzeigenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AlleAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.AlleAnzeigenToolStripMenuItem.Text = "&Alle Bestellungen anzeigen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(250, 6)
        '
        'BestellungAnzeigenToolStripMenuItem
        '
        Me.BestellungAnzeigenToolStripMenuItem.Name = "BestellungAnzeigenToolStripMenuItem"
        Me.BestellungAnzeigenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BestellungAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.BestellungAnzeigenToolStripMenuItem.Text = "Bestellung anzeigen"
        '
        'btnJTLImport
        '
        Me.btnJTLImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnJTLImport.BackColor = System.Drawing.Color.Bisque
        Me.btnJTLImport.Enabled = False
        Me.btnJTLImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJTLImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnJTLImport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnJTLImport.Location = New System.Drawing.Point(560, 552)
        Me.btnJTLImport.Name = "btnJTLImport"
        Me.btnJTLImport.Size = New System.Drawing.Size(173, 36)
        Me.btnJTLImport.TabIndex = 3
        Me.btnJTLImport.Text = "&Export nach JTL WaWi"
        Me.btnJTLImport.UseVisualStyleBackColor = False
        '
        'lblMasterHeader
        '
        Me.lblMasterHeader.AutoSize = True
        Me.lblMasterHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMasterHeader.Location = New System.Drawing.Point(12, 9)
        Me.lblMasterHeader.Name = "lblMasterHeader"
        Me.lblMasterHeader.Size = New System.Drawing.Size(128, 24)
        Me.lblMasterHeader.TabIndex = 4
        Me.lblMasterHeader.Text = "Bestellarchiv"
        '
        'txtSuchenKunde
        '
        Me.txtSuchenKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuchenKunde.Location = New System.Drawing.Point(65, 47)
        Me.txtSuchenKunde.Name = "txtSuchenKunde"
        Me.txtSuchenKunde.Size = New System.Drawing.Size(208, 20)
        Me.txtSuchenKunde.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(16, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Suche"
        '
        'btnBestellungOpen
        '
        Me.btnBestellungOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBestellungOpen.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellungOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBestellungOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBestellungOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBestellungOpen.Location = New System.Drawing.Point(16, 552)
        Me.btnBestellungOpen.Name = "btnBestellungOpen"
        Me.btnBestellungOpen.Size = New System.Drawing.Size(173, 36)
        Me.btnBestellungOpen.TabIndex = 72
        Me.btnBestellungOpen.Text = "Bestellung öffnen"
        Me.btnBestellungOpen.UseVisualStyleBackColor = False
        '
        'chkImported
        '
        Me.chkImported.AutoSize = True
        Me.chkImported.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkImported.Location = New System.Drawing.Point(305, 48)
        Me.chkImported.Name = "chkImported"
        Me.chkImported.Size = New System.Drawing.Size(66, 17)
        Me.chkImported.TabIndex = 73
        Me.chkImported.Text = "&Importiert"
        Me.chkImported.UseVisualStyleBackColor = True
        '
        'lblSumme
        '
        Me.lblSumme.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSumme.AutoSize = True
        Me.lblSumme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumme.Location = New System.Drawing.Point(746, 561)
        Me.lblSumme.Name = "lblSumme"
        Me.lblSumme.Size = New System.Drawing.Size(0, 20)
        Me.lblSumme.TabIndex = 74
        '
        'btnBestellungAdd
        '
        Me.btnBestellungAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBestellungAdd.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellungAdd.Enabled = False
        Me.btnBestellungAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBestellungAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBestellungAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBestellungAdd.Location = New System.Drawing.Point(381, 552)
        Me.btnBestellungAdd.Name = "btnBestellungAdd"
        Me.btnBestellungAdd.Size = New System.Drawing.Size(173, 36)
        Me.btnBestellungAdd.TabIndex = 75
        Me.btnBestellungAdd.Text = "&Bestellung anlegen..."
        Me.btnBestellungAdd.UseVisualStyleBackColor = False
        '
        'lvwKunde
        '
        Me.lvwKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwKunde.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colKundenNr, Me.colKundenVorname, Me.colKundenNachname, Me.colKundenStadt, Me.colKundenStrasse, Me.colKundenPLZ, Me.colKundenLand, Me.colKundenFirma, Me.colKundenTel, Me.colKundenEmail, Me.colKundenExists, Me.colKundenID})
        Me.lvwKunde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lvwKunde.FullRowSelect = True
        Me.lvwKunde.GridLines = True
        Me.lvwKunde.HideSelection = False
        Me.lvwKunde.Location = New System.Drawing.Point(898, 534)
        Me.lvwKunde.MultiSelect = False
        Me.lvwKunde.Name = "lvwKunde"
        Me.lvwKunde.Size = New System.Drawing.Size(53, 66)
        Me.lvwKunde.TabIndex = 94
        Me.lvwKunde.UseCompatibleStateImageBehavior = False
        Me.lvwKunde.View = System.Windows.Forms.View.Details
        Me.lvwKunde.Visible = False
        '
        'colKundenNr
        '
        Me.colKundenNr.Text = "Nr."
        Me.colKundenNr.Width = 61
        '
        'colKundenVorname
        '
        Me.colKundenVorname.Text = "Vorname"
        Me.colKundenVorname.Width = 101
        '
        'colKundenNachname
        '
        Me.colKundenNachname.Text = "Nachname"
        Me.colKundenNachname.Width = 111
        '
        'colKundenStadt
        '
        Me.colKundenStadt.Text = "Stadt"
        Me.colKundenStadt.Width = 100
        '
        'colKundenStrasse
        '
        Me.colKundenStrasse.DisplayIndex = 5
        Me.colKundenStrasse.Text = "Straße"
        Me.colKundenStrasse.Width = 150
        '
        'colKundenPLZ
        '
        Me.colKundenPLZ.DisplayIndex = 6
        Me.colKundenPLZ.Text = "PLZ"
        '
        'colKundenLand
        '
        Me.colKundenLand.DisplayIndex = 7
        Me.colKundenLand.Text = "Land"
        Me.colKundenLand.Width = 120
        '
        'colKundenFirma
        '
        Me.colKundenFirma.DisplayIndex = 4
        Me.colKundenFirma.Text = "Firma"
        Me.colKundenFirma.Width = 140
        '
        'colKundenTel
        '
        Me.colKundenTel.Text = "Telefon"
        Me.colKundenTel.Width = 130
        '
        'colKundenEmail
        '
        Me.colKundenEmail.Text = "Email"
        Me.colKundenEmail.Width = 120
        '
        'colKundenExists
        '
        Me.colKundenExists.Text = "Exists"
        Me.colKundenExists.Width = 0
        '
        'colKundenID
        '
        Me.colKundenID.Text = "ID"
        Me.colKundenID.Width = 0
        '
        'dgvArtikel
        '
        Me.dgvArtikel.AllowUserToAddRows = False
        Me.dgvArtikel.AllowUserToOrderColumns = True
        Me.dgvArtikel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArtikel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArtikel.ColumnHeadersHeight = 35
        Me.dgvArtikel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLöschen, Me.colBestellBild, Me.colBestellMenge, Me.ArtNr, Me.colBestellName, Me.colBestellNetto, Me.colBestellBrutto, Me.colBestellNettoGes, Me.colBestellBruttoGes, Me.Lagerbestand, Me.MwSt, Me.Gewicht})
        Me.dgvArtikel.Location = New System.Drawing.Point(898, -6)
        Me.dgvArtikel.Margin = New System.Windows.Forms.Padding(30)
        Me.dgvArtikel.MultiSelect = False
        Me.dgvArtikel.Name = "dgvArtikel"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArtikel.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvArtikel.Size = New System.Drawing.Size(121, 82)
        Me.dgvArtikel.TabIndex = 95
        Me.dgvArtikel.Visible = False
        '
        'colLöschen
        '
        Me.colLöschen.HeaderText = " "
        Me.colLöschen.Name = "colLöschen"
        Me.colLöschen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLöschen.Width = 30
        '
        'colBestellBild
        '
        Me.colBestellBild.HeaderText = "Bild"
        Me.colBestellBild.Name = "colBestellBild"
        Me.colBestellBild.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBestellBild.Width = 65
        '
        'colBestellMenge
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red
        Me.colBestellMenge.DefaultCellStyle = DataGridViewCellStyle2
        Me.colBestellMenge.HeaderText = "M."
        Me.colBestellMenge.Name = "colBestellMenge"
        Me.colBestellMenge.Width = 30
        '
        'ArtNr
        '
        Me.ArtNr.HeaderText = "ArtNr."
        Me.ArtNr.Name = "ArtNr"
        Me.ArtNr.Width = 80
        '
        'colBestellName
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBestellName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colBestellName.HeaderText = "Name"
        Me.colBestellName.Name = "colBestellName"
        Me.colBestellName.Width = 120
        '
        'colBestellNetto
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        Me.colBestellNetto.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBestellNetto.HeaderText = "Netto"
        Me.colBestellNetto.Name = "colBestellNetto"
        Me.colBestellNetto.Width = 80
        '
        'colBestellBrutto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Green
        Me.colBestellBrutto.DefaultCellStyle = DataGridViewCellStyle5
        Me.colBestellBrutto.HeaderText = "Brutto"
        Me.colBestellBrutto.Name = "colBestellBrutto"
        Me.colBestellBrutto.Width = 80
        '
        'colBestellNettoGes
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        Me.colBestellNettoGes.DefaultCellStyle = DataGridViewCellStyle6
        Me.colBestellNettoGes.HeaderText = "G.Netto"
        Me.colBestellNettoGes.Name = "colBestellNettoGes"
        Me.colBestellNettoGes.Width = 83
        '
        'colBestellBruttoGes
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Green
        Me.colBestellBruttoGes.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBestellBruttoGes.HeaderText = "G.Brutto"
        Me.colBestellBruttoGes.Name = "colBestellBruttoGes"
        Me.colBestellBruttoGes.Width = 83
        '
        'Lagerbestand
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lagerbestand.DefaultCellStyle = DataGridViewCellStyle8
        Me.Lagerbestand.HeaderText = "Lager"
        Me.Lagerbestand.Name = "Lagerbestand"
        Me.Lagerbestand.Width = 60
        '
        'MwSt
        '
        Me.MwSt.HeaderText = "MwSt"
        Me.MwSt.Name = "MwSt"
        '
        'Gewicht
        '
        Me.Gewicht.HeaderText = "Gewicht"
        Me.Gewicht.Name = "Gewicht"
        '
        'btnBestellungEditieren
        '
        Me.btnBestellungEditieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBestellungEditieren.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellungEditieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBestellungEditieren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBestellungEditieren.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBestellungEditieren.Location = New System.Drawing.Point(198, 552)
        Me.btnBestellungEditieren.Name = "btnBestellungEditieren"
        Me.btnBestellungEditieren.Size = New System.Drawing.Size(173, 36)
        Me.btnBestellungEditieren.TabIndex = 96
        Me.btnBestellungEditieren.Text = "&Bestellung editieren..."
        Me.btnBestellungEditieren.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(460, 43)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 97
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Bisque
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBack.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBack.Location = New System.Drawing.Point(406, 43)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(48, 20)
        Me.btnBack.TabIndex = 99
        Me.btnBack.Text = "<<"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnVor
        '
        Me.btnVor.BackColor = System.Drawing.Color.Bisque
        Me.btnVor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnVor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVor.Location = New System.Drawing.Point(666, 43)
        Me.btnVor.Name = "btnVor"
        Me.btnVor.Size = New System.Drawing.Size(48, 20)
        Me.btnVor.TabIndex = 100
        Me.btnVor.Text = ">>"
        Me.btnVor.UseVisualStyleBackColor = False
        '
        'BestellungLöschenToolStripMenuItem
        '
        Me.BestellungLöschenToolStripMenuItem.Name = "BestellungLöschenToolStripMenuItem"
        Me.BestellungLöschenToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.BestellungLöschenToolStripMenuItem.Text = "Bestellung löschen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(250, 6)
        '
        'frmRechnungsArchiv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 600)
        Me.Controls.Add(Me.btnVor)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnBestellungEditieren)
        Me.Controls.Add(Me.dgvArtikel)
        Me.Controls.Add(Me.lvwKunde)
        Me.Controls.Add(Me.btnBestellungAdd)
        Me.Controls.Add(Me.lblSumme)
        Me.Controls.Add(Me.btnBestellungOpen)
        Me.Controls.Add(Me.chkImported)
        Me.Controls.Add(Me.txtSuchenKunde)
        Me.Controls.Add(Me.btnJTLImport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMasterHeader)
        Me.Controls.Add(Me.lvwRechnungen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRechnungsArchiv"
        Me.Text = "Internes Bridge Rechnungsarchiv"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvArtikel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwRechnungen As System.Windows.Forms.ListView
    Friend WithEvents colArchivArtikelName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivPreis As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivKundeName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivBestellID As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnJTLImport As System.Windows.Forms.Button
    Friend WithEvents lblMasterHeader As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleAnzeigenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSuchenKunde As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BestellungAnzeigenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBestellungOpen As System.Windows.Forms.Button
    Friend WithEvents colArchivStadt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivAnzahl As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivErstellt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivKNr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivPLZ As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivStrasse As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivVorname As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivTelefon As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivLand As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivFirma As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkImported As System.Windows.Forms.CheckBox
    Friend WithEvents colArchivImported As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArchivBenutzer As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblSumme As System.Windows.Forms.Label
    Friend WithEvents btnBestellungAdd As System.Windows.Forms.Button
    Friend WithEvents lvwKunde As System.Windows.Forms.ListView
    Friend WithEvents colKundenNr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenVorname As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenNachname As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenStadt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenStrasse As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenPLZ As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenLand As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenFirma As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenTel As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenExists As System.Windows.Forms.ColumnHeader
    Friend WithEvents colKundenID As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgvArtikel As System.Windows.Forms.DataGridView
    Friend WithEvents colLöschen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellBild As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellMenge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArtNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellNetto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellBrutto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellNettoGes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBestellBruttoGes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lagerbestand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MwSt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gewicht As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArchivcArtNr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colVerkaufsPreisNetto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMwSt As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBestellungEditieren As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents btnBack As Button
    Friend WithEvents btnVor As Button
    Friend WithEvents BestellungLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
