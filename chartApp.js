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

//Controllers
app.controller("lineCtrl_HousingAbility", function ($scope, HA_JHB, HA_PTA, HA_DBN, HA_CPT) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = HA_JHB.get();
    var promiseGet2 = HA_PTA.get();
    var promiseGet3 = HA_DBN.get();
    var promiseGet4 = HA_CPT.get();

    $scope.JHB = [];
    $scope.PTA = [];
    $scope.DBN = [];
    $scope.CPT = [];

    promiseGet1.then(function (pl) {
        $scope.JHB = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.PTA = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.DBN = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.CPT = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    $scope.labels = ['JHB', 'PTA', 'DBN', 'CPT'];
    $scope.series = ['Supply', 'Demand'];
});//G

app.controller("pieCtrl_AccPerCampus", function ($scope, countPerCampus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = countPerCampus.get();

    $scope.NumCampData = [];

    promiseGet1.then(function (pl) {
        $scope.NumCampData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

app.controller("pieCtrl_AccredStatus", function ($scope, accredStatus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = accredStatus.get();

    $scope.accredStatusData = [];

    promiseGet1.then(function (pl) {
        $scope.accredStatusData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//B

app.controller("pieCtrl_AccredStatusSpecific", function ($scope, accredStatusSpecific) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = accredStatusSpecific.get();

    $scope.accredStatusData = [];

    promiseGet1.then(function (pl) {
        $scope.accredStatusData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

app.controller("pieCtrl_GenGroupings", function ($scope, Female, Male, Mixed) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = Female.get();
    var promiseGet2 = Male.get();
    var promiseGet3 = Mixed.get();

    $scope.NumFemale = 0;
    $scope.NumMale = 0;
    $scope.NumMixed = 0;

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
    promiseGet3.then(function (pl) {
        $scope.NumMixed = pl.data;

    },
              function (errorPl) {
                  $log.error('failure loading Mixed', errorPl);
              });

});//G

app.controller("pieCtrl_FundingTypes", function ($scope, Credit, Cash, EFT) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = Credit.get();
    var promiseGet2 = Cash.get();
    var promiseGet3 = EFT.get();

    $scope.NumCredit = 0;
    $scope.NumCash = 0;
    $scope.NumEFT = 0;

    promiseGet1.then(function (pl) {
        $scope.NumCredit = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading NumCredit', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.NumCash = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading Cash', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.NumEFT = pl.data;

    },
              function (errorPl) {
                  $log.error('failure loading EFT', errorPl);
              });

});//G

app.controller("pieCtrl_AccommodatedStuds", function ($scope, Accommodated, NonAccommodated) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = Accommodated.get();
    var promiseGet2 = NonAccommodated.get();

    $scope.NumAccommodated = 0;
    $scope.NumNonAccommodated = 0;

    promiseGet1.then(function (pl) {
        $scope.NumAccommdated = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading count', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.NumNonAccommodated = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading count', errorPl);
              });
});//N

app.controller("BarCtrl_Capacity", function ($scope, Range1_C, Range2_C, Range3_C, Range4_C, Range5_C,
    Range6_C, Range7_C, Range8_C, Range9_C, Range10_C, Range11_C) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    var promiseGet1 = Range1_C.get();
    var promiseGet2 = Range2_C.get();
    var promiseGet3 = Range3_C.get();
    var promiseGet4 = Range4_C.get();
    var promiseGet5 = Range5_C.get();
    var promiseGet6 = Range6_C.get();
    var promiseGet7 = Range7_C.get();
    var promiseGet8 = Range8_C.get();
    var promiseGet9 = Range9_C.get();
    var promiseGet10 = Range10_C.get();
    var promiseGet11 = Range11_C.get();

    $scope.Range1 = 0;
    $scope.Range2 = 0;
    $scope.Range3 = 0;
    $scope.Range4 = 0;
    $scope.Range5 = 0;
    $scope.Range6 = 0;
    $scope.Range7 = 0;
    $scope.Range8 = 0;
    $scope.Range9 = 0;
    $scope.Range10 = 0;
    $scope.Range11 = 0;

    promiseGet2.then(function (pl) {
        $scope.Range2 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.Range3 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.Range4 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet5.then(function (pl) {
        $scope.Range5 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet6.then(function (pl) {
        $scope.Range6 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet1.then(function (pl) {
        $scope.Range1 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet7.then(function (pl) {
        $scope.Range7 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet8.then(function (pl) {
        $scope.Range8 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet9.then(function (pl) {
        $scope.Range9 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet10.then(function (pl) {
        $scope.Range10 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet11.then(function (pl) {
        $scope.Range11 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });


    $scope.labels = ['1-100', '100-200', '200-300', '300-400', '400-500', '500-600', '600-700', '700-800', '800-900',
        '900-1000', '1000+'];

});//N

app.controller("BarCtrl_Distance", function ($scope, Range1, Range2, Range3, Range4, Range5) {

    $scope.options = {
        title: {
            display: true,

        },
    };

    var promiseGet1 = Range1.get();
    var promiseGet2 = Range2.get();
    var promiseGet3 = Range3.get();
    var promiseGet4 = Range4.get();
    var promiseGet5 = Range5.get();

    $scope.Range1 = 0;
    $scope.Range2 = 0;
    $scope.Range3 = 0;
    $scope.Range4 = 0;
    $scope.Range5 = 0;


    promiseGet1.then(function (pl) {
        $scope.Range1 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.Range2 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading PTA', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.Range3 = pl.data;

    },
              function (errorPl) {
                  $log.error('failure loading DBN', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.Range4 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading CPT', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.Range4 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading CPT', errorPl);
              });
    promiseGet5.then(function (pl) {
        $scope.Range5 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading CPT', errorPl);
              });

    $scope.labels = ['1-3', '3-5', '5-7', '7-9', '10+'];

});//N

app.controller("RadarCtrl_FeaturesCount", function ($scope, FeatureCount) {
    $scope.labels = ["WiFi", "TV Area", "Cleaning Service", "Laundry Service", "Entertainment Area", "Study Area", "Transport", "Gym", "Parking"];

    $scope.options = {
        title: {
            display: true,

        }
    };

    var promiseGet1 = FeatureCount.get();
    $scope.featuresData = [];

    promiseGet1.then(function (pl) {
        $scope.featuresData = pl.data;
    },
             function (errorPl) {
                 $log.error('failure loading features', errorPl);
             });
});//N

app.controller("RadarCtrl_FeaturesCountSpecific", function ($scope, FeatureCountSpecific) {
    $scope.labels = ["WiFi", "TV Area", "Cleaning Service", "Laundry Service", "Entertainment Area", "Study Area", "Transport", "Gym", "Parking"];

    $scope.options = {
        title: {
            display: true,

        }
    };

    var promiseGet1 = FeatureCountSpecific.get();
    $scope.featuresData = [];

    promiseGet1.then(function (pl) {
        $scope.featuresData = pl.data;
    },
             function (errorPl) {
                 $log.error('failure loading features', errorPl);
             });
});//N

app.controller("BarCtrl_RentRates", function ($scope, Range1_Rent, Range2_Rent, Range3_Rent) {

    $scope.options = {
        title: {
            display: true,

        },
    };

    var promiseGet1 = Range1_Rent.get();
    var promiseGet2 = Range2_Rent.get();
    var promiseGet3 = Range3_Rent.get();

    $scope.Range1 = 0;
    $scope.Range2 = 0;
    $scope.Range3 = 0;

    promiseGet1.then(function (pl) {
        $scope.Range1 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.Range2 = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading PTA', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.Range3 = pl.data;

    },
              function (errorPl) {
                  $log.error('failure loading DBN', errorPl);
              });

    $scope.labels = ['2000-2500', '2500-3000', '3000+'];
});//B

app.controller("BarCtrl_BuidlingType", function ($scope, buldingTypeGeneral, buldingTypeSpecific) {

    $scope.options = {
        title: {
            display: true,

        },
    };

    var promiseGet1 = buldingTypeGeneral.get();
    var promiseGet2 = buldingTypeSpecific.get();

    $scope.General = [];
    $scope.Specific = [];

    promiseGet1.then(function (pl) {
        $scope.General = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    promiseGet2.then(function (pl) {
        $scope.Specific = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading PTA', errorPl);
              });

    $scope.labels = ['Flat', 'Detatched', 'Semi-Detatched', 'Terraced', 'Attached'];
});
//Services

//Housing Ability
app.service("HA_JHB", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getTotalCapacityAbility/jhb");
    };
});

app.service("HA_PTA", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getTotalCapacityAbility/pta);
    };
});

app.service("HA_DBN", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getTotalCapacityAbility/dbn");
    };
});

app.service("HA_CPT", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getTotalCapacityAbility/cpt");
    };
});


//Accommodated Students
app.service("Accommodated", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommdatedCount/" + getUrlParameter('campus'));
    };
});

app.service("NonAccommodated", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getNonAccommdatedCount/" + getUrlParameter('campus'));
    };
});

//RentRates
app.service("Range1_Rent", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getRentRates/2000,2500," + getUrlParameter('campus'));
    };
});

app.service("Range2_Rent", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getRentRates/2500,3000," + getUrlParameter('campus'));
    };
});

app.service("Range3_Rent", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getRentRates/3000,6000," + getUrlParameter('campus'));
    };
});

//Features
app.service("FeatureCount", function ($http) {

    this.get = function () {
        return $http.get(BASE_URL + "getFeatures/all");
    };
});

app.service("FeatureCountSpecific", function ($http) {

    this.get = function () {
        return $http.get(BASE_URL + "getFeatures/" + getUrlParameter('campus'));
    };

    //debugger;

});


//Capacity
app.service("Range1_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/1,100," + getUrlParameter('campus'));
    };
});

app.service("Range2_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/100,200," + getUrlParameter('campus'));
    };
});

app.service("Range3_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/200,300," + getUrlParameter('campus'));
    };
});

app.service("Range4_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/300,400," + getUrlParameter('campus'));
    };
});

app.service("Range5_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/400,500," + getUrlParameter('campus'));
    };
});

app.service("Range6_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/500,600," + getUrlParameter('campus'));
    };
});

app.service("Range7_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/600,700," + getUrlParameter('campus'));
    };
});

app.service("Range8_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/700,800," + getUrlParameter('campus'));
    };
});

app.service("Range9_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/800,900," + getUrlParameter('campus'));
    };
});

app.service("Range10_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/900,1000," + getUrlParameter('campus'));
    };
});

app.service("Range11_C", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getCapacities/1000,5000," + getUrlParameter('campus'));
    };
});

//Distance
app.service("Range1", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommoListInDistanceRange/1,3," + getUrlParameter('campus'));
    };
});

app.service("Range2", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommoListInDistanceRange/3,5," + getUrlParameter('campus'));
    };
});

app.service("Range3", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommoListInDistanceRange/5,7," + getUrlParameter('campus'));
    };
});

app.service("Range4", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommoListInDistanceRange/7,9," + getUrlParameter('campus'));
    };
});

app.service("Range5", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommoListInDistanceRange/9,100," + getUrlParameter('campus'));
    };
});


//FundingTypes
app.service("Credit", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getByFundingType/Credit");
    };
});

app.service("Cash", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getByFundingType/Cash");
    };
});

app.service("EFT", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getByFundingType/Electronic Fund Transfer (EFT)");
    };
});

//GenderGroupings
app.service("Female", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "genderGroupings/Female");
    };
});

app.service("Male", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "genderGroupings/Male");
    };
});

app.service("Mixed", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "genderGroupings/Mixed");
    };
});

//CountAccPerCampus
app.service("countPerCampus", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "accommodationCounts");
    };
});

//Accred statuses
app.service("accredStatus", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAccommodationsByStatus/all");
    };
});

app.service("accredStatusSpecific", function ($http) {
    //debugger; + getUrlParameter('campus')

    this.get = function () {
        return $http.get(BASE_URL + "getAccommodationsByStatus/" + getUrlParameter('campus'));
    };
});

//BuildingTypes
app.service("buldingTypeGeneral", function ($http) {
    //debugger; + getUrlParameter('campus')

    this.get = function () {
        return $http.get(BASE_URL + "accommodationTypeCounts/all");
    };
});

app.service("buldingTypeSpecific", function ($http) {
    //debugger; + getUrlParameter('campus')

    this.get = function () {
        return $http.get(BASE_URL + "accommodationTypeCounts/" + getUrlParameter('campus'));
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

