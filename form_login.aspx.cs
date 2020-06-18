using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mail;
using System.Net.Mail;
using System.Text;
namespace sell2world
{
    public partial class form_login : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr1;

        DateTime CurrentUtc_IND = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                //Response.Redirect(@"~\Index.aspx");
            }


        }
        protected void Btn_Login_Click(object sender, EventArgs e)
        {

            try
            {
                string Password = "";
                string UserName = "";
                string EmployeeName = "";

                int Result = 0, EmployeeId = 0, User_Id = 0;

                UserName = Tb_UserName.Text.ToString();
                Password = Tb_Password.Text.ToString();

                con.ConnectionString = str;
                cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "USP_Employee_Authentication";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);

                SqlParameter OP_Result = new SqlParameter();
                OP_Result.ParameterName = "@Result";
                OP_Result.DbType = DbType.Int32;
                OP_Result.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(OP_Result);

                SqlParameter OP_EmployeeId = new SqlParameter();
                OP_EmployeeId.ParameterName = "@EmployeeId";
                OP_EmployeeId.DbType = DbType.Int32;
                OP_EmployeeId.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(OP_EmployeeId);

                SqlParameter OP_EmployeeName = new SqlParameter();
                OP_EmployeeName.ParameterName = "@EmployeeName";
                OP_EmployeeName.DbType = DbType.String;
                OP_EmployeeName.Size = 200;
                OP_EmployeeName.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(OP_EmployeeName);





                cmd.ExecuteNonQuery();
                con.Close();

                Result = Convert.ToInt32(OP_Result.Value.ToString());

                if (Result == 1)
                {
                    EmployeeId = Convert.ToInt32(OP_EmployeeId.Value.ToString());
                    EmployeeName = OP_EmployeeName.Value.ToString();


                    Session["LoginEmployeeId"] = EmployeeId;
                    Session["LoginEmployeeName"] = EmployeeName;
                    Session["LoginUsername"] = UserName;
                    Session["LoginAuthenticated"] = "Yes";
                    //Session["LoginStudentEmail"] = Email;
                    //Session["LoginStudentUserId"] = User_Id;
                    //Session["LoginMembershipNumber"] = MembershipNumber;

                    con.Open();
                    cmd.Dispose();

                    //Response.Redirect(@"~\Home.aspx");


                    Response.Redirect(@"~\form_UserRegistration.aspx");

                }
                else if (Result == 0)
                {
                    //Invalid user name and password
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error Invalid Username or Password')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
        }



    }
}