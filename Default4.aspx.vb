Imports System.Globalization
Imports System.IO
Imports Aspose.Words
Imports System.Text.RegularExpressions
Imports MSDASC
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks


Partial Class Default4
    Inherits System.Web.UI.Page
    Public users(2000) As Integer
    Public list As New System.Collections.Generic.List(Of Test2)
    Public list3 As New System.Collections.Generic.List(Of Test2)
    Public direct2 As String
    Public direct As String

    Public Function Direct5(list As System.Collections.Generic.List(Of Test2)) As System.Collections.Generic.List(Of Test2)
        Dim direct3 As String = ""
        Dim direct4 As String = ""
        Dim usersDir As String() = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim k As Object = 0
        Dim k1 As Object = 0
        Dim j As Object = 0
        Dim aaaa As Object = ""
        Dim bbbb As Object = ""
        Dim cccc As Object = ""
        Dim dddd As Object = ""
        Dim ffff As Object = ""
        Dim a1 As Object = True
        Dim b1 As Object = True
        Dim aaa As Object = 0
        Dim bbb As Object = 0
        Dim eeee As Object = ""
        If ListBox1.Items.Count < 76 Then bbb = 76
        For Each direct In usersDir
            k = Len(direct)
            While k > 0
                If Mid(direct, k, 1) = "\" Then
                    direct2 = Mid(direct, k + 1, Len(direct) - k)
                    If Integer.TryParse(Mid(direct2, 1, 3), aaa) Then
                        If ListBox1.SelectedIndex + 1 + bbb = aaa Then direct4 = direct2
                    End If
                End If
                k = k - 1
            End While
        Next

        For Each direct3 In Directory.GetFiles(Request.PhysicalApplicationPath & "Listes et Favoris" & "\" & direct4 & "\", "*.*")
            If InStr(direct3, ".xls") Then
                If InStr(direct3, ".xlsx") Then
                Else
                    Dim Conn As ADODB.Connection = New ADODB.Connection
                    Conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & direct3 & ";Extended Properties=""Excel 8.0;HDR=0;""")
                    Dim Adap2 As ADODB.Recordset = Conn.Execute("Select * FROM [Feuil1$B3:G100]")

                    a1 = True
                    b1 = True

                    While Not Adap2.EOF
                        Dim delimiter() As Char = {",", "+", " et"}
                        If Adap2.Fields.Item(0).Value.ToString <> "" AndAlso Adap2.Fields.Item(0).Value.ToString <> "SPECIALITES" Then
                            If aaaa = Adap2.Fields.Item(0).Value.ToString Then
                                a1 = False
                            Else
                                aaaa = Adap2.Fields.Item(0).Value.ToString
                                a1 = True
                            End If
                        Else
                            If Adap2.Fields.Item(2).Value.ToString <> "" Then
                                If Adap2.Fields.Item(2).Value.ToString.Length > 200 Then
                                    If bbbb = Mid(Adap2.Fields.Item(2).Value.ToString, 1, 200) Then
                                        b1 = False
                                    Else
                                        bbbb = Mid(Adap2.Fields.Item(2).Value.ToString, 1, 200)
                                        aaaa = Adap2.Fields.Item(2).Value.ToString.Split(delimiter)(0).ToUpper
                                        b1 = True
                                    End If
                                Else
                                    If bbbb = Adap2.Fields.Item(2).Value.ToString Then
                                        b1 = False
                                    Else
                                        bbbb = Adap2.Fields.Item(2).Value.ToString
                                        aaaa = Adap2.Fields.Item(2).Value.ToString.Split(delimiter)(0).ToUpper
                                        b1 = True
                                    End If
                                End If
                            Else
                                If a1 = True AndAlso b1 = True AndAlso Adap2.Fields.Item(4).Value.ToString <> "" AndAlso Adap2.Fields.Item(3).Value.ToString.Split(delimiter)(0) <> "" Then
                                    cccc = Adap2.Fields.Item(3).Value.ToString
                                    dddd = Adap2.Fields.Item(4).Value.ToString
                                    ffff = Adap2.Fields.Item(5).Value.ToString
                                    k1 = 1
                                    Dim i As Object = 0
                                    For i = 0 To list3.Count - 1
                                        If list3.Item(i).Nom = cccc Then
                                            k1 = 0
                                            Exit For
                                        End If
                                    Next
                                    If k1 = 1 Then
                                        list3.Add(New Test2(cccc, dddd, aaaa, bbbb, ListBox1.Text, ffff))
                                    End If
                                    list.Add(New Test2(cccc, dddd, aaaa, bbbb, ListBox1.Text, ffff))

                                Else
                                    If Adap2.Fields.Item(3).Value.ToString.Split(delimiter)(0) <> "" Then
                                        cccc = Adap2.Fields.Item(3).Value.ToString
                                        k1 = 1
                                        Dim i As Object = 0
                                        For i = 0 To list3.Count - 1
                                            If list3.Item(i).Nom = cccc Then
                                                k1 = 0
                                                Exit For
                                            End If
                                        Next
                                        If k1 = 1 Then
                                            list3.Add(New Test2(cccc, dddd, aaaa, bbbb, ListBox1.Text, ffff))
                                        End If
                                        list.Add(New Test2(cccc, dddd, aaaa, bbbb, ListBox1.Text, ffff))

                                    End If
                                End If
                            End If
                        End If
                        Adap2.MoveNext()
                    End While
                    Adap2.Close()
                End If
            End If
        Next
        Label1.Text = "Commentaires de l'Expert"
        Label2.Text = "Médicaments"
        Return list
    End Function

    Public Function Direct6(list As System.Collections.Generic.List(Of Test2), aaa As Boolean) As System.Collections.Generic.List(Of Test2)
        Dim chaine As Object = ""
        Dim chaine2 As Object = ""
        Dim direct3 As String = ""
        Dim direct4 As Object = ""
        Dim delimiter() As Char = {" ", ","}
        Dim Adap2(20) As System.Data.OleDb.OleDbDataAdapter
        Dim usersDir As String() = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.AllDirectories)
        Dim k As Object = 0
        Dim bbb As Object = 0
        Dim cccc As Object = 0
        Dim n As Object = 0
        Dim d As Object = 1
        Dim i As Object = 0
        Dim j As Object = 0
        Dim rrr As Object = ""
        TextBox1.Text = ""
        If aaa = True Then
            While j < usersDir.Length - 1
                If j = 0 Then
                    While ListBox3.Items.Count > 0
                        ListBox3.Items.RemoveAt(ListBox3.Items.Count - 1)
                    End While
                End If
                direct = Trim(usersDir(j))
                d = Len(direct)
                While d > 0
                    If Mid(direct, d, 1) = "0" Or Mid(direct, d, 1) = "1" Or Mid(direct, d, 1) = "2" Or Mid(direct, d, 1) = "3" Or Mid(direct, d, 1) = "4" Or Mid(direct, d, 1) = "5" Or Mid(direct, d, 1) = "6" Or Mid(direct, d, 1) = "7" Or Mid(direct, d, 1) = "8" Or Mid(direct, d, 1) = "9" Then
                        rrr = Trim(Mid(direct, d + 1, Len(direct) - d))
                        Exit While
                    End If
                    d = d - 1
                End While
                i = 0
                rrr = Trim(rrr)
                While i < list.Count - 1
                    If param3.Text = "ENFANTS" Then
                        If (InStr(1, UCase(rrr), "ENFANT") > 0 Or InStr(1, UCase(rrr), "NOURRISSON") > 0 Or InStr(1, UCase(rrr), "POUSSEES DENTAIRES") > 0 Or InStr(1, UCase(rrr), "PEDIATRIQUE") > 0) Then
                            If UCase(Trim(list.Item(i).Nom)) = Trim(UCase(ListBox2.Text)) And InStr(1, Replace(ReplaceChars(Trim(UCase(list.Item(i).Sympt)), False), "’", "'"), ReplaceChars(UCase(Trim(rrr)), False)) > 0 Then
                                cccc = list.Item(i).Note
                                direct2 = list.Item(i).Sympt
                                chaine = list.Item(i).Avis

                                If InStr(1, TextBox1.Text, Trim(direct2)) <= 0 Then
                                    ListBox3.Items.Add(direct)
                                    TextBox1.Text = TextBox1.Text & Trim(direct2) & " (note: " & cccc & ") " & Chr(13) & Chr(10)
                                End If
                            End If
                        End If
                    Else
                        If (param3.Text = "ADULTES" And InStr(1, UCase(rrr), "ENFANT") <= 0 And InStr(1, UCase(rrr), "NOURRISSON") <= 0 And InStr(1, UCase(rrr), "POUSSEES DENTAIRES") <= 0 And InStr(1, UCase(rrr), "PEDIATRIQUE") <= 0) Then
                            If UCase(Trim(list.Item(i).Nom)) = Trim(UCase(ListBox2.Text)) And InStr(1, Replace(ReplaceChars(Trim(UCase(list.Item(i).Sympt)), False), "’", "'"), ReplaceChars(UCase(Trim(rrr)), False)) > 0 Then
                                cccc = list.Item(i).Note
                                direct2 = list.Item(i).Sympt
                                chaine = list.Item(i).Avis

                                If InStr(1, TextBox1.Text, Trim(direct2)) <= 0 Then
                                    ListBox3.Items.Add(direct)
                                    TextBox1.Text = TextBox1.Text & Trim(direct2) & " (note: " & cccc & ") " & Chr(13) & Chr(10)
                                End If
                            End If
                        End If
                    End If
                    Button1.Visible = True
                    Button1.Enabled = True
                    i = i + 1
                End While
                j = j + 1
            End While

            TextBox1.Text = TextBox1.Text & Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(chaine, "EN SAVOIR PLUS", ""), "En savoir plus", ""), "en savoir plus", ""), "Eneeenen savoir plus", ""), Chr(11), ""), Chr(9), ""), Chr(7), ""), "pANsement", "pansement") & Chr(13), "idem", " ")
        End If
        Dim Item As String = ""
        If aaa = False Then
            For Each Item In ListBox3.Items
                d = Len(Item.ToString)
                While d > 0
                    If Mid(Item.ToString, d, 1) = "0" Or Mid(Item.ToString, d, 1) = "1" Or Mid(Item.ToString, d, 1) = "2" Or Mid(Item.ToString, d, 1) = "3" Or Mid(Item.ToString, d, 1) = "4" Or Mid(Item.ToString, d, 1) = "5" Or Mid(Item.ToString, d, 1) = "6" Or Mid(Item.ToString, d, 1) = "7" Or Mid(direct, d, 1) = "8" Or Mid(Item.ToString, d, 1) = "9" Then
                        rrr = Trim(Mid(Item.ToString, d + 2, Len(Item.ToString) - d + 1))
                        Exit While
                    End If
                    d = d - 1
                End While
                Dim Files() As String
                Files = System.IO.Directory.GetFiles(Item.ToString, "*.doc")
                For Each direct3 In Files
                    Dim doc As New Document(direct3)
                    If InStr(1, direct3, "Favori") > 0 Then
                        If InStr(1, TextBox1.Text, Replace(Trim(doc.Sections(0).Body.Range.Text), "NOTRE MEDICAMENT FAVORI", "NOTRE MEDICAMENT FAVORI" & Chr(13) & rrr & Chr(13))) <= 0 Then
                            TextBox1.Text = TextBox1.Text & Replace(Trim(doc.Sections(0).Body.Range.Text), "NOTRE MEDICAMENT FAVORI", "NOTRE MEDICAMENT FAVORI" & Chr(13) & rrr & Chr(13))
                        End If
                    End If
                    doc = Nothing
                Next direct3
            Next Item
            If Not InStr(TextBox1.Text, "FAVORI") > 0 Then
                If TextBox1.Text <> "" Then TextBox1.Text = TextBox1.Text & "Pas de médicament favori" Else TextBox1.Text = "Pas de médicament favori"
            End If
            Button1.Visible = False
            Button1.Enabled = False
            While ListBox3.Items.Count > 0
                ListBox3.Items.RemoveAt(ListBox3.Items.Count - 1)
            End While
        End If
        ListBox2.SelectedItem.Attributes.CssStyle.Add("background-color", "SkyBlue")
        ListBox2.Focus()

        Return list
    End Function

    Public Function Recherche_word(list As System.Collections.Generic.List(Of Test2)) As System.Collections.Generic.List(Of Test2)
        On Error Resume Next
        Dim chaine As Object = ""
        Dim direct1 As Object = ""
        Dim direct4 As String = ""
        Dim ligne1 As String = ""
        Dim ligne3 As String = ""
        Dim m1 As Integer = 0
        Dim m2 As Integer = 0
        Dim bbb As Object = 0
        If ListBox1.Items.Count < 76 Then bbb = 76
        Dim usersDir3 As String() = Directory.GetFiles(Request.PhysicalApplicationPath, "*.*")
        For Each direct1 In usersDir3
            If InStr(direct1, "manuscrit médicaments sans ordonnance") Then
                direct4 = direct1
            End If
        Next
        Dim myObject As Object = New Document(direct4)
        Dim k = 0
        Dim a1 = 0
        Dim a2 = True
        Dim j = 0
        If m1 = 0 Or m2 = 0 Then
            For k = 1098 To myObject.Sections(0).Body.Paragraphs.Count
                On Error GoTo - 1
                If myObject.Sections(0).Body.Paragraphs(k) IsNot Nothing Then
                    If myObject.Sections(0).Body.Paragraphs(k).ParagraphFormat.StyleName = "01.Titre1" Then
                        j = j + 1
                        If j = ListBox1.SelectedIndex + 1 + bbb Then
                            m1 = k
                            a1 = 0
                        End If
                        If j = ListBox1.SelectedIndex + 2 + bbb Then
                            m2 = k
                            a1 = 0
                        End If
                    End If
                End If
            Next
        End If
        If m1 = 0 Or m2 = 0 Then
            j = j - 2
            For k = 0 To myObject.Sections(2).Body.Paragraphs.Count
                On Error GoTo - 1
                If myObject.Sections(2).Body.Paragraphs(k) IsNot Nothing Then
                    If myObject.Sections(2).Body.Paragraphs(k).ParagraphFormat.StyleName = "01.Titre1" Or InStr(myObject.Sections(2).Body.Paragraphs(k).Range.Text, "BIBLIOGRAPHIE") > 0 Then
                        If ListBox1.SelectedIndex + bbb >= 76 AndAlso a2 = True Then
                            a2 = False
                            j = j - 3
                        End If
                        j = j + 1
                        If j = ListBox1.SelectedIndex + bbb Then
                            m1 = k
                            a1 = 2
                        End If
                        If j = ListBox1.SelectedIndex + 1 + bbb Then
                            m2 = k
                            a1 = 2
                        End If
                    End If
                End If
            Next
        End If
        Dim n = a1
        For k = m1 To m2 - 1
            On Error GoTo - 1
            If myObject.Sections(n).Body.Paragraphs(k) IsNot Nothing Then
                chaine = chaine & " " & Strings.Replace(myObject.Sections(n).Body.Paragraphs(k).Range.Text, ";", "")
            End If
        Next

        TextBox2.Text = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(chaine, "EN SAVOIR PLUS", ""), "Eneeenen savoir plus", ""), Chr(11), ""), Chr(9), ""), Chr(7), ""), "pANsement", "pansement"), " d ", ""), " c ", "")
        myObject = Nothing
        Return list
        ListBox2.Focus()
    End Function

    Public Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

        TextBox1.Visible = True
        ListBox1.Visible = False
        ListBox2.Visible = True
        TextBox2.Visible = False
        Label1.Visible = True
        Button1.Visible = True
        Button1.Enabled = True
        list.Clear()
        Dim i As Object = 0
        For i = 0 To ListBox1.Items.Count - 1
            If i > 0 Then ListBox1.Items(i - 1).Selected = False
            ListBox1.Items(i).Selected = True
            list = Direct5(list)
            list.Sort(Function(elementA As Test2, elementB As Test2)
                          Return elementA.Nom.CompareTo(elementB.Nom)
                      End Function)

            list3.Sort(Function(elementA As Test2, elementB As Test2)
                           Return elementA.Nom.CompareTo(elementB.Nom)
                       End Function)

        Next
        list = Direct6(list, True)
        ListBox2.SelectedItem.Attributes.CssStyle.Add("background-color", "SkyBlue")
        ListBox1.SelectedItem.Attributes.CssStyle.Add("color", "#0645AD")
        ListBox2.Focus()

    End Sub
    Public Function ReplaceChars(ByVal source As String, ByVal deleteNonPrintableChars As Boolean) As String
        Dim sourceInFormD As String = source.Normalize(NormalizationForm.FormD)
        Dim output As New StringBuilder
        For Each c As Char In sourceInFormD
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
            If uc <> UnicodeCategory.NonSpacingMark Then
                output.Append(c)
            End If
        Next
        Dim ret As String = output.ToString.Normalize(NormalizationForm.FormC)
        If deleteNonPrintableChars Then
            ret = Regex.Replace(ret, "[^\u0000-\u007F]", String.Empty) 'on supprime les non-printable characters
        End If
        Return ret
    End Function

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        adultes.Visible = False
        enfants.Visible = False
        ListBox1.Items.Clear()
        Dim usersDir As Object = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim n = 0
        Dim k = 0
        For Each direct In usersDir
            k = Len(direct)
            While k > 0
                If Mid(direct, k, 1) = "\" Then
                    users(n) = Convert.ToInt16(Mid(direct, k + 1, 2))
                    Exit While
                End If
                k = k - 1
            End While
            n = n + 1
        Next
        Dim chaine As Object = ""
        Dim direct1 As Object = ""
        Dim direct4 As String = ""
        Dim ligne1 As String = ""
        Dim ligne3 As String = ""
        Dim usersDir3 As String() = Directory.GetFiles(Request.PhysicalApplicationPath, "*.*")
        For Each direct1 In usersDir3
            If InStr(direct1, "manuscrit médicaments sans ordonnance") Then
                direct4 = direct1
            End If
        Next
        Dim myObject As Object = New Document(direct4)
        Dim delimiter5() As Char = {Chr(13), "°", "'"}
        Dim delimiter1() As Char = {"X"}
        Dim a1 = 0
        Dim a3 = 0
        Dim a4 = False
        If param3.Text = "ADULTES" Then
            a1 = 0
            a3 = 3091
            a4 = True
        End If
        If param3.Text = "ENFANTS" Then
            a1 = 3148
            a3 = myObject.Sections(2).Body.Paragraphs.Count - 1
            a4 = False
        End If
        If a4 = True Then
            For k = 1098 To myObject.Sections(0).Body.Paragraphs.Count - 1

                If myObject.Sections(0).Body.Paragraphs(k).ParagraphFormat.Style.Font.Size = 25 Then
                    ListBox1.Items.Add(Replace(Replace(Replace(Replace(myObject.Sections(0).Body.Paragraphs(k).Range.Text, vbCr, ""), Chr(11), ""), Chr(9), ""), Chr(7), ""))
                End If
            Next
        End If
        For k = a1 To a3
            If InStr(myObject.Sections(2).Body.Paragraphs(k).Range.Text, "BIBLIOGRAPHIE") > 0 Then
                Exit For
            End If

            If myObject.Sections(2).Body.Paragraphs(k).ParagraphFormat.Style.Font.Size = 25 Then
                    ListBox1.Items.Add(Replace(Replace(Replace(Replace(myObject.Sections(2).Body.Paragraphs(k).Range.Text, vbCr, ""), Chr(11), ""), Chr(9), ""), Chr(7), ""))
                End If
            Next

        list.Clear()
        list3.Clear()
        Dim i As Object = 0
        For i = 0 To ListBox1.Items.Count - 1
            If i > 0 Then ListBox1.Items(i - 1).Selected = False
            ListBox1.Items(i).Selected = True
            list = Direct6(list, True)
            list3 = Direct6(list3, True)
            list.Sort(Function(elementA As Test2, elementB As Test2)
                          Return elementA.Nom.CompareTo(elementB.Nom)
                      End Function)
            list3.Sort(Function(elementA As Test2, elementB As Test2)
                           Return elementA.Nom.CompareTo(elementB.Nom)
                       End Function)

        Next
        TextBox1.Visible = True
        ListBox1.Visible = False
        ListBox2.Visible = True
        TextBox2.Visible = False
        Label1.Visible = True
        Button1.Visible = True
        Button1.Enabled = False
        Select Case param4.Value
            Case "fr"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0), "%20", " "))
                    Else
                        list3 = Direct6(list3, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0))
                        End If
                    End If
                End If
            Case "en"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0), "%20", " "))
                    Else
                        list3 = Direct6(list3, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0), "%20", " "))
                        End If
                    End If
                End If
            Case Else
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0), "%20", " "))
                    Else
                        list3 = Direct6(list3, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter5)(0), "%20", " "))
                        End If
                    End If
                End If
        End Select
    End Sub

    Public Sub form1_Init(sender As Object, e As EventArgs) Handles form1.Init
        TextBox1.Visible = False
        ListBox1.Visible = False
        ListBox2.Visible = False
        TextBox2.Visible = False
        Button1.Visible = False
        adultes.Visible = True
        enfants.Visible = True
        Button1.Enabled = False
        Label1.Visible = True
    End Sub
    Public Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim meta As HtmlMeta = New HtmlMeta()
        meta.Content = "automédication troubles santé bénins efficacité effets indésirables médicaments sans ordonnance populations fragiles médicaments favoris"
        meta.Name = "KEYWORDS"
        Header.Controls.Add(meta)
        meta.Content = "Comment traiter ces maux du quotidien seul et sans danger, lorsque l'on sait que plus de 50 % des médicaments sans ordonnance n'ont jamais démontré d'efficacité chez l'homme, et que tous présentent des effets indésirables, parfois graves ? Dans ce guide pratique d'automédication, le Pr. Giroud, expert international en médicaments, donne les clés pour soigner 120 troubles de santé bénins. Tout ce qu'il faut savoir sur les médicaments, leurs risques et les précautions à prendre, notamment chez les populations fragiles. Pour chacune de ces affections, toutes les manifestations, causes, signes d'alerte et conduites à tenir. Une liste de tous les médicaments disponibles sans ordonnance évalués, notés de 0 à 20 et commentés, une information introuvable ailleurs. Les médicaments recommandés ou favoris"
        meta.Name = "DESCRIPTION"
        Header.Controls.Add(meta)
        meta.Name = "ROBOTS"
        meta.Content = "INDEX,FOLLOW"
        Header.Controls.Add(meta)
        ListBox1.Focus()

    End Sub

    Private Sub adultes_ServerClick(sender As Object, e As EventArgs) Handles adultes.ServerClick

        param3.Text = "ADULTES"
        adultes.Visible = False
        enfants.Visible = False
        ListBox1.Items.Clear()
        Dim usersDir As Object = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim n = 0
        Dim k = 0
        For Each direct In usersDir
            k = Len(direct)
            While k > 0
                If Mid(direct, k, 1) = "\" Then
                    users(n) = Convert.ToInt16(Mid(direct, k + 1, 2))
                    Exit While
                End If
                k = k - 1
            End While
            n = n + 1
        Next
        Dim chaine As Object = ""
        Dim direct1 As Object = ""
        Dim direct4 As String = ""
        Dim ligne1 As String = ""
        Dim ligne3 As String = ""
        Dim usersDir3 As String() = Directory.GetFiles(Request.PhysicalApplicationPath, "*.*")
        For Each direct1 In usersDir3
            If InStr(direct1, "manuscrit médicaments sans ordonnance") Then
                direct4 = direct1
            End If
        Next
        Dim myObject As Object = New Document(direct4)
        Dim delimiter6() As Char = {Chr(13), "°", "'"}
        Dim delimiter2() As Char = {"X"}
        Dim a1 = 0
        Dim a3 = 0
        Dim a4 = False

        a1 = 0
        a3 = 3091
        a4 = True

        If a4 = True Then
            For k = 1098 To myObject.Sections(0).Body.Paragraphs.Count - 1

                If myObject.Sections(0).Body.Paragraphs(k).ParagraphFormat.Style.Font.Size = 25 Then
                    ListBox1.Items.Add(Replace(Replace(Replace(Replace(myObject.Sections(0).Body.Paragraphs(k).Range.Text, vbCr, ""), Chr(11), ""), Chr(9), ""), Chr(7), ""))
                End If
            Next
        End If
        For k = a1 To a3
            If InStr(myObject.Sections(2).Body.Paragraphs(k).Range.Text, "BIBLIOGRAPHIE") > 0 Then
                Exit For
            End If

            If myObject.Sections(2).Body.Paragraphs(k).ParagraphFormat.Style.Font.Size = 25 Then
                ListBox1.Items.Add(Replace(Replace(Replace(Replace(myObject.Sections(2).Body.Paragraphs(k).Range.Text, vbCr, ""), Chr(11), ""), Chr(9), ""), Chr(7), ""))
            End If
        Next
        list.Clear()
        Dim i As Object = 0
        For i = 0 To ListBox1.Items.Count - 1
            If i > 0 Then ListBox1.Items(i - 1).Selected = False
            ListBox1.Items(i).Selected = True
            list = Direct5(list)

            list.Sort(Function(elementA As Test2, elementB As Test2)
                          Return elementA.Nom.CompareTo(elementB.Nom)
                      End Function)
            list3.Sort(Function(elementA As Test2, elementB As Test2)
                           Return elementA.Nom.CompareTo(elementB.Nom)
                       End Function)

        Next
        TextBox1.Visible = True
        ListBox1.Visible = False
        ListBox2.Visible = True
        TextBox2.Visible = False
        Label1.Visible = True
        Button1.Visible = True
        Button1.Enabled = False
        Select Case param4.Value
            Case "fr"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0), "%20", " "))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0), "%20", " "))
                        End If
                    End If
                End If
            Case "en"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect("https://www.drugs.com/search.php?searchterm=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect("https://www.drugs.com/search.php?searchterm=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0))
                        End If
                    End If
                End If
            Case Else
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0), "%20", " "))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter6)(0), "%20", " "))
                        End If
                    End If
                End If
        End Select
    End Sub

    Public Sub enfants_ServerClick(sender As Object, e As EventArgs) Handles enfants.ServerClick

        param3.Text = "ENFANTS"
        adultes.Visible = False
        enfants.Visible = False
        ListBox1.Items.Clear()
        Dim usersDir As Object = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim n = 0
        Dim k = 0
        For Each direct In usersDir
            k = Len(direct)
            While k > 0
                If Mid(direct, k, 1) = "\" Then
                    users(n) = Convert.ToInt16(Mid(direct, k + 1, 2))
                    Exit While
                End If
                k = k - 1
            End While
            n = n + 1
        Next
        Dim chaine As Object = ""
        Dim direct1 As Object = ""
        Dim direct4 As String = ""
        Dim ligne1 As String = ""
        Dim ligne3 As String = ""
        Dim usersDir3 As String() = Directory.GetFiles(Request.PhysicalApplicationPath, "*.*")
        Dim delimiter7() As Char = {Chr(13), "°", "'"}
        Dim delimiter3() As Char = {"X"}
        For Each direct1 In usersDir3
            If InStr(direct1, "manuscrit médicaments sans ordonnance") Then
                direct4 = direct1
            End If
        Next
        Dim myObject = New Document(direct4)
        Dim a1 = 0
        Dim a3 = 0

        a1 = 3148
        a3 = myObject.Sections(2).Body.Paragraphs.Count - 1
        For k = a1 To a3
            If InStr(myObject.Sections(2).Body.Paragraphs(k).Range.Text, "BIBLIOGRAPHIE") > 0 Then
                Exit For
            End If

            If myObject.Sections(2).Body.Paragraphs(k).ParagraphFormat.Style.Font.Size = 25 Then
                ListBox1.Items.Add(Replace(Replace(Replace(Replace(myObject.Sections(2).Body.Paragraphs(k).Range.Text, vbCr, ""), Chr(11), ""), Chr(9), ""), Chr(7), ""))
            End If
        Next
        list.Clear()
        Dim i As Object = 0
        For i = 0 To ListBox1.Items.Count - 1
            If i > 0 Then ListBox1.Items(i - 1).Selected = False
            ListBox1.Items(i).Selected = True
            list = Direct5(list)

            list.Sort(Function(elementA As Test2, elementB As Test2)
                          Return elementA.Nom.CompareTo(elementB.Nom)
                      End Function)
            list3.Sort(Function(elementA As Test2, elementB As Test2)
                           Return elementA.Nom.CompareTo(elementB.Nom)
                       End Function)

        Next
        TextBox1.Visible = True
        ListBox1.Visible = False
        ListBox2.Visible = True
        TextBox2.Visible = False
        Label1.Visible = True
        Button1.Visible = True
        Select Case param4.Value
            Case "fr"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0), "%20", " "))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0), "%20", " "))
                        End If
                    End If
                End If
                Button1.Enabled = False
            Case "en"
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0), "%20", " "))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect("https://www.drugs.com/search.php?searchterm=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0))
                        End If
                    End If
                End If
            Case Else
                If TextBox1.Text = "" Then
                    For i = 0 To list3.Count - 1
                        ListBox2.Items.Add(list3.Item(i).Nom.ToString)
                    Next
                Else
                    If InStr(TextBox1.Text, "favori") > 0 Or InStr(TextBox1.Text, "FAVORI") > 0 Then
                        Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0), "%20", " "))
                    Else
                        list = Direct6(list, False)
                        Button1.Visible = True
                        Button1.Enabled = True
                        If InStr(TextBox1.Text, "Pas de médicament favori") > 0 Then
                            TextBox1.Visible = False
                            ListBox2.Visible = False
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(ListBox2.Text.Substring(0, 1).ToUpper & ListBox2.Text.Substring(1).ToUpper)).Split(delimiter7)(0), "%20", " "))
                        End If
                    End If
                End If
        End Select
    End Sub
End Class

Public Class Test2
    Public Function Test() As Test2
        Test = Nothing
        Return Test
    End Function

    Public Sub New(ByVal name As String, ByVal note As String, ByVal dci As String, ByVal prd As String, ByVal sympt As String, ByVal avis As String)
        _name = name
        _note = note
        _dci = dci
        _prd = prd
        _sympt = sympt
        _avis = avis
    End Sub
    Private _name As String
    Public Property Nom() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _note As String
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    Private _dci As String
    Public Property Dci() As String
        Get
            Return _dci
        End Get
        Set(ByVal value As String)
            _dci = value
        End Set
    End Property
    Private _prd As String
    Public Property Prd() As String
        Get
            Return _prd
        End Get
        Set(ByVal value As String)
            _prd = value
        End Set
    End Property
    Private _sympt As String
    Public Property Sympt() As String
        Get
            Return _sympt
        End Get
        Set(ByVal value As String)
            _sympt = value
        End Set
    End Property
    Private _avis As String
    Public Property Avis() As String
        Get
            Return _avis
        End Get
        Set(ByVal value As String)
            _avis = value
        End Set
    End Property
End Class



