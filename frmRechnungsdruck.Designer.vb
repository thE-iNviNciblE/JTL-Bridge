<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRechnungsdruck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRechnungsdruck))
        Me.webYabeRechnung = New System.Windows.Forms.WebBrowser()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NeuToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ÖffnenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SpeichernToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.DruckenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AusschneidenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.KopierenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EinfügenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Bold = New System.Windows.Forms.ToolStripButton()
        Me.Hyperlink = New System.Windows.Forms.ToolStripButton()
        Me.Suchen = New System.Windows.Forms.ToolStripButton()
        Me.Bild = New System.Windows.Forms.ToolStripButton()
        Me.Redo = New System.Windows.Forms.ToolStripButton()
        Me.Undo = New System.Windows.Forms.ToolStripButton()
        Me.tabelle = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtVorlageQuellcode = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.btnBestellungADD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chkArchiv = New System.Windows.Forms.CheckBox()
        Me.DHTMLControll1 = New AxDHTMLEDLib.AxDHTMLEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.chkRechnungsdetailsVerkäuferAnzeigen = New System.Windows.Forms.CheckBox()
        Me.rdoJTLWaWiSave = New System.Windows.Forms.RadioButton()
        Me.rdoJTLWaWiNotSave = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DHTMLControll1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'webYabeRechnung
        '
        resources.ApplyResources(Me.webYabeRechnung, "webYabeRechnung")
        Me.webYabeRechnung.Name = "webYabeRechnung"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripButton, Me.ÖffnenToolStripButton, Me.SpeichernToolStripButton, Me.ToolStripButton1, Me.DruckenToolStripButton, Me.toolStripSeparator, Me.AusschneidenToolStripButton, Me.KopierenToolStripButton, Me.EinfügenToolStripButton, Me.toolStripSeparator2, Me.Bold, Me.Hyperlink, Me.Suchen, Me.Bild, Me.Redo, Me.Undo, Me.tabelle})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'NeuToolStripButton
        '
        Me.NeuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.NeuToolStripButton, "NeuToolStripButton")
        Me.NeuToolStripButton.Name = "NeuToolStripButton"
        '
        'ÖffnenToolStripButton
        '
        Me.ÖffnenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ÖffnenToolStripButton, "ÖffnenToolStripButton")
        Me.ÖffnenToolStripButton.Name = "ÖffnenToolStripButton"
        '
        'SpeichernToolStripButton
        '
        Me.SpeichernToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.SpeichernToolStripButton, "SpeichernToolStripButton")
        Me.SpeichernToolStripButton.Name = "SpeichernToolStripButton"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'DruckenToolStripButton
        '
        Me.DruckenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.DruckenToolStripButton, "DruckenToolStripButton")
        Me.DruckenToolStripButton.Name = "DruckenToolStripButton"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        resources.ApplyResources(Me.toolStripSeparator, "toolStripSeparator")
        '
        'AusschneidenToolStripButton
        '
        Me.AusschneidenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.AusschneidenToolStripButton, "AusschneidenToolStripButton")
        Me.AusschneidenToolStripButton.Name = "AusschneidenToolStripButton"
        '
        'KopierenToolStripButton
        '
        Me.KopierenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.KopierenToolStripButton, "KopierenToolStripButton")
        Me.KopierenToolStripButton.Name = "KopierenToolStripButton"
        '
        'EinfügenToolStripButton
        '
        Me.EinfügenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.EinfügenToolStripButton, "EinfügenToolStripButton")
        Me.EinfügenToolStripButton.Name = "EinfügenToolStripButton"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
        '
        'Bold
        '
        Me.Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Bold, "Bold")
        Me.Bold.Name = "Bold"
        '
        'Hyperlink
        '
        Me.Hyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Hyperlink, "Hyperlink")
        Me.Hyperlink.Name = "Hyperlink"
        '
        'Suchen
        '
        Me.Suchen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Suchen, "Suchen")
        Me.Suchen.Name = "Suchen"
        '
        'Bild
        '
        Me.Bild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Bild, "Bild")
        Me.Bild.Name = "Bild"
        '
        'Redo
        '
        Me.Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Redo, "Redo")
        Me.Redo.Name = "Redo"
        '
        'Undo
        '
        Me.Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Undo, "Undo")
        Me.Undo.Name = "Undo"
        '
        'tabelle
        '
        Me.tabelle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tabelle, "tabelle")
        Me.tabelle.Name = "tabelle"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtVorlageQuellcode
        '
        resources.ApplyResources(Me.txtVorlageQuellcode, "txtVorlageQuellcode")
        Me.txtVorlageQuellcode.Name = "txtVorlageQuellcode"
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'btnBestellungADD
        '
        resources.ApplyResources(Me.btnBestellungADD, "btnBestellungADD")
        Me.btnBestellungADD.BackColor = System.Drawing.Color.Moccasin
        Me.btnBestellungADD.ImageList = Me.ImageList1
        Me.btnBestellungADD.Name = "btnBestellungADD"
        Me.btnBestellungADD.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "printer.png")
        '
        'chkArchiv
        '
        resources.ApplyResources(Me.chkArchiv, "chkArchiv")
        Me.chkArchiv.Checked = True
        Me.chkArchiv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkArchiv.Name = "chkArchiv"
        Me.chkArchiv.UseVisualStyleBackColor = True
        '
        'DHTMLControll1
        '
        resources.ApplyResources(Me.DHTMLControll1, "DHTMLControll1")
        Me.DHTMLControll1.Name = "DHTMLControll1"
        Me.DHTMLControll1.OcxState = CType(resources.GetObject("DHTMLControll1.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.DHTMLControll1)
        Me.Panel1.Controls.Add(Me.webYabeRechnung)
        Me.Panel1.Controls.Add(Me.txtVorlageQuellcode)
        Me.Panel1.Name = "Panel1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'chkRechnungsdetailsVerkäuferAnzeigen
        '
        resources.ApplyResources(Me.chkRechnungsdetailsVerkäuferAnzeigen, "chkRechnungsdetailsVerkäuferAnzeigen")
        Me.chkRechnungsdetailsVerkäuferAnzeigen.Checked = True
        Me.chkRechnungsdetailsVerkäuferAnzeigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRechnungsdetailsVerkäuferAnzeigen.Name = "chkRechnungsdetailsVerkäuferAnzeigen"
        Me.chkRechnungsdetailsVerkäuferAnzeigen.UseVisualStyleBackColor = True
        '
        'rdoJTLWaWiSave
        '
        resources.ApplyResources(Me.rdoJTLWaWiSave, "rdoJTLWaWiSave")
        Me.rdoJTLWaWiSave.Checked = True
        Me.rdoJTLWaWiSave.Name = "rdoJTLWaWiSave"
        Me.rdoJTLWaWiSave.TabStop = True
        Me.rdoJTLWaWiSave.UseVisualStyleBackColor = True
        '
        'rdoJTLWaWiNotSave
        '
        resources.ApplyResources(Me.rdoJTLWaWiNotSave, "rdoJTLWaWiNotSave")
        Me.rdoJTLWaWiNotSave.Name = "rdoJTLWaWiNotSave"
        Me.rdoJTLWaWiNotSave.UseVisualStyleBackColor = True
        '
        'frmRechnungsdruck
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rdoJTLWaWiNotSave)
        Me.Controls.Add(Me.rdoJTLWaWiSave)
        Me.Controls.Add(Me.chkRechnungsdetailsVerkäuferAnzeigen)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.chkArchiv)
        Me.Controls.Add(Me.btnBestellungADD)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmRechnungsdruck"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DHTMLControll1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents webYabeRechnung As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NeuToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ÖffnenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpeichernToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DruckenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusschneidenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents KopierenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EinfügenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Bold As System.Windows.Forms.ToolStripButton
    Friend WithEvents Hyperlink As System.Windows.Forms.ToolStripButton
    Friend WithEvents Suchen As System.Windows.Forms.ToolStripButton
    Friend WithEvents Bild As System.Windows.Forms.ToolStripButton
    Friend WithEvents Redo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Undo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabelle As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtVorlageQuellcode As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnBestellungADD As System.Windows.Forms.Button
    Friend WithEvents chkArchiv As System.Windows.Forms.CheckBox
    Friend WithEvents DHTMLControll1 As AxDHTMLEDLib.AxDHTMLEdit
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents chkRechnungsdetailsVerkäuferAnzeigen As System.Windows.Forms.CheckBox
    Friend WithEvents rdoJTLWaWiSave As RadioButton
    Friend WithEvents rdoJTLWaWiNotSave As RadioButton
End Class
