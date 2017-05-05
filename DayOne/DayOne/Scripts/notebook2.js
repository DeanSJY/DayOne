var app = angular.module('ngApp', []);
app.controller("noteCtrl", function($scope, $http) {
    $scope.nav = 1;

    $scope.refresh_notebook_list = function() {
        $http.get("NoteList").then(function(result) {
            $scope.notes = result.data;
        });
    };

    $scope.add = function() {
        //alert($scope.noteName);
        $http.post("AddNoteBook", {
            name: $scope.noteName
        }).then(function(response) {
            $scope.refresh_notebook_list();
        });
    };

    $scope.refresh_notebook_list();
});