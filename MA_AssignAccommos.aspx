<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MA_AssignAccommos.aspx.cs" Inherits="AAFS.MA_AssignAccommos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Show List Of Accommos & DropDwn Of Officers  --%>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/angular-route.js"></script>
    <script src="js/MyScripts/dirPagination.js"></script>
    <script src="js/MyScripts/GetAllOfficers.js"></script>
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

        tr, td {
            padding-bottom: 3%;
        }

        label {
            font-weight: bold;
        }
    </style>


    <div id="content" class="padding50">
        <h1></h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="wrapper">
            <legend>
                <h1>Assign Inspector</h1>
            </legend>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="table table-striped table-bordered table-responsive">
                        <tr style="background-color: white">
                            <td colspan="2"><strong>Inspector</strong></td>
                        </tr>
                        <tr>
                            <th>Surname & Name:</th>
                            <td>
                                <asp:Label ID="lblNameSurname" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <th>Campus:</th>
                            <td>
                                <asp:Label ID="lblCampus" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <th>Tel No.</th>
                            <td>
                                <asp:Label ID="lblTele" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <th>Email:</th>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr style="background-color: white">
                            <td colspan="2"><strong>Accommodation</strong></td>

                        </tr>
                        <tr>
                            <th>Name:</th>
                            <td>
                                <asp:Label ID="lblAccName" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <th>Address:</th>
                            <td>
                                <asp:Label ID="lblAccAddress" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnAssign" runat="server" Text="Assign" CssClass="btn btn-primary" OnClick="btnAssign_Click" />

                            </td>
                        </tr>
                    </table>
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
    </div>
</asp:Content>
