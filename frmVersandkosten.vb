Public Class frmVersandkosten
    Dim bclose As Boolean = False
    Dim bNewRow As Boolean = False

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVersandkosten.CellContentClick

    End Sub

    Private Sub dgvVersandkosten_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVersandkosten.CellContentDoubleClick
        addToMainForm()
    End Sub

    Private Sub dgvVersandkosten_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVersandkosten.CellEndEdit
        Try
            If bclose = False Then

                '# Anlegen der Versandkosten in der Datenbank
                If bNewRow = True And dgvVersandkosten.Rows(e.RowIndex).Cells(3).Value = "" Then
                    frmJTLRechnung.clsDB.setVersandkostenPosition_create(dgvVersandkosten.Rows(e.RowIndex).Cells(0).Value, dgvVersandkosten.Rows(e.RowIndex).Cells(1).Value, dgvVersandkosten.Rows(e.RowIndex).Cells(2).Value)
                    Dim iVersandkostenMaxID As Integer = frmJTLRechnung.clsDB.getJTLID_MAX("cubss_versandkosten", "kVersandkosten")
                    iVersandkostenMaxID -= 1
                    frmJTLRechnung.clsDB.setVersandkostenPosition_read(iVersandkostenMaxID, dgvVersandkosten, False, e.RowIndex)

                Else
                    frmJTLRechnung.clsDB.setVersandkostenPosition_update(dgvVersandkosten.Rows(e.RowIndex).Cells(0).Value, dgvVersandkosten.Rows(e.RowIndex).Cells(1).Value, dgvVersandkosten.Rows(e.RowIndex).Cells(2).Value, dgvVersandkosten.Rows(e.RowIndex).Cells(3).Value)
                End If

                ' dgvVersandkosten.Rows.GetRowState()
                'If My.Settings.dgvVersandkostenName.Count <= e.RowIndex Then
                '    My.Settings.dgvVersandkostenName.Insert(e.RowIndex, "")
                '    My.Settings.dgvVersandkostenPreis.Insert(e.RowIndex, "")
                'End If

                'If e.ColumnIndex = 0 Then
                '    My.Settings.dgvVersandkostenName.Item(e.RowIndex) = dgvVersandkosten.Rows(e.RowIndex).Cells(0).Value
                'ElseIf e.ColumnIndex = 1 Then
                '    My.Settings.dgvVersandkostenPreis.Item(e.RowIndex) = dgvVersandkosten.Rows(e.RowIndex).Cells(1).Value
                'End If
                My.Settings.Save()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei dgvVersandkosten.CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub dgvVersandkosten_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvVersandkosten.RowsAdded
        ' MessageBox.Show("test")
        bNewRow = True
    End Sub
    
    Private Sub btnAbbrechen_Click(sender As System.Object, e As System.EventArgs) Handles btnAbbrechen.Click
        bclose = True
        Me.Close()
    End Sub

    Private Sub btnÜbernahme_Click(sender As System.Object, e As System.EventArgs) Handles btnÜbernahme.Click
        addToMainForm()
    End Sub

    '###################################################
    '# >> addToMainForm
    '# Bestellung anlegen - Zum Hauptformular hinzufügen
    '###################################################
    Private Function addToMainForm() As Boolean
        Try
            Dim iInsertCountingRow As Integer = 1
            If My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position) = False Then
                frmJTLRechnung.dgvArtikel.Rows.Add()
                iInsertCountingRow = 1
            Else
                iInsertCountingRow = 0
            End If

        
            frmJTLRechnung.dgvArtikel.Rows(frmJTLRechnung.dgvArtikel.Rows.Count - 1).Cells(4).Value = dgvVersandkosten.SelectedRows(0).Cells(0).Value
            frmJTLRechnung.dgvArtikel.Rows(frmJTLRechnung.dgvArtikel.Rows.Count - 1).Cells(5).Value = dgvVersandkosten.SelectedRows(0).Cells(1).Value
            frmJTLRechnung.dgvArtikel.Rows(frmJTLRechnung.dgvArtikel.Rows.Count - 1).Cells(6).Value = dgvVersandkosten.SelectedRows(0).Cells(2).Value
            Me.Close()
            My.Settings.Save()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei addToMainForm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try

    End Function
    Private Sub frmVersandkosten_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'DgvVersandkosten.Rows.Add()
        Try
            Dim iLoop As Integer = 0

            Me.Text &= " " & strVersionsNummer

            'For iLoop = 0 To My.Settings.dgvVersandkostenName.Count - 1

            '    If Not iLoop = My.Settings.dgvVersandkostenName.Count Then
            '        dgvVersandkosten.Rows.Add()
            '    End If

            '    dgvVersandkosten.Rows(iLoop).Cells(0).Value = My.Settings.dgvVersandkostenName.Item(iLoop)
            '    dgvVersandkosten.Rows(iLoop).Cells(1).Value = My.Settings.dgvVersandkostenPreis.Item(iLoop)
            'Next
            frmJTLRechnung.clsDB.setVersandkostenPosition_read(1, dgvVersandkosten, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei Form_Load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub


    Private Sub btnLöschen_Click(sender As System.Object, e As System.EventArgs) Handles btnLöschen.Click
        With dgvVersandkosten
            If .SelectedRows.Count > 0 Then
                For I As Integer = .SelectedRows.Count - 1 To 0 Step -1
                    frmJTLRechnung.clsDB.setVersandkostenPosition_delete(.Rows(.SelectedRows(I).Index).Cells(3).Value)
                    .Rows.RemoveAt(.SelectedRows(I).Index)
                Next
            End If
        End With
    End Sub
End Class