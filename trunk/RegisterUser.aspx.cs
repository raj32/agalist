using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using ProductListDBModel;

public partial class RegisterUser : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
                     
        
    }

    protected override void  OnPreRender(EventArgs e)               //Return controls to starting condition.
    {
 	    base.OnPreRender(e);
        
        tbxEmail.Text = "";
        comboDummyCities.SelectedIndex = 0;
    }
        
    


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //ProdListDB.Refresh(System.Data.Objects.RefreshMode.StoreWins,);
        ProductListDBModel.Client objClient = new ProductListDBModel.Client();

        IEnumerable<Client> arrClients = from p in MasterPage.ProdListDB.Clients select p;
        
        bool UsernameIsExist=false;                                 //Checks whether current email is already exist.
        foreach (Client item in arrClients)     
        {
            if (tbxEmail.Text == item.email)
            {
                UsernameIsExist = true;
                break;
            }            
        }                


        if (UsernameIsExist)
        {
            RegisterLabel.Text = "מייל זה כבר רשום במערכת";
        }
        else
        {
            objClient.email = tbxEmail.Text.ToLower()   ;
            objClient.password = tbxFirstPassword.Text;
            objClient.join_date = DateTime.Now;
            objClient.last_login_date = DateTime.Now;           //Last login is Now, only at opening new user.
            objClient.city_id = comboDummyCities.SelectedIndex;                          
            // objClient.address =                              //To be written later
            objClient.update_date_shop_list = DateTime.Now;     //update_date_shop_list is Now only at opening new user.
            // objClient.comments =                             //To be written later
            MasterPage.ProdListDB.Clients.AddObject(objClient);
            
            try
            {
                MasterPage.ProdListDB.SaveChanges();                
               
                Response.Cookies["UserIdNew"].Value = Convert.ToString( objClient.user_id);

                string username = objClient.email.Split('@')[0];

                FormsAuthentication.RedirectFromLoginPage(username, false);

                Response.Redirect("~/TheMainListPage.aspx");
                
            }
            catch (Exception)
            {
                RegisterLabel.Text = "הרשמה נכשלה";
                throw;
            }
        }

                
        

        

        
    }
}