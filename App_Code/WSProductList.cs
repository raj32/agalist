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

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   /* private void getCurrentUser() {
        if (userID !=0)
        {
           // System.Web.HttpContext.Current.Request.Cookies["HRU"].Value = "Oinki Oinki";
            userID = 78;
        }
        else
        {
           // System.Web.HttpContext.Current.Request.Cookies["HRU"].Value = "Oink";
            if (System.Web.HttpContext.Current.Request.Cookies["UserIdNew"] != null)
            {
             
                userID = Convert.ToInt16(System.Web.HttpContext.Current.Request.Cookies["UserIdNew"].Value);
                userID = 117;
            }
            else
            {
                userID = 117;
                //System.Web.HttpContext.Current.Request.Cookies["UserIdNew"].Value = "117";
            }
        }
        
    }
    */
    [WebMethod]
    public List<String> ExportProductList(int userId)
    {
        List<String> result = new List<string>();
        result = DBHandler.GetInstance().Shopping_list_proc(userId).ToList<String>();
        if (result.Count == 0) 
            result.Add("Empty");
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
    public string lifewatch(){
        return "oink";
    }

    [WebMethod]
    public void UpdateAmount(int product_id, float amount,int userId)
    {
       DBHandler.GetInstance().UpdateProductAmount(product_id, amount, userId);
       AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
       string strResponse = apnGCM.SendNotification("AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ", "Testtt Push Notification message ");
    }

    [WebMethod]
    public int VerifyUser(string username, string password)
    {
        return DBUtils.getUserId(username, password);
    }

    [WebMethod]
    public void SetUser(int userId)
    {
        userID = userId;
    }



    //GCM Push request Start
    /*private void GcmPush()
    {
        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");


        Request.Method = "POST";
        Request.KeepAlive = false;

        string postData = "{ 'registration_ids': [ '" + registrationId + "' ], 'data': {'message': '" + message + "'}}";

        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        Request.ContentType = "application/json";
        //Request.ContentLength = byteArray.Length;


        //Request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + AuthString);
        Request.Headers.Add(HttpRequestHeader.Authorization, "Authorization: key=AIzaSyAVx_czZItZXcmIQHcw4TauzV9g1mertaQ");
        //-- Delegate Modeling to Validate Server Certificate --//


        //-- Create Stream to Write Byte Array --// 
        Stream dataStream = Request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        //-- Post a Message --//
        WebResponse Response = Request.GetResponse();
        HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
        if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
        {
            var text = "Unauthorized - need new token";

        }
        else if (!ResponseCode.Equals(HttpStatusCode.OK))
        {
            var text = "Response from web service isn't OK";
        }

        StreamReader Reader = new StreamReader(Response.GetResponseStream());
        string responseLine = Reader.ReadLine();
        Reader.Close();
    }*/
    //GCM Push request End
}
