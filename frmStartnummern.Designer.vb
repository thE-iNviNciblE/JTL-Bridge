<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartnummern
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartnummern))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblKundeBeispiel = New System.Windows.Forms.Label()
        Me.txtKundenSuffix = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKundenLaufendeNummer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKundenPrefix = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNummernRefresh = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblAuftragBeispiel = New System.Windows.Forms.Label()
        Me.txtAuftragSuffix = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAuftragLaufendeNr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAuftragPrefix = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblKundeBeispiel)
        Me.GroupBox1.Controls.Add(Me.txtKundenSuffix)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtKundenLaufendeNummer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtKundenPrefix)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Kundennummer"
        '
        'lblKundeBeispiel
        '
        Me.lblKundeBeispiel.AutoSize = True
        Me.lblKundeBeispiel.Location = New System.Drawing.Point(18, 82)
        Me.lblKundeBeispiel.Name = "lblKundeBeispiel"
        Me.lblKundeBeispiel.Size = New System.Drawing.Size(0, 13)
        Me.lblKundeBeispiel.TabIndex = 6
        '
        'txtKundenSuffix
        '
        Me.txtKundenSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKundenSuffix.Location = New System.Drawing.Point(299, 46)
        Me.txtKundenSuffix.Name = "txtKundenSuffix"
        Me.txtKundenSuffix.Size = New System.Drawing.Size(100, 20)
        Me.txtKundenSuffix.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Suffix"
        '
        'txtKundenLaufendeNummer
        '
        Me.txtKundenLaufendeNummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKundenLaufendeNummer.Location = New System.Drawing.Point(148, 46)
        Me.txtKundenLaufendeNummer.Name = "txtKundenLaufendeNummer"
        Me.txtKundenLaufendeNummer.Size = New System.Drawing.Size(100, 20)
        Me.txtKundenLaufendeNummer.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(145, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Laufende Nr."
        '
        'txtKundenPrefix
        '
        Me.txtKundenPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKundenPrefix.Location = New System.Drawing.Point(18, 46)
        Me.txtKundenPrefix.Name = "txtKundenPrefix"
        Me.txtKundenPrefix.Size = New System.Drawing.Size(100, 20)
        Me.txtKundenPrefix.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prefix"
        '
        'btnNummernRefresh
        '
        Me.btnNummernRefresh.BackColor = System.Drawing.Color.Bisque
        Me.btnNummernRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNummernRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNummernRefresh.Location = New System.Drawing.Point(255, 234)
        Me.btnNummernRefresh.Name = "btnNummernRefresh"
        Me.btnNummernRefresh.Size = New System.Drawing.Size(186, 23)
        Me.btnNummernRefresh.TabIndex = 1
        Me.btnNummernRefresh.Text = "&Startnummern abrufen"
        Me.btnNummernRefresh.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblAuftragBeispiel)
        Me.GroupBox2.Controls.Add(Me.txtAuftragSuffix)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAuftragLaufendeNr)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtAuftragPrefix)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 100)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Auftragsnummern"
        '
        'lblAuftragBeispiel
        '
        Me.lblAuftragBeispiel.AutoSize = True
        Me.lblAuftragBeispiel.Location = New System.Drawing.Point(21, 77)
        Me.lblAuftragBeispiel.Name = "lblAuftragBeispiel"
        Me.lblAuftragBeispiel.Size = New System.Drawing.Size(0, 13)
        Me.lblAuftragBeispiel.TabIndex = 7
        '
        'txtAuftragSuffix
        '
        Me.txtAuftragSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuftragSuffix.Location = New System.Drawing.Point(299, 46)
        Me.txtAuftragSuffix.Name = "txtAuftragSuffix"
        Me.txtAuftragSuffix.Size = New System.Drawing.Size(100, 20)
        Me.txtAuftragSuffix.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(296, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Suffix"
        '
        'txtAuftragLaufendeNr
        '
        Me.txtAuftragLaufendeNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuftragLaufendeNr.Location = New System.Drawing.Point(148, 46)
        Me.txtAuftragLaufendeNr.Name = "txtAuftragLaufendeNr"
        Me.txtAuftragLaufendeNr.Size = New System.Drawing.Size(100, 20)
        Me.txtAuftragLaufendeNr.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(145, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Laufende Nr."
        '
        'txtAuftragPrefix
        '
        Me.txtAuftragPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuftragPrefix.Location = New System.Drawing.Point(18, 46)
        Me.txtAuftragPrefix.Name = "txtAuftragPrefix"
        Me.txtAuftragPrefix.Size = New System.Drawing.Size(100, 20)
        Me.txtAuftragPrefix.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Prefix"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmStartnummern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 266)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnNummernRefresh)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStartnummern"
        Me.Text = "JTL Startnummern"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtKundenLaufendeNummer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKundenPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKundenSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNummernRefresh As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAuftragSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAuftragLaufendeNr As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAuftragPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblKundeBeispiel As System.Windows.Forms.Label
    Friend WithEvents lblAuftragBeispiel As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
