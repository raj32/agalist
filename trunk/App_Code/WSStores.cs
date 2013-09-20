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
/// <summary>
/// Summary description for WSProductList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSStores : System.Web.Services.WebService {
    
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    int userID = 0;

    public WSStores()
    {
    }

    [WebMethod]
    public int InsertStore(int userId,String store_name, float coordinate_x,float coordinate_y)
    {

        int result = 0;
        try
        {
            myDBhandler.InsertStore(userId, store_name, coordinate_x, coordinate_y);
        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
    public int UpdateStore(int userId, int store_id,String store_name, float coordinate_x, float coordinate_y)
    {
        int result = 0;
        
        try
        {
            //myDBhandler.InsertStore(userId, store_name, coordinate_x, coordinate_y);
        }
        catch (Exception e) { result = -2; }

        return result;
    }
    [WebMethod]
    public XmlDocument StoreList(int userId)
    {
        XmlDocument result = new XmlDocument();
//        List<string> str = new List<string>();
        String str = " ";
        try
        {
            str = myDBhandler.StoreList(userId).First();
        }
        catch (Exception e)
        {            
        }
        result.LoadXml(str);
        return result;
    }



/*    public XmlDocument GetEntityXml<String>()
{

    XmlDocument xmlDoc = new XmlDocument();
    
    XPathNavigator nav = xmlDoc.CreateNavigator();
    using (XmlWriter writer = nav.AppendChild())
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<String>), new XmlRootAttribute("Store"));
        ser.Serialize(writer, parameters);
    }
    return xmlDoc;
    }*/
}
