Public Class frmKundenauswahl

    Private Sub txtSuchenKunde_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSuchenKunde.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSuchen.PerformClick()
        End If
    End Sub


    Private Sub btnAbrechen_Click(sender As Object, e As EventArgs) Handles btnAbrechen.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
        If lvwKunde.SelectedItems.Count > 0 Then
            Dim strDivider As String = " | "

            If lvwKunde.SelectedItems(0).SubItems(7).Text.Length > 0 Then
                strDivider = " | "
            Else
                strDivider = ""
            End If

            frmJTLRechnung.lblKundenData.Text = "Kunde: " & lvwKunde.SelectedItems(0).SubItems(7).Text & strDivider & lvwKunde.SelectedItems(0).SubItems(1).Text & " " & lvwKunde.SelectedItems(0).SubItems(2).Text & " | " & lvwKunde.SelectedItems(0).SubItems(3).Text & " | " & lvwKunde.SelectedItems(0).SubItems(5).Text & " " & lvwKunde.SelectedItems(0).SubItems(4).Text & " | " & lvwKunde.SelectedItems(0).SubItems(8).Text
            frmJTLRechnung.lblKundennummer.Text = lvwKunde.SelectedItems(0).SubItems(0).Text

            '# Aktuellen Datensatz kopieren in das unsichtbare Listview 
            frmJTLRechnung.setLvwKundenUpdate(lvwKunde.SelectedItems(0).Clone)
            frmJTLRechnung.txtSuchenKunde.Text = txtSuchenKunde.Text
        End If
        Me.Close()
    End Sub

    Private Sub frmKundenauswahl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call setLVWColumOrder(lvwKunde)
    End Sub

    Private Sub frmKundenauswahl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.lvw_colum_save.Item(My.Settings.mandant_position) = True Then
            Call getLVWColumOrder(lvwKunde)
        End If

        If frmJTLRechnung.clsDB.getDBConnect("") = False Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()

        End If

        frmJTLRechnung.setMainWindowTitle("Kundenauswahl", Me)

        If frmJTLRechnung.txtSuchenKunde.Text.Length > 0 Then
            txtSuchenKunde.Text = frmJTLRechnung.txtSuchenKunde.Text
            btnSuchen.PerformClick()
            Dim iCount As Integer = 0
            For iCount = 0 To lvwKunde.Items.Count - 1
                If lvwKunde.Items(iCount).Text = frmJTLRechnung.lblKundennummer.Text Then
                    lvwKunde.Items(iCount).Selected = True
                    Exit For
                End If
            Next
        End If
        lvwKunde.LargeImageList = ImageList1
    End Sub
    Private Sub AlleKundenAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmJTLRechnung.clsDB.getKunden_alle(lvwKunde)
    End Sub
    Private Sub lvwKunde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvwKunde.SelectedItems.Count > 0 Then
            Dim strFirma As String = ""
            If lvwKunde.SelectedItems(0).SubItems(7).Text.Length > 0 Then
                strFirma = lvwKunde.SelectedItems(0).SubItems(7).Text & " / "
            End If
            frmJTLRechnung.lblKundenData.Text = "Kunde: " & strFirma & lvwKunde.SelectedItems(0).SubItems(1).Text & " " & lvwKunde.SelectedItems(0).SubItems(2).Text & " aus " & lvwKunde.SelectedItems(0).SubItems(3).Text
        End If
    End Sub


    Private Sub NeuerKundeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuerKundeToolStripMenuItem1.Click
        Call frmJTLRechnung.setNewKunde()
    End Sub

    Private Sub RouteDistanzAbrufenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call frmJTLRechnung.getRoutenPlaner(lvwKunde)
    End Sub

    Private Sub AlleKundenAnzeigenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleKundenAnzeigenToolStripMenuItem.Click
        txtSuchenKunde.Enabled = False
        lvwKunde.Enabled = False
        lvwKunde.Items.Clear()
        frmJTLRechnung.clsDB.getKundenListe_suchen("", lvwKunde)
        txtSuchenKunde.Enabled = True
        lvwKunde.Enabled = True
    End Sub
 
    Private Sub RouteDistanzAbrufenToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RouteDistanzAbrufenToolStripMenuItem.Click
        frmJTLRechnung.getRoutenPlaner(lvwKunde)
    End Sub

    Private Sub btnSuchen_Click(sender As System.Object, e As System.EventArgs) Handles btnSuchen.Click
        txtSuchenKunde.Enabled = False
        btnOK.Enabled = False
        lvwKunde.Enabled = False
        lvwKunde.Items.Clear()
        frmJTLRechnung.clsDB.getKundenListe_suchen(txtSuchenKunde.Text, lvwKunde)
        txtSuchenKunde.Enabled = True
        lvwKunde.Enabled = True
    End Sub

    Private Sub lvwKunde_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwKunde.ColumnClick
        Call setSort(lvwKunde, e)
    End Sub

    Private Sub lvwKunde_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwKunde.DoubleClick
        If lvwKunde.SelectedItems.Count > 0 Then
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub lvwKunde_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles lvwKunde.SelectedIndexChanged
        If lvwKunde.SelectedItems.Count > 0 Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If
    End Sub

    Private Sub txtSuchenKunde_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSuchenKunde.TextChanged

    End Sub

    Private Sub btnNeuerKunde_Click(sender As System.Object, e As System.EventArgs) Handles btnNeuerKunde.Click
        Dim frmNeuerKunde As New frmKunde_neu
        frmNeuerKunde.lvwKunden = lvwKunde
        frmNeuerKunde.Show()
    End Sub

    Private Sub AlsKassenkundenFestlegenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlsKassenkundenFestlegenToolStripMenuItem.Click
        My.Settings.strKassenKundenID(My.Settings.mandant_position) = lvwKunde.SelectedItems(0).Text
        My.Settings.Save()
    End Sub
End Class