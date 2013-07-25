using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductListDBModel;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ShoppingListController
/// </summary>
public class ShoppingListController
{
   
	public ShoppingListController()
	{
		
	}

    public List<Shopping_List> GetShoppingList(int userID)
    {
        int l_userID = userID;
        if (userID == 99999)
        {
            l_userID = (from sl in DBHandler.GetInstance().Clients where sl.email == "support@agalist.com" select sl.user_id).First<int>();
        }
       
        List<Shopping_List> result = (from l in DBHandler.GetInstance().Shopping_List
                                      where l.user_id == l_userID
                                      select l).ToList();
        return result;
    }

    public void DeleteShoppingList(int ID)
    {

        DBHandler.GetInstance().Shopping_List.DeleteObject((from l in DBHandler.GetInstance().Shopping_List where l.id == ID select l).First<Shopping_List>());
        DBHandler.GetInstance().SaveChanges();
    }

    public void UpdateShoppingList(int ID, int qtty)
    {

        Shopping_List result = (from l in DBHandler.GetInstance().Shopping_List where l.id == ID select l).First<Shopping_List>();
        //DBHandler.GetInstance().Shopping_List.
        result.qtty = qtty;
        //DBHandler.GetInstance().Shopping_List.AddObject(result);
        DBHandler.GetInstance().SaveChanges();
        
    }
}