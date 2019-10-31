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
    switch(getUrlParameter('campus'))
    {
        case "jhb":
            this.get = function () {
                return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/jhb");
            };
            break;
        case "pta":
            this.get = function () {
                return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/pta");
            };
            break;
        case "dbn":
            this.get = function () {
                return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/dbn");
            };
            break;
        case "cpt":
            this.get = function () {
                return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/cpt");
            };
            break;
        default:
            this.get = function () {
                return $http.get("http://localhost:50706/AccommodationServices.svc/getAllAccommo");
            };
            break;
    }
});

//Filter that helps with pagination
app.filter('startFrom', function () {
    return function (data, start) {
        return data.slice(start);
    }
});

//Price filter

//Unique Filter - Haven't used this filter as of yet
app.filter('uniqueGender', function () {
    return function (data, keyname) {
        var output = [], keys = [];
        angular.forEach(data, function (item) {
            var key = item[keyname];
            if (keys.indexOf(key) === -1) {
                keys.push(key);
                output.push(item);
            }
        });
        return output;
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
