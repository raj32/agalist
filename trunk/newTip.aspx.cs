using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductListDBModel;

public partial class newTip : System.Web.UI.Page
{
    ProdListDBEntities myDBhandler = DBHandler.GetInstance(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        //List<Tip> allTips = new List<Tip>();
        //allTips = (from t in myDBhandler.Tips select t).ToList<Tip>();
        //tipsGridView.DataSource = allTips;
        //tipsGridView.DataBind();
    }
}