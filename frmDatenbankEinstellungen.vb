Public Class frmDatenbankEinstellungen
    Dim iCurrent As Integer = 0
    Dim bConnected As Boolean = False
    Dim bIsLoading As Boolean = False
    Public bErrorLoading As Boolean = False
    Dim iEazybusinessProfilID As Integer = -1



    'Dim clsDB As New clsDatenbank

    Private Sub frmDatenbankEinstellungen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Not My.Settings.mandant_position = -1 Then
                msgMaster.Text = "Bei Einstellung: " & My.Settings.mandant_letzter_name & " (" & My.Settings.mandant_position & ")"
            Else
                msgMaster.Text = "Bei Einstellung: Keine Einstellungen gefunden!"
            End If

            '# Laden der Standarddatenbank
            iEazybusinessProfilID = frmJTLRechnung.getMySettingsPositionByDatabase("eazybusiness")

            Call frmJTLRechnung.setMainWindowTitle("Datenbankverbindung", Me)

            If Not My.Settings.mandant_position = -1 Then

                '# Aktuelle Position auslesen aus dem Hauptformular 
                '# entspricht mandant_letzter_name 
                iCurrent = My.Settings.mandant_position

                '# Daten in Textfelder eintragen 
                txtServerName.Text = My.Settings.db_server.Item(iCurrent).ToString
                txtUsername.Text = My.Settings.db_username.Item(iCurrent).ToString
                txtPasswort.Text = My.Settings.db_passwort.Item(iCurrent).ToString
                txtDatenbank.Text = My.Settings.db_datenbankname.Item(iCurrent).ToString

                Dim strCon As String = "server=" & My.Settings.db_server.Item(iCurrent).ToString & ";uid=" & My.Settings.db_username.Item(iCurrent).ToString & ";pwd=" & My.Settings.db_passwort.Item(iCurrent).ToString & ";database=" & My.Settings.db_datenbankname.Item(iCurrent).ToString & ";"

                '# Datenbankverbindung Testen 
                If frmJTLRechnung.clsDB.getDBConnect(strCon) = True Then
                    '# Mandanten in die Combobox übertragen 
                    Call frmJTLRechnung.clsDB.setMandantbyCombobox(cmbMandant, True)
                    bConnected = True
                Else
                    '# Keine Datenbankverbindung vorhanden
                    cmbMandant.Visible = False
                    Label5.Visible = False

                End If

            Else
                '# Laden der Standard Datenbank
                iCurrent = frmJTLRechnung.getMySettingsPositionByDatabase("eazybusiness")
                If Not iCurrent = -1 Then
                    MessageBox.Show("Fehler bei der Profilauswahl: benutze Standardprofil!", "Standardprofil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    MainStatus.Text = "Fehler bei der Profilauswahl: benutze Standardprofil!"
                    txtServerName.Text = My.Settings.db_server.Item(iCurrent).ToString
                    txtUsername.Text = My.Settings.db_username.Item(iCurrent).ToString
                    txtPasswort.Text = My.Settings.db_passwort.Item(iCurrent).ToString
                    txtDatenbank.Text = My.Settings.db_datenbankname.Item(iCurrent).ToString
                Else
                    ''# Initalisieren der Settings
                    'If MessageBox.Show("Die Programmsettings werden neu geschrieben, einige überschrieben möchten Sie fortfahren?", "Programmeinstellungen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '    Call frmMain.setSettingsInit(My.Settings.mandant_position)
                    '    iCurrent = 0
                    'End If
                    MainStatus.Text = "Es wurde noch kein Datenbankprofil gefunden - keine Datenbankverbindung möglich"
                End If
            End If

        Catch ex As Exception
            If MessageBox.Show("Fehler bei Load: " & ex.Message & vbCrLf & "Datenbank Einstellungen neuschreiben?", "frmDatenbankEinstellungen_Load", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Call frmJTLRechnung.setSettingsDelete()
            End If
        End Try
    End Sub

    Private Sub btnDBTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBTest.Click

        Dim strCon As String = "server=" & txtServerName.Text & ";uid=" & txtUsername.Text & ";pwd=" & txtPasswort.Text & ";database=" & txtDatenbank.Text & ";"
        Dim strFilename As String = ""
        Try

            If frmJTLRechnung.clsDB.getDBConnect(strCon, False) = True Then

                If Not txtDatenbank.Text = "eazybusiness" Then
                    Dim iEazybusinessProfil As Integer = frmJTLRechnung.getMySettingsPositionByDatabase("eazybusiness")

                    Dim strCon2 As String = "server=" & My.Settings.db_server.Item(iEazybusinessProfil) & ";uid=" & My.Settings.db_username.Item(iEazybusinessProfil) & ";pwd=" & My.Settings.db_passwort.Item(iEazybusinessProfil) & ";database=" & My.Settings.db_datenbankname.Item(iEazybusinessProfil) & ";"
                    frmJTLRechnung.clsDB.getDBConnect(strCon2, True)
                End If

                '#################################################################################
                '# >> Settings hinzufügen, wenn noch nicht vorhanden 
                '#################################################################################

                Dim iTempMandantPosition As Integer = My.Settings.mandant_position ' neu
                My.Settings.mandant_position = frmJTLRechnung.clsDB.chkMandantPosition(txtDatenbank.Text)
                Call frmJTLRechnung.setSettingsInit(My.Settings.mandant_position)

                '# Wenn nicht gleich, wird neu hinzugefügt 
                If Not iTempMandantPosition = My.Settings.mandant_position Then
                    'My.Settings.db_server.Insert(My.Settings.mandant_position, txtServerName.Text)
                    'My.Settings.db_datenbankname.Insert(My.Settings.mandant_position, txtDatenbank.Text)
                    'My.Settings.db_username.Insert(My.Settings.mandant_position, txtUsername.Text)
                    'My.Settings.db_passwort.Insert(My.Settings.mandant_position, txtPasswort.Text)

                    My.Settings.db_server.Item(My.Settings.mandant_position) = txtServerName.Text
                    My.Settings.db_datenbankname.Item(My.Settings.mandant_position) = txtDatenbank.Text
                    My.Settings.db_username.Item(My.Settings.mandant_position) = txtUsername.Text
                    My.Settings.db_passwort.Item(My.Settings.mandant_position) = txtPasswort.Text

                    '##############################################################################
                    '# >> Installation der Tabellen für die neue Datenbankverbindung 
                    '##############################################################################

                Else
                    '# Update der Settings 
                    My.Settings.db_server.Item(My.Settings.mandant_position) = txtServerName.Text
                    My.Settings.db_datenbankname.Item(My.Settings.mandant_position) = txtDatenbank.Text
                    My.Settings.db_username.Item(My.Settings.mandant_position) = txtUsername.Text
                    My.Settings.db_passwort.Item(My.Settings.mandant_position) = txtPasswort.Text
                End If

                My.Settings.Save()

                '# Datenbankprofil in Combobox neuladen und auf neusten Eintrag setzen 
                My.Settings.mandant_letzter_name = frmJTLRechnung.clsDB.getMandantbyDBName(txtDatenbank.Text)
                'frmMain.clsDB.setMandantbyCombobox(frmMain.cmbMandant)
                bConnected = True

                '#############################################################################
                '# >> Alle Mandanten durchgehen bis zum letzten Mandanten 
                '#############################################################################

                '# Problem bei keinem Mandanten 
                Dim strMandant As String = cmbMandant.Text
                If strMandant.Length < 0 Then
                    strMandant = txtDatenbank.Text
                End If

                '# Problem bei keinem Mandanten 
                'Dim iMandantPosition As Integer = cmbMandant.Items.Count
                'If cmbMandant.Items.Count = 0 Then

                'End If

                '# Datenbank Update
                If setUpdateDatabase(txtDatenbank.Text, False) = False Then
                    MessageBox.Show("Fehler beim Datenbankupdate", "btnDBTest", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                '# Wenn letzter Mandant ausgewählt Fenster schließen 
                If cmbMandant.SelectedIndex = cmbMandant.Items.Count Then
                    MessageBox.Show("Verbindung von " & strMandant & " wurde erfolgreich gespeichert", "Datenbankverbindung " & txtDatenbank.Text & " gespeichert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    If MessageBox.Show("Verbindung von " & strMandant & " wurde erfolgreich gespeichert" & vbCrLf & vbCrLf & "Möchten Sie den zum nächsten möglichen Mandanten wechseln, um die Datenbankeinstellungen zu speichern?", "Datenbankverbindung " & txtDatenbank.Text & " gespeichert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If cmbMandant.Items.Count = 0 And Not cmbMandant.Text = "" Then
                            cmbMandant.SelectedIndex = cmbMandant.SelectedIndex + 1
                        Else
                            Call frmJTLRechnung.clsDB.setMandantbyCombobox(cmbMandant, True)
                        End If
                    Else

                        Me.Close()
                    End If
                End If

            Else
                MessageBox.Show("Verbindung NICHT erfolgreich", "Datenbankverbindung fehlerhaft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'My.Settings.db_server.RemoveAt(iCurrent)
                'My.Settings.db_datenbankname.RemoveAt(iCurrent)
                'My.Settings.db_username.RemoveAt(iCurrent)
                'My.Settings.db_passwort.RemoveAt(iCurrent)
            End If
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "btnDBTest_click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMandant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMandant.SelectedIndexChanged
        Dim strDatabase As String = ""
        '# Einstellungsposition anzeigen + Name
        msgMaster.Text = "Bei Einstellung: " & cmbMandant.Text & " (" & My.Settings.mandant_position & ")"

        If bConnected = True And bIsLoading = False Then

            '# Laden der aktuellen Settingspostion mittels des aktuellen Datenbanknamens mit dem Zwischenschritt über den Mandantennamen
            strDatabase = frmJTLRechnung.clsDB.getMandantDatabaseByMandantName(cmbMandant.Text)
            My.Settings.mandant_position = frmJTLRechnung.getMySettingsPositionByDatabase(strDatabase)
            msgMaster.Text = "Bei Einstellung: " & cmbMandant.Text & " (" & My.Settings.mandant_position & ")"

            '# Fehler es wird das aktuelle Profil nicht gefunden - noch nicht angelegt 
            If My.Settings.mandant_position = -1 Then
                '# Lade das Standarddatenbank Profil
                My.Settings.mandant_position = frmJTLRechnung.getMySettingsPositionByDatabase("eazybusiness")
                Dim iCurrent As Integer = My.Settings.mandant_position
                msgMaster.Text = "Bei Einstellung: Standard 'eazybusiness' (" & My.Settings.mandant_position & ")"

                If My.Settings.mandant_position = -1 Then
                    MessageBox.Show("Es wird empfohlen die Standarddatenbank eazybusiness anzulegen", "cmbMandant_selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'txtServerName.Text = My.Settings.db_server.Item(iCurrent).ToString
                'txtUsername.Text = My.Settings.db_username.Item(iCurrent).ToString
                'txtPasswort.Text = My.Settings.db_passwort.Item(iCurrent).ToString
                'txtDatenbank.Text = My.Settings.db_datenbankname.Item(iCurrent).ToString
                txtServerName.Text = ""
                txtUsername.Text = ""
                txtPasswort.Text = ""
                txtDatenbank.Text = strDatabase
            Else
                '# Anzeigen der aktuellen Einstellungen 
                txtServerName.Text = My.Settings.db_server.Item(My.Settings.mandant_position).ToString
                txtUsername.Text = My.Settings.db_username.Item(My.Settings.mandant_position).ToString
                txtPasswort.Text = My.Settings.db_passwort.Item(My.Settings.mandant_position).ToString
                txtDatenbank.Text = My.Settings.db_datenbankname.Item(My.Settings.mandant_position).ToString
            End If
        End If
    End Sub

    Private Sub txtPasswort_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPasswort.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnDBTest.PerformClick()
        End If
    End Sub
    '######################################################
    '# >> Beim schließen vom Formular 
    '######################################################
    Private Sub frmDatenbankEinstellungen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '# Mandanten in die Combobox übertragen 
        If Not My.Settings.mandant_position = -1 Then
            If Not My.Settings.first_start = True Then
                Call frmJTLRechnung.clsDB.setMandantbyCombobox(frmJTLRechnung.cmbMandantenauswahl, False)
            End If

            Application.DoEvents()
            Dim frmStartNummern As New frmStartnummern
            frmStartNummern.Visible = True
            '   frmStartNummern.bIsVisible = True
            frmStartNummern.Show()
        End If

    End Sub

    Private Sub txtPasswort_TextChanged(sender As Object, e As EventArgs) Handles txtPasswort.TextChanged

    End Sub
End Class