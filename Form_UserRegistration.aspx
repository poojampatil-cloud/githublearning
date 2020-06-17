<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_UserRegistration.aspx.cs" Inherits="Sell2W.Form_UserRegistration" %>


<%--<<%@ Register Src="~/User Control/DefaultLinks.ascx" TagName="DefaultLinks" TagPrefix="DL" %>
<%@ Register Src="~/User Control/Header.ascx" TagName="Header" TagPrefix="HD" %>
<%@ Register Src="~/User Control/MenuNavigation.ascx" TagName="MenuNavigation" TagPrefix="MNU" %>--%><%--<%@ Register Src="~/App_Data/User Control/Footer.ascx" TagName="Footer" TagPrefix="FT" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> <script>
        
    </script>

    <script type="text/javascript">
        

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
    </style>

    <%--again add select2 to dropdown class--%>    <%--select 2 end--%>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label1" runat="server" Text="EmployeeId"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtemployeeid" runat="server"></asp:TextBox>
        &nbsp;
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="EmployeeName"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtemployeenm" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Set Password"></asp:Label>
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtPssword" runat="server" TextMode="Password"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnSave" runat="server" OnClick="Btn_Save_Click" Text="Save" Width="113px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>

</body>
</html>
