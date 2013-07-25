<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" %>


     
    <asp:Content ID="RegisterUserCont" runat="server" ContentPlaceHolderID="CentralPlaceHolder">        
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
        <div class="CentralPanelDiv">    

        <div style="clear: both;"></div>

        <div class="CentralMainDiv">
          
            <div style = "border:2px solid #FF9900; width:94%; margin-right:20px; padding-top:20px; padding-bottom:20px; height:230px;">
            <div style = " float:right;">
            <div id="EmailLabelDiv" class="RegisterGroupDivEdge" >
                    <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="אי מייל "></asp:Label>
            </div>

            <div id="EmailTextBoxDiv" class="RegisterGroupDiv" >
                <asp:TextBox ID="tbxEmail" runat="server" style="width: 159px; margin-left: 0px;"></asp:TextBox>
            </div>

            <div id="EmailValidationDiv" class="RegisterGroupDiv" >
            
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" 
                    ControlToValidate="tbxEmail" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ForeColor="Red" EnableViewState="False">שדה חובה</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" 
                    runat="server" ControlToValidate="tbxEmail" Display="Dynamic" 
                    ErrorMessage="כתובת מייל שגויה" ForeColor="Red" SetFocusOnError="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">כתובת מייל שגויה</asp:RegularExpressionValidator>
            
            </div>

        
        <div style="clear: both;"></div>   


            <div id="LivingCityLabelDiv" class="RegisterGroupDivEdge" >
                    <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="עיר מגורים"></asp:Label>
            </div>

            <div id="LivingCityComboboxDiv" class="RegisterGroupDiv" >
                <span id="locations" class="comboblack12" lang="he"  >
                                    <select class="comboblack12" id="comboDummyCities" runat="server">
                                    <option value="0">בחר יישוב</option>
                                    <option value="אבו גוש">אבו גוש </option>
                                    <option value="אבו סנאן">אבו סנאן </option>
                                    <option value="אביחיל">אביחיל </option>
                                    <option value="אבן יהודה">אבן יהודה </option>
                                    <option value="אודים">אודים </option>
                                    <option value="אום אל פחם">אום אל פחם </option>
                                    <option value="אופקים">אופקים </option>
                                    <option value="אור יהודה">אור יהודה </option>
                                    <option value="אור עקיבא">אור עקיבא </option>
                                    <option value="אורנית">אורנית </option>
                                    <option value="אזור">אזור </option>
                                    <option value="אילת">אילת </option>
                                    <option value="אכסאל">אכסאל </option>
                                    <option value="אלון מורה">אלון מורה </option>
                                    <option value="אלון שבות">אלון שבות </option>
                                    <option value="אלונים">אלונים </option>
                                    <option value="אליכין">אליכין </option>
                                    <option value="אלעד">אלעד </option>
                                    <option value="אלפי מנשה">אלפי מנשה </option>
                                    <option value="אלקנה">אלקנה </option>
                                    <option value="אעבלין">אעבלין </option>
                                    <option value="אפיקים">אפיקים </option>
                                    <option value="אפק">אפק </option>
                                    <option value="אפרתה">אפרתה </option>
                                    <option value="אריאל">אריאל </option>
                                    <option value="אשדוד">אשדוד </option>
                                    <option value="אשקלון">אשקלון </option>
                                    <option value="באקה אל-גרביה">באקה אל-גרביה </option>
                                    <option value="באר יעקב">באר יעקב </option>
                                    <option value="באר שבע">באר שבע </option>
                                    <option value="בארות יצחק">בארות יצחק </option>
                                    <option value="בועיינה-נוג`ידאת">בועיינה-נוג`ידאת </option>
                                    <option value="ביצרון">ביצרון </option>
                                    <option value="ביר אל-מכסור">ביר אל-מכסור </option>
                                    <option value="בית אורן">בית אורן </option>
                                    <option value="בית אל א'">בית אל א' </option>
                                    <option value="בית אריה">בית אריה </option>
                                    <option value="בית ג`ן">בית ג`ן </option>
                                    <option value="בית דגן">בית דגן </option>
                                    <option value="בית השיטה">בית השיטה </option>
                                    <option value="בית זית">בית זית </option>
                                    <option value="בית חולים אסף הרופא">בית חולים אסף הרופא </option>
                                    <option value="בית חנן">בית חנן </option>
                                    <option value="בית יצחק">בית יצחק </option>
                                    <option value="בית שאן">בית שאן </option>
                                    <option value="בית שמש">בית שמש </option>
                                    <option value="בית?ר עילית">בית"ר עילית </option>
                                    <option value="בני ברק">בני ברק </option>
                                    <option value="בני יהודה">בני יהודה </option>
                                    <option value="בני עטרות">בני עטרות </option>
                                    <option value="בני עי?ש">בני עי"ש </option>
                                    <option value="בני ציון">בני ציון </option>
                                    <option value="בנימינה">בנימינה </option>
                                    <option value="בסמת טבעון">בסמת טבעון </option>
                                    <option value="בענה">בענה </option>
                                    <option value="בצרה">בצרה </option>
                                    <option value="ברקן">ברקן </option>
                                    <option value="בת חפר">בת חפר </option>
                                    <option value="בת ים">בת ים </option>
                                    <option value="ג`דיידה-מכר">ג`דיידה-מכר </option>
                                    <option value="ג`ולס">ג`ולס </option>
                                    <option value="ג`סאר א-זרקא">ג`סאר א-זרקא </option>
                                    <option value="ג`ש-גוש חלב">ג`ש-גוש חלב </option>
                                    <option value="ג`ת">ג`ת </option>
                                    <option value="גבעת ברנר">גבעת ברנר </option>
                                    <option value="גבעת השלושה">גבעת השלושה </option>
                                    <option value="גבעת זאב">גבעת זאב </option>
                                    <option value="גבעת עדה">גבעת עדה </option>
                                    <option value="גבעת שמואל">גבעת שמואל </option>
                                    <option value="גבעתיים">גבעתיים </option>
                                    <option value="גדרה">גדרה </option>
                                    <option value="גורן">גורן </option>
                                    <option value="גן יבנה">גן יבנה </option>
                                    <option value="גני תקוה">גני תקוה </option>
                                    <option value="געש">געש </option>
                                    <option value="דאלית אל-כרמל">דאלית אל-כרמל </option>
                                    <option value="דבוריה">דבוריה </option>
                                    <option value="דימונה">דימונה </option>
                                    <option value="דיר אל-אסד">דיר אל-אסד </option>
                                    <option value="דיר חנא">דיר חנא </option>
                                    <option value="דליה">דליה </option>
                                    <option value="הוד השרון">הוד השרון </option>
                                    <option value="העוגן">העוגן </option>
                                    <option value="הרצליה">הרצליה </option>
                                    <option value="זכרון יעקב">זכרון יעקב </option>
                                    <option value="זלפה">זלפה </option>
                                    <option value="זמר">זמר </option>
                                    <option value="חדרה">חדרה </option>
                                    <option value="חולון">חולון </option>
                                    <option value="חורה">חורה </option>
                                    <option value="חורשים">חורשים </option>
                                    <option value="חיפה">חיפה </option>
                                    <option value="חמד">חמד </option>
                                    <option value="חניתה">חניתה </option>
                                    <option value="חצור-אשדוד">חצור-אשדוד </option>
                                    <option value="חצור הגלילית">חצור הגלילית </option>
                                    <option value="חרפיש">חרפיש </option>
                                    <option value="טבריה">טבריה </option>
                                    <option value="טובה-זנגריה">טובה-זנגריה </option>
                                    <option value="טורעאן">טורעאן </option>
                                    <option value="טייבה במשולש">טייבה במשולש </option>
                                    <option value="טירה">טירה </option>
                                    <option value="טירת כרמל">טירת כרמל </option>
                                    <option value="טמרה">טמרה </option>
                                    <option value="יאנוח-ג`ת">יאנוח-ג`ת </option>
                                    <option value="יבנאל">יבנאל </option>
                                    <option value="יבנה">יבנה </option>
                                    <option value="יגור">יגור </option>
                                    <option value="יד בנימין">יד בנימין </option>
                                    <option value="ידידיה">ידידיה </option>
                                    <option value="יהוד">יהוד </option>
                                    <option value="יסוד המעלה">יסוד המעלה </option>
                                    <option value="יפיע">יפיע </option>
                                    <option value="יקום">יקום </option>
                                    <option value="יקנעם-מושבה">יקנעם-מושבה </option>
                                    <option value="יקנעם עילית">יקנעם עילית </option>
                                    <option value="ירוחם">ירוחם </option>
                                    <option value="ירושלים">ירושלים </option>
                                    <option value="ירכא">ירכא </option>
                                    <option value="כאבול">כאבול </option>
                                    <option value="כאוכב אל-היג`א">כאוכב אל-היג`א </option>
                                    <option value="כוכב יאיר">כוכב יאיר </option>
                                    <option value="כסיפה">כסיפה </option>
                                    <option value="כסרא-סמיע">כסרא-סמיע </option>
                                    <option value="כפר ברא">כפר ברא </option>
                                    <option value="כפר החורש">כפר החורש </option>
                                    <option value="כפר המכבי">כפר המכבי </option>
                                    <option value="כפר הרא?ה">כפר הרא"ה </option>
                                    <option value="כפר ויתקין">כפר ויתקין </option>
                                    <option value="כפר ורדים">כפר ורדים </option>
                                    <option value="כפר חב?ד">כפר חב"ד </option>
                                    <option value="כפר חיים">כפר חיים </option>
                                    <option value="כפר חסידים ב`">כפר חסידים ב` </option>
                                    <option value="כפר יאסיף">כפר יאסיף </option>
                                    <option value="כפר יונה">כפר יונה </option>
                                    <option value="כפר כמא">כפר כמא </option>
                                    <option value="כפר כנא">כפר כנא </option>
                                    <option value="כפר מונש">כפר מונש </option>
                                    <option value="כפר מנדא">כפר מנדא </option>
                                    <option value="כפר סבא">כפר סבא </option>
                                    <option value="כפר סירקין">כפר סירקין </option>
                                    <option value="כפר עקב">כפר עקב </option>
                                    <option value="כפר קאסם">כפר קאסם </option>
                                    <option value="כפר קרע">כפר קרע </option>
                                    <option value="כפר שמריהו">כפר שמריהו </option>
                                    <option value="כפר תבור">כפר תבור </option>
                                    <option value="כרמי יוסף">כרמי יוסף </option>
                                    <option value="כרמיאל">כרמיאל </option>
                                    <option value="להבים">להבים </option>
                                    <option value="לוד">לוד </option>
                                    <option value="מ.א. גלבוע">מ.א. גלבוע </option>
                                    <option value="מבוא ביתר">מבוא ביתר </option>
                                    <option value="מבשרת ציון">מבשרת ציון </option>
                                    <option value="מג`ד אל-כרום">מג`ד אל-כרום </option>
                                    <option value="מגאר">מגאר </option>
                                    <option value="מגדל">מגדל </option>
                                    <option value="מגדל העמק">מגדל העמק </option>
                                    <option value="מגדל תפן">מגדל תפן </option>
                                    <option value="מגשימים">מגשימים </option>
                                    <option value="מדרשת בן גוריון">מדרשת בן גוריון </option>
                                    <option value="מדרשת רופין">מדרשת רופין </option>
                                    <option value="מודיעין">מודיעין </option>
                                    <option value="מודיעין עילית">מודיעין עילית </option>
                                    <option value="מוצמוץ">מוצמוץ </option>
                                    <option value="מזכרת בתיה">מזכרת בתיה </option>
                                    <option value="מזרעה">מזרעה </option>
                                    <option value="מטולה">מטולה </option>
                                    <option value="מירון">מירון </option>
                                    <option value="מיתר">מיתר </option>
                                    <option value="מכבים-רעות">מכבים-רעות </option>
                                    <option value="מכמורת">מכמורת </option>
                                    <option value="מנחמיה">מנחמיה </option>
                                    <option value="מסעדה">מסעדה </option>
                                    <option value="מעברות">מעברות </option>
                                    <option value="מעלה אדומים">מעלה אדומים </option>
                                    <option value="מעלה אפרים">מעלה אפרים </option>
                                    <option value="מעלות">מעלות </option>
                                    <option value="מעלות-תרשיחא">מעלות-תרשיחא </option>
                                    <option value="מעליא">מעליא </option>
                                    <option value="מצפה רמון">מצפה רמון </option>
                                    <option value="מרכז שפירא">מרכז שפירא </option>
                                    <option value="משהד">משהד </option>
                                    <option value="משמר השבעה">משמר השבעה </option>
                                    <option value="משמר השרון">משמר השרון </option>
                                    <option value="מתן">מתן </option>
                                    <option value="נהורה">נהורה </option>
                                    <option value="נהלל">נהלל </option>
                                    <option value="נהריה">נהריה </option>
                                    <option value="נוה ימין">נוה ימין </option>
                                    <option value="נווה אפרים">נווה אפרים </option>
                                    <option value="נווה ירק">נווה ירק </option>
                                    <option value="נחלים">נחלים </option>
                                    <option value="נחף">נחף </option>
                                    <option value="נחשון">נחשון </option>
                                    <option value="ניר צבי">ניר צבי </option>
                                    <option value="נמל תעופה בן גוריון (לוד)">נמל תעופה בן גוריון (לוד) </option>
                                    <option value="נס ציונה">נס ציונה </option>
                                    <option value="נען">נען </option>
                                    <option value="נצרת">נצרת </option>
                                    <option value="נצרת עילית">נצרת עילית </option>
                                    <option value="נשר">נשר </option>
                                    <option value="נתיבות">נתיבות </option>
                                    <option value="נתניה">נתניה </option>
                                    <option value="סאג`ור">סאג`ור </option>
                                    <option value="סביון">סביון </option>
                                    <option value="סח`נין">סח`נין </option>
                                    <option value="עומר">עומר </option>
                                    <option value="עופרה">עופרה </option>
                                    <option value="עילבון">עילבון </option>
                                    <option value="עילוט">עילוט </option>
                                    <option value="עין חרוד-מאוחד">עין חרוד-מאוחד </option>
                                    <option value="עין מאהל">עין מאהל </option>
                                    <option value="עינת">עינת </option>
                                    <option value="עירון">עירון </option>
                                    <option value="עכו">עכו </option>
                                    <option value="עלי">עלי </option>
                                    <option value="עמנואל">עמנואל </option>
                                    <option value="עספיא">עספיא </option>
                                    <option value="עפולה">עפולה </option>
                                    <option value="עראבה">עראבה </option>
                                    <option value="ערד">ערד </option>
                                    <option value="ערערה">ערערה </option>
                                    <option value="ערערה (בנגב)/ערוער">ערערה (בנגב)/ערוער </option>
                                    <option value="עשרת">עשרת </option>
                                    <option value="עתלית">עתלית </option>
                                    <option value="פארק ראם">פארק ראם </option>
                                    <option value="פוריידיס">פוריידיס </option>
                                    <option value="פסוטה">פסוטה </option>
                                    <option value="פקיעין">פקיעין </option>
                                    <option value="פרדס חנה-כרכור">פרדס חנה-כרכור </option>
                                    <option value="פרדסיה">פרדסיה </option>
                                    <option value="פתח תקוה">פתח תקוה </option>
                                    <option value="צופית">צופית </option>
                                    <option value="צור יגאל">צור יגאל </option>
                                    <option value="צור יצחק ">צור יצחק </option>
                                    <option value="צפת">צפת </option>
                                    <option value="קדומים">קדומים </option>
                                    <option value="קדימה">קדימה </option>
                                    <option value="קדרון">קדרון </option>
                                    <option value="קיסריה">קיסריה </option>
                                    <option value="קלנסווה">קלנסווה </option>
                                    <option value="קציר">קציר </option>
                                    <option value="קצרין">קצרין </option>
                                    <option value="קרית אונו">קרית אונו </option>
                                    <option value="קרית ארבע">קרית ארבע </option>
                                    <option value="קרית אתא">קרית אתא </option>
                                    <option value="קרית ביאליק">קרית ביאליק </option>
                                    <option value="קרית גת">קרית גת </option>
                                    <option value="קרית חיים">קרית חיים </option>
                                    <option value="קרית טבעון">קרית טבעון </option>
                                    <option value="קרית ים">קרית ים </option>
                                    <option value="קרית מוצקין">קרית מוצקין </option>
                                    <option value="קרית מלאכי">קרית מלאכי </option>
                                    <option value="קרית עקרון">קרית עקרון </option>
                                    <option value="קרית שמואל">קרית שמואל </option>
                                    <option value="קרית שמונה">קרית שמונה </option>
                                    <option value="קרני שומרון">קרני שומרון </option>
                                    <option value="ראמה">ראמה </option>
                                    <option value="ראש העין">ראש העין </option>
                                    <option value="ראש פינה">ראש פינה </option>
                                    <option value="ראשון לציון">ראשון לציון </option>
                                    <option value="רהט">רהט </option>
                                    <option value="רחובות">רחובות </option>
                                    <option value="ריינה">ריינה </option>
                                    <option value="רמות השבים">רמות השבים </option>
                                    <option value="רמלה">רמלה </option>
                                    <option value="רמת אפעל">רמת אפעל </option>
                                    <option value="רמת גן">רמת גן </option>
                                    <option value="רמת הכובש">רמת הכובש </option>
                                    <option value="רמת השרון">רמת השרון </option>
                                    <option value="רמת ישי">רמת ישי </option>
                                    <option value="רעות-מכבים">רעות-מכבים </option>
                                    <option value="רעננה">רעננה </option>
                                    <option value="רשפון">רשפון </option>
                                    <option value="שבי ציון">שבי ציון </option>
                                    <option value="שבלי">שבלי </option>
                                    <option value="שגב שלום">שגב שלום </option>
                                    <option value="שדרות">שדרות </option>
                                    <option value="שוהם">שוהם </option>
                                    <option value="שלומי">שלומי </option>
                                    <option value="שעב">שעב </option>
                                    <option value="שער חפר">שער חפר </option>
                                    <option value="שערי תקווה">שערי תקווה </option>
                                    <option value="שפיים">שפיים </option>
                                    <option value="שפרעם">שפרעם </option>
                                    <option value="תל אביב-יפו">תל אביב-יפו </option>
                                    <option value="תל השומר">תל השומר </option>
                                    <option value="תל מונד">תל מונד </option>
                                    <option value="תל שבע">תל שבע </option>
                                    <option value="תמרה">תמרה </option>
                                    <option value="תמרת">תמרת </option>
                                    </select>
                                    </span>
                </div>

            <div id="LivingCityValidationDiv" class="RegisterGroupDiv" >
            
                </div>
             
                     <div style="clear: both;"></div>

            <div id="PasswordDiv" class="RegisterGroupDivEdge">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="סיסמא"></asp:Label>
            </div>

            <div id="PasswordTextboxDiv" class="RegisterGroupDiv" >
                    <asp:TextBox ID="tbxFirstPassword" runat="server" style="width: 159px" 
                        TextMode="Password"></asp:TextBox>
            </div>

            <div id="PasswordValidationDiv" class="RegisterGroupDiv" >
            
                    <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" 
                    ControlToValidate="tbxFirstPassword" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ForeColor="Red" SetFocusOnError="True">שדה חובה</asp:RequiredFieldValidator>
            
            </div>

                 <div style="clear: both;"></div>

            <div id="RepeatPasswordLabelDiv" class="RegisterGroupDivEdge" >
                            <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="אימות סיסמא"></asp:Label>
            </div>

            <div id="RepeatPasswordTextboxDiv" class="RegisterGroupDiv" >
                <asp:TextBox ID="tbxVerifyPassword" runat="server" style="width: 159px" 
                    TextMode="Password"></asp:TextBox>
            </div>

            <div id="RepeatPasswordValidationDiv" class="RegisterGroupDiv" >
            
                        <asp:CompareValidator ID="PasswordCompareValidator" runat="server" 
                            ControlToCompare="tbxFirstPassword" ControlToValidate="tbxVerifyPassword" 
                            Display="Dynamic" ErrorMessage="השדה שונה מהסיסמא" ForeColor="Red" 
                            SetFocusOnError="True">השדה שונה מהסיסמא</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="SecondPasswordRequiredFieldValidator0" 
                            runat="server" ControlToValidate="tbxVerifyPassword" Display="Dynamic" 
                            ErrorMessage="שדה חובה" ForeColor="Red" SetFocusOnError="True">שדה חובה</asp:RequiredFieldValidator>
            
            </div>       

    
            <div style="clear: both;"></div>

            <div id="RegisterButtonLeftSpacerDiv" class="RegisterGroupDivEdge" >
            
            </div>

            <div id="RegisterButtonDiv" class="RegisterGroupDiv" style="text-align:center" >
                <asp:Button ID="btnRegister" runat="server"  Text="הרשם"  CssClass = "BtnClass"  BorderStyle="Ridge" Font-Size="Small" 
                    onclick="btnRegister_Click" />
            </div> 
        
            <div id="RegistryLabelDiv" class="FullLengthDiv" >
                <asp:Label ID="RegisterLabel" runat="server" Font-Bold="True" 
                    ForeColor="#CC0000"></asp:Label>
            </div>

          </div>                            
       
        <div style = "float:right;">
            <img src="Images/artichoke2.jpg" />
        </div>         
               
             
            </div>
          <div style="clear:both; background-color:White;"></div>
                  
      </div >
      </div >
   </asp:Content>     
        
        