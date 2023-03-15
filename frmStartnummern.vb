Public Class frmStartnummern
    Dim bIsLoading As Boolean = True
    Public bIsVisible As Boolean = True

    Private Sub frmStartnummern_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call frmJTLRechnung.setMainWindowTitle("JTL Startnummern", Me)


        '# Kundennummern 
        If My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position).Length = 0 Then
            bIsLoading = False
            txtKundenPrefix.Text = frmJTLRechnung.clsDB.getStartNummern("cPrefix", "WHERE cName='Kunde'")
            bIsLoading = True
        Else
            txtKundenPrefix.Text = My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position)
        End If

        If My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position).Length = 0 Then
            bIsLoading = False
            txtKundenSuffix.Text = frmJTLRechnung.clsDB.getStartNummern("cSuffix", "WHERE cName='Kunde'")
            bIsLoading = True
        Else
            txtKundenSuffix.Text = My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position)
        End If

        '# Auftrag
        If My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position).Length = 0 Then
            bIsLoading = False
            txtAuftragPrefix.Text = frmJTLRechnung.clsDB.getStartNummern("cPrefix", "WHERE cName='Auftrag'")
            bIsLoading = True
        Else
            txtAuftragPrefix.Text = My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position)
        End If

        If My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position).Length = 0 Then
            bIsLoading = False
            txtAuftragSuffix.Text = frmJTLRechnung.clsDB.getStartNummern("cSuffix", "WHERE cName='Auftrag'")
            bIsLoading = True
        Else
            txtAuftragSuffix.Text = My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position)
        End If

        '# Laufende Nummer 
        txtAuftragLaufendeNr.Text = frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")
        txtKundenLaufendeNummer.Text = frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Kunde'")

        lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
        lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)
        bIsLoading = False

        If bIsVisible = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnNummernRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNummernRefresh.Click

        '# Kundennummer 
        txtKundenSuffix.Text = frmJTLRechnung.clsDB.getStartNummern("cSuffix", "WHERE cName='Kunde'")
        txtKundenPrefix.Text = frmJTLRechnung.clsDB.getStartNummern("cPrefix", "WHERE cName='Kunde'")

        '# Auftrag
        txtAuftragPrefix.Text = frmJTLRechnung.clsDB.getStartNummern("cPrefix", "WHERE cName='Auftrag'")
        txtAuftragSuffix.Text = frmJTLRechnung.clsDB.getStartNummern("cSuffix", "WHERE cName='Auftrag'")

        '# Laufende Nummer 
        txtAuftragLaufendeNr.Text = frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")
        txtKundenLaufendeNummer.Text = frmJTLRechnung.clsDB.getLftNummer("tLaufendeNummern", "WHERE cName='Kunde'")

        lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
        lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

    End Sub

    Private Sub txtKundenPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKundenPrefix.TextChanged
        If bIsLoading = False Then
            My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position) = txtKundenPrefix.Text
            My.Settings.Save()

            lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
            lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

        End If
    End Sub

    Private Sub txtKundenSuffix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKundenSuffix.TextChanged
        If bIsLoading = False Then
            My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position) = txtKundenSuffix.Text
            My.Settings.Save()

            lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
            lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

        End If
    End Sub

    Private Sub txtAuftragPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAuftragPrefix.TextChanged
        If bIsLoading = False Then
            My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position) = txtAuftragPrefix.Text
            My.Settings.Save()

            lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
            lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

        End If
    End Sub

    Private Sub txtAuftragSuffix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAuftragSuffix.TextChanged
        If bIsLoading = False Then
            My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position) = txtAuftragSuffix.Text
            My.Settings.Save()

            lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
            lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

        End If
    End Sub

    Private Sub txtKundenLaufendeNummer_TextChanged(sender As Object, e As EventArgs) Handles txtKundenLaufendeNummer.TextChanged

        lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
        lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

    End Sub

    Private Sub txtAuftragLaufendeNr_TextChanged(sender As Object, e As EventArgs) Handles txtAuftragLaufendeNr.TextChanged

        lblKundeBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), txtKundenLaufendeNummer.Text)
        lblAuftragBeispiel.Text = "Beispiel: " & frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), txtAuftragLaufendeNr.Text)

    End Sub
End Class