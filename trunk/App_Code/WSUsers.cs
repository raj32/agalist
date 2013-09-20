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
public class WSUsers : System.Web.Services.WebService {
    
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    int userID = 0;
    
    public WSUsers()
    {
    }

    [WebMethod]
    public int VerifyUser(string username, string password)
    {
        return DBUtils.getUserId(username, password);
    }

    public int RegisterUser(String username, String password,int client_type)
    {
        int result = 0;
        try
        {
            result = DBUtils.isExistsUser(username);

            if (result == 0)
            {
                myDBhandler.registeruser(username, password, client_type);
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
