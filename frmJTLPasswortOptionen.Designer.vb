<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJTLPasswortOptionen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJTLPasswortOptionen))
        Me.btnOKSpeichern = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkKlartextPasswörter = New System.Windows.Forms.CheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
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
        Me.btnOKSpeichern.Location = New System.Drawing.Point(142, 112)
        Me.btnOKSpeichern.Name = "btnOKSpeichern"
        Me.btnOKSpeichern.Size = New System.Drawing.Size(124, 36)
        Me.btnOKSpeichern.TabIndex = 19
        Me.btnOKSpeichern.Text = "&Speichern"
        Me.btnOKSpeichern.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 52)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "JTL Passwörter in einer Version neuer als April 2013 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden mit einem Hash Vers" & _
    "chlüsselt. Verwenden" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie eine JTL Version früher, werden die Passwörter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "im Kla" & _
    "rtext gespeichert"
        '
        'chkKlartextPasswörter
        '
        Me.chkKlartextPasswörter.AutoSize = True
        Me.chkKlartextPasswörter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKlartextPasswörter.Location = New System.Drawing.Point(15, 79)
        Me.chkKlartextPasswörter.Name = "chkKlartextPasswörter"
        Me.chkKlartextPasswörter.Size = New System.Drawing.Size(169, 17)
        Me.chkKlartextPasswörter.TabIndex = 21
        Me.chkKlartextPasswörter.Text = "Klartext Passwörter verwenden"
        Me.chkKlartextPasswörter.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        '
        'frmJTLPasswortOptionen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 160)
        Me.Controls.Add(Me.chkKlartextPasswörter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOKSpeichern)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJTLPasswortOptionen"
        Me.Text = "JTL Passwortoptionen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOKSpeichern As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkKlartextPasswörter As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
