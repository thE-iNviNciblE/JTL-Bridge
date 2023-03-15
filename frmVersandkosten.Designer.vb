<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersandkosten
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVersandkosten))
        Me.dgvVersandkosten = New System.Windows.Forms.DataGridView()
        Me.btnÜbernahme = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAbbrechen = New System.Windows.Forms.Button()
        Me.btnLöschen = New System.Windows.Forms.Button()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BruttoPreis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvVersandkosten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVersandkosten
        '
        Me.dgvVersandkosten.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVersandkosten.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVersandkosten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVersandkosten.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colPreis, Me.BruttoPreis, Me.ID})
        Me.dgvVersandkosten.Location = New System.Drawing.Point(12, 12)
        Me.dgvVersandkosten.Name = "dgvVersandkosten"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVersandkosten.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVersandkosten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVersandkosten.Size = New System.Drawing.Size(470, 178)
        Me.dgvVersandkosten.TabIndex = 0
        '
        'btnÜbernahme
        '
        Me.btnÜbernahme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnÜbernahme.BackColor = System.Drawing.Color.Moccasin
        Me.btnÜbernahme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnÜbernahme.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnÜbernahme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnÜbernahme.ImageKey = "accept.png"
        Me.btnÜbernahme.ImageList = Me.ImageList1
        Me.btnÜbernahme.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnÜbernahme.Location = New System.Drawing.Point(242, 195)
        Me.btnÜbernahme.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnÜbernahme.Name = "btnÜbernahme"
        Me.btnÜbernahme.Size = New System.Drawing.Size(116, 31)
        Me.btnÜbernahme.TabIndex = 73
        Me.btnÜbernahme.Text = "&Übernahme"
        Me.btnÜbernahme.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        Me.ImageList1.Images.SetKeyName(1, "cross.png")
        '
        'btnAbbrechen
        '
        Me.btnAbbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbbrechen.BackColor = System.Drawing.Color.Moccasin
        Me.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbbrechen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnAbbrechen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbbrechen.ImageKey = "cross.png"
        Me.btnAbbrechen.ImageList = Me.ImageList1
        Me.btnAbbrechen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbbrechen.Location = New System.Drawing.Point(366, 195)
        Me.btnAbbrechen.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnAbbrechen.Name = "btnAbbrechen"
        Me.btnAbbrechen.Size = New System.Drawing.Size(116, 31)
        Me.btnAbbrechen.TabIndex = 74
        Me.btnAbbrechen.Text = "&Abbrechen"
        Me.btnAbbrechen.UseVisualStyleBackColor = False
        '
        'btnLöschen
        '
        Me.btnLöschen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLöschen.BackColor = System.Drawing.Color.Moccasin
        Me.btnLöschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLöschen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnLöschen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLöschen.ImageKey = "cross.png"
        Me.btnLöschen.ImageList = Me.ImageList1
        Me.btnLöschen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLöschen.Location = New System.Drawing.Point(19, 195)
        Me.btnLöschen.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnLöschen.Name = "btnLöschen"
        Me.btnLöschen.Size = New System.Drawing.Size(116, 31)
        Me.btnLöschen.TabIndex = 75
        Me.btnLöschen.Text = "&Löschen"
        Me.btnLöschen.UseVisualStyleBackColor = False
        '
        'colName
        '
        Me.colName.HeaderText = "Versandkostenname"
        Me.colName.Name = "colName"
        Me.colName.Width = 200
        '
        'colPreis
        '
        Me.colPreis.HeaderText = "Netto Preis"
        Me.colPreis.Name = "colPreis"
        Me.colPreis.Width = 120
        '
        'BruttoPreis
        '
        Me.BruttoPreis.HeaderText = "Brutto Preis"
        Me.BruttoPreis.Name = "BruttoPreis"
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Width = 5
        '
        'frmVersandkosten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 238)
        Me.Controls.Add(Me.btnLöschen)
        Me.Controls.Add(Me.btnAbbrechen)
        Me.Controls.Add(Me.btnÜbernahme)
        Me.Controls.Add(Me.dgvVersandkosten)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVersandkosten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Versandkosten erzeugen"
        CType(Me.dgvVersandkosten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvVersandkosten As System.Windows.Forms.DataGridView
    Friend WithEvents btnÜbernahme As System.Windows.Forms.Button
    Friend WithEvents btnAbbrechen As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnLöschen As System.Windows.Forms.Button
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BruttoPreis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
