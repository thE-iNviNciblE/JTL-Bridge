Public Class frmMapsBrowser
    Public strURL As String = ""
    Private Sub frmMapsBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call frmJTLRechnung.setMainWindowTitle("Google Maps Distanz", Me)
        WebBrowser1.Navigate(strURL)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub
End Class