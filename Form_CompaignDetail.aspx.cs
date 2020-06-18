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
using System.Web.Mail;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Net.Configuration;
namespace sell2world
{
    public partial class Form_CompaignDetail : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        DateTime CurrentUtc_IND = DateTime.UtcNow.AddHours(5).AddMinutes(30);

        int CompaignId = 0;
        string CompaignName = "";
        string CompaignDate="";

        string JobFunction="";
        string CompanySize = "";
        string Industry = "";
        string Country = "";
        string CustomeQuestion = "";


        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetNextCompaignId();
            fill_compaign();
        }
        private void fill_compaign()
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select CompaignId , CompaignName,CompaignDate,JobFunction,CompanySize,Industry, Country, CustomeQuestion from Tbl_CompaignDetail";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();


        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            

            CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
            CompaignName = (Tb_CompaignName.Text.ToString());
            CompaignDate = (Dp_CompaignDate.Text.ToString());
            JobFunction = (Tb_JobFunction.Text.ToString());

            CompanySize =(Tb_CompanySize.Text.ToString());
            Industry = (Tb_Industry.Text.ToString());
            Country = (Tb_Country.Text.ToString());
            CustomeQuestion = (Tb_CustomQuestion.Text.ToString());


            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CompaignDetail";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
            cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime(CompaignDate));
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

            cmd.Parameters.AddWithValue("@CompanySize", CompanySize);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@selecttype", "insert");
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('save succesfully'", true);
            cleardata();
            fill_compaign();


        }

        private void cleardata()
        {
            Tb_CompaignName.Text = "";
            Dp_CompaignDate.Text = "";
            Tb_JobFunction.Text = "";


            Tb_CompanySize.Text = "";
            Tb_Industry.Text ="";
            Tb_Country.Text = "";
            Tb_CustomQuestion.Text = "";


        }


        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
            CompaignName = (Tb_CompaignName.Text.ToString());
            CompaignDate = (Dp_CompaignDate.Text.ToString());
            JobFunction = (Tb_JobFunction.Text.ToString());

            CompanySize = (Tb_CompanySize.Text.ToString());
            Industry = (Tb_Industry.Text.ToString());
            Country = (Tb_Country.Text.ToString());
            CustomeQuestion = (Tb_CustomQuestion.Text.ToString());


            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CompaignDetail";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
            cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime(CompaignDate));
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

            cmd.Parameters.AddWithValue("@CompanySize", CompanySize);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@selecttype", "delete");
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('delete succesfully'", true);
            cleardata();
            fill_compaign();


        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
            CompaignName = (Tb_CompaignName.Text.ToString());
            CompaignDate = (Dp_CompaignDate.Text.ToString());
            JobFunction = (Tb_JobFunction.Text.ToString());

            CompanySize = (Tb_CompanySize.Text.ToString());
            Industry = (Tb_Industry.Text.ToString());
            Country = (Tb_Country.Text.ToString());
            CustomeQuestion = (Tb_CustomQuestion.Text.ToString());


            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CompaignDetail";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
            cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime( CompaignDate));
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

            cmd.Parameters.AddWithValue("@CompanySize", CompanySize);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@selecttype", "update");
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('update succesfully'", true);
            cleardata();
            fill_compaign();



        }

        protected void Btn_new_Click(object sender, EventArgs e)
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select isnull((select max(CompaignId)from Tbl_CompaignDetail),0)+1 'CompaignId' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Tb_CompaignId.Text = dr["CompaignId"].ToString();
            }
            dr.NextResult();
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('new'+ ex.message.tostring() +", true);

        }


        private void GetNextCompaignId()
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select isnull((select max(CompaignId)from Tbl_CompaignDetail),0)+1 'CompaignId' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Tb_CompaignId.Text = dr["CompaignId"].ToString();
            }
            dr.NextResult();
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('new'+ ex.message.tostring() +", true);

        }




        protected void Btn_view_Click(object sender, EventArgs e)
        {
            Compaignfill(CompaignId = Convert.ToInt32(Tb_CompaignId .Text.ToString()));
        }
        private void Compaignfill(int CompaignId)
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "USP_CompaignDetail";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
            cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime(CompaignDate));
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

            cmd.Parameters.AddWithValue("@CompanySize", CompanySize);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@selecttype", "select");
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                ////TextBox1.Text = dr[""].ToString();
                Tb_CompaignName .Text = dr["CompaignName"].ToString();
                Dp_CompaignDate .Text = dr["CompaignDate"].ToString();
                Tb_JobFunction .Text = dr["JobFunction"].ToString();
                

                Tb_CompanySize .Text = dr["CompanySize"].ToString();
                Tb_Industry .Text = dr["Industry"].ToString();
                Tb_Country .Text = dr["Country"].ToString();
                Tb_CustomQuestion .Text = dr["CustomeQuestion"].ToString();
            }
            dr.NextResult();
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('fill grid'+ ex.message.tostring() +", true);




        }
    }
}