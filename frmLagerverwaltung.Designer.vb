<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLagerverwaltung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLagerverwaltung))
        Me.lblTitel = New System.Windows.Forms.Label()
        Me.txtLagerbestandNeu = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtLagerbestand_alt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArtikelnummer = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLageranzahl = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPreis = New System.Windows.Forms.Label()
        Me.btnDelWarehouse = New System.Windows.Forms.Button()
        Me.btnAddWarehouse = New System.Windows.Forms.Button()
        Me.btnLagerbestand_save = New System.Windows.Forms.Button()
        Me.chkOptAddDelWarehouseTotal = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblVerfügbarNeu = New System.Windows.Forms.Label()
        Me.lblVerfügbarALT = New System.Windows.Forms.Label()
        Me.lblMHDOption = New System.Windows.Forms.Label()
        Me.lblkArtikel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMHD = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChargenummer = New System.Windows.Forms.TextBox()
        Me.lblMHD = New System.Windows.Forms.Label()
        Me.MonthCalendarMHD = New System.Windows.Forms.MonthCalendar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtKommentar = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTitel
        '
        Me.lblTitel.AutoSize = True
        Me.lblTitel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitel.Location = New System.Drawing.Point(11, 9)
        Me.lblTitel.Name = "lblTitel"
        Me.lblTitel.Size = New System.Drawing.Size(50, 24)
        Me.lblTitel.TabIndex = 0
        Me.lblTitel.Text = "Titel"
        '
        'txtLagerbestandNeu
        '
        Me.txtLagerbestandNeu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLagerbestandNeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLagerbestandNeu.Enabled = False
        Me.txtLagerbestandNeu.Location = New System.Drawing.Point(264, 118)
        Me.txtLagerbestandNeu.Name = "txtLagerbestandNeu"
        Me.txtLagerbestandNeu.Size = New System.Drawing.Size(70, 20)
        Me.txtLagerbestandNeu.TabIndex = 1
        Me.txtLagerbestandNeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lagerbestand Neu"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        Me.ImageList1.Images.SetKeyName(1, "table_add.png")
        Me.ImageList1.Images.SetKeyName(2, "table_delete.png")
        '
        'txtLagerbestand_alt
        '
        Me.txtLagerbestand_alt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLagerbestand_alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLagerbestand_alt.Enabled = False
        Me.txtLagerbestand_alt.Location = New System.Drawing.Point(40, 118)
        Me.txtLagerbestand_alt.Name = "txtLagerbestand_alt"
        Me.txtLagerbestand_alt.Size = New System.Drawing.Size(70, 20)
        Me.txtLagerbestand_alt.TabIndex = 10
        Me.txtLagerbestand_alt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Lagerbestand Alt"
        '
        'lblArtikelnummer
        '
        Me.lblArtikelnummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArtikelnummer.AutoSize = True
        Me.lblArtikelnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtikelnummer.Location = New System.Drawing.Point(136, 42)
        Me.lblArtikelnummer.Name = "lblArtikelnummer"
        Me.lblArtikelnummer.Size = New System.Drawing.Size(73, 13)
        Me.lblArtikelnummer.TabIndex = 4
        Me.lblArtikelnummer.Text = "Artikelnummer"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(160, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Anzahl "
        '
        'txtLageranzahl
        '
        Me.txtLageranzahl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLageranzahl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLageranzahl.Location = New System.Drawing.Point(163, 118)
        Me.txtLageranzahl.Name = "txtLageranzahl"
        Me.txtLageranzahl.Size = New System.Drawing.Size(70, 20)
        Me.txtLageranzahl.TabIndex = 0
        Me.txtLageranzahl.Text = "0"
        Me.txtLageranzahl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "ID: "
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(265, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Preis: "
        '
        'lblPreis
        '
        Me.lblPreis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPreis.AutoSize = True
        Me.lblPreis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreis.Location = New System.Drawing.Point(311, 42)
        Me.lblPreis.Name = "lblPreis"
        Me.lblPreis.Size = New System.Drawing.Size(30, 13)
        Me.lblPreis.TabIndex = 14
        Me.lblPreis.Text = "Preis"
        '
        'btnDelWarehouse
        '
        Me.btnDelWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelWarehouse.BackColor = System.Drawing.Color.Bisque
        Me.btnDelWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelWarehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelWarehouse.ImageKey = "table_delete.png"
        Me.btnDelWarehouse.ImageList = Me.ImageList1
        Me.btnDelWarehouse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDelWarehouse.Location = New System.Drawing.Point(314, 172)
        Me.btnDelWarehouse.Name = "btnDelWarehouse"
        Me.btnDelWarehouse.Size = New System.Drawing.Size(55, 36)
        Me.btnDelWarehouse.TabIndex = 12
        Me.btnDelWarehouse.Text = "   -"
        Me.btnDelWarehouse.UseVisualStyleBackColor = False
        '
        'btnAddWarehouse
        '
        Me.btnAddWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddWarehouse.BackColor = System.Drawing.Color.Bisque
        Me.btnAddWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddWarehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddWarehouse.ImageKey = "table_add.png"
        Me.btnAddWarehouse.ImageList = Me.ImageList1
        Me.btnAddWarehouse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAddWarehouse.Location = New System.Drawing.Point(37, 172)
        Me.btnAddWarehouse.Name = "btnAddWarehouse"
        Me.btnAddWarehouse.Size = New System.Drawing.Size(55, 36)
        Me.btnAddWarehouse.TabIndex = 11
        Me.btnAddWarehouse.Text = "   +"
        Me.btnAddWarehouse.UseVisualStyleBackColor = False
        '
        'btnLagerbestand_save
        '
        Me.btnLagerbestand_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLagerbestand_save.BackColor = System.Drawing.Color.Bisque
        Me.btnLagerbestand_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLagerbestand_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnLagerbestand_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLagerbestand_save.ImageKey = "accept.png"
        Me.btnLagerbestand_save.ImageList = Me.ImageList1
        Me.btnLagerbestand_save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLagerbestand_save.Location = New System.Drawing.Point(98, 172)
        Me.btnLagerbestand_save.Name = "btnLagerbestand_save"
        Me.btnLagerbestand_save.Size = New System.Drawing.Size(210, 36)
        Me.btnLagerbestand_save.TabIndex = 2
        Me.btnLagerbestand_save.Text = "&Lagerbestand übernehmen"
        Me.btnLagerbestand_save.UseVisualStyleBackColor = False
        '
        'chkOptAddDelWarehouseTotal
        '
        Me.chkOptAddDelWarehouseTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkOptAddDelWarehouseTotal.AutoSize = True
        Me.chkOptAddDelWarehouseTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOptAddDelWarehouseTotal.Location = New System.Drawing.Point(40, 149)
        Me.chkOptAddDelWarehouseTotal.Name = "chkOptAddDelWarehouseTotal"
        Me.chkOptAddDelWarehouseTotal.Size = New System.Drawing.Size(286, 17)
        Me.chkOptAddDelWarehouseTotal.TabIndex = 16
        Me.chkOptAddDelWarehouseTotal.Text = "Addieren und Subtrahieren vom aktuellen Lagerbestand"
        Me.chkOptAddDelWarehouseTotal.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(340, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "X"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(239, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "X"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(116, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "X"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(45, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Verfügbar ALT:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(212, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Verfügbar NEU:"
        '
        'lblVerfügbarNeu
        '
        Me.lblVerfügbarNeu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVerfügbarNeu.AutoSize = True
        Me.lblVerfügbarNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerfügbarNeu.Location = New System.Drawing.Point(314, 76)
        Me.lblVerfügbarNeu.Name = "lblVerfügbarNeu"
        Me.lblVerfügbarNeu.Size = New System.Drawing.Size(0, 13)
        Me.lblVerfügbarNeu.TabIndex = 32
        '
        'lblVerfügbarALT
        '
        Me.lblVerfügbarALT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVerfügbarALT.AutoSize = True
        Me.lblVerfügbarALT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerfügbarALT.Location = New System.Drawing.Point(136, 76)
        Me.lblVerfügbarALT.Name = "lblVerfügbarALT"
        Me.lblVerfügbarALT.Size = New System.Drawing.Size(0, 13)
        Me.lblVerfügbarALT.TabIndex = 33
        '
        'lblMHDOption
        '
        Me.lblMHDOption.AutoSize = True
        Me.lblMHDOption.Location = New System.Drawing.Point(342, 475)
        Me.lblMHDOption.Name = "lblMHDOption"
        Me.lblMHDOption.Size = New System.Drawing.Size(69, 13)
        Me.lblMHDOption.TabIndex = 43
        Me.lblMHDOption.Text = "kMHDOption"
        '
        'lblkArtikel
        '
        Me.lblkArtikel.AutoSize = True
        Me.lblkArtikel.Location = New System.Drawing.Point(342, 453)
        Me.lblkArtikel.Name = "lblkArtikel"
        Me.lblkArtikel.Size = New System.Drawing.Size(42, 13)
        Me.lblkArtikel.TabIndex = 42
        Me.lblkArtikel.Text = "kArtikel"
        Me.lblkArtikel.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(194, 357)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Mindesthaltbarkeitsdatum"
        '
        'txtMHD
        '
        Me.txtMHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMHD.Location = New System.Drawing.Point(197, 373)
        Me.txtMHD.Name = "txtMHD"
        Me.txtMHD.Size = New System.Drawing.Size(203, 20)
        Me.txtMHD.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(194, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Chargenummer"
        '
        'txtChargenummer
        '
        Me.txtChargenummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChargenummer.Location = New System.Drawing.Point(197, 322)
        Me.txtChargenummer.Name = "txtChargenummer"
        Me.txtChargenummer.Size = New System.Drawing.Size(203, 20)
        Me.txtChargenummer.TabIndex = 39
        '
        'lblMHD
        '
        Me.lblMHD.AutoSize = True
        Me.lblMHD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMHD.Location = New System.Drawing.Point(12, 287)
        Me.lblMHD.Name = "lblMHD"
        Me.lblMHD.Size = New System.Drawing.Size(151, 13)
        Me.lblMHD.TabIndex = 37
        Me.lblMHD.Text = "Mindesthaltbarkeitsdatum"
        '
        'MonthCalendarMHD
        '
        Me.MonthCalendarMHD.Location = New System.Drawing.Point(15, 309)
        Me.MonthCalendarMHD.Name = "MonthCalendarMHD"
        Me.MonthCalendarMHD.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(210, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Kommentar zur Buchung hinzufügen"
        '
        'txtKommentar
        '
        Me.txtKommentar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKommentar.Location = New System.Drawing.Point(15, 257)
        Me.txtKommentar.Name = "txtKommentar"
        Me.txtKommentar.Size = New System.Drawing.Size(385, 20)
        Me.txtKommentar.TabIndex = 35
        '
        'frmLagerverwaltung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 489)
        Me.Controls.Add(Me.lblMHDOption)
        Me.Controls.Add(Me.lblkArtikel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMHD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtChargenummer)
        Me.Controls.Add(Me.lblMHD)
        Me.Controls.Add(Me.MonthCalendarMHD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtKommentar)
        Me.Controls.Add(Me.lblVerfügbarALT)
        Me.Controls.Add(Me.lblVerfügbarNeu)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkOptAddDelWarehouseTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblPreis)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDelWarehouse)
        Me.Controls.Add(Me.btnAddWarehouse)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLageranzahl)
        Me.Controls.Add(Me.lblArtikelnummer)
        Me.Controls.Add(Me.btnLagerbestand_save)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLagerbestand_alt)
        Me.Controls.Add(Me.txtLagerbestandNeu)
        Me.Controls.Add(Me.lblTitel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLagerverwaltung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lagerverwaltung"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitel As System.Windows.Forms.Label
    Friend WithEvents txtLagerbestandNeu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLagerbestand_save As System.Windows.Forms.Button
    Friend WithEvents txtLagerbestand_alt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblArtikelnummer As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLageranzahl As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnAddWarehouse As System.Windows.Forms.Button
    Friend WithEvents btnDelWarehouse As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPreis As System.Windows.Forms.Label
    Friend WithEvents chkOptAddDelWarehouseTotal As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblVerfügbarNeu As Label
    Friend WithEvents lblVerfügbarALT As Label
    Friend WithEvents txtKommentar As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents MonthCalendarMHD As MonthCalendar
    Friend WithEvents lblMHD As Label
    Friend WithEvents txtChargenummer As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMHD As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblkArtikel As Label
    Friend WithEvents lblMHDOption As Label
End Class
