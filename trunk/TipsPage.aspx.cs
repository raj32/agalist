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

public partial class TipsPage : System.Web.UI.Page
{

    ProdListDBEntities myDBhandler = DBHandler.GetInstance();   

    protected void Page_Load(object sender, EventArgs e)
    {

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