<%@ page language="C#" autoeventwireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRECALCUL</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <a href="Default.aspx">MENU</a>
        <br />
       <br />
            <asp:Button ID="Button5" runat="server" Text="BIO" OnClick="Button5_Click" />
            <asp:Button ID="Button3" runat="server" Text="BLAYE" OnClick="Button3_Click" />
            <asp:Button ID="Button2" runat="server" Text="BOURG" OnClick="Button2_Click" />
            <asp:Button ID="Button4" runat="server" Text="PRIX SPECIAL" OnClick="Button4_Click" />
       <hr />
            <asp:Button ID="Button1" runat="server" Text="TOUS" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
