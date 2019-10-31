/// <reference path="../../Scripts/angular.min.js" />
/// <reference path="dirPagination.js" />


//App variable
var app;


//**************Acc Manage Accommo Get All************//
//Module
(function () {
    app = angular.module("MyAccommoModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoController", function ($scope, AccommoService) {
    // debugger;
    $scope.Accommodations = [];
    var promiseGet = AccommoService.get();

    promiseGet.then(function (pl) {
        $scope.Accommodations = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Hotels', errorPl);
              });
});
//Services
app.service("AccommoService", function ($http) {
    //var ownrId = '@Session["ID"]';
    //var ownrId = '<%= Session["ID"] %>';
    //$scope.cookie = $cookieStore.get('Name');
    //var ownrId = $cookieStore.get('OwnrID');
   
    //var ownrId = angular.element(document.querySelector('#lblOwnerID'));
    //var ownrId = angular.element($document[0].querySelector('#lblOwnerID'))
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/AccommodationServices.svc/getAccommoByOwnerId/" + getUrlParameter('OwnrID')); // Change to parameter
    };
});
//*****************End Acc Manage Accommo*********//


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