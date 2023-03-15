<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKundenauswahl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKundenauswahl))
        Me.txtSuchenKunde = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.colKundenRowHeight = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsKunden = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleKundenAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NeuerKundeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RouteDistanzAbrufenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnAbrechen = New System.Windows.Forms.Button()
        Me.btnSuchen = New System.Windows.Forms.Button()
        Me.btnNeuerKunde = New System.Windows.Forms.Button()
        Me.AlsKassenkundenFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsKunden.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSuchenKunde
        '
        Me.txtSuchenKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuchenKunde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuchenKunde.Location = New System.Drawing.Point(55, 5)
        Me.txtSuchenKunde.Name = "txtSuchenKunde"
        Me.txtSuchenKunde.Size = New System.Drawing.Size(155, 24)
        Me.txtSuchenKunde.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Suche"
        '
        'lvwKunde
        '
        Me.lvwKunde.AllowColumnReorder = True
        Me.lvwKunde.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwKunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwKunde.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colKundenNr, Me.colKundenVorname, Me.colKundenNachname, Me.colKundenStadt, Me.colKundenStrasse, Me.colKundenPLZ, Me.colKundenLand, Me.colKundenFirma, Me.colKundenTel, Me.colKundenEmail, Me.colKundenExists, Me.colKundenID, Me.colKundenRowHeight})
        Me.lvwKunde.ContextMenuStrip = Me.cmsKunden
        Me.lvwKunde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lvwKunde.FullRowSelect = True
        Me.lvwKunde.GridLines = True
        Me.lvwKunde.HideSelection = False
        Me.lvwKunde.Location = New System.Drawing.Point(12, 38)
        Me.lvwKunde.MultiSelect = False
        Me.lvwKunde.Name = "lvwKunde"
        Me.lvwKunde.Size = New System.Drawing.Size(781, 484)
        Me.lvwKunde.SmallImageList = Me.ImageList1
        Me.lvwKunde.StateImageList = Me.ImageList1
        Me.lvwKunde.TabIndex = 92
        Me.lvwKunde.UseCompatibleStateImageBehavior = False
        Me.lvwKunde.View = System.Windows.Forms.View.Details
        '
        'colKundenNr
        '
        Me.colKundenNr.Text = "Nr."
        Me.colKundenNr.Width = 110
        '
        'colKundenVorname
        '
        Me.colKundenVorname.DisplayIndex = 2
        Me.colKundenVorname.Text = "Vorname"
        Me.colKundenVorname.Width = 101
        '
        'colKundenNachname
        '
        Me.colKundenNachname.DisplayIndex = 3
        Me.colKundenNachname.Text = "Nachname"
        Me.colKundenNachname.Width = 111
        '
        'colKundenStadt
        '
        Me.colKundenStadt.DisplayIndex = 5
        Me.colKundenStadt.Text = "Stadt"
        Me.colKundenStadt.Width = 100
        '
        'colKundenStrasse
        '
        Me.colKundenStrasse.DisplayIndex = 6
        Me.colKundenStrasse.Text = "Straße"
        Me.colKundenStrasse.Width = 150
        '
        'colKundenPLZ
        '
        Me.colKundenPLZ.DisplayIndex = 4
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
        Me.colKundenFirma.DisplayIndex = 1
        Me.colKundenFirma.Text = "Firma"
        Me.colKundenFirma.Width = 130
        '
        'colKundenTel
        '
        Me.colKundenTel.Text = "Telefon"
        Me.colKundenTel.Width = 120
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
        'colKundenRowHeight
        '
        Me.colKundenRowHeight.Text = "Height"
        Me.colKundenRowHeight.Width = 0
        '
        'cmsKunden
        '
        Me.cmsKunden.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleKundenAnzeigenToolStripMenuItem, Me.ToolStripSeparator2, Me.NeuerKundeToolStripMenuItem1, Me.RouteDistanzAbrufenToolStripMenuItem, Me.ToolStripSeparator1, Me.AlsKassenkundenFestlegenToolStripMenuItem})
        Me.cmsKunden.Name = "cmsKunden"
        Me.cmsKunden.Size = New System.Drawing.Size(224, 126)
        '
        'AlleKundenAnzeigenToolStripMenuItem
        '
        Me.AlleKundenAnzeigenToolStripMenuItem.Name = "AlleKundenAnzeigenToolStripMenuItem"
        Me.AlleKundenAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AlleKundenAnzeigenToolStripMenuItem.Text = "Alle Kunden anzeigen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(220, 6)
        '
        'NeuerKundeToolStripMenuItem1
        '
        Me.NeuerKundeToolStripMenuItem1.Name = "NeuerKundeToolStripMenuItem1"
        Me.NeuerKundeToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.NeuerKundeToolStripMenuItem1.Text = "Neuer Kunde..."
        '
        'RouteDistanzAbrufenToolStripMenuItem
        '
        Me.RouteDistanzAbrufenToolStripMenuItem.Name = "RouteDistanzAbrufenToolStripMenuItem"
        Me.RouteDistanzAbrufenToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.RouteDistanzAbrufenToolStripMenuItem.Text = "Route / Distanz abrufen..."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "sport_raquet.png")
        Me.ImageList1.Images.SetKeyName(1, "accept.png")
        Me.ImageList1.Images.SetKeyName(2, "application_form_delete.png")
        Me.ImageList1.Images.SetKeyName(3, "row-height.png")
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.Bisque
        Me.btnOK.Enabled = False
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.ImageKey = "accept.png"
        Me.btnOK.ImageList = Me.ImageList1
        Me.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOK.Location = New System.Drawing.Point(554, 528)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 36)
        Me.btnOK.TabIndex = 93
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnAbrechen
        '
        Me.btnAbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbrechen.BackColor = System.Drawing.Color.Bisque
        Me.btnAbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrechen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnAbrechen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbrechen.ImageKey = "application_form_delete.png"
        Me.btnAbrechen.ImageList = Me.ImageList1
        Me.btnAbrechen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbrechen.Location = New System.Drawing.Point(678, 528)
        Me.btnAbrechen.Name = "btnAbrechen"
        Me.btnAbrechen.Size = New System.Drawing.Size(118, 36)
        Me.btnAbrechen.TabIndex = 94
        Me.btnAbrechen.Text = "&Abbrechen"
        Me.btnAbrechen.UseVisualStyleBackColor = False
        '
        'btnSuchen
        '
        Me.btnSuchen.BackColor = System.Drawing.Color.Bisque
        Me.btnSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuchen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSuchen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSuchen.ImageKey = "sport_raquet.png"
        Me.btnSuchen.ImageList = Me.ImageList1
        Me.btnSuchen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSuchen.Location = New System.Drawing.Point(216, 4)
        Me.btnSuchen.Name = "btnSuchen"
        Me.btnSuchen.Size = New System.Drawing.Size(112, 27)
        Me.btnSuchen.TabIndex = 96
        Me.btnSuchen.Text = "Suche..."
        Me.btnSuchen.UseVisualStyleBackColor = False
        '
        'btnNeuerKunde
        '
        Me.btnNeuerKunde.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNeuerKunde.BackColor = System.Drawing.Color.Bisque
        Me.btnNeuerKunde.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNeuerKunde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnNeuerKunde.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNeuerKunde.ImageKey = "accept.png"
        Me.btnNeuerKunde.ImageList = Me.ImageList1
        Me.btnNeuerKunde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNeuerKunde.Location = New System.Drawing.Point(12, 528)
        Me.btnNeuerKunde.Name = "btnNeuerKunde"
        Me.btnNeuerKunde.Size = New System.Drawing.Size(147, 36)
        Me.btnNeuerKunde.TabIndex = 97
        Me.btnNeuerKunde.Text = "&Neuer Kunde..."
        Me.btnNeuerKunde.UseVisualStyleBackColor = False
        '
        'AlsKassenkundenFestlegenToolStripMenuItem
        '
        Me.AlsKassenkundenFestlegenToolStripMenuItem.Name = "AlsKassenkundenFestlegenToolStripMenuItem"
        Me.AlsKassenkundenFestlegenToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AlsKassenkundenFestlegenToolStripMenuItem.Text = "Als Kassenkunden festlegen!"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(220, 6)
        '
        'frmKundenauswahl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 572)
        Me.Controls.Add(Me.btnNeuerKunde)
        Me.Controls.Add(Me.btnSuchen)
        Me.Controls.Add(Me.btnAbrechen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lvwKunde)
        Me.Controls.Add(Me.txtSuchenKunde)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKundenauswahl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kundenauswahl"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cmsKunden.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSuchenKunde As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAbrechen As System.Windows.Forms.Button
    Friend WithEvents cmsKunden As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleKundenAnzeigenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NeuerKundeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RouteDistanzAbrufenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSuchen As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnNeuerKunde As System.Windows.Forms.Button
    Friend WithEvents colKundenRowHeight As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AlsKassenkundenFestlegenToolStripMenuItem As ToolStripMenuItem
End Class
