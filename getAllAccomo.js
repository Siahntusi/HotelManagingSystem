/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;
//, 'ngRoute'
//Module
(function () {
    app = angular.module("AccommodationModule", ['angularUtils.directives.dirPagination']);
})();

//Controller
app.controller("AccommodationController", function ($scope, AccommodationService) {
    // debugger;
    $scope.Accommodations = [];
    var promiseGet = AccommodationService.get();

    promiseGet.then(function (pl) {
        $scope.Accommodations = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Accommodations', errorPl);
              });
});

//Services
app.service("AccommodationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAllAccommo");
    };
});
