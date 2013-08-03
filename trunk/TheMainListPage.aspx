<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheMainListPage.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="TheMainListPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="MainListPage" runat="server" ContentPlaceHolderID="CentralPlaceHolder">
    <script type="text/javascript">
        window.onload = function() {
            document.getElementById("jagalistTable").contentWindow.postMessage("", "http://agalist.com:8080");
        };

        $(document).change(function () {
            $("div > .BasketHandling").hide();

            $("div > .SavedBasketsDiv").click(function () {
                $("div > .BasketHandling").show('slow');
            });
        });
        $(document).ready(function () {
            $("div > .BasketHandling").hide();

            $("div > .SavedBasketsDiv").click(function () {
                $("div > .BasketHandling").show('slow');
            });
        });                                   
    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
         m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41057118-1', 'agalist.com');
        ga('send', 'pageview');

    </script>
    <div style="background: white; direction: rtl; float: left; width: 760px;">
        <asp:Button ID="AdminEnterButton" runat="server" Text="מנהל המערכת" CssClass="BtnClass"
                                        Width="150px" OnClick="EnterAdminPage_Click" />
        <div class="CentralPanelDiv">
            <div class="InsideCenterDiv">
                <div class="CenterOfCenterPageDiv">
                    <div style="background-color: white; text-align: right; color: White; direction: rtl;
                        padding-right: 0px; border-bottom: 5px solid #1d6ca3; border-top: 5px solid white;">
                        <h2 style="font-size: x-large; margin-top: 0px; margin-bottom: 0px; width: 300px;
                            background-color: #1d6ca3; padding-right: 10px; border: 3px solid #1d6ca3;">
                            רשימת מוצרים
                        </h2>
                    </div>
<%--                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>--%>
                    <div id="FindProductDiv" dir="ltr">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="direction: rtl; margin-right: 60px;">
                                    <asp:Label ID="Label1" runat="server" Text="מה תרצו לקנות:"></asp:Label>
                                    <asp:TextBox ID="tbxFindProduct" runat="server" autocomplete="off" Width="200px"></asp:TextBox>
                                    <asp:AutoCompleteExtender runat="server" TargetControlID="tbxFindProduct" ServiceMethod="GetCompletionList"
                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="2" ServicePath="ProductFindWebService.asmx"
                                        CompletionListCssClass="FindProductAutoCompleteExtender" CompletionInterval="50">
                                    </asp:AutoCompleteExtender>
                                    &nbsp
                                    <asp:Button ID="btnAddToList" runat="server" Text="הוסף מוצר" CssClass=" BtnClass"
                                        Width="150px" OnClick="btnAddToList_Click" />
                                    &nbsp
                                    <asp:Button ID="btnAddNewProduct" runat="server" Text="הוסף מוצר חדש" Width="150px"
                                        OnClick="btnAddNewProduct_Click" Visible="False" />
                                </div>
                                <div style="float: right; width: 550px; height:10px;">
                                    <br />
                                    <img style="float: left;" src="Images/AboutLine.jpg" />
                                    <br />
                                </div>
                                <div style="float: left; background-color: White; width: 90%; margin: 5px; margin-top: 20px;">
                                    <div style="height: 20px; text-align: center; font-weight: bolder; margin-bottom: 10px;
                                        margin-left: 70px;">
                                        <asp:Label ID="lblBasketName" runat="server" Text="רשימה אחרונה"> </asp:Label>
                                        <br />
                                        <img src="Images/UnderTipsLine.jpg" />
                                    </div>
                                    <div style="float: right; background-color: White; width: 90%;">
                                        <asp:Panel ID="GridViewPanel" runat="server" DefaultButton="btnAddNewProduct">
                                          <div style="width:486px; height:500px" >
                                                <iframe id="jagalistTable" height="500px" width="507px" src="http://www.agalist.com:8080/Jagalist/Jagalist.html" style="overflow:auto; direction:ltr;overflow-x:hidden;overflow-y:scroll;border:1px;">
                                                </iframe>
                                          </div>
                                            <div style="float: right; width: 495px;">
                                                <br />
                                                <img style="float: left;" src="Images/AboutLine.jpg" />
                                                <br />
                                            </div>
                                           <div class="CenterBottomWhiteMainDiv">
                                                <asp:TextBox ID="tbxSaveNewList" runat="server"></asp:TextBox>
                                                &nbsp
                                                <asp:Button ID="btnSaveNewList" CssClass="BtnClass" OnClick="btnSaveNewList_Click"
                                                    runat="server" Text="שמור רשימה" />
                                                &nbsp
                                                <asp:Button ID="btnDelList" CssClass="BtnClass" OnClick="btnDelList_Click"
                                                    runat="server" Text="נקה רשימה" />
                                                <br/>
                                                <asp:Label ID="lblSaveNewList" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="RightBottomWhite">
                                            </div>
                                        </asp:Panel>
                                        <asp:ObjectDataSource ID="odsShoppingList" runat="server" SelectMethod="GetShoppingList"
                                            DeleteMethod="DeleteShoppingList" UpdateMethod="UpdateShoppingList" TypeName="ShoppingListController">
                                            <SelectParameters>
                                                <asp:CookieParameter CookieName="UserIdNew" Name="userID" Type="Int32" />
                                            </SelectParameters>
                                            <DeleteParameters>
                                                <asp:Parameter Name="id" Type="Int32" />
                                            </DeleteParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="id" Type="Int32" />
                                                <asp:Parameter Name="qtty" Type="Int32" />
                                            </UpdateParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                </div>
                                <br />
                                </div>
                                <div class="NewProductDiv" id="NewProductDiv" runat="server">
                                    <div style="background-color: #FF9900; font-weight: bold;">
                                        הזן את נתוני המוצר</div>
                                    <table id="Table1" width="100%" dir="rtl">
                                        <tr>
                                            <td>
                                                דוגמא
                                            </td>
                                        </tr>
                                        <tr>
                                            <td dir="rtl" style="background-color: #CAC9C9; border: 2px solid #FF3333; width: 32%;">
                                                מיונז
                                            </td>
                                            <td dir="rtl" style="background-color: #CAC9C9; border: 2px solid #339933; width: 20%;">
                                                תלמה
                                            </td>
                                            <td dir="rtl" style="background-color: #CAC9C9; border: 2px solid #3366CC; width: 18%;">
                                                אריזה
                                            </td>
                                            <td dir="rtl" style="background-color: #CAC9C9; border: 2px solid #FF9900; width: 11%;">
                                                500
                                            </td>
                                            <td dir="rtl" style="background-color: #CAC9C9; border: 2px solid #993399; width: 18%;">
                                                גרם
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                מוצר חדש
                                            </td>
                                        </tr>
                                        <tr>
                                            <td dir="rtl" style="background-color: white; border: 2px solid #FF3333;">
                                                <asp:TextBox ID="tbxNewProductName" runat="server" Width="95%"></asp:TextBox>
                                            </td>
                                            <td dir="rtl" style="background-color: white; border: 2px solid #339933;">
                                                <asp:TextBox ID="tbxNewProdactCompanyName" runat="server" Width="95%"></asp:TextBox>
                                            </td>
                                            <td dir="rtl" style="background-color: white; border: 2px solid #3366CC;">
                                                <asp:DropDownList ID="drpPackages" runat="server" Style="margin-left: 0px; width: 98%;">
                                                </asp:DropDownList>
                                            </td>
                                            <td dir="rtl" style="background-color: white; border: 2px solid #FF9900;">
                                                <asp:TextBox ID="tbxQttyInPackage" runat="server" Style="margin-left: 0px; width: 93%;"></asp:TextBox>
                                            </td>
                                            <td dir="rtl" style="background-color: white; border: 2px solid #993399;">
                                                <asp:DropDownList ID="drpUnits" runat="server" Style="margin-left: 0px; width: 98%;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" Text="הוסף" OnClick="btnAdd_Click" Width="75px" />
                                    &nbsp
                                    <asp:Button ID="btnCancel" runat="server" Text="ביטול" OnClick="btnCancel_Click"
                                        Width="75px" />
                                </div>
                            </ContentTemplate>                        
                        </asp:UpdatePanel>
                       
                        <div id="errorsdiv" class="errorsdiv" runat="server" dir="rtl">
                            <h3>
                                שים לב !
                            </h3>
                            <table id="Table2" width="100%">
                                <tr>
                                    <td dir="rtl">
                                        <asp:Label ID="lblErrorOne" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td dir="rtl">
                                        <asp:Label ID="lblErrorTwo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="btnOK" runat="server" Text="OK" Width="75px" OnClick="btnOK_Click" />
                            &nbsp
                        </div>
                    </div>
                </div>
                <!----class="CenterOfCenterPageDiv" ----->
                <div class="RightOfCenterPageDiv" dir="rtl">
                    <div class="TipsDiv">
                        <h4 style="margin-bottom: 0px; margin-top: 100px; margin-right: 20px;">
                            רשימות מוכנות
                        </h4>
                        <img src="Images/UnderTipsLine.jpg" />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="SavedBasketsDiv" style="overflow: auto;">
                                    <asp:ListBox ID="lstSavedBaskets" runat="server" CssClass="ListClass" Rows="5" EnableTheming="True">
                                    </asp:ListBox>
                                    <br />
                                </div>
                                <div class="BasketHandling">
                                    <asp:Button ID="btnLoadSavedBasket" runat="server" CssClass="BtnClass" Text="טען"
                                        OnClick="btnLoadSavedBasket_Click" Width="70px" />
                                    <asp:Button ID="btnDeleteSavedBasket" runat="server" CssClass="BtnClass" Text="מחק"
                                        OnClick="btnDeleteSavedBasket_Click" Width="70px" />
                                </div>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                   <!-------TipsDiv------->
                    <div class="TipsDiv"> 
                        <h5 style="margin-bottom:0px; margin-top:0px; margin-right:20px;">
                            10 טיפים לחיסכון בסופר
                        </h5>
                        <img src="Images/UnderTipsLine.jpg"/>
                        <div style="clear: both;">&nbsp</div>
                        <marquee behavior="scroll" direction="up" scrollamount="1" scrolldelay="1" onmouseover="stop()" onmouseout="start()"> 
                            <div class = "ParTips">
                                    <a href="TipsPage.aspx" class = "ParTips"> <%=ProductListDBModel.DBUtils.getAllTips%>  </a>
                            </div></marquee>
                        <div class = "ParTips" style="padding-top:15px;">
                            <asp:HyperLink ID="lnkAddNewTips" runat="server" NavigateUrl="~/TipsPage.aspx" class = "AddTipLink"> להוספת טיפ לחץ כאן</asp:HyperLink> 
                        </div>
                    </div> 
                    <!-------TipsDiv------->
                </div>
                <!--  RightOfCenterPageDiv  -->
            </div>
            <!---insideCenterDiv---->
        </div>
        <!--  CentralPanelDiv  -->
    </div>
    <br />
    <div style="clear: both;">
    </div>
</asp:Content>
