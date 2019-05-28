<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Nayan_ecommerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Panel ID="Panel1" runat="server">
               <!--created buttons to handle the main page-->
                <asp:Button ID="Promopage" runat="server"  Text="Promotion Page" CssClass="button" OnClick="Promopage_Click"  />
                 <asp:Button ID="Weather" runat="server" Text="Weather" CssClass="button" OnClick="Weather_Click"  />
                 <asp:Button ID="Customers" runat="server" Text="Customer" CssClass="button" OnClick="Customers_Click" />
                <asp:Button ID="Products" runat="server" Text="Products" CssClass="button" OnClick="Products_Click" />
                <asp:Button ID="Catalog" runat="server" Text="Catalog" CssClass="button" OnClick="Catalog_Click"  />
                <asp:Button ID="Cart" runat="server" Text="Cart" CssClass="button" OnClick="Cart_Click" />
                
              
            <br/><br/>
                 <!--created iframe to display the pages-->
                <iframe id="Frame" name="Frame" runat="server" style="position:absolute;top:87px; left:-2px; height:667px; width:1244px; border:1px solid black; right: 131px; background-color:#BFC9DC;"></iframe>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
