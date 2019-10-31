/// <reference path="chartApp.js" />
/// <reference path="chartServices.js" />

app.controller("pieChartController", function ($scope, countJHB , countCPT/*, countAPB, countDFC*/) {
    // debugger;
    var promiseGet1 = countCPT.get();
    var promiseGet2 = countJHB.get();
    //var promiseGet3 = countAPB.get();
    //var promiseGet4 = countDFC.get();

    $scope.NumJHB = 0;
    //$scope.NumAPB = 0;
    //$scope.NumDFC = 0;
    $scope.NumCPT = 0;

    promiseGet1.then(function (pl) {
        $scope.NumJHB = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading JHB', errorPl);
              });
    //promiseGet2.then(function (pl) {
    //    $scope.NumAPB = pl.data;
    //},
    //          function (errorPl) {
    //              $log.error('failure loading APB', errorPl);
    //          });
    //promiseGet3.then(function (pl) {
    //    $scope.NumDFC = pl.data;
    //},
    //          function (errorPl) {
    //              $log.error('failure loading DFC', errorPl);
    //          });
    promiseGet4.then(function (pl) {
        $scope.NumSWC = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading SWC', errorPl);
              });
    //$scope.totalNum = $scope.NumAPB + $scope.NumAPK + $scope.NumDFC + $scope.NumSWC;

    //$scope.chartData = [$scope.NumAPK / $scope.totalNum, $scope.NumAPB / $scope.totalNum, $scope.NumDFC / $scope.totalNum, $scope.NumSWC / $scope.totalNum];
});
