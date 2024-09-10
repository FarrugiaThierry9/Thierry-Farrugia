<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Windows.Forms" %>

<script runat="server">

    Public Sub Application_Start(sender As Object, e As EventArgs)
        
        Try
            Dim License As Aspose.Words.License = New Aspose.Words.License()
            License.SetLicense(Server.MapPath("Aspose.Words.lic"))

        Catch ex As Exception
            MsgBox("There was an error setting the license: " + ex.Message, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

</script>