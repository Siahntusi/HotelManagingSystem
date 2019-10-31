<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_GenerelReports.aspx.cs" Inherits="AAFS.Acc_GenerelReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/angular.min.js"></script>
    <script src="js/ChartScripts/Chart.min.js"></script>
    <script src="js/ChartScripts/angular-chart.min.js"></script>
    <script src="js/MyScripts/chartApp.js"></script>
    <style>
        table, th, tr, td {
            border: none;
            border-collapse: collapse;
            border-style: none;
        }

        .Formlabel {
            text-align: left;
            display: inline;
            display: block;
        }

        #content {
            margin: 15px auto;
            text-align: center;
            width: 1000px;
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
            width: 1000px;
            overflow: hidden;
            padding: 10px;
        }


        .hidden {
            display: none;
        }

        .middle {
            margin-left: auto;
            margin-right: auto;
            width: 98%;
        }

        .col-md-6 {
            padding: 5px;
        }

        .x_panel {
            background-color: white;
            margin-bottom: 12px;
            border: 1px solid #E4E4E4;
            border-radius: 7px;
        }

        .x_content {
            padding: 10px;
        }

        .count {
            font-size: 20px;
        }

        .row {
            margin-bottom: 10px;
        }

        li {
            padding-top: 5px;
            padding-bottom: 5px;
            margin-left: 2px;
            margin-right: 5px;
        }
        
    </style>

    <div id="content" class="padding50" ng-app="reportsModule">
        <h1></h1>

        <div id="wrapper">
            <legend>
                <h1>General Reports</h1>
            </legend>

            <%-- Housing per campus +  --%>
            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Housing Supply & Demand Per City</h3>
                            </legend>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="lineCtrl_HousingAbility">
                                <canvas id="line" class="chart chart-line" chart-data="[[JHB[1],PTA[1],DBN[1],CPT[1]],[JHB[0],PTA[0],DBN[0],CPT[0]]]"
                                    chart-labels="labels" chart-series="series" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Hotels Per City</h3>
                            </legend>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="pieCtrl_AccPerCampus">
                                <canvas id="pie" class="chart chart-doughnut"
                                    chart-data="NumCampData" chart-labels="['JHB','PTA','DBN','CPT']" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Gender Groupings</h3>
                            </legend>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="pieCtrl_GenGroupings">
                                <canvas id="pie2" class="chart chart-pie"
                                    chart-data="[NumFemale,NumMale,NumMixed]" chart-labels="['Female','Male','Mixed']" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Funding Types Allocations</h3>
                            </legend>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="pieCtrl_FundingTypes">
                                <canvas id="pie3" class="chart chart-doughnut"
                                    chart-data="[NumNsfas,NumCash,NumExternal]" chart-labels="['Credit Card','Cash','Electronics Fund Transfer (EFT)']" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Accredited Hotels</h3>
                            </legend>

                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="pieCtrl_AccredStatus">
                                <canvas id="pie4" class="chart chart-doughnut"
                                    chart-data="accredStatusData" chart-labels="['Accredited','Not Accredited']" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <legend>
                                <h3>Rent Rates</h3>
                            </legend>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div ng-controller="BarCtrl_RentRates">
                                <canvas id="bar" class="chart chart-bar"
                                    chart-data="[Range1,Range2,Range3]" chart-labels="labels"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
