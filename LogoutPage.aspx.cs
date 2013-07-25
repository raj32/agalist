using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogoutPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       Response.Cookies["UserIdNew"].Expires = DateTime.Now.AddDays(-1);
       Response.Redirect("Default.aspx");
    }
}