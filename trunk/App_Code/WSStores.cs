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
public class WSStores : System.Web.Services.WebService {
    
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    int userID = 0;

    public WSStores()
    {
    }

    [WebMethod]
    public int InsertStore(int userId,String store_name, float coordinate_x,float coordinate_y,String address)
    {

        int result = 0;
        try
        {
            myDBhandler.InsertStore(userId, store_name, coordinate_x, coordinate_y,address);
        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
    public int UpdateStore(int userId, int storeId, String store_name, float coordinate_x, float coordinate_y, int active, String address)
    {
        int result = 0;
        
        try
        {
            myDBhandler.UpdateStore(storeId,userId, store_name, coordinate_x, coordinate_y,active,address);
        }
        catch (Exception e) { result = -2; }

        return result;
    }
    [WebMethod]
    public XmlDocument StoreList(int userId)
    {
        String result;
        List<string> str = new List<string>();
        try
        {
            str = myDBhandler.StoreList(userId).ToList<String>();
        }
        catch (Exception e)
        {            
        }

        result = "<Stores>";

        foreach (string itm in (str.ToArray()))
        {
            result = result + itm;
        }

        result = result + "</Stores>";

        XmlDocument xm = new XmlDocument();
        xm.LoadXml(string.Format("<root>{0}</root>", result));

//        XDocument r = new XDocument("Stores",str.Select(x=>XElement.Parse(x)));

//        XmlDocument result = new XmlDocument();
//        result.Load(r.CreateReader());

        return xm;
    }

    [WebMethod]
    public int DeleteStore(int userId, int storeId)
    {
        int result = 0;

        try
        {
            myDBhandler.DeleteStore(userId, storeId);
        }
        catch (Exception e) { result = -2; }

        return result;
    }

    [WebMethod]
    public XmlDocument GetStore(int userId, int storeId)
    {
        String result;
        List<string> str = new List<string>();
        try
        {
            str = myDBhandler.getStore(userId, storeId).ToList<String>();
        }
        catch (Exception e)
        {
        }

        result = "<Stores>";

        foreach (string itm in (str.ToArray()))
        {
            result = result + itm;
        }

        result = result + "</Stores>";

        XmlDocument xm = new XmlDocument();
        xm.LoadXml(string.Format("<root>{0}</root>", result));

        //        XDocument r = new XDocument("Stores",str.Select(x=>XElement.Parse(x)));

        //        XmlDocument result = new XmlDocument();
        //        result.Load(r.CreateReader());

        return xm;
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
