using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default8 : Page, IRequiresSessionState
{
    //protected HtmlForm form1;
    //protected GridView GridView1;
    //protected Label Label1;
    //protected SqlDataSource SqlDataSource1;

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand("UPDATE PRECALCUL SET NOTE=" + e.NewValues[0].ToString().Replace(',', '.') + " WHERE NUMERO=" + e.Keys[0].ToString()))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery().ToString();
                connection.Close();
            }
        }
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = base.Request.Params["TYPE"];
    }


}

