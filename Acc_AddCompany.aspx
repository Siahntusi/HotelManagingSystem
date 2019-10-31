<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_AddCompany.aspx.cs" Inherits="AAFS.Acc_AddCompany" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="css/Validation.css" rel="stylesheet" />
    <script src="js/Validation.js"></script>
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
    .reqFieldValid {
            font-weight: bold;
            color: red;
        }
    </style>

     <div id="content" class="padding50">
       <h1></h1>

        <div id="wrapper">
             
  <legend><h1>Company Details</h1></legend>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="table" style="text-align: left">
                        <tr>
                            <td style="border-style: none">
                                <label for="CompName">Company Name: </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Company Name Required" ControlToValidate="txtCompName" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txtCompName" runat="server" CssClass="form-control" AutoPostBack="True" placeholder=" Company Name" OnTextChanged="txtCompName_TextChanged" ToolTip="Company Registration Name"></asp:TextBox>

                            </td>
                            <td style="border-style: none"></td>
                        </tr>
                        <tr>
                            <td style="border-style: none">
                                <label for="CompReg">Company Registration Number: </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Company Registration Number" ControlToValidate="txtCompRegNo" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtCompRegNo" runat="server" CssClass="form-control" ToolTip="Company Registration" placeholder="YYYY/NNNNNNN/NN" AutoPostBack="true" OnTextChanged="txtCompRegNo_TextChanged" MaxLength="15"></asp:TextBox>

                            </td>

                        </tr>
                        <tr>
                            <td style="border-style: none">
                                <label for="TeleNo">Telephone Number: </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTeleNo" CssClass="reqFieldValid">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtTeleNo" runat="server" CssClass="form-control" placeholder="0000000000" AutoPostBack="true" OnTextChanged="txtTeleNo_TextChanged" MaxLength="10"></asp:TextBox>

                            </td>
                            <td style="border-style: none"></td>
                        </tr>
                        <tr>
                            <td style="border-style: none">
                                <label for="Email">Email: </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Company Email Required" ControlToValidate="txtEmail" Text="*" CssClass="reqFieldValid"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="name@Company.com" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Format Incorrect" Text="* Email Format Incorrect" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td style="border-style: none"></td>
                        </tr>
                        <tr>
                            <td style="border-style: none"></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100%" Text="Submit" CssClass="btn btn-primary" Style="padding: 2%; padding-bottom: 5px; margin-left: auto; margin-right: auto;" />

                </ContentTemplate>
           </asp:UpdatePanel>
        </div>
    </div>

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
                            <h3>Company Added</h3>
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
                           <div class="alert-box warning" style="text-align: center;">
                            <h2>Failed</h2>
                            <br />
                            <h3>Error Adding Company</h3>
                            <br />
                            <h5>Try Again...</h5>
                            <p>If Problem Continues, Contact Admin for Further Assistance!!!</p>
                        </div>
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
</asp:Content>
