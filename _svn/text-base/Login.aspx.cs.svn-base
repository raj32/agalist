using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductListDBModel;

public partial class Login : System.Web.UI.Page
{
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    UserVariables currentUser = new UserVariables();
    
            
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserIdNew"] != null)
        {
            string username;
            int UserIdNew = Convert.ToInt16(Request.Cookies["UserIdNew"].Value); 
            username = (from b in myDBhandler.Clients where b.user_id == UserIdNew select b.email).First<string>();

            username = username.Split('@')[0];

            FormsAuthentication.RedirectFromLoginPage(username, false);
            Response.Redirect("~/TheMainListPage.aspx");

        }
        

    }

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {        
        Response.Redirect("~/RegisterUser.aspx");
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        IEnumerable<Client> arrClients = from a in myDBhandler.Clients select a;


        foreach (Client item in arrClients)
        {

            bool UsernameIsValid = tbxEmail.Text == item.email;
            bool PasswordIsValid = tbxPassword.Text == item.password;

            if (UsernameIsValid && PasswordIsValid)
            {
                string username;
                username = item.email.Split('@')[0];
                FormsAuthentication.RedirectFromLoginPage(username, false);
                IEnumerable<Client> updClient = from b in arrClients where b.email == tbxEmail.Text select b;       //Find exact client that loggedin and update it's last login date.
                Response.Cookies["UserIdNew"].Value = item.user_id.ToString();
                Response.Cookies["UserIdNew"].Expires = DateTime.Now.AddDays(364);
                updClient.First<Client>().last_login_date = DateTime.Now;                                 
                Response.Redirect("~/TheMainListPage.aspx");
            }
            else
            {
                LoginMessageLabel.Text = "מייל או סיסמא שגויים";
            }
            
        }

        myDBhandler.SaveChanges();
        
    }
}