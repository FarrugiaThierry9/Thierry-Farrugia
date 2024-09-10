Imports MSDASC
Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Partial Class [Default]
    Inherits System.Web.UI.Page

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
        If (HttpContext.Current.Request.Browser("IsMobileDevice")) Then
            form1.Style.Add("AutoScaleMode", "Times")
            form1.Style.Add("autoscaledimensions", "New System.Drawing.SizeF(4.7!, 13.3!)")
        End If
		 Dim nnn = "Comment traiter ces maux du quotidien seul et sans danger, lorsque l'on sait que plus de 50 % des médicaments sans ordonnance n'ont jamais démontré d'efficacité chez l'homme, et que tous présentent des effets indésirables, parfois graves ? Dans ce guide pratique d'automédication, le Professeur Giroud, expert international en médicaments, donne les clés pour soigner 120 troubles de santé bénins. Tout ce qu'il faut savoir sur les médicaments, leurs risques et les précautions à prendre, notamment chez les populations fragiles. Pour chacune de ces affections, toutes les manifestations, causes, signes d'alerte et conduites à tenir. Une liste de tous les médicaments disponibles sans ordonnance évalués, notés de 0 à 20 et commentés, une information introuvable ailleurs. Les médicaments recommandés ou favoris"
		
    End Sub
End Class
