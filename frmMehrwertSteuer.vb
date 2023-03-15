Public Class frmMehrwertSteuer

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtMwSt.Text = 0 Then
            txtMwSt.Text = 1
        End If
        'My.Settings.mwst = txtMwSt.Text
        frmJTLRechnung.bSetMwst_rewrite = True
        Me.Close()
    End Sub

    Private Sub txtMwSt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMwSt.KeyDown
        If e.KeyCode = Keys.Enter Then

            My.Settings.mwst_tmp.Item(My.Settings.mandant_position) = txtMwSt.Text
            My.Settings.Save()
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub frmMehrwertSteuer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  txtMwSt.Text = My.Settings.mwst
        Me.Text &= " " & strVersionsNummer

    End Sub

    Private Sub frmMehrwertSteuer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class