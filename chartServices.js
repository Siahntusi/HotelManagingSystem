/// <reference path="chartApp.js" />

//Services
app.service("countCPT", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/CPT");
    };
});

app.service("countJHB", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/jhb");
    };
});

app.service("countPTA", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/pta");
    };
});
app.service("countDBN", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/dbn");
    };
});
