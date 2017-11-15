<%@ page language="C#" autoeventwireup="true" CodeFile="Default9.aspx.cs" Inherits="Default9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EXPORT</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default.aspx">MENU</a>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="NUMERO" runat="server" Checked="true" />NUMERO</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="MEDAILLE_NUM" runat="server" Checked="true" />MEDAILLE (1, 2, 3)</td>
                </tr>
               <tr>
                    <td>
                        <asp:CheckBox ID="NOTE" runat="server" Checked="true" />NOTE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="MEDAILLE_TXT" runat="server" />MEDAILLE (OR, AREGNT, BRONZE)</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="TYPE" runat="server" />TYPE</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NOM" runat="server" />NOM</td>
                </tr>
      
            </table>
               <asp:Button ID="Button1" runat="server" Text="exporter" OnClick="Button1_Click" />             
               <asp:Button ID="Button2" runat="server" Text="exporter tout" OnClick="Button2_Click" />             
</div>
    </form>
</body>
</html>
