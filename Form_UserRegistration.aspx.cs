using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
namespace Sell2W
{
    public partial class Form_UserRegistration : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        string UserName = "";
        int EmployeeId = 0;
        int EmployeeId_ToUpdate = 0;
        int CallFor = 0;
        DateTime CurrentUtc_IND = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["LoginUsername"] == null || Session["LoginAuthenticated"] == "No")
            {
                Response.Redirect(@"~\Form_Login.aspx");
            }
            else
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                
                UserName = Session["LoginUsername"].ToString();
                //  EmployeeId = Convert.ToInt32(Session["LoginEmployee_Id"].ToString());

                if (Request.QueryString.Count > 0)
                {
                    try
                    {
                        //EmployeeId_ToUpdate = Convert.ToInt32(Request.QueryString[0].ToString());
                        //CallFor = Convert.ToInt32(Request.QueryString["Call"].ToString());

                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Invalid Operation');window.location='Home.aspx'", true);
                    }
                }

                if (!IsPostBack)
                {

                }
                TxtEmployeeId.Enabled = true;
                fill_emplyoeeId();

            }
        }

        private void fill_emplyoeeId()
        {
           
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select ISNULL((select max(EmployeeAuthenticationId) from tbl_EmployeeAuthentication),0)+1 'EmployeeId'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtEmployeeId.Text = dr["EmployeeId"].ToString();
            }
            dr.NextResult();
            dr.Close();
            con.Close();
        }

        private int Validation()
        {
            {
                int Go = 1;
                string ValidationMsg = "";

                if (txtemployeenm.Text == "")
                {
                    Go = 0;
                    txtemployeenm.BorderColor = Color.Red;
                    ValidationMsg += "Please Enter First name. /";
                }
                else
                {
                    txtemployeenm.BorderColor = Color.LightGray;
                }


                if (Go == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :" + ValidationMsg.ToString() + "')", true);
                }
                return Go;

            }
        }
        //public static string CreateRandomPassword(int PasswordLength)
        //{
        //    //string _allowedChars = "0123456789!:=abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        //    //Random randNum = new Random();
        //    //char[] chars = new char[PasswordLength];
        //    //int allowedCharCount = _allowedChars.Length;
        //    //for (int i = 0; i < PasswordLength; i++)
        //    //{
        //    //    chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        //    //}
        //    //return new string(chars);
        //}


        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            int EmployeeId = 0;
            string EmployeeNm = "";
            string AccountPassword = "";
            AccountPassword = TxtPssword.Text;

            EmployeeNm = txtemployeenm.Text.ToString();
            con.ConnectionString = str;
            cmd = new SqlCommand();
            con.Open();

            SqlTransaction tran = con.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.CommandText = "USP_EmployeeDetail_Insert";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeNm", EmployeeNm);


                cmd.Parameters.AddWithValue("@AccountPassword", AccountPassword);

                cmd.Parameters.AddWithValue("@CreatedDate", CurrentUtc_IND);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);

                //SqlParameter OP_MemberShipNumber = new SqlParameter();
                //OP_MemberShipNumber.Direction = ParameterDirection.Output;
                //OP_MemberShipNumber.ParameterName = "@MemberShipNumber";
                //OP_MemberShipNumber.DbType = DbType.String;
                //OP_MemberShipNumber.Size = 255;
                //cmd.Parameters.Add(OP_MemberShipNumber);

                SqlParameter OP_EmployeeId = new SqlParameter();
                OP_EmployeeId.Direction = ParameterDirection.Output;
                OP_EmployeeId.ParameterName = "@EmployeeId";
                OP_EmployeeId.DbType = DbType.Int32;
                cmd.Parameters.Add(OP_EmployeeId);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(@"~\Form_Welcome.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
        }

    
}










       
    }
