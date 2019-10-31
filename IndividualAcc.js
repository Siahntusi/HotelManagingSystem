/// <reference path="../../Scripts/ng-map.min.js" />

var app;
//Module  
(function () {
    app = angular.module("IndividualAccModule",['ngMap']);
})();

app.controller("IndividualAccommodationController", function ($scope, IndividualAccommodationService) {
    // debugger;
    var promiseGet = IndividualAccommodationService.get();
    
    $scope.Accommodation = [];
    promiseGet.then(function (pl) {
        $scope.Accommodation = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Accommodation', errorPl);
              });
});

//Services
app.service("IndividualAccommodationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoFullInfoById/" + getUrlParameter('AccommID'));
    };
});

//filter
app.filter('roundup', function () {

    return function (value) {
        return Math.ceil(value);
    };
})

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