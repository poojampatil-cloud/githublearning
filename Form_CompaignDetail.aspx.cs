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
    public partial class Form_CompaignDetail : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        string ClientId = "";
        int ClientStatus_Id = 1;
        int CompaignId = 0;
        string CompaignName = "";

        string CompaignDate ="";
        String FuCompanySizeFileText = "";
        string FuIndustryFileNameText = "";
        string JobFunction="";
        string UserName = "";
        int EmployeeId = 0;
        string Country = "";
        string CustomeQuestion = "";
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

                }

                Btn_Save.Visible = false;
                Btn_Update.Visible = false;
                Btn_cancel.Visible =false;
                // GetNextCompaignId();
                fill_compaign();
            }
           
        }
        private void fill_compaign()
        {
            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            // cmd.CommandText = "select CompaignId , CompaignName,CompaignDate,JobFunction,CompanySize,Industry, Country, CustomeQuestion from Tbl_CompaignDetail";
            cmd.CommandText = "select CompaignId ,CompaignName,ClientStatus,ClientId,CreatedDate,CompaignDate,JobFunction, Country,FuCompanySizeFileName,FuIndustryFileName,CustomeQuestion from Tbl_CompaignDetail";
            //cmd.Connection = con;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
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
                    //  UnreadText += "     <td class=\"c-grid-col-size-50\"><input id=CbSelectStudent_\"" + dr["StudentId"].ToString() + "\" type=\"checkbox\" onclick=CheckUncheck(\"" + dr["StudentId"].ToString() + "\") name=\"CbSelectStudent_" + dr["StudentId"].ToString() + "\" > <input type=\"hidden\" name=\"HfStudentId_" + dr["StudentId"].ToString() + "\" id=\"HfStudentId_" + dr["StudentId"].ToString() + "\" value=\"" + dr["StudentId"].ToString() + "\"></td>";
                    //UnreadText += "     <td class=\"c-grid-col-size-275\"><div><span class=\"c-grid-label-3\">" + dr["FullName"].ToString() + "</span></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"></div><div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"><span>[M]</span></div> <div class=\"col-md-10 c-col-size-86 no-padding c-padding-left-1\"> <span>" + dr["MobileNumber"].ToString() + " </span></div></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"><span>[E]</span></div> <div class=\"col-md-10 c-col-size-86 no-padding c-padding-left-1\"> <span>" + dr["EmailId"].ToString() + " </span></div></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"></div></div> </td>";
                    // UnreadText += "<td class=\"c-grid-col-size-275\"><div><span><a  class=\"c-grid-label-3\" href=\"Form_StudentRegistration.aspx?ID=" + encrypt(dr["StudentId"].ToString()) + "&Call=" + encrypt("2") + "\">" + dr["FullName"].ToString() + "</a></span></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"></div><div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"><span>[M]</span></div> <div class=\"col-md-10 c-col-size-86 no-padding c-padding-left-1\"> <span>" + dr["MobileNumber"].ToString() + " </span></div></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"><span>[E]</span></div> <div class=\"col-md-10 c-col-size-86 no-padding c-padding-left-1\"> <span>" + dr["EmailId"].ToString() + " </span></div></div> <div class=\"col-md-12 no-padding c-inline-space\"> <div class=\"col-md-2 c-col-size-14 no-padding\"></div></div> </td>";

                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignId"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["CompaignName"].ToString() + "</span></div></td>";
                   
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientId"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-center\"><span>" + dr["ClientStatus"].ToString() + "</span></div></td>";
                    UnreadText += "     <td class=\"c-grid-col-size-100\"><div class=\"c-grid-label-left\"><span>" + Convert.ToDateTime(dr["CreatedDate"]).ToString("dd/MM/yyyy") + "</span></div></td>";

                    //DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DueDate"]);

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


        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int Go = 1;
            Go = ValidateData();
            if (Go == 1)
            {

                string folderPath = Server.MapPath("~/IndustryProfile1");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists("~/IndustryProfile1"))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory("folderPath");
                   // Directory.CreateDirectory("~/IndustryProfile1");
                }

                //Save the File to the Directory (Folder).
                Fu_Industry.SaveAs(folderPath + Path.GetFileName(Fu_Industry.FileName));

                //Display the success message.
                lblMessage.Text = Path.GetFileName(Fu_Industry.FileName) + " has been uploaded.";




                Btn_Update.Visible = true;
                Btn_view.Visible = true;
                string FuCompanySizeFileName, FuCompanySizeFilePath = "", FuIndustryFileName, FuIndustryFilePath = "";



                FuIndustryFileName = Path.GetFileName(Fu_Industry.PostedFile.FileName);


                if (FuIndustryFileName != "")
                {
                    FuIndustryFilePath = "IndustryProfile/" + CompaignId.ToString() + "_" + FuIndustryFileName;
                    // FuIndustryFilePath = "IndustryProfile/" + FuIndustryFileName;
                    Fu_Industry.SaveAs(Server.MapPath("IndustryProfile/" + CompaignId.ToString() + "_" + FuIndustryFileName));
                }
                else
                {
                    FuCompanySizeFilePath = " ";
                }









                //if (Fu_CompanySize.HasFile == true)
                //{
                FuCompanySizeFileName = Path.GetFileName(Fu_CompanySize.PostedFile.FileName);
                //}


      
                if (FuCompanySizeFileName != "")
                {
                   // File_Path = "CompaignProfile/" + CompaignId.ToString() + "_" + File_Name;
                          

                    FuCompanySizeFilePath = "CompanyProfile/" + FuCompanySizeFileName;
                    Fu_CompanySize.SaveAs(Server.MapPath("CompanyProfile/" + CompaignId.ToString() + "_" + FuCompanySizeFileName));
                }
                else
                {
                    FuCompanySizeFilePath = " ";
                }


               
                

                    
                ClientId =(Tb_ClientId.Text.ToString());

                ClientStatus_Id = Convert.ToInt32(DD_EmployeeStatus.SelectedValue.ToString());

                CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
                CompaignName = (Tb_CompaignName.Text.ToString());
                CompaignDate = (Dp_CompaignDate.Text.ToString());
                JobFunction = (Tb_JobFunction.Text.ToString());

                FuCompanySizeFileText = (txt_CompanySize.Text.ToString());
                FuIndustryFileNameText = (txt_Industry.Text.ToString());
                Country = (Tb_Country.Text.ToString());
                CustomeQuestion = (Tb_CustomQuestion.Text.ToString());



                cmd.Parameters.Clear();


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

                cmd.Parameters.AddWithValue("@ClientId", ClientId);
                cmd.Parameters.AddWithValue("@ClientStatus", ClientStatus_Id);
                cmd.Parameters.AddWithValue("@Country", Country);
                cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);

                cmd.Parameters.AddWithValue("@CreatedDate", CurrentUtc_IND);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                cmd.Parameters.AddWithValue("@TouchedWhen", DBNull.Value);
                cmd.Parameters.AddWithValue("@TouchedBy", DBNull.Value);
                cmd.Parameters.AddWithValue("@FuCompanySizeFileText",FuCompanySizeFileText);
                cmd.Parameters.AddWithValue("@FuIndustryFileNameText",FuIndustryFileNameText);


                if (FuCompanySizeFileName !=null)
                {
                    cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                    cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);
                    //cmd.Parameters.AddWithValue("@Companysize", Companysize);
                    //cmd.Parameters.AddWithValue("@Industry", Industry);
                }
                else
                {
                    string FuCompanySizeFileName1 = null;
                    string FuCompanySizeFilePath1 = null;
                    cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName1);
                    cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath1);
                }



               


                if (FuIndustryFileName !=null)
                {
                    cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                    cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);
                    //cmd.Parameters.AddWithValue("@Companysize", Companysize);
                    //cmd.Parameters.AddWithValue("@Industry", Industry);
                }
                else
                {
                   string FuIndustryFileName1 =null;
                    string FuIndustryFilePath1 = null;
                    cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName1);
                    cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath1);

                }


                //cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
               

                cmd.Parameters.AddWithValue("@selecttype", "insert");
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('save succesfully'", true);
                cleardata();
                fill_compaign();


            //    string File_Name = "", File_Path = "";

               
            //    if (Fu_CompanySize.HasFile == true)
            //    {
            //        File_Name = Path.GetFileName(Fu_CompanySize.PostedFile.FileName);
            //    }
               
            //    if (File_Name != "")
            //    {
            //        File_Path = "CompaignProfile/" + CompaignId.ToString() + "_" + File_Name;
            //        Fu_CompanySize.SaveAs(Server.MapPath("CompaignProfile/" + CompaignId.ToString() + "_" + File_Name));


            //        cmd.Parameters.AddWithValue("@FuCompanySizeFileName", File_Name);
            //        cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", File_Path);
            //    }
            
            //else
            //{
            //    File_Path = "";
            //}

               //string File_Name1 = "", File_Path1 = "";
               // if (Fu_Industry.HasFile == true)
               // {
               //     File_Name1 = Path.GetFileName(Fu_Industry.PostedFile.File_Name1);
               // }

               // if (File_Name1 != "")
               // {
               //     File_Path1 = "CompaignProfile/" + CompaignId.ToString() + "_" + File_Name1;
               //     Fu_Industry.SaveAs(Server.MapPath("CompaignProfile/" + CompaignId.ToString() + "_" + File_Name1));


               //     cmd.Parameters.AddWithValue("@FuIndustryFileName ", File_Name1);
               //     cmd.Parameters.AddWithValue("@FuIndustryFilePath", File_Path1);

               // }
        
               // else
               // {
               //     File_Path1 = "";
               // }
               

            }
        }

        private void cleardata()
        {
            Tb_CompaignName.Text = "";
            Dp_CompaignDate.Text = "";
            Tb_JobFunction.Text = "";

            Tb_CompaignId.Text = "";
            //Tb_CompanySize.Text = "";
            //Fu_Industry.Text ="";
            Tb_Country.Text = "";
            Tb_CustomQuestion.Text = "";


        }


        protected void Btn_delete_Click(object sender, EventArgs e)
        {

            string FuCompanySizeFileName, FuCompanySizeFilePath = "", FuIndustryFileName, FuIndustryFilePath = "";
            FuCompanySizeFileName = Path.GetFileName(Fu_CompanySize.PostedFile.FileName);
            FuCompanySizeFilePath = "CompanyProfile/" + FuCompanySizeFileName;


            FuIndustryFileName = Path.GetFileName(Fu_Industry.PostedFile.FileName);
            FuIndustryFilePath = "IndustryProfile/" + FuIndustryFileName;


            CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
            CompaignName = (Tb_CompaignName.Text.ToString());
            CompaignDate = (Dp_CompaignDate.Text.ToString());
            JobFunction = (Tb_JobFunction.Text.ToString());

            //CompanySize = (Tb_CompanySize.Text.ToString());
            //Industry = (Fu_Industry.Text.ToString());
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
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

            cmd.Parameters.AddWithValue("@CreatedDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);

            cmd.Parameters.AddWithValue("@TouchedBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@TouchedWhen", DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime(CompaignDate));
           


            cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
            cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);
            cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
            cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);




            cmd.Parameters.AddWithValue("@selecttype", "delete");
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('delete succesfully'", true);
            cleardata();
            fill_compaign();



        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            Btn_Save.Visible = true;
            Btn_new.Visible = true;

            string FuCompanySizeFileName, FuCompanySizeFilePath = "", FuIndustryFileName, FuIndustryFilePath = "";


            
            FuCompanySizeFileName = Path.GetFileName(Fu_CompanySize.PostedFile.FileName);




            if (FuCompanySizeFileName != "")
            {


                FuCompanySizeFilePath = "CompanyProfile/" + FuCompanySizeFileName;
                Fu_CompanySize.SaveAs(Server.MapPath("CompanyProfile/" + CompaignId.ToString() + "_" + FuCompanySizeFileName));

                
            }
            else
            {
                FuCompanySizeFilePath = " ";
            }


            FuIndustryFileName = Path.GetFileName(Fu_Industry.PostedFile.FileName);
          
            if (FuIndustryFileName != "")
            {
                FuIndustryFilePath = "IndustryProfile/" + FuIndustryFileName;
                Fu_Industry.SaveAs(Server.MapPath("IndustryProfile/" + CompaignId.ToString() + "_" + FuIndustryFileName));

               

            }
            else
            {
                FuIndustryFilePath = " ";
            }

            CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString());
            CompaignName = (Tb_CompaignName.Text.ToString());
            CompaignDate = (Dp_CompaignDate.Text.ToString());
            JobFunction = (Tb_JobFunction.Text.ToString());

            FuCompanySizeFileText = (txt_CompanySize.Text.ToString());
            FuIndustryFileNameText = (txt_Industry.Text.ToString());
            Country = (Tb_Country.Text.ToString());
            CustomeQuestion = (Tb_CustomQuestion.Text.ToString());


            con.ConnectionString = str;
            con.Open();
            cmd = new SqlCommand();
            //cmd.CommandText = "USP_CompaignDetail";
            cmd.CommandText = "USP_CompaignDetailUpdate";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
            cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
            cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime( CompaignDate));
            //cmd.Parameters.AddWithValue("@CompaignDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobFunction", JobFunction);


            cmd.Parameters.AddWithValue("@CreatedDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
            
            cmd.Parameters.AddWithValue("@TouchedBy", UserName);
            cmd.Parameters.AddWithValue("@TouchedWhen",CurrentUtc_IND);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);
            cmd.Parameters.AddWithValue("@FuCompanySizeFileText",FuCompanySizeFileText);
            cmd.Parameters.AddWithValue("@FuIndustryFileNameText",FuIndustryFileNameText);


            if (FuCompanySizeFileName != "")
            {


                FuCompanySizeFilePath = "CompanyProfile/" + FuCompanySizeFileName;
                Fu_CompanySize.SaveAs(Server.MapPath("CompanyProfile/" + CompaignId.ToString() + "_" + FuCompanySizeFileName));


                cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);

                cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);

                cmd.Parameters.AddWithValue("@selecttype", "update1");
            }







            else if (FuIndustryFileName != "")
            {
                FuIndustryFilePath = "IndustryProfile/" + FuIndustryFileName;
                Fu_Industry.SaveAs(Server.MapPath("IndustryProfile/" + CompaignId.ToString() + "_" + FuIndustryFileName));

                cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);


                cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);
                cmd.Parameters.AddWithValue("@selecttype", "update2");
            }

             else if(FuCompanySizeFileName != "" && FuIndustryFileName != "")
            {
                cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);


                cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);
                cmd.Parameters.AddWithValue("@selecttype", "update3");
            }
            else
            {


                cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", FuCompanySizeFilePath);


                cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                cmd.Parameters.AddWithValue("@FuIndustryFilePath", FuIndustryFilePath);
                cmd.Parameters.AddWithValue("@selecttype", "update4");


            }
            //cmd.Parameters.AddWithValue("@selecttype", "update");
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('update succesfully'", true);
            cleardata();
            fill_compaign();

            

        }

        protected void Btn_new_Click(object sender, EventArgs e)
        {
            Btn_Save.Visible = true;
            Btn_Update.Visible= false;
            Btn_view.Visible= false;
            Btn_cancel.Visible = true;
            cleardata();
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
            Tb_CompaignName.Enabled=false;
            Dp_CompaignDate.Enabled = false;
            Tb_JobFunction.Enabled = false;

            txt_CompanySize.Enabled = false;
            txt_Industry.Enabled = false;
            Tb_ClientId.Enabled = false;
            Tb_Country.Enabled = false;
            Tb_CustomQuestion.Enabled = false;
            DD_EmployeeStatus.Enabled = false;
            Btn_Save.Visible = false;
            Btn_new.Visible = false;
            Btn_cancel.Visible = true;
            Btn_Update.Visible = true;

            string ValidationMsg1 = "";
            if (Tb_CompaignId.Text.ToString() == "")
            {



                ValidationMsg1 += "Please enter CompaignId.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg1.ToString() + "')", true);
                Tb_CompaignId.BorderColor = Color.Red;
            }
            else
            {

                Compaignfill(CompaignId = Convert.ToInt32(Tb_CompaignId.Text.ToString()));
            }
        }
        private void Compaignfill(int CompaignId)
        {
            try
            {

                Tb_CompaignName.Enabled = true;
                Dp_CompaignDate.Enabled = true;
                Tb_JobFunction.Enabled = true;

                txt_CompanySize.Enabled = true;
                txt_Industry.Enabled = true;
                Tb_ClientId.Enabled = true;
                Tb_Country.Enabled = true;
                Tb_CustomQuestion.Enabled = true;
                DD_EmployeeStatus.Enabled = true;





                string FuCompanySizeFileName, FuCompanySizeFilePath = "", FuIndustryFileName, FuIndustryFilePath = "";
                FuCompanySizeFileName = Path.GetFileName(Fu_CompanySize.PostedFile.FileName);
                FuCompanySizeFilePath = "StudentProfile/" + FuCompanySizeFileName;


                FuIndustryFileName = Path.GetFileName(Fu_Industry.PostedFile.FileName);
                FuIndustryFilePath = "EmployeeProfile/" + FuIndustryFileName;

               
                con.ConnectionString = str;
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "USP_CompaignDetail";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompaignId", CompaignId);
                cmd.Parameters.AddWithValue("@CompaignName", CompaignName);
                // cmd.Parameters.AddWithValue("@CompaignDate", Convert.ToDateTime(Dp_CompaignDate.Text.ToString()));
                cmd.Parameters.AddWithValue("@JobFunction", JobFunction);

                cmd.Parameters.AddWithValue("@CompaignDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);

                cmd.Parameters.AddWithValue("@TouchedBy", DBNull.Value);
                cmd.Parameters.AddWithValue("@TouchedWhen", DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", Country);
                cmd.Parameters.AddWithValue("@CustomeQuestion", CustomeQuestion);


                cmd.Parameters.AddWithValue("@FuCompanySizeFileName", FuCompanySizeFileName);
                cmd.Parameters.AddWithValue("@FuCompanySizeFilePath", DBNull.Value);
                cmd.Parameters.AddWithValue("@FuIndustryFileName ", FuIndustryFileName);
                cmd.Parameters.AddWithValue("@FuIndustryFilePath", DBNull.Value);
                cmd.Parameters.AddWithValue("@FuCompanySizeFileText",FuCompanySizeFileText);
                cmd.Parameters.AddWithValue("@FuIndustryFileNameText",FuIndustryFileNameText);


                cmd.Parameters.AddWithValue("@selecttype", "select");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    
                    Tb_CompaignName.Text = dr["CompaignName"].ToString();
                    Dp_CompaignDate.Text = dr["CompaignDate"].ToString();
                    Tb_JobFunction.Text = dr["JobFunction"].ToString();
                    //Fu_CompanySize.PostedFile.FileName= dr["JobFunction"].ToString();
                    //Fu_CompanySize.text = dr["JobFunction"].ToString();
                    txt_CompanySize.Text = dr["FuCompanySizeFileText"].ToString();
                    txt_Industry.Text = dr["FuIndustryFileNameText"].ToString();
                    Tb_ClientId.Text = dr["ClientId"].ToString();
                    Tb_Country.Text = dr["Country"].ToString();
                    Tb_CustomQuestion.Text = dr["CustomeQuestion"].ToString();
                }
                dr.NextResult();
                dr.Close();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('fill grid'+ ex.message.tostring() +", true);
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
        private int ValidateData()
        {
            int Go = 1;
            string ValidationMsg = "";
            if (Tb_CompaignName.Text.ToString() == "")
            {


                Go = 0;
                ValidationMsg += "Please enter CompaignName.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
                Tb_CompaignName.BorderColor = Color.Red;
            }
            else
            {
                Tb_CompaignName.BorderColor = Color.LightGray;
            }

            if (Tb_JobFunction.Text.ToString() == "")
            {
                //Go = 0;
                ValidationMsg += "Please enter job function.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
                Tb_JobFunction.BorderColor = Color.Red;
            }
            else
            {
                Tb_JobFunction.BorderColor = Color.LightGray;
            }



            if (Dp_CompaignDate.Text.ToString() == "")
            {
                //Go = 0;
                ValidationMsg += "Please enter CompaignDate.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
                Dp_CompaignDate.BorderColor = Color.Red;
            }
            else
            {
                Dp_CompaignDate.BorderColor = Color.LightGray;
            }

            if (Tb_Country.Text.ToString() == "")
            {
                //Go = 0;
                ValidationMsg += "Please enter Country Name.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
                Tb_Country.BorderColor = Color.Red;
            }
            else
            {
                Tb_Country.BorderColor = Color.LightGray;
            }

            if (Tb_ClientId.Text.ToString() == "")
            {
                //Go = 0;
                ValidationMsg += "Please enter ClientId.\\n";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
                Tb_ClientId.BorderColor = Color.Red;
            }
            else
            {
                Tb_ClientId.BorderColor = Color.LightGray;
            }
            if (Go == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Validation :\\n" + ValidationMsg.ToString() + "')", true);
            }
            return Go;
        }

           

protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Tb_CompaignId.Text = "";
            Btn_Save.Visible = false;
            Btn_new.Visible = true;
            Btn_Update.Visible = false;
            Btn_view.Visible = true;
        }
    }
}