<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SesijaWEB.aspx.cs" Inherits="SesijaWEB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="New entry:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Existing entries:"></asp:Label>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" Height="100px" Width="300px">
        </asp:Table>
    </div>
    </form>
</body>
</html>
