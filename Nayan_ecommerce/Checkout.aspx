<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Nayan_ecommerce.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="Styles/Checkout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <iframe id="CustomerFrame" class="CheckoutFrame" src="Customers.aspx" runat="server"
            style="left:10px; top:80px">
        </iframe>
        <iframe id="DetailFrame" class="CheckoutFrame" src="Details.aspx" runat="server"
            style="left:400px; top:80px">
        </iframe>
        </div>
    </form>
</body>
</html>
