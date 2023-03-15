<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEinstellungen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEinstellungen))
        Me.lblFirma = New System.Windows.Forms.Label()
        Me.txtFirma = New System.Windows.Forms.TextBox()
        Me.txtVorname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNachname = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStraße = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPLZ = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStadt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLand = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtExportPfad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnExportPfad = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkAutologin = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkLVWSaveColum = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnOKSpeichern = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chkdvgArtikelAddRow = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGoogleMapsBenzinpreis = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSettingEinkaufsspalte = New System.Windows.Forms.CheckBox()
        Me.chkGoogleBenzinPreisAPI = New System.Windows.Forms.CheckBox()
        Me.chkLagerwarnmeldung = New System.Windows.Forms.CheckBox()
        Me.txtKassenKundenNummer = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFirma
        '
        Me.lblFirma.AutoSize = True
        Me.lblFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirma.Location = New System.Drawing.Point(14, 49)
        Me.lblFirma.Name = "lblFirma"
        Me.lblFirma.Size = New System.Drawing.Size(42, 13)
        Me.lblFirma.TabIndex = 3
        Me.lblFirma.Text = "Firma*"
        '
        'txtFirma
        '
        Me.txtFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirma.Location = New System.Drawing.Point(17, 65)
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Size = New System.Drawing.Size(173, 20)
        Me.txtFirma.TabIndex = 4
        '
        'txtVorname
        '
        Me.txtVorname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVorname.Location = New System.Drawing.Point(222, 65)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(173, 20)
        Me.txtVorname.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Vorname*"
        '
        'txtNachname
        '
        Me.txtNachname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNachname.Location = New System.Drawing.Point(432, 65)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(173, 20)
        Me.txtNachname.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(429, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nachname*"
        '
        'txtStraße
        '
        Me.txtStraße.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStraße.Location = New System.Drawing.Point(18, 113)
        Me.txtStraße.Name = "txtStraße"
        Me.txtStraße.Size = New System.Drawing.Size(173, 20)
        Me.txtStraße.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Straße*"
        '
        'txtPLZ
        '
        Me.txtPLZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPLZ.Location = New System.Drawing.Point(223, 113)
        Me.txtPLZ.Name = "txtPLZ"
        Me.txtPLZ.Size = New System.Drawing.Size(86, 20)
        Me.txtPLZ.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(220, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Postleitzahl*"
        '
        'txtStadt
        '
        Me.txtStadt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStadt.Location = New System.Drawing.Point(433, 113)
        Me.txtStadt.Name = "txtStadt"
        Me.txtStadt.Size = New System.Drawing.Size(173, 20)
        Me.txtStadt.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(430, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Stadt*"
        '
        'txtLand
        '
        Me.txtLand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLand.Location = New System.Drawing.Point(17, 166)
        Me.txtLand.Name = "txtLand"
        Me.txtLand.Size = New System.Drawing.Size(173, 20)
        Me.txtLand.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Land*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(395, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Rechnungserstellung - Inhaber der Firma"
        '
        'txtExportPfad
        '
        Me.txtExportPfad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExportPfad.Location = New System.Drawing.Point(19, 257)
        Me.txtExportPfad.Name = "txtExportPfad"
        Me.txtExportPfad.Size = New System.Drawing.Size(418, 20)
        Me.txtExportPfad.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Rechnungsexport"
        '
        'btnExportPfad
        '
        Me.btnExportPfad.BackColor = System.Drawing.Color.Bisque
        Me.btnExportPfad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportPfad.Location = New System.Drawing.Point(714, 309)
        Me.btnExportPfad.Name = "btnExportPfad"
        Me.btnExportPfad.Size = New System.Drawing.Size(35, 24)
        Me.btnExportPfad.TabIndex = 20
        Me.btnExportPfad.Text = "..."
        Me.btnExportPfad.UseVisualStyleBackColor = False
        '
        'chkAutologin
        '
        Me.chkAutologin.AutoSize = True
        Me.chkAutologin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAutologin.Location = New System.Drawing.Point(18, 294)
        Me.chkAutologin.Name = "chkAutologin"
        Me.chkAutologin.Size = New System.Drawing.Size(116, 17)
        Me.chkAutologin.TabIndex = 21
        Me.chkAutologin.Text = "Autologin aktivieren"
        Me.ToolTip1.SetToolTip(Me.chkAutologin, "Aktiviert automatisches Login! " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Speichert allerdings das JTL Benutzerpasswort au" &
        "f dem Computer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ermöglicht beschleunigten Zugang zum Programm")
        Me.chkAutologin.UseVisualStyleBackColor = True
        '
        'chkLVWSaveColum
        '
        Me.chkLVWSaveColum.AutoSize = True
        Me.chkLVWSaveColum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLVWSaveColum.Location = New System.Drawing.Point(147, 294)
        Me.chkLVWSaveColum.Name = "chkLVWSaveColum"
        Me.chkLVWSaveColum.Size = New System.Drawing.Size(132, 17)
        Me.chkLVWSaveColum.TabIndex = 22
        Me.chkLVWSaveColum.Text = "Spalten selbst sortieren"
        Me.chkLVWSaveColum.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(207, 24)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Optionen Darstellung"
        '
        'btnOKSpeichern
        '
        Me.btnOKSpeichern.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOKSpeichern.BackColor = System.Drawing.Color.Bisque
        Me.btnOKSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOKSpeichern.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnOKSpeichern.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOKSpeichern.ImageKey = "accept.png"
        Me.btnOKSpeichern.ImageList = Me.ImageList1
        Me.btnOKSpeichern.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOKSpeichern.Location = New System.Drawing.Point(444, 472)
        Me.btnOKSpeichern.Name = "btnOKSpeichern"
        Me.btnOKSpeichern.Size = New System.Drawing.Size(200, 36)
        Me.btnOKSpeichern.TabIndex = 24
        Me.btnOKSpeichern.Text = "&Einstellungen speichern"
        Me.btnOKSpeichern.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        '
        'chkdvgArtikelAddRow
        '
        Me.chkdvgArtikelAddRow.AutoSize = True
        Me.chkdvgArtikelAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkdvgArtikelAddRow.Location = New System.Drawing.Point(285, 294)
        Me.chkdvgArtikelAddRow.Name = "chkdvgArtikelAddRow"
        Me.chkdvgArtikelAddRow.Size = New System.Drawing.Size(205, 17)
        Me.chkdvgArtikelAddRow.TabIndex = 25
        Me.chkdvgArtikelAddRow.Text = "Bestellansicht Zeilen selbst hinzufügen"
        Me.chkdvgArtikelAddRow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 419)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 24)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Google Maps Benzinpreis"
        '
        'txtGoogleMapsBenzinpreis
        '
        Me.txtGoogleMapsBenzinpreis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGoogleMapsBenzinpreis.Location = New System.Drawing.Point(19, 485)
        Me.txtGoogleMapsBenzinpreis.Name = "txtGoogleMapsBenzinpreis"
        Me.txtGoogleMapsBenzinpreis.Size = New System.Drawing.Size(61, 20)
        Me.txtGoogleMapsBenzinpreis.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 448)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Dieselpreis pro 100 km"
        '
        'chkSettingEinkaufsspalte
        '
        Me.chkSettingEinkaufsspalte.AutoSize = True
        Me.chkSettingEinkaufsspalte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSettingEinkaufsspalte.Location = New System.Drawing.Point(496, 294)
        Me.chkSettingEinkaufsspalte.Name = "chkSettingEinkaufsspalte"
        Me.chkSettingEinkaufsspalte.Size = New System.Drawing.Size(159, 17)
        Me.chkSettingEinkaufsspalte.TabIndex = 29
        Me.chkSettingEinkaufsspalte.Text = "Einkaufspalte nicht anzeigen"
        Me.chkSettingEinkaufsspalte.UseVisualStyleBackColor = True
        '
        'chkGoogleBenzinPreisAPI
        '
        Me.chkGoogleBenzinPreisAPI.AutoSize = True
        Me.chkGoogleBenzinPreisAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkGoogleBenzinPreisAPI.Location = New System.Drawing.Point(20, 464)
        Me.chkGoogleBenzinPreisAPI.Name = "chkGoogleBenzinPreisAPI"
        Me.chkGoogleBenzinPreisAPI.Size = New System.Drawing.Size(166, 17)
        Me.chkGoogleBenzinPreisAPI.TabIndex = 30
        Me.chkGoogleBenzinPreisAPI.Text = "Google Benzinpreis API aktiv?"
        Me.chkGoogleBenzinPreisAPI.UseVisualStyleBackColor = True
        '
        'chkLagerwarnmeldung
        '
        Me.chkLagerwarnmeldung.AutoSize = True
        Me.chkLagerwarnmeldung.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLagerwarnmeldung.Location = New System.Drawing.Point(20, 331)
        Me.chkLagerwarnmeldung.Name = "chkLagerwarnmeldung"
        Me.chkLagerwarnmeldung.Size = New System.Drawing.Size(177, 17)
        Me.chkLagerwarnmeldung.TabIndex = 31
        Me.chkLagerwarnmeldung.Text = "Lagerwarnmeldung anzeigen < 0"
        Me.chkLagerwarnmeldung.UseVisualStyleBackColor = True
        '
        'txtKassenKundenNummer
        '
        Me.txtKassenKundenNummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKassenKundenNummer.Location = New System.Drawing.Point(222, 166)
        Me.txtKassenKundenNummer.Name = "txtKassenKundenNummer"
        Me.txtKassenKundenNummer.Size = New System.Drawing.Size(146, 20)
        Me.txtKassenKundenNummer.TabIndex = 33
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(219, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Kassenkunden-Nr"
        '
        'frmEinstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 520)
        Me.Controls.Add(Me.txtKassenKundenNummer)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkLagerwarnmeldung)
        Me.Controls.Add(Me.chkGoogleBenzinPreisAPI)
        Me.Controls.Add(Me.chkSettingEinkaufsspalte)
        Me.Controls.Add(Me.txtGoogleMapsBenzinpreis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkdvgArtikelAddRow)
        Me.Controls.Add(Me.btnOKSpeichern)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkLVWSaveColum)
        Me.Controls.Add(Me.chkAutologin)
        Me.Controls.Add(Me.btnExportPfad)
        Me.Controls.Add(Me.txtExportPfad)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLand)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtStadt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPLZ)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtStraße)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVorname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFirma)
        Me.Controls.Add(Me.lblFirma)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEinstellungen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Einstellungen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFirma As System.Windows.Forms.Label
    Friend WithEvents txtFirma As System.Windows.Forms.TextBox
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStraße As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPLZ As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStadt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLand As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtExportPfad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExportPfad As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkAutologin As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkLVWSaveColum As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnOKSpeichern As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chkdvgArtikelAddRow As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGoogleMapsBenzinpreis As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSettingEinkaufsspalte As System.Windows.Forms.CheckBox
    Friend WithEvents chkGoogleBenzinPreisAPI As CheckBox
    Friend WithEvents chkLagerwarnmeldung As CheckBox
    Friend WithEvents txtKassenKundenNummer As TextBox
    Friend WithEvents Label13 As Label
End Class
