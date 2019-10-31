<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acc_DashBoard.aspx.cs" Inherits="AAFS.Acc_DashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /*Star Rating*/
        .starRating {
            width: 50px;
            height: 50px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
        }

        .FillStars {
            background-image: url("img/Rating/FilledStar.png");
            background-size: 15px;
        }

        .WaitingStars {
            background-image: url("img/Rating/waitingStar.png");
            background-size: 15px;
        }

        .EmptyStars {
            background-image: url("img/Rating/EmptyStar.png");
            background-size: 15px;
        }

        /*End star Rating*/

        .carousel .one {
            background: url(../img/cleaningservice.jpg) no-repeat;
            background-size: contain;
            background-position: center;
        }

        .carousel .two {
            background: url(../img/bedding.jpg) no-repeat;
            background-size: contain;
            background-position: center;
            background-attachment: scroll;
        }

        .carousel .three {
            background: url(../img/electrical.jpg) no-repeat;
            background-size: contain;
            background-position: center;
            background-attachment: scroll;
        }

        .carousel .four {
            background: url(../img/plumbing.jpg) no-repeat;
            background-size: contain;
            background-position: center;
            background-attachment: scroll;
        }

        /*.carousel .five {
            background: url(../img/bedding.jpg) no-repeat;
            background-size: contain;
            background-position: center;
            background-attachment: scroll;
        }*/

        #content {
            margin: 15px auto;
            text-align: center;
            width: 900px;
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
            width: 900px;
            overflow: hidden;
            padding: 5px;
        }

        .tile-stats {
            padding: 2px;
            background-color: white;
            margin-bottom: 12px;
            border: 1px solid #E4E4E4;
        }

        .x_panel {
            background-color: white;
            margin-bottom: 12px;
            border: 1px solid #E4E4E4;
            border-radius: 10px;
            padding: 5px;
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

        .pull-left {
            font-size: medium;
        }
    </style>
    <script src="Dashboard/jquery/dist/jquery.js"></script>
    <script src="Dashboard/jquery/dist/jquery.min.js"></script>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular.js"></script>
    <script src="js/MyScripts/OwnerDashboard.js"></script>

    <div id="content" class="padding50" ng-app="ownerDashModule">
        <h1></h1>
        <div id="wrapper">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row">

                <div id="reportrange" class=" col-md-3 pull-right" style="background: #fff; cursor: pointer; padding: 5px 10px; margin-right: 10px; border: 1px solid #ccc; border-radius: 3px">

                    <span>
                        <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label></span>
                </div>

            </div>
            <!-- Carousel -->
            <div id="carousel-example-generic" class="carousel slide carousel-fade" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target='#carousel-example-generic' data-slide-to='0' class='active'></li>
                    <li data-target='#carousel-example-generic' data-slide-to='1'></li>
                    <li data-target='#carousel-example-generic' data-slide-to='2'></li>
                    <li data-target='#carousel-example-generic' data-slide-to='3'></li>
                    <%--<li data-target='#carousel-example-generic' data-slide-to='4'></li>--%>
                </ol>
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item active one">
                    </div>
                    <div class="item two">
                    </div>
                    <div class="item three">
                    </div>
                    <div class="item four">
                    </div>
                   <%-- <div class="item five">
                    </div>--%>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                            href="#carousel-example-generic" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
                </div>
            </div>


            <!-- page content -->
            <div class="right_col" role="main">
                <div class="">
                    <hr />
                    <div class="row">
                        <div class="x_content">
                            <%-- Upcoming Inpsctions --%>
                            <div class="col-md-5">
                                <div class="x_panel">
                                    <div class="x_title">
                                        <legend>
                                            <h3>Quick Access </h3>
                                        </legend>
                                        <%-- <small>Sessions</small>--%>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="x_content ">
                                        <ul class="list-group-item well" style="list-style: none;">
                                            <li>
                                                <asp:LinkButton ID="linkMyAccommo" runat="server" OnClick="linkMyAccommo_Click" class="btn btn-default btn-lg btn-min-block" Width="100%">
                            <i class="fa fa-home fa-5x"></i><br/> <h4>MyAccommodations</h4></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="linkUpComInspec" runat="server" OnClick="linkUpComInspec_Click" class="btn btn-default btn-lg btn-min-block" Width="100%">
                            <i class="fa fa-file-o fa-5x"></i><br/> <h4>Upcoming Inspections</h4></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="linkReports" runat="server" OnClick="linkReports_Click" class="btn btn-default btn-lg btn-min-block" Width="100%">
                            <span class=" fa-line-chart fa fa-5x"></span><br/> <h4>General Reports</h4></asp:LinkButton></li>
                                        </ul>



                                    </div>
                                </div>
                            </div>

                            <%-- Top Rating Accommos --%>
                            <div class="col-md-7" ng-controller="ratingsController">
                                <div class="x_panel">
                                    <div class="x_title">
                                        <legend>
                                            <h3>Top Accommodations</h3>
                                        </legend>
                                        <div class="clearfix"></div>
                                    </div>
                                    <ul class="list-unstyled top_profiles scroll-view">
                                        <li class="media event well" ng-repeat="rating in accRatings | orderBy:'-avgAccommoRating' | limitTo:5 | filter: campusSelected.NearestCampus">

                                            <div class="">

                                                <table style="width: 99%; border-collapse: collapse; padding: 10px; border-style: none; border-radius: 0px 10px 10px 10px">

                                                    <tr style="background-color: white">
                                                        <td rowspan="3" style="text-align: center; margin-left: auto; margin-right: auto; border-bottom-right-radius: 15px; border-bottom-left-radius: 15px; width: 40%">
                                                            <img class="img-rounded pull-left" ng-src="Accommodations/{{rating.AccommoID}}/Accomm_Images/{{rating.AccommoMainImage.ImageName}}" style="width: 90%; height: 80px; padding-bottom: 10px; margin-left: 10%; margin-right: 10%;" aria-multiline="True" alt="Accommodation Profile Picture" />
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td>
                                                            <%--<div class="pull-left bg-info" style="font-size: 24px; border-radius: 0px 0px 8px 0px">{{$index + 1}}.</div>--%>

                                                            <h4><a class="title" href="ViewIndividualAccommodation.aspx?AccommID={{rating.AccommoID}}">{{rating.AccommoName}}</a></h4>

                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td style="text-align: center; margin-left: 3px">
                                                            <div ng-if="rating.avgAccommoRating == 0" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="0"></ajaxToolkit:Rating>
                                                            </div>
                                                            <div ng-if="rating.avgAccommoRating == 1" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating2" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="1"></ajaxToolkit:Rating>
                                                            </div>
                                                            <div ng-if="rating.avgAccommoRating == 2" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating3" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="2"></ajaxToolkit:Rating>
                                                            </div>
                                                            <div ng-if="rating.avgAccommoRating == 3" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating4" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="3"></ajaxToolkit:Rating>
                                                            </div>
                                                            <div ng-if="rating.avgAccommoRating == 4" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating5" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="4"></ajaxToolkit:Rating>
                                                            </div>
                                                            <div ng-if="rating.avgAccommoRating == 5" style="max-height: 30px;">
                                                                <ajaxToolkit:Rating ID="Rating6" runat="server" StarCssClass="starRating" FilledStarCssClass="FillStars" WaitingStarCssClass="WaitingStars" EmptyStarCssClass="EmptyStars" MaxRating="5" CurrentRating="5"></ajaxToolkit:Rating>
                                                            </div>

                                                            <p>Rated by <strong>{{rating.numRatings}}</strong> person(s)</p>
                                                        </td>
                                                    </tr>
                                                </table>



                                            </div>
                                        </li>

                                    </ul>
                                </div>
                            </div>

                        </div>

                    </div>

                    <%-- 
                    <div class="row">
                        <div class="col-md-2"></div>

                        <div class="col-md-2"></div>
                        <%--   <div class="col-md-4">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Top Profiles <small>Sessions</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                        <ul class="dropdown-menu" role="menu">
                          <li><a href="#">Settings 1</a>
                          </li>
                          <li><a href="#">Settings 2</a>
                          </li>
                        </ul>
                      </li>
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item One Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Three Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                  </div>
                </div>
              </div>

              <div class="col-md-4">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Top Profiles <small>Sessions</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                        <ul class="dropdown-menu" role="menu">
                          <li><a href="#">Settings 1</a>
                          </li>
                          <li><a href="#">Settings 2</a>
                          </li>
                        </ul>
                      </li>
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item One Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Two Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">April</p>
                        <p class="day">23</p>
                      </a>
                      <div class="media-body">
                        <a class="title" href="#">Item Three Title</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                      </div>
                    </article>
                  </div>
                </div>
              </div>--% --%>
                </div>
            </div>
            <!-- /page content -->
        </div>
    </div>

</asp:Content>
