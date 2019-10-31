/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;


//**************Acc Get Accommo by AccredStatus************//
//Module
(function () {
    app = angular.module("AccommoAccredStatusModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredStatusController", function ($scope, AccommoAccredStatusService) {
    // debugger;
    $scope.AccommoAccredStatus = [];
    var promiseGet = AccommoAccredStatusService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAccredStatus = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Accommodations', errorPl);
              });
});
//Services
app.service("AccommoAccredStatusService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoByAccredStatus/ACCREDITED");
    };
});
//*****************End Acc Get Accommo by AccredStatus*********//
