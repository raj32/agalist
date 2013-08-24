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
            String json = "just some text";
            //String json = @"{""event"":""UpdateAmount"",""product_id"":"+product_id.ToString()+",""amount"":"""+product_id.ToString()+""",""amount"":"""+product_id.ToString()+"""}";
            push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ"));
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(andregid)
                              .WithJson(json));
            push.StopAllServices();
        }
        
    }

    [WebMethod]
    public int VerifyUser(string username, string password)
    {
        return DBUtils.getUserId(username, password);
    }

    [WebMethod]
    public void SetUserRegId(String userId, String androidRegId)
    {
        int intUserId = Convert.ToInt16(userId);
        DBUtils.setUserRegId(intUserId, androidRegId);
    }

    [WebMethod]
    public void gcmPush()
    {
        var push = new PushBroker();

        push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ"));
        push.QueueNotification(new GcmNotification().ForDeviceRegistrationId("APA91bGVCd67wfTA6HdCwc64z3XuO3LpuWqD-tZGyHRtoWnihZOUwCIIKnlwyM3kh8Y7CMqh2k1RLFx2E0zjsGkg8MuAw90U5iizFmU6sPriqv7_w2w1XwtxtRlFkdCdb8t4UNxKFa18xYmtt6N_PsxRGeX4xvcEzQ")
                              .WithJson(@"{""alert"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}"));
                                
        push.StopAllServices();
    }



    [WebMethod] // Fucked up by Vova
    public int RegisterUser(String username, String password)
    {
        int result = 0;
        try
        {
            result = DBUtils.isExistsUser(username);

            if (result == 0)
            {
               // DBHandler.GetInstance().RegisterUser(username, password);
                //result = DBUtils.getUserId(username, password);
            }
            else
            {
                result = -1;
            }
        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
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
    }
}
