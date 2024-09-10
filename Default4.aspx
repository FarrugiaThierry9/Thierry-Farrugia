<%@ Page Language="VB"  CodeFile="Default4.aspx.vb" Inherits="Default4" AutoEventWireup="true" enableEventValidation="false" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
   <title>Automedication.info</title>
    <style type="text/css" >
        .auto-style6 {
            background-image: url('arcenciel.jpg');
            background-repeat:repeat;
            background-size:100%;
            background-attachment:fixed;
            margin:5% 5% 5% 5%;
            width:96.2%;
            height:100%;
            text-align: left;
            vertical-align:top;
            opacity: 0.8;
            filter: inherit;
            font-size: xx-large;
            font-family: Comic sans MS;
            background-color:#B0E0E6;
        }
          .auto-style7 {
            margin-left:500px;
            font-size: xx-large;
            font-family: Comic sans MS;
            vertical-align:top;
            color:#0645AD;
        }
          .auto-style8 {
            margin-left:50px;
            text-align: left;
            font-size: xx-large;
            font-family: Comic sans MS;
            vertical-align:top;
            color:#0645AD;
        }
       
          .auto-style22 {
            text-align: left;
            width: 100%;
            height: 100%;
            font-size: xx-large;
            vertical-align: top;
            font-family: Comic sans MS;
            visibility:hidden;
        }
        .auto-style29 {
            font-family: Comic sans MS;
            font-size: x-large;
            color:#0645AD;
        }
        
        .auto-style31 {
             text-align: left;
            font-size: x-large;
            vertical-align:auto;
            font-family: Comic sans MS;
            color:#0645AD;
        }
        .zoom:hover {
            transform: scale(0.8); 
        }
        
       </style></head>
 <script type="text/javascript"  src="https://code.jquery.com/jquery-1.10.2.js" ></script> 
   
<body runat="server" style="font-size: x-large; font-family: Comic sans MS;color:#0645AD;" class="auto-style6" >
             <form id="form1" runat="server" style="font-family: Comic sans MS ;" >
                    <table><tr><asp:Label ID="Label2" runat="server"  visibility = "hidden"  style="font-family:Comic sans MS;color:#0645AD;" enable="false" class="auto-style8"/><asp:Label ID="Label1" runat="server" visibility = "hidden" style="position: absolute;font-family:Comic sans MS;color:#0645AD;" enable="false" class="auto-style7" /></tr><tr><asp:Label ID="Label3" runat="server"  class="auto-style7"/><td class="auto-style31">
                    <a runat="server" href="#" style="font-family:Comic sans MS;color:#0645AD;font-size:75px;" id="adultes" >ADULTES</a><br />
                     <a runat="server" href="#" style="font-family:Comic sans MS;color:#0645AD;font-size:75px;" id="enfants" >ENFANTS</a><br />
                    <asp:ListBox ID="ListBox1"  height="0px" width="0px" runat="server" BackColor="White"  visibility="hidden" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" ShowHeader="false"  allowsorting="true" AutoPostBack="True" style="position: absolute;margin-top:0px;margin-left:0px;font-family: Comic sans MS;color:#0645AD;" Font-Size="30pt" autoscale="true" Visible="false" CssClass="auto-style22" ></asp:ListBox>
                    <asp:ListBox ID="ListBox2"  height="0px" width="0px" ClientInstanceName="listbox2"  runat="server" BackColor="White" visibility="hidden" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" ShowHeader="false"  allowsorting="true" AutoPostBack="True" style="position: absolute;margin-top:0px;margin-left:0px;font-family: Comic sans MS;color:#0645AD;" Font-Size="30pt" autoscale="true" Visible="false" CssClass="auto-style22" ForeColor="Black" SelectionMode="Single" selectedstyle="true"  ></asp:ListBox>
                    </td></tr><tr><td><asp:Button ID="Button1" runat="server" visibility="hidden" CssClass="auto-style29" style="position:absolute;" Text="&gt;&gt;" Width="150px" BackColor="#9999FF" Height="100px" ></asp:Button> 
                    </td><td><asp:TextBox ID="TextBox1"  height="0px" width="0px" visibility="hidden" ClientInstanceName="textbox2" runat="server"   AutoPostBack = "true" style="position: absolute;color:#0645AD" font-family="Comic sans MS" ForeColor="Black" TextMode="MultiLine"  Font-Size="30pt" ReadOnly="True" Rows="20" CssClass="auto-style22" enable="false" Visible="false" ></asp:TextBox>
                    <asp:TextBox ID="TextBox2" height="0px" width="0px" runat="server" visibility="hidden" AutoPostBack="True"  Font-Size="30pt" ReadOnly="True" style="position: absolute;color:#0645AD" font-family="Comic sans MS" TextMode="MultiLine" Rows="20" CssClass="auto-style22" enable="false" Visible="False" ></asp:TextBox><asp:ListBox ID="ListBox3"  height="0px" width="0px" runat="server" Visible="false" ></asp:ListBox>     
                    </td></tr> </table>	<input type="hidden" runat="server" name="param4" id="param4" />
       <asp:Label runat="server" id="param3" visible="false"/>
       <asp:Label ID="Label4" runat="server" visible="false" />   
 </form>
</body>               <script type="text/javascript">
           
                             var h1 = Math.round($(window).height());
                             var w1 = Math.round($(window).width());
                             if (h1 > w1 || navigator.userAgentData.mobile()) 
                             {
                                 document.getElementById("Label1").style.visibility = "invisible"; 
                                 document.getElementById("Label3").style.visibility = "invisible"; 
                              //   document.getElementById("Label1").style.marginLeft = Math.round(w1 * 200 / 1920, 0) + 'px';
                                 document.getElementById("Label1").style.marginLeft = Math.round(w1 - 800, 0) + 'px';
                                 document.getElementById("Label3").style.marginLeft = Math.round(w1 - 800, 0) + 'px';
                                 document.getElementById("Label1").style.visibility = "visible"; 
                                 document.getElementById("Label3").style.visibility = "visible";
                             }
                             else
                             {
                             //    document.getElementById("Label1").style.visibility = "invisible"; 
                                 document.getElementById("Label3").style.visibility = "invisible"; 
                                 document.getElementById("Label1").style.marginLeft = Math.round(w1 -1200, 0) + 'px';
                             //    document.getElementById("Label1").style.marginLeft = Math.round(w1 * 500 / 1920, 0) + 'px';
                                 document.getElementById("Label3").style.marginLeft = Math.round(w1 - 1200, 0) + 'px';
                                 document.getElementById("Label1").style.visibility = "visible"; 
                                 document.getElementById("Label3").style.visibility = "visible";
                             }
                            document.getElementById("Label2").style.visibility = "visible"; 
</script> 
                         <script type="text/javascript">
                   
                             var h1 = Math.round($(window).height());
                             var w1 = Math.round($(window).width());
                             
                      document.getElementById('ListBox2').style.visibility = 'invisible';
                      document.getElementById('ListBox2').style.height=Math.round(h1 * 785 / 1080, 0) + 'px';
                      document.getElementById('ListBox2').style.width = Math.round(w1 * 800 / 1920, 0) + 'px';
                      document.getElementById('ListBox2').style.visibility = 'visible';
                      document.getElementById('TextBox1').style.visibility = 'invisible';
                      document.getElementById('TextBox1').style.height=Math.round(h1 * 777 / 1080, 0) + 2  + 'px';
                      document.getElementById('TextBox1').style.width=Math.round(w1 * 800 / 1920, 0) + 'px';
                      document.getElementById('TextBox1').style.marginTop = -4 + 'px';
                      document.getElementById('TextBox1').style.marginLeft = Math.round(w1 * 800 / 1920, 0) - 4 + 'px'; 
                      document.getElementById('TextBox1').style.fontSize = Math.round(h1 / 40) + 'pt';
                      document.getElementById('TextBox1').style.visibility = 'visible';
                      document.getElementById('Button1').style.visibility = 'invisible';
                      document.getElementById('Button1').style.marginTop= Math.round(h1 * 785 / 1080, 0) + 'px';
                      document.getElementById('Button1').style.marginLeft = 0 + 'px';
                      document.getElementById('Button1').style.visibility = 'visible';
                      </script>  
</html>            

