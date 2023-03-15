Imports System.Data
Imports System.Data.SqlClient

Public Class clsDatenbank
    Public strConnectionString As String
    Public iKID As Integer = -1
    Public strConnectionString_eazybusiness As String = ""

    '##########################################################
    '# >> Verbindung aufbauen + Connection String 
    '##########################################################
    Public Function getDBConnect(ByVal strConnection As String, Optional ByVal bEazybusiness As Boolean = False) As Boolean

        If strConnection.Length = 0 Then
            strConnection = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
        End If

        Dim sqlConn As New SqlConnection(strConnection)

        Try



            If strConnection.IndexOf("eazybusiness") > 0 Then
                bEazybusiness = True
                strConnectionString = strConnection
            End If


            sqlConn.Open()
            'If bEazybusiness = False And strConnection.IndexOf("eazybusiness") < 0 Then
            If bEazybusiness = False Then
                strConnectionString = strConnection
            Else
                strConnectionString_eazybusiness = strConnection
                'strConnectionString = strConnection
            End If

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei Verbindung getDBConnect()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> Kundengruppe ID 
    '####################################################################
    Public Function getJTLLogin(ByVal strUsername As String, ByVal strPasswort As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim iAnzahl As Integer = -1
            Dim sqlComm As New SqlCommand("SELECT * FROM tbenutzer WHERE cLogin='" & strUsername & "' AND cPasswort='" & strPasswort & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                My.Settings.login_userid.Item(My.Settings.mandant_position) = r("kBenutzer").ToString
                Return True                
            End While

            sqlConn.Close()
            Return False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '##########################################################
    '# >> Artikelliste holen 
    '##########################################################
    Public Function getArtikelListe_alle(ByVal lvwData As ListView, ByVal img As ImageList) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()
        img.Images.Clear()
        lvwData.BeginUpdate()
        Dim sqlComm As New SqlCommand("SELECT * FROM tartikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE  tArtikelBeschreibung.kSprache=1 ORDER BY tArtikelBeschreibung.cName ASC", sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()

            Dim lvwItem As New ListViewItem
            ''# Dynamisch die Bilder laden 
            'Try

            '    Application.DoEvents()
            '    If IO.File.Exists(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg") = True Then
            '        img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
            '        lvwItem.ImageKey = r("cArtNr").ToString
            '    Else
            '        Dim sqlConn2 As New SqlConnection(strConnectionString)
            '        sqlConn2.Open()
            '        Dim sqlComm2 As New SqlCommand("SELECT * FROM tArtikelBild WHERE kArtikel=" & r("kArtikel") & " AND nNr=1", sqlConn2)
            '        Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
            '        While r2.Read()
            '            Dim strData() As Byte = r2("pict")
            '            My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\bilderexport\" & r("cArtNr") & ".jpg", strData, False)
            '        End While
            '        sqlConn2.Close()
            '        img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
            '        lvwItem.ImageKey = r("cArtNr").ToString
            '    End If
            'Catch ex As Exception
            '    lvwItem.Text = "--"
            'End Try
            lvwItem.UseItemStyleForSubItems = False
            lvwItem.SubItems.Add(r("cArtNr").ToString)  ' Artikelnummer
            lvwItem.SubItems.Add(r("cName").ToString) ' Name 
            lvwItem.SubItems.Add(CDbl(r("fVKNetto").ToString).ToString("C")) ' Verkauf Nett

            'BURTTO
            'If IsNumeric(r("fVKBrutto").ToString) Then
            '    lvwItem.SubItems.Add(CDbl(r("fVKBrutto").ToString).ToString("C")) ' Verkauf Brutto 
            'Else
            Dim dblSteuersatz As Double = getSteuersatz(r("kSteuerklasse").ToString)

            '# (10 / 100)  * dblSteuersatz
            Dim dblVerkaufBrutto As Double = ((Convert.ToDouble(r("fVKNetto").ToString) / 100) * dblSteuersatz) + Convert.ToDouble(r("fVKNetto").ToString)


            lvwItem.SubItems.Add(dblVerkaufBrutto.ToString("C")) ' Verkauf Brutto 
            'End If

            lvwItem.SubItems.Add(getLagerbestand(r("kArtikel").ToString)) '  
            lvwItem.SubItems.Add(r("fEKNetto").ToString)
            Try
                lvwItem.SubItems.Add(CDbl(r("fEKNetto").ToString) * CDbl(r("fMwSt").ToString))
            Catch ex As Exception
                lvwItem.SubItems.Add("0")
            End Try
            lvwItem.SubItems.Add(r("fGewicht").ToString)
            '# MWST
            lvwItem.SubItems.Add(dblSteuersatz)

            lvwData.Items.Add(lvwItem)

            lvwData.Items(lvwData.Items.Count - 1).SubItems(3).ForeColor = Color.Blue
            lvwData.Items(lvwData.Items.Count - 1).SubItems(4).ForeColor = Color.Green
        End While
        sqlConn.Close()
        lvwData.EndUpdate()
        Return True
    End Function

    '##########################################################
    '# >> Alle Kunden holen 
    '##########################################################
    Public Function getKunden_alle(ByVal lvwData As ListView) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            lvwData.Items.Clear()
            Dim sqlComm As New SqlCommand("SELECT * FROM tkunde ORDER BY cName", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Kleines Bild hinzufügen
            Dim imgList As New ImageList
            imgList.ImageSize = New Size(1, 60)

            imgList.Images.Add("smallimage", Bitmap.FromFile(Application.StartupPath & "\grafiken\row-height.png"))
            lvwData.SmallImageList = imgList

            While r.Read()

                Dim lvwItem As New ListViewItem
                lvwItem.Text = r("cKundenNr").ToString
                lvwItem.SubItems.Add(r("cVorname").ToString)
                lvwItem.SubItems.Add(r("cName").ToString)
                lvwItem.SubItems.Add(r("cOrt").ToString)
                lvwItem.SubItems.Add(r("cStrasse").ToString)
                lvwItem.SubItems.Add(r("cPLZ").ToString)
                lvwItem.SubItems.Add(r("cLand").ToString)
                lvwItem.SubItems.Add(r("cFirma").ToString)
                lvwItem.SubItems.Add(r("cTel").ToString)
                lvwItem.SubItems.Add(r("cEmail").ToString)
                lvwItem.SubItems.Add("True")
                lvwItem.SubItems.Add(r("kKunde").ToString)
                lvwItem.SubItems.Add(r("kKunde").ToString)
                lvwData.Items.Add(lvwItem)
            End While

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler X1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    '##########################################################
    '# >> Artikel suchen 
    '##########################################################
    Public Function getArtikelListe_suchen(ByVal strSuche As String, ByVal lvwData As ListView, ByVal img As ImageList) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()
        img.Images.Clear()


        '####################################
        '# Anzahl der Kategorie bestimmen
        '####################################
        Dim strQueryAnzahl As String = "SELECT count(*) anzahl FROM tartikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel  WHERE (tArtikelBeschreibung.cName LIKE '%" & strSuche & "%' OR tartikel.cArtNr LIKE '%" & strSuche & "%') AND tArtikelBeschreibung.kSprache=1"
        Dim sqlCommCount As New SqlCommand(strQueryAnzahl, sqlConn)
        Dim readerCount As SqlDataReader = sqlCommCount.ExecuteReader()

        While readerCount.Read()

            If Convert.ToInt16(readerCount("anzahl")) > 300 Then
                If MessageBox.Show("Alle Artikel " & readerCount("anzahl") & " anzuzeigen dauert sehr lange, möchten Sie fortfahren", "Große Anzahl", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Return True
                    Exit Function
                End If
            End If
        End While
        readerCount.Close()

        Dim strQueryData As String = "SELECT * FROM tartikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel  WHERE (tArtikelBeschreibung.cName LIKE '%" & strSuche & "%' OR tartikel.cArtNr LIKE '%" & strSuche & "%') AND tArtikelBeschreibung.kSprache=1 ORDER BY tArtikelBeschreibung.cName ASC"

        Dim sqlComm As New SqlCommand(strQueryData, sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()

            Dim lvwItem As New ListViewItem

            '# Dynamisch die Bilder laden 
            Try


                If IO.File.Exists(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg") = True Then
                    img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
                    lvwItem.ImageKey = r("cArtNr").ToString
                Else
                    Dim sqlConn2 As New SqlConnection(strConnectionString)
                    sqlConn2.Open()
                    Dim sqlComm2 As New SqlCommand("SELECT * FROM tArtikelBild WHERE kArtikel=" & r("kArtikel") & " AND nNr=1", sqlConn2)
                    Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                    While r2.Read()
                        Dim strData() As Byte = r2("pict")
                        My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\bilderexport\" & r("cArtNr") & ".jpg", strData, False)
                    End While
                    sqlConn2.Close()
                    img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
                    lvwItem.ImageKey = r("cArtNr").ToString
                End If
            Catch ex As Exception
                lvwItem.Text = "--"
            End Try
            lvwItem.UseItemStyleForSubItems = False
            lvwItem.SubItems.Add(r("cArtNr").ToString)  ' Artikelnummer
            lvwItem.SubItems.Add(r("cName").ToString) ' Name 
            lvwItem.SubItems.Add(CDbl(r("fVKNetto").ToString).ToString("C")) ' Verkauf Nett

            'BURTTO
            'If IsNumeric(r("fVKBrutto").ToString) Then
            '    lvwItem.SubItems.Add(CDbl(r("fVKBrutto").ToString).ToString("C")) ' Verkauf Brutto 
            'Else
            Dim dblSteuersatz As Double = getSteuersatz(r("kSteuerklasse").ToString)

            '# (10 / 100)  * dblSteuersatz
            Dim dblVerkaufBrutto As Double = ((Convert.ToDouble(r("fVKNetto").ToString) / 100) * dblSteuersatz) + Convert.ToDouble(r("fVKNetto").ToString)


            lvwItem.SubItems.Add(dblVerkaufBrutto.ToString("C")) ' Verkauf Brutto 
            'End If

            lvwItem.SubItems.Add(getLagerbestand(r("kArtikel").ToString)) '  
            lvwItem.SubItems.Add(r("fEKNetto").ToString)
            Try
                lvwItem.SubItems.Add(CDbl(r("fEKNetto").ToString) * CDbl(r("fMwSt").ToString))
            Catch ex As Exception
                lvwItem.SubItems.Add("0")
            End Try
            lvwItem.SubItems.Add(r("fGewicht").ToString)
            '# MWST
            lvwItem.SubItems.Add(dblSteuersatz)

            lvwData.Items.Add(lvwItem)

            lvwData.Items(lvwData.Items.Count - 1).SubItems(3).ForeColor = Color.Blue
            lvwData.Items(lvwData.Items.Count - 1).SubItems(4).ForeColor = Color.Green
        End While

        sqlConn.Close()
        Return True
    End Function

    Public Function getSteuersatz(strSteuerklasse As Integer) As Double
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)

            Dim strQueryData As String = "SELECT * FROM tSteuerschluessel  JOIN tSteuersatz ON tSteuerschluessel.kSteuerschluessel = tSteuersatz.kSteuerklasse WHERE tSteuersatz.kSteuerzone = 1 AND tSteuersatz.kSteuerklasse='" & strSteuerklasse & "'"
            sqlConn.Open()
            Dim sqlComm As New SqlCommand(strQueryData, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()
            r.Read()
            Dim dbl As Double = Convert.ToDouble(r("fSteuersatz").ToString)
            sqlConn.Close()
            Return dbl
        Catch ex As Exception
            '   MessageBox(ex.Message, "getSteuersatz")
        End Try
    End Function
    '###################################################################
    '# >> getkArtikelIDbySKU
    '# Ermittelt die kArtikel ID anhand der SKU
    '###################################################################
    Public Function getkArtikelIDbySKU(strCArtNr As String) As String
        Try
            Dim strkArtikelID As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tArtikel WHERE cArtNr= '" & strCArtNr & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strkArtikelID = r("kArtikel").ToString()
            End While

            Return strkArtikelID

        Catch ex As Exception
            MessageBox.Show("Fehler beim abrufen des der absoluten ArtikelID", "getkArtikelIDbySKU", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '###################################################################
    '# >> getkArtikelIDbySKU
    '# Ermittelt die kArtikel ID anhand der SKU
    '###################################################################
    Public Function getkArtikelMHDOptionbySKU(strCArtNr As String) As String
        Try
            Dim strkArtikelID As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tArtikel WHERE cArtNr= '" & strCArtNr & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strkArtikelID = r("nMHD").ToString()
            End While

            Return strkArtikelID

        Catch ex As Exception
            MessageBox.Show("Fehler beim abrufen des der absoluten ArtikelID", "getkArtikelIDbySKU", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function
    '#############################################################
    '# >> Lagerbestand abrufen
    '#############################################################
    Public Function getLagerbestand(strArtikelId As String) As Double
        Try
            Dim dblLagerbestand As Double = 0
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tlagerbestand WHERE kArtikel= '" & strArtikelId & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                dblLagerbestand = r("fVerfuegbar").ToString()
            End While

            Return dblLagerbestand
        Catch ex As Exception
            MessageBox.Show("Fehler beim abrufen des Lagerbestands", "getLagerbestand", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    '##########################################################
    '# >> Kunde suchen 
    '##########################################################
    Public Function getKundenListe_suchen(ByVal strSuche As String, ByVal lvwData As ListView) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            lvwData.Items.Clear()
            Dim sqlComm As New SqlCommand("SELECT * FROM tkunde WHERE cName LIKE '%" & strSuche & "%' OR cKundenNr LIKE '%" & strSuche & "%' OR cVorname LIKE '%" & strSuche & "%' OR cOrt LIKE '%" & strSuche & "%' OR cPLZ LIKE '%" & strSuche & "%' OR cStrasse LIKE '%" & strSuche & "%' OR cFirma LIKE '%" & strSuche & "%' ORDER BY cName ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Kleines Bild hinzufügen
            Dim imgList As New ImageList
            imgList.ImageSize = New Size(1, 60)

            imgList.Images.Add("smallimage", Bitmap.FromFile(Application.StartupPath & "\grafiken\row-height.png"))
            lvwData.SmallImageList = imgList
            While r.Read()

                Dim lvwItem As New ListViewItem
                '  lvwItem.ImageKey(3).ToString()
                lvwItem.ImageKey = "smallimage"

                lvwItem.Text = r("cKundenNr").ToString
                lvwItem.SubItems.Add(r("cVorname").ToString)
                lvwItem.SubItems.Add(r("cName").ToString)
                lvwItem.SubItems.Add(r("cOrt").ToString)
                lvwItem.SubItems.Add(r("cStrasse").ToString)
                lvwItem.SubItems.Add(r("cPLZ").ToString)
                lvwItem.SubItems.Add(r("cLand").ToString)
                lvwItem.SubItems.Add(r("cFirma").ToString)
                lvwItem.SubItems.Add(r("cTel").ToString)
                lvwItem.SubItems.Add(r("cEmail").ToString)
                lvwItem.SubItems.Add("True")
                lvwItem.SubItems.Add(r("kKunde").ToString)
                lvwItem.SubItems.Add(r("kKunde").ToString)
                lvwData.Items.Add(lvwItem)

            End While

            sqlConn.Close()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '##########################################################
    '# >> Kategorie abrufen
    '##########################################################
    Public Function getKategorie(ByVal iCatID As Integer, ByVal lvwKategorie As ListView, Optional ByVal iSubLevel As Integer = -1) As Boolean
        Try
            Dim strAbstand As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tkategorie JOIN tKategorieSprache ON tkategorie.kKategorie = tKategorieSprache.kKategorie  WHERE tkategorie.kOberKategorie = " & iCatID, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Abstand berechnen 
            If iSubLevel > 0 Then
                For iCount As Integer = 0 To iSubLevel
                    strAbstand &= "  "
                Next                
            End If

            While r.Read()

                Dim lvwItem As New ListViewItem
                lvwItem.Text = r("kKategorie").ToString
                lvwItem.SubItems.Add(strAbstand & r("cName").ToString)
                lvwKategorie.Items.Add(lvwItem)

                '# Alle Unterkategorien anzeigen 
                If iSubLevel >= 0 Then
                    Call getKategorie(r("kKategorie").ToString, lvwKategorie, iSubLevel + 1) ' Rekursion starten 
                End If

            End While            
            sqlConn.Close()


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> Kategorie Oberkategorie abrufen
    '##########################################################
    Public Function getKategorieOberKategorie(ByVal iCatID As Integer, ByVal iPos As Integer, Optional ByVal bSubCategoriy As Boolean = False) As String()
        Try
            Dim iInternPos As Integer = 0
            Dim strOutput(1) As String
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tkategorie JOIN tKategorieSprache ON tkategorie.kKategorie = tKategorieSprache.kKategorie  WHERE kOberKategorie='" & iCatID & "' AND tKategorieSprache.kSprache=1 ORDER BY tkategorie.nSort ASC, tKategorieSprache.cName ASC ", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                If iPos = iInternPos Then
                    strOutput(0) = r("cName").ToString
                    strOutput(1) = r("kKategorie").ToString
                    sqlConn.Close()
                    Return strOutput
                    Exit Function
                End If
                iInternPos += 1
            End While

            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    '##########################################################
    '# >> Kategorie Oberkategorie abrufen und zählen
    '##########################################################
    Public Function getKategorieOberKategorie_count(ByVal iCatID As Integer) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            Dim iAnzahl As Integer = 0
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT count(*) as anzahl FROM tkategorie WHERE kOberKategorie='" & iCatID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                iAnzahl = r("anzahl").ToString
                sqlConn.Close()
                Return iAnzahl
                Exit Function

            End While

            sqlConn.Close()
            Return -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    '##########################################################
    '# >> Artikel aus Kategorie laden
    '##########################################################
    Public Function getKategorie2Artikel(ByVal iCatID As Integer, ByRef lvwArtikel As ListView, ByVal img As ImageList) As Boolean
        Try

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            lvwArtikel.Items.Clear()
            img.Images.Clear()
            lvwArtikel.BeginUpdate()
            frmJTLRechnung.msgProgress.Visible = True
            '####################################
            '# Anzahl der Kategorie bestimmen
            '####################################
            Dim strQuery As String = "SELECT count(*) as anzahl FROM tkategorieartikel JOIN tartikel ON tkategorieartikel.kArtikel = tartikel.kArtikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel  WHERE tkategorieartikel.kKategorie='" & iCatID & "' AND tArtikelBeschreibung.kSprache=1"
            Dim sqlCommCount As New SqlCommand(strQuery, sqlConn)
            Dim readerCount As SqlDataReader = sqlCommCount.ExecuteReader()
            frmJTLRechnung.msgProgress.Value = 0

            While readerCount.Read()
                frmJTLRechnung.msgProgress.Maximum = Convert.ToInt16(readerCount("anzahl"))
                If Convert.ToInt16(readerCount("anzahl")) > 300 Then
                    If MessageBox.Show("Alle Artikel " & readerCount("anzahl") & " anzuzeigen dauert sehr lange, möchten Sie fortfahren", "Große Anzahl", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Return True
                        Exit Function
                    End If
                End If
            End While
            readerCount.Close()

            Dim strQuery2 As String = "SELECT * FROM tkategorieartikel JOIN tartikel ON tkategorieartikel.kArtikel = tartikel.kArtikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tkategorieartikel.kKategorie='" & iCatID & "' AND tArtikelBeschreibung.kSprache=1 ORDER BY cName ASC"
            Dim sqlComm As New SqlCommand(strQuery2, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                Dim lvwItem As New ListViewItem

                '# Dynamisch die Bilder laden 
                Try

                    frmJTLRechnung.msgProgress.Value += 1

                    If IO.File.Exists(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg") = True Then
                        img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
                        lvwItem.ImageKey = r("cArtNr").ToString
                    Else
                        Dim sqlConn2 As New SqlConnection(strConnectionString)
                        sqlConn2.Open()
                        'Dim sqlComm2 As New SqlCommand("SELECT * FROM tArtikelBild WHERE kArtikel=" & r("kArtikel") & " AND nNr=1", sqlConn2)
                        Dim sqlComm2 As New SqlCommand("SELECT * FROM tArtikelbildPlattform JOIN tBild ON tArtikelbildPlattform.kBild = tBild.kBild WHERE kArtikel=" & r("kArtikel"), sqlConn2)
                        Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                        While r2.Read()
                            Dim strData() As Byte = r2("bBild")
                            My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\bilderexport\" & r("cArtNr") & ".jpg", strData, False)
                        End While
                        sqlConn2.Close()
                        img.Images.Add(r("cArtNr").ToString, Bitmap.FromFile(Application.StartupPath & "\bilderexport\" & r("cArtNr").ToString & ".jpg"))
                        lvwItem.ImageKey = r("cArtNr").ToString
                        sqlConn2.Dispose()
                    End If
                Catch ex As Exception
                    lvwItem.Text = "--"
                    MessageBox.Show(ex.ToString)
                End Try

                lvwItem.UseItemStyleForSubItems = False
                lvwItem.SubItems.Add(r("cArtNr").ToString)  ' Artikelnummer
                lvwItem.SubItems.Add(r("cName").ToString) ' Name 
                lvwItem.SubItems.Add(CDbl(r("fVKNetto").ToString).ToString("C")) ' Verkauf Nett

                'BURTTO
                'If IsNumeric(r("fVKBrutto").ToString) Then
                '    lvwItem.SubItems.Add(CDbl(r("fVKBrutto").ToString).ToString("C")) ' Verkauf Brutto 
                'Else
                Dim dblSteuersatz As Double = getSteuersatz(r("kSteuerklasse").ToString)

                '# (10 / 100)  * dblSteuersatz
                Dim dblVerkaufBrutto As Double = ((Convert.ToDouble(r("fVKNetto").ToString) / 100) * dblSteuersatz) + Convert.ToDouble(r("fVKNetto").ToString)


                lvwItem.SubItems.Add(dblVerkaufBrutto.ToString("C")) ' Verkauf Brutto 
                'End If

                lvwItem.SubItems.Add(getLagerbestand(r("kArtikel").ToString)) '  
                lvwItem.SubItems.Add(r("fEKNetto").ToString)
                Try
                    lvwItem.SubItems.Add(CDbl(r("fEKNetto").ToString) * CDbl(r("fMwSt").ToString))
                Catch ex As Exception
                    lvwItem.SubItems.Add("0")
                End Try
                lvwItem.SubItems.Add(r("fGewicht").ToString)
                '# MWST
                lvwItem.SubItems.Add(dblSteuersatz)

                lvwArtikel.Items.Add(lvwItem)

                lvwArtikel.Items(lvwArtikel.Items.Count - 1).SubItems(3).ForeColor = Color.Blue
                lvwArtikel.Items(lvwArtikel.Items.Count - 1).SubItems(4).ForeColor = Color.Green
            End While

            sqlConn.Close()
            lvwArtikel.EndUpdate()
            frmJTLRechnung.msgProgress.Visible = False
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen getKategorie2Artikel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getArtikel2Picture() As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tArtikelBild WHERE kArtikel=2 AND nNr=1", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                Dim strData() As Byte = r("pict")
                My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\bilderexport\test.jpg", strData, False)
            End While

            sqlConn.Close()


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Startnummern 
    '####################################################################
    Public Function getStartNummern(ByVal strBereich As String, strWhere As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT " & strBereich & " FROM tLaufendeNummern " & strWhere, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r(strBereich).ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Laufende Nummer  
    '####################################################################
    Public Function getLftNummer(ByVal strTabelle As String, strWhere As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT nNummer FROM " & strTabelle & " " & strWhere, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("nNummer").ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Laufende Nummer updaten 
    '####################################################################
    Public Function setLftNummer_update(ByVal strTabelle As String, ByVal strWhere As String, ByVal iNummerNext As Integer) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim iNr As Integer = 0
            Dim sqlComm As New SqlCommand("UPDATE " & strTabelle & " SET nNummer=" & iNummerNext & " " & strWhere, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return iNr

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    '####################################################################
    '# >> Kundengruppe
    '####################################################################
    Public Function getZahlungsarten(ByVal cmb As ComboBox) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tZahlungsart", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                cmb.Items.Add(r("cName").ToString)
            End While

            cmb.SelectedIndex = 0
            sqlConn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Kundengruppe
    '####################################################################
    Public Function getKundenGruppe(ByVal cmb As ComboBox) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tKundenGruppe", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                cmb.Items.Add(r("cName").ToString)
            End While

            cmb.SelectedIndex = 0
            sqlConn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> Länderliste
    '####################################################################
    Public Function getKundenLänderliste(ByVal cmb As ComboBox) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tland ORDER BY cName ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                'If r("cName").ToString.Contains("Deutschland") Then
                '    MessageBox.Show(cmb.Items.Count)
                'End If

                cmb.Items.Add(r("cName").ToString)
            End While

            cmb.SelectedIndex = 0
            sqlConn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> LAND  ISO 
    '####################################################################
    Public Function getKundenLänderliste_ISO(ByVal strName As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tland WHERE cName='" & strName & "' ORDER BY cName ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("cISO").ToString
            End While

            sqlConn.Close()

            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '####################################################################
    '# >> Kundengruppe ID 
    '####################################################################
    Public Function getZahlungsArtByName(ByVal strName As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tZahlungsart WHERE cName='" & strName & "' ORDER BY cName ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("kZahlungsart").ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function
    '####################################################################
    '# >> Kundengruppe ID 
    '####################################################################
    Public Function getKundenGruppe_id(ByVal strName As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT * FROM tKundenGruppe WHERE cName='" & strName & "' ORDER BY cName ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("kKundenGruppe").ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '####################################################################
    '# >> Kundengruppe ID 
    '####################################################################
    Public Function getJTLID_MAX(ByVal strTabelle As String, ByVal strSpalte As String) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim iNr As Integer = 0
            Dim sqlComm As New SqlCommand("SELECT max(" & strSpalte & ") as max FROM " & strTabelle, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("max").ToString
            End While

            If strData.Length = 0 Then
                strData = 0
            End If
            iNr = CInt(strData) + 1
            sqlConn.Close()
            Return iNr

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    '####################################################################
    '# >> JTL Kunden / Auftragsnummer formatieren und holen
    '####################################################################
    Public Function getJTLNumber(ByVal strPreFix As String, ByVal strSuffix As String, ByVal strFortlaufendeNummer As String) As String
        Try
            Dim strData As String = ""

            strData = strPreFix & strFortlaufendeNummer & strSuffix

            '# Monat mit laufender Null
            Dim strMonth As String = Date.Now.Month
            If CInt(strMonth) < 10 Then
                strMonth = "0" & strMonth
            End If

            '# Tag mit laufender Null 
            Dim strTag As String = Date.Now.Day
            If CInt(strTag) < 10 Then
                strTag = "0" & strTag
            End If

            strData = strData.Replace("<J>", Date.Now.Year).Replace("<M>", strMonth).Replace("<T>", strTag)

            Return strData
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '####################################################################
    '# >> Lieferadresse speichern 
    '####################################################################
    Public Function setKunde_Lieferadresse(ByVal frm As frmKunde_neu, ByVal strJTLKundenNummer As String, ByVal ikKundenID As Integer) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""

            '# Anrede festlegen 
            Dim strAnrede As String = ""
            If frm.rdbFirma.Checked = True Then
                strAnrede = "Firma"
            ElseIf frm.rdbFrau.Checked = True Then
                strAnrede = "Frau"
            ElseIf frm.rdbHerr.Checked = True Then
                strAnrede = "Herr"
            End If

            strQuery = "INSERT INTO tlieferadresse(kLieferAdresse,kKunde,cFirma,cAnrede,cVorname,cName,cStrasse,cPLZ,cOrt,cLand,cTel,cMail,cBundesland,cISO)"
            strQuery &= " VALUES("
            strQuery &= "'" & getJTLID_MAX("tlieferadresse", "kLieferAdresse") & "',"
            strQuery &= "'" & ikKundenID & "',"
            strQuery &= "'" & frm.txtFirma.Text & "',"
            strQuery &= "'" & strAnrede & "',"
            strQuery &= "'" & frm.txtVorname.Text & "',"
            strQuery &= "'" & frm.txtNachname.Text & "',"
            strQuery &= "'" & frm.txtStraße.Text & "',"
            strQuery &= "'" & frm.txtPostleitzahl.Text & "',"
            strQuery &= "'" & frm.txtOrt.Text & "',"
            strQuery &= "'" & frm.cmbLand.Text & "',"
            strQuery &= "'" & frm.txtTelefon.Text & "',"
            strQuery &= "'" & frm.txtEmail.Text & "',"
            strQuery &= "'" & frm.txtBundesland.Text & "',"
            strQuery &= "'" & getKundenLänderliste_ISO(frm.txtLand.Text) & "')"

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Abbruch beim Lieferadresse speichern" & vbCrLf & ex.Message, "Lieferadresse speichern", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Buchung speichern 
    '####################################################################
    Public Function setLager_BuchungEingang(ByVal frm As frmLagerverwaltung, strArtikelID As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""

            strQuery = "INSERT INTO tWarenLagerEingang(kArtikel,kWarenLagerPlatz,kLieferantenBestellungPos,kBenutzer,fAnzahl,fEKEinzel,cLieferscheinNr,cChargenNr,dMHD,dErstellt,dGeliefertAM,cKommentar,kGutschriftPos,kWarenLagerAusgang,kLHM,fAnzahlAktuell,fAnzahlReserviertPickpos,kSessionID,kWarenLagerEingang_Ursprung)"
            strQuery &= " VALUES("
            strQuery &= "'" & strArtikelID & "',"
            strQuery &= "'" & "1" & "',"
            strQuery &= "'" & "0" & "',"
            strQuery &= "'" & "1" & "',"
            strQuery &= "'" & frm.txtLageranzahl.Text & "',"
            strQuery &= "'" & "0" & "',"
            strQuery &= "'" & "" & "',"
            strQuery &= "'" & frm.txtChargenummer.Text & "',"
            strQuery &= "@date_mhd,"
            strQuery &= "@date_erstellt,"
            strQuery &= "@date_geliefert,"
            strQuery &= "'" & frm.txtKommentar.Text & "',"
            strQuery &= "'0',"
            strQuery &= "'0',"
            strQuery &= "'0',"

            strQuery &= "'0',"
            strQuery &= "'0',"
            strQuery &= "'0'," 'SESSION ID = 0 OK (?)
            strQuery &= "'" & "0" & "')"

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.Parameters.Add("@date_erstellt", SqlDbType.DateTime).Value = DateTime.Now
            sqlComm.Parameters.Add("@date_geliefert", SqlDbType.DateTime).Value = DateTime.Now

            If frm.txtMHD.Text.Length > 0 Then
                Dim dMHD As DateTime = frm.txtMHD.Text
                sqlComm.Parameters.Add("@date_mhd", SqlDbType.DateTime).Value = dMHD.ToString("yyyy-MM-dd")
            Else
                Dim dMHD As DateTime = New DateTime(1753, 01, 01)

                sqlComm.Parameters.Add("@date_mhd", SqlDbType.DateTime).Value = dMHD
            End If

            sqlComm.ExecuteNonQuery()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Abbruch setLager_BuchungEingang konnte nicht durchgeführt werden" & vbCrLf & ex.Message, "Buchungseingang speichern", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Rechnungsadresse speichern 
    '####################################################################
    Public Function setKunde_Rechnungsadresse(ByVal frm As frmKunde_neu, ByVal strJTLKundenNummer As String, ByVal ikKundenID As Integer) As Boolean
        Try

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""

            '# Anrede festlegen 
            Dim strAnrede As String = ""
            If frm.rdbFirma.Checked = True Then
                strAnrede = "Firma"
            ElseIf frm.rdbFrau.Checked = True Then
                strAnrede = "Frau"
            ElseIf frm.rdbHerr.Checked = True Then
                strAnrede = "Herr"
            End If

            strQuery = "INSERT INTO trechnungsadresse(kRechnungsAdresse,kKunde,cFirma,cAnrede,cVorname,cName,cStrasse,cPLZ,cOrt,cLand,cTel,cMail,cISO,cBundesland,cKundenNr)"
            strQuery &= " VALUES("
            strQuery &= "'" & getJTLID_MAX("trechnungsadresse", "kRechnungsAdresse") & "',"
            strQuery &= "'" & ikKundenID & "',"
            strQuery &= "'" & frm.txtFirma.Text & "',"
            strQuery &= "'" & strAnrede & "',"
            strQuery &= "'" & frm.txtVorname.Text & "',"
            strQuery &= "'" & frm.txtNachname.Text & "',"
            strQuery &= "'" & frm.txtStraße.Text & "',"
            strQuery &= "'" & frm.txtPostleitzahl.Text & "',"
            strQuery &= "'" & frm.txtOrt.Text & "',"
            strQuery &= "'" & frm.cmbLand.Text & "',"
            strQuery &= "'" & frm.txtTelefon.Text & "',"
            strQuery &= "'" & frm.txtEmail.Text & "',"
            strQuery &= "'" & getKundenLänderliste_ISO(frm.txtLand.Text) & "',"
            strQuery &= "'" & frm.txtBundesland.Text & "',"
            strQuery &= "'" & strJTLKundenNummer & "')"

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()
            sqlConn.Close()

            Return True
        Catch ex As Exception
            MessageBox.Show("Abbruch beim Rechnungsdresse speichern" & vbCrLf & ex.Message, "Rechnungsdresse speichern", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Kunde speichern 
    '####################################################################
    Public Function setKunde_neu(ByVal frm As frmKunde_neu, ByVal strTabelle As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""
            Dim ikKundenID As Integer = -1 ' HauptKundenID
            Dim bNoError As Boolean = True
            Dim strJTLKundenNummer As String

            '# Nächste Kundennummer holen
            If strTabelle = "cubss_rechnung_kunde" Then
                strJTLKundenNummer = frm.txtKundenNummer.Text
            Else
                strJTLKundenNummer = frmJTLRechnung.clsDB.getJTLNumber(My.Settings.nr_kunden_prefix.Item(My.Settings.mandant_position), My.Settings.nr_kunden_suffix.Item(My.Settings.mandant_position), getLftNummer("tLaufendeNummern", "WHERE cName='Kunde'"))
            End If

            '# Anrede festlegen 
            Dim strAnrede As String = ""
            If frm.rdbFirma.Checked = True Then
                strAnrede = "Firma"
            ElseIf frm.rdbFrau.Checked = True Then
                strAnrede = "Frau"
            ElseIf frm.rdbHerr.Checked = True Then
                strAnrede = "Herr"
            End If

            Dim strKassenkunde As String = "Y"
            Dim strHändler As String = "N"
            Dim strNewsletter As String = "Y"

            If frm.chkHändler.Checked = True Then
                strHändler = "Y"
            End If

            If frm.chkKassenkunde.Checked = False Then
                strKassenkunde = "N"
            End If

            If frm.chkNewsletter.Checked = False Then
                strNewsletter = "N"
            End If

            '#########################################################################
            '# >> Hauptkundenprofil
            '#########################################################################
            ikKundenID = getJTLID_MAX(strTabelle, "kKunde")
            iKID = ikKundenID
            Try
                If strTabelle.Contains("cubss_") = True Then
                    strQuery = "INSERT INTO " & strTabelle & "(kKunde,cKundenNr,cFirma,cAnrede,cVorname,cName,cStrasse,cPLZ,cOrt,cLand,cTel,cEMail,cAktiv,cNewsletter,cSperre,kKundenGruppe,kSprache,cISO,kZahlungsart)"
                    strQuery &= " VALUES("
                    strQuery &= "'" & ikKundenID & "',"
                    strQuery &= "'" & strJTLKundenNummer & "',"
                    strQuery &= "'" & frm.txtFirma.Text & "',"
                    strQuery &= "'" & strAnrede & "',"
                    strQuery &= "'" & frm.txtVorname.Text & "',"
                    strQuery &= "'" & frm.txtNachname.Text & "',"
                    strQuery &= "'" & frm.txtStraße.Text & "',"
                    strQuery &= "'" & frm.txtPostleitzahl.Text & "',"
                    strQuery &= "'" & frm.txtOrt.Text & "',"
                    strQuery &= "'" & frm.cmbLand.Text & "',"
                    strQuery &= "'" & frm.txtTelefon.Text & "',"
                    strQuery &= "'" & frm.txtEmail.Text & "',"
                    strQuery &= "'Y'," ' aktiv
                    strQuery &= "'" & strNewsletter & "'," ' Newsletter
                    strQuery &= "'N'," ' Sperre
                    strQuery &= "'" & getKundenGruppe_id(frm.txtKundengruppe.Text) & "',"
                    strQuery &= "'1',"
                    strQuery &= "'" & getKundenLänderliste_ISO(frm.txtLand.Text) & "',"
                    strQuery &= "'" & getZahlungsArtByName(frm.cmbZahlungsart.Text) & "')"

                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                    sqlComm.ExecuteNonQuery()
                Else
                    strQuery = "INSERT INTO " & strTabelle & "(kKunde,cKundenNr,cFirma,cAnrede,cVorname,cName,cStrasse,cPLZ,cOrt,cLand,cTel,cEMail,cAktiv,cNewsletter,cSperre,kKundenGruppe,kSprache,cISO,kZahlungsart,nDebitorennr,nKreditlimit,cKassenkunde,nZahlungsziel ,nDrittland ,cHaendler ,dErstellt, kKundenKategorie ,kInetKunde , cBundesland)"
                    strQuery &= " VALUES("
                    strQuery &= "'" & ikKundenID & "',"
                    strQuery &= "'" & strJTLKundenNummer & "',"
                    strQuery &= "'" & frm.txtFirma.Text & "',"
                    strQuery &= "'" & strAnrede & "',"
                    strQuery &= "'" & frm.txtVorname.Text & "',"
                    strQuery &= "'" & frm.txtNachname.Text & "',"
                    strQuery &= "'" & frm.txtStraße.Text & "',"
                    strQuery &= "'" & frm.txtPostleitzahl.Text & "',"
                    strQuery &= "'" & frm.txtOrt.Text & "',"
                    strQuery &= "'" & frm.cmbLand.Text & "',"
                    strQuery &= "'" & frm.txtTelefon.Text & "',"
                    strQuery &= "'" & frm.txtEmail.Text & "',"
                    strQuery &= "'Y'," ' aktiv
                    strQuery &= "'" & strNewsletter & "'," ' Newsletter
                    strQuery &= "'N'," ' Sperre
                    strQuery &= "'" & getKundenGruppe_id(frm.txtKundengruppe.Text) & "',"
                    strQuery &= "'1',"
                    strQuery &= "'" & getKundenLänderliste_ISO(frm.txtLand.Text) & "',"
                    strQuery &= "'" & getZahlungsArtByName(frm.cmbZahlungsart.Text) & "'," 'Zahlungsart
                    strQuery &= "'0'," 'nDebitorennr
                    strQuery &= "'0'," 'nKreditlimit
                    strQuery &= "'" & strKassenkunde & "'," 'cKassenkunde
                    strQuery &= "'0'," 'nZahlungsziel 
                    strQuery &= "'0'," 'nDrittland
                    strQuery &= "'" & strHändler & "'," 'cHaendler
                    strQuery &= "@date," 'dErstellt 
                    strQuery &= "'0'," 'kKundenKategorie 
                    strQuery &= "'0'," 'kInetKunde  
                    strQuery &= "'" & frm.txtBundesland.Text & "')"

                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                    sqlComm.ExecuteNonQuery()
                End If

            Catch ex As Exception
                bNoError = False
                MessageBox.Show("Abbruch beim Hauptkundenprofil speichern" & vbCrLf & ex.Message, "Kundenprofil speichern", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            '# Fortlaufende Kundennummer erhöhen 
            If Not strTabelle = "cubss_rechnung_kunde" Then
                Dim iNummer As Integer = getLftNummer("tLaufendeNummern", "WHERE cName='Kunde'")
                iNummer += 1

                '# Fehlerfall Prüfung Nummer nicht mehr numerisch 
                If IsNumeric(iNummer) = True Then
                    Call setLftNummer_update("tLaufendeNummern", "WHERE cName='Kunde'", iNummer)
                Else
                    MessageBox.Show("Fehler bei dem Kundennummer Update!" & vbCrLf & "Bitte überprüfen Sie umgehend unter Einstellungen -> Allgemeine Einstellungen -> Startnummern")
                End If

                '#########################################################################
                '# >> RECHNUNGSADRESSE
                '#########################################################################
                '# Kein Fehler beim Kunden anlegen
                If bNoError = True Then
                    bNoError = setKunde_Rechnungsadresse(frm, strJTLKundenNummer, ikKundenID)
                End If

                '#########################################################################
                '# >> Lieferadresse
                '#########################################################################
                If bNoError = True Then
                    bNoError = setKunde_Lieferadresse(frm, strJTLKundenNummer, ikKundenID)
                End If

            End If

            sqlConn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '#################################################################
    '# Rechnungsadresse ID holen
    '# Lieferadresse ID holen
    '#################################################################
    Public Function getAdressKEYS(ByVal strTabelle As String, ByVal strSpalte As String, ByVal strKID As String) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = "-1"
            Dim iNr As Integer = -1
            Dim sqlComm As New SqlCommand("SELECT " & strSpalte & " FROM " & strTabelle & " WHERE kKunde='" & strKID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r(strSpalte).ToString
            End While

            iNr = CInt(strData)
            sqlConn.Close()
            Return iNr
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler ID's holen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    '###################################################################
    '# >> setVersandkostenPosition_save
    '# Speichern der Versandkostenposition 
    '###################################################################
    Public Function setVersandkostenPosition_create(strVersandkostenName As String, strVersandkostenNetto As String, strVersandkostenBrutto As String) As Boolean
        Try
            Dim strQuery As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim iVersandkostenMaxID As Integer = getJTLID_MAX("cubss_versandkosten", "kVersandkosten")

            strQuery = "INSERT INTO cubss_versandkosten (kVersandkosten,cVersandkostenname,cVersandkostenNetto,cVersandkostenBrutto)"
            strQuery &= " VALUES("
            strQuery &= "'" & iVersandkostenMaxID & "',"
            strQuery &= "'" & strVersandkostenName & "',"
            strQuery &= "'" & strVersandkostenNetto & "',"
            strQuery &= "'" & strVersandkostenBrutto & "')" ' nKomplettAusgeliefert 'kColor

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            'sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show("Fehler bei: " & ex.Message, "setVersandkostenPosition", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '###################################################################
    '# >> setVersandkostenPosition_update
    '# Speichern der Versandkostenposition 
    '###################################################################
    Public Function setVersandkostenPosition_update(strVersandkostenName As String, strVersandkostenNetto As String, strVersandkostenBrutto As String, strVersandkostenID As String) As Boolean
        Try
            Dim strQuery As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            'Dim iVersandkostenMaxID As Integer = getJTLID_MAX("cubss_versandkosten", "kVersandkosten")

            strQuery = "Update cubss_versandkosten set cVersandkostenname='" & strVersandkostenName & "', cVersandkostenNetto = '" & strVersandkostenNetto & "',cVersandkostenBrutto='" & strVersandkostenBrutto & "' WHERE kVersandkosten ='" & strVersandkostenID & "'"
         
            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei: " & ex.Message, "setVersandkostenPosition", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '###################################################################
    '# >> setVersandkostenPosition_read
    '# Lesen der Versandkostenposition 
    '###################################################################
    Public Function setVersandkostenPosition_read(ByVal strVersandkostenID As String, dgv As DataGridView, bReadAll As Boolean, Optional iRowIndex As Integer = 0) As Boolean
        Try
            Dim strQuery As String

            If bReadAll = True Then
                strQuery = "SELECT * FROM cubss_versandkosten"
            Else
                strQuery = "SELECT * FROM cubss_versandkosten WHERE kVersandkosten='" & strVersandkostenID & "'"
            End If

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If bReadAll = True Then
                    dgv.Rows.Add(r("cVersandkostenname").ToString, r("cVersandkostenNetto").ToString, r("cVersandkostenBrutto").ToString, r("kVersandkosten").ToString)
                Else
                    dgv.Rows(iRowIndex).Cells(0).Value = r("cVersandkostenname").ToString
                    dgv.Rows(iRowIndex).Cells(1).Value = r("cVersandkostenNetto").ToString
                    dgv.Rows(iRowIndex).Cells(2).Value = r("cVersandkostenBrutto").ToString
                    dgv.Rows(iRowIndex).Cells(3).Value = r("kVersandkosten").ToString
                End If

            End While

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei: " & ex.Message, "setVersandkostenPosition", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '###################################################################
    '# >> setVersandkostenPosition_delete
    '# Lesen der Versandkostenposition 
    '###################################################################
    Public Function setVersandkostenPosition_delete(ByVal strVersandkostenID As String) As Boolean
        Try
            Dim strQuery As String
 
            strQuery = "DELETE FROM cubss_versandkosten WHERE kVersandkosten='" & strVersandkostenID & "'"


            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei: " & ex.Message, "setVersandkostenPosition", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> Bestellung Header
    '####################################################################
    Public Function setBestellung_header(ByVal strKID As String, ByVal strTabelle As String) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""
            Dim iLieferAdresse As Integer
            Dim iRechnungsAdresse As Integer

            If strKID = "-1" Then
                strKID = iKID
            End If

            Dim iBestellung As Integer = getJTLID_MAX(strTabelle, "kBestellung")

            '# Keine Lieferadresse / Rechnungsaddresse 
            ' If not strTabelle = "cubss_rechnung_bestellung" Then
            iLieferAdresse = getAdressKEYS("tlieferadresse", "kLieferAdresse", strKID)
            iRechnungsAdresse = getAdressKEYS("trechnungsadresse", "kRechnungsAdresse", strKID)
            'Else
            '   iLieferAdresse = -1
            '    iRechnungsAdresse = -1
            'End If


            Dim strJTLWaWiBenutzer As String = 1
            If My.Settings.login_userid.Item(My.Settings.mandant_position).Length > 0 Then
                strJTLWaWiBenutzer = My.Settings.login_userid.Item(My.Settings.mandant_position).Length
            End If

            If strTabelle.Contains("cubss_") = True Then



                strQuery = "INSERT INTO " & strTabelle & "(kBestellung,tRechnung_kRechnung,tBenutzer_kBenutzer,tAdresse_kAdresse,tText_kText,tKunde_kKunde,cBestellNr,cType,nZahlungsziel,tVersandArt_kVersandArt,fVersandBruttoPreis,fRabatt,kInetBestellung,cInet,cWaehrung,fFaktor,kShop,kFirma,kLogistik,nPlatform,kSprache,fGutschein,kZahlungsArt,kLieferAdresse,kRechnungsAdresse,dErstellt,nHatUpload,nZahlungsTyp,nStorno,fSkonto,kColor,nKomplettAusgeliefert)"
                strQuery &= " VALUES("
                strQuery &= "'" & iBestellung & "',"
                strQuery &= "'0',"
                strQuery &= "'" & My.Settings.login_userid.Item(My.Settings.mandant_position) & "',"
                strQuery &= "'0',"
                strQuery &= "'3',"
                strQuery &= "'" & strKID & "',"
                strQuery &= "'" & getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")) & "',"
                strQuery &= "'B',"
                strQuery &= "'0'," 'Zahlungsziel
                strQuery &= "'0'," ' Versandart
                strQuery &= "'0'," ' Versandpreis Brutto
                strQuery &= "'0'," ' Rabatt
                strQuery &= "'0'," ' Internet Bestellung
                strQuery &= "'N'," ' Internet Y/N
                strQuery &= "'EUR'," ' Währung
                strQuery &= "'1'," ' FFaktor
                strQuery &= "'0'," ' Shop 
                strQuery &= "'1'," ' Firma
                strQuery &= "'0'," ' Logistik
                strQuery &= "'1'," ' Plattform
                strQuery &= "'1'," ' Sprache
                strQuery &= "'0'," 'Gutschein 
                strQuery &= "'0'," ' Zahlart
                strQuery &= "'" & iLieferAdresse & "'," ' Lieferadresse
                strQuery &= "'" & iRechnungsAdresse & "'," ' Rechnungsadresse
                'MsgBox(DateTime.Now.ToString("yyyy-MM-dd" & " HH:mm:ss.fff"))
                'strQuery &= DateTime.Now.ToString("yyyy-MM-dd") & "," ' Erstellt
                'strQuery &= Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & "," ' Erstellt            
                strQuery &= "@date," ' Erstellt
                strQuery &= "'0'," ' nHatUpload
                strQuery &= "'0'," ' nZahlungsTyp
                strQuery &= "'0'," ' nStorno
                strQuery &= "'0'," ' fSkonto
                'strQuery &= Date.Today & "," ' Erstellt
                strQuery &= "'0','0')" ' nKomplettAusgeliefert 'kColor

                Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                sqlComm.ExecuteNonQuery()

            Else
                Dim sqlComm As New SqlCommand("spBestellungAnlegen", sqlConn)

                '# Umschalten auf Stored Procedure 
                sqlComm.CommandType = CommandType.StoredProcedure

                '# Return-Wert als Integer 
                Dim RetValue As SqlParameter = sqlComm.Parameters.Add("kBestellung", SqlDbType.Int)
                RetValue.Direction = ParameterDirection.ReturnValue

                Dim kBestellung As SqlParameter = sqlComm.Parameters.Add("@kBestellung", SqlDbType.Int)
                kBestellung.Direction = ParameterDirection.Input
                kBestellung.Value = iBestellung

                Dim kRechnung As SqlParameter = sqlComm.Parameters.Add("@kRechnung", SqlDbType.Int)
                kRechnung.Direction = ParameterDirection.Input
                kRechnung.Value = "0"



                Dim kBenutzer As SqlParameter = sqlComm.Parameters.Add("@kBenutzer", SqlDbType.Int)
                kBenutzer.Direction = ParameterDirection.Input
                kBenutzer.Value = strJTLWaWiBenutzer

                Dim kAdresse As SqlParameter = sqlComm.Parameters.Add("@kAdresse", SqlDbType.Int)
                kAdresse.Direction = ParameterDirection.Input
                kAdresse.Value = "0"

                Dim kKunde As SqlParameter = sqlComm.Parameters.Add("@kKunde", SqlDbType.Int)
                kKunde.Direction = ParameterDirection.Input
                kKunde.Value = strKID

                Dim kText As SqlParameter = sqlComm.Parameters.Add("@kText", SqlDbType.Int)
                kText.Direction = ParameterDirection.Input
                kText.Value = "3"

                Dim cBestellNr As SqlParameter = sqlComm.Parameters.Add("@cBestellNr", SqlDbType.VarChar, 40)
                cBestellNr.Direction = ParameterDirection.Input
                cBestellNr.Value = getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'"))

                Dim strcType As SqlParameter = sqlComm.Parameters.Add("@cType", SqlDbType.Char, 1)
                strcType.Direction = ParameterDirection.Input
                strcType.Value = "B"

                Dim cAnmerkung As SqlParameter = sqlComm.Parameters.Add("@cAnmerkung", SqlDbType.VarChar, 4500)
                cAnmerkung.Direction = ParameterDirection.Input
                cAnmerkung.Value = "Barzahlung JTL Bridge"

                Dim dErstellt As SqlParameter = sqlComm.Parameters.Add("@dErstellt", SqlDbType.DateTime)
                dErstellt.Direction = ParameterDirection.Input
                dErstellt.Value = Date.Now

                Dim nZahlungsziel As SqlParameter = sqlComm.Parameters.Add("@nZahlungsziel", SqlDbType.TinyInt)
                nZahlungsziel.Direction = ParameterDirection.Input
                nZahlungsziel.Value = "0"

                Dim kVersandArt As SqlParameter = sqlComm.Parameters.Add("@kVersandArt", SqlDbType.Int)
                kVersandArt.Direction = ParameterDirection.Input
                kVersandArt.Value = "0"

                Dim fVersandBruttoPreis As SqlParameter = sqlComm.Parameters.Add("@fVersandBruttoPreis", SqlDbType.Decimal)

                fVersandBruttoPreis.Direction = ParameterDirection.Input
                fVersandBruttoPreis.Value = "0"

                Dim fRabatt As SqlParameter = sqlComm.Parameters.Add("@fRabatt", SqlDbType.Decimal)
                fRabatt.Direction = ParameterDirection.Input
                fRabatt.Value = "0"

                Dim kInetBestellung As SqlParameter = sqlComm.Parameters.Add("@kInetBestellung", SqlDbType.Int)
                kInetBestellung.Direction = ParameterDirection.Input
                kInetBestellung.Value = "0"

                Dim cVersandInfo As SqlParameter = sqlComm.Parameters.Add("@cVersandInfo", SqlDbType.VarChar, 255)
                cVersandInfo.Direction = ParameterDirection.Input
                cVersandInfo.Value = ""

                Dim dVersandt As SqlParameter = sqlComm.Parameters.Add("@dVersandt", SqlDbType.DateTime)
                dVersandt.Direction = ParameterDirection.Input
                dVersandt.Value = DBNull.Value

                Dim cIdentCode As SqlParameter = sqlComm.Parameters.Add("@cIdentCode", SqlDbType.VarChar, 255)
                cIdentCode.Direction = ParameterDirection.Input
                cIdentCode.Value = ""

                Dim cBeschreibung As SqlParameter = sqlComm.Parameters.Add("@cBeschreibung", SqlDbType.Char, 1)
                cBeschreibung.Direction = ParameterDirection.Input
                cBeschreibung.Value = "N"

                Dim cInet As SqlParameter = sqlComm.Parameters.Add("@cInet", SqlDbType.Char, 1)
                cInet.Direction = ParameterDirection.Input
                cInet.Value = "N"

                Dim dLieferdatum As SqlParameter = sqlComm.Parameters.Add("@dLieferdatum", SqlDbType.DateTime)
                dLieferdatum.Direction = ParameterDirection.Input
                dLieferdatum.Value = DBNull.Value

                Dim kBestellHinweis As SqlParameter = sqlComm.Parameters.Add("@kBestellHinweis", SqlDbType.Int)
                kBestellHinweis.Direction = ParameterDirection.Input
                kBestellHinweis.Value = "0"

                Dim cErloeskonto As SqlParameter = sqlComm.Parameters.Add("@cErloeskonto", SqlDbType.VarChar, 64)
                cErloeskonto.Direction = ParameterDirection.Input
                cErloeskonto.Value = ""

                Dim cWaehrung As SqlParameter = sqlComm.Parameters.Add("@cWaehrung", SqlDbType.VarChar, 20)
                cWaehrung.Direction = ParameterDirection.Input
                cWaehrung.Value = "EUR"

                Dim fFaktor As SqlParameter = sqlComm.Parameters.Add("@fFaktor", SqlDbType.Decimal)
                fFaktor.Direction = ParameterDirection.Input
                fFaktor.Value = "1"

                Dim kShop As SqlParameter = sqlComm.Parameters.Add("@kShop", SqlDbType.Int)
                kShop.Direction = ParameterDirection.Input
                kShop.Value = "0"

                Dim kFirma As SqlParameter = sqlComm.Parameters.Add("@kFirma", SqlDbType.Int)
                kFirma.Direction = ParameterDirection.Input
                kFirma.Value = "1"

                Dim kLogistik As SqlParameter = sqlComm.Parameters.Add("@kLogistik", SqlDbType.Int)
                kLogistik.Direction = ParameterDirection.Input
                kLogistik.Value = "0"

                Dim nPlatform As SqlParameter = sqlComm.Parameters.Add("@nPlatform", SqlDbType.TinyInt)
                nPlatform.Direction = ParameterDirection.Input
                nPlatform.Value = "1"

                Dim kSprache As SqlParameter = sqlComm.Parameters.Add("@kSprache", SqlDbType.Int)
                kSprache.Direction = ParameterDirection.Input
                kSprache.Value = "1"

                Dim fGutschein As SqlParameter = sqlComm.Parameters.Add("@fGutschein", SqlDbType.Decimal)
                fGutschein.Direction = ParameterDirection.Input
                fGutschein.Value = "0"

                Dim dGedruckt As SqlParameter = sqlComm.Parameters.Add("@dGedruckt", SqlDbType.DateTime)
                dGedruckt.Direction = ParameterDirection.Input
                dGedruckt.Value = DBNull.Value

                Dim dMailVersandt As SqlParameter = sqlComm.Parameters.Add("@dMailVersandt", SqlDbType.DateTime)
                dMailVersandt.Direction = ParameterDirection.Input
                dMailVersandt.Value = DBNull.Value

                Dim cInetBestellnr As SqlParameter = sqlComm.Parameters.Add("@cInetBestellnr", SqlDbType.VarChar, 50)
                cInetBestellnr.Direction = ParameterDirection.Input
                cInetBestellnr.Value = ""

                Dim kZahlungsArt As SqlParameter = sqlComm.Parameters.Add("@kZahlungsArt", SqlDbType.Int)
                kZahlungsArt.Direction = ParameterDirection.Input
                kZahlungsArt.Value = "1" 'BAR

                Dim kLieferAdresse As SqlParameter = sqlComm.Parameters.Add("@kLieferAdresse", SqlDbType.Int)
                kLieferAdresse.Direction = ParameterDirection.Input
                kLieferAdresse.Value = iLieferAdresse

                Dim kRechnungsAdresse As SqlParameter = sqlComm.Parameters.Add("@kRechnungsAdresse", SqlDbType.Int)
                kRechnungsAdresse.Direction = ParameterDirection.Input
                kRechnungsAdresse.Value = iRechnungsAdresse

                Dim nIGL As SqlParameter = sqlComm.Parameters.Add("@nIGL", SqlDbType.TinyInt)
                nIGL.Direction = ParameterDirection.Input
                nIGL.Value = "0"

                Dim nUStFrei As SqlParameter = sqlComm.Parameters.Add("@nUStFrei", SqlDbType.TinyInt)
                nUStFrei.Direction = ParameterDirection.Input
                nUStFrei.Value = "0"

                Dim cStatus As SqlParameter = sqlComm.Parameters.Add("@cStatus", SqlDbType.VarChar, 255)
                cStatus.Direction = ParameterDirection.Input
                cStatus.Value = ""

                Dim dVersandMail As SqlParameter = sqlComm.Parameters.Add("@dVersandMail", SqlDbType.DateTime)
                dVersandMail.Direction = ParameterDirection.Input
                dVersandMail.Value = DBNull.Value

                Dim dZahlungsMail As SqlParameter = sqlComm.Parameters.Add("@dZahlungsMail", SqlDbType.DateTime)
                dZahlungsMail.Direction = ParameterDirection.Input
                dZahlungsMail.Value = DBNull.Value

                Dim cUserName As SqlParameter = sqlComm.Parameters.Add("@cUserName", SqlDbType.VarChar, 255)
                cUserName.Direction = ParameterDirection.Input
                cUserName.Value = ""

                Dim cVerwendungszweck As SqlParameter = sqlComm.Parameters.Add("@cVerwendungszweck", SqlDbType.VarChar, 255)
                cVerwendungszweck.Direction = ParameterDirection.Input
                cVerwendungszweck.Value = ""

                Dim fSkonto As SqlParameter = sqlComm.Parameters.Add("@fSkonto", SqlDbType.Decimal)
                fSkonto.Direction = ParameterDirection.Input
                fSkonto.Value = "0"



                Dim kColor As SqlParameter = sqlComm.Parameters.Add("@kColor", SqlDbType.Int)
                kColor.Direction = ParameterDirection.Input
                kColor.Value = "0"

                Dim nStorno As SqlParameter = sqlComm.Parameters.Add("@nStorno", SqlDbType.TinyInt)
                nStorno.Direction = ParameterDirection.Input
                nStorno.Value = "0"

                Dim cModulID As SqlParameter = sqlComm.Parameters.Add("@cModulID", SqlDbType.VarChar, 255)
                cModulID.Direction = ParameterDirection.Input
                cModulID.Value = ""

                Dim nZahlungsTyp As SqlParameter = sqlComm.Parameters.Add("@nZahlungsTyp", SqlDbType.Int)
                nZahlungsTyp.Direction = ParameterDirection.Input
                nZahlungsTyp.Value = "0"

                Dim nHatUpload As SqlParameter = sqlComm.Parameters.Add("@nHatUpload", SqlDbType.Int)
                nHatUpload.Direction = ParameterDirection.Input
                nHatUpload.Value = "0"

                Dim fZusatzGewicht As SqlParameter = sqlComm.Parameters.Add("@fZusatzGewicht", SqlDbType.Decimal)
                fZusatzGewicht.Direction = ParameterDirection.Input
                fZusatzGewicht.Value = "0"

                Dim nKomplettAusgeliefert As SqlParameter = sqlComm.Parameters.Add("@nKomplettAusgeliefert", SqlDbType.TinyInt)
                nKomplettAusgeliefert.Direction = ParameterDirection.Input
                nKomplettAusgeliefert.Value = "0"

                Dim dBezahlt As SqlParameter = sqlComm.Parameters.Add("@dBezahlt", SqlDbType.DateTime)
                dBezahlt.Direction = ParameterDirection.Input
                dBezahlt.Value = DBNull.Value

                Dim kSplitBestellung As SqlParameter = sqlComm.Parameters.Add("@kSplitBestellung", SqlDbType.Int)
                kSplitBestellung.Direction = ParameterDirection.Input
                kSplitBestellung.Value = "0"

                Dim cPUIZahlungsdaten As SqlParameter = sqlComm.Parameters.Add("@cPUIZahlungsdaten", SqlDbType.VarChar, 100000)
                cPUIZahlungsdaten.Direction = ParameterDirection.Input
                cPUIZahlungsdaten.Value = ""

                Dim nPrio As SqlParameter = sqlComm.Parameters.Add("@nPrio", SqlDbType.TinyInt)
                nPrio.Direction = ParameterDirection.Input
                nPrio.Value = "0"

                Dim cVersandlandISO As SqlParameter = sqlComm.Parameters.Add("@cVersandlandISO", SqlDbType.VarChar, 5)
                cVersandlandISO.Direction = ParameterDirection.Input
                cVersandlandISO.Value = "DE"

                Dim cUstId As SqlParameter = sqlComm.Parameters.Add("@cUstId", SqlDbType.VarChar, 25)
                cUstId.Direction = ParameterDirection.Input
                cUstId.Value = ""

                Dim nPremium As SqlParameter = sqlComm.Parameters.Add("@nPremium", SqlDbType.TinyInt)
                nPremium.Direction = ParameterDirection.Input
                nPremium.Value = "0"

                Dim kRueckhalteGrund As SqlParameter = sqlComm.Parameters.Add("@kRueckhalteGrund", SqlDbType.Int)
                kRueckhalteGrund.Direction = ParameterDirection.Input
                kRueckhalteGrund.Value = "0"

                'Dim kBestellung As SqlParameter = sqlComm.Parameters.Add("@kBestellung", SqlDbType.Int)
                'kBestellung.Direction = ParameterDirection.Input
                'kBestellung.Value = strJTLWaWiBenutzer


                'sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                sqlComm.Parameters("@fVersandBruttoPreis").Precision = 28
                sqlComm.Parameters("@fVersandBruttoPreis").Scale = 14

                sqlComm.Parameters("@fRabatt").Precision = 28
                sqlComm.Parameters("@fRabatt").Scale = 14

                sqlComm.Parameters("@fGutschein").Precision = 28
                sqlComm.Parameters("@fGutschein").Scale = 14

                sqlComm.Parameters("@fZusatzGewicht").Precision = 28
                sqlComm.Parameters("@fZusatzGewicht").Scale = 14

                sqlComm.ExecuteNonQuery()
            End If


            '# Fortlaufende Auftragsnummer erhöhen 
            If Not strTabelle = "cubss_rechnung_bestellung" Then
                Dim iNummer As Integer = getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")
                iNummer += 1
                If IsNumeric(iNummer) = True Then
                    Call setLftNummer_update("tLaufendeNummern", "WHERE cName='Auftrag'", iNummer)
                Else
                    MessageBox.Show("Fehler beim Update der Laufenden Nummern!" & vbCrLf & "Bitte öffnen Sie umgehend die JTL Einstellungen -> Allgemeine Einstellungen -> Startnummern und überprüfen die nächste folgende Nummer!", "setBestellung_header", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

            Return iBestellung
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Speichern der Bestellkopfdaten!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function getArtikel_nr2ID(ByVal strArtikelNr As String) As Integer
        Try
            Dim iNr As Integer = 0

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strData As String = ""
            Dim sqlComm As New SqlCommand("SELECT kArtikel FROM tartikel WHERE cArtNr='" & strArtikelNr & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("kArtikel").ToString
            End While

            iNr = CInt(strData)
            sqlConn.Close()

            Return iNr
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function setDeleteArchiv_bestellung(strKBestellung As String, strKundenID As String) As Boolean

        Dim strQuery As String = ""
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()

        Dim strData As String = ""

        Dim sqlComm As New SqlCommand("SELECT count(*) as anzahl FROM cubss_rechnung_kunde  WHERE cKundenNr='" & strKundenID & "'", sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()
        Dim iAnzahlBestellungenproKunden As Integer = 0
        While r.Read()
            iAnzahlBestellungenproKunden = r("anzahl").ToString
        End While

        If (iAnzahlBestellungenproKunden <= 1) Then
            Dim sqlConn3 As New SqlConnection(strConnectionString)
            sqlConn3.Open()
            Dim sqlComm3 As New SqlCommand("DELETE FROM cubss_rechnung_kunde WHERE cKundenNr='" & strKundenID & "'", sqlConn3)
            sqlComm3.ExecuteNonQuery()
            sqlConn3.Close()
        End If

        sqlConn.Close()

        Dim sqlConn1 As New SqlConnection(strConnectionString)
        sqlConn1.Open()
        Dim sqlComm1 As New SqlCommand("DELETE FROM cubss_rechnung_bestellung_pos WHERE tBestellung_kBestellung=" & strKBestellung, sqlConn1)
        sqlComm1.ExecuteNonQuery()
        sqlConn1.Close()

        Dim sqlConn2 As New SqlConnection(strConnectionString)
        sqlConn2.Open()
        Dim sqlComm2 As New SqlCommand("DELETE FROM cubss_rechnung_bestellung WHERE kBestellung=" & strKBestellung, sqlConn2)
        sqlComm2.ExecuteNonQuery()
        sqlConn2.Close()

    End Function

    '#######################################################################################
    '# >> Archiv abrufen Liste
    '#######################################################################################
    Public Function getArchiv(ByVal lvwData As ListView, ByVal strWhere As String, ByVal lblMessage As Label, dErstellt_am As DateTimePicker, Optional bAllArticles As Boolean = False) As Boolean
        Try
            lvwData.Items.Clear()
            Dim strQuery As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim strData As String = ""
            ',CAST(@dErstellt AS DATE) as dErstellt 
            Dim sqlComm As New SqlCommand("SELECT * FROM cubss_rechnung_bestellung JOIN cubss_rechnung_bestellung_pos ON cubss_rechnung_bestellung.kBestellung = cubss_rechnung_bestellung_pos.tBestellung_kBestellung JOIN  cubss_rechnung_kunde ON cubss_rechnung_bestellung.tKunde_kKunde = cubss_rechnung_kunde.kKunde " & strWhere & " ORDER BY dErstellt DESC", sqlConn)
            Dim ddatum As DateTime = dErstellt_am.Value.ToString("yyyy-MM-dd")

            sqlComm.Parameters.Add("@dErstelltam", SqlDbType.DateTime).Value = dErstellt_am.Value.ToString("yyyy-MM-dd")
            sqlComm.Parameters.Add("@dErstelltam2", SqlDbType.DateTime).Value = dErstellt_am.Value.AddDays(+1).ToString("yyyy-MM-dd")

            Dim r As SqlDataReader = sqlComm.ExecuteReader()
            'JOIN tBenutzer ON tBenutzer.kBenutzer = cubss_rechnung_bestellung.tBenutzer_kBenutzer
            Dim bImported As Boolean = False
            Dim iCount As Integer = 0
            Dim dblSumme As Double = 0
            Dim strBestellID As String = ""
            While r.Read()
                Dim lvwItem As New ListViewItem
                If r("bImported").ToString = "1" Then
                    lvwItem.BackColor = Color.PapayaWhip
                    bImported = True
                End If

                iCount += 1
                dblSumme += CDbl(r("fVKPreis").ToString.Replace(".", ","))

                If Not r("kBestellung").ToString = strBestellID Or bAllArticles = True Then

                    strBestellID = r("kBestellung").ToString

                    lvwItem.Text = r("cString").ToString
                    lvwItem.SubItems.Add(r("fVKPreis").ToString)
                    lvwItem.SubItems.Add(r("cName").ToString)
                    lvwItem.SubItems.Add(r("kBestellung").ToString)
                    lvwItem.SubItems.Add(r("cOrt").ToString)
                    lvwItem.SubItems.Add(r("nAnzahl").ToString)
                    lvwItem.SubItems.Add(r("dErstellt").ToString)
                    lvwItem.SubItems.Add(r("cKundenNr").ToString)
                    lvwItem.SubItems.Add(r("cPLZ").ToString)
                    lvwItem.SubItems.Add(r("cStrasse").ToString)
                    lvwItem.SubItems.Add(r("cVorname").ToString)
                    lvwItem.SubItems.Add(r("cEMail").ToString)
                    lvwItem.SubItems.Add(r("cTel").ToString)
                    lvwItem.SubItems.Add(r("cLand").ToString)
                    lvwItem.SubItems.Add(r("cFirma").ToString)
                    lvwItem.SubItems.Add(r("dImported").ToString)
                    '  lvwItem.SubItems.Add(r("cLogin").ToString)
                    lvwItem.SubItems.Add("")
                    lvwItem.SubItems.Add(r("cArtNr").ToString)
                    lvwItem.SubItems.Add(r("fVKNetto").ToString)
                    lvwItem.SubItems.Add(r("fMwSt").ToString)
                    lvwData.Items.Add(lvwItem)
                End If

            End While

            '# Zusätzliche Information anzeigen 
            If bImported = True Then
                lvwData.Columns(15).Width = 120
                lvwData.Columns(15).DisplayIndex = 0
            Else
                lvwData.Columns(15).Width = 0
            End If

            If lvwData.Items.Count > 0 Then
                lvwData.Items(0).Selected = True
            End If

            lblMessage.Text = "Artikel: " & iCount & " | Umsatz: " & dblSumme.ToString("C")

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler holen des Archivs!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Kundennummer zu ID 
    '####################################################################
    Public Function getKunde_Nr2ID(ByVal strKNr As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim strData As String = "-1"
            Dim sqlComm As New SqlCommand("SELECT * FROM tkunde WHERE cKundenNr='" & strKNr & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("kKunde").ToString
            End While

            sqlConn.Close()
            Return strData
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Kundennummer abrufen", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Bestellung Import Kunde 
    '####################################################################
    Public Function setBestellung_import_kunde() As Boolean
        Try

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Kundenimport", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Bestellung Import Header
    '####################################################################
    Public Function setBestellung_import_bestellHeader(ByVal strKID As String, ByVal iBestellungID As Integer) As Integer
        Try
            Dim iBestellung As Integer = getJTLID_MAX("tbestellung", "kBestellung")
            Dim strQuery As String = ""
            Dim iLieferAdresse As Integer = 0
            Dim iRechnungsAdresse As Integer = 0
            Dim reader As SqlDataReader
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            '# Keine Lieferadresse / Rechnungsaddresse 
            iLieferAdresse = getAdressKEYS("tlieferadresse", "kLieferAdresse", strKID)
            iRechnungsAdresse = getAdressKEYS("trechnungsadresse", "kRechnungsAdresse", strKID)

            '# Positionen abrufen 
            strQuery = "SELECT * FROM cubss_rechnung_bestellung WHERE kBestellung=" & iBestellungID
            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            reader = sqlComm.ExecuteReader()

            While reader.Read()
                strQuery = "INSERT INTO tbestellung(kBestellung,tRechnung_kRechnung,tBenutzer_kBenutzer,tAdresse_kAdresse,tText_kText,tKunde_kKunde,cBestellNr,cType,nZahlungsziel,tVersandArt_kVersandArt,fVersandBruttoPreis,fRabatt,kInetBestellung,cInet,cWaehrung,fFaktor,kShop,kFirma,kLogistik,nPlatform,kSprache,fGutschein,kZahlungsArt,kLieferAdresse,kRechnungsAdresse,dErstellt,nHatUpload,nZahlungsTyp,nStorno,fSkonto,kColor,nKomplettAusgeliefert)"
                strQuery &= " VALUES("
                strQuery &= "'" & iBestellung & "',"
                strQuery &= "'0',"
                strQuery &= "'" & reader("tBenutzer_kBenutzer").ToString & "',"
                strQuery &= "'0',"
                strQuery &= "'3',"
                strQuery &= "'" & strKID & "',"
                strQuery &= "'" & getJTLNumber(My.Settings.nr_auftrag_prefix.Item(My.Settings.mandant_position), My.Settings.nr_auftrag_suffix.Item(My.Settings.mandant_position), getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")) & "',"
                strQuery &= "'B',"
                strQuery &= "'0'," 'Zahlungsziel
                strQuery &= "'0'," ' Versandart
                strQuery &= "'0'," ' Versandpreis Brutto
                strQuery &= "'0'," ' Rabatt
                strQuery &= "'0'," ' Internet Bestellung
                strQuery &= "'N'," ' Internet Y/N
                strQuery &= "'EUR'," ' Währung
                strQuery &= "'1'," ' FFaktor
                strQuery &= "'0'," ' Shop 
                strQuery &= "'1'," ' Firma
                strQuery &= "'0'," ' Logistik
                strQuery &= "'1'," ' Plattform
                strQuery &= "'1'," ' Sprache
                strQuery &= "'0'," 'Gutschein 
                strQuery &= "'0'," ' Zahlart
                strQuery &= "'" & iLieferAdresse & "'," ' Lieferadresse
                strQuery &= "'" & iRechnungsAdresse & "'," ' Rechnungsadresse
                'MsgBox(DateTime.Now.ToString("yyyy-MM-dd" & " HH:mm:ss.fff"))
                'strQuery &= DateTime.Now.ToString("yyyy-MM-dd") & "," ' Erstellt
                'strQuery &= Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & "," ' Erstellt            
                strQuery &= "@date," ' Erstellt
                strQuery &= "'0'," ' nHatUpload
                strQuery &= "'0'," ' nZahlungsTyp
                strQuery &= "'0'," ' nStorno
                strQuery &= "'0'," ' fSkonto
                'strQuery &= Date.Today & "," ' Erstellt
                strQuery &= "'0','0')"

                Dim sqlConn2 As New SqlConnection(strConnectionString)
                sqlConn2.Open()
                Dim sqlComm2 As New SqlCommand(strQuery, sqlConn2)
                sqlComm2.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                sqlComm2.ExecuteNonQuery()
                sqlConn2.Close()

                '# Fortlaufende Auftragsnummer erhöhen 
                Dim iNummer As Integer = getLftNummer("tLaufendeNummern", "WHERE cName='Auftrag'")
                iNummer += 1
                Call setLftNummer_update("tLaufendeNummern", "WHERE cName='Auftrag'", iNummer)

            End While

            sqlConn.Close()
            Return iBestellung
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Speichern der Bestellkopfdaten!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    '####################################################################
    '# >> Bestellung Import Data
    '####################################################################
    Public Function setBestellung_import_bestellPos(ByVal iBestellungID_illixi As Integer, ByVal iBestellungID_master As Integer) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""
            Dim iCount As Integer = 0
            Dim reader As SqlDataReader

            '# 
            If IsNumeric(iBestellungID_illixi) = False Then
                MessageBox.Show("Bestellnummer fehlt", "Fehler keine BestellID gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            '# Positionen abrufen 
            strQuery = "SELECT * FROM cubss_rechnung_bestellung_pos WHERE tBestellung_kBestellung=" & iBestellungID_illixi
            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            reader = sqlComm.ExecuteReader()

            While reader.Read()

                strQuery = "INSERT INTO tbestellpos(kBestellPos, tArtikel_kArtikel,tBestellung_kBestellung,fVKPreis,fMwSt,nAnzahl,fRabatt,cString,fVKNetto,cArtNr,nType,cHinweis,nHatUpload)"
                strQuery &= " VALUES("
                strQuery &= "" & getJTLID_MAX("tbestellpos", "kBestellPos") & "," ' ID holen
                strQuery &= "" & reader("tArtikel_kArtikel").ToString & "," ' Artikel ID 
                strQuery &= "" & iBestellungID_master & "," ' Bestell ID Header                
                strQuery &= "" & CDbl(reader("fVKPreis").ToString) & "," ' Preis
                strQuery &= "" & CDbl(reader("fMwSt").ToString) & "," ' Mwst
                strQuery &= "" & CInt(reader("nAnzahl").ToString) & "," ' Anzahl
                strQuery &= "0," ' Rabatt
                strQuery &= "'" & reader("cString").ToString & "'," ' Name
                strQuery &= "" & reader("fVKNetto").ToString & "," ' Netto
                strQuery &= "'" & reader("cArtNr").ToString & "'," ' Artikelnummer
                strQuery &= "1," ' nType
                strQuery &= "''," ' Hinweise
                strQuery &= "0)" ' Hatupload 

                Dim sqlConn2 As New SqlConnection(strConnectionString)
                sqlConn2.Open()
                Dim sqlComm2 As New SqlCommand(strQuery, sqlConn2)
                'sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                sqlComm2.ExecuteNonQuery()
                sqlConn2.Close()

            End While

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Speichern der Bestellkopfdaten!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '####################################################################
    '# >> Bestellung Data
    '####################################################################
    Public Function setBestellung_data(ByVal dgv As DataGridView, ByVal iBestellungID As Integer, ByVal strTabelle As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = ""
            Dim iCount As Integer = 0
            Dim iLoopMax As Integer

            If My.Settings.dvgArtikel_allowAddRow.Item(My.Settings.mandant_position) = True Then
                iLoopMax = 2
            Else
                iLoopMax = 1
            End If




            For iCount = 0 To dgv.Rows.Count - iLoopMax

                If strTabelle.Contains("cubss_") = True Then
                    'kBestellpos,
                    strQuery = "INSERT INTO " & strTabelle & "(tArtikel_kArtikel,tBestellung_kBestellung,fVKPreis,fMwSt,nAnzahl,fRabatt,cString,fVKNetto,cArtNr,nType,cHinweis,nHatUpload)"
                    strQuery &= " VALUES("
                    '  strQuery &= "" & getJTLID_MAX(strTabelle, "kBestellPos") & "," ' ID holen
                    strQuery &= "" & getArtikel_nr2ID(dgv.Rows(iCount).Cells(3).Value) & "," ' Artikel ID 
                    strQuery &= "" & iBestellungID & "," ' Bestell ID Header                
                    strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(6).Value).ToString.Replace(",", ".") & "," ' Preis
                    strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(10).Value) & "," ' Mwst
                    strQuery &= "" & CInt(dgv.Rows(iCount).Cells(2).Value) & "," ' Anzahl
                    strQuery &= "0," ' Rabatt
                    strQuery &= "'" & dgv.Rows(iCount).Cells(4).Value & "'," ' Name
                    strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(5).Value).ToString.Replace(",", ".") & "," ' Netto
                    strQuery &= "'" & dgv.Rows(iCount).Cells(3).Value & "'," ' Artikelnummer
                    strQuery &= "1," ' nType
                    strQuery &= "''," ' Hinweise
                    strQuery &= "0)" ' Hatupload

                    '    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)

                    Dim kBestellpos As SqlParameter = sqlComm.Parameters.Add("@kBestellpos", SqlDbType.Int)
                    kBestellpos.Direction = ParameterDirection.Input
                    kBestellpos.Value = getJTLID_MAX(strTabelle, "kBestellPos")
                    sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                    sqlComm.ExecuteNonQuery()

                Else

                    Dim sqlComm As New SqlCommand("spBestellposAnlegen", sqlConn)

                    '# Umschalten auf Stored Procedure 
                    sqlComm.CommandType = CommandType.StoredProcedure

                    Dim RetValue As SqlParameter = sqlComm.Parameters.Add("kBestellpos", SqlDbType.Int)
                    RetValue.Direction = ParameterDirection.ReturnValue


                    Dim kBestellung As SqlParameter = sqlComm.Parameters.Add("@kBestellung", SqlDbType.Int)
                    kBestellung.Direction = ParameterDirection.Input
                    kBestellung.Value = iBestellungID

                    Dim kArtikel As SqlParameter = sqlComm.Parameters.Add("@kArtikel", SqlDbType.Int)
                    kArtikel.Direction = ParameterDirection.Input
                    kArtikel.Value = getArtikel_nr2ID(dgv.Rows(iCount).Cells(3).Value)

                    Dim fVKPreis As SqlParameter = sqlComm.Parameters.Add("@fVKPreis", SqlDbType.Decimal)
                    fVKPreis.Direction = ParameterDirection.Input
                    fVKPreis.Value = CDbl(dgv.Rows(iCount).Cells(6).Value).ToString.Replace(",", ".")

                    Dim fMwSt As SqlParameter = sqlComm.Parameters.Add("@fMwSt", SqlDbType.Decimal)
                    fMwSt.Direction = ParameterDirection.Input
                    fMwSt.Value = CDbl(dgv.Rows(iCount).Cells(10).Value).ToString.Replace(",", ".")

                    Dim nAnzahl As SqlParameter = sqlComm.Parameters.Add("@nAnzahl", SqlDbType.Decimal)
                    nAnzahl.Direction = ParameterDirection.Input
                    nAnzahl.Value = CInt(dgv.Rows(iCount).Cells(2).Value)

                    Dim fRabatt As SqlParameter = sqlComm.Parameters.Add("@fRabatt", SqlDbType.Decimal)
                    fRabatt.Direction = ParameterDirection.Input
                    fRabatt.Value = "0"

                    Dim cString As SqlParameter = sqlComm.Parameters.Add("@cString", SqlDbType.VarChar, 255)
                    cString.Direction = ParameterDirection.Input
                    cString.Value = dgv.Rows(iCount).Cells(4).Value

                    Dim fVKNetto As SqlParameter = sqlComm.Parameters.Add("@fVKNetto", SqlDbType.Decimal)
                    fVKNetto.Direction = ParameterDirection.Input
                    fVKNetto.Value = CDbl(dgv.Rows(iCount).Cells(5).Value).ToString.Replace(",", ".")

                    Dim cArtNr As SqlParameter = sqlComm.Parameters.Add("@cArtNr", SqlDbType.VarChar, 100)
                    cArtNr.Direction = ParameterDirection.Input
                    cArtNr.Value = dgv.Rows(iCount).Cells(3).Value

                    Dim nType As SqlParameter = sqlComm.Parameters.Add("@nType", SqlDbType.TinyInt)
                    nType.Direction = ParameterDirection.Input
                    nType.Value = "1"

                    Dim cHinweis As SqlParameter = sqlComm.Parameters.Add("@cHinweis", SqlDbType.VarChar, 2000)
                    cHinweis.Direction = ParameterDirection.Input
                    cHinweis.Value = ""

                    Dim nHatUpload As SqlParameter = sqlComm.Parameters.Add("@nHatUpload", SqlDbType.TinyInt)
                    nHatUpload.Direction = ParameterDirection.Input
                    nHatUpload.Value = "0"

                    '########## ??????????????????????? NEU
                    Dim cUnique As SqlParameter = sqlComm.Parameters.Add("@cUnique", SqlDbType.VarChar, 30)
                    cUnique.Direction = ParameterDirection.Input
                    cUnique.Value = ""

                    Dim kKonfigitem As SqlParameter = sqlComm.Parameters.Add("@kKonfigitem", SqlDbType.Int)
                    kKonfigitem.Direction = ParameterDirection.Input
                    kKonfigitem.Value = "0"

                    Dim nDropshipping As SqlParameter = sqlComm.Parameters.Add("@nDropshipping", SqlDbType.TinyInt)
                    nDropshipping.Direction = ParameterDirection.Input
                    nDropshipping.Value = "0"


                    Dim fEkNetto As SqlParameter = sqlComm.Parameters.Add("@fEkNetto", SqlDbType.Decimal)
                    fEkNetto.Direction = ParameterDirection.Input
                    fEkNetto.Value = "0"

                    Dim cOrderItemId As SqlParameter = sqlComm.Parameters.Add("@cOrderItemId", SqlDbType.VarChar, 255)
                    cOrderItemId.Direction = ParameterDirection.Input
                    cOrderItemId.Value = ""

                    Dim cItemId As SqlParameter = sqlComm.Parameters.Add("@cItemId", SqlDbType.VarChar, 255)
                    cItemId.Direction = ParameterDirection.Input
                    cItemId.Value = ""

                    Dim cTransactionID As SqlParameter = sqlComm.Parameters.Add("@cTransactionID", SqlDbType.VarChar, 255)
                    cTransactionID.Direction = ParameterDirection.Input
                    cTransactionID.Value = ""

                    Dim kAmazonBestellungPos As SqlParameter = sqlComm.Parameters.Add("@kAmazonBestellungPos", SqlDbType.Int)
                    kAmazonBestellungPos.Direction = ParameterDirection.Input
                    kAmazonBestellungPos.Value = "0"

                    Dim nSort As SqlParameter = sqlComm.Parameters.Add("@nSort", SqlDbType.Int)
                    nSort.Direction = ParameterDirection.Input
                    nSort.Value = "1"

                    Dim kBestellStueckliste As SqlParameter = sqlComm.Parameters.Add("@kBestellStueckliste", SqlDbType.Int)
                    kBestellStueckliste.Direction = ParameterDirection.Input
                    kBestellStueckliste.Value = "0"

                    Dim cEinheit As SqlParameter = sqlComm.Parameters.Add("@cEinheit", SqlDbType.VarChar, 255)
                    cEinheit.Direction = ParameterDirection.Input
                    cEinheit.Value = "0"

                    '# n = nummer kein Wert gefunden -> 
                    Dim nEckDatenNichtAktualisieren As SqlParameter = sqlComm.Parameters.Add("@nEckDatenNichtAktualisieren", SqlDbType.TinyInt)
                    nEckDatenNichtAktualisieren.Direction = ParameterDirection.Input
                    nEckDatenNichtAktualisieren.Value = "0"

                    'Dim kBestellpos As SqlParameter = sqlComm.Parameters.Add("@kBestellpos", SqlDbType.TinyInt)
                    'kBestellpos.Direction = ParameterDirection.Input
                    'kBestellpos.Value = getJTLID_MAX(strTabelle, "kBestellPos")

                    'kBestellPos,
                    'strQuery = "INSERT INTO " & strTabelle & "(tArtikel_kArtikel,tBestellung_kBestellung,fVKPreis,fMwSt,nAnzahl,fRabatt,cString,fVKNetto,cArtNr,nType,cHinweis,nHatUpload)"
                    'strQuery &= " VALUES("
                    ''  strQuery &= "" & getJTLID_MAX(strTabelle, "kBestellPos") & "," ' ID holen
                    'strQuery &= "" & getArtikel_nr2ID(dgv.Rows(iCount).Cells(3).Value) & "," ' Artikel ID 
                    'strQuery &= "" & iBestellungID & "," ' Bestell ID Header                
                    'strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(6).Value).ToString.Replace(",", ".") & "," ' Preis
                    'strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(10).Value) & "," ' Mwst
                    'strQuery &= "" & CInt(dgv.Rows(iCount).Cells(2).Value) & "," ' Anzahl
                    'strQuery &= "0," ' Rabatt
                    'strQuery &= "'" & dgv.Rows(iCount).Cells(4).Value & "'," ' Name
                    'strQuery &= "" & CDbl(dgv.Rows(iCount).Cells(5).Value).ToString.Replace(",", ".") & "," ' Netto
                    'strQuery &= "'" & dgv.Rows(iCount).Cells(3).Value & "'," ' Artikelnummer
                    'strQuery &= "1," ' nType
                    'strQuery &= "''," ' Hinweise
                    'strQuery &= "0)" ' Hatupload

                    ''    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    'sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
                    sqlComm.ExecuteNonQuery()
                End If


            Next


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Fehler beim Speichern der Bestellkopfdaten!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '#######################################################################
    '# >> Importiert setzen 
    '#######################################################################
    Public Function setBestellung_imported(ByVal iBestellung_id As Integer) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = "UPDATE cubss_rechnung_bestellung SET bImported='1',dImported=@date WHERE kBestellung=" & iBestellung_id

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now
            sqlComm.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Importiert setzen", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '#######################################################################
    '# >> Lagerbestand Gesammt übertragen
    '#######################################################################
    Public Function setArtikel_Lagerbestand(ByVal strkArtikelID As String, ByVal strLagerbestand As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = "UPDATE tlagerbestand SET fLagerbestand=" & strLagerbestand & " WHERE kArtikel=" & strkArtikelID

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei setArtikel_lagerbestand()", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '#######################################################################
    '# >> Lagerbestand Verfügbar übertragen
    '#######################################################################
    Public Function setArtikel_Lagerbestand_verfügbar(ByVal strkArtikelID As String, ByVal strLagerbestandVerfügbar As String) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim strQuery As String = "UPDATE tlagerbestand SET fVerfuegbar=" & strLagerbestandVerfügbar & " WHERE kArtikel=" & strkArtikelID

            Dim sqlComm As New SqlCommand(strQuery, sqlConn)
            sqlComm.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei setArtikel_lagerbestand()", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    '#######################################################################
    '# >> Bestand holen
    '#######################################################################
    Public Function getLagerBestandLagerGes(strArtikelID As String) As Double
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim strData As Double = -1
            Dim sqlComm As New SqlCommand("SELECT * FROM tlagerbestand WHERE kArtikel='" & strArtikelID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("fLagerbestand").ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei getLagerBestandVerfuegbar()", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '#######################################################################
    '# >> Verfügbar holen
    '#######################################################################
    Public Function getLagerBestandVerfuegbar(strArtikelID As String) As Double
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim strData As Double = -1
            Dim sqlComm As New SqlCommand("SELECT * FROM tlagerbestand WHERE kArtikel='" & strArtikelID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                strData = r("fVerfuegbar").ToString
            End While

            sqlConn.Close()
            Return strData

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei getLagerBestandVerfuegbar()", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    '############################################################################################################################################################################################################################
    '# >> Mandanten Steuerung + UPDATE Steuerung 
    '############################################################################################################################################################################################################################

    '##########################################################
    '# >> Existiert der Mandant welcher eingelesen wird
    '##########################################################
    Public Function chkMandantExists(ByVal strMandant_db As String) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("USE " & strMandant_db, sqlConn)
            sqlComm.ExecuteNonQuery()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '##########################################################
    '# >> chkMandantPosition
    '# Mandanten Position innerhalb der tMandant bestimmen
    '##########################################################
    Public Function chkMandantPosition(ByVal strMandantDBName As String) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
            Dim iCount As Byte = 0
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant WHERE cDB='" & strMandantDBName & "' ORDER BY cNAME ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If chkMandantExists(r("cdb").ToString) = True Then
                    If strMandantDBName = r("cDB").ToString Then
                        My.Settings.mandant_position = r("kMandant").ToString
                        My.Settings.Save()
                        Exit While
                    End If
                End If
                iCount += 1
            End While

            Return My.Settings.mandant_position
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei chkMandantPosition abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    '##########################################################
    '# >> setMandantbyCombobox
    '# Mandanten in Combobox einlesen
    '##########################################################
    Public Function setMandantbyCombobox(ByVal cmbMandant As ComboBox, ByVal bAllDBs As Boolean) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
            sqlConn.Open()

            '# Combobox löschen 
            cmbMandant.Items.Clear()
            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant ORDER BY cNAME ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                '# Prüfen ob Datenbank überhaupt angelegt ist 
                If chkMandantExists(r("cDB").ToString) = True Then
                    Dim lvwItem As New ListViewItem

                    '# Nur Verfügbare Datenbanken eintragen, wenn Setting gefunden wurde und bAllDbs nicht True ist 
                    If bAllDBs = True Then
                        cmbMandant.Items.Add(r("cName").ToString)
                    Else
                        If frmJTLRechnung.getMySettingsPositionByDatabase(r("cDB").ToString) >= 0 Then
                            cmbMandant.Items.Add(r("cName").ToString)
                        End If
                    End If

                End If
            End While

            If cmbMandant.Items.Count > 0 Then
                If cmbMandant.Items.Count - 1 > 0 Then
                    For i As Byte = 0 To cmbMandant.Items.Count - 1
                        If My.Settings.mandant_letzter_name = cmbMandant.Items(i) Then
                            cmbMandant.SelectedIndex = i
                            My.Settings.mandant_letzter_name = cmbMandant.Text
                            Exit For
                        End If
                    Next
                Else
                    cmbMandant.SelectedIndex = 0
                    My.Settings.mandant_letzter_name = cmbMandant.Text
                End If

            End If
            My.Settings.Save()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim JTL Mandant abrufen getMandant()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> getMandantbyName
    '# Mandant DB Name einlesen
    '# Returns DB-Name
    '##########################################################
    Public Function getMandantDatabaseByMandantName(ByVal strMandantName As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try

            Dim strDBName As String = ""

            sqlConn.Open()
            '# Datenbank einlesen 
            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant WHERE cName='" & strMandantName & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                Dim lvwItem As New ListViewItem
                strDBName = r("cDB").ToString
            End While

            sqlConn.Close()
            Return strDBName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "getMandantbyName()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> getMandantbyDBName
    '# Mandant DB Name einlesen
    '# Returns Profil-Name
    '##########################################################
    Public Function getMandantbyDBName(ByVal strMandantDB As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try

            Dim strMandantName As String = ""

            sqlConn.Open()
            '# Datenbank einlesen 
            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant WHERE cDB='" & strMandantDB & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                Dim lvwItem As New ListViewItem
                strMandantName = r("cName").ToString
            End While

            sqlConn.Close()
            Return strMandantName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "getMandantbyDBName()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> chkInstallTableExists
    '# Überprüft ob eine Tabelle exisitert
    '# returns 1 OK / -1 unbekannter FEHLER / Name der fehlenden Tabelle
    '####################################################################
    Public Function chkInstallTableExists(ByVal strFilename As String) As String
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            Dim strDataFile As String = ""
            Dim strDataFile_split() As String
            sqlConn.Open()

            Dim strQuery As String = ""

            '# Datei einlesen 

            strDataFile = My.Computer.FileSystem.ReadAllText(strFilename)
            strDataFile_split = strDataFile.Split(vbCrLf)

            '# Alle Tabellen durchgehen 
            For i As Byte = 0 To strDataFile_split.Length - 1
                strQuery = "SELECT *  FROM " & strDataFile_split(i)
                Try
                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As Exception
                    '# Fehler bei der Tabelle übergeben 
                    Return strDataFile_split(i)
                End Try
            Next
            Return "1"
        Catch ex As Exception
            MessageBox.Show("Fehler bei chkInstallTablesExists()" & ex.Message, "chkInstallTableExists()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function
    '####################################################################
    '# >> setInstallUpdateByDatabase
    '# Neue Tabellen installieren, z.B. wenn neuer Mandant angelegt 
    '# wird in den Datenbankeinstellungen
    '####################################################################
    Public Function setInstallUpdateByDatabase(ByVal strFileName As String, ByVal strMandant_db As String) As Boolean

        Dim strContent As String = My.Computer.FileSystem.ReadAllText(strFileName)
        Dim strContent_split() As String = strContent.Split(vbCrLf)
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            For i As Integer = 0 To strContent_split.Length - 1
                Try
                    Dim strQuery As String = ""
                    strQuery = "USE " & strMandant_db & vbCrLf & strContent_split(i)
                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    sqlComm.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show("Zeile: " & i & " " & ex.Message, "SQL Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Next

            sqlConn.Close()
            Return True
        Catch ex As Exception
            '# 0: In der Datenbank ist bereits ein Objekt mit dem Namen 'illixi_newsletter' vorhanden.

            MessageBox.Show(ex.Message, "Fehler beim Hinzufügen der neuen Datenbank Tabelle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '####################################################################
    '# >> setInstallUpdateAllMandant
    '# Installieren des Updates für alle Mandanten
    '####################################################################
    Public Function setInstallUpdateAllMandant(ByVal strFileName As String, ByVal cmbMandanten As ComboBox) As Boolean
        Dim strMandant_db As String = ""
        Try
            If IO.File.Exists(strFileName) = True Then
                For i As Integer = 0 To cmbMandanten.Items.Count - 1
                    strMandant_db = getMandantDatabaseByMandantName(cmbMandanten.Items(i))
                    If setInstallUpdateByDatabase(strFileName, strMandant_db) = True Then
                        My.Settings.first_start = False
                        My.Settings.Save()
                    Else
                        MessageBox.Show("Datenbanktabelle " & strMandant_db & " konnte nicht angelegt werden", "Datenbank: Installation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next

                Dim strFileNameNew() As String = strFileName.Split("\")
                Dim strFileNameNew_complete As String = Application.StartupPath & "\SQL\" & strFileNameNew(strFileNameNew.Length - 1).Replace(".", " " & Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & " " & Date.Now.Hour & "-" & Date.Now.Minute & "-" & Date.Now.Second & ".")
                IO.File.Move(strFileName, strFileNameNew_complete)
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei setInstallUpdateAllMandant: " & ex.Message, "setInstallUpdateAllMandant()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
End Class
