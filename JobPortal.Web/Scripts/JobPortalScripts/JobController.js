app.controller('JobController', function ($scope, $http) {

    app.directive('fileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var model = $parse(attrs.fileModel);
                var modelSetter = model.assign;

                element.bind('change', function () {
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);

    $scope.GetDateFormat = function (dateString) {
        var currentTime = new Date(parseInt(dateString));
        var month = currentTime.getMonth() + 1;
        var day = currentTime.getDate();
        var year = currentTime.getFullYear();
        var date = day + "/" + month + "/" + year;
        return date;
    };

    $scope.test = "job controller";

    function GetCurrentUser() {
        $http.get('/job/GetUser/').success(function (response) {
            $scope.isRecruiter = response;
        });
    };

    function GetJobs() {
        $http.get('/job/GetJobs/').success(function (response) {
            $scope.jobs = response;
            angular.forEach($scope.jobs, function (obj) {
                obj.LastDate = $scope.GetDateFormat(obj.LastDate.substr(6));
            });
        });
    };
    GetCurrentUser();
    GetJobs();

    $scope.EditJob = function (job) {
        $scope.addJob = job;
    };

    $scope.SaveJob = function (job) {
        if (job.Id > 0) {
            $http.post('/job/UpdateJob?job=' + JSON.stringify(job)).success(function (response) {
                $scope.addJob = {};
                GetJobs();
            });
        } else {
            $http.post('/job/AddJob?job=' + JSON.stringify(job)).success(function (response) {
                $scope.addJob = {};
                GetJobs();
            });
        }
    };

    $scope.ApplyJob = function (job) {        
        $scope.fileModel = null;        
        $http.post('/job/ApplyJob?job=' + JSON.stringify(job)).success(function (response) {
            $scope.addJob = {};
            GetJobs();
        });
    };

    $scope.DeleteJob = function (jobId) {
        $http.post('/job/DeleteJob?jobId=' + jobId).success(function (response) {
            GetJobs();
        });
    };
});