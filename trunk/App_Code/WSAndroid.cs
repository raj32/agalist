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
public class WSAndroid : System.Web.Services.WebService {
    
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    int userID = 0;

    public WSAndroid()
    {

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
}
