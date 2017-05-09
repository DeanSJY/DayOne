var app = angular.module('ngApp', []);

app.controller("NoteListControl", function($scope, $http) {
    $scope.book = _gNoteBook;
    $scope.notes = _gNoteBook.NoteList;

    $scope.current = $scope.notes[0] || {};
    $scope.contentUrl = "/NoteBook/NoteViewHtml";

    _gNoteBook = null;

    $scope.select = function(note) {
        $scope.current = angular.copy(note);
        $scope.contentUrl = "/NoteBook/NoteViewHtml";
    };

    $scope.refresh_note_list = function() {
        $http.get("/NoteBook/NoteList?bookId=" + $scope.book.NoteBookId)
            .then(function(response) {
                $scope.notes = response.data;
                if ($scope.current != null && $scope.current.NoteId >= 0) {
                    for (var i in $scope.notes) {
                        if ($scope.notes[i].NoteId === $scope.current.NoteId) {
                            return $scope.current = angular.copy($scope.notes[i]);
                        }
                    }
                }

                $scope.current = angular.copy($scope.notes[0] || {});
            });
    };

    $scope.prepare_create_note = function() {
        $scope.current2 = $scope.current;
        $scope.current = {
            BookId: $scope.book.NoteBookId,
            Title: "",
            Content: ""
        };

        $scope.contentUrl = "/NoteBook/NoteAddHtml";
    };

    $scope.post_create_note = function(newnote, validate) {
        if (validate.$invalid) {
            return alert("标题和内容不能空");
        }

        $http.post("/NoteBook/AddNote", newnote)
            .then(function() {
                $scope.refresh_note_list();
                $scope.contentUrl = "/NoteBook/NoteViewHtml";
            });
    };

    $scope.return_to_view = function() {
        $scope.contentUrl = "/NoteBook/NoteViewHtml";
        $scope.current = $scope.current2;
    };

    $scope.prepare_edit_note = function() {
        $scope.current2 = angular.copy($scope.current);
        $scope.contentUrl = "/NoteBook/NoteEditHtml";
    };

    $scope.post_edit_note = function(validate) {
        if (validate.$invalid) {
            return alert("标题和内容不能空");
        }

        $http.post("/NoteBook/NoteEdit", $scope.current)
            .then(function(response) {
                $scope.refresh_note_list();
                $scope.contentUrl = "/NoteBook/NoteViewHtml";
            });
        //$scope.current = angular.copy($scope.current2);
        //$scope.contentUrl = "/NoteBook/NoteViewHtml";
    };

    $scope.cancel_edit_note = function(validate) {
        $scope.current = angular.copy($scope.current2);
        $scope.contentUrl = "/NoteBook/NoteViewHtml";
    };

    $scope.delete_note = function() {
        $http.delete("/NoteBook/DeleteNote?noteId=" + $scope.current.NoteId)
            .then($scope.refresh_note_list);
    };

    $scope.mark_love_it = function() {
        $scope.current.LoveOrNot = !!!$scope.current.LoveOrNot;
    };

    $scope.mark_love_it_and_post = function() {
        $http.post("/NoteBook/ToggleLoveIt?noteId=" + $scope.current.NoteId, $scope.current)
            .then(function(response) {
                $scope.current.LoveOrNot = response.data || false;
            });
    };
});