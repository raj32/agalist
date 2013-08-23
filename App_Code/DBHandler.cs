using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductListDBModel;

/// <summary>
/// Summary description for DBHandler
/// </summary>
/// 

namespace ProductListDBModel
{
    public class DBHandler
    {

        static ProdListDBEntities _db;

        /// <summary>
        /// Property that returns singleton of database entity framework instace.
        /// </summary>       
        public static ProdListDBEntities GetInstanceProp
        {
            get
            {
                return GetInstance();
            }
        }

        /// <summary>
        /// Method that returns singleton of database entity framework instace.
        /// </summary>
        public static ProdListDBEntities GetInstance()
        {
            if (_db == null)
            {
                _db = new ProdListDBEntities();
            }

            return _db;
        }
    }
    
    public static class DBUtils
    {
        public static int userId
        {
            get
            {
                return selectSupportUserId();
            }
        }
        static int selectSupportUserId()
        {
            return (from b in DBHandler.GetInstance().Clients where b.email == "support@agalist.com" select b.user_id).First<int>();
        }

        
        //-----------------------------------------------------------------//


        /// <summary>
        /// Selecting distinct names of saved lists of given user
        /// </summary>
        /// <param name="pUserId"></param>
        /// <returns>Array of strings with current user saved baskets.</returns>
        public static String[] selectSavedList(int pUserId)
        {

            return (from b in  DBHandler.GetInstance().Shopping_List_Hist where b.user_id == pUserId select b.stored_list_name).Distinct<String>().ToArray<String>();
        }

        /// <summary>
        ///  Selecting distinct names of saved lists of the support
        /// </summary>
        /// <returns>Array of strings with support saved baskets.</returns>
        public static String[] selectSavedList() 
        {
            return (from b in DBHandler.GetInstance().Shopping_List_Hist where b.user_id == userId select b.stored_list_name).Distinct<String>().ToArray<String>();
        }

        /// <summary>
        ///  Selecting distinct names of saved lists of the support
        /// </summary>
        /// <returns>Array of strings with support saved baskets.</returns>
        public static Boolean deleteProduct(int userId, int productId)
        {
            try
            {
                Shopping_List myObject = (from b in DBHandler.GetInstanceProp.Shopping_List where b.user_id == userId && b.product_id == productId select b).First<Shopping_List>();
                DBHandler.GetInstanceProp.DeleteObject(myObject);
                DBHandler.GetInstanceProp.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///  Selecting distinct names of saved lists of the support
        /// </summary>
        /// <returns>Array of strings with support saved baskets.</returns>
        public static int getUserId(string username, string password)
        {
            try
            {
                int myClient = (from db in DBHandler.GetInstanceProp.Clients where db.email == username && db.password == password select db.user_id).First<int>();              
                return myClient;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //------------------------------------------------------------------//

        public static int isExistsUser(string username)
        {
            try
            {
                int myClient = (from db in DBHandler.GetInstanceProp.Clients where db.email == username select db.user_id).First<int>();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //-----------------------------------------------------------------//

        public static String getAllTips
        {
            get
            {
                return allTips();
            }
            
        }

        static String allTips()
        {
            
            List<Tip> lclAllTips = (from b in DBHandler.GetInstanceProp.Tips where b.is_active == 1 select b).ToList<Tip>();
            String returnValue = "";

            foreach (var item in lclAllTips)
            {

                returnValue += item.tip_content + "<br><br><br>";
            }

            return returnValue;
        }

        public static String getAllTipsForScr
        {
            get
            {
                return allTipsForScr();
            }

        }

        static String allTipsForScr()
        {

            List<Tip> lclAllTips = (from b in DBHandler.GetInstanceProp.Tips where b.is_active == 1 select b).ToList<Tip>();
            String returnValue = "";

            int i = 0;

            foreach (var item in lclAllTips)
            {
                i++;

                if (i==2)
                {
                    returnValue += "<div class=\" nameTip\">" + "הטיפ של " + "Agalist" + "<br> </div>" +
                                "<div class=\" contentTip\">" + "מומלץ לקרוא על חסכון בכל תחומי החיים. באתר זה תקראו איך " +
                                "<a href=\"http://www.save4u.co.il\"> פשוט לשלם פחות </a>  " + "</div> <br><br>";
                }
                returnValue += "<div class=\" nameTip\">" + "הטיפ של " + (item.Client.email == "support@agalist.com" ? "Agalist" : item.Client.email.Split('@')[0]) + "<br> </div>" +
                                "<div class=\" contentTip\">" + item.tip_content + "</div> <br><br>";
            }

            return returnValue;
        }


        internal static void setUserRegId(int userId, string androidRegId)
        {
            try
            {
                string currentRegId = (from b in DBHandler.GetInstanceProp.Clients where b.user_id == userId select b.comments).First<string>();

                if (currentRegId != androidRegId)
                {
                    Client myObject = (from b in DBHandler.GetInstanceProp.Clients where b.user_id == userId select b).First<Client>();
                    myObject.comments = androidRegId;
                    DBHandler.GetInstanceProp.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        internal static string getUserRegId(int userId)
        {
            string currentRegId = null;
            try
            {
                currentRegId = (from b in DBHandler.GetInstanceProp.Clients where b.user_id == userId select b.comments).First<string>();
                if (currentRegId != null && currentRegId.Length>100)
                {
                    return currentRegId;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return currentRegId;
        }
    }

}
