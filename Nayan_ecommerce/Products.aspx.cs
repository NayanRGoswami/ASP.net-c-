using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Nayan_ecommerce
{
    public partial class Products : System.Web.UI.Page
    {
        string webSiteData = HttpContext.Current.Server.MapPath(".") + @"\data\Products\";
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=Store";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


               
                DirectoryInfo imagename = new DirectoryInfo(Server.MapPath("~/pictures/"));
            
                Picture1.DataSource = imagename.GetFiles("*.*");
                Picture1.DataBind();
            }
        }

        protected void btnNewProducts_Click(object sender, EventArgs e)
        {
            flushData();
        }

        protected void btnAddProducts_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            // create our SQL string with VALUE parameters
            string sqlString = "INSERT INTO Products (ManufacCode, Description, Picture, QtyOnHand, Price) VALUES (@ManufacCode, @Description, @Picture, @QtyOnHand, @Price)";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ManufacCode", ManufacCode.Text);
                cmd.Parameters.AddWithValue("@Description", Description.Text);
                cmd.Parameters.AddWithValue("@Picture", Picture.Text);
                cmd.Parameters.AddWithValue("@QtyOnHand", QtyOnHand.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
              
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                return;
            }

            // get the primary key identity just inserted
            string identRequest = "SELECT IDENT_CURRENT('Products') FROM Products";
            cmd = new SqlCommand(identRequest, connectCmd);
            int identValue = Convert.ToInt32(cmd.ExecuteScalar());
            ProdID.Text = identValue.ToString();
            lblMessages.Text = "New Product Added";

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

        }

        protected void btnUpdateProducts_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            // now make a change to the customer last name
            string sqlString = "UPDATE Products SET ManufacCode=@ManufacCode, Description=@Description, Picture=@Picture, QtyOnHand=@QtyOnHand, Price=@Price WHERE ProdID=@ProdID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ManufacCode", ManufacCode.Text);
                cmd.Parameters.AddWithValue("@Description", Description.Text);
                cmd.Parameters.AddWithValue("@Picture", Picture.Text);
                cmd.Parameters.AddWithValue("@QtyOnHand", QtyOnHand.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@ProdID", ProdID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                return;
            }
            lblMessages.Text = "Product Updated";

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);


        }

        protected void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            // define SQL string to delete customer by customer ID
            string sqlString = "DELETE FROM Products WHERE ProdID = @ProdID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ProdID", ProdID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                return;
            }
            lblMessages.Text = "Product Deleted";

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

            flushData();
        }

        protected void btnFindProducts_Click(object sender, EventArgs e)
        {
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

                // create SQL string to select customer record
                string sqlString = "SELECT * FROM Products WHERE ProdID = @ProdID";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                // add the parameter to SQL string and validate
                scmd.Parameters.AddWithValue("@ProdID", ProdID.Text);

                // create a new SQL data adapter to retrieve the data and
                // fill the data set
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                return;
            }
           

            lblMessages.Text = "";

            // copy over the data fields from the dataset into text boxes
            if (ds.Tables["Products"].Rows.Count == 1)
            {
                ManufacCode.Text = ds.Tables["Products"].Rows[0]["ManufacCode"].ToString();
                Description.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                Picture.Text = ds.Tables["Products"].Rows[0]["Picture"].ToString();
                QtyOnHand.Text = ds.Tables["Products"].Rows[0]["QtyOnHand"].ToString();
                Price.Text = ds.Tables["Products"].Rows[0]["Price"].ToString();
                
            }
            else
            {
                lblMessages.Text = "Product not found";
            }

           

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        private void flushData()
        {

            ProdID.Text = "";
            ManufacCode.Text = "";
            Description.Text = "";
            Picture.Text = "";
            QtyOnHand.Text = "";
            Price.Text = "";

        }

        protected void Picture1_SelectedIndexChanged(object sender, EventArgs e)
        {


            Image1.ImageUrl = "pictures/" + Picture1.SelectedValue;


            Picture.Text = Picture1.SelectedValue;
        }

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
            
