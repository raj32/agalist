using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using ProductListDBModel;


public partial class TheMainListPage : System.Web.UI.Page
{
    ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    UserVariables user = new UserVariables();
    int userID = 0;



    
    protected void Page_Load(object sender, EventArgs e)
    {    
        int lIsAdmin = 0;

        tbxFindProduct.Attributes.Add("onkeydown", "funfordefautenterkey1(" + btnAddToList.ClientID + ",event)");

        
        HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
        try
        {
            if (userID == 0) 
            {
                userID = Convert.ToInt16(Request.Cookies["UserIdNew"].Value);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Default.aspx");
            //throw;
            errorsdiv.Visible = true;
            lblErrorOne.Text += ex.Message;
            lblErrorTwo.Text += ex.Message;            
        }

        if (!IsPostBack)
        {
           // lstSavedBaskets.Items.Clear();
          //  lstSavedBaskets.Items.AddRange(getList(userID));
        }
       

        NewProductDiv.Style.Add(HtmlTextWriterStyle.Top,"-100%");
        errorsdiv.Visible = false;
        lblSaveNewList.Text = "";
        AdminEnterButton.Visible = false;

        try
        {
            lIsAdmin =  (from b in myDBhandler.Clients where b.user_id == userID select b.is_admin).First<int>();
        }
        catch(Exception ex) {
            lIsAdmin = 0;
        };
        if (lIsAdmin == 1) 
        {
            AdminEnterButton.Visible = true;
        }

    }

    protected override void OnPreRender(EventArgs e)               //Return controls to starting condition.
    {
        base.OnPreRender(e);
        if (userID != 0)
        {
            lstSavedBaskets.Items.Clear();
            lstSavedBaskets.Items.AddRange(getList(userID));  
        }
                
    }

    private ListItem[] getList(int userID)
    {
        String[] myListHist = DBUtils.selectSavedList(userID);        
        String[] supportListHist = DBUtils.selectSavedList();        
        ListItem[] returnedList = new ListItem[supportListHist.Length + myListHist.Length];        
        int j = 0;
        for (int i = 0; i < myListHist.Length; i++)
        {
            ListItem item = new ListItem();
            item.Value = myListHist[i];
            item.Attributes.Add("style", "color:#F96C05");
            
             
            //item.Attributes.Add("style", "color:red");
            //item.Attributes.Add("style", "font-weight:bold");                      
            returnedList[j] = item;
            j++;
        }     
        for (int i = 0; i < supportListHist.Length; i++)
        {
            ListItem item = new ListItem();
            
            item.Attributes.Add("style", "Color:#1d6ca3;Border:1px solid #FF9900");
            item.Value = supportListHist[i];
            
            returnedList[j] = item;
            j++;           
        }
        return returnedList;
    }

    
    protected void btnAddNewProduct_Click(object sender, EventArgs e)
    {        
        //drpUnits.Items.Clear();
        //tbxNewProductName.Text = tbxFindProduct.Text;         
        ////UserVariables.IEnumerable<Measure> arrMeasures = from a in MasterPage.ProdListDB.Measures select a;
        ////IEnumerable<Measure> arrMeasures = from a in myDBhandler.Measures where a.is_measure == 1 select a;
        //IEnumerable<String> arrStrMeasures = from b in myDBhandler.Measures where b.is_measure == 1 select b.measure_unit_name;        
        //drpUnits.DataSource = arrStrMeasures;        
        //drpUnits.DataBind();        
        ////this.btnAddToList_Click();  Should add product to database and to the current Shopping List.
        //drpPackages.Items.Clear();        
        //IEnumerable<String> arrStrPackages = from b in myDBhandler.Measures where b.is_package == 1 select b.measure_unit_name;
        //drpPackages.DataSource = arrStrPackages;
        //drpPackages.DataBind();
        //NewProductDiv.Visible = true;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Product myProduct = new Product();
        Shopping_List newShoppingList = new Shopping_List();
        string productName;

        productName = tbxNewProductName.Text.Trim() + " " + tbxNewProdactCompanyName.Text.Trim() + " " + tbxQttyInPackage.Text.Trim() + " " + drpUnits.Text.Trim(); // (drpUnits.Text == "בחר מהרשימה" ? "" : drpUnits.Text);

        productName = productName.Replace(",", "").Trim().Replace("  "," ");

        Boolean isExistSameProductName = (from b in myDBhandler.Products where b.product_name == productName select b.product_name).Contains(productName);

        if (tbxNewProductName.Text.Trim() != " " && tbxNewProductName.Text.Trim() != "" && !(isExistSameProductName))
        {
            myProduct.product_name = productName;    
            myProduct.measure_unit_id = (from b in myDBhandler.Measures where b.measure_unit_name == drpPackages.SelectedItem.Text select b.measure_unit_id).First<int>();
            myDBhandler.Products.AddObject(myProduct);   
            myDBhandler.SaveChanges();

            newShoppingList.user_id = userID;
            newShoppingList.product_id = myProduct.product_id;
            newShoppingList.qtty = 1;
            myDBhandler.Shopping_List.AddObject(newShoppingList);
            tbxFindProduct.Text = "";
            myDBhandler.SaveChanges();
            //NewProductDiv.Visible = false;       
            NewProductDiv.Style.Add(HtmlTextWriterStyle.Top, "-100%");
        }
        drpUnits.Items.Clear();
        tbxNewProductName.Text = "";
        tbxQttyInPackage.Text = "";
        tbxNewProdactCompanyName.Text = "";

        lstSavedBaskets.Items.Clear();
        lstSavedBaskets.Items.AddRange(getList(userID));

      //  ShoppingListGrid.DataBind();

    }

    //Adds product to current Shopping List database, then refreshes the GridView
    protected void btnAddToList_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Boolean isExistSameProductName = (from b in myDBhandler.Products where b.product_name == tbxFindProduct.Text select b.product_name).Contains(tbxFindProduct.Text);
            if (isExistSameProductName)
            {
                try
                {
                    Shopping_List myShoppingList = new Shopping_List();
                    if ((from pr in myDBhandler.Products where pr.product_name == tbxFindProduct.Text select pr.product_name).First<string>() != null || tbxFindProduct.Text != "")
                    {
                        myShoppingList.user_id = userID;
                        myShoppingList.product_id = (from pr in myDBhandler.Products where pr.product_name == tbxFindProduct.Text select pr.product_id).First<int>();
                        myShoppingList.qtty = 1;
                        myDBhandler.Shopping_List.AddObject(myShoppingList);
                        tbxFindProduct.Text = "";
                        myDBhandler.SaveChanges();
                        lstSavedBaskets.Items.Clear();
                        lstSavedBaskets.Items.AddRange(getList(userID));
                        //   ShoppingListGrid.DataBind();
                    }
                    else
                    {
                        lblErrorOne.Text = "מוצר לא קיים, הוסף כמוצר חדש";
                        errorsdiv.Visible = true;
                    }
                }
                catch (Exception hru)
                {
                    lblErrorOne.Text += "(exeption)";
                    lblErrorOne.Text += hru;
                    errorsdiv.Visible = true;
                    //throw;
                }
            }

            else
            {
                ///----------------------------------------------------------------------------------
                ///
                drpUnits.Items.Clear();
                tbxNewProductName.Text = tbxFindProduct.Text;
                IEnumerable<String> arrStrMeasures = from b in myDBhandler.Measures where b.is_measure == 1 select b.measure_unit_name;
                drpUnits.DataSource = arrStrMeasures;

                drpUnits.DataBind();
                drpPackages.Items.Clear();
                IEnumerable<String> arrStrPackages = from b in myDBhandler.Measures where b.is_package == 1 select b.measure_unit_name;
                drpPackages.DataSource = arrStrPackages;
                drpPackages.DataBind();
                NewProductDiv.Style.Add(HtmlTextWriterStyle.Top, "30%"); 
                //NewProductDiv.Visible = true;
            }
            lstSavedBaskets.Items.Clear();
            lstSavedBaskets.Items.AddRange(getList(userID));

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpUnits.Items.Clear();
        tbxNewProductName.Text = "";
        tbxQttyInPackage.Text = "";
        tbxNewProdactCompanyName.Text = "";
        //NewProductDiv.Visible = false;
        NewProductDiv.Style.Add(HtmlTextWriterStyle.Top, "-100%");
        lstSavedBaskets.Items.Clear();
        lstSavedBaskets.Items.AddRange(getList(userID));
    }

    

    protected void btnSaveNewList_Click(object sender, EventArgs e)
    {
        string lclStoredName = tbxSaveNewList.Text;

        if (lclStoredName == "")
        {
            lclStoredName = "רשימה מ- " + DateTime.Now.ToShortDateString();
        }
            //Delete all data for current user in Shopping_List
            List<Shopping_List_Hist> shoppingListHistToRemove;
            shoppingListHistToRemove = (from sl in DBHandler.GetInstance().Shopping_List_Hist where sl.user_id == userID && sl.stored_list_name == lclStoredName select sl).ToList<Shopping_List_Hist>();
            for (int j = 0; j < shoppingListHistToRemove.Count; j++)
            {
                DBHandler.GetInstance().Shopping_List_Hist.DeleteObject(shoppingListHistToRemove[j]);
            }

            lstSavedBaskets.Items.Remove(lclStoredName); 

            List<Shopping_List> newShoppingListForHist =  (from b in myDBhandler.Shopping_List where b.user_id == userID select b).ToList();
                               
            List<Shopping_List_Hist> arrShoppingListHist = new List<Shopping_List_Hist>();

            foreach (var item in newShoppingListForHist)
            {
                Shopping_List_Hist shoppingListHist = new Shopping_List_Hist() 
                { 
                    user_id = userID, 
                    product_id = (int)item.product_id,
                    qtty = (float)item.qtty,
                    stored_list_name = lclStoredName,
                    save_date = DateTime.Now
                };
                arrShoppingListHist.Add(shoppingListHist);             
            }
            
            foreach (var item in arrShoppingListHist)
            {
                myDBhandler.Shopping_List_Hist.AddObject(item);
                myDBhandler.SaveChanges();
            }
            lblSaveNewList.Text = "רשימה נשמרה בהצלחה";           
            lstSavedBaskets.Items.Clear();
            lstSavedBaskets.Items.AddRange(getList(userID));
        
    }

  

    protected void btnOK_Click(object sender, EventArgs e)
    {
        lblErrorOne.Text = "";
        errorsdiv.Visible = false;
        
    }

    protected void btnLoadSavedBasket_Click(object sender, EventArgs e)
    {
        //Delete all data for current user in Shopping_List
        List<Shopping_List> shoppingListToRemove;
        shoppingListToRemove = (from sl in DBHandler.GetInstance().Shopping_List where sl.user_id == userID select sl).ToList<Shopping_List>();
        for (int j = 0; j < shoppingListToRemove.Count; j++)
			{
                DBHandler.GetInstance().Shopping_List.DeleteObject(shoppingListToRemove[j]);
			}

        //Copy to Shopping_List data from Shopping_List_Hist with chosen Name
        List<Shopping_List_Hist> shoppingListToLoad;
        shoppingListToLoad = (from ll in DBHandler.GetInstance().Shopping_List_Hist where ll.user_id == userID && ll.stored_list_name == lstSavedBaskets.SelectedItem.Value select ll).ToList<Shopping_List_Hist>();

        if (shoppingListToLoad.Count == 0)
        {
            shoppingListToLoad = (from ll in DBHandler.GetInstance().Shopping_List_Hist where ll.user_id == DBUtils.userId && ll.stored_list_name == lstSavedBaskets.SelectedItem.Value select ll).ToList<Shopping_List_Hist>();
        }

        for (int i = 0; i < shoppingListToLoad.Count; i++)
        {
            Shopping_List myShopList = new Shopping_List()
            {
                user_id=userID,
                product_id=shoppingListToLoad[i].product_id,
                qtty = shoppingListToLoad[i].qtty,
                order_no = i
            };
            DBHandler.GetInstance().Shopping_List.AddObject(myShopList);
        }
        DBHandler.GetInstance().SaveChanges();
        lblBasketName.Text = lstSavedBaskets.SelectedValue;


        tbxSaveNewList.Text = lstSavedBaskets.SelectedItem.Value;
       // ShoppingListGrid.DataBind();
        lstSavedBaskets.Items.Clear();
        lstSavedBaskets.Items.AddRange(getList(userID));

        
    }

    protected void btnDeleteSavedBasket_Click(object sender, EventArgs e)
    {
        //Find all rows with current Name, then delete them from Shopping_List_Hist
   
        List<Shopping_List_Hist> arrShoppingListHist;// = new IEnumerable<Shopping_List_Hist>();
        arrShoppingListHist = (from l in DBHandler.GetInstance().Shopping_List_Hist where l.user_id == userID && l.stored_list_name == lstSavedBaskets.SelectedItem.Value select l).ToList<Shopping_List_Hist>();
        for (int i = 0; i < arrShoppingListHist.Count; i++)
        {
            DBHandler.GetInstance().Shopping_List_Hist.DeleteObject(arrShoppingListHist[i]);
        }        
        DBHandler.GetInstance().SaveChanges();        
        lstSavedBaskets.Items.Clear();
        lstSavedBaskets.Items.AddRange(getList(userID));
    }


    protected void btnDelList_Click(object sender, EventArgs e)
    {
        List<Shopping_List> arrShoppingList;// = new IEnumerable<Shopping_List_Hist>();
        arrShoppingList = (from l in DBHandler.GetInstance().Shopping_List where l.user_id == userID select l).ToList<Shopping_List>();
        for (int i = 0; i < arrShoppingList.Count; i++)
        {
            DBHandler.GetInstance().Shopping_List.DeleteObject(arrShoppingList[i]);
        }
        DBHandler.GetInstance().SaveChanges();
        
    }
    protected void EnterAdminPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPage.aspx");
    }
}