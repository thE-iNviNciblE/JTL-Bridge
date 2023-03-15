<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJTLRechnung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJTLRechnung))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.lblSuche = New System.Windows.Forms.Label()
        Me.txtSuchenArtikel = New System.Windows.Forms.TextBox()
        Me.lblÜberschrift = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbAlle = New System.Windows.Forms.TabPage()
        Me.lvwArtikel_alle = New System.Windows.Forms.ListView()
        Me.colBild = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArtikelNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNetto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBrutto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLagerbestand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEKNetto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEKBrutto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGewicht = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMwSt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsArtikel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LagerbestandÄndernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvwArtikel_kategorien = New System.Windows.Forms.ListView()
        Me.colCatID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
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
        Me.lblKundennummer = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblGoogleMaps = New System.Windows.Forms.LinkLabel()
        Me.txtSuchenKunde = New System.Windows.Forms.TextBox()
        Me.cmbMandantenauswahl = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvArtikel = New System.Windows.Forms.DataGridView()
        Me.colLöschen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colBestellBild = New System.Windows.Forms.DataGridViewImageColumn()
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
        Me.cmsBestellung = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MengeVerändernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MehrwertsteuerAnpassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FreipositionHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDistanz = New System.Windows.Forms.LinkLabel()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WerkzeugeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechnungenAuflistenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuerKundeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoutenplanerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MandantenwechselToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenbankeinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartnummernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpracheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeutschToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnglischToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VietnamesischToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LagerverwaltungAktivierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebseiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KontaktierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblArtikelanzahl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGesammtsumme = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGoogleBenzin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msgMaster = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msgProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBestellungDrucken = New System.Windows.Forms.Button()
        Me.btnBestellungAnlegen = New System.Windows.Forms.Button()
        Me.btnLöschen = New System.Windows.Forms.Button()
        Me.btnViewSelector = New System.Windows.Forms.Button()
        Me.lblKundenData = New System.Windows.Forms.Label()
        Me.btnBestellliste = New System.Windows.Forms.Button()
        Me.lblBarkunde = New System.Windows.Forms.LinkLabel()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbAlle.SuspendLayout()
        Me.cmsArtikel.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsBestellung.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer5
        '
        resources.ApplyResources(Me.SplitContainer5, "SplitContainer5")
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.lblSuche)
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtSuchenArtikel)
        Me.SplitContainer5.Panel1.Controls.Add(Me.lblÜberschrift)
        resources.ApplyResources(Me.SplitContainer5.Panel1, "SplitContainer5.Panel1")
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.TabControl1)
        '
        'lblSuche
        '
        resources.ApplyResources(Me.lblSuche, "lblSuche")
        Me.lblSuche.Name = "lblSuche"
        '
        'txtSuchenArtikel
        '
        resources.ApplyResources(Me.txtSuchenArtikel, "txtSuchenArtikel")
        Me.txtSuchenArtikel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuchenArtikel.Name = "txtSuchenArtikel"
        '
        'lblÜberschrift
        '
        resources.ApplyResources(Me.lblÜberschrift, "lblÜberschrift")
        Me.lblÜberschrift.Name = "lblÜberschrift"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbAlle)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'tbAlle
        '
        resources.ApplyResources(Me.tbAlle, "tbAlle")
        Me.tbAlle.Controls.Add(Me.lvwArtikel_alle)
        Me.tbAlle.Name = "tbAlle"
        Me.tbAlle.UseVisualStyleBackColor = True
        '
        'lvwArtikel_alle
        '
        Me.lvwArtikel_alle.AllowColumnReorder = True
        Me.lvwArtikel_alle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwArtikel_alle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colBild, Me.colArtikelNr, Me.colName, Me.colNetto, Me.colBrutto, Me.colLagerbestand, Me.colEKNetto, Me.colEKBrutto, Me.colGewicht, Me.colMwSt})
        Me.lvwArtikel_alle.ContextMenuStrip = Me.cmsArtikel
        resources.ApplyResources(Me.lvwArtikel_alle, "lvwArtikel_alle")
        Me.lvwArtikel_alle.FullRowSelect = True
        Me.lvwArtikel_alle.GridLines = True
        Me.lvwArtikel_alle.HideSelection = False
        Me.lvwArtikel_alle.LargeImageList = Me.ImageList1
        Me.lvwArtikel_alle.Name = "lvwArtikel_alle"
        Me.lvwArtikel_alle.UseCompatibleStateImageBehavior = False
        Me.lvwArtikel_alle.View = System.Windows.Forms.View.Details
        '
        'colBild
        '
        resources.ApplyResources(Me.colBild, "colBild")
        '
        'colArtikelNr
        '
        resources.ApplyResources(Me.colArtikelNr, "colArtikelNr")
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        '
        'colNetto
        '
        resources.ApplyResources(Me.colNetto, "colNetto")
        '
        'colBrutto
        '
        resources.ApplyResources(Me.colBrutto, "colBrutto")
        '
        'colLagerbestand
        '
        resources.ApplyResources(Me.colLagerbestand, "colLagerbestand")
        '
        'colEKNetto
        '
        resources.ApplyResources(Me.colEKNetto, "colEKNetto")
        '
        'colEKBrutto
        '
        resources.ApplyResources(Me.colEKBrutto, "colEKBrutto")
        '
        'colGewicht
        '
        resources.ApplyResources(Me.colGewicht, "colGewicht")
        '
        'colMwSt
        '
        resources.ApplyResources(Me.colMwSt, "colMwSt")
        '
        'cmsArtikel
        '
        Me.cmsArtikel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LagerbestandÄndernToolStripMenuItem})
        Me.cmsArtikel.Name = "cmsArtikel"
        resources.ApplyResources(Me.cmsArtikel, "cmsArtikel")
        '
        'LagerbestandÄndernToolStripMenuItem
        '
        Me.LagerbestandÄndernToolStripMenuItem.Image = Global.JTLRechnung.My.Resources.Resources.application_view_columns
        Me.LagerbestandÄndernToolStripMenuItem.Name = "LagerbestandÄndernToolStripMenuItem"
        resources.ApplyResources(Me.LagerbestandÄndernToolStripMenuItem, "LagerbestandÄndernToolStripMenuItem")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok")
        Me.ImageList1.Images.SetKeyName(1, "gen-himmel021.jpg")
        Me.ImageList1.Images.SetKeyName(2, "spa.jpg")
        Me.ImageList1.Images.SetKeyName(3, "calendar_delete.png")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvwArtikel_kategorien)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvwArtikel_kategorien
        '
        Me.lvwArtikel_kategorien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwArtikel_kategorien.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCatID, Me.colCatName})
        resources.ApplyResources(Me.lvwArtikel_kategorien, "lvwArtikel_kategorien")
        Me.lvwArtikel_kategorien.FullRowSelect = True
        Me.lvwArtikel_kategorien.GridLines = True
        Me.lvwArtikel_kategorien.HideSelection = False
        Me.lvwArtikel_kategorien.Name = "lvwArtikel_kategorien"
        Me.lvwArtikel_kategorien.UseCompatibleStateImageBehavior = False
        Me.lvwArtikel_kategorien.View = System.Windows.Forms.View.Details
        '
        'colCatID
        '
        resources.ApplyResources(Me.colCatID, "colCatID")
        '
        'colCatName
        '
        resources.ApplyResources(Me.colCatName, "colCatName")
        '
        'SplitContainer4
        '
        resources.ApplyResources(Me.SplitContainer4, "SplitContainer4")
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        '
        'FlowLayoutPanel1
        '
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDistanz)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer2
        '
        resources.ApplyResources(Me.SplitContainer2, "SplitContainer2")
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lvwKunde)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblKundennummer)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblGoogleMaps)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtSuchenKunde)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbMandantenauswahl)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DateTimePicker1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvArtikel)
        '
        'lvwKunde
        '
        Me.lvwKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwKunde.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colKundenNr, Me.colKundenVorname, Me.colKundenNachname, Me.colKundenStadt, Me.colKundenStrasse, Me.colKundenPLZ, Me.colKundenLand, Me.colKundenFirma, Me.colKundenTel, Me.colKundenEmail, Me.colKundenExists, Me.colKundenID})
        resources.ApplyResources(Me.lvwKunde, "lvwKunde")
        Me.lvwKunde.FullRowSelect = True
        Me.lvwKunde.GridLines = True
        Me.lvwKunde.HideSelection = False
        Me.lvwKunde.MultiSelect = False
        Me.lvwKunde.Name = "lvwKunde"
        Me.lvwKunde.UseCompatibleStateImageBehavior = False
        Me.lvwKunde.View = System.Windows.Forms.View.Details
        '
        'colKundenNr
        '
        resources.ApplyResources(Me.colKundenNr, "colKundenNr")
        '
        'colKundenVorname
        '
        resources.ApplyResources(Me.colKundenVorname, "colKundenVorname")
        '
        'colKundenNachname
        '
        resources.ApplyResources(Me.colKundenNachname, "colKundenNachname")
        '
        'colKundenStadt
        '
        resources.ApplyResources(Me.colKundenStadt, "colKundenStadt")
        '
        'colKundenStrasse
        '
        resources.ApplyResources(Me.colKundenStrasse, "colKundenStrasse")
        '
        'colKundenPLZ
        '
        resources.ApplyResources(Me.colKundenPLZ, "colKundenPLZ")
        '
        'colKundenLand
        '
        resources.ApplyResources(Me.colKundenLand, "colKundenLand")
        '
        'colKundenFirma
        '
        resources.ApplyResources(Me.colKundenFirma, "colKundenFirma")
        '
        'colKundenTel
        '
        resources.ApplyResources(Me.colKundenTel, "colKundenTel")
        '
        'colKundenEmail
        '
        resources.ApplyResources(Me.colKundenEmail, "colKundenEmail")
        '
        'colKundenExists
        '
        resources.ApplyResources(Me.colKundenExists, "colKundenExists")
        '
        'colKundenID
        '
        resources.ApplyResources(Me.colKundenID, "colKundenID")
        '
        'lblKundennummer
        '
        resources.ApplyResources(Me.lblKundennummer, "lblKundennummer")
        Me.lblKundennummer.Name = "lblKundennummer"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblGoogleMaps
        '
        resources.ApplyResources(Me.lblGoogleMaps, "lblGoogleMaps")
        Me.lblGoogleMaps.Name = "lblGoogleMaps"
        Me.lblGoogleMaps.TabStop = True
        '
        'txtSuchenKunde
        '
        Me.txtSuchenKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtSuchenKunde, "txtSuchenKunde")
        Me.txtSuchenKunde.Name = "txtSuchenKunde"
        '
        'cmbMandantenauswahl
        '
        Me.cmbMandantenauswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbMandantenauswahl, "cmbMandantenauswahl")
        Me.cmbMandantenauswahl.FormattingEnabled = True
        Me.cmbMandantenauswahl.Name = "cmbMandantenauswahl"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        '
        'dgvArtikel
        '
        Me.dgvArtikel.AllowUserToOrderColumns = True
        Me.dgvArtikel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArtikel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        resources.ApplyResources(Me.dgvArtikel, "dgvArtikel")
        Me.dgvArtikel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLöschen, Me.colBestellBild, Me.colBestellMenge, Me.ArtNr, Me.colBestellName, Me.colBestellNetto, Me.colBestellBrutto, Me.colBestellNettoGes, Me.colBestellBruttoGes, Me.Lagerbestand, Me.MwSt, Me.Gewicht})
        Me.dgvArtikel.ContextMenuStrip = Me.cmsBestellung
        Me.dgvArtikel.MultiSelect = False
        Me.dgvArtikel.Name = "dgvArtikel"
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArtikel.RowsDefaultCellStyle = DataGridViewCellStyle18
        '
        'colLöschen
        '
        resources.ApplyResources(Me.colLöschen, "colLöschen")
        Me.colLöschen.Name = "colLöschen"
        Me.colLöschen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLöschen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colBestellBild
        '
        resources.ApplyResources(Me.colBestellBild, "colBestellBild")
        Me.colBestellBild.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colBestellBild.Name = "colBestellBild"
        Me.colBestellBild.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBestellBild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colBestellMenge
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red
        Me.colBestellMenge.DefaultCellStyle = DataGridViewCellStyle11
        resources.ApplyResources(Me.colBestellMenge, "colBestellMenge")
        Me.colBestellMenge.Name = "colBestellMenge"
        '
        'ArtNr
        '
        resources.ApplyResources(Me.ArtNr, "ArtNr")
        Me.ArtNr.Name = "ArtNr"
        '
        'colBestellName
        '
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBestellName.DefaultCellStyle = DataGridViewCellStyle12
        resources.ApplyResources(Me.colBestellName, "colBestellName")
        Me.colBestellName.Name = "colBestellName"
        '
        'colBestellNetto
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Blue
        Me.colBestellNetto.DefaultCellStyle = DataGridViewCellStyle13
        resources.ApplyResources(Me.colBestellNetto, "colBestellNetto")
        Me.colBestellNetto.Name = "colBestellNetto"
        '
        'colBestellBrutto
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Green
        Me.colBestellBrutto.DefaultCellStyle = DataGridViewCellStyle14
        resources.ApplyResources(Me.colBestellBrutto, "colBestellBrutto")
        Me.colBestellBrutto.Name = "colBestellBrutto"
        '
        'colBestellNettoGes
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Blue
        Me.colBestellNettoGes.DefaultCellStyle = DataGridViewCellStyle15
        resources.ApplyResources(Me.colBestellNettoGes, "colBestellNettoGes")
        Me.colBestellNettoGes.Name = "colBestellNettoGes"
        '
        'colBestellBruttoGes
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Green
        Me.colBestellBruttoGes.DefaultCellStyle = DataGridViewCellStyle16
        resources.ApplyResources(Me.colBestellBruttoGes, "colBestellBruttoGes")
        Me.colBestellBruttoGes.Name = "colBestellBruttoGes"
        '
        'Lagerbestand
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lagerbestand.DefaultCellStyle = DataGridViewCellStyle17
        resources.ApplyResources(Me.Lagerbestand, "Lagerbestand")
        Me.Lagerbestand.Name = "Lagerbestand"
        '
        'MwSt
        '
        resources.ApplyResources(Me.MwSt, "MwSt")
        Me.MwSt.Name = "MwSt"
        '
        'Gewicht
        '
        resources.ApplyResources(Me.Gewicht, "Gewicht")
        Me.Gewicht.Name = "Gewicht"
        '
        'cmsBestellung
        '
        Me.cmsBestellung.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LöschenToolStripMenuItem, Me.ToolStripSeparator1, Me.MengeVerändernToolStripMenuItem, Me.MehrwertsteuerAnpassenToolStripMenuItem, Me.FreipositionHinzufügenToolStripMenuItem})
        Me.cmsBestellung.Name = "cmsBestellung"
        resources.ApplyResources(Me.cmsBestellung, "cmsBestellung")
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        resources.ApplyResources(Me.LöschenToolStripMenuItem, "LöschenToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'MengeVerändernToolStripMenuItem
        '
        Me.MengeVerändernToolStripMenuItem.Name = "MengeVerändernToolStripMenuItem"
        resources.ApplyResources(Me.MengeVerändernToolStripMenuItem, "MengeVerändernToolStripMenuItem")
        '
        'MehrwertsteuerAnpassenToolStripMenuItem
        '
        Me.MehrwertsteuerAnpassenToolStripMenuItem.Name = "MehrwertsteuerAnpassenToolStripMenuItem"
        resources.ApplyResources(Me.MehrwertsteuerAnpassenToolStripMenuItem, "MehrwertsteuerAnpassenToolStripMenuItem")
        '
        'FreipositionHinzufügenToolStripMenuItem
        '
        Me.FreipositionHinzufügenToolStripMenuItem.Name = "FreipositionHinzufügenToolStripMenuItem"
        resources.ApplyResources(Me.FreipositionHinzufügenToolStripMenuItem, "FreipositionHinzufügenToolStripMenuItem")
        '
        'lblDistanz
        '
        resources.ApplyResources(Me.lblDistanz, "lblDistanz")
        Me.lblDistanz.Name = "lblDistanz"
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "application_add.png")
        Me.ImageList3.Images.SetKeyName(1, "application_side_contract.png")
        Me.ImageList3.Images.SetKeyName(2, "basket_add.png")
        Me.ImageList3.Images.SetKeyName(3, "basket_delete.png")
        Me.ImageList3.Images.SetKeyName(4, "printer.png")
        Me.ImageList3.Images.SetKeyName(5, "money_add.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.WerkzeugeToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem1})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        resources.ApplyResources(Me.DateiToolStripMenuItem, "DateiToolStripMenuItem")
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        resources.ApplyResources(Me.BeendenToolStripMenuItem, "BeendenToolStripMenuItem")
        '
        'WerkzeugeToolStripMenuItem
        '
        Me.WerkzeugeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RechnungenAuflistenToolStripMenuItem, Me.NeuerKundeToolStripMenuItem, Me.RoutenplanerToolStripMenuItem, Me.MandantenwechselToolStripMenuItem})
        Me.WerkzeugeToolStripMenuItem.Name = "WerkzeugeToolStripMenuItem"
        resources.ApplyResources(Me.WerkzeugeToolStripMenuItem, "WerkzeugeToolStripMenuItem")
        '
        'RechnungenAuflistenToolStripMenuItem
        '
        Me.RechnungenAuflistenToolStripMenuItem.Name = "RechnungenAuflistenToolStripMenuItem"
        resources.ApplyResources(Me.RechnungenAuflistenToolStripMenuItem, "RechnungenAuflistenToolStripMenuItem")
        '
        'NeuerKundeToolStripMenuItem
        '
        Me.NeuerKundeToolStripMenuItem.Name = "NeuerKundeToolStripMenuItem"
        resources.ApplyResources(Me.NeuerKundeToolStripMenuItem, "NeuerKundeToolStripMenuItem")
        '
        'RoutenplanerToolStripMenuItem
        '
        Me.RoutenplanerToolStripMenuItem.Name = "RoutenplanerToolStripMenuItem"
        resources.ApplyResources(Me.RoutenplanerToolStripMenuItem, "RoutenplanerToolStripMenuItem")
        '
        'MandantenwechselToolStripMenuItem
        '
        Me.MandantenwechselToolStripMenuItem.Name = "MandantenwechselToolStripMenuItem"
        resources.ApplyResources(Me.MandantenwechselToolStripMenuItem, "MandantenwechselToolStripMenuItem")
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatenbankeinstellungenToolStripMenuItem, Me.StartnummernToolStripMenuItem, Me.EinstellungenToolStripMenuItem1, Me.ToolStripSeparator3, Me.SpracheToolStripMenuItem, Me.LagerverwaltungAktivierenToolStripMenuItem, Me.UpdatesToolStripMenuItem})
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        resources.ApplyResources(Me.EinstellungenToolStripMenuItem, "EinstellungenToolStripMenuItem")
        '
        'DatenbankeinstellungenToolStripMenuItem
        '
        Me.DatenbankeinstellungenToolStripMenuItem.Name = "DatenbankeinstellungenToolStripMenuItem"
        resources.ApplyResources(Me.DatenbankeinstellungenToolStripMenuItem, "DatenbankeinstellungenToolStripMenuItem")
        '
        'EinstellungenToolStripMenuItem1
        '
        Me.EinstellungenToolStripMenuItem1.Name = "EinstellungenToolStripMenuItem1"
        resources.ApplyResources(Me.EinstellungenToolStripMenuItem1, "EinstellungenToolStripMenuItem1")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'StartnummernToolStripMenuItem
        '
        Me.StartnummernToolStripMenuItem.Name = "StartnummernToolStripMenuItem"
        resources.ApplyResources(Me.StartnummernToolStripMenuItem, "StartnummernToolStripMenuItem")
        '
        'SpracheToolStripMenuItem
        '
        Me.SpracheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeutschToolStripMenuItem, Me.EnglischToolStripMenuItem, Me.VietnamesischToolStripMenuItem})
        Me.SpracheToolStripMenuItem.Name = "SpracheToolStripMenuItem"
        resources.ApplyResources(Me.SpracheToolStripMenuItem, "SpracheToolStripMenuItem")
        '
        'DeutschToolStripMenuItem
        '
        Me.DeutschToolStripMenuItem.Name = "DeutschToolStripMenuItem"
        resources.ApplyResources(Me.DeutschToolStripMenuItem, "DeutschToolStripMenuItem")
        '
        'EnglischToolStripMenuItem
        '
        Me.EnglischToolStripMenuItem.Name = "EnglischToolStripMenuItem"
        resources.ApplyResources(Me.EnglischToolStripMenuItem, "EnglischToolStripMenuItem")
        '
        'VietnamesischToolStripMenuItem
        '
        Me.VietnamesischToolStripMenuItem.Name = "VietnamesischToolStripMenuItem"
        resources.ApplyResources(Me.VietnamesischToolStripMenuItem, "VietnamesischToolStripMenuItem")
        '
        'LagerverwaltungAktivierenToolStripMenuItem
        '
        Me.LagerverwaltungAktivierenToolStripMenuItem.Name = "LagerverwaltungAktivierenToolStripMenuItem"
        resources.ApplyResources(Me.LagerverwaltungAktivierenToolStripMenuItem, "LagerverwaltungAktivierenToolStripMenuItem")
        '
        'UpdatesToolStripMenuItem
        '
        Me.UpdatesToolStripMenuItem.Name = "UpdatesToolStripMenuItem"
        resources.ApplyResources(Me.UpdatesToolStripMenuItem, "UpdatesToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebseiteToolStripMenuItem, Me.KontaktierenToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'WebseiteToolStripMenuItem
        '
        Me.WebseiteToolStripMenuItem.Name = "WebseiteToolStripMenuItem"
        resources.ApplyResources(Me.WebseiteToolStripMenuItem, "WebseiteToolStripMenuItem")
        '
        'KontaktierenToolStripMenuItem
        '
        Me.KontaktierenToolStripMenuItem.Name = "KontaktierenToolStripMenuItem"
        resources.ApplyResources(Me.KontaktierenToolStripMenuItem, "KontaktierenToolStripMenuItem")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblArtikelanzahl, Me.lblGesammtsumme, Me.lblGoogleBenzin, Me.msgMaster, Me.msgProgress})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'lblArtikelanzahl
        '
        resources.ApplyResources(Me.lblArtikelanzahl, "lblArtikelanzahl")
        Me.lblArtikelanzahl.Name = "lblArtikelanzahl"
        '
        'lblGesammtsumme
        '
        resources.ApplyResources(Me.lblGesammtsumme, "lblGesammtsumme")
        Me.lblGesammtsumme.Name = "lblGesammtsumme"
        '
        'lblGoogleBenzin
        '
        resources.ApplyResources(Me.lblGoogleBenzin, "lblGoogleBenzin")
        Me.lblGoogleBenzin.Name = "lblGoogleBenzin"
        '
        'msgMaster
        '
        resources.ApplyResources(Me.msgMaster, "msgMaster")
        Me.msgMaster.Name = "msgMaster"
        '
        'msgProgress
        '
        Me.msgProgress.Name = "msgProgress"
        resources.ApplyResources(Me.msgProgress, "msgProgress")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "calendar_delete.png")
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackColor = System.Drawing.Color.Bisque
        Me.Button1.ImageList = Me.ImageList3
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnBestellungDrucken
        '
        resources.ApplyResources(Me.btnBestellungDrucken, "btnBestellungDrucken")
        Me.btnBestellungDrucken.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellungDrucken.ImageList = Me.ImageList3
        Me.btnBestellungDrucken.Name = "btnBestellungDrucken"
        Me.btnBestellungDrucken.UseVisualStyleBackColor = False
        '
        'btnBestellungAnlegen
        '
        resources.ApplyResources(Me.btnBestellungAnlegen, "btnBestellungAnlegen")
        Me.btnBestellungAnlegen.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellungAnlegen.ImageList = Me.ImageList3
        Me.btnBestellungAnlegen.Name = "btnBestellungAnlegen"
        Me.btnBestellungAnlegen.UseVisualStyleBackColor = False
        '
        'btnLöschen
        '
        resources.ApplyResources(Me.btnLöschen, "btnLöschen")
        Me.btnLöschen.BackColor = System.Drawing.Color.Bisque
        Me.btnLöschen.ImageList = Me.ImageList3
        Me.btnLöschen.Name = "btnLöschen"
        Me.btnLöschen.UseVisualStyleBackColor = False
        '
        'btnViewSelector
        '
        resources.ApplyResources(Me.btnViewSelector, "btnViewSelector")
        Me.btnViewSelector.BackColor = System.Drawing.Color.Bisque
        Me.btnViewSelector.ImageList = Me.ImageList3
        Me.btnViewSelector.Name = "btnViewSelector"
        Me.btnViewSelector.UseVisualStyleBackColor = False
        '
        'lblKundenData
        '
        resources.ApplyResources(Me.lblKundenData, "lblKundenData")
        Me.lblKundenData.Name = "lblKundenData"
        '
        'btnBestellliste
        '
        resources.ApplyResources(Me.btnBestellliste, "btnBestellliste")
        Me.btnBestellliste.BackColor = System.Drawing.Color.Bisque
        Me.btnBestellliste.ImageList = Me.ImageList3
        Me.btnBestellliste.Name = "btnBestellliste"
        Me.btnBestellliste.UseVisualStyleBackColor = False
        '
        'lblBarkunde
        '
        resources.ApplyResources(Me.lblBarkunde, "lblBarkunde")
        Me.lblBarkunde.Name = "lblBarkunde"
        Me.lblBarkunde.TabStop = True
        '
        'frmJTLRechnung
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBarkunde)
        Me.Controls.Add(Me.btnBestellliste)
        Me.Controls.Add(Me.lblKundenData)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnViewSelector)
        Me.Controls.Add(Me.btnLöschen)
        Me.Controls.Add(Me.btnBestellungAnlegen)
        Me.Controls.Add(Me.btnBestellungDrucken)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmJTLRechnung"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbAlle.ResumeLayout(False)
        Me.cmsArtikel.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvArtikel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsBestellung.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmsBestellung As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnBestellungDrucken As System.Windows.Forms.Button
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MengeVerändernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBestellungAnlegen As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatenbankeinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WerkzeugeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechnungenAuflistenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgvArtikel As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EinstellungenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLöschen As System.Windows.Forms.Button
    Friend WithEvents NeuerKundeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDistanz As System.Windows.Forms.LinkLabel
    Friend WithEvents MehrwertsteuerAnpassenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RoutenplanerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StartnummernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpracheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeutschToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnglischToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VietnamesischToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsArtikel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LagerbestandÄndernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MandantenwechselToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblGesammtsumme As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblArtikelanzahl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LagerverwaltungAktivierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msgMaster As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnViewSelector As System.Windows.Forms.Button
    Friend WithEvents cmbMandantenauswahl As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSuchenKunde As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblGoogleMaps As System.Windows.Forms.LinkLabel
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblÜberschrift As System.Windows.Forms.Label
    Friend WithEvents txtSuchenArtikel As System.Windows.Forms.TextBox
    Friend WithEvents lblSuche As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbAlle As System.Windows.Forms.TabPage
    Friend WithEvents lvwArtikel_alle As System.Windows.Forms.ListView
    Friend WithEvents colBild As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArtikelNr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNetto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colBrutto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLagerbestand As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEKNetto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEKBrutto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colGewicht As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvwArtikel_kategorien As System.Windows.Forms.ListView
    Friend WithEvents colCatID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCatName As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents lblKundennummer As System.Windows.Forms.Label
    Friend WithEvents colMwSt As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents FreipositionHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblKundenData As System.Windows.Forms.Label
    Friend WithEvents btnBestellliste As System.Windows.Forms.Button
    Friend WithEvents colLöschen As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colBestellBild As System.Windows.Forms.DataGridViewImageColumn
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
    Friend WithEvents msgProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents UpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebseiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KontaktierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblGoogleBenzin As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblBarkunde As LinkLabel
End Class
