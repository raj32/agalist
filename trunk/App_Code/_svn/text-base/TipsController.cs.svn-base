using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductListDBModel;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for TipsController
/// </summary>
public class TipsController
{
	public TipsController()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public List<Tip> GetTips()
    {
        List<Tip> result = (from l in DBHandler.GetInstanceProp.Tips
                                      select l).ToList();
        return result;
    }

    public void DeleteTip(int id)
    {

        DBHandler.GetInstance().Tips.DeleteObject((from l in DBHandler.GetInstance().Tips where l.id == id select l).First<Tip>());
        DBHandler.GetInstance().SaveChanges();
    }

    public void UpdateTips(int id, int is_active, String tip_content)
    {

        Tip result = (from l in DBHandler.GetInstance().Tips where l.id == id select l).First<Tip>();
        
        result.is_active = is_active;
        result.tip_content = tip_content;
        //DBHandler.GetInstance().Shopping_List.AddObject(result);
        DBHandler.GetInstance().SaveChanges();

    }



}