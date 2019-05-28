<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Nayan_ecommerce.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalog</title>
    <link href="Styles/Catalog.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" CssClass="CellStyle" Height="123px" Width="567px" BackColor="#FFCCCC" runat="server" BorderStyle="Solid"></asp:Table>
        <asp:Button ID="Button1" runat="server" style="visibility:hidden" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
