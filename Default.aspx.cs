using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using ProductListDBModel;

using System.Net.Mail;
using System.Net;


public partial class _Default : System.Web.UI.Page
{

    ProdListDBEntities myDBhandler = DBHandler.GetInstance();   
    protected void Page_Load(object sender, EventArgs e)
    {
           
        if (Request.Cookies["UserIdNew"] != null)
        {
            
            string username;
            int UserIdNew = Convert.ToInt16(Request.Cookies["UserIdNew"].Value);
            try {
            username = (from b in myDBhandler.Clients where b.user_id == UserIdNew select b.email).First<string>();
            } catch(Exception d){
                username = "support@agalist.com";
            }
            username = username.Split('@')[0];
            FormsAuthentication.RedirectFromLoginPage(username, false);
            Response.Redirect("~/TheMainListPage.aspx");
        }

        if (!IsPostBack)
        {
            int userID = (from sl in DBHandler.GetInstance().Clients where sl.email == "support@agalist.com" select sl.user_id).First<int>();
            String[] myListHist = (from b in myDBhandler.Shopping_List_Hist where b.user_id == userID select b.stored_list_name).Distinct<String>().ToArray<String>();
            lstSavedBaskets2.DataSource = myListHist;
            lstSavedBaskets2.DataBind();
            lstSavedBaskets2.SelectedIndex = 0;
            //lblBasketName.Text =  lstSavedBaskets2.SelectedValue;
            Object myObj = new object();
            EventArgs myEvArg = new EventArgs();
            btnLoadSavedBasket_Click(myObj, myEvArg);
          //  lblTips.Text = "על מנת לא להתפתות לקנות מוצרים שאין בהם צורך, מומלץ להגיע לסופר עם רשימה מוכנה מראש \n\n גדכעדגכ דעידגכ עי דגכידגכעיגכ עידקטד";
            
        }
        
        //tbxTips

        LoginMessageLabel.Text = "";
    }

    protected override void OnPreRender(EventArgs e)               //Return controls to starting condition.
    {
        base.OnPreRender(e);
        if (!IsPostBack)
        {
            lblmailReminder.Visible = false;
            tbxmailReminder.Visible = false;
            btnSendReminder.Visible = false;
        }


        
    }

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegisterUser.aspx");
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        IEnumerable<Client> arrClients = from a in myDBhandler.Clients select a;

        string l_email = tbxEmail.Text.ToLower();

        
        foreach (Client item in arrClients)
        {

            bool UsernameIsValid = l_email == item.email;
            bool PasswordIsValid = tbxPassword.Text == item.password;


            if (UsernameIsValid && PasswordIsValid)
            {
                string username;
                username = item.email.Split('@')[0];
                FormsAuthentication.RedirectFromLoginPage(username, false);
                IEnumerable<Client> updClient = from b in arrClients where b.email == l_email select b;       //Find exact client that loggedin and update it's last login date.
                Response.Cookies["UserIdNew"].Value = item.user_id.ToString();
                Response.Cookies["UserIdNew"].Expires = DateTime.Now.AddDays(364);
                updClient.First<Client>().last_login_date = DateTime.Now;
                Response.Redirect("~/TheMainListPage.aspx");
            }       
        }
        LoginMessageLabel.Text = "אימייל או הסיסמא שהזנת שגויים";
        myDBhandler.SaveChanges();

    }
    
 
  protected void Menu1_MenuItemClick(object sender, EventArgs e)   
       {
           MultiView1.ActiveViewIndex = Convert.ToInt32( Menu1.SelectedValue);
  }

  protected void btnLoadSavedBasket_Click(object sender, EventArgs e)
  {
      //Delete all data for current user in Shopping_List
      List<Shopping_List> shoppingListToRemove;

      int userID = (from sl in DBHandler.GetInstance().Clients where sl.email == "support@agalist.com" select sl.user_id).First<int>();
      shoppingListToRemove = (from sl in DBHandler.GetInstance().Shopping_List where sl.user_id == userID select sl).ToList<Shopping_List>();
      for (int j = 0; j < shoppingListToRemove.Count; j++)
      {
          DBHandler.GetInstance().Shopping_List.DeleteObject(shoppingListToRemove[j]);
      }

      //Copy to Shopping_List data from Shopping_List_Hist with chosen Name
      List<Shopping_List_Hist> shoppingListToLoad;

      shoppingListToLoad = (from ll in DBHandler.GetInstance().Shopping_List_Hist where ll.user_id == userID && ll.stored_list_name == lstSavedBaskets2.SelectedItem.Value select ll).ToList<Shopping_List_Hist>();

      for (int i = 0; i < shoppingListToLoad.Count; i++)
      {
          Shopping_List myShopList = new Shopping_List()
          {
              user_id = userID,
              product_id = shoppingListToLoad[i].product_id,
              qtty = shoppingListToLoad[i].qtty,
              order_no = i
          };
          DBHandler.GetInstance().Shopping_List.AddObject(myShopList);
      }
      DBHandler.GetInstance().SaveChanges();
      ShoppingListGrid.DataBind();

      lblBasketName.Text = lstSavedBaskets2.SelectedValue;
  }

  
  protected void btnPasswordReminder_Click(object sender, EventArgs e)
  {

      if (!lblmailReminder.Visible)
      {
          tbxmailReminder.Text = tbxEmail.Text;
          tbxmailReminder.Text = "";
          lblmailReminder.Visible = true;
          tbxmailReminder.Visible = true;
          btnSendReminder.Visible = true;
      }
      else
      {
          lblmailReminder.Visible = false;
          tbxmailReminder.Visible = false;
          btnSendReminder.Visible = false;
      }
  }
  protected void btnSendReminder_Click(object sender, EventArgs e)
  {
      lblmailReminder.Visible = false;
      tbxmailReminder.Visible = false;
      btnSendReminder.Visible = false;
      AgaMail myMail = new AgaMail(tbxmailReminder.Text, MailKind.PasswordReminder);
      myMail.ExecuteSending();
      tbxEmail.Text = tbxmailReminder.Text;
      
  }
}


 