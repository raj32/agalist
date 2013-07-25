<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="CentralPlaceHolder" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnEnter">
                   
                   <div class="LeftTopYellow">
                   </div>
                   <div class="CenterTopYellowMainDiv">
                   </div>
                   <div class="RightTopYellow">
                   </div>

                   <div style="clear: both;"></div>

                   <div class="CentralMainDiv">

                   <div  class="LoginGroupDiv" style="float:right;text-align:right;">
                            <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="אי מייל"></asp:Label>
                    </div>
                    <div class="LoginGroupDiv">
                        <asp:TextBox ID="tbxEmail" runat="server" Width="100%" TabIndex="1"></asp:TextBox>
                    </div>
                    
                     <div class="LoginGroupDiv" style="float:right; text-align:right;">
                        <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="סיסמא"></asp:Label>
                    </div>     
                    <div  class="LoginGroupDiv" >
                        <asp:TextBox ID="tbxPassword" runat="server" 
                            TextMode="Password" Width="100%" TabIndex="2"></asp:TextBox>
                    </div>

                    <div  class="LoginGroupDiv" style="float:right;" >
                        <asp:Button ID="btnRegister" runat="server" onclick="ButtonRegister_Click" 
                            Text="משתמש חדש" Font-Size="Small" Width="95%" CausesValidation="False" 
                            TabIndex="4" />
                    </div>

                    <div  class="LoginGroupDiv" >
                            <asp:Button ID="btnEnter"  runat="server" Text="כניסה" Font-Size="Small" 
                                Width="95%" onclick="btnEnter_Click" TabIndex="3" />
                    </div>        
                    
                    <div class="LoginGroupErrorMessageDiv">
                        <asp:Label ID="LoginMessageLabel" runat="server" ForeColor="#CC0000"></asp:Label> <br />
                        
                        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" 
                            ErrorMessage="שדה סיסמא לא יכול להיות ריק" ControlToValidate="tbxPassword" 
                            ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator> <br />
                        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" 
                            ControlToValidate="tbxEmail" Display="Dynamic" 
                            ErrorMessage="שדה מייל לא יכול להיות ריק" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="MailRegularExpressionValidator" 
                            runat="server" ErrorMessage="אנא ודא שמייל שהזנת תקין" ControlToValidate="tbxEmail" 
                            Display="Dynamic" ForeColor="#CC0000" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    
                    </div>

                   <div style="clear: both;"></div>
                   
                   <div class="LeftBottomWhite">
                   </div>
                   <div class="CenterBottomWhiteMainDiv">
                   </div>
                   <div class="RightBottomWhite">
                   </div>
</asp:Panel>
</asp:Content>