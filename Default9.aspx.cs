using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default9 : Page, IRequiresSessionState
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        if (this.NUMERO.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "NUMERO ";
        }
        if (this.MEDAILLE_NUM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 1 WHEN ISNULL(NEW_NOTE,NOTE) >= [ARGENT] AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 2 WHEN ISNULL(NEW_NOTE,NOTE) >= [BRONZE] AND ISNULL(NEW_NOTE,NOTE) < [ARGENT] THEN 3 ELSE 0 END AS MEDAILLE_NUM ";
        }
        if (this.NOTE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "ISNULL(NEW_NOTE,NOTE) AS NOTE ";
        }
        if (this.MEDAILLE_TXT.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 'OR' WHEN ISNULL(NEW_NOTE,NOTE) >= [ARGENT] AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 'ARGENT' WHEN ISNULL(NEW_NOTE,NOTE) >= [BRONZE] AND ISNULL(NEW_NOTE,NOTE) < [ARGENT] THEN 'BRONZE' ELSE '' END AS MEDAILLE_TXT ";
        }
        if (this.NOM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "NOM ";
        }
       if (this.TYPE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "TYPE ";
        }
      /*  if (this.SERIE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "SERIE ";
        }
        if (this.RANG.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "RANG ";
        }
        if (this.CATEGORIE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CATEGORIE ";
        }
        if (this.PAYS.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "PAYS ";
        }
        if (this.APPELLATION.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "APPELLATION ";
        }
        if (this.MILLESIME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "MILLESIME ";
        }
        if (this.FIRME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "FIRME ";
        }
        if (this.NOM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "NOM ";
        }
        if (this.PRENOM.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "PRENOM ";
        }
        if (this.CRU_OU_MARQUE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "[CRU OU MARQUE] ";
        }
        if (this.CAB.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CAB ";
        }
        if (this.NUMERO_OXY.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "[NUMERO OXY] ";
        }
        if (this.VOLUME.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "VOLUME ";
        }
        if (this.CEPAGE.Checked)
        {
            if (!str.Equals(string.Empty))
            {
                str = str + ",";
            }
            str = str + "CEPAGE ";
        }*/
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + str + "FROM [PRECALCUL], SEUIL ORDER BY ISNULL(NEW_NOTE,NOTE) DESC", connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "CSV");
            DataTable dt = dataSet.Tables["CSV"];
            this.CreateCSVFile(dt, @"D:\01 - CHALLENGE\Export_" + DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-') + ".csv");
            connection.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = "[JURY] ,[NB_JURE] 'NB JURE' ,[ORDRE] ,[NUMERO] ,CASE WHEN ISNULL(NEW_NOTE,NOTE) >= [OR] THEN 'OR'  WHEN ISNULL(NEW_NOTE,NOTE) >= [ARGENT] AND ISNULL(NEW_NOTE,NOTE) < [OR] THEN 'ARGENT'  WHEN ISNULL(NEW_NOTE,NOTE) >= [BRONZE] AND ISNULL(NEW_NOTE,NOTE) < [ARGENT] THEN 'BRONZE'  ELSE ''  END AS MEDAILLE ,ISNULL([NEW_NOTE],[NOTE]) NOTE ,[ECART_TYPE] 'ECART TYPE' , APRECIATION_PONDEREE 'APRECIATION PONDEREE'     , C1 FLORAL, C2 FRUITE, C3 EPICE, C4 BOISE, C5 MINERAL, C6, C7 NERVEUX, C8 EQUILIBRE, C9 SOUPLE, C10 LEGER, C11 STRUCTURE, C12 PUISSANT, C13 PUISS_AROMATIQUE, C14, C15, C16, C17 , A4 MOYEN, A3 BON, A2 'TRES BON', A1 EXCELLENT, CA4 JAMAIS, CA3 'PEUT-ETRE', CA2 SUREMENT, CA1 AFFAIRE, [FIRME] ,[TYPE] ,[PAYS] ,[APPELLATION] ,[NOM] ,[MILLESIME] ,[VOLUME] ,[CEPAGE] ,[PRIX]";
      
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + str + "FROM [PRECALCUL], SEUIL ORDER BY ISNULL(NEW_NOTE,NOTE) DESC", connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "CSV");
            DataTable dt = dataSet.Tables["CSV"];
            this.CreateCSVFile(dt, @"D:\CDV\01 - CHALLENGE\Export_" + DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-') + ".csv");
            connection.Close();
        }
    }

    public void CreateCSVFile(DataTable dt, string strFilePath)
    {
        StreamWriter writer = new StreamWriter(strFilePath, false);
        int count = dt.Columns.Count;
        for (int i = 0; i < count; i++)
        {
            writer.Write( dt.Columns[i] );
            //writer.Write("\"" + dt.Columns[i] + "\"");
            if (i < (count - 1))
            {
                writer.Write(";");
            }
        }
        writer.Write(writer.NewLine);
        foreach (DataRow row in dt.Rows)
        {
            for (int j = 0; j < count; j++)
            {
                if (!Convert.IsDBNull(row[j]))
                {
                    writer.Write( row[j].ToString() );
                    //writer.Write("\"" + row[j].ToString() + "\"");
                }
                if (j < (count - 1))
                {
                    writer.Write(";");
                }
            }
            writer.Write(writer.NewLine);
        }
        writer.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

