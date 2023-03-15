Imports System.Security.Cryptography
Public Class frmLogin

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim clsCrypto As New clsCrypto
        Dim md5Hash As MD5 = MD5.Create()
        Dim strPasswordHash As String = clsCrypto.GetMd5Hash(md5Hash, txtPasswort.Text)

        If frmJTLRechnung.clsDB.getJTLLogin(txtUsername.Text, strPasswordHash) = False Then
            lblMessage.Text = "Benutzername oder Passwort falsch"
        Else
            My.Settings.login_username.Item(My.Settings.mandant_position) = txtUsername.Text
            My.Settings.Save()
            My.Settings.login_ok = True
            Me.Close()
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text &= strVersionsNummer
        txtUsername.Text = My.Settings.login_username.Item(My.Settings.mandant_position)

        '#################################################################
        '# >> Standardmandanten laden - eazybusiness Standarddatenbank
        '#################################################################
        Call frmJTLRechnung.clsDB.setMandantbyCombobox(cmbMandantenauswahl, False)

    End Sub

    Private Sub txtPasswort_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPasswort.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtUsername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtPasswort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPasswort.TextChanged
        If Convert.ToBoolean(My.Settings.login_automodus.Item(My.Settings.mandant_position)) = True Then
            My.Settings.login_passwort.Item(My.Settings.mandant_position) = txtPasswort.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub cmbMandantenauswahl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMandantenauswahl.SelectedIndexChanged
        My.Settings.mandant_position = frmJTLRechnung.clsDB.chkMandantPosition(frmJTLRechnung.clsDB.getMandantDatabaseByMandantName(cmbMandantenauswahl.Text))
        My.Settings.mandant_letzter_name = cmbMandantenauswahl.Text
        frmJTLRechnung.msgMaster.Text = "Es wurde das Datenbankprofil ' " & My.Settings.mandant_letzter_name & "' geladen!"
        Dim strCon2 As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
        If frmJTLRechnung.clsDB.getDBConnect(strCon2, False) = False Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
        End If

    End Sub

    Private Sub lblPasswortOptionen_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblPasswortOptionen.LinkClicked

    End Sub
End Class