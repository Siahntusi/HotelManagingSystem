/// <reference path="../../Scripts/ng-map.min.js" />
var app;

//Module
(function () {
    app = angular.module("mapModule", ['ngMap']);
})();

//***************************************Start Gen Cont***************************************************
app.controller("mapAccommoController", function ($scope, AccommoMappingService) {
    // debugger;
    var promiseGet = AccommoMappingService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});


app.controller("mapCampusController", function ($scope, CampusMappingService) {
    // debugger;
    var promiseGet = CampusMappingService.get();

    promiseGet.then(function (pl) {
        $scope.CampusCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});
//*************************************End Gen Cont*****************************************************

//Controllers for nearest campus ***********************************************************
app.controller("NearestCityJHB", function ($scope, NearestJHB) {
    // debugger;
    var promiseGet = NearestJHB.get();

    promiseGet.then(function (pl) {
        $scope.AccommoCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});

app.controller("NearestCityPTA", function ($scope, NearestPTA) {
    // debugger;
    var promiseGet = NearestPTA.get();

    promiseGet.then(function (pl) {
        $scope.AccommoCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});

app.controller("NearestCityDBN", function ($scope, NearestDBN) {
    // debugger;
    var promiseGet = NearestDBN.get();

    promiseGet.then(function (pl) {
        $scope.AccommoCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});

app.controller("NearestCityCPT", function ($scope, NearestCPT {
    // debugger;
    var promiseGet = NearestCPT.get();

    promiseGet.then(function (pl) {
        $scope.AccommoCoordinates = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading coordinates', errorPl);
              });
});
//*************************End of Controllers for nearest campus*****************************
//Services
//AccommoMappingService
app.service("AccommoMappingService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAllAccommo");
    };
});
//End of AccommoMappingService


//CampusMappingService
app.service("CampusMappingService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/CampusServices.svc/getAllCampus");
    };
});
//End of CampusMappingService

//NearestCampusServices
app.service("NearestJHB", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/jhb");
    };
});

app.service("NearestPTA", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/pta");
    };
});

app.service("NearestDBN", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/dbn");
    };
});

app.service("NearestCPT", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoNearCampus/cpt");
    };
});
//End of NearestCampusServices