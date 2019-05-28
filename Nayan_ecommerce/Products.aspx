<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Nayan_ecommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Products.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top: 353px">
            <asp:Panel ID="Panel" CssClass="Panels" style="left:4px; top: 27px; height:255px; right:119px" runat="server">
                <asp:Label ID="lblProductNumber" CssClass="Labels" style="left:10px; top:20px" runat="server" Text="Products #"></asp:Label>
                <asp:TextBox ID="ProdID" CssClass="TextBoxes" style="top:20px; left:157px; width:111px; color:red" runat="server"></asp:TextBox>

                <asp:ListBox ID="Picture1" style="position:absolute; top:16px; left:734px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Picture1_SelectedIndexChanged">
                   
                </asp:ListBox>
                <asp:Image ID="Image1" runat="server" style="position:absolute; top:6px; left:414px; height: 201px; width: 303px;" /><br />

              

                <asp:Label ID="lblManufacturer" CssClass="Labels" style="left:10px; top:50px" runat="server" Text="Manufacturer Code"></asp:Label>
                <asp:TextBox ID="ManufacCode" CssClass="TextBoxes" style="top:49px; left:157px; width:200px" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblDescription" CssClass="Labels" style="left:10px; top:80px" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="Description" CssClass="TextBoxes" style="top:79px; left:157px; width:200px" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPicture" CssClass="Labels" style="left:10px; top:110px" runat="server" Text="Picture"></asp:Label>
                <asp:TextBox ID="Picture" CssClass="TextBoxes" style="top:113px; left:157px; width:200px" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblQuantity" CssClass="Labels" style="left:10px; top:140px" runat="server" Text="Quantity"></asp:Label>
                <asp:TextBox ID="QtyOnHand" CssClass="TextBoxes" style="top:141px; left:157px; width:120px" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPrice" CssClass="Labels" style="left:10px; top:170px" runat="server" Text="Price"></asp:Label>
                <asp:TextBox ID="Price" CssClass="TextBoxes" style="top:170px; left:157px; width:100px" runat="server"></asp:TextBox><br />

                <!--Buttons to perform varios tasks-->
                <asp:Button ID="btnNewProducts" CssClass="Buttons" style="left:10px; bottom:10px" runat="server" Text="New" ToolTip="Create new Products" OnClick="btnNewProducts_Click" />
                <asp:Button ID="btnAddProducts" runat="server" CssClass="Buttons" OnClick="btnAddProducts_Click" style="left:56px; bottom:10px; width: 53px;" Text="Add" ToolTip="Add new Products" />
                <asp:Button ID="btnUpdateProducts" runat="server" CssClass="Buttons" OnClick="btnUpdateProducts_Click" style="left:118px; bottom:10px; width: 80px;" Text="Update" ToolTip="Update Products" />
                <asp:Button ID="btnDeleteProducts" runat="server" CssClass="Buttons" OnClick="btnDeleteProducts_Click" style="left:199px; bottom:10px; width: 73px;" Text="Delete" ToolTip="Delete Products" />
                <asp:Button ID="btnFindProducts" runat="server" CssClass="Buttons" OnClick="btnFindProducts_Click" style="left:277px; bottom:10px; width: 55px; margin-top: 0px;" Text="Find" ToolTip="Find Products" />
                
            </asp:Panel>
            <asp:Label ID="lblMessages" runat="server" CssClass="Messages" style="left:10px; top:300px; right:10px; height:16px; background-color:cyan" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
