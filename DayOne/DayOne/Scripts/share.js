(function(angular) {
	"user strict";

	function ShareFiltersCTRL($scope) {
		//$scope._all = true;
		$scope._note_only = true;
		$scope._plan_only = true;
		$scope._my_only = false;

		$scope.showAll = function() {
			return $scope._note_only && $scope._plan_only && !$scope._my_only;
		};

		$scope.toggleNote = function() {
			$scope._show_note = !!!$scope._show_note;
		};

		$scope.toggleAll = function() {
			$scope._note_only = true;
			$scope._plan_only = true;
			$scope._my_only = false;
			$scope.reload();
		};

		$scope.toggleNote = function() {
			$scope._note_only = !!!$scope._note_only;
			if (!$scope._note_only && !$scope._plan_only) {
				$scope._plan_only = true;
			}
			$scope.reload();
		};

		$scope.togglePlan = function() {
			$scope._plan_only = !!!$scope._plan_only;
			if (!$scope._note_only && !$scope._plan_only) {
				$scope._note_only = true;
			}
			$scope.reload();
		};

		$scope.toggleMy = function() {
			$scope._my_only = !!!$scope._my_only;
			$scope.reload();
		};

		$scope.reload = function() {
			var reload_args = {
				OnlyMyself: $scope._my_only,
				IncludeNote: $scope._note_only,
				IncludePlan: $scope._plan_only,
				Text: $scope._searchText
			};

			$scope.$emit('__reload', reload_args);
		};
	}

	function ShareCTRL($scope, $http, paging) {
		$scope.shareList = [];
		paging.limit(4);
		$scope.paging = paging;

		$scope._queryArgs = {};

		function query_share_list(args) {
			$scope._queryArgs = args || $scope._queryArgs;

			$http.post('/share/query', paging.create_post_args($scope._queryArgs))
				.then(paging.on_request_completed)
				.then(function(response) {
					$scope.shareList = response.data.DataList;
				});
		}

		$scope.$on('__reload', function($event, $args) {
			$event.stopPropagation();
			$event.preventDefault();
			
			$scope.paging.reset();
			query_share_list($args);
		});

		$scope.get = function(index) {
			return $scope.shareList[index];
		};

		$scope.prev = function() {
			$scope.paging.next();
			query_share_list();
		};

		$scope.next = function() {
			$scope.paging.prev();
			query_share_list();
		};

		query_share_list();
	}

	function ShareViewCTRL($scope, $http) {
		$scope.item = null;

		$scope.$watch(function() {
			return $scope.get($scope.index);
		}, function(newval) {
			$scope.item = newval;
		});

		$scope.togglePraised = function() {
			$http.get("/share/ToggleLoveIt?shareId=" + $scope.item.Id)
				.then(function(response) {
					if ($scope.item.IsMyPraised) {
						$scope.item.IsMyPraised = response.data;
						if (!$scope.item.IsMyPraised) {
							$scope.item.LoveCount -= 1;
						}
					} else {
						$scope.item.IsMyPraised = response.data;
						if ($scope.item.IsMyPraised) {
							$scope.item.LoveCount += 1;
						}
					}
				});
		};
	}

	app.controller('ShareCTRL', ['$scope', '$http', 'paging', ShareCTRL])
		.controller('ShareFiltersCTRL', ['$scope', ShareFiltersCTRL])
		.controller('ShareViewCTRL', ['$scope', '$http', ShareViewCTRL]);
})(angular);