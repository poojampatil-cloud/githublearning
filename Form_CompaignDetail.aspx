<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_CompaignDetail.aspx.cs" Inherits="compaings2w.Form_CompaignDetail" %>

<%@ Register Src="~/User Control/Header.ascx" TagName="Header" TagPrefix="HD" %>
<%@ Register Src="~/User Control/DefaultLinks.ascx" TagName="DefaultLinks" TagPrefix="DL" %>

<%@ Register Src="~/User Control/Footer.ascx" TagName="Footer" TagPrefix="FT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <DL:DefaultLinks runat="server" ID="DL_1" />
   
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />

    <link rel="stylesheet" href="plugins/datatables/dataTables.bootstrap.css" />
    <script src="plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="plugins/datepicker/bootstrap-datepicker.js"></script>

     

    <script type="text/javascript">

        ///////////////////using jquery///////////////////////////
        //$(document).ready(function () {
        //    var Age1 = "";
        //    $('#Dp_CompaignDate').datepicker({
        //        onSelect: function (value, ui)
        //       // onSelect: function (value, datepicker)
        //        {
        //            var today = new Date();
        //            Age1 = today.getFullYear() - ui.selectedYear;          
        //            $('#Age').val(Age1);
        //        },
        //        changeMonth: true,
        //        changeYear: true,

        //    })
        //})

        //////////////////using datepicker//////////////////////////////////

        //$(document).ready(function () {
        //    var Age1 = "";
        //    var dob = $(this).datepicker('getDate');
        //    $('#Dp_CompaignDate').datepicker( {
        //        onSelect: function (value, dob)

        //        {
        //            var today = new Date();

        //            Age1 = today.getFullYear() - dob.selectedYear;

        //            $('#Age').val(Age1);
        //        },
        //        changeMonth: true,
        //        changeYear: true,

        //    })
        //})


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Dp_CompaignDate').datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy'
            });
        })

    </script>
       
    <script type="text/javascript">

        $(document).ready(function () {
            $('#Gv_CompaignDetail').dataTable({
                "bLengthChange": true,
                "paging": true,
                "sPaginationType": "full_numbers",                    
                // "scrollY": 400,                                     // For Scrolling
                "jQueryUI": true,                                      
                //"aaSorting":[[2,"desc"]]                               //To sort by created date column
                "aaSorting": [],
                //"dom": '<"top"flp>rt<"bottom"i><"clear">',
                "lengthMenu": [[5, 10, 25, 50, 100, 200, -1], [5, 10, 25, 50, 100, 200, "All"]]
                //"bFilter": false

            });

            $('div.dataTables_filter input').addClass('form-control');
            $('div.dataTables_length select').addClass('form-control');
        });

        </script>





        <style>
        #Gv_CompaignDetail_filter {
            /*width: 20%;*/
            float: right;
            padding-top: 7px;
            text-align: left;
            padding-left: 10px;
        }

        #Gv_CompaignDetail_length {
            /* width: 13%; */
            float: left;
            padding-top: 7px;
            /* margin-left: 7%; */
        }

        #Gv_CompaignDetail_paginate {
            /*width:60%;*/
            float: right;
        }
        
      
        .c-btn-addnew {
            width: 15.5%;
            float: right;
            padding-right: 16px;
        }

       

        @media screen and (max-width:900px) {
            #Gv_CompaignDetail_length {
                width: 100%;
                float: left;
                padding-top: 7px;
                text-align: left;
                padding-left: 10px;
            }

            #Gv_CompaignDetail_paginate {
                width: 100%;
                text-align: left;
                padding-left: 10px;
            }
        }


        /*latest css*/

        .container-of-inputbox{   
            border-top: 1px solid #f1efef;
            border-bottom: 1px solid #f1efef;
            padding: 4%;
        }
        .input-width{
            width:264px;
        }
        .nav-login-sty{
            float: right;
            margin-right: 21%;
        }
        .logo-sty{
            margin-left: 176%;
        }
        .align-input{
            display:flex;
        }
        .align-footer{
            padding: 10px 0;
        }
        .footer-lbl-color{
            color: gray;
        }
        .lbl-sty{
            width: 30%;
        }
        .btn-width{
            padding-left: 12%;
        }
            .input-group.date.calenderwidth {
                width: 65%;
            }

            .navbar-default {
                background-color: #759be8;
                border-color: #e7e7e7;
            }

                .navbar-default .navbar-nav > li > a {
                    color: #fff;
                }

                .navbar-default .navbar-brand {
                    color: #fff;
                }

                .lbl-sty-textarea{
                    width :30%;
                }
                .lbl-sty-textarea
                {

                    height: 97px;
                    /*width: 50%;*/
                    width:17%;

                }
    </style>
    
</head>
    

<body >
    <form id="form1" runat="server">
       
            <hd:header runat="server" ID="HD_1" />

       <%-- <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Sell2World</a>
                </div>
                <ul class="nav navbar-nav">
                    <li class="active"><a href="Home.aspx">Home</a></li>
                    <li><a href="form_login.aspx">login</a></li>
                    <li><a href="form_UserNewRegistration.aspx">UserNewRegistration</a></li>

                </ul>
            </div>
        </nav>--%>

          <div class=" col-md-12 Container">
            <div class="col-md-2"></div>
            <div class="col-md-8">               
                 <h2>Add Compaign Detail</h2>  
                <div class="container-of-inputbox">
                    <div class="col-md-6">
                        <div class="form-group align-input">
                            <asp:Label ID="Lbl_CompaignId" runat="server" class="lbl-sty" Text="CompaignId*"></asp:Label>
                            <asp:TextBox ID="Tb_CompaignId" runat="server" CssClass="form-control input-width"></asp:TextBox>
                        </div>

                        <%--<div class="form-group align-input">

                            <div class="col-md-12 c-inline-space">
                                <div class="col-md-2 c-col-size-14 c-label-1">
                                    <asp:Label ID="Label1" runat="server" class="lbl-sty" Text="CompaignId Date"></asp:Label>

                                </div>
                                <div class="col-md-10 no-padding c-col-size-86">
                                    <div class="col-md-4 c-col-size-40">
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>

                                            <asp:TextBox runat="server" CssClass="form-control input-width"
                                                ID="Dp_CompaignDate" data-date-format="dd/mm/yyyy" placeholder="Compaign Date"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4 c-col-size-20 c-label-1 c-padding-left-1">
                                        <asp:Label ID="Lbl_JobFunction" class="lbl-sty" runat="server" Text="JobFunction"></asp:Label>
                                    </div>
                                    <div class="col-md-4 c-col-size-40">
                                        <asp:TextBox ID="Tb_JobFunction" runat="server" CssClass="form-control input-width" placeholder="JobFunction" TextMode="MultiLine" Width="375px"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>--%>
                         <div class="form-group align-input">
                                <asp:Label ID="Label1" runat="server" class="lbl-sty" Text="CompaignId Date"></asp:Label>

                           <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>

                                            <asp:TextBox runat="server" CssClass="form-control input-width"
                                                ID="Dp_CompaignDate" data-date-format="dd/mm/yyyy" placeholder="Compaign Date"></asp:TextBox>
                                        </div>
                        </div>
                        
                         <div class="form-group align-input">

                            <asp:Label ID="Label8" CssClass="Label" runat="server" Text="Working Status"></asp:Label>
                            <asp:DropDownList ID="DD_EmployeeStatus" runat="server" class="form-control">
                                <asp:ListItem Value="0">Pause</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                <asp:ListItem Value="2">Completed</asp:ListItem>
                            </asp:DropDownList>

                        </div>

                    

                     </div> 
                       <div class="col-md-6">

                        <div class="form-group align-input">
                            <asp:Label ID="Label2" runat="server" class="lbl-sty" Text="Compaign Name*"></asp:Label>
                            <asp:TextBox ID="Tb_CompaignName" runat="server" CssClass="form-control input-width" placeholder="Compaign Name"></asp:TextBox>
                        </div>
                        <div class="form-group align-input">
                            <%--<asp:Label ID="LblCompanySize" runat="server" class="lbl-sty" Text="CompanySize*"></asp:Label>
                             <asp:TextBox ID="txt_CompanySize" runat="server" CssClass="form-control txt-style-inputarea" placeholder="CompanySize" TextMode="MultiLine"></asp:TextBox>
                            <asp:FileUpload ID="Fu_CompanySize" runat="server" CssClass="form-control input-width " />--%>

                             <asp:Label ID="Label3" runat="server" class="lbl-sty" Text="ClientId"></asp:Label>
                               <asp:TextBox ID="Tb_ClientId" runat="server" CssClass="form-control input-width" placeholder="ClientId" ></asp:TextBox>
                        </div>

                            <div class="form-group align-input">
                            
                             <asp:Label ID="Label4" runat="server" class="lbl-sty" Text="Country"></asp:Label>
                               <asp:TextBox ID="Tb_Country" runat="server" CssClass="form-control input-width" placeholder="Country" ></asp:TextBox>
                           
                        </div>


                        </div>
                        
                                   
                    </div>
                   
                      <div class="col-md-12">
                            <div class="form-group align-input">
                                <asp:Label ID="lblIndustry" runat="server" class="lbl-sty" Text="Industry*"></asp:Label>
                           
                               <asp:TextBox ID="txt_Industry" runat="server" CssClass="form-control txt-style-inputarea" placeholder="Industry" TextMode="MultiLine"></asp:TextBox>
                              
                               <asp:FileUpload ID="Fu_Industry" runat="server" CssClass="form-control input-width" />

                                 <asp:Label ID="lblMessage" runat="server" class="lbl-sty"></asp:Label>
                                </div> 
                             <div class="form-group align-input">

                              </div>
                                
                        </div>

                    <div class="col-md-12">
                            <div class="form-group align-input">
                          <asp:Label ID="LblCompanySize" runat="server" class="lbl-sty" Text="CompanySize*"></asp:Label>
                           
                                <asp:TextBox ID="txt_CompanySize" runat="server" CssClass="form-control txt-style-inputarea" placeholder="CompanySize" TextMode="MultiLine"></asp:TextBox>
                                <asp:FileUpload ID="Fu_CompanySize" runat="server" CssClass="form-control input-width " />
                            </div>
                         <div class="form-group align-input">
                                      
                              </div>  
                        </div>
                    

                  
                     <div class="col-md-12">
                         
                        <div class="form-group align-input">
                            <asp:Label ID="LblCustomQuestion" runat="server" class="lbl-sty-textarea" Text="CustomQuestion"></asp:Label>
                            <asp:TextBox ID="Tb_CustomQuestion" runat="server" CssClass="form-control txt-style-inputarea" placeholder="CustomQuestion" TextMode="MultiLine"></asp:TextBox>
                        </div>
                              
                     <div class="form-group align-input">
                            <asp:Label ID="Lbl_JobFunction" class="lbl-sty-textarea" runat="server" Text="JobFunction"></asp:Label>
                             <asp:TextBox ID="Tb_JobFunction" runat="server" CssClass="form-control txt-style-inputarea" placeholder="JobFunction" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>


               <asp:Panel ID="pnl_save" runat="server">
                  
                    <div class="col-md-12">
                      <div class="col-md-2">
                          </div> 
                        <div class="col-md-10">
                            <div class="col-md-6">
                                <div class="col-md-4 c-btn-widht-25">
                                    <asp:Button ID="Btn_new" runat="server" Text="New" class="btn btn-secondary" OnClick="Btn_new_Click" OnClientClick="return ValidateDates();" />
                                </div>
                                <div class="col-md-4 c-btn-widht-25">
                                    <asp:Button ID="Btn_Save" runat="server" Text="Save" class="btn btn-secondary" formnovalidate="" OnClick="Btn_Save_Click" />
                                </div>
                                <div class="col-md-4 c-btn-widht-25">
                                    <asp:Button ID="Btn_view" runat="server" Text="View" class="btn btn-secondary" formnovalidate="" OnClick="Btn_view_Click" />
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="col-md-4 c-btn-widht-25">
                                    <asp:Button ID="Btn_Update" runat="server" Text="Update" class="btn btn-secondary" formnovalidate="" OnClick="Btn_Update_Click" />
                                </div>

                                <div class="col-md-4 c-btn-widht-25">
                                    <asp:Button ID="Btn_cancel" runat="server" Text="Cancel" class="btn btn-secondary" formnovalidate="" OnClick="Btn_cancel_Click" />
                                </div>
                                <div class="col-md-4 c-btn-widht-25">
                                   
                                </div>
                            </div>
                      </div> 
                    </div>
               </asp:Panel>
                                
                        <div class="col-md-12 ">
                            <div class="table-responsive no-padding c-">
                                <div>

                                    <table class="table" id="Gv_CompaignDetail">
                                        <thead>
                                            <tr class="c-grid-header">
                                                <th>CompaignId</th>
                                                <th>CompaignName</th>
                                                <th>ClientId</th>

                                                <th>Status</th>
                                                <th>CreatedDate</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tlist" runat="server"></tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
            </div>
           <div class="col-md-2"></div>
            </div> 
            <%--content end--%>

      <FT:Footer runat="server" ID="FT_1" />      
    </form>
</body>
</html>
