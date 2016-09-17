app.controller('JobController', function ($scope, $http) {

    $scope.test = "job controller";

    function GetCurrentUser() {
        $http.get('/job/GetUser/').success(function (response) {
            $scope.isRecruiter = response;
        });
    };

    function GetJobs() {
        $http.get('/job/GetJobs/').success(function (response) {
            $scope.jobs = response;
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
        debugger;
        var x = prompt("Are you sure ?");
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