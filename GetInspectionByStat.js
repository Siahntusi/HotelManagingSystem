/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;

//**************OFF FAILED Inspect Get All************//
//Module
(function () {
    app = angular.module("AccommoFailedInspecModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoFailedInspecController", function ($scope, AccommoFailedService) {
    // debugger;
    $scope.AccommoFailedInspec = [];

    var promiseGet = AccommoFailedService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoFailedInspec = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Upcoming Inspections', errorPl);
              });
});
//Services
app.service("AccommoFailedService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/InspectionSevices.svc/getListAccommoByInspecStatus/FAILED");
    };
});
//*****************End Inspect*********//

//**************ACC FAILED Inspect Get All************//
//Module
(function () {
    app = angular.module("AccommoFailedInspecModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoFailedInspecController", function ($scope, AccommoFailedService) {
    // debugger;
    $scope.AccommoFailedInspec = [];

    var promiseGet = AccommoFailedService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoFailedInspec = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Upcoming Inspections', errorPl);
              });
});
//Services
app.service("AccommoFailedService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/InspectionSevices.svc/getListAccommoByInspecStatus/FAILED");
    };
});
//*****************End Inspect*********//