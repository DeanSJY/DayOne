app.controller("LoveNoteCtrl", function($scope, $http, paging) {
	$scope.paging = paging;
	$scope.offset = 0;

	$scope.notes = [];
	$scope.currrent = null;

	$scope.load_love_notes = function() {
		$http.get(paging.create_query_url("/NoteBook/LoveNoteList"))
			.then(paging.on_request_completed)
			.then(function(response) {
				$scope.notes = response.data.DataList;
				$scope.current = $scope.notes[0] ||  {};
				
				// if (!!$scope.current){

				// 	for(var i in $scope.notes){
				// 		if ($scope.notes[i].NoteId == $scope.current.NoteId){
				// 			$scope.current = $scope.notes[i];
				// 		}
				// 	}
				// }
			});
	};

	$scope.has_next = function() {
		return $scope.start > 0;
	};

	$scope.has_previous = function() {

	};

	$scope.$on("reload", function() {
		$scope.load_love_notes();
	});
});