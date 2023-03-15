<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRabatt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRabatt))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtRabatt = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPreis = New System.Windows.Forms.Label()
        Me.lblPreisNeu = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMenge = New System.Windows.Forms.Label()
        Me.lblPreisGes = New System.Windows.Forms.Label()
        Me.lblPreisNeuGes = New System.Windows.Forms.Label()
        Me.lblRabattinEuro = New System.Windows.Forms.Label()
        Me.lblTitel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Moccasin
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageKey = "accept.png"
        Me.btnSave.ImageList = Me.ImageList1
        Me.btnSave.Location = New System.Drawing.Point(127, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 33)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&OK"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        '
        'txtRabatt
        '
        Me.txtRabatt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRabatt.Location = New System.Drawing.Point(16, 155)
        Me.txtRabatt.Name = "txtRabatt"
        Me.txtRabatt.Size = New System.Drawing.Size(61, 20)
        Me.txtRabatt.TabIndex = 3
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(13, 44)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(236, 42)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Name"
        '
        'lblPreis
        '
        Me.lblPreis.AutoSize = True
        Me.lblPreis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreis.Location = New System.Drawing.Point(13, 86)
        Me.lblPreis.Name = "lblPreis"
        Me.lblPreis.Size = New System.Drawing.Size(35, 13)
        Me.lblPreis.TabIndex = 7
        Me.lblPreis.Text = "Preis"
        '
        'lblPreisNeu
        '
        Me.lblPreisNeu.AutoSize = True
        Me.lblPreisNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreisNeu.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPreisNeu.Location = New System.Drawing.Point(13, 121)
        Me.lblPreisNeu.Name = "lblPreisNeu"
        Me.lblPreisNeu.Size = New System.Drawing.Size(73, 13)
        Me.lblPreisNeu.TabIndex = 8
        Me.lblPreisNeu.Text = "Neuer Preis"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "%"
        '
        'lblMenge
        '
        Me.lblMenge.AutoSize = True
        Me.lblMenge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenge.Location = New System.Drawing.Point(100, 86)
        Me.lblMenge.Name = "lblMenge"
        Me.lblMenge.Size = New System.Drawing.Size(45, 13)
        Me.lblMenge.TabIndex = 10
        Me.lblMenge.Text = "Menge"
        '
        'lblPreisGes
        '
        Me.lblPreisGes.AutoSize = True
        Me.lblPreisGes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreisGes.Location = New System.Drawing.Point(170, 86)
        Me.lblPreisGes.Name = "lblPreisGes"
        Me.lblPreisGes.Size = New System.Drawing.Size(35, 13)
        Me.lblPreisGes.TabIndex = 11
        Me.lblPreisGes.Text = "Preis"
        '
        'lblPreisNeuGes
        '
        Me.lblPreisNeuGes.AutoSize = True
        Me.lblPreisNeuGes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreisNeuGes.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPreisNeuGes.Location = New System.Drawing.Point(170, 121)
        Me.lblPreisNeuGes.Name = "lblPreisNeuGes"
        Me.lblPreisNeuGes.Size = New System.Drawing.Size(73, 13)
        Me.lblPreisNeuGes.TabIndex = 12
        Me.lblPreisNeuGes.Text = "Neuer Preis"
        '
        'lblRabattinEuro
        '
        Me.lblRabattinEuro.AutoSize = True
        Me.lblRabattinEuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRabattinEuro.Location = New System.Drawing.Point(108, 145)
        Me.lblRabattinEuro.Name = "lblRabattinEuro"
        Me.lblRabattinEuro.Size = New System.Drawing.Size(0, 24)
        Me.lblRabattinEuro.TabIndex = 13
        '
        'lblTitel
        '
        Me.lblTitel.AutoSize = True
        Me.lblTitel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitel.Location = New System.Drawing.Point(12, 9)
        Me.lblTitel.Name = "lblTitel"
        Me.lblTitel.Size = New System.Drawing.Size(159, 24)
        Me.lblTitel.TabIndex = 14
        Me.lblTitel.Text = "Rabatt festlegen"
        '
        'frmRabatt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 223)
        Me.Controls.Add(Me.lblTitel)
        Me.Controls.Add(Me.lblRabattinEuro)
        Me.Controls.Add(Me.lblPreisNeuGes)
        Me.Controls.Add(Me.lblPreisGes)
        Me.Controls.Add(Me.lblMenge)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPreisNeu)
        Me.Controls.Add(Me.lblPreis)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRabatt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRabatt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rabatt festlegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtRabatt As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPreis As System.Windows.Forms.Label
    Friend WithEvents lblPreisNeu As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMenge As System.Windows.Forms.Label
    Friend WithEvents lblPreisGes As System.Windows.Forms.Label
    Friend WithEvents lblPreisNeuGes As System.Windows.Forms.Label
    Friend WithEvents lblRabattinEuro As System.Windows.Forms.Label
    Friend WithEvents lblTitel As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
