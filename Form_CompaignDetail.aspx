<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_CompaignDetail.aspx.cs" Inherits="sell2world.Form_CompaignDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%-- <DL:DefaultLinks runat="server" ID="DL_1" />--%>    <%--select 2 start--%>
    <!-- Select2 -->
    <script src="plugins/select2/select2.full.min.js"></script>
    <!-- bootstrap time picker -->

    <!-- Select2 -->
    <link rel="stylesheet" href="plugins/select2/select2.min.css" />
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css"/>
     <%--<script src="jquery.js"></script>
    <script src="plugins/jQueryUI/jquery-ui.js"></>
     <script src="plugins/jquery/jQuery-2.2.0.min.js"></script>
    <script src="plugins/jQueryUI/jquery-ui.min.js"></script>--%>
       <script src="plugins/datepicker/bootstrap-datepicker.js"></script>
    <script type = "text/javascript">

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
    <script type = "text/javascript">




        //$(function () {
        //    //Initialize Select2 Elements
        //    $(".select2").select2();
        //});
        $(function () {
            $('#Dp_CompaignDate').datepicker({
                changeMonth: true,
            changeYear: true,
                dateFormat: 'dd-mm-yy'
            });
        });


        ////Timepicker
        //$('#input_starttime').pickatime({
        //    // 12 or 24 hour
        //    twelvehour: true,
        //});



    </script>
      <style>
        .select2-container--default .select2-selection--single {
            border: 1px solid #d2d6de;
            border-radius: 0px;
            height: 34px;
        }
    </style>

    <style>
        .c-label-right {
            float: right;
            margin-right: 5px;
        }

        .c-col-size-15 {
            width: 15%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-col-size-16 {
            width: 16%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-col-size-23 {
            width: 23%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-col-size-20 {
            width: 20%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-col-size-40 {
            width: 40%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-btn-widht-37 {
            width: 37%;
        }

        .c-col-size-8 {
            width: 8%;
            padding-left: 0px;
            padding-right: 0px;
        }

        .c-height {
            margin: 1%;
            height: 28px;
        }

        .c-btn-height {
            margin: 1%;
            height: 28px;
            padding: 0px;
        }
        /*.c-dd-height {
        height:30px;
        
        }*/
        .c-width-46 {
            width: 46%;
        }

        .c-width-200p {
            width: 200px;
        }

        @media screen and (max-width:992px) {
            .c-col-size-8 {
                width: 8%;
                padding-left: 0px;
                padding-right: 0px;
            }

            .c-col-size-20 {
                width: 100%;
            }

            .c-col-size-40 {
                width: 100%;
            }

            .c-btn-widht-37 {
                width: 70%;
                margin-left: 15%;
                margin-bottom: 2%;
            }

            .c-width-46 {
                width: 100%;
            }
        }
        .form-control {}
        .c-with-shadow {}
    </style>
</head>
<body >
    <form id="form1" runat="server">
        
                        <asp:Label ID="Lbl_Header" runat="server" CssClass="box-title" Text="Add Compaign Detail"></asp:Label>
                   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
         <br />
                                <asp:Label ID="Lbl_CompaignId" runat="server" CssClass="Label" Text="CompaignId"></asp:Label>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_CompaignId" runat="server" CssClass="form-control c-tb-noresize" Width="229px"  
                                        ></asp:TextBox>
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
         <br />
                                    <asp:Label ID="Lbl_CompaignName" runat="server" CssClass="Label" Text="Compaign Name"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                               
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_CompaignName" runat="server" CssClass="form-control c-tb-noresize" placeholder="Compaign Name" Width="223px"></asp:TextBox>
                               
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                                <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         <br />
                               
                                    <asp:Label ID="Lbl_CompaignDate" runat="server" CssClass="Label" Text="CompaignId Date"></asp:Label>
                                
                                    <%--<asp:TextBox ID="Tb_CompaignDate" runat="server" CssClass="form-control c-tb-noresize" placeholder="Last Name" required="required"
                                        oninvalid="this.setCustomValidity('Please enter Last name')" oninput="this.setCustomValidity('')"></asp:TextBox>--%>
                                
                                <%--<div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>--%>
                                            <%--<asp:TextBox runat="server" CssClass="form-control"
                                                ID="Dp_CompaignDate" data-date-format="dd/mm/yyyy" placeholder=" Compaign Date"></asp:TextBox>--%>


                                     <asp:TextBox runat="server" 
                                      ID="Dp_CompaignDate" data-date-format="dd/mm/yyyy"  AutoCompleteType="Disabled" Width="18%" Height="20px" style="margin-left: 61px"></asp:TextBox>
         <br />
                                      
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                        
                                <asp:Label ID="Lbl_JobFunction" CssClass="Label" runat="server" Text="JobFunction"></asp:Label>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_JobFunction" runat="server" CssClass="form-control" placeholder="JobFunction" TextMode="MultiLine" Width="238px"></asp:TextBox>
                          
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         <br />
                       
                                <asp:Label ID="LblCompanySize" CssClass="Label" runat="server" Text="CompanySize"></asp:Label>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_CompanySize" runat="server" CssClass="form-control" placeholder="CompanySize" Width="232px"></asp:TextBox>
                          
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         <br />
                     
                                <asp:Label ID="lblIndustry" CssClass="Label" runat="server" Text="Industry"></asp:Label>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_Industry" runat="server" CssClass="form-control" placeholder="Industry" Height="23px" Width="227px"></asp:TextBox>
                               
                                &nbsp;<%--<asp:DropDownList ID="DD_City" runat="server" CssClass="form-control select2 "
                                        DataTextField="City" DataValueField="City_Id" style="width:100%"></asp:DropDownList>--%><br />
         <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                          
                                    <asp:Label ID="lblCountry" CssClass="Label" runat="server" Text="Country"></asp:Label>
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_Country" runat="server" CssClass="form-control" placeholder="Country" Height="23px" Width="209px"></asp:TextBox>
                               
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
        <br />

                      
                                <asp:Label ID="LblCustomQuestion" CssClass="Label" runat="server" Text="CustomQuestion"></asp:Label>
                           
                            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Tb_CustomQuestion" runat="server" CssClass="form-control" placeholder="CustomQuestion" TextMode="MultiLine" Height="48px" Width="247px"></asp:TextBox>
                               
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                           
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         <br />
                          &nbsp;&nbsp;<asp:Button ID="Btn_new" runat="server" Text="new" CssClass="btn btn-primary bg-purple c-bg-blueish btn-block  btn-flat c-with-shadow" OnClick="Btn_new_Click" Width="79px" />
                                
                              
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_Save" runat="server" Text="Save" CssClass="btn btn-primary bg-purple c-bg-blueish btn-block  btn-flat c-with-shadow" OnClick="Btn_Save_Click" Width="81px" />
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_view" runat="server" Text="view" CssClass="btn btn-primary bg-purple c-bg-blueish btn-block  btn-flat c-with-shadow" OnClick="Btn_view_Click" Width="75px" />
                              
                            
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_Update" runat="server" Text="Update" CssClass="btn btn-primary bg-purple c-bg-blueish btn-block  btn-flat c-with-shadow" formnovalidate="" OnClick="Btn_Update_Click" Width="84px" />
                                      &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_delete" runat="server" Text="Delete" CssClass="btn btn-primary bg-purple c-bg-blueish btn-block  btn-flat c-with-shadow" formnovalidate="" OnClick="Btn_delete_Click"  Visible
                                        ="false"/>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        <br />
&nbsp;<asp:GridView ID="GridView1" runat="server" Width="916px" style="margin-left: 0px">
        </asp:GridView>
        <br />
                              
                            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                                
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                                
                              
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                                 
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
        </form>
</body>
</html>
