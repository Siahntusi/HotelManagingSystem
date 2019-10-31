<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_StudentBookings.aspx.cs" Inherits="AAFS.Acc_StudentBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        td {
            text-align: left;
        }

        #content {
            margin: 15px auto;
            text-align: center;
            width: 850px;
            position: relative;
            height: 100%;
            top: 0px;
            left: 0px;
        }

        #wrapper {
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 2px solid #fff;
            background-color: #f9f9f9;
            width: 850px;
            overflow: hidden;
        }
    </style>

    <div id="content" class="padding50">
        <h1></h1>

        <div id="wrapper">
            <legend>
                <h1>Accommodations Bookings</h1>
            </legend>

            <%--<div id="SelectUsr" style="width:50%; margin-left:0;margin-right:0;text-align:center">
                <asp:DropDownList ID="dropdwnUsers" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="dropdwnUsers_SelectedIndexChanged" ToolTip="Select Gender" style="width:50%; margin-left:0;margin-right:0;">
                    <asp:ListItem Value="-1" disabled="disabled">Select Users </asp:ListItem>
                    <asp:ListItem Value="1">All</asp:ListItem>
                    <asp:ListItem Value="2">Officers</asp:ListItem>
                    <asp:ListItem Value="3">Students</asp:ListItem>
                    <asp:ListItem Value="4">Owners</asp:ListItem>
                </asp:DropDownList>

            </div>--%>

            <div id="AccommoBookingsDiv" runat="server" class="  table table-responsive" style="width: 100%">
            </div>
           

        </div>
    </div>
</asp:Content>
