(function(angular){
	"use strict";

	var app=angular.module("app",[]);
	app.controller("mainCtrl",["$scope",function($scope){
		$scope.nav=1;
	}])
})(angular);