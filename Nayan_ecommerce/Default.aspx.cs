using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nayan_ecommerce
{
    public partial class Default : System.Web.UI.Page
    {

        const int MAXPRODUCTS = 10;

        public static string[] modelNum;
        public static string[] pics;
        public static string[] descrip;
        public static string[] qty;
        public static string[] price;

        public static string[] qtySold = new string[MAXPRODUCTS];
        public static int[] cartInfo = new int[MAXPRODUCTS];
        public static int numItems = 0;
        public static int cusID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < MAXPRODUCTS; i++)
                    qtySold[i] = "1";
            }
        }

        protected void Promopage_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "PromoPage.aspx");
        }

        protected void Customers_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "Customers.aspx");
        }

        protected void Products_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "Products.aspx");
        }

        protected void Catalog_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "Catalog.aspx");
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "Cart.aspx");

        }

        protected void Weather_Click(object sender, EventArgs e)
        {
            Frame.Attributes.Add("Src", "https://www.theweathernetwork.com/ca/weather/ontario/london");
        }

       
    }
}