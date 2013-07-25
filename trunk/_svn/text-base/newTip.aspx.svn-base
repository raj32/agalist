<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newTip.aspx.cs" Inherits="newTip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="tipsGridView" runat="server" DataSourceID="odsTips" 
            AutoGenerateColumns="False" DataKeyNames="id" Width="100%">
            <Columns>
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                 <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" />
                 <asp:BoundField DataField="tip_content" HeaderText="tip_content" SortExpression="tip_content" ControlStyle-Width="90%"
                     Visible="True" />
                 <asp:BoundField DataField="tip_enter_date" HeaderText="tip_enter_date" SortExpression="tip_enter_date"
                     Visible="True"  ReadOnly="True" />
                 <asp:BoundField DataField="is_active" HeaderText="is_active"
                     SortExpression="is_active" />
                 <asp:BoundField DataField="user_id" HeaderText="user_id" 
                     SortExpression="user_id" ItemStyle-CssClass="quantityResizer" ReadOnly="True" />
             </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsTips" runat="server" SelectMethod="GetTips"
            DeleteMethod="DeleteTip" UpdateMethod="UpdateTips" 
            TypeName="TipsController" >
            <SelectParameters>
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="is_active" Type="Int32" />
                <asp:Parameter Name="tip_content" Type="string" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
