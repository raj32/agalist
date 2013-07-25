using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProductListDBModel
{
    /// <summary>
    /// Summary description for GlobalVariables
    /// </summary>
    /// 
  public class UserVariables
    {
        private int _currentUserID;
        private string _currentUserName;

        public int CurrentUserID
        {
            get { return _currentUserID; }
            set { _currentUserID = value; }
        }

        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { _currentUserName = value; }
        }

        public UserVariables()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }

  public class CurrentUser //singleton
  {
      static CurrentUser _cu;

      public static CurrentUser GetInstance(int userIDo, string userNameo)
      {
          int userID;
          string userName;

          if (_cu == null)
          {
              userID = userIDo;
              userName = userNameo;
              _cu = new CurrentUser();              
          }
          return _cu;
      }
  }

}