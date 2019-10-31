/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

var app;
//Module  
(function () {
    app = angular.module("AccMoveInModule", ['angularUtils.directives.dirPagination']);
})();

app.controller("IndivAccommoMoveInReqController", function ($scope, IndivAccommoMoveInReqService) {
    // debugger;
    var promiseGet = IndivAccommoMoveInReqService.get();

    $scope.AccommodationMoveIns = [];
    promiseGet.then(function (pl) {
        $scope.AccommodationMoveIns = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Accommodation', errorPl);
              });
});

//*****************MoveInRequest*******************

//Services
app.service("IndivAccommoMoveInReqService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/BookingServices.svc/getAllMoveInRequests/" + getUrlParameter('AccommID'));
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
