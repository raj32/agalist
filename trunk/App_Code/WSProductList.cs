using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using ProductListDBModel;
using System.Data.SqlClient;
using System.Net;
using System.Net.Security;
using System.Text;
using System.IO;
using PushSharp;
using PushSharp.Android;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml.Linq;


/// <summary>
/// Summary description for WSProductList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSProductList : System.Web.Services.WebService {
    
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    int userID = 0;

    public WSProductList () {

    }

    [WebMethod]
    public List<String> ExportProductList(int userId)
    {
        List<String> result = new List<string>();
        try
        {
            result = DBHandler.GetInstance().Shopping_list_proc(userId).ToList<String>();
        }
        catch(Exception) { }

        if (result.Count == 0)
            result.Add("14~p~הרשימה ריקה. התחל להזין מוצרים~p~0~p~במשקל~p~0~p~0.5~p~0~n~");
        return result;
    }

    [WebMethod]
    public Boolean DeleteProduct(int userId, int productId)
    {
        Boolean success = false;
        List<String> result = new List<string>();
        success = DBUtils.deleteProduct(userId, productId);
        return success;
    }


    [WebMethod]
    public void UpdateAmount(int product_id, float amount,int userId)
    {
        DBHandler.GetInstance().UpdateProductAmount(product_id, amount, userId);
        string andregid = DBUtils.getUserRegId(userId);
        if (andregid!=null) 
        {
            var push = new PushBroker();
            String json = @"{""event"":""UpdateAmount""}";
            //String json = @"{""event"":""UpdateAmount"",""product_id"":"+product_id.ToString()+",""amount"":"""+product_id.ToString()+""",""amount"":"""+product_id.ToString()+"""}";
            push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ"));
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(andregid)
                              .WithJson(json));
            push.StopAllServices();
        }
        
    }

 /*   [WebMethod]
    public int VerifyUser(string username, string password)
    {
        return DBUtils.getUserId(username, password);
    }*/

  /*  [WebMethod]
    public void SetUserRegId(String userId, String androidRegId)
    {
        int intUserId = Convert.ToInt16(userId);
        DBUtils.setUserRegId(intUserId, androidRegId);
    }
    */
 /*   [WebMethod]
    public void gcmPush()
    {
        var push = new PushBroker();

        push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ"));
        push.QueueNotification(new GcmNotification().ForDeviceRegistrationId("APA91bGVCd67wfTA6HdCwc64z3XuO3LpuWqD-tZGyHRtoWnihZOUwCIIKnlwyM3kh8Y7CMqh2k1RLFx2E0zjsGkg8MuAw90U5iizFmU6sPriqv7_w2w1XwtxtRlFkdCdb8t4UNxKFa18xYmtt6N_PsxRGeX4xvcEzQ")
                              .WithJson(@"{""alert"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}"));
                                
        push.StopAllServices();
    }*/


/*    [WebMethod] 
    public int RegisterUser(String username, String password,int client_type)
    {
        int result = 0;
        try
        {
            result = DBUtils.isExistsUser(username);

            if (result == 0)
            {
                DBHandler.GetInstance().registeruser(username,password,client_type);
               result = DBUtils.getUserId(username, password);
            }
            else
            {
                result = -1;
            }
        }
        catch (Exception e) { result = -2; }

        return result;
    }
    */
    
  /*  [WebMethod]
    public int PasswordReminder(String username)
    {
        int result = 0;
        try
        {
            result = DBUtils.isExistsUser(username);

            if (result == 1)
            {
                AgaMail myMail = new AgaMail(username, MailKind.PasswordReminder);
                myMail.ExecuteSending();
            }
        }
        catch (Exception e) { result = -2; }

        return result;
    }*/
    
    [WebMethod]
    public XmlDocument searchProduct(String product2letters)
    {
        String result;
        List<string> str = new List<string>();
        try
        {
            str = myDBhandler.ProductListXml(product2letters).ToList<String>();
        }
        catch (Exception e)
        {
        }

        result = "<Products>";

        foreach (string itm in (str.ToArray()))
        {
            result = result + itm;
        }

        result = result + "</Products>";

        XmlDocument xm = new XmlDocument();
        xm.LoadXml(string.Format("<root>{0}</root>", result));

        return xm;
    }

    [WebMethod]
    public int AddProductToStore(int userId,int storeId,int productId,String productName,float price)
    {
        int result = 0;
        int lProductId;
        try
        {
            if (productId == 0) 
            {
                //checks if a product with same name already exists 
                lProductId = DBUtils.getProductId(productName);

                if (lProductId == 0)
                {
                    lProductId = myDBhandler.addProduct(productName);
                    lProductId = DBUtils.getProductId(productName);
                }
            }
            else
            {
                lProductId=productId;
            }

            myDBhandler.addProductToStore(userId,storeId,lProductId,price);

        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
    public int AddProductToUser(int userId, int productId, String productName)
    {
        int result = 0;
        int lProductId;
        try
        {
            if (productId == 0)
            {
                //checks if a product with same name already exists 
                lProductId = DBUtils.getProductId(productName);

                if (lProductId == 0)
                {
                    lProductId = myDBhandler.addProduct(productName);
                    lProductId = DBUtils.getProductId(productName);
                }
            }
            else
            {
                lProductId = productId;
            }

            myDBhandler.addProductToUser(userId, lProductId);

        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
    public int AddProduct(String productName)
    {
        int lProductId;
        try
        {
                //checks if a product with same name already exists 
                lProductId = DBUtils.getProductId(productName);

                if (lProductId == 0)
                {
                    lProductId = myDBhandler.addProduct(productName);
                    lProductId = DBUtils.getProductId(productName);
                }
            
        }
        catch (Exception e) { lProductId = -2; }

        return lProductId;
    }

    [WebMethod]
    public int AddProductToCategory(int productId,int categoryId)
    {
        int Result;
        try
        {
            if (myDBhandler.isexist_category(productId) != 0 && myDBhandler.isexist_category(categoryId) != 0)
            {
                myDBhandler.AddProductToCategory(categoryId, productId);
            }
        }
        catch (Exception e) { Result = -2; }

        return 0;
    }
   
}
