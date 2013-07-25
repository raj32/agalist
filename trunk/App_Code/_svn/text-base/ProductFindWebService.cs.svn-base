using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using ProductListDBModel;


/// <summary>
/// Summary description for ProductFindWebService
/// </summary>
[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ProductFindWebService : System.Web.Services.WebService {
   
    private static ProdListDBEntities prodListDB2 = DBHandler.GetInstanceProp;

    public ProductFindWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetCompletionList(string prefixText, int count) 
    {
        IEnumerable<Product> arrProduct = from a in prodListDB2.Products select a;
        IEnumerable<String> arrStrProducts = from b in arrProduct where b.product_name.Contains(prefixText) select b.product_name;
        string[] arrReturn = arrStrProducts.ToArray<String>();
        return arrReturn;
    }
    
}
