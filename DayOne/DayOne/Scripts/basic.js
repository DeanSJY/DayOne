(function() {
	"use strict";

	function longdate($filter) {
		return function(input, uppercase) {
			if (input.startsWith("/Date")) {
				input = 'new ' + input.substring(1, input.length - 1);
			}
			return $filter('date')(eval(input), 'yy-MM-dd HH:mm');
		};

	}

	function shortdate($filter) {
		if (input.startsWith("/")) {
			input = 'new ' +input.substring(1, input.length - 1);
		}
		return $filter('date')(eval(input), 'yy-MM-dd');
	}

	function timeonly($filter) {
		if (input.startsWith("/")) {
			input = 'new ' +input.substring(1, input.length - 1);
		}
		return $filter('date')(eval(input), 'HH:mm:ss');
	}


	angular.module('ngApp')
		.filter('longdate', ['$filter', longdate])
		.filter('shortdate', ['$filter', shortdate])
		.filter('shortdate', ['$filter', timeonly]);

})();