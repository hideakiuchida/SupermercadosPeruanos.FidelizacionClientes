// MODULE
var safetyAuthApp = angular.module('safetyAuthApp', ['ngResource', 'ngRoute']);

safetyAuthApp.config(function($routeProvider,$httpProvider){
    $httpProvider.defaults.cache=false;
    $routeProvider    
    .when('/account',{
        templateUrl:'account.html',
         controller: 'accountController'
    })    
});


safetyAuthApp.controller('accountController', ['$scope','$log','$resource','$timeout','$filter','$http',function ($scope,$log,$resource,$timeout,$filter, $http) {
    
    /*$scope.uuid = '14218ad6-3d76-4d25-865b-743a428c43ca';
    
    $scope.getAccount= function(){ 
        $http.get('http://localhost:25023/api/v1/puntosoh/account/' + $scope.uuid)
                .success(function (result){
                    $scope.accountResponse = result;
                })
                .error(function(data, status){
                    $scope.errorMessage = data;
                })    
        };*/
    
    var account = {
                    firstName:'',
                    lastName : '',
                    email:'',
                    password : '',
                    companyName: ''
    				};
    
    $scope.accountData = account;
	
    $scope.signUpAccount= function(){        
		var jsonData = {
				SignUpModel:{
							firstName : $scope.accountData.firstName,
							lastName : $scope.accountData.lastName,
							email : $scope.accountData.email,
							password : $scope.accountData.password,
							companyName : $scope.accountData.companyName
							}
					};
            
        $http.post('http://localhost:25023/api/v1/puntosoh/accounts/signup', jsonData)
                .success(function (result){
                    $scope.accountResponse = result;
                })
                .error(function(data, status){
                    $scope.errorMessage = data;
                })  
    };
	
	$scope.loginAccount = function(){
		    var safetyAuthRequest = $http({
                method: 'POST',
                url: 'http://authorization.dev.safetyauth.com/puntosoh/oauth2/token',
                 headers: {
                   'Content-Type': 'application/x-www-form-urlencoded'
                 },
                data : 'username=someone@outlook.com&password=12345678&client_id=bd0a974dfffa48238a9cb5d8ed665374&grant_type=password'
            }).then(function successCallback(response) {
                    $scope.accountResponse = response;
            console.log("Response : " + response.data);
            console.log("Status : " + response.status);
            console.log("StatusText : " + response.statusText);
            }, function errorCallback(response) {
                    $scope.errorMessage = response;
  			});
	};
}]);