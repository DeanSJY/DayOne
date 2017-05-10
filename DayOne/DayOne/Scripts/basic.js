(function() {
	"use strict";

	function _get_date_from_aspnet_json_string(input) {
		if (typeof input === "string" && input.startsWith("/Date")) {
			return eval('new ' + input.substring(1, input.length - 1));
		}
		return input;
	}

	function longdate($filter) {
		return function(input) {
			return $filter('date')(_get_date_from_aspnet_json_string(input), 'yy-MM-dd HH:mm');
		};
	}

	function shortdate($filter) {
		return $filter('date')(_get_date_from_aspnet_json_string(input), 'yy-MM-dd');
	}

	function timeonly($filter) {
		return $filter('date')(_get_date_from_aspnet_json_string(input), 'HH:mm:ss');
	}


	function paging($http) {
		var start = 0;
		var limit = 10;
		var totalCount = 0;
		var dataList = null;

		function hasNext() {
			return start > 0;
		}

		function hasPrevious() {
			return start + limit <= totalCount;
		}

		function next() {
			start = start + limit;
		}

		function prev() {
			start = start - limit;
			if (start <= 0) {
				start = 0;
			}
		}

		function total() {
			return totalCount;
		}

		function create_query_url(url) {
			var p = "start=" + start + "&limit=" + limit;

			if (url.endsWith("?") || url.endsWith("&")) {
				return url + p;
			} else {
				return url + "?" + p;
			}
		}

		function on_request_completed(response) {
			totalCount = response.data.Total;
			return response;
		}

		return {
			next: next,
			prev: prev,
			hasNext: hasNext,
			hasPrev: hasPrevious,
			total: total,
			create_query_url: create_query_url,
			on_request_completed: on_request_completed
		};
	};

	angular.module('ngApp')
		.filter('longdate', ['$filter', longdate])
		.filter('shortdate', ['$filter', shortdate])
		.filter('shortdate', ['$filter', timeonly])
		.factory('paging', ['$http', paging]);

})();