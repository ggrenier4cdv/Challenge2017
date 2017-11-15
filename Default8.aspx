<%@ page language="C#" autoeventwireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>COMMISSION</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default6.aspx">RETOUR</a>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NUMERO"
                DataSourceID="SqlDataSource1" OnRowUpdated="GridView1_RowUpdated" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
<asp:BoundField DataField="JURY" HeaderText="JURY" ReadOnly="True" SortExpression="JURY" />
<asp:BoundField DataField="NB_JURE" HeaderText="NB JURY" ReadOnly="True" SortExpression="NB_JURE" />
<asp:BoundField DataField="ORDRE" HeaderText="ORDRE" ReadOnly="True" SortExpression="ORDRE" />
<asp:BoundField DataField="NUMERO" HeaderText="NUMERO" ReadOnly="True" SortExpression="NUMERO" />
<asp:BoundField DataField="MEDAILLE" HeaderText="MEDAILLE" ReadOnly="True" SortExpression="MEDAILLE" /><asp:TemplateField HeaderText="NOTE" SortExpression="NOTE">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NOTE") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOTE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
<asp:BoundField DataField="ECART_TYPE" HeaderText="ECART-TYPE" ReadOnly="True" SortExpression="ECART_TYPE" />

<asp:BoundField DataField="FIRME" HeaderText="FIRME" ReadOnly="True" SortExpression="FIRME" />
<asp:BoundField DataField="TYPE" HeaderText="TYPE" ReadOnly="True" SortExpression="TYPE" />
<asp:BoundField DataField="PAYS" HeaderText="PAYS" ReadOnly="True" SortExpression="PAYS" />
<asp:BoundField DataField="APPELLATION" HeaderText="APPELLATION" ReadOnly="True" SortExpression="APPELLATION" />
<asp:BoundField DataField="NOM" HeaderText="NOM" ReadOnly="True" SortExpression="NOM" />
<asp:BoundField DataField="MILLESIME" HeaderText="MILLESIME" ReadOnly="True" SortExpression="MILLESIME" />
<asp:BoundField DataField="VOLUME" HeaderText="VOLUME" ReadOnly="True" SortExpression="VOLUME" />
<asp:BoundField DataField="CEPAGE" HeaderText="CEPAGE" ReadOnly="True" SortExpression="CEPAGE" />
<asp:BoundField DataField="PRIX" HeaderText="PRIX" ReadOnly="True" SortExpression="PRIX" />
<asp:BoundField DataField="CEPAGE" HeaderText="CEPAGE" ReadOnly="True" SortExpression="CEPAGE" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT
 JURY, 
 NB_JURE,
 ORDRE,
 NUMERO,
 CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 'OR' 
 WHEN ISNULL(NEW_NOTE,NOTE) >= [ARGENT] AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 'ARGENT'
 WHEN ISNULL(NEW_NOTE,NOTE) >= [BRONZE] AND ISNULL(NEW_NOTE,NOTE) < [ARGENT] THEN 'BRONZE' 
 ELSE '' END AS MEDAILLE,
 ISNULL(NEW_NOTE,NOTE) AS NOTE,
 ECART_TYPE,
 APRECIATION_PONDEREE, 
 C1,
 C2,
 C3,
 C4,
 C5,
 C6,
 C7,
 C8,
 C9,
 C10,
 C11,
 C12,
 C13,
 C14,
 C15,
 C16,
 C17,
 A5,
 A4,
 A3,
 A2,
 A1,
 CA4,
 CA3,
 CA2,
 CA1,
 FIRME,
 TYPE, 
 PAYS,
 APPELLATION, 
 NOM, 
 MILLESIME,
 VOLUME,
 CEPAGE,
 PRIX
 FROM [PRECALCUL], SEUIL WHERE ([TYPE] = @TYPE
 ) ORDER BY [NOTE] DESC"
                   UpdateCommand="SELECT 1" >
                <SelectParameters>
                    <asp:QueryStringParameter Name="TYPE" QueryStringField="TYPE" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
