using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace Sell2W
{
    public partial class Home : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;

        int EmployeeId=0;
        string UserName;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUsername"] == null || Session["LoginAuthenticated"] == "No")
            {
                Response.Redirect(@"~\Form_Login");
            }
            else
            {
                UserName = Session["LoginUsername"].ToString();

                //  EmployeeId = Convert.ToInt32(Session["LoginEmployee_Id"].ToString());

                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                if (!IsPostBack)
                {
                    

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Form_UserRegistration");
        }
    }
}