app.controller("NoteBookViewCTRL", function($scope) {
    $scope._searchText = "";

    $scope.reload = function() {
        $scope.$broadcast("reload", {
            searchText: $scope._searchText
        });
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

/* 笔记列表控制器 */
function create_note_list_control(fQuery) {
    return function($scope, $http, paging) {
        $scope.paging = paging;
        $scope.offset = 0;

        $scope.notes = [];
        $scope.current = null;
        $scope.args = {};

        paging.limit(5);

        // $scope.load_love_notes = function(filters) {
        //     $http.get(paging.create_query_url("/NoteBook/LoveNoteList"))
        //         .then(paging.on_request_completed)
        //         .then(function(response) {
        //             $scope.notes = response.data.DataList;
        //             $scope.current = $scope.notes[0] || {};
        //         });
        // };

        $scope.next = function() {
            $scope.paging.prev();
            fQuery($scope.args, $scope, $http, paging);
        };

        $scope.prev = function() {
            $scope.paging.next();
            fQuery($scope.args, $scope, $http, paging);
        };

        $scope.$on("reload", function(event, args) {
            $scope.args = args || $scope.args;
            $scope.paging.reset();
            fQuery($scope.args, $scope, $http, paging);
        });

        fQuery($scope.args, $scope, $http, paging);
    }
}

function query_love_notes(filters, $scope, $http, paging) {
    var url = "/NoteBook/LoveNoteList";
    if (filters.searchText) {
        url = url + "?searchText=" + filters.searchText + "&";
    }

    $http.get(paging.create_query_url(url))
        .then(paging.on_request_completed)
        .then(function(response) {
            $scope.notes = response.data.DataList;
            $scope.current = $scope.notes[0] || {};
        });
}

function query_all_notes(filters, $scope, $http, paging) {
    var url = "/NoteBook/AllNoteList";
    if (filters.searchText) {
        url = url + "?searchText=" + filters.searchText + "&";
    }

    $http.get(paging.create_query_url(url))
        .then(paging.on_request_completed)
        .then(function(response) {
            $scope.notes = response.data.DataList;
            $scope.current = $scope.notes[0] || {};
        });

    //query_love_notes(filters, $scope, $http, paging);
}

app.controller("LoveNoteCtrl", ['$scope', '$http', 'paging', create_note_list_control(query_love_notes)])
    .controller("AllNoteCTRL", ['$scope', '$http', 'paging', create_note_list_control(query_all_notes)]);