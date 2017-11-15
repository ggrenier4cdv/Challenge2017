<%@ page language="C#" autoeventwireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONSULTATION</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default.aspx">MENU</a>
            <br />
            <br />
            <table border="0">
                <tr>
                    <td>
                        Seuil Or :
                    </td>
                    <td>
                        <asp:TextBox ID="OR" runat="server" Text="" />
                    </td>
                    <td>
                        <asp:Label ID="pOR" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Seuil Argent :
                    </td>
                    <td>
                        <asp:TextBox ID="ARGENT" runat="server" Text="" />
                    </td>
                    <td>
                        <asp:Label ID="pARGENT" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Seuil Bronze :
                    </td>
                    <td>
                        <asp:TextBox ID="BRONZE" runat="server" Text="" />
                    </td>
                    <td>
                        <asp:Label ID="pBRONZE" runat="server" Text="" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Mise à Jour" OnClick="Button1_Click" />
        <table>
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
                        OnRowDataBound="RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="PAYS" SortExpression="PAYS">
                                <ItemTemplate>
                                    <asp:Button Width="100%" ID="LinkButton1" runat="server" PostBackUrl="~/Default7.aspx" CommandName="PAYS"
                                        CommandArgument='<%# Eval("PAYS") %>' Text='<%# Eval("PAYS") %>' />
                                    <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NbOr" HeaderText="OR" SortExpression="NbOr" />
                            <asp:BoundField DataField="NbArgent" HeaderText="ARGENT" SortExpression="NbArgent" />
                            <asp:BoundField DataField="NbBronze" HeaderText="BRONZE" SortExpression="NbBronze" />
                            <asp:BoundField DataField="None" HeaderText="AUCUNE" SortExpression="None" />
                            <asp:BoundField DataField="PoucentMedaille" HeaderText="% Medaille" SortExpression="PoucentMedaille" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                </td>
                <td style="width: 50px">
                </td>
                <td valign="top">
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False"
                        OnRowDataBound="RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="TYPE" SortExpression="TYPE">
                                <ItemTemplate>
                                    <asp:Button Width="100%" ID="LinkButton1" runat="server" PostBackUrl="~/Default8.aspx" CommandName="TYPE"
                                        CommandArgument='<%# Eval("TYPE") %>' Text='<%# Eval("TYPE") %>' />
                                    <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NbOr" HeaderText="OR" SortExpression="NbOr" />
                            <asp:BoundField DataField="NbArgent" HeaderText="ARGENT" SortExpression="NbArgent" />
                            <asp:BoundField DataField="NbBronze" HeaderText="BRONZE" SortExpression="NbBronze" />
                            <asp:BoundField DataField="None" HeaderText="AUCUNE" SortExpression="None" />
                            <asp:BoundField DataField="PoucentMedaille" HeaderText="% Medaille" SortExpression="PoucentMedaille" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="DECLARE @OR FLOAT&#13;&#10;DECLARE @AR FLOAT&#13;&#10;DECLARE @BR FLOAT&#13;&#10;SET @OR = (SELECT TOP 1 [OR] FROM SEUIL)&#13;&#10;SET @AR = (SELECT TOP 1 [ARGENT] FROM SEUIL)&#13;&#10;SET @BR = (SELECT TOP 1 [BRONZE] FROM SEUIL)&#13;&#10;SELECT&#13;&#10;PAYS,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @OR THEN 1 ELSE 0 END) AS NbOr,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @AR AND ISNULL(NEW_NOTE,NOTE) < @OR THEN 1 ELSE 0 END) AS NbArgent,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @BR AND ISNULL(NEW_NOTE,NOTE) < @AR THEN 1 ELSE 0 END) AS NbBronze,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) < @BR THEN 1 ELSE 0 END) AS None,&#13;&#10;CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @BR THEN 1 ELSE 0 END)*100 / SUM(1) AS VARCHAR(255)) + '%' As PoucentMedaille&#13;&#10;FROM PRECALCUL&#13;&#10;GROUP BY PAYS ORDER BY PAYS" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="DECLARE @OR FLOAT&#13;&#10;DECLARE @AR FLOAT&#13;&#10;DECLARE @BR FLOAT&#13;&#10;SET @OR = (SELECT TOP 1 [OR] FROM SEUIL)&#13;&#10;SET @AR = (SELECT TOP 1 [ARGENT] FROM SEUIL)&#13;&#10;SET @BR = (SELECT TOP 1 [BRONZE] FROM SEUIL)&#13;&#10;SELECT&#13;&#10;TYPE,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @OR THEN 1 ELSE 0 END) AS NbOr,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @AR AND ISNULL(NEW_NOTE,NOTE) < @OR THEN 1 ELSE 0 END) AS NbArgent,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @BR AND ISNULL(NEW_NOTE,NOTE) < @AR THEN 1 ELSE 0 END) AS NbBronze,&#13;&#10;SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) < @BR THEN 1 ELSE 0 END) AS None,&#13;&#10;CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= @BR THEN 1 ELSE 0 END)*100 / SUM(1) AS VARCHAR(255)) + '%' As PoucentMedaille&#13;&#10;FROM PRECALCUL&#13;&#10;GROUP BY TYPE ORDER BY TYPE" />
    </form>
</body>
</html>
