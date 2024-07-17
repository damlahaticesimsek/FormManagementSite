var app = angular.module('formManagementApp', []);

// Form Controller
app.controller('formController', ['$scope', '$http', function ($scope, $http) {
    $scope.forms = []; 
    $scope.searchQuery = '';

    $scope.loadForms = function () {
        $http.get('/api/form').then(function (response) {
            $scope.forms = response.data; 
        }, function (error) {
            console.error('Error loading forms:', error); 
        });
    };

    $scope.loadForms();
}]);



// Authentication Controller
app.controller('authenticationController', ['$scope', '$http', function ($scope, $http) {
    $scope.loginData = { username: '', password: '' };
    $scope.errorMessage = '';

    $scope.login = function () {
        $http.post('/api/authentication/login', $scope.loginData).then(function (response) {
            if (response.data.success) {
                window.location.href = '/Form'; 
            } else {
                $scope.errorMessage = response.data.message;
            }
        }, function (error) {
            $scope.errorMessage = 'An error occurred during login.';
        });
    };
}]);