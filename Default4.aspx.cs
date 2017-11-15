using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default4 : Page, IRequiresSessionState
{
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G_S1.Visible = false;
        this.G_S2.Visible = false;
        this.G_S3.Visible = false;
        this.G_S4.Visible = false;
        switch (this.DropDownList1.SelectedValue)
        {
            case "S1":
                this.G_S1.Visible = true;
                return;

            case "S2":
                this.G_S2.Visible = true;
                return;

            case "S3":
                this.G_S3.Visible = true;
                return;

            case "S4":
                this.G_S4.Visible = true;
                return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void S1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }

    protected void S2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }

    protected void S3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }

    protected void S4_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }

    protected void BOURG_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }

    protected void BLAYE_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }
    protected void BOURGOGNE_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }
    protected void VDLOIRE_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 300;
    }
}

