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

namespace Sell2W
{
    public partial class Form_Login : System.Web.UI.Page
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

                    Response.Redirect(@"~\Home.aspx");

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



        //protected void Btn_Login_Click(object sender, EventArgs e)
        //{

        //    string Password = "";
        //    string UserName = "";
        //    UserName = Tb_UserName.Text.ToString();
        //    Password = Tb_Password.Text.ToString();
        //    con.ConnectionString = str;
        //    cmd = new SqlCommand();
        //    con.Open();
        //    string a = "";
        //    string b = "";



        //    cmd.CommandText = "USP_User_Authentication2";
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@UserName", UserName);
        //    cmd.Parameters.AddWithValue("@Password", Password);
        //    cmd.Connection = con;
        //    dr = cmd.ExecuteReader();

        //    if (dr.HasRows)
        //    {
        //        Allowlogin();
        //    }

        //    else
        //    {

        //        Allowlogin();
        //        dr.Close();
        //    }
        //    con.Close();
        //}


        //private void Allowlogin()
        //{
        //    try
        //    {
        //        string Password = "";
        //        string UserName = "";
        //        string Employee_Name = "";
        //        string Email = "", Mobile = "", UserImgPath = "";
        //        int Result = 0, Role_Id = 0, Employee_Id = 0, Is_SuperAdmin = 0, User_Id = 0, ServiceCentre_Id = 0, ServiceCentreCompany_Id = 0;

        //        UserName = Tb_UserName.Text.ToString();
        //        Password = Tb_Password.Text.ToString();

        //        //con.ConnectionString = str;
        //        cmd = new SqlCommand();
        //        //con.Open();
        //        cmd.CommandText = "USP_User_Authentication";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@UserName", UserName);
        //        cmd.Parameters.AddWithValue("@Password", Password);

        //        SqlParameter OP_Result = new SqlParameter();
        //        OP_Result.ParameterName = "@Result";
        //        OP_Result.DbType = DbType.Int32;
        //        OP_Result.Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add(OP_Result);

        //        SqlParameter OP_Role_Id = new SqlParameter();
        //        OP_Role_Id.ParameterName = "@Role_Id";
        //        OP_Role_Id.DbType = DbType.Int32;
        //        OP_Role_Id.Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add(OP_Role_Id);

        //        SqlParameter OP_Employee_Id = new SqlParameter();
        //        OP_Employee_Id.ParameterName = "@Employee_Id";
        //        OP_Employee_Id.DbType = DbType.Int32;
        //        OP_Employee_Id.Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add(OP_Employee_Id);




        //        SqlParameter OP_Employee_Name = new SqlParameter();
        //        OP_Employee_Name.ParameterName = "@Employee_Name";
        //        OP_Employee_Name.DbType = DbType.String;
        //        OP_Employee_Name.Size = 200;
        //        OP_Employee_Name.Direction = ParameterDirection.Output;

        //        cmd.Parameters.Add(OP_Employee_Name);




        //        dr.Close();
        //        cmd.ExecuteNonQuery();

        //        con.Close();


        //        Result = Convert.ToInt32(OP_Result.Value.ToString());

        //        if (Result == 1)
        //        {
        //            Role_Id = Convert.ToInt32(OP_Role_Id.Value.ToString());
        //            Employee_Id = Convert.ToInt32(OP_Employee_Id.Value.ToString());

        //            Employee_Name = OP_Employee_Name.Value.ToString();
        //            //Email = OP_Email.Value.ToString();
        //            //Mobile = OP_Contact_Mobile.Value.ToString();
        //            //User_Id = Convert.ToInt32(OP_UserId.Value.ToString());
        //            //UserImgPath = OP_UserImg.Value.ToString();

        //            Session["LoginEmployee_Id"] = Employee_Id;
        //            Session["LoginRole_Id"] = Role_Id;
        //            Session["LoginUsername"] = UserName;
        //            Session["LoginAuthenticated"] = "Yes";
        //            //Session["LoginIs_SuperAdmin"] = Is_SuperAdmin;
        //            //Session["LoginEmpName"] = Employee_Name;
        //            //Session["LoginEmpEmail"] = Email;
        //            //Session["LoginEmpMobile"] = Mobile;
        //            //Session["LoginUserId"] = User_Id;
        //            //Session["UserImgPath"] = UserImgPath;

        //            con.Open();
        //            cmd.Dispose();

        //            con.Close();


        //            Response.Redirect(@"~\Home.aspx");
        //            //Session.Abandon();
        //            //Session.RemoveAll();
        //        }
        //        else if (Result == 0)
        //        {
        //            //Invalid user name and password
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error Invalid Username or Password')", true);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
        //    }


        //}
    }
}