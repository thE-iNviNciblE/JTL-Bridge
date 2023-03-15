Public Class frmLagerverwaltung
    Dim bIsLoading As Boolean = True
    Private Sub btnLagerbestand_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLagerbestand_save.Click

        If txtMHD.Text = "" And lblMHDOption.Text = "1" Then
            MessageBox.Show("Bitte wählen Sie ein MHD Datum aus, ist erforderliches Feld")
            Exit Sub
        ElseIf IsNumeric(txtLagerbestandNeu.Text) = False Then
            MessageBox.Show("Lagerbestand muss eine Ganzzahl sein!", "Lagerbestand Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else

            If frmJTLRechnung.lvwArtikel_alle.SelectedItems.Count > 0 Then
                frmJTLRechnung.lvwArtikel_alle.SelectedItems(0).SubItems(5).Text = txtLagerbestandNeu.Text
            End If
            Dim strKArtikelID As String = ""

            ' Artikelnummer zu ArtikelID bei _load
            strKArtikelID = frmJTLRechnung.clsDB.getkArtikelIDbySKU(lblArtikelnummer.Text)

            If strKArtikelID.Length = 0 Then
                MessageBox.Show("Konnte keine ArtikelID aus Artelnummer ermitteln")
            End If
            ' Buchungsatz schreiben
            'frmJTLRechnung.clsDB.setLager_BuchungEingang(Me, lblkArtikel.Text)

            ' Lagerstand setzen
            If frmJTLRechnung.clsDB.setArtikel_Lagerbestand(strKArtikelID, txtLagerbestandNeu.Text) = True Then

                If frmJTLRechnung.clsDB.setArtikel_Lagerbestand_verfügbar(strKArtikelID, lblVerfügbarNeu.Text) = True Then
                    Me.Close()
                End If


            End If

        End If

    End Sub

    Private Sub txtLagerbestandNeu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLagerbestandNeu.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLagerbestand_save.PerformClick()
        End If
    End Sub

    Private Sub txtLagerbestandNeu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLagerbestandNeu.KeyPress

    End Sub

    Private Sub frmLagerverwaltung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call frmJTLRechnung.setMainWindowTitle("Lagerverwaltung", Me)
        Me.WindowState = FormWindowState.Maximized
        chkOptAddDelWarehouseTotal.Checked = My.Settings.chkWarehouseAddDelTotal.Item(My.Settings.mandant_position)

        lblkArtikel.Text = frmJTLRechnung.clsDB.getkArtikelIDbySKU(lblArtikelnummer.Text)
        lblMHDOption.Text = frmJTLRechnung.clsDB.getkArtikelMHDOptionbySKU(lblArtikelnummer.Text)
        lblVerfügbarALT.Text = frmJTLRechnung.clsDB.getLagerBestandVerfuegbar(lblkArtikel.Text)
        txtLagerbestand_alt.Text = frmJTLRechnung.clsDB.getLagerBestandLagerGes(lblkArtikel.Text)

        txtLagerbestandNeu.Text = txtLagerbestand_alt.Text
        lblVerfügbarNeu.Text = lblVerfügbarALT.Text
        txtKommentar.Text = "JTL Bridge Lagerverwaltung"

        If lblMHDOption.Text = "1" Then
            MonthCalendarMHD.Visible = True
            lblMHD.Visible = True
            txtMHD.Visible = True
            Label8.Visible = True
            txtChargenummer.Visible = True
            Label7.Visible = True
        Else
            MonthCalendarMHD.Visible = False
            lblMHD.Visible = False
            txtMHD.Visible = False
            Label8.Visible = False
            txtChargenummer.Visible = False
            Label7.Visible = False
        End If

        txtLageranzahl.Focus()
        bIsLoading = False
    End Sub

    Private Sub txtLageranzahl_plus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLageranzahl.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLagerbestand_save.PerformClick()
        End If
    End Sub
    Private Function setCalcLagerbestand()

        If IsNumeric(txtLageranzahl.Text) = False Then
            btnLagerbestand_save.Enabled = False
        Else
            btnLagerbestand_save.Enabled = True
            If chkOptAddDelWarehouseTotal.Checked = True Then
                txtLagerbestandNeu.Text = Convert.ToInt16(txtLagerbestand_alt.Text) + Convert.ToInt16(txtLageranzahl.Text)
                lblVerfügbarNeu.Text = Convert.ToInt16(lblVerfügbarALT.Text) + Convert.ToInt16(txtLageranzahl.Text)
            Else
                txtLagerbestandNeu.Text = txtLageranzahl.Text

                If txtLageranzahl.Text > txtLagerbestand_alt.Text Then
                    'lblVerfügbarNeu.Text = lblVerfügbarALT.Text - (Convert.ToInt16(txtLageranzahl.Text) - Convert.ToInt16(txtLagerbestand_alt.Text))
                    lblVerfügbarNeu.Text = lblVerfügbarALT.Text - (Convert.ToInt16(txtLagerbestand_alt.Text) - Convert.ToInt16(txtLageranzahl.Text))
                Else
                    lblVerfügbarNeu.Text = lblVerfügbarALT.Text - (Convert.ToInt16(txtLagerbestand_alt.Text) - Convert.ToInt16(txtLageranzahl.Text))
                End If


            End If

        End If
        Return True

    End Function

    Private Sub txtLageranzahl_plus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLageranzahl.TextChanged
        Try
            Call setCalcLagerbestand()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLagerbestand_alt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLagerbestand_alt.TextChanged
        If IsNumeric(txtLagerbestand_alt.Text) = False Then
            btnLagerbestand_save.Enabled = False
        Else
            btnLagerbestand_save.Enabled = True
        End If
    End Sub

    Private Sub txtLagerbestandNeu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLagerbestandNeu.TextChanged
        If IsNumeric(txtLagerbestandNeu.Text) = False Then
            btnLagerbestand_save.Enabled = False
        Else
            btnLagerbestand_save.Enabled = True
        End If
    End Sub

    Private Sub txtLageranzahl_plus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLageranzahl.KeyPress

    End Sub

    Private Sub btnAddWarehouse_Click(sender As System.Object, e As System.EventArgs) Handles btnAddWarehouse.Click
        Dim iWarehouseValue = Convert.ToInt16(txtLageranzahl.Text)
        txtLageranzahl.Text = iWarehouseValue + 1
    End Sub

    Private Sub btnDelWarehouse_Click(sender As System.Object, e As System.EventArgs) Handles btnDelWarehouse.Click
        Dim iWarehouseValue = Convert.ToInt16(txtLageranzahl.Text)
        txtLageranzahl.Text = iWarehouseValue - 1
    End Sub

    Private Sub chkOptAddDelWarehouseTotal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOptAddDelWarehouseTotal.CheckedChanged
        My.Settings.chkWarehouseAddDelTotal.Item(My.Settings.mandant_position) = chkOptAddDelWarehouseTotal.Checked
        My.Settings.Save()

        If bIsLoading = False Then
            Call setCalcLagerbestand()
        End If

    End Sub

    Private Sub MonthCalendarMHD_DateChanged(sender As Object, e As DateRangeEventArgs)
        txtMHD.Text = e.Start.ToShortDateString()
    End Sub
End Class