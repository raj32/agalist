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
            
        

        NewProductDiv.Visible = false;
        errorsdiv.Visible = false;
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

        productName = tbxNewProductName.Text + " " + tbxNewProdactCompanyName.Text + " " + drpPackages.Text + " " + tbxQttyInPackage.Text + " " + drpUnits.Text; // (drpUnits.Text == "בחר מהרשימה" ? "" : drpUnits.Text);

        Boolean isExistSameProductName = (from b in myDBhandler.Products where b.product_name == productName select b.product_name).Contains(productName);

        //showTopEntries = showTopEntries >= totalEntries ? totalEntries : showTopEntries;
        if (tbxNewProductName.Text != "" && !(isExistSameProductName))
        {
            myProduct.product_name = productName;
            //myProduct.measure_unit_id = drpPackages.SelectedIndex;
            myProduct.measure_unit_id = (from b in myDBhandler.Measures where b.measure_unit_name == drpPackages.SelectedItem.Text select b.measure_unit_id).First<int>();
            myDBhandler.Products.AddObject(myProduct);   
            myDBhandler.SaveChanges();

            newShoppingList.user_id = userID;
            newShoppingList.product_id = myProduct.product_id;
            newShoppingList.qtty = 1;
            myDBhandler.Shopping_List.AddObject(newShoppingList);
            tbxFindProduct.Text = "";
            myDBhandler.SaveChanges();
            NewProductDiv.Visible = false;       
        }
        drpUnits.Items.Clear();
        tbxNewProductName.Text = "";
        tbxQttyInPackage.Text = "";
        tbxNewProdactCompanyName.Text = "";

        ShoppingListGrid.DataBind();

    }

    //Adds product to current Shopping List database, then refreshes the GridView
    protected void btnAddToList_Click(object sender, EventArgs e)
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
                    ShoppingListGrid.DataBind();
                }
                else
                {
                    lblErrorOne.Text = "מוצר לא קיים, הוסף כמוצר חדש";
                    errorsdiv.Visible = true;
                }

                //tbxFindProduct.Text = "";
                //This IF handles situation while one wants to add to Shopping_List product that not yet exists in Products table.
                // *! It has a bug when adding a new product.
                //string strTemp = (from pr in myDBhandler.Products where pr.product_name == tbxFindProduct.Text select pr.product_name).First<string>();

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

            //UserVariables.IEnumerable<Measure> arrMeasures = from a in MasterPage.ProdListDB.Measures select a;
            //IEnumerable<Measure> arrMeasures = from a in myDBhandler.Measures where a.is_measure == 1 select a;
            IEnumerable<String> arrStrMeasures = from b in myDBhandler.Measures where b.is_measure == 1 select b.measure_unit_name;

            drpUnits.DataSource = arrStrMeasures;
            drpUnits.DataBind();
            //this.btnAddToList_Click();  Should add product to database and to the current Shopping List.

            drpPackages.Items.Clear();

            IEnumerable<String> arrStrPackages = from b in myDBhandler.Measures where b.is_package == 1 select b.measure_unit_name;

            drpPackages.DataSource = arrStrPackages;

            drpPackages.DataBind();

            NewProductDiv.Visible = true;
        }
    }


    protected void btnSaveNewList_Click(object sender, EventArgs e)
    {
        if (tbxSaveNewList.Text != "")
        {
            //myDBhandler

            List<Shopping_List> newShoppingListForHist =  (from b in myDBhandler.Shopping_List where b.user_id == userID select b).ToList();
            
            //IEnumerable<Shopping_List_Hist> 
            
            List<Shopping_List_Hist> arrShoppingListHist = new List<Shopping_List_Hist>();

            foreach (var item in newShoppingListForHist)
            {
                Shopping_List_Hist shoppingListHist = new Shopping_List_Hist() 
                { 
                    user_id = userID, 
                    product_id = (int)item.product_id,
                    qtty = (float)item.qtty,
                    stored_list_name = tbxSaveNewList.Text,
                    save_date = DateTime.Now
                };

                arrShoppingListHist.Add(shoppingListHist);             

            }

            
            foreach (var item in arrShoppingListHist)
            {
                //myDBhandler.Shopping_List_Hist.AddObject(item);
                myDBhandler.Shopping_List_Hist.AddObject(item);
                myDBhandler.SaveChanges();
            }
            //myDBhandler.Shopping_List_Hist.Parameters.Add(arrShoppingListHist);              
            

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpUnits.Items.Clear();
        tbxNewProductName.Text = "";
        tbxQttyInPackage.Text = "";
        tbxNewProdactCompanyName.Text = "";
        NewProductDiv.Visible = false;       
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        lblErrorOne.Text = "";
        errorsdiv.Visible = false;
        
    }
}