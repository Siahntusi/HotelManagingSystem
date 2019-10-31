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
app.controller("AccommoOfficerController", function ($scope, AccommoOfficerService) {
    // debugger;
    $scope.AccommoOfficers = [];
    var promiseGet = AccommoOfficerService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoOfficers = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Officers', errorPl);
              });
});
//Services
app.service("AccommoOfficerService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/OfficerServices.svc/getAllOfficers");
    };
});
//*****************End OFficer*********//
