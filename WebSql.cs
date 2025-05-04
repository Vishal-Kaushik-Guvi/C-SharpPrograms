using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page 
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ab"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        Response.Write("Connection Established to SQl Server Successfully...Weldone");



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Employee values(@eno,@en,@ed,@es)";
        cmd.Parameters.Add("@eno", SqlDbType.Int).Value = Convert.ToInt32 (textbox1.Text);
        cmd.Parameters.Add("@en", SqlDbType.NVarChar, 50).Value = TextBox2.Text;
        cmd.Parameters.Add("@ed", SqlDbType.NVarChar, 50).Value = TextBox3.Text;
        cmd.Parameters.Add("@es", SqlDbType.Int).Value = Convert.ToInt32 (TextBox4.Text);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        textbox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        textbox1.Focus();
    }
}