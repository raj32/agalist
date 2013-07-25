<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TipsPage.aspx.cs" Inherits="TipsPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="LoginContent" runat="server" ContentPlaceHolderID="UsernamePassHolder">
    <%--   <asp:ScriptManager ID="WelcomeScriptManager" runat="server">
    </asp:ScriptManager>--%>
    <script type="text/javascript" src="jquery-1.6.2.js"></script>  
    <script type="text/javascript" src="jquery.slidingmessage.js"></script>
    <script type="text/javascript" >
        var options = {id: 'message_from_top',
               position: 'bottom',
               size: 50,
               backgroundColor: '#FF9900',
               delay: 4500,
               speed: 500,
               fontSize: '15px'                          
              };                
        $(document).ready(function() {<%=ScriptToRun %>, options);  });      
    </script>
    <div class="LoginDiv">
        <table>
            <tr>
                <td dir="ltr">
                    <asp:TextBox ID="tbxEmail" runat="server" Width="150px" TabIndex="1" BorderStyle="Ridge"
                        BorderColor="#FF9900" CssClass="iPhoneLogin"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbxEmailTextBoxWatermarkExtender" runat="server"
                        TargetControlID="tbxEmail" WatermarkText="israel@israeli.co.il" WatermarkCssClass="LoginWatermark">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td>
                    &nbsp &nbsp
                </td>
                <td dir="ltr">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" Width="150px" TabIndex="2"
                        BorderStyle="Ridge" BorderColor="#FF9900"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbxPasswordTextBoxWatermarkExtender" runat="server"
                        TargetControlID="tbxPassword" WatermarkText="password" WatermarkCssClass="LoginWatermark">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td>
                    <asp:Button ID="btnEnter" runat="server" Text="כניסה" Font-Size="Small" CssClass="BtnClass"
                        OnClick="btnEnter_Click" TabIndex="3" BorderStyle="Ridge" />
                </td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" OnClick="ButtonRegister_Click" Text="הרשמה"
                        Font-Size="Small" CssClass="BtnClass" CausesValidation="False" TabIndex="4" Height="24px" />
                </td>
            </tr>
        </table>
        <div style="margin-right: 10px;">
            <asp:LinkButton ID="btnPasswordReminder" runat="server" Font-Size="9px" CausesValidation="false"
                OnClick="btnPasswordReminder_Click">שכחתי סיסמא</asp:LinkButton>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div style="direction: rtl;">
        <asp:Label ID="LoginMessageLabel" runat="server" ForeColor="#fc9937" Font-Bold="True"></asp:Label>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="שדה סיסמא לא יכול להיות ריק"
            ControlToValidate="tbxPassword" ForeColor="#fc9937" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>
        &nbsp
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="tbxEmail"
            Display="Dynamic" ErrorMessage="שדה מייל לא יכול להיות ריק" ForeColor="#fc9937"
            Font-Bold="True"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="MailRegularExpressionValidator" runat="server"
            ErrorMessage="אנא ודא שמייל שהזנת תקין" ControlToValidate="tbxEmail" Display="Dynamic"
            ForeColor="#fc9937" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Font-Bold="True"></asp:RegularExpressionValidator>
    </div>
</asp:Content>
<asp:Content ID="DefContent" runat="server" ContentPlaceHolderID="CentralPlaceHolder">
    <div id="divPassReminder" style="width: 540px; direction: rtl; margin: 10px 10px 10px 10px;">
        <asp:Label ID="lblmailReminder" runat="server" Text="אי-מייל" Visible="false" ForeColor="#124a71"></asp:Label>
        <asp:TextBox ID="tbxmailReminder" Width="150px" BorderStyle="Ridge" BorderColor="#FF9900"
            runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="btnSendReminder" runat="server" Text="שלח" CssClass="BtnClass" Visible="false"
            CausesValidation="false" Font-Size="Small" Height="24px" OnClick="btnSendReminder_Click" />
    </div>

<div  style ="background:white; direction:rtl; float:left;width:800px; margin-bottom:20px;">
    <div class="CentralPanelDiv">
        <div class="CenterOfCenterPageDiv">
          
                <div style="background:white; float:left; margin-top:30px;">
               
                <div class="nameTip"> הוספת טיפ חדש  </div>
                    <div class="contentTip">  
                        <asp:TextBox ID="tbxNewTip" runat="server" Width="400px" Height="50px" CausesValidation="false" AutoComplete="off" TextMode="MultiLine"  ForeColor="#F96C05"> </asp:TextBox> 
                        <div id="oink" style = " direction:ltr;  text-align:left; margin-left:5px; ">
                            <asp:Button ID="btnAddNewTip" runat="server" Text="הוסף" class="BtnClass"  CausesValidation="false"
                               onclick="btnAddNewTip_Click"  />
                        </div>
                    </div>
                    <br />
                     <%=ProductListDBModel.DBUtils.getAllTipsForScr%>  
                     <br />
                    <br />
                </div>
        </div>
        <div  class="RightOfCenterPageDiv" style=" background:white;" dir="rtl">
            <div style=" margin-top:-35px; margin-right:35px;">
                <asp:Button ID="HomeButton" runat="server" CssClass ="BtnClass" 
                    width = "65px" CausesValidation = "false" ToolTip="homepage"  Text = "לדף הבית"
                    onclick="HomeButton_Click"> </asp:Button>
            </div>
            <div style="background:white;">
                <div id="AdInList" style= " width:180px; margin-left:40px; margin-top:25px; " >
                                            <script type="text/javascript"><!--
                google_ad_client = "ca-pub-9177698621225528";
                /* inTipsPageAd */
                google_ad_slot = "3700196406";
                google_ad_width = 160;
                google_ad_height = 600;
                //-->
                </script>
                    <script type="text/javascript"
                    src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
                <br />
                <br />

            </div>
            </div>
        </div>
</div>             

    </div>
</asp:Content>
