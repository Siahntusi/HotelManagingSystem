/// <reference path="../../Scripts/angular.min.js" />
/// <reference path="../ChartScripts/Chart.min.js" />
/// <reference path="../ChartScripts/angular-chart.min.js" />

var BASE_URL = "http://localhost:50706/ReportingServices.svc/";
var app;

//Module  
(function () {
    app = angular.module("reportsModule", ['chart.js']);
})();

//Config
app.config(['ChartJsProvider', function (ChartJsProvider) {
    // Configure all charts 
    ChartJsProvider.setOptions({
        chartColors: ["#455C73",
        "#9B59B6",
        "#BDC3C7",
        "#26B99A"],
        responsive: true,
    });
}]);


//Bokoings by Gender////////////////////////
app.controller("pieCtrl_BookingsByGender", function ($scope, Female, Male) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
            
        }
    };

    // debugger;
    var promiseGet1 = Female.get();
    var promiseGet2 = Male.get();
   

    $scope.NumFemale = 0;
    $scope.NumMale = 0;
    

    promiseGet1.then(function (pl) {
        $scope.NumFemale = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Female', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.NumMale = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Male', errorPl);
              });
});

app.service("Male", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getNumBookingsByGender/" + getUrlParameter('AccommID') + ",Male");
    };
});

app.service("Female", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getNumBookingsByGender/" + getUrlParameter('AccommID') + ",Female");
    };
});
///////////////////////////////////////////////////////////////////////////


//Accomo Bookings Details//////////////////////////////////////////////////
app.controller("IndividualAccommodationController", function ($scope, IndividualAccommodationService, numBookings) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
           
        }
    };
    // debugger;
    var promiseGet1 = IndividualAccommodationService.get();
    var promiseGet2 = numBookings.get();

    $scope.Accommodation = [];

    promiseGet1.then(function (pl) {
        $scope.Accommodation = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Accommodation', errorPl);
              });

    $scope.numBook = 0;

    promiseGet2.then(function (pl) {
        $scope.numBook = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Bookings', errorPl);
              });

});
//Services
app.service("IndividualAccommodationService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoFullInfoById/" + getUrlParameter('AccommID'));
    };
});

app.service("numBookings", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getNumBookingsToAccommo/" + getUrlParameter('AccommID'));
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

