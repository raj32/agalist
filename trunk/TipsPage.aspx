<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TipsPage.aspx.cs" Inherits="TipsPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="LoginContent" runat="server" ContentPlaceHolderID="UsernamePassHolder">
    <asp:ScriptManager ID="WelcomeScriptManager" runat="server">
    </asp:ScriptManager>
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
    
    <div class="CentralPanelDiv">
        <div class="InsideCenterDiv">
            <div class="CenterOfCenterPageDiv">
                
            </div>
        </div>
    </div>
</asp:Content>
