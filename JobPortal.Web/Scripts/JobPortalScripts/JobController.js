app.controller('JobController', function ($scope, $http) {

    $scope.test = "job controller";

    function GetCurrentUser() {
        $http.get('', function (response) {

        });
    };
});