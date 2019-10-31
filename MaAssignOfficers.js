/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;

//**************Officer Get All************//
//Module
(function () {
    app = angular.module("AccommoOfficerModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoOfficerController", function ($scope, AccommoOfficerService, IndividualAccommodationService) {
    // debugger;
    $scope.AccommoOfficers = [];
    var promiseGet = AccommoOfficerService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoOfficers = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Officers', errorPl);
              });

    $scope.ApplyAccommodation = [];
    var promiseGet = IndividualAccommodationService.get();

    promiseGet.then(function (pl) {
        $scope.ApplyAccommodation = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Hotel', errorPl);
              });
});
//Services
app.service("AccommoOfficerService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/OfficerServices.svc/getOfficersInCampus/" + getUrlParameter('Campus'));
    };
});
//*****************End OFficer*********//



//Services
app.service("IndividualAccommodationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getApplicationDetailsByRefNum/" + getUrlParameter('RefNum'));
    };
});


function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;

    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }
    return res;
}