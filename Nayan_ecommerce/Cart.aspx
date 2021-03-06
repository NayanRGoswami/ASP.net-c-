﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Nayan_ecommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link href="Styles/Cart.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" CssClass="CellStyle" Height="123px" Width="700px" BackColor="#CDECFE" BorderStyle="Dashed"></asp:Table>
        <asp:Button ID="BtnRemove" runat="server" Text="Button" style="visibility:hidden" OnClick="RemoveFromCart" />
        <br />
        <asp:Label ID="LblTotal" runat="server" CssClass="LabelTotal" Text="0.00"></asp:Label>
        <asp:Button ID="btnRecalculate" runat="server" Text="Total" OnClick="RecalculateTotal" />
        <asp:Button ID="btnCheckOut" runat="server" Text="Checkout" OnClick="LoadCheckoutPage" />
    </div>
    </form>
</body>
</html>
