using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default3 : Page, IRequiresSessionState
{
    //protected Button Button1;
    //protected FileUpload FileUpload1;
    //protected HtmlForm form1;
    //protected Label Label1;
    //protected Label Label2;
    //protected Label Label3;

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            string fileName = FileUpload1.PostedFile.FileName;
            string TempfileLocation = Server.MapPath("~/");
            string FullPath = System.IO.Path.Combine(TempfileLocation, fileName);
            FileUpload1.SaveAs(FullPath);

            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCommand command = new SqlCommand("BULK INSERT SAISIE_SERIE FROM '" + FullPath + "' WITH (FIRSTROW = 1, MAXERRORS = 0, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n')"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery().ToString();
                    connection.Close();
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM (SELECT DISTINCT JURE, JURY, ORDRE FROM SAISIE_SERIE) SS"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    int num = int.Parse(this.Label1.Text);
                    this.Label1.Text = command.ExecuteScalar().ToString();
                    this.Label2.Visible = true;
                    this.Label3.Text = (int.Parse(this.Label1.Text) - num).ToString();
                    connection.Close();
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM (SELECT DISTINCT JURY, ORDRE FROM SAISIE_SERIE) SS"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    int num = int.Parse(this.Label4.Text);
                    this.Label4.Text = command.ExecuteScalar().ToString();
                    this.Label5.Visible = true;
                    this.Label6.Text = (int.Parse(this.Label4.Text) - num).ToString();
                    connection.Close();
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM (SELECT DISTINCT JURE, JURY, ORDRE FROM SAISIE_SERIE) SS"))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                this.Label1.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }
        using (SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM (SELECT DISTINCT JURY, ORDRE FROM SAISIE_SERIE) SS"))
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                command.Connection = connection;
                this.Label4.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }

    }

}

