<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default5.aspx.vb" Inherits="Default5" enableEventValidation="false" Async="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>Automedication.info</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8;"/>
     <style type="text/css" >
        .auto-style6 {
            background-image: url('arcenciel.jpg');
            background-repeat:repeat;
            background-size:100%;
            background-attachment:fixed;
            margin:5% 5% 5% 5%;
            text-align: left;
            vertical-align:auto;
            opacity: 0.8;
            filter: inherit;
            font-size: xx-large;
            font-family: Comic sans MS;
            background-color:#B0E0E6;
            width:96.2%;
            height:100%;
        }
                        
                    
        .auto-style12 {
            text-align: left;
            font-size: 17pt;
            vertical-align:auto;
            font-family: Comic sans MS;
            color:#0645AD;
        }
        
         
        .auto-style15 {
            margin-left:50px;
            font-size: xx-large;
            vertical-align: top;
            text-align: left;
            font-family: Comic sans MS;
            color:#0645AD;
        }
        .auto-style16 {
            margin-left:350px;
            font-size: xx-large;
            vertical-align: top;
            text-align: left;
            font-family: Comic sans MS;
            color:#0645AD;
        }
                                 
        .auto-style22 {
             text-align: left;
             font-size: x-large;
             font-family: Comic sans MS;
             color: #0645AD;
             vertical-align: top;
             height:100%;
             width:100%;
        }
        .auto-style29 {
            font-family: Comic sans MS;
            color:#0645AD;
        }
        .zoom:hover {
            transform: scale(0.8); 
        }
   
         </style>
   
</head>     
<script type="text/javascript"  src="https://code.jquery.com/jquery-1.10.2.js" ></script>
<body runat="server" id="body" style="font-size: x-large; font-family: Comic sans MS;color:#0645AD;" class="auto-style6" >
     <form id="form1" runat="server" style="font-family: Comic sans MS ;" >
         <table>
         <tr><td><asp:Label ID="Label1" runat="server" visibility="hidden" style="font-family:Comic sans MS;color:#0645AD;" enable="false" class="auto-style15" /><asp:Label ID="Label2" runat="server" visibility="hidden" style="position: absolute;font-family:Comic sans MS;color:#0645AD;" enable="false" class="auto-style16" /></td></tr><tr>
                  <td class="auto-style12">
                  <a runat="server" href="#" style="font-family:Comic sans MS;color:#0645AD;font-size:75px;"  id="adultes2" >ADULTES</a><br />
                    <a runat="server" href="#" style="font-family:Comic sans MS;color:#0645AD;font-size:75px;"  id="enfants2" >ENFANTS</a><br />
                     <asp:ListBox ID="ListBox1" name="ListBox1"  height="0px" width="0px" visibility="hidden" ClientInstanceName="listbox1" runat="server" BackColor="White" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" ShowHeader="false"  allowsorting="true" visible="false" AutoPostBack="True" style="position: absolute;font-family: Comic sans MS;color:#0645AD;" Font-Size="30pt" CssClass="auto-style22" />
                    </td></tr><tr><td class="auto-style22">
                <asp:Gridview ID="GridView2" name="GridView2" height="0px" width="0px" visibility="hidden" ClientInstanceName="gridview2" runat="server" cellpadding="0" AutoPostBack="True" style="position: absolute;margin-top:0px;margin-left:0px;color:#0645AD;" font-family="Comic sans MS;" Font-Size= "15pt" AllowPaging="True" AutoGenerateSelectButton="false" Backcolor="White" EnableModelValidation="False" EnableTheming="False" EnableViewState="False" DataKeyNames="Nom,Note" PageIndex="1" PageSize="4" Enable="false" CssClass="auto-style22" >
                    <EditRowStyle Font-Size="Larger" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" />
                    <RowStyle BackColor="White" /><columns></columns>
               <SelectedRowStyle Font-Bold="false" Wrap="true" BackColor="#6699FF"   />
                </asp:Gridview><asp:Button ID="Button1" runat="server" visibility="hidden" style="position:absolute;" CssClass="auto-style29" Text="&gt;&gt;" Width="150px" BackColor="#9999FF" Height="100px" visible="false" />
              </td><td>
                <asp:TextBox ID="TextBox1" name="TextBox1" height="0px" width="0px" visibility="hidden" ClientInstanceName="textbox1" runat="server" style="position: relative;color:#0645AD;" font-family="Comic sans MS;" ForeColor="Black" TextMode="MultiLine" AutoPostBack="True"  Font-Size="30pt" ReadOnly="True" Rows="20" CssClass="auto-style22" Visible="False" Enable="false" />
                <asp:TextBox ID="TextBox2" name="TextBox2" height="0px" width="0px" visibility="hidden" ClientInstanceName="textbox2" runat="server" AutoPostBack="True" Font-Size="30pt" ReadOnly="True" flex="1" style="position: relative;color:#0645AD;" font-family="Comic sans MS;" TextMode="MultiLine" Rows="20" CssClass="auto-style22" Visible="False"  />   
              </td></tr><asp:Label ID="param2" runat="server" visible="false" />
         <asp:Label runat="server" name="TextBox3" id="TextBox3" visible="false" /></table><input type="hidden" runat="server" name="param5" id="param5" />

		 	  
 
<script type="text/javascript" >
const fetch = require('../httpdocs/node_modules/node-fetch');

const apiKey = "sk-CeaeYy1AW-kjsF5KzZyKxaZmwIuXeoEim2UAO0ezMtT3BlbkFJ2j4hiVYYWhU3E31o8bzh5abAtvgUsmg-6C4M1WF0wA";

async function getChatGPTResponse(userInput, chatMemory = []) {
  try {
    const response = await fetch("https://api.openai.com/v1/chat/completions", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${apiKey}`, 
      },
      body: JSON.stringify({
        model: "gpt-3.5-turbo",
        messages: [...chatMemory, { role: "user", content: userInput }],
        max_tokens: 2000,
      }),
    });

    if (!response.ok) {
      throw new Error("Error while requesting to the API");
    }

    const data = await response.json();

    if (!data.choices || !data.choices.length || !data.choices[0].message || !data.choices[0].message.content) {
      throw new Error("Invalid API response");
    }

    const chatGPTResponse = data.choices[0].message.content.trim();
    chatMemory.push({ role: "user", content: userInput });
    chatMemory.push({ role: "assistant", content: chatGPTResponse });

    return chatMemory;
  } catch (error) {
    return [{ role: "system", content: error.message }];
  }
}

async function sendMessage(userInput) {
  if (userInput !== "") {
    let chatMemory = [];
    chatMemory = await getChatGPTResponse(userInput, chatMemory);

    const responseContent = chatMemory[chatMemory.length - 1].content;
    document.getElementById("TextBox2").innerHTML = responseContent;    
  }
}
sendMessage(document.getElementById("TextBox2").innerHTML);
		 </script>
<script type="text/javascript" >
                        var h1 = Math.round($(window).height());
                        var w1 = Math.round($(window).width());
                  document.getElementById("Label2").style.visibility = "invisible"; 
                  document.getElementById("Label2").style.marginLeft = document.getElementById("Label1").style.Width + 60 + 'px';
                  document.getElementById("Label2").style.visibility = "visible"; 
                 document.getElementById("Label2").style.size="30"; 
             
              document.getElementById("Label1").style.visibility = "visible"; 
</script>
           <script type="text/javascript">
                     
                              var h1 = Math.round($(window).height());
                              var w1 = Math.round($(window).width());
		
				   if (w1 > h1)
     {
				      document.getElementById("ListBox1").style.visibility = "invisible";  
                      document.getElementById("ListBox1").style.height = Math.round(h1 * 825 / 1080, 0) + 'px'; 
                      document.getElementById("ListBox1").style.width = Math.round(w1 * 841 / 1920, 0) + 'px';
                      document.getElementById("ListBox1").style.visibility = "visible"; 
                   document.getElementById("Button1").style.visibility = "invisible";
                   document.getElementById("Button1").style.marginTop = Math.round(h1 * 841 / 1080, 0) + 'px';
             
                   document.getElementById("Button1").style.marginLeft = 0 + 'px';
                   document.getElementById("Button1").style.visibility = "visible";
			   }
				   else
				   {
					    document.getElementById("ListBox1").style.visibility = "invisible";  
                      document.getElementById("ListBox1").style.height = Math.round(h1 * 820 / 1080, 0) + 'px'; 
                      document.getElementById("ListBox1").style.width = Math.round(w1 * 800 / 1080, 0) + 'px';
                      document.getElementById("ListBox1").style.visibility = "visible"; 
                   document.getElementById("Button1").style.visibility = "invisible";
                   document.getElementById("Button1").style.marginTop = Math.round(h1 * 1500 / 1920, 0) - 7 + 'px';
             
                   document.getElementById("Button1").style.marginLeft = 0 + 'px';
                   document.getElementById("Button1").style.visibility = "visible";
				   }
			   
           </script>
           
 <script type="text/javascript">
                       
     var h1 = Math.round($(window).height());
     var w1 = Math.round($(window).width());
    
     if (w1> h1 )
     {

             var a1 = 40;
             var c1 = 10;
			 		  document.getElementById("TextBox2").style.visibility = "invisible";  
                      document.getElementById("TextBox2").style.marginTop = -4 + 'px';
                       document.getElementById("TextBox2").style.marginLeft = Math.round(-w1 * 1000 / 1920, 0) + 'px';
                      document.getElementById("TextBox2").style.height = Math.round(h1 * 814 / 1080, 0) + 'px';
                      document.getElementById("TextBox2").style.width = Math.round(w1 * 800 / 1920, 0) + 'px';
                 
                      document.getElementById("TextBox2").style.visibility = "visible"; 
         }
     if (h1 > w1) {
         var a1 = 55;
         var c1 = 8;
     
	                  document.getElementById("TextBox2").style.visibility = "invisible";  
                      document.getElementById("TextBox2").style.marginTop = -4 + 'px';
                      document.getElementById("TextBox2").style.marginLeft = Math.round(-w1 * 1660 / 1920, 0) + 'px';
                      document.getElementById("TextBox2").style.height = Math.round(h1 * 820 / 1080, 0) - 7 + 'px';
		              document.getElementById("TextBox2").style.width = Math.round(w1 * 800 / 1080, 0) + 'px';             
                      document.getElementById("TextBox2").style.visibility = "visible"; 
	 }
 </script>
             <script type="text/javascript">
             
                              var h1 = Math.round($(window).height());
                              var w1 = Math.round($(window).width());
              
                   if (w1 > h1 ) {
                       var a1 = 55;
                       document.getElementById("GridView2").style.visibility = "invisible";
                       document.getElementById("GridView2").style.height = Math.round(h1 * 820 / 1080, 0) + 'px';
                       document.getElementById("GridView2").style.width = Math.round(w1 * 800 / 1920, 0) + 'px';
                       document.getElementById("GridView2").style.fontSize = Math.round(h1 / a1) + 'pt';
                       document.getElementById("GridView2").style.visibility = "visible";
                       document.getElementById("GridView2").update();
             }
            
               if (h1 > w1) {
                   var a1 = 60;
                   document.getElementById("GridView2").style.visibility = "invisible";
                   document.getElementById("GridView2").style.height =  Math.round(h1 * 820 / 1080, 0) - 7 + 'px';
                   document.getElementById("GridView2").style.width = Math.round(w1 * 1500 / 1080, 0) + 'px';
                   document.getElementById("GridView2").style.fontSize = Math.round(h1 / a1) + 'pt';
                   document.getElementById("GridView2").style.visibility = "visible";
                   document.getElementById("GridView2").update();
             }
            
         </script>
           <script type="text/javascript"> 
              
               var h1 = Math.round($(window).height());
               var w1 = Math.round($(window).width()); 
                      
               if (w1 > h1 ) {
                   var a1 = 40;
                   var d1 = 18; 
                   document.getElementById("TextBox1").style.visibility = "invisible";
                   document.getElementById("TextBox1").style.marginLeft = Math.round(-w1 * 600 / 1080, 0) + 'px';
                   document.getElementById("TextBox1").style.marginTop = 0 + 'px';
                   document.getElementById("TextBox1").style.height = Math.round(h1 * 814 / 1080, 0) + 'px';
                   document.getElementById("TextBox1").style.width = Math.round(w1 * 800 / 1920, 0) + 'px';
                   document.getElementById("TextBox1").style.fontSize = Math.round(h1 / a1) + 'pt';
                   document.getElementById("TextBox1").style.visibility = "visible";
				   document.getElementById("Button1").style.marginTop = Math.round(h1 * 814 / 1080, 0) + 13 - d1 + 'px';
	               document.getElementById("Button1").style.marginLeft = 0 + 'px';
                   document.getElementById("TextBox1").update();
               }
               
               if (h1 > w1 ) {
                   var a1 = 65;
                   var d1 = 0;
                   document.getElementById("TextBox1").style.visibility = "invisible";
                   document.getElementById("TextBox1").style.marginTop = 0 + 'px';
                   document.getElementById("TextBox1").style.height = Math.round(h1 * 820 / 1080, 0) - 7 + 'px';
                   document.getElementById("TextBox1").style.width = Math.round(w1 * 900 / 1080, 0) + 'px';
                   document.getElementById("TextBox1").style.fontSize = Math.round(h1 / a1) + 'pt';
                   document.getElementById("TextBox1").style.marginLeft = Math.round(w1 * 1200 / 1080, 0) + 'px';
                   document.getElementById("TextBox1").style.visibility = "visible";
                   document.getElementById("Button1").style.marginTop = Math.round(h1 * 814 / 1080, 0) + 13 - d1 + 'px';
                   document.getElementById("Button1").style.marginLeft = 0 + 'px';
                   document.getElementById("TextBox1").update();
               }
</script>
</form>
</body>
</html>            

