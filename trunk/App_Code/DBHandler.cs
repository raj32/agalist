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
            //String[] lclAllTips =  (from b in DBHandler.GetInstanceProp.Tips where b.is_active == 1 select b.tip_content).ToArray<String>();
            String returnValue = "";

            //for (int i = 0; i < lclAllTips.Length; i++)
            //{
            //    returnValue += lclAllTips[i] + "<br><br><br>";
                
            //}
            //return returnValue;
            returnValue = "על מנת לא להתפתות לקנות מוצרים שאין בהם צורך, מומלץ להגיע לסופר עם רשימה מוכנה מראש" + "<br><br><br>" + "במדפים התחתונים של הסופר תמצאו את אותם המוצרים במחיר נמוך יותר וזאת מכיוון שהסופר ממקם את המוצרים הרווחיים ביותר בגובה העיניים" + "<br><br><br>" + " מומלץ לא להגיע לחנות רעבים. כשאנחנו רעבים אנחנו קונים יותר" + "<br><br><br>" + " ילדים נוטים לשים בעגלה מוצרים שלא התכוונו לקנות. שתפו את הילדים בתהליך והציעו להם לעזור לכם למצוא מוצרים מהרשימה" + "<br><br><br>" + "הכינו רשימת קניות לשבוע שלם. הדבר יחסוך ביקורים מיותרים בסופר, קניית עודפי מוצרים והכי חשוב זמן יקר" + "<br><br><br>";
            return returnValue;
        }

    }

}
