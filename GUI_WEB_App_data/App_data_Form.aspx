<%@ Page Language="C#" AutoEventWireup="true" CodeFile="App_data_Form.aspx.cs" Inherits="App_data_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Item list:"></asp:Label>
        <asp:Table ID="Table1" runat="server" BackColor="#FFFFCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load" />
    
        <br />
    
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Prekes.xml"></asp:XmlDataSource>
     
    
    </div>
    </form>
</body>
</html>
