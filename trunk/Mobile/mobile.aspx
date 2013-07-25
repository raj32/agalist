<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mobile.aspx.cs" Inherits="Mobile_mobile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
  <head  runat="server">
      <a href="../App_Code/DBHandler.cs">../App_Code/DBHandler.cs</a>
    <title>Welcome To Mobile Agalist</title>
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.0a4.1/jquery.mobile-1.0a4.1.min.css" />
    <script src="http://code.jquery.com/jquery-1.5.2.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.0a4.1/jquery.mobile-1.0a4.1.min.js">
  </script>
  </head>
  <body>         
      <form runat="server">
        <asp:ScriptManager ID="mobileScriptManager" runat="server"></asp:ScriptManager> 
	    <section id="page1" data-role="page" runat="server">
		    <header data-role="header"><h1>Mobile Agalist</h1></header>
		    <div class="content">
			    <p align="center">Welcome to mobile AgaList</p>
                <img src="agalistMobile.jpg" width="320px"/>
                <br />
                <br />
			    <p align="center"><a href="#page2">To login</a></p>
		    </div>
		    <footer data-role="footer" data-position="fixed"><h1>GM</h1></footer>
	    </section>

	    <section id="page2" data-role="page" runat="server">
		    <header data-role="header"><h1>Login</h1></header>
		    <div class="content">
                <br />
                <br />			   
                <asp:TextBox ID="tbxUsername" runat="server" Width="250px" Height="30px"></asp:TextBox>                
                <asp:TextBoxWatermarkExtender ID="tbxMobileEmailTextBoxWatermarkExtender" runat="server" 
                        TargetControlID="tbxUsername" WatermarkText="israel@israeli.co.il" >
                </asp:TextBoxWatermarkExtender>
                <br />
                <asp:TextBox ID="tbxPassword" runat="server" Width="250px" Height="30px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="tbxMobilePasswordTextBoxWatermarkExtender" runat="server" 
                        TargetControlID="tbxPassword" WatermarkText="password" >
                </asp:TextBoxWatermarkExtender>
			    <p align="center"><a href="#page3" data-rel="dialog" data-transition="slidedown">Go to list</a></p>
		    </div>
		    <footer data-role="footer" data-position="fixed"><h1>GM</h1></footer>
	    </section>

	    <!-- begin third page -->
	    <section id="page3" data-role="page" runat="server">
	      <header data-role="header"><h1>dfdf</h1></header>
          <h3>Unordered List</h3>
             <ul data-role="listview">
              <li><a href="#">Item</a></li>
              <li><a href="#">Item</a></li>
              <li><a href="#">Item</a></li>
            </ul>
            <h3>Ordered List</h3>
            <ol data-role="listview">
              <li><a href="#">Item</a></li>
              <li><a href="#">Item</a></li>
              <li><a href="#">Item</a></li>
            </ol>
	      <div data-role="content" class="content">
		    <p>Third page!</p>
		    <p><a href="external.html">Go to external page</a></p>
	      </div>
	      <footer data-role="footer" data-position="bottom"><h1>GM</h1></footer>
	    </section>
<!-- end third page -->
    </form>
  </body>
</html>
