var app = angular.module('ngApp', []);

app.controller("NoteListControl", function ($scope, $http) {
    $scope.book = _gNoteBook; 
    $scope.notes = _gNoteBook.NoteList;

    $scope.current = null;
    $scope.contentUrl = "/NoteBook/NoteViewHtml";

    _gNoteBook = null;

    $scope.select = function (note) {
        $scope.current = note;
    };

    $scope.refresh_note_list = function(){
        $http.get("/NoteBook/NoteList?bookId=" + $scope.book.NoteBookId)
            .then(function(response){
                $scope.notes = response.data;
            });
    };

    $scope.prepare_create_note = function(){
        $scope.current = {
            BookId : $scope.book.NoteBookId,
            Title: "",
            Content :""
        };
        $scope.contentUrl = "/NoteBook/NoteAddHtml";
    };

    $scope.post_create_note = function(newnote){
        $http.post("/NoteBook/AddNote", newnote)
            .then(function(){
                $scope.refresh_note_list();
                $scope.contentUrl = "/NoteBook/NoteViewHtml";
            });
    };
});

