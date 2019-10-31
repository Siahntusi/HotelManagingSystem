/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;


//**************Acc UpComing Inspect Get All************//
//Module
(function () {
    app = angular.module("AccommoInspecModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoUpcomeInspecController", function ($scope, AccInspectService) {
    // debugger;
    $scope.AccommoInspecStat = [];

    var promiseGet = AccInspectService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoInspecStat = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Inspections', errorPl);
              });
});
//Services
app.service("AccInspectService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/InspectionSevices.svc/getInspecsByStatus/PENDING");
    };
});
//*****************End Acc UpComing Inspect*********//


