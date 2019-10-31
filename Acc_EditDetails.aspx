<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_EditDetails.aspx.cs" Inherits="AAFS.Acc_EditDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Upload --%>
    <script src="Scripts/angular.js"></script>
    <script src="DropzoneJs_scripts/dropzone.js"></script>
    <link href="DropzoneJs_scripts/dropzone.css" rel="stylesheet" />
    <link href="DropzoneJs_scripts/basic.css" rel="stylesheet" />
    <script src="js/MyScripts/ng-dropzone.min.js"></script>
    <script src="js/MyScripts/ng-dropzone.js"></script>
    <%--<!-- AngularJS -->
	<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.9/angular.min.js"></script>
		
	<!-- Dropzone -->
	<script src="https://rawgit.com/enyo/dropzone/d8ef7a82e6ab5447c1f2d9512c8e1bfd4de5ac9e/dist/dropzone.js"></script>
	<link rel="stylesheet" href="https://rawgit.com/enyo/dropzone/d8ef7a82e6ab5447c1f2d9512c8e1bfd4de5ac9e/dist/dropzone.css">--%>
    <link href="js/MyScripts/ng-dropzone.min.css" rel="stylesheet" />
    <script src="js/MyScripts/ng-dropzone.min.js"></script>
    <script src="js/MyScripts/toets.js"></script>
    <%-- End Upload --%>
     <link href="css/ModalsProgress.css" rel="stylesheet" />
    <style>
                #modalProgress {
            position: absolute;
            left: 50%;
            top: 50%;
            z-index: 99;
            width: 600px;
            height: 600px;
            margin: -75px 0 0 -75px;
            background-image: url("img/loader.gif");
            background-repeat: no-repeat;
        }
        label {
            text-align: left;
        }

        #content {
            margin: 15px auto;
            text-align: center;
            width: 852px;
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
            width: 852px;
            overflow: hidden;
        }

        #box {
            width: 300px;
            height: 100px;
            text-align: center;
            vertical-align: middle;
            border: 2px solid #ff6a00;
            background-color: #ffd800;
            padding: 15px;
            font-family: Arial;
            font-size: 16px;
            margin-top: 35px;
        }

        .padleft {
            padding-left: 5%;
        }

        .left {
            float: left;
        }

        .right {
            float: right;
        }

        .padDown {
            padding-bottom: 5px;
        }

        .col {
            border: 1px solid black;
            background-color: #fafefd;
        }

        .imgMainPicCss {
            width: 80%;
            height: 80%;
        }
    </style>
    <div id="content" class="padding50">
        <h1></h1>

        <div id="wrapper">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <legend>
                <h1>Edit Details</h1>

            </legend>

             <%-- View as student --%>
            <div class="row">
                <div class="col-md-3 pull-right">
                    <div id="ahrefdiv" runat="server"></div>
                </div>
            </div>

            <%-- Pic + Name --%>
            <div class="row" style="padding: 5px;">
                <div class="col-md-3"></div>
                <div class="col-md-6 col">
                    <legend>Main Picture</legend>
                    <asp:Image ID="imgMainPic" runat="server" CssClass="padDown imgMainPicCss" AlternateText="Profile Picture" />
                    <br />
                    <asp:FileUpload ID="MainPic" runat="server" class="btn btn-default center-block" BorderColor="Black" BorderStyle="Dotted" />
                    <br />
                    <asp:Button ID="btnChngeProPic" CssClass="btn btn-primary" runat="server" Text="Change Main Profile Picture" OnClick="btnChngeProPic_Click" />
                    <br />
                    <br />
                    <ajaxtoolkit:balloonpopupextender id="BalloonPopupExtender1" displayonmouseover="true" position="BottomRight"
                        balloonsize="Medium" runat="server" targetcontrolid="imgMainPic"
                        balloonpopupcontrolid="panel1" useshadow="true" balloonstyle="Rectangle">
                    </ajaxtoolkit:balloonpopupextender>
                    <asp:Panel ID="panel1" runat="server">
                        <p class="alert alert-info">The Profile picture is the image displayed as the 'Face' of the Hotel</p>
                    </asp:Panel>
                </div>

                <div class="col-md-3">
                </div>
            </div>
            <hr style="" />
            <%-- Tabs --%>
            <div class="row" style="padding: 10px;">
                <div class="col-md-1"></div>
                <div class="col-md-10"
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ajaxtoolkit:tabcontainer id="TabContainer2" runat="server">

                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>Features</HeaderTemplate>
                            <ContentTemplate>
                                <div class="row" style="padding: 10px;">
                                    <p class="alert alert-info">
                                        Select Features That are Currently Offered By the Hotel
                                    <br />
                                    </p>
                                    <div id="divChckBoxListFeatures" runat="server" width="100%" class="chboxList">
                                        <input runat="server" type="checkbox" id="Gym">Gym</input>
                                        <input runat="server" type="checkbox" id="Cleaning">Cleaning Service</input>
                                        <input runat="server" type="checkbox" id="Laundry">Laundry Service</input><br/>
                                        <input runat="server" type="checkbox" id="Parking">Parking</input>
                                        <input runat="server" type="checkbox" id="Wifi">Wifi</input>
                                        <input runat="server" type="checkbox" id="TvArea">TV Area</input><br/>
                                        <input runat="server" type="checkbox" id="EntArea">Entertainment Area</input>
                                        <input runat="server" type="checkbox" id="StudyArea">Study Area</input>
                                        <input runat="server" type="checkbox" id="TransServ">Transport Services</input>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>

                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>Rooms and Pricing</HeaderTemplate>
                            <ContentTemplate>
                                <div class="row" style="padding: 10px;">
                                    <p class="alert alert-info">
                                        Adjust Number of Rooms and Room Prices  the Hotel
                                    <br />
                                    </p>
                                    <div class="col-md-6">
                                        <table class="table table-bordered table-striped" style="text-align: left">
                                            <tr>
                                                <asp:DropDownList ID="drpGender" CssClass="form-control" runat="server">
                                                    <asp:ListItem disabled="disabled">Select Gender Allowed</asp:ListItem>
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                    <asp:ListItem>Mixed</asp:ListItem>
                                                </asp:DropDownList>
                                            </tr>
                                            <thead>
                                                <tr>
                                                    <th style="text-align: center">
                                                        <h3>Rooms</h3>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Number Of Singles: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Accommodation Name Required" ControlToValidate="txtNumSingles" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtNumSingles" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNumSingles_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Number Of Sharing: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Hotel Name Required" ControlToValidate="txtNumSharing" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtNumSharing" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNumSharing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td style="border-style: none">
                                                    <label>Number Of Sharing En-Suite: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Accommodation Name Required" ControlToValidate="txtNumSharEnS" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtNumSharEnS" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNumSharEnS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Number Of Single En-Suite: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Accommodation Name Required" ControlToValidate="txtNumSinglEnS" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtNumSinglEnS" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNumSinglEnS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Number Of Bathrooms: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="Hotel Name Required" ControlToValidate="txtNumBathrooms" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtNumBathrooms" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNumBathrooms_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Total Capacity: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Hotel Name Required" ControlToValidate="txtCapacity" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCapacity_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-md-6">
                                        <table class="table table-bordered table-striped" style="text-align: left">
                                            <thead>
                                                <tr>
                                                    <th style="text-align: center">
                                                        <h3>Pricing</h3>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Singles: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Accommodation Name Required" ControlToValidate="txtPricSingle" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtPricSingle" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPricSingle_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none">
                                                    <label>Sharing: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="Hotel Name Required" ControlToValidate="txtPricSharing" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txtPricSharing" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPricSharing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>

                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server">
                            <HeaderTemplate>Image UpLoads</HeaderTemplate>
                            <ContentTemplate>
                                <div ng-app="UploadsApp" style="margin-left: auto; margin-right: auto; padding: 10px">
                                    <p class="alert alert-info">
                                        <strong>You May Only Upload a Maximum 8 Pictures </strong>
                                        <br />
                                        These images will be the ones to be displayed upon individual Viewing
                                    <br />
                                    </p>
                                    <div ng-controller="drop1Controller">
                                        <div id="dropzone1" class="dropzone" options="dzOptions" callbacks="dzCallbacks" ng-dropzone></div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>

                    </ajaxtoolkit:tabcontainer>
  <div class="row" style="padding-bottom: 5%; padding-top: 5%;">
                <div class="col-md-4" style="float: left"></div>
                <div class="col-md-4">
                    <asp:Button ID="btnSaveChanges" CssClass="btn btn-success" Width="150px" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />
                </div>
                <div class="col-md-4" style="float: left"></div>

            </div>
                        </ContentTemplate>
                   </asp:UpdatePanel>
                        <%-- Update Progress --%>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div id="modalProgress"></div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%-- End Progress --%>
            <%-- Success Input --%>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSuccess" BehaviorID="mpe" runat="server"
                PopupControlID="pnlPopup" TargetControlID="lnkDummySuccess" BackgroundCssClass="modalBackground" CancelControlID="btnSuccessClose">
            </ajaxToolkit:ModalPopupExtender>
            <asp:LinkButton ID="lnkDummySuccess" runat="server"></asp:LinkButton>

            <asp:Panel ID="pnlPopup" runat="server" Style="display: none">

                <div class="modal-content modal-dialog">
                    <div class="pull-right" style="padding-right: 5px; height: 10px">
                        <button type="button" id="btnSuccessClose" runat="server" class="close" style="height: 50px; width: 50px" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="Reg-modal-body" style="padding: 35px 50px;">
                        <div class="alert-box success" style="text-align: center;">
                            <h2>Success</h2>
                            <br />
                            <h3>Inspector Assigned</h3>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <!-- Success Input-->
            <script type="text/javascript">
                function pageLoad() {
                    var modalPopup = $find('mpe');
                    modalPopup.add_shown(function () {
                        modalPopup._backgroundElement.addEventListener("click", function () {
                            modalPopup.hide();
                        });
                    });
                };
            </script>
            <%-- End Success --%>

            <%-- Failed Input --%>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFailed" BehaviorID="mpe2" runat="server"
                PopupControlID="pnlPopup" TargetControlID="LnkDummyFailed" BackgroundCssClass="modalBackground" CancelControlID="btnFailedClose">
            </ajaxToolkit:ModalPopupExtender>
            <asp:LinkButton ID="LnkDummyFailed" runat="server"></asp:LinkButton>

            <asp:Panel ID="pnlfailed" runat="server" Style="display: none">

                <div class="modal-content modal-dialog">
                    <div class="pull-right" style="padding-right: 5px; height: 10px">
                        <button type="button" id="btnFailedClose" runat="server" class="close" style="height: 50px; width: 50px" data-dismiss="modal">&times;</button>

                    </div>
                    <div class="Reg-modal-body" style="padding: 35px 50px;">
                        <div class="alert-box warning" style="text-align: center;">
                            <h2>Failed</h2>
                            <br />
                            <h3>Error Assigning Inspector</h3>
                            <br />
                            <h5>Try Again...</h5>
                            <p>If Problem Continues, Contact Admin for Further Assistance!!!</p>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <!-- Failed Input-->
            <script type="text/javascript">
                function pageLoad() {
                    var modalPopup = $find('mpe2');
                    modalPopup.add_shown(function () {
                        modalPopup._backgroundElement.addEventListener("click", function () {
                            modalPopup.hide();
                        });
                    });
                };
            </script>
            <%-- End Failed --%>
                </div>
                <div class="col-md-1"></div>
            </div>

            


        </div>
    </div>
</asp:Content>
