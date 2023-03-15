Public Class frmRabatt
    Public dgv As DataGridView
    Dim dblPreis As Double = 0
    Dim iMenge As Integer = 0
    Dim dblPreis_ges As Double = 0
    Dim dblNewPrice As Double = 0
    Dim dblNewPriceGes As Double = 0

    Private Sub txtRabatt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRabatt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub frmRabatt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call frmJTLRechnung.setMainWindowTitle("Rabatt", Me)
        lblName.Text = "Name: " & dgv.CurrentRow.Cells(3).Value

        iMenge = CInt(dgv.CurrentRow.Cells("colBestellMenge").Value)
        lblMenge.Text = iMenge & "x"

        dblPreis = CDbl(dgv.CurrentRow.Cells("colBestellNetto").Value)
        lblPreis.Text = "Preis: " & dblPreis.ToString("C")

        dblPreis_ges = iMenge * dblPreis
        lblPreisGes.Text = "Ges: " & dblPreis_ges.ToString("C")
    End Sub

    Private Sub txtRabatt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRabatt.TextChanged
        Try
            dblNewPrice = dblPreis            
            dblNewPrice = (dblNewPrice / 100) * CDbl(txtRabatt.Text)
            dblNewPrice = (dblPreis - dblNewPrice)
            lblPreisNeu.Text = "Neuer Preis: " & dblNewPrice.ToString("C")

            dblNewPriceGes = dblNewPrice * iMenge
            lblPreisNeuGes.Text = "Ges: " & dblNewPriceGes.ToString("C")

            If iMenge = 1 Then
                lblRabattinEuro.Text = "Rabatt: " & (dblPreis - dblNewPrice).ToString("C")
            Else
                lblRabattinEuro.Text = "Rabatt: " & ((dblPreis_ges) - (dblNewPriceGes)).ToString("C")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        frmJTLRechnung.dblRabatt_newPrice = dblNewPrice
        Me.Close()
    End Sub

    Private Sub frmRabatt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class