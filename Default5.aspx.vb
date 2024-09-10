Imports System.Globalization
Imports System.IO
Imports Aspose.Words
Imports MSDASC
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Data


Partial Class Default5
    Inherits System.Web.UI.Page
    Public users(2000) As Integer
    Public list As New System.Collections.Generic.List(Of Test)
    Public direct2 As String
    Public hp, wp As Integer
    Public param1, h1, w1 As String
    Public Sub form1_Init(sender As Object, e As EventArgs) Handles form1.Init
        On Error Resume Next
        param1 = Request.QueryString("TextBox3")
        Dim usersDir As Object = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim n As Object = 0
        Dim k As Object = 0
        Dim Direct As String = ""
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
        If param1 = "" Or param2.Text <> "" Then
            adultes2.Visible = True
            enfants2.Visible = True
            Button1.Visible = False
            Button1.Enabled = False
        Else
            adultes2.Visible = False
            enfants2.Visible = False
            Button1_Click(sender, New System.EventArgs())
        End If
    End Sub

    Private Sub ListBox1_TextChanged(sender As Object, e As EventArgs) Handles ListBox1.TextChanged
        On Error Resume Next
        adultes2.Visible = False
        enfants2.Visible = False
        Dim chaine As String = ""
        TextBox2.Text = ""
        list = Recherche_word(list)
        If GridView2.HeaderRow IsNot Nothing Then
            GridView2.Sort("Note", SortDirection.Descending)
            GridView2.HeaderRow.Cells(0).Text = "Principe actif"
            GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
            GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
            GridView2.HeaderRow.Cells(3).Text = "Note"
            GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
            GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
            ListBox1.SelectedItem.Attributes.CssStyle.Add("background-color", "SkyBlue")
            ListBox1.SelectedItem.Attributes.CssStyle.Add("color", "#0645AD")
        End If
        ListBox1.Focus()
    End Sub


    Private Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        adultes2.Visible = False
        enfants2.Visible = False
        TextBox1.Visible = True
        Label1.Text = "Médicaments"
        Label2.Text = "Commentaires de l'Expert"
        GridView2.Visible = True
        GridView2.Enabled = True
        ListBox1.Visible = False
        TextBox2.Visible = False
        TextBox2.Text = ""
        TextBox1.Style.Add("vertical-align", "top")
        GridView2.DataSource = Direct5(list)
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
        GridView2.HeaderRow.Cells(0).Text = "Principe actif"
        GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
        GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
        GridView2.HeaderRow.Cells(3).Text = "Note"
        GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
        GridView2.Sort("Note", SortDirection.Descending)
    End Sub


    Public Function Recherche_word(list As System.Collections.Generic.List(Of Test)) As System.Collections.Generic.List(Of Test)
        On Error Resume Next
        Dim chaine As Object = ""
        Dim direct1 As Object = ""
        Dim direct4 As String = ""
        Dim ligne1 As String = ""
        Dim ligne3 As String = ""
        Dim m1 As Integer = 0
        Dim m2 As Integer = 0
        Dim bbb As Object = 0
        If ListBox1.Items.Count < 76 AndAlso ListBox1.Items.Count > 0 Then bbb = 76
        Dim usersDir3 As String() = Directory.GetFiles(Request.PhysicalApplicationPath, "*.*")
        For Each direct1 In usersDir3
            If InStr(direct1, "manuscrit médicaments sans ordonnance") Then
                direct4 = direct1
            End If
        Next
        Dim myObject As Object = New Document(direct4)
        Dim k As Object = 0
        Dim a1 As Object = 0
        Dim a2 As Object = True
        Dim j As Object = 0

        If m1 = 0 AndAlso m2 = 0 Then
            For k = 1098 To myObject.Sections(0).Body.Paragraphs.Count - 1
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
            If ListBox1.SelectedIndex = 3 AndAlso bbb = 0 Then
                m1 = 1223
                m2 = 1240
                a1 = 0
            End If
        End If
        If bbb = 76 Then j = j - 4 Else j = j - 1

        If m1 = 0 AndAlso m2 = 0 Then
            For k = 0 To myObject.Sections(2).Body.Paragraphs.Count - 1
                On Error GoTo - 1
                If myObject.Sections(2).Body.Paragraphs(k) IsNot Nothing Then
                    If myObject.Sections(2).Body.Paragraphs(k).ParagraphFormat.StyleName = "01.Titre1" Or InStr(myObject.Sections(2).Body.Paragraphs(k).Range.Text, "BIBLIOGRAPHIE") > 0 Then
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

        TextBox2.Text = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(chaine, "EN SAVOIR PLUS", ""), "En savoir plus", ""), "en savoir plus", ""), "Eneeenen savoir plus", ""), Chr(11), ""), Chr(9), ""), Chr(7), ""), "pANsement", "pansement"), " d?", ""), " c?", ""), "Eneeen", "")
        myObject = Nothing
        Return list
        ListBox1.Focus()
    End Function

    Public Function Direct5(list As System.Collections.Generic.List(Of Test)) As List(Of Test)
        Dim direct3 As Object = ""
        Dim direct4 As String = ""
        Dim usersDir As String() = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim direct As String
        Dim k = 0
        Dim aaaa As Object = ""
        Dim bbbb As Object = ""
        Dim cccc As Object = ""
        Dim dddd As Object = ""
        Dim a1 As Object = True
        Dim b1 As Object = True
        Dim aaa As Object = 0
        Dim bbb As Object = 0
        If ListBox1.Items.Count < 76 AndAlso ListBox1.Items.Count > 0 Then bbb = 76
        For Each direct In usersDir
            k = Len(direct)
            Dim h As Object = 0
            For h = 0 To ListBox1.Items.Count - 1
                If ListBox1.Items(h).Text = param1 Then ListBox1.Items(h).Selected = True
            Next
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
                        Dim Delimiter() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", ".", ",", "(", "+"}

                        If Adap2.Fields.Item(0).Value.ToString <> "" AndAlso Adap2.Fields.Item(0).Value.ToString <> "SPECIALITES" Then
                            If aaaa = Adap2.Fields.Item(0).Value.ToString Then
                                a1 = False
                            Else
                                aaaa = Adap2.Fields.Item(0).Value.ToString
                                a1 = True
                            End If
                            If Len(aaaa) > 60 Then aaaa = Mid(aaaa, 1, 59)
                        Else
                            If Adap2.Fields.Item(2).Value.ToString <> "" Then
                                If Adap2.Fields.Item(2).Value.ToString.Length > 80 Then
                                    If bbbb = Mid(Adap2.Fields.Item(2).Value.ToString, 1, 79) Then
                                        b1 = False
                                    Else
                                        bbbb = Mid(Adap2.Fields.Item(2).Value.ToString, 1, 79)
                                        aaaa = Adap2.Fields.Item(2).Value.ToString.Split(Delimiter)(0).ToUpper
                                        b1 = True
                                    End If
                                Else
                                    If bbbb = Adap2.Fields.Item(2).Value.ToString Then
                                        b1 = False
                                    Else
                                        bbbb = Adap2.Fields.Item(2).Value.ToString
                                        aaaa = Adap2.Fields.Item(2).Value.ToString.Split(Delimiter)(0).ToUpper
                                        b1 = True
                                    End If
                                End If
                                If Len(aaaa) > 80 Then aaaa = Mid(aaaa, 1, 79)
                            End If
                        End If
                        If a1 = True AndAlso b1 = True Then
                            If Adap2.Fields.Item(4).Value.ToString <> "" Then dddd = Adap2.Fields.Item(4).Value.ToString
                            If Adap2.Fields.Item(3).Value.ToString <> "" Then
                                If Len(aaaa) > 40 Then aaaa = Mid(aaaa, 1, 39)
                                If Len(bbbb) > 40 Then bbbb = Mid(bbbb, 1, 39)
                                If Len(cccc) > 40 Then cccc = Mid(cccc, 1, 39)
                                If cccc <> "" Then cccc = cccc & Chr(13) & Adap2.Fields.Item(3).Value.ToString Else cccc = Adap2.Fields.Item(3).Value.ToString

                            Else
                                If cccc <> "" Then
                                    If Len(cccc) > 80 Then cccc = Mid(cccc, 1, 79)
                                    list.Add(New Test(cccc, dddd, aaaa, bbbb))
                                    cccc = ""
                                End If
                            End If
                        End If
                        Adap2.MoveNext()
                    End While
                    Adap2.Close()
                End If
            End If
        Next
        Return list
    End Function
    Public Function Direct6(list As System.Collections.Generic.List(Of Test), ddd As Boolean) As List(Of Test)
        Dim chaine As String = ""
        Dim chaine2 As Object = ""
        Dim direct3 As String = ""
        Dim direct4 As String = ""
        Dim usersDir As String() = Directory.GetDirectories(Request.PhysicalApplicationPath & "Listes et Favoris" & "\", "*.*", SearchOption.TopDirectoryOnly)
        Dim direct As String = ""
        Dim k As Object = 0
        Dim aaa As Object = 0
        Dim bbb As Object = 0
        Dim zzz As String = ""

        TextBox1.Text = ""
        If ListBox1.Items.Count < 76 AndAlso ListBox1.Items.Count > 0 Then bbb = 76
        For Each direct In usersDir
            k = Len(direct)
            Dim h As Object = 0
            For h = 0 To ListBox1.Items.Count - 1
                If ListBox1.Items(h).Text = Request.Params("TextBox3") Then ListBox1.Items(h).Selected = True
            Next
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
        direct = ""
        If direct4 <> "" Then
            For Each direct In usersDir
                If InStr(direct, Mid(ReplaceChars(direct4.ToUpper, True), 1, 4)) > 0 Then
                    Exit For
                End If
            Next
        End If
        Dim cccc As Integer = 0
        Dim nn As Object = 0

        If ddd = True Then
            For Each direct3 In Directory.GetFiles(direct & "\", "*.*")
                If InStr(direct3, "Liste") AndAlso InStr(direct3, ".xls") Then
                    If InStr(direct3, ".xlsx") Then
                    Else
                        Dim Conn As ADODB.Connection = New ADODB.Connection
                        Conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & direct3 & ";Extended Properties=""Excel 8.0;HDR=0;""")
                        Dim Adap2 As ADODB.Recordset = Conn.Execute("Select * FROM [Feuil1$B3:G100]")
                        While Not Adap2.EOF
                            If Adap2.Fields.Item(4).Value.ToString <> "" AndAlso Adap2.Fields.Item(5).Value.ToString <> "" Then
                                If nn = GridView2.SelectedIndex Then
                                    chaine = Replace(Replace(Replace(Replace(Adap2.Fields.Item(5).Value.ToString, "Lefficacité", "L'efficacité"), "Lapplication", "L'application"), "cest", "c'est"), "EN SAVOIR PLUS", "")
                                End If
                                nn = nn + 1
                            End If
                            Adap2.MoveNext()
                        End While
                        Adap2.Close()
                    End If
                End If
            Next
            Button1.Visible = True
            Button1.Enabled = True
            ListBox1.Visible = True
            ListBox1.Enabled = True

        Else
            For Each direct3 In Directory.GetFiles(direct & " \ ", "*.*")
                If InStr(direct3, "Favori") AndAlso InStr(direct3, ".doc") Then
                    Dim myObject2 As Object = New Document(direct3)
                    If chaine2 <> "" Then chaine2 = chaine2 & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Trim(myObject2.Sections(0).Body.Range.Text) Else chaine2 = Trim(myObject2.Sections(0).Body.Range.Text)
                End If
            Next
            If Not InStr(chaine2, "FAVORI") > 0 Then
                If chaine2 <> "" Then chaine2 = chaine2 & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "Pas de médicament favori" Else chaine2 = "Pas de médicament favori"
            End If
            Button1.Visible = True
            Button1.Enabled = True
            ListBox1.Visible = True
            ListBox1.Enabled = True

        End If
        TextBox1.Text = Replace(Replace(Replace(Replace(Replace(Replace(LTrim(chaine & " " & chaine2), "EN SAVOIR PLUS", ""), "Eneeenen savoir plus", ""), Chr(11), ""), Chr(9), ""), Chr(7), ""), "pANsement", "pansement")
        If TextBox1.Text = "" Then TextBox1.Text = "idem"
        Return list

        ListBox1.Focus()
    End Function




    Private Function PadQuotes(ByVal s As String) As String

        If s.IndexOf("\") <> -1 Then
            s = Replace(s, "\", "\\")
        End If

        If s.IndexOf(vbCrLf) <> -1 Then
            s = Replace(s, vbCrLf, "\n")
        End If

        If s.IndexOf(vbCr) <> -1 Then
            s = Replace(s, vbCr, "\r")
        End If

        If s.IndexOf(vbLf) <> -1 Then
            s = Replace(s, vbLf, "\f")
        End If

        If s.IndexOf(vbTab) <> -1 Then
            s = Replace(s, vbTab, "\t")
        End If

        If s.IndexOf("""") = -1 Then
            Return s
        Else
            Return Replace(s, """", "\""")
        End If
    End Function

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
        Dim delimiter() As Char = {Chr(13), "°", "'"}
        Dim delimiter1() As Char = {"X"}

        adultes2.Visible = False
        enfants2.Visible = False
        If TextBox2.Visible = True AndAlso ListBox1.SelectedIndex >= 0 Then
            TextBox1.Visible = True
            GridView2.Visible = True
            GridView2.Enabled = True
            ListBox1.Visible = False
            TextBox2.Visible = False
            TextBox1.Text = ""
            Label1.Text = "Médicaments"
            Label2.Text = "Commentaires de l'Expert"
            GridView2.DataSource = Direct6(Direct5(list), False)
            GridView2.Sort("Note", SortDirection.Descending)
            GridView2.DataBind()
            If GridView2.Rows.Count > 0 Then
                GridView2.HeaderRow.Cells(0).Text = "Principe actif"
                GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
                GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
                GridView2.HeaderRow.Cells(3).Text = "Note"
                GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
                GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
            End If
            If GridView2.PageCount = 0 Then
                Button1.Visible = True
                Button1.Enabled = False
            Else
                Button1.Visible = True
                Button1.Enabled = True
            End If
        Else
            If GridView2.SelectedIndex >= 0 Then
                If Not (InStr(TextBox1.Text, "FAVORI") > 0 Or InStr(TextBox1.Text, "Pas de médicament favori") > 0) Then
                    GridView2.DataSource = Direct6(Direct5(list), False)
                    GridView2.DataBind()
                    TextBox1.Visible = True
                    GridView2.Visible = True
                    GridView2.Enabled = True
                    ListBox1.Visible = False
                    TextBox2.Visible = False
                    GridView2.HeaderRow.Cells(0).Text = "Principe actif"
                    GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
                    GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
                    GridView2.HeaderRow.Cells(3).Text = "Note"
                    GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    Select Case param5.Value
                        Case "fr"
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                        Case "en"
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                        Case Else
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                    End Select
                Else
                    Select Case param5.Value
                        Case "fr"
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                        Case "en"
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                        Case Else
                            Response.Redirect(Replace("http://base-donnees-publique.medicaments.gouv.fr/?txtCaracteres=" & (LTrim(GridView2.SelectedDataKey.Item("Nom").Substring(0, 1).ToUpper & GridView2.SelectedDataKey.Item("Nom").Substring(1).ToUpper)).Split(delimiter)(0), "%20", " "))
                    End Select
                End If
            Else
                TextBox1.Visible = True
                TextBox2.Visible = False
                GridView2.Visible = True
                ListBox1.Visible = False
                If GridView2.SelectedIndex <> -1 Then
                    TextBox1.Visible = False
                    TextBox2.Visible = True
                    TextBox1.Text = ""
                    Label1.Text = "Médicaments"
                    Label2.Text = "Commentaires de l'Expert"
                    GridView2.DataSource = Direct6(Direct5(list), False)
                    GridView2.DataBind()
                    GridView2.HeaderRow.Cells(0).Text = "Principe actif"
                    GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
                    GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
                    GridView2.HeaderRow.Cells(3).Text = "Note"
                    GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    GridView2.Sort("Note", SortDirection.Descending)
                    list = Direct6(list, False)
                    Button1.Visible = True
                    Button1.Enabled = True
                End If
            End If
            If ListBox1.SelectedIndex = -1 Then
                TextBox1.Visible = False
                GridView2.Visible = False
                ListBox1.Visible = True
                TextBox2.Visible = True
                Label1.Text = "Symptômes et Maladies"
                Label2.Text = "Ce qu'il faut connaître"
            End If
            If ListBox1.Items.Count = 0 Then
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
                Dim k As Object = 0
                Dim a1 As Object = 0
                Dim a3 As Object = 0
                Dim a4 As Object = False
                If (param1 = "ADULTES" Or param2.Text = "ADULTES") Or Not (InStr(param1, "enfant") > 0 Or InStr(param1, "nourrisson") > 0 Or InStr(param1, "Poussées") > 0) Then
                    a1 = 0
                    a3 = 3091
                    a4 = True
                End If
                If (param1 = "ENFANTS" Or param2.Text = "ENFANTS") Or (InStr(param1, "enfant") > 0 Or InStr(param1, "nourrisson") > 0 Or InStr(param1, "Poussées") > 0) Then
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
                myObject = Nothing
                TextBox1.Visible = False
                GridView2.Visible = False
                GridView2.Enabled = True
                ListBox1.Visible = True
                TextBox2.Visible = True
                Button1.Visible = True
                Button1.Enabled = True
                TextBox2.Text = ""
                ListBox1.Enabled = True
                TextBox2.Enabled = True
                Dim h As Object = 0
                If param1 <> "" Then
                    For h = 0 To ListBox1.Items.Count - 1
                        If UCase(Trim(ListBox1.Items(h).Text)).Equals(UCase(Trim(param1))) = True Then
                            ListBox1.Items(h).Selected = True
                            ListBox1_TextChanged(ListBox1, Nothing)
                        End If
                    Next
                End If
            End If
        End If

        ListBox1.Focus()

    End Sub

    Private Sub alert()
        Throw New NotImplementedException()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        adultes2.Visible = False
        enfants2.Visible = False
        ListBox1.Visible = False
        TextBox2.Visible = False
        Label1.Visible = True
        GridView2.DataSource = Direct6(Direct5(list), True)
        GridView2.DataBind()
        GridView2.HeaderRow.Cells(0).Text = "Principe actif"
        GridView2.HeaderRow.Cells(1).Text = "Composition du Produit"
        GridView2.HeaderRow.Cells(2).Text = "Nom de spécialité"
        GridView2.HeaderRow.Cells(3).Text = "Note"
        GridView2.HeaderRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
        GridView2.HeaderRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
        TextBox1.Visible = True
        GridView2.Visible = True

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim meta As HtmlMeta = New HtmlMeta()
        meta.Content = "automedication troubles santé benins efficacité effets indésirables médicaments sans ordonnnance populations fragiles médicaments favoris"
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
    Private Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub

    Private Sub adultes_ServerClick(sender As Object, e As EventArgs) Handles adultes2.ServerClick
        param2.Text = "ADULTES"
        Button1_Click(sender, New System.EventArgs())
    End Sub

    Private Sub enfants_ServerClick(sender As Object, e As EventArgs) Handles enfants2.ServerClick
        param2.Text = "ENFANTS"
        Button1_Click(sender, New System.EventArgs())
    End Sub

    Private Sub GridView2_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView2.Sorting

    End Sub

End Class
 
Public Class Test
    Public Function Test() As Test
        Test = Nothing
        Return Test
    End Function
    Public Sub New(ByVal name As String, ByVal note As String, ByVal DCI As String, ByVal Produit As String)
        _dci = DCI
        _prd = Produit
        _name = name
        _note = note
    End Sub
    Private _dci As String
    Public Property DCI() As String
        Get
            Return _dci
        End Get
        Set(ByVal value As String)
            _dci = value
        End Set
    End Property
    Private _prd As String
    Public Property Produit() As String
        Get
            Return _prd
        End Get
        Set(ByVal value As String)
            _prd = value
        End Set
    End Property
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

End Class



