app.controller("RecyleNoteCTRL", function($scope, $http, paging) {
	// $scope.paging = paging;
	// $scope.offset = 0;

	// paging.limit(6);

	// $scope.notes = [];
	// $scope.current = null;
	$scope._recoverying = true;
	
	function load_recovery_notes(filters, $scope, $http, paging) {
		var url = "/NoteBook/RecyleNoteList";
		if (filters.searchText) {
			url = url + "?searchText=" + filters.searchText + "&";
		}

		$http.get(paging.create_query_url(url))
			.then(paging.on_request_completed)
			.then(function(response) {
				$scope.notes = response.data.DataList;
				$scope.current = $scope.notes[0] || {};
			});
	};

	// $scope.next = function() {
	// 	$scope.paging.prev();
	// 	$scope.load_love_notes();
	// };

	// $scope.prev = function() {
	// 	$scope.paging.next();
	// 	$scope.load_love_notes();
	// };

	$scope.setCurrent = function(note) {
		$scope.current = note;
	};

	function remove_from_view_list(note) {
		var index = $scope.notes.indexOf(note);
		if (index > -1) {
			$scope.notes.splice(index, 1);
		}
	}

	$scope.remove_note_final = function(note) {
		$http.delete("/NoteBook/DeleteNote?noteId=" + note.NoteId + "&destroy=true")
			.then(function(response) {
				remove_from_view_list(note);
			});
	};

	$scope.recovery_note = function(note) {
		$http.get("/NoteBook/RecoveryNote?noteId=" + note.NoteId)
			.then(function(response) {
				remove_from_view_list(note);
			});
	};

	create_note_list_control(load_recovery_notes)($scope, $http, paging);
	// $scope.$on("reload", function() {
	// 	$scope.load_love_notes();
	// });

	// $scope.load_love_notes();
});