Public Class frmJTLPasswortOptionen

    Private Sub frmJTLPasswortOptionen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call frmJTLRechnung.setMainWindowTitle("Passwort Optionen", Me)

        chkKlartextPasswörter.Checked = My.Settings.bHashPasswort
    End Sub

    Private Sub chkKlartextPasswörter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKlartextPasswörter.CheckedChanged
        My.Settings.bHashPasswort = chkKlartextPasswörter.Checked
        My.Settings.Save()        
    End Sub
End Class