<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_MyCompanies.aspx.cs" Inherits="AAFS.AccMyCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .Formlabel {
            text-align: left;
            display: inline;
            display: block;
        }

        .auto-style1 {
            height: 143px;
        }

        #content {
            margin: 15px auto;
            text-align: center;
            width: 700px;
            position: relative;
            height: 100%;
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
            width: 700px;
            overflow: hidden;
        }

        #steps {
            overflow: hidden;
            width: 700px;
        }

        .step {
            float: left;
            width: 700px;
        }

        .MoveBtn {
            padding-right: 10px;
            width: 100px;
            margin: 15px;
        }

        .hidden {
            display: none;
        }
    </style>

    <div id="content" class="padding50">
        <h1></h1>

        <div id="wrapper">
            <legend>
                <h1>Manage Companies</h1>
            </legend>
            <div style="float: right; padding: 1%;">
                <asp:Button ID="btnAddNewCompany" runat="server" Text="Add New Company" CssClass="btn btn-default" OnClick="btnAddNewCompany_Click" />
            </div>

            <div id="MyCompListDiv" runat="server" class=" table-responsive" style="width: 100%">
            </div>

        </div>
    </div>
</asp:Content>
