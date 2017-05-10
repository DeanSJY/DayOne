app.controller("NoteBookViewCTRL", function($scope, ) {

    $scope.reload = function() {
        $scope.$broadcast("reload");
    };
});

app.controller("noteCtrl", function($scope, $http) {
    $scope.nav = 1;
    $scope.current = null;

    $scope.select = function(note) {
        $scope.current = note;
    };

    $scope.refresh_notebook_list = function() {
        $http.get("/NoteBook/NoteBookList").then(function(result) {
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

    $scope.updateBook = function(notebook) {
        $http.post("/NoteBook/UpdateNoteBook?bookId=" + notebook.NoteBookId + "&newName=" + notebook.BookName)
            .then($scope.refresh_notebook_list);
    };

    $scope.addnote = function(onenote) {
        onenote = angular.extend({
            BookId: 0,
            Title: "empty",
            Content: ""
        }, onenote);

        $http.post("/NoteBook/AddNote", onenote)
            .then($scope.refresh_note_list);
    };

    $scope.refresh_notebook_list();
});