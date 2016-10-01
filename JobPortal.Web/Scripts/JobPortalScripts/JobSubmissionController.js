app.controller('JobSubmissionController', function ($scope, $http) {
    //$scope.test = "job submission controller";
    function GetSubmissions() {
        $http.get('/job/GetSubmissions/').success(function (response) {
            $scope.JobSubmissions = response;
            angular.forEach($scope.JobSubmissions, function (obj) {
                obj.AppliedDate = $scope.GetDateFormat(obj.AppliedDate.substr(6));
            });
        });
    };

    $scope.GetDateFormat = function (dateString) {      
        var currentTime = new Date(parseInt(dateString));
        var month = currentTime.getMonth() + 1;
        var day = currentTime.getDate();
        var year = currentTime.getFullYear();
        var date = day + "/" + month + "/" + year;
        return date;
    };

    GetSubmissions();
});