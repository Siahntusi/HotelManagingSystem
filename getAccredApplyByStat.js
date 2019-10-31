/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;

//**************Accred Applications Unsuccessful OFFICER************//
//Module
(function () {
    app = angular.module("AccommoAccredFailApplyModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredFailedApplyController", function ($scope, AccAccreditationfailedService) {
    // debugger;
    $scope.AccommoAcrApply = [];
    var promiseGet = AccAccreditationfailedService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAcrApply = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Applications', errorPl);
              });
});
//Services
app.service("AccAccreditationfailedService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getAllAccredApplications");
    };
});
//*****************End Applications*********//

//**************Accred Applications Unsuccessful OWNER************//
//Module
(function () {
    app = angular.module("AccommoAccredFailApplyModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredFailedApplyController", function ($scope, AccAccreditationfailedService) {
    // debugger;
    $scope.AccommoAcrApply = [];
    var promiseGet = AccAccreditationfailedService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAcrApply = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Applications', errorPl);
              });
});
//Services
app.service("AccAccreditationfailedService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getAllAccredApplications");
    };
});
//*****************End Applications*********//