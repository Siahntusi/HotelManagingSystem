/// <reference path="dirPagination.js" />

//App variable
var app;



//**************Accred Applications Get All************//
//Module
(function () {
    app = angular.module("AccommoAccredApplyModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredApplyController", function ($scope, AccAccreditationService) {
    // debugger;
    $scope.AccommoAcrApply = [];
    var promiseGet = AccAccreditationService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAcrApply = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Applications', errorPl);
              });
});
//Services
app.service("AccAccreditationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getAllAccredApplications");
    };
});
//*****************End Applications*********//

//**************Accred Applications Unsuccessful OFFICER************//
//Module
(function () {
    app = angular.module("AccommoAccredApplyModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredApplyController", function ($scope, AccAccreditationService) {
    // debugger;
    $scope.AccommoAcrApply = [];
    var promiseGet = AccAccreditationService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAcrApply = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Applications', errorPl);
              });
});
//Services
app.service("AccAccreditationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getApplicationByStatus/FAILED");
    };
});
//*****************End Applications*********//

//**************Accred Applications Unsuccessful OWNER************//
//Module
(function () {
    app = angular.module("AccommoAccredApplyModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAccredApplyController", function ($scope, AccAccreditationService) {
    // debugger;
    $scope.AccommoAcrApply = [];
    var promiseGet = AccAccreditationService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAcrApply = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Applications', errorPl);
              });
});
//Services
app.service("AccAccreditationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccreditationServices.svc/getAllAccredApplications");
    };
});
//*****************End Applications*********//