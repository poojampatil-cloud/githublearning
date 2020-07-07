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

namespace compaings2w
{
    public partial class Form_MISsearch : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        DataSet ds;

        string UserName = "";
        int EmployeeId = 0;

        string Country = "";
        string JobTitle = "";
        string Industry = "";
        string Revenue = "";

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
                EmployeeId = Convert.ToInt32(Session["LoginEmployeeId"].ToString());

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
                    //Tb_SearchData.Visible = false;
                    //fill_LeadData();
                    Tb_SearchData.Enabled = false;
                }
              

            }
        }

        protected void DD_SearchValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DD_SearchValue.SelectedItem.Value == "5")
            {
                Tb_SearchData.Enabled = false;
            }
            if (DD_SearchValue.SelectedItem.Value == "1")
            {
                Tb_SearchData.Enabled = true;
            }
            if (DD_SearchValue.SelectedItem.Value == "2")
            {
                Tb_SearchData.Enabled = true;
            }
            if (DD_SearchValue.SelectedItem.Value == "3")
            {
                Tb_SearchData.Enabled = true;
            }
            if (DD_SearchValue.SelectedItem.Value == "4")
            {
                Tb_SearchData.Enabled = true;
            }

        }
        private void fill_compaignByCountry()
        {
           Country = (Tb_SearchData.Text.ToString());
            try
            { 

            if (DD_SearchValue.SelectedItem.Value == "1")
            {
                    con.ConnectionString = str;
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_SearchData";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JobTitle",DBNull.Value);

                    cmd.Parameters.AddWithValue("@Country", Country);
                    cmd.Parameters.AddWithValue("@Industry",DBNull.Value);

                    cmd.Parameters.AddWithValue("@Revenue",DBNull.Value);

                    cmd.Parameters.AddWithValue("@selecttype","selectCountry");


                    //cmd.CommandText = "select ClientId,FirstName,LastName,Email,JobTitle,CompanyName,PhoneNumber,CreatedDate from Tbl_CreateLeadData where Country=" + Country;
                    //cmd.Connection = con;
                    // da = new SqlDataAdapter(cmd);
                    //ds = new DataSet();
                    //da.Fill(ds, "MISsearch");

                    //dr = cmd.ExecuteReader();
                    //Gv_MIS.DataSource = ds.Tables["MISsearch"];
                    //Gv_MIS.DataBind();
                    //con.Close();

                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();



                    String UnreadText = "";
                    Int32 i = 0;

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UnreadText += "<tr>";

                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["FirstName"].ToString() + "</span></div></td>";

                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompanyName"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["PhoneNumber"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";


                            UnreadText += "</tr>";
                            UnreadText += "</tr>";
                            tlist.InnerHtml = UnreadText;
                            i++;
                        }
                    }

                    else
                    {
                        UnreadText += "<tr>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "</tr>";


                        UnreadText += "</tr>";
                        tlist.InnerHtml = UnreadText;


                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
            }
        }
        private void fill_compaignByIndustry()
        {
            Industry = Tb_SearchData.Text.ToString();
            try
            {
                if (DD_SearchValue.SelectedItem.Value == "3")
                {
                    con.ConnectionString = str;
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_SearchData";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JobTitle", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Industry", Industry);

                    cmd.Parameters.AddWithValue("@Revenue", DBNull.Value);

                    cmd.Parameters.AddWithValue("@selecttype", "selectIndustry");
                    //cmd.CommandText = "select ClientId,FirstName,LastName, Email,JobTitle,CompanyName,PhoneNumber,CreatedDate from Tbl_CreateLeadData where Industry=" + Industry;


                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();



                    String UnreadText = "";
                    Int32 i = 0;

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UnreadText += "<tr>";

                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["LeadDataId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["FirstName"].ToString() + "</span></div></td>";

                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompanyName"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["PhoneNumber"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";


                            UnreadText += "</tr>";
                            UnreadText += "</tr>";
                            tlist.InnerHtml = UnreadText;
                            i++;
                        }
                    }

                    else
                    {
                        UnreadText += "<tr>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "</tr>";


                        UnreadText += "</tr>";
                        tlist.InnerHtml = UnreadText;


                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
            }
        }
        private void fill_LeadData()
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "USP_SearchData";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@JobTitle", DBNull.Value);

            cmd.Parameters.AddWithValue("@Country", DBNull.Value);
            cmd.Parameters.AddWithValue("@Industry", DBNull.Value);

            cmd.Parameters.AddWithValue("@Revenue", DBNull.Value);

            cmd.Parameters.AddWithValue("@selecttype", "selectAll");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();



            String UnreadText = "";
            Int32 i = 0;

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    UnreadText += "<tr>";
                 
                   
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                    //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["FirstName"].ToString() + "</span></div></td>";

                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompanyName"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["PhoneNumber"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";

                    UnreadText += "</tr>";
                    UnreadText += "</tr>";
                    tlist.InnerHtml = UnreadText;
                    i++;
                }
            }

            else
            {
                UnreadText += "<tr>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "    <td></td>";
                UnreadText += "</tr>";


                UnreadText += "</tr>";
                tlist.InnerHtml = UnreadText;


            }
            Tb_SearchData.Enabled = true;
            con.Close();
        }
        private void fill_compaignByRevnue()
        {
            Revenue = Tb_SearchData.Text.ToString();
            try
            {
                if (DD_SearchValue.SelectedItem.Value == "4")
                {
                    con.ConnectionString = str;
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_SearchData";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JobTitle", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Industry", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Revenue",Revenue);

                    cmd.Parameters.AddWithValue("@selecttype", "selectRevenue");
                    //cmd.CommandText = "select ClientId,FirstName,LastName, Email,JobTitle,CompanyName,PhoneNumber,CreatedDate from Tbl_CreateLeadData where Revenue=" + Revenue;


                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();



                    String UnreadText = "";
                    Int32 i = 0;

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UnreadText += "<tr>";

                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["LeadDataId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["FirstName"].ToString() + "</span></div></td>";

                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompanyName"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["PhoneNumber"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";


                            UnreadText += "</tr>";
                            UnreadText += "</tr>";
                            tlist.InnerHtml = UnreadText;
                            i++;
                        }
                    }

                    else
                    {
                        UnreadText += "<tr>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "</tr>";


                        UnreadText += "</tr>";
                        tlist.InnerHtml = UnreadText;


                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
            }
        }

        private void fill_compaignByJobTitle()
        {
            JobTitle = Tb_SearchData.Text.ToString();
            try
            {
                if (DD_SearchValue.SelectedItem.Value == "2")
                {
                    con.ConnectionString = str;
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "USP_SearchData";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JobTitle", JobTitle);

                    cmd.Parameters.AddWithValue("@Country", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Industry", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Revenue", DBNull.Value);

                    cmd.Parameters.AddWithValue("@selecttype", "selectJobTitle");
                    //cmd.CommandText = "select ClientId,FirstName,LastName, Email,JobTitle,CompanyName,PhoneNumber,CreatedDate from Tbl_CreateLeadData where JobTitle=" + JobTitle;


                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();



                    String UnreadText = "";
                    Int32 i = 0;

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UnreadText += "<tr>";

                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["LeadDataId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                            //UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["FirstName"].ToString() + "</span></div></td>";

                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompanyName"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["PhoneNumber"].ToString() + "</span></div></td>";
                            UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";


                            UnreadText += "</tr>";
                            UnreadText += "</tr>";
                            tlist.InnerHtml = UnreadText;
                            i++;
                        }
                    }

                    else
                    {
                        UnreadText += "<tr>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "    <td></td>";
                        UnreadText += "</tr>";


                        UnreadText += "</tr>";
                        tlist.InnerHtml = UnreadText;


                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured :" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
            }
        }
        protected void Tb_SearchData_TextChanged(object sender, EventArgs e)
        {
            //if (DD_SearchValue.SelectedItem.Value == "1")
            //{
            //    fill_compaignByCountry();
            //}
            //else if (DD_SearchValue.SelectedItem.Value == "2")
            //{
            //    fill_compaignByJobTitle();
            //}
            //else if (DD_SearchValue.SelectedItem.Value == "3")
            //{
            //    fill_compaignByIndustry();
            //}
            //else  //Revnue
            //{
            //    fill_compaignByRevnue();
            //}

        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            if (DD_SearchValue.SelectedItem.Value == "1")
            {
                string ValidationMsg1 = "";
                if (Tb_SearchData.Text.ToString() == "")
                {



                    ValidationMsg1 += "Please enter SearchData.\\n";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg1.ToString() + "')", true);
                    Tb_SearchData.BorderColor = Color.Red;
                }
                else
                {
                    fill_compaignByCountry();
                    Tb_SearchData.BorderColor = Color.LightGray;
                    Tb_SearchData.Text = "";
                }
               
            }
            else if (DD_SearchValue.SelectedItem.Value == "2")
            {

                string ValidationMsg1 = "";
                if (Tb_SearchData.Text.ToString() == "")
                {



                    ValidationMsg1 += "Please enter SearchData.\\n";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg1.ToString() + "')", true);
                    Tb_SearchData.BorderColor = Color.Red;
                }
                else
                {
                    fill_compaignByJobTitle();
                    Tb_SearchData.BorderColor = Color.LightGray;
                    Tb_SearchData.Text = "";
                }
               
            }
            else if (DD_SearchValue.SelectedItem.Value == "3")
            {
                string ValidationMsg1 = "";
                if (Tb_SearchData.Text.ToString() == "")
                {



                    ValidationMsg1 += "Please enter SearchData.\\n";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg1.ToString() + "')", true);
                    Tb_SearchData.BorderColor = Color.Red;
                }
                else
                {
                    fill_compaignByIndustry();
                    Tb_SearchData.BorderColor = Color.LightGray;
                    Tb_SearchData.Text = "";
                }
               
            }
            else if (DD_SearchValue.SelectedItem.Value == "4")//Revnue
            {
                string ValidationMsg1 = "";
                if (Tb_SearchData.Text.ToString() == "")
                {



                    ValidationMsg1 += "Please enter SearchData.\\n";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg1.ToString() + "')", true);
                    Tb_SearchData.BorderColor = Color.Red;
                }
                else
                {
                    fill_compaignByRevnue();
                    Tb_SearchData.BorderColor = Color.LightGray;
                    Tb_SearchData.Text = "";
                }

               
            }
            else
            {
                Tb_SearchData.BorderColor = Color.LightGray;
                fill_LeadData();
               
            }


        }
    }
}