using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default6 : Page, IRequiresSessionState
{
    //protected TextBox ARGENT;
    //protected TextBox BRONZE;
    //protected Button Button1;
    //protected HtmlForm form1;
    //protected GridView GridView1;
    //protected GridView GridView2;
    //protected TextBox OR;
    //protected Label pARGENT;
    //protected Label pBRONZE;
    //protected Label pOR;
    //protected SqlDataSource SqlDataSource1;
    //protected SqlDataSource SqlDataSource2;

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                this.OR.Text = this.OR.Text.Replace(',', '.');
                this.ARGENT.Text = this.ARGENT.Text.Replace(',', '.');
                this.BRONZE.Text = this.BRONZE.Text.Replace(',', '.');
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE SEUIL SET [OR] ='" + this.OR.Text + "', ARGENT='" + this.ARGENT.Text + "', BRONZE='" + this.BRONZE.Text + "'";
                command.ExecuteNonQuery().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                this.pOR.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= ARGENT AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= ARGENT AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                this.pARGENT.Text = command.ExecuteScalar().ToString();
                command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= BRONZE AND ISNULL(NEW_NOTE,NOTE) < ARGENT THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= BRONZE AND ISNULL(NEW_NOTE,NOTE) < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                this.pBRONZE.Text = command.ExecuteScalar().ToString();
                connection.Close();
                this.GridView1.DataBind();
                this.GridView2.DataBind();
                this.OR.Text = this.OR.Text.Replace('.', ',');
                this.ARGENT.Text = this.ARGENT.Text.Replace('.', ',');
                this.BRONZE.Text = this.BRONZE.Text.Replace('.', ',');
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT [OR] FROM SEUIL";
                    this.OR.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT ARGENT FROM SEUIL";
                    this.ARGENT.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT BRONZE FROM SEUIL";
                    this.BRONZE.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                    this.pOR.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= ARGENT AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= ARGENT AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                    this.pARGENT.Text = command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT CAST(CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= BRONZE AND ISNULL(NEW_NOTE,NOTE) < ARGENT THEN 1 ELSE 0 END)*100.00 / SUM(1) AS DECIMAL(5,2)) AS VARCHAR(255)) + '% (' + CAST(SUM(CASE WHEN ISNULL(NEW_NOTE,NOTE) >= BRONZE AND ISNULL(NEW_NOTE,NOTE) < ARGENT THEN 1 ELSE 0 END) AS VARCHAR(10)) + ')' FROM PRECALCUL, SEUIL";
                    this.pBRONZE.Text = command.ExecuteScalar().ToString();
                    connection.Close();
                }
            }
        }
        this.OR.Text = this.OR.Text.Replace('.', ',');
        this.ARGENT.Text = this.ARGENT.Text.Replace('.', ',');
        this.BRONZE.Text = this.BRONZE.Text.Replace('.', ',');
    }

    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Alternate) || (e.Row.RowState == DataControlRowState.Normal)))
        {
            Button button1 = (Button) e.Row.FindControl("LinkButton1");
            string postBackUrl = button1.PostBackUrl;
            button1.PostBackUrl = postBackUrl + "?" + ((Button) e.Row.FindControl("LinkButton1")).CommandName + "=" + ((Button) e.Row.FindControl("LinkButton1")).CommandArgument;
        }
    }

}

