using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Nayan_ecommerce
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=Store";

            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            try
            {
                // create a new data set object called ds
                ds = new DataSet();
                // create a connection to the database called connectFill
                connectFill = new SqlConnection(dbConnect);

                // create SQL string to select all products
                string sqlString = "SELECT * FROM Products";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                // create a new SQL data adapter to retrieve the data and
                // fill the data set
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                return;
            }

            int numProducts = 0;

            // if we have some products in the Products table...
            if (ds.Tables["Products"].Rows.Count > 0)
            {
                // save the number of products in the Products table
                numProducts = ds.Tables["Products"].Rows.Count;

                // reset the arrays in the main page based on the number of products
                Default.modelNum = new string[numProducts];
                Default.pics = new string[numProducts];
                Default.descrip = new string[numProducts];
                Default.qty = new string[numProducts];
                Default.price = new string[numProducts];

                // get all the products data, just as we did with StreamReader version
                for (int i = 0; i < numProducts; i++)
                {
                    Default.modelNum[i] = ((int)ds.Tables["Products"].Rows[i]["ProdID"]).ToString();
                    Default.descrip[i] = ds.Tables["Products"].Rows[i]["Description"].ToString();
                    Default.pics[i] = ds.Tables["Products"].Rows[i]["Picture"].ToString();
                    Default.qty[i] = ((int)ds.Tables["Products"].Rows[i]["QtyOnHand"]).ToString();
                    Default.price[i] = ((decimal)ds.Tables["Products"].Rows[i]["Price"]).ToString();
                }
            }

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

            for (int i = 0; i < numProducts; i++)
            {
                // add new empty row object
                TableRow row = new TableRow();
                for (int j = 0; j < 6; j++)
                {
                    // add new empty cell object
                    TableCell cell = new TableCell();

                    if (j == 0)
                    {
                        Image pic = new Image();
                        pic.ImageUrl = "pictures/" + Default.pics[i];
                        pic.Height = 100;
                        pic.Width = 120;
                        cell.Controls.Add(pic);
                    }
                    else if (j == 1)
                    {
                        cell.Text = Default.modelNum[i];
                    }
                    else if (j == 2)
                    {
                        cell.Text = Default.descrip[i];
                    }
                    else if (j == 3)
                    {
                        cell.Text = Default.qty[i];
                    }
                    else if (j == 4)
                    {
                        cell.Text = Default.price[i];
                    }
                    else
                    {
                        Button btnAddToCart = new Button();
                        //btnAddToCart.ID = "Row_" + i;
                        btnAddToCart.ID = i.ToString();

                        btnAddToCart.Click += new EventHandler(Button1_Click);
                        btnAddToCart.Text = "Add To Cart";
                        cell.Controls.Add(btnAddToCart);
                    }
                    // now add all the cells for the current row
                    row.Cells.Add(cell);
                }
                // finally, add the current row to the table
                Table1.Rows.Add(row);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // create a button object from the sender
            // and cast the sender object to a button
            Button b = (Button)sender;
            int row = int.Parse(b.ID);

            if (Default.numItems > 0)
            {
                bool matchRow = false;
                for (int i = 0; i < Default.numItems; i++)
                {
                    if (row == Default.cartInfo[i])
                    {
                        matchRow = true;
                        break;
                    }
                }

                if (!matchRow)
                {
                    Default.cartInfo[Default.numItems] = row;
                    Default.numItems++;
                }
            }
            else
            {
                Default.cartInfo[Default.numItems] = row;
                Default.numItems++;
            }
        }

        // **************************************************************
        // method releases all database resources that have been assigned
        private static void DisposeResources(ref SqlDataAdapter sqlDataAdapter,
            ref DataSet ds,
            ref SqlConnection connectFill,
            ref SqlConnection connectCmd,
            ref SqlCommand cmd,
            ref SqlCommand scmd)
        {
            if (sqlDataAdapter != null)
                sqlDataAdapter.Dispose();
            if (ds != null)
                ds.Dispose();
            if (connectFill != null)
                connectFill.Dispose();
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
            if (scmd != null)
                scmd.Dispose();
        }
    }
}