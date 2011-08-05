using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProductListDBModel;

public partial class MasterPage : System.Web.UI.MasterPage
{

    public static ProductListDBModel.ProdListDBEntities ProdListDB = new ProductListDBModel.ProdListDBEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        Application["Version"] = "V1.56b";
        lblVersion.Text = (string)Application["Version"];
    }



    

}


