Public Class frmEinstellungen

    Private Sub frmEinstellungen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call frmJTLRechnung.setMainWindowTitle("Programmeinstellungen", Me)

        txtFirma.Text = My.Settings.absender_firma.Item(My.Settings.mandant_position)
        txtVorname.Text = My.Settings.absender_vorname.Item(My.Settings.mandant_position)
        txtNachname.Text = My.Settings.absender_nachname.Item(My.Settings.mandant_position)
        txtStraße.Text = My.Settings.absender_straße.Item(My.Settings.mandant_position)
        txtPLZ.Text = My.Settings.absender_plz.Item(My.Settings.mandant_position)
        txtStadt.Text = My.Settings.absender_ort.Item(My.Settings.mandant_position)
        txtLand.Text = My.Settings.absender_land.Item(My.Settings.mandant_position)
        txtExportPfad.Text = My.Settings.export_pfad.Item(My.Settings.mandant_position)
        chkAutologin.Checked = Convert.ToBoolean(My.Settings.login_automodus.Item(My.Settings.mandant_position))
        chkLVWSaveColum.Checked = Convert.ToBoolean(My.Settings.lvw_colum_save.Item(My.Settings.mandant_position))
        chkdvgArtikelAddRow.Checked = Convert.ToBoolean(My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position))
        txtGoogleMapsBenzinpreis.Text = My.Settings.txtBenzinpreis.Item(My.Settings.mandant_position)
        chkSettingEinkaufsspalte.Checked = My.Settings.chkEinkaufsspalte
        chkGoogleBenzinPreisAPI.Checked = My.Settings.bGoogleBenzinpreis.Item(My.Settings.mandant_position)

        Try
            chkLagerwarnmeldung.Checked = My.Settings.chkLagerwarnmeldung.Item(My.Settings.mandant_position)
        Catch ex As Exception
            My.Settings.chkLagerwarnmeldung.Insert(My.Settings.mandant_position, "true")
            chkLagerwarnmeldung.Checked = My.Settings.chkLagerwarnmeldung.Item(My.Settings.mandant_position)
        End Try

        Try
            txtKassenKundenNummer.Text = My.Settings.strKassenKundenID.Item(My.Settings.mandant_position)
        Catch ex As Exception
            My.Settings.strKassenKundenID.Insert(My.Settings.mandant_position, "")
            txtKassenKundenNummer.Text = My.Settings.strKassenKundenID.Item(My.Settings.mandant_position)
        End Try

    End Sub
 

    Private Sub txtFirma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirma.TextChanged
        My.Settings.absender_firma.Item(My.Settings.mandant_position) = txtFirma.Text
        My.Settings.Save()
    End Sub

    Private Sub txtVorname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVorname.TextChanged
        My.Settings.absender_vorname.Item(My.Settings.mandant_position) = txtVorname.Text
        My.Settings.Save()
    End Sub

    Private Sub txtNachname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNachname.TextChanged
        My.Settings.absender_nachname.Item(My.Settings.mandant_position) = txtNachname.Text
        My.Settings.Save()
    End Sub

    Private Sub txtStraße_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStraße.TextChanged
        My.Settings.absender_straße.Item(My.Settings.mandant_position) = txtStraße.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLZ.TextChanged
        My.Settings.absender_plz.Item(My.Settings.mandant_position) = txtPLZ.Text
        My.Settings.Save()
    End Sub

    Private Sub txtStadt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStadt.TextChanged
        My.Settings.absender_ort.Item(My.Settings.mandant_position) = txtStadt.Text
        My.Settings.Save()
    End Sub

    Private Sub txtLand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLand.TextChanged
        My.Settings.absender_land.Item(My.Settings.mandant_position) = txtLand.Text
        My.Settings.Save()
    End Sub

    Private Sub btnExportPfad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportPfad.Click

        If txtExportPfad.Text.Length > 0 Then
            FolderBrowserDialog1.SelectedPath = txtExportPfad.Text
        End If

        FolderBrowserDialog1.ShowNewFolderButton = True
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtExportPfad.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.export_pfad.Item(My.Settings.mandant_position) = txtExportPfad.Text
        End If
    End Sub

    Private Sub chkAutologin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutologin.CheckedChanged
        If chkAutologin.Checked = False Then
            My.Settings.login_passwort.Item(My.Settings.mandant_position) = ""
        End If

        My.Settings.login_automodus.Item(My.Settings.mandant_position) = chkAutologin.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkLVWSaveColum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLVWSaveColum.CheckedChanged
        My.Settings.lvw_colum_save.Item(My.Settings.mandant_position) = chkLVWSaveColum.Checked
        My.Settings.Save()
    End Sub

    Private Sub btnOKSpeichern_Click(sender As System.Object, e As System.EventArgs) Handles btnOKSpeichern.Click

        If txtVorname.Text = "" Then
            MessageBox.Show("Bitte einen Vornamen eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVorname.Focus()
            Exit Sub
        End If
        If txtNachname.Text = "" Then
            MessageBox.Show("Bitte einen Nachnamen eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNachname.Focus()
            Exit Sub
        End If
        If txtStraße.Text = "" Then
            MessageBox.Show("Bitte eine Straße eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStraße.Focus()
            Exit Sub
        End If
        If txtStadt.Text = "" Then
            MessageBox.Show("Bitte eine Stadt eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStadt.Focus()
            Exit Sub
        End If
        If txtPLZ.Text = "" Then
            MessageBox.Show("Bitte einen Postleitzahl eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPLZ.Focus()
            Exit Sub
        End If
        If txtLand.Text = "" Then
            MessageBox.Show("Bitte ein Land eingeben!", "Vorname fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLand.Focus()
            Exit Sub
        End If

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub chkdvgArtikelAddRow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkdvgArtikelAddRow.CheckedChanged
        My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position) = chkdvgArtikelAddRow.Checked
        frmJTLRechnung.dgvArtikel.AllowUserToAddRows = chkdvgArtikelAddRow.Checked
        My.Settings.Save()
    End Sub

    Private Sub txtGoogleMapsBenzinpreis_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGoogleMapsBenzinpreis.TextChanged
        My.Settings.txtBenzinpreis.Item(My.Settings.mandant_position) = txtGoogleMapsBenzinpreis.Text
        My.Settings.Save()
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub lblFirma_Click(sender As System.Object, e As System.EventArgs) Handles lblFirma.Click

    End Sub

    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub chkSettingEinkaufsspalte_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSettingEinkaufsspalte.CheckedChanged
        My.Settings.chkEinkaufsspalte = chkSettingEinkaufsspalte.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkGoogleBenzinPreisAPI_CheckedChanged(sender As Object, e As EventArgs) Handles chkGoogleBenzinPreisAPI.CheckedChanged
        My.Settings.bGoogleBenzinpreis.Item(My.Settings.mandant_position) = chkGoogleBenzinPreisAPI.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkLagerwarnmeldung_CheckedChanged(sender As Object, e As EventArgs) Handles chkLagerwarnmeldung.CheckedChanged
        My.Settings.chkLagerwarnmeldung.Item(My.Settings.mandant_position) = chkLagerwarnmeldung.Checked
        My.Settings.Save()
    End Sub

    Private Sub txtKassenKundenNummer_TextChanged(sender As Object, e As EventArgs) Handles txtKassenKundenNummer.TextChanged
        My.Settings.strKassenKundenID(My.Settings.mandant_position) = txtKassenKundenNummer.Text
        My.Settings.Save()
    End Sub
End Class