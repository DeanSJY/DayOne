var app = angular.module('ngApp', []);

app.controller("noteCtrl", function($scope, $http) {
    $scope.nav = 1;

    $scope.refresh_notebook_list = function() {
        $http.get("/NoteBook/NoteList").then(function(result) {
            $scope.notes = result.data;
        });
    };

    $scope.add = function() {
        //alert($scope.noteName);
        $http.post("AddNoteBook", {
            name: $scope.noteName
        }).then($scope.refresh_notebook_list);
    };

    $scope.removeBook = function(notebook) {
        $http.delete("/NoteBook/Delete?bookId=" + notebook.NoteBookId)
            .then($scope.refresh_notebook_list);
    };

    $scope.updateBook = function(notebook, newName) {
        $http.post("/NoteBook/UpdateNoteBook?bookId" + notebook.NoteBookId + "&newName=" + newName)
            .then($scope.refresh_notebook_list);
    };

    $scope.addnote = function(onenote){
        onenote =  angular.extend({
            BookId : 0,
            Title: "empty"
            Content: ""
        }, onenote);

        $http.post("/NoteBook/AddNote", onenote)
            .then($scope.refresh_note_list);
    };

    $scope.refresh_notebook_list();
});