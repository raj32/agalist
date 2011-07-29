<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="LoginContent" runat="server" ContentPlaceHolderID="UsernamePassHolder">
  
    <div class="LoginDiv">
        <table>                    
            <tr>
                <td dir="ltr">
                    
                    <asp:TextBox ID="tbxEmail" runat="server" Width="150px" TabIndex="1" 
                        BorderStyle="Ridge" BorderColor="#FF9900" CssClass="iPhoneLogin"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbxEmailTextBoxWatermarkExtender" runat="server" 
                        TargetControlID="tbxEmail" WatermarkText="israel@israeli.co.il" 
                        WatermarkCssClass="LoginWatermark">
                    </asp:TextBoxWatermarkExtender>
                                    
                </td>
                <td> 
                    &nbsp &nbsp 
                </td>
                <td dir="ltr">
                     <asp:TextBox ID="tbxPassword" runat="server" 
                          TextMode="Password" Width="150px" TabIndex="2" BorderStyle="Ridge" BorderColor="#FF9900" ></asp:TextBox>
                     <asp:TextBoxWatermarkExtender ID="tbxPasswordTextBoxWatermarkExtender" runat="server" 
                        TargetControlID="tbxPassword" WatermarkText="password" 
                        WatermarkCssClass="LoginWatermark">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td>
                    <asp:Button ID="btnEnter"  runat="server" Text="כניסה" Font-Size="Small"  
                        CssClass="BtnClass" onclick="btnEnter_Click" TabIndex="3"
                        BorderStyle="Ridge" />
                </td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" onclick="ButtonRegister_Click" 
                            Text="הרשמה" Font-Size="Small" CssClass="BtnClass" 
                            CausesValidation="False" TabIndex="4" Height="24px" />
                </td>
            </tr>
        </table>       
        <div style= " margin-right : 10px;">
            <asp:LinkButton ID="btnPasswordReminder" runat="server" Font-Size="9px" 
                CausesValidation="false" onclick="btnPasswordReminder_Click" >שכחתי סיסמא</asp:LinkButton>            
        </div>
    </div>

    <div style="clear:both;"></div>

    <div style= " direction:rtl; "> 
        <asp:Label ID="LoginMessageLabel" runat="server" ForeColor="#fc9937" Font-Bold="True"></asp:Label> 
                        
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" 
                            ErrorMessage="שדה סיסמא לא יכול להיות ריק" ControlToValidate="tbxPassword" 
                            ForeColor="#fc9937" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator> &nbsp
        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" 
                            ControlToValidate="tbxEmail" Display="Dynamic" 
                            ErrorMessage="שדה מייל לא יכול להיות ריק" ForeColor="#fc9937" Font-Bold="True"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="MailRegularExpressionValidator" 
                            runat="server" ErrorMessage="אנא ודא שמייל שהזנת תקין" ControlToValidate="tbxEmail" 
                            Display="Dynamic" ForeColor="#fc9937" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="True"></asp:RegularExpressionValidator>
    </div>
</asp:Content>

<asp:Content ID="DefContent" runat="server" ContentPlaceHolderID="CentralPlaceHolder">
    <asp:ScriptManager ID="WelcomeScriptManager" runat="server">
    </asp:ScriptManager>    
    <div id="divPassReminder" style="width:540px; direction:rtl; margin:10px 10px 10px 10px;">
        <asp:Label ID="lblmailReminder" runat="server" Text="אי-מייל" Visible="false" ForeColor="#124a71" ></asp:Label>
        <asp:TextBox ID="tbxmailReminder" Width="150px" BorderStyle="Ridge" BorderColor="#FF9900" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="btnSendReminder" runat="server" Text="שלח" CssClass ="BtnClass" 
            Visible="false" CausesValidation = "false" Font-Size="Small" 
            Height="24px" onclick="btnSendReminder_Click" />          
    </div>   
    <div  style ="background:white; direction:rtl; float:left;width:760px;">   
                 
            <div class="mainPageTabs">
                <asp:Menu ID="Menu1"        
                    runat="server"
                    Orientation="Horizontal"
                    height="40px"
                    StaticMenuStyle-Height= "40px"
                    StaticHoverStyle-Height = "40px"
                    StaticMenuItemStyle-Height = "40px"
                    StaticSelectedStyle-Height = "40px"
                    StaticMenuItemStyle-VerticalPadding = "10px"
                    StaticMenuItemStyle-Width = "92px"
                    StaticHoverStyle-BackColor = "#FF9900"
                    StaticMenuItemStyle-BackColor = "#D4DAE3"
                    StaticSelectedStyle-BackColor = "#F96C05"
                    StaticSelectedStyle-ForeColor = "White"
                    StaticMenuItemStyle-ForeColor = "#1d6ca3"
                    StaticEnableDefaultPopOutImage="False"
                    StaticMenuItemStyle-CssClass = "tabMenuItem"
                    OnMenuItemClick="Menu1_MenuItemClick"
                    CssClass="WelcomeMenu"
                    Font-Size="15px"
                    >
                    <Items>
                        <asp:MenuItem Text="אודות <br /> האתר" Value="1" ></asp:MenuItem>
                        <asp:MenuItem Text="רשימות <br /> מוכנות" Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="דף <br /> הבית" Value="0" ></asp:MenuItem>
                    </Items>
                   </asp:Menu>
            </div>
            <div class="tabCompensateDiv">
                <script type="text/javascript"><!--
                    google_ad_client = "ca-pub-9177698621225528";
                    /* MainTabAd */
                    google_ad_slot = "4175873554";
                    google_ad_width = 468;
                    google_ad_height = 60;
                    //-->
                    </script>
                    <script type="text/javascript"
                    src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                </script>
            </div>
            <asp:MultiView  ID="MultiView1" runat="server" ActiveViewIndex ="0">
                    <asp:View ID="View1" runat="server">  
                        <div class="MainPagePicDiv">
                            <img src="Images/MainPic800i.jpg">
                        </div>
                        <div class="CentralPanelDiv">
                            <div class = "InsideCenterDiv">
                                <div class="CenterOfCenterPageDiv">            
                   
                                        <div style="background-color:white; text-align:right; color:White; direction:rtl;  padding-right:0px; border-bottom:5px solid #1d6ca3;">
                                              <h2 style = " font-size: x-large; margin-top:0px; margin-bottom:0px;  width:300px; background-color:#1d6ca3; padding-right:10px; ">עגליסט - רשימת קניות מוכנה </h2>
                                        </div>
                                        <div style="clear:both"></div>

                                        <div style="background:white;">
                                            <div style=" background:White; border:1px solid white; color:#404142; ">
                                                <h2 style="text-align:right; "> ברוכים הבאים לאתר עגליסט   </h2>
                                            
                                                     <div style="text-align:center; width:500px;">
                                                        <h4 > השימוש החינמי באתר יאפשר לכם </h4>
                                                    </div>
                                                    <div class="CenterPanelPicDiv">
                                                        <img  src="Images/YellowPaper200x178.jpg" />
                                                    </div>
                                                   <div class="CenterPanelTextDiv">
                                                
                                                        <h5 style="text-align:right;">     
                                                        להחליף את הפתק עם רשימת הקניות לסופר לכלי חדשני יותר <br/><br/>
                                                        לנהל רשימת קניות פשוטה ואינטואיטיבית  <br/><br/>
                                                        לגשת לרשימת קניות אישית מכל מקום בו תימצאו <br/><br/> 
                                                        למנוע שיחות טלפון מיותרות בזמן הקניות <br/><br/>
                                                        לנהל רשימת קניות שבועית, לחג, לפיקניק או לכל ארוע אחר <br/><br/>
                                                        </h5>
                                                    </div>
                                            </div>
                                            <div style = " clear : both;"></div>
                                            <div style="text-align:center; width:500px; color:#404142;">
                                                <h4> מטרת האתר - רשימת קניות פשוטה  </h4>
                                            </div>
                                            <div style="background:White; border:1px solid white; color:#404142;">
                                                 <div class="CenterPanelPicDiv">
                                                    <img  src="Images/mango20ps.jpg" />
                                                 </div>

                                                <div class="CenterPanelTextDiv">
                                                    <br />
                                                    <h5 style="text-align:right;"> היתרון של רשימת הקניות של עגליסט הוא יכולת להכין רשימה עם כל מוצר הקיים בעולם, ללא הגבלה של רשתות השיווק הגדולות אשר מכוונות אתכם למוצרים מסויימים.  </h5>
                                                    <h5 style="text-align:right;">  האתר מאפשר לעדכן ולהכין רשימת קניות חוזרת על בסיס רשימת קניות קודמת או על בסיס רשימת קניות מוכנה של האתר.  </h5>
                                                 </div>
                                           
                                             </div>
                                        </div>
                                 </div> <!----class="CenterOfCenterPageDiv" ----->        
                   
                   
                                 <div  class="RightOfCenterPageDiv" dir="rtl">

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
                                            </div>
                                        </marquee>
                                        <div class = "ParTips" style="padding-top:15px;">
                                            <asp:HyperLink ID="lnkAddNewTips" runat="server" NavigateUrl="~/TipsPage.aspx" class = "AddTipLink"> להוספת טיפ לחץ כאן</asp:HyperLink> 
                                        </div>
                                    </div> 
                                    <!-------TipsDiv------->

                                    <div style="clear: both;">&nbsp</div>
                                    <div>
                                        <script type="text/javascript"><!--
                                            google_ad_client = "ca-pub-9177698621225528";
                                            /* UnderTips */
                                            google_ad_slot = "5146387945";
                                            google_ad_width = 200;
                                            google_ad_height = 200;
                                            //-->
                                            </script>
                                            <script type="text/javascript"
                                            src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                                        </script>
                                    </div>
                                </div>   <!--  RightOfCenterPageDiv  -->

                            </div> <!---insideCenterDiv---->
              
                        </div> <!--  CentralPanelDiv  -->
                    </asp:View>  
                    <asp:View ID="View2" runat="server">  
                .       <div class="CentralPanelDiv">
                            <div style = " clear : both;"></div>
                            <div style="text-align:center; width:500px;">
                                <h4> למי?  </h4>                                  
                            </div>                             
                                <div class="CenterPanelPicDiv">
                                    <img  src="Images/Fruits-3-200x178.jpg" />
                                </div>

                                <div class="AboutTextDiv">
                                  <img  style="margin-right: -50px;" src  ="Images/AboutLine.jpg" />
                                    <br />
                                    <h5 style="text-align:right;"> האתר מיועד לכל מי שנמאס לו... </h5>
                                    <h5 style="text-align:right;"> - מרשימת הקניות הידנית שהולכת לאיבוד, נקרעת, לא ברורה, ודורשת הכנה מחודשת. <br/>
                                                                   - להתקשר לביתו 20 פעם במהלך הקניות בסופרמקט. <br/>
                                                                   - לחזור לחנות שוב ושוב מכיוון ששכח משהו.
                                    </h5>
                                </div>
                                          

                            <div style = " clear : both;"></div>
                            <div style="text-align:center; width:500px;">
                                <h4> למה?</h4>
                            </div>

                                <div class="CenterPanelPicDiv">
                                    <img  src="Images/egg200x178.jpg" />
                                </div>

                                <div class="AboutTextDiv">
                                <img  style="margin-right: -50px;" src  ="Images/AboutLine.jpg" />
                                    <br />
                                    <h5 style="text-align:right;">  
                                        כי האתר פשוט ואינטואיטיבי <br />
                                        כי האתר נגיש בכל מקום (הרשימה מתאימה גם לשימוש בסמארטפונים וובאייפונים) <br />
                                        כי השימוש באתר הוא חינם <br />
                                        כי הרשימה הזו לא תלך לאיבוד <br />
                                    </h5>
                                </div>
                                           
                          
            





                            <div style = " clear : both;"></div>
                            <div style="text-align:center; width:500px;">
                                <h4>מתי?</h4>
                            </div>
                                
                 
                                <div class="CenterPanelPicDiv">
                                    <img  src="Images/Fruits-2.jpg" />
                                </div>

                                <div class="AboutTextDiv">
                                <img  style="margin-right: -50px;" src  ="Images/AboutLine.jpg" />
                                    <br />
                                    <h5 style="text-align:right;">  
                                        מתי שבא לכם!!! לפני, אחרי או ממש בזמן הקניות. הרשימה זמינה תמיד ומוכנה לקלוט את השינויים שלכם
                                    </h5>
                                </div>
                                           
                      





                            <div style = " clear : both;"></div>
                            <div style="text-align:center; width:500px;">
                                <h4>איך?</h4>
                            </div>
                    
                    
                                <div class="CenterPanelPicDiv">
                                    <img  src="Images/chicken%20cutlet5-200x178.jpg" />
                                </div>

                                <div class="AboutTextDiv">
                                <img  style="margin-right: -50px;" src  ="Images/AboutLine.jpg" />
                                    <br />
                                    <h5 style="text-align:right;">  
                                       נרשמים לאתר - ההרשמה מאוד פשוטה ודורשת את כתובת דואר האלקטרוני ועיר המגורים בלבד. (אתם לא הולכים לקבל מהאתר הודעות ללא הסכמתכם.) <br />
                                       לאחר מכן עוברים לרשימה ומתחילים להזין את המוצרים שברצונכם לקנות. <br />
                                       אחרי שרשימת הקניות מוכנה, אפשר להדפיסה או להעלות אותה מהסמארטפון. מעריצי כל הסמארטפונים, גם האייפון וגם האנדרואיד יכולים להשתמש במערכת לניהול רשימת קניות ללא התקנת אפליקציה נוספת - הכל דרך דפדפן האינטרנט. <br />
                                       שימו לב! יותר מבן אדם אחד יכול להשתמש באותו היוזר בזמן נתון, כלומר מי שמעדכן את רשימת הקניות יכול להימצא בבית בזמן שמי ששם את המוצרים בעגלה, נמצא עם הסמארטפון בסופרמרקט ורואה את העידכונים בשוטף. <br />

                                    </h5>
                                </div>
                                           
                          

                        </div>
                    </asp:View> 
                    <asp:View ID="View3" runat="server">  
                         
                        <div  style ="background:white; direction:rtl; float:left;width:760px; margin-bottom:20px;">  
                            <div class="CentralPanelDiv">    
                                <div class = "InsideCenterDiv">
                                  
                                     <div  class="RightOfCenterPageDiv" dir="rtl">
                                <div class="TipsDiv">
                                    <h4 style="margin-bottom:0px; margin-top:67px; margin-right:20px;">
                                          רשימות מוכנות
                                    </h4>                             
                                 
                                    <img src="Images/UnderTipsLine.jpg" />
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class = "SavedBasketsDiv" style = " overflow :auto;">
                                                <asp:ListBox ID="lstSavedBaskets2" runat="server" CssClass = "ListClass" 
                                                     Rows="5" EnableTheming="True"  AutoPostBack="true"
                                                    onselectedindexchanged="btnLoadSavedBasket_Click"></asp:ListBox>
                                              
                                               <br />
                                            </div>
                                       

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
                                                <%=ProductListDBModel.DBUtils.getAllTips%> 
                                            </div>
                                        </marquee>
                                    </div> 
                                    <!-------TipsDiv------->

                                    <div class="TipsDiv" style=" margin-right:20px; text-align:center;" >
                                        תגיות
                                        <h5 style="margin-bottom:-25px; margin-top:0px; text-align:center; color:#666699;"> רשימת קניות סופר </h5>  
                                        <h3 style="margin-bottom:-25px; color:#33CC66;text-align:right; "> רשימת קניות לסופר </h3> 
                                        <h5 style="margin-bottom:-25px; color:#CCCC66;text-align:right;">  רשימת קניות לתינוק </h5> 
                                        <h4 style="margin-bottom:-25px; color:#CCFFFF;text-align:right; ">  רשימת קניות בסופר</h4> 
                                        <h3 style="margin-bottom:-25px; color:#FF9933;text-align:right;">  רשימת קניות לבית</h3>
                                        <h5 style="margin-bottom:-25px; color:#CCCC66;text-align:right;">  רשימת קניות מוכנה </h5> 


                                        
                                    </div>
                                           

                             
                             </div>   <!--  RightOfCenterPageDiv  -->
                                  
                                    <div class="CenterOfCenterPageDiv">  
                                        <div style="background-color:white; text-align:right; color:White; direction:rtl;  padding-right:0px; border-bottom:5px solid #1d6ca3; border-top:5px solid white;">
                                            <h2 style = " font-size: x-large; margin-top:0px; margin-bottom:0px;  width:300px; background-color:#1d6ca3; padding-right:10px; border:3px solid #1d6ca3; "> רשימת מוצרים </h2>
                                        </div>

        
                                        <div id="FindProductDefDiv" dir="ltr" >                   
                                            <br/>

                                            <div style="float:left; background-color:White; width:380px;  ">
                                               
                                                <asp:Panel ID="GridViewPanel" runat="server">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        


                                                        <ContentTemplate>  
                                                        <div style ="height:20px; text-align:center; font-weight:bolder; margin-bottom:10px;"> 
                                                            <asp:Label ID="lblBasketName" runat="server" Text=""> </asp:Label>
                                                            <br/>
                                                            <img src="Images/UnderTipsLine.jpg" />

                                                        </div>

                                                          
                                                            <asp:GridView ID="ShoppingListGrid" runat="server" Width="100%" CellPadding="4" 
                                                                DataSourceID="odsShoppingList" ForeColor="#333333" GridLines="None" 
                                                                AutoGenerateColumns="False" BorderStyle="None" ShowHeader="False" datakeynames="id"   >
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" 
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="user_id" HeaderText="user_id" 
                                                                        SortExpression="user_id" Visible="False" />
                                                                    <asp:BoundField DataField="product_id" HeaderText="product_id" 
                                                                        SortExpression="product_id" Visible="False" />
                                                                    <asp:BoundField DataField="MeasureUnitName" HeaderText="MeasureUnitName" 
                                                                        ReadOnly="True" SortExpression="MeasureUnitName" InsertVisible="False" />
                                                                    <asp:BoundField DataField="qtty" HeaderText="qtty" SortExpression="qtty" ItemStyle-CssClass="quantityResizer" />
                           
                                                                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                                                                        ReadOnly="True" SortExpression="ProductName" >
                                                                    <ItemStyle Width="70%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                        
                                                                <EditRowStyle BackColor="White" BorderStyle="Solid" BorderColor="Red" BorderWidth="2px" />
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />                          
                                                                </asp:GridView>
                     
                                                        </ContentTemplate>  
                                                    </asp:UpdatePanel>
                                                </asp:Panel>
                   
                                                <asp:ObjectDataSource ID="odsShoppingList" runat="server" 
                                                    SelectMethod="GetShoppingList" 
                                                    TypeName="ShoppingListController">
                                                     <SelectParameters>
                                                        <asp:CookieParameter CookieName="UserIdNew" Name="userID" Type="Int32" DefaultValue = "99999" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                 
                                            <div id="AdInList" style= "float:left; background-color:White; width:160px; margin-left:5px;" >
                                                <script type="text/javascript"><!--
                                                    google_ad_client = "ca-pub-9177698621225528";
                                                    /* ReadyBasketsPicAd */
                                                    google_ad_slot = "0853253424";
                                                    google_ad_width = 160;
                                                    google_ad_height = 600;
                                                    //-->
                                                    </script>
                                                    <script type="text/javascript"
                                                    src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                                                    </script>
                                            </div>
                                        </div>
                                        <br />
            
                                    
                                
                                    </div> <!----class="CenterOfCenterPageDiv" ----->   


                                 
                             


                                </div> <!---insideCenterDiv---->
              
                            </div> <!--  CentralPanelDiv  -->
                        </div>
                    </asp:View> 
            </asp:MultiView>          

    </div>
 </asp:Content>