<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKunde_neu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKunde_neu))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVorname = New System.Windows.Forms.TextBox()
        Me.txtNachname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirma = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStraße = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPostleitzahl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNeuerKunde = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtLand = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefon = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkJTLSpeichern = New System.Windows.Forms.CheckBox()
        Me.rdbFrau = New System.Windows.Forms.RadioButton()
        Me.rdbHerr = New System.Windows.Forms.RadioButton()
        Me.rdbFirma = New System.Windows.Forms.RadioButton()
        Me.cmbKundengruppe = New System.Windows.Forms.ComboBox()
        Me.cmbLand = New System.Windows.Forms.ComboBox()
        Me.txtKundengruppe = New System.Windows.Forms.TextBox()
        Me.txtKundenNummer = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblBundesland = New System.Windows.Forms.Label()
        Me.txtBundesland = New System.Windows.Forms.TextBox()
        Me.lblKassenkunde = New System.Windows.Forms.Label()
        Me.chkKassenkunde = New System.Windows.Forms.CheckBox()
        Me.chkHändler = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkNewsletter = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbZahlungsart = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtVorname
        '
        Me.txtVorname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtVorname, "txtVorname")
        Me.txtVorname.Name = "txtVorname"
        '
        'txtNachname
        '
        Me.txtNachname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtNachname, "txtNachname")
        Me.txtNachname.Name = "txtNachname"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtFirma
        '
        Me.txtFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtFirma, "txtFirma")
        Me.txtFirma.Name = "txtFirma"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtStraße
        '
        Me.txtStraße.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtStraße, "txtStraße")
        Me.txtStraße.Name = "txtStraße"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtPostleitzahl
        '
        Me.txtPostleitzahl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtPostleitzahl, "txtPostleitzahl")
        Me.txtPostleitzahl.Name = "txtPostleitzahl"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtOrt
        '
        Me.txtOrt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtOrt, "txtOrt")
        Me.txtOrt.Name = "txtOrt"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'btnNeuerKunde
        '
        resources.ApplyResources(Me.btnNeuerKunde, "btnNeuerKunde")
        Me.btnNeuerKunde.BackColor = System.Drawing.Color.Bisque
        Me.btnNeuerKunde.ImageList = Me.ImageList1
        Me.btnNeuerKunde.Name = "btnNeuerKunde"
        Me.btnNeuerKunde.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        '
        'txtLand
        '
        Me.txtLand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtLand, "txtLand")
        Me.txtLand.Name = "txtLand"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtTelefon
        '
        Me.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtTelefon, "txtTelefon")
        Me.txtTelefon.Name = "txtTelefon"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtEmail, "txtEmail")
        Me.txtEmail.Name = "txtEmail"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'chkJTLSpeichern
        '
        resources.ApplyResources(Me.chkJTLSpeichern, "chkJTLSpeichern")
        Me.chkJTLSpeichern.Name = "chkJTLSpeichern"
        Me.chkJTLSpeichern.UseVisualStyleBackColor = True
        '
        'rdbFrau
        '
        resources.ApplyResources(Me.rdbFrau, "rdbFrau")
        Me.rdbFrau.Checked = True
        Me.rdbFrau.Name = "rdbFrau"
        Me.rdbFrau.TabStop = True
        Me.rdbFrau.UseVisualStyleBackColor = True
        '
        'rdbHerr
        '
        resources.ApplyResources(Me.rdbHerr, "rdbHerr")
        Me.rdbHerr.Name = "rdbHerr"
        Me.rdbHerr.UseVisualStyleBackColor = True
        '
        'rdbFirma
        '
        resources.ApplyResources(Me.rdbFirma, "rdbFirma")
        Me.rdbFirma.Name = "rdbFirma"
        Me.rdbFirma.UseVisualStyleBackColor = True
        '
        'cmbKundengruppe
        '
        Me.cmbKundengruppe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbKundengruppe, "cmbKundengruppe")
        Me.cmbKundengruppe.FormattingEnabled = True
        Me.cmbKundengruppe.Name = "cmbKundengruppe"
        '
        'cmbLand
        '
        Me.cmbLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbLand, "cmbLand")
        Me.cmbLand.FormattingEnabled = True
        Me.cmbLand.Name = "cmbLand"
        '
        'txtKundengruppe
        '
        Me.txtKundengruppe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtKundengruppe, "txtKundengruppe")
        Me.txtKundengruppe.Name = "txtKundengruppe"
        '
        'txtKundenNummer
        '
        Me.txtKundenNummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtKundenNummer, "txtKundenNummer")
        Me.txtKundenNummer.Name = "txtKundenNummer"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'lblBundesland
        '
        resources.ApplyResources(Me.lblBundesland, "lblBundesland")
        Me.lblBundesland.Name = "lblBundesland"
        '
        'txtBundesland
        '
        Me.txtBundesland.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtBundesland, "txtBundesland")
        Me.txtBundesland.Name = "txtBundesland"
        '
        'lblKassenkunde
        '
        resources.ApplyResources(Me.lblKassenkunde, "lblKassenkunde")
        Me.lblKassenkunde.Name = "lblKassenkunde"
        '
        'chkKassenkunde
        '
        resources.ApplyResources(Me.chkKassenkunde, "chkKassenkunde")
        Me.chkKassenkunde.Checked = True
        Me.chkKassenkunde.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKassenkunde.Name = "chkKassenkunde"
        Me.chkKassenkunde.UseVisualStyleBackColor = True
        '
        'chkHändler
        '
        resources.ApplyResources(Me.chkHändler, "chkHändler")
        Me.chkHändler.Name = "chkHändler"
        Me.chkHändler.UseVisualStyleBackColor = True
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'chkNewsletter
        '
        resources.ApplyResources(Me.chkNewsletter, "chkNewsletter")
        Me.chkNewsletter.Checked = True
        Me.chkNewsletter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNewsletter.Name = "chkNewsletter"
        Me.chkNewsletter.UseVisualStyleBackColor = True
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'cmbZahlungsart
        '
        Me.cmbZahlungsart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbZahlungsart, "cmbZahlungsart")
        Me.cmbZahlungsart.FormattingEnabled = True
        Me.cmbZahlungsart.Name = "cmbZahlungsart"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'frmKunde_neu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmbZahlungsart)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.chkNewsletter)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkHändler)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chkKassenkunde)
        Me.Controls.Add(Me.lblKassenkunde)
        Me.Controls.Add(Me.lblBundesland)
        Me.Controls.Add(Me.txtBundesland)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtKundenNummer)
        Me.Controls.Add(Me.cmbLand)
        Me.Controls.Add(Me.cmbKundengruppe)
        Me.Controls.Add(Me.rdbFirma)
        Me.Controls.Add(Me.rdbHerr)
        Me.Controls.Add(Me.rdbFrau)
        Me.Controls.Add(Me.chkJTLSpeichern)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTelefon)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtLand)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnNeuerKunde)
        Me.Controls.Add(Me.txtOrt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPostleitzahl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStraße)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFirma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVorname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtKundengruppe)
        Me.MaximizeBox = False
        Me.Name = "frmKunde_neu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirma As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStraße As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPostleitzahl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOrt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnNeuerKunde As System.Windows.Forms.Button
    Friend WithEvents txtLand As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefon As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkJTLSpeichern As System.Windows.Forms.CheckBox
    Friend WithEvents rdbFrau As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHerr As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFirma As System.Windows.Forms.RadioButton
    Friend WithEvents cmbKundengruppe As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLand As System.Windows.Forms.ComboBox
    Friend WithEvents txtKundengruppe As System.Windows.Forms.TextBox
    Friend WithEvents txtKundenNummer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lblBundesland As Label
    Friend WithEvents txtBundesland As TextBox
    Friend WithEvents lblKassenkunde As Label
    Friend WithEvents chkKassenkunde As CheckBox
    Friend WithEvents chkHändler As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkNewsletter As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbZahlungsart As ComboBox
    Friend WithEvents TextBox1 As TextBox
End Class
