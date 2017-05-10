(function(angular) {
    "use strict";

    function DayPlanController($scope) {

    }

    function OnePlanController($scope) {
        $scope.plans = ["aaaaaaaaaaaa", "dddddd", "sssssss",
            "sdfsdfdsfsdfsdf"
        ];
    }

    function AddPlanController($scope) {
        $scope.is_adding = false;
        $scope._out_of_editing = true;
        $scope._on_focus = false;

        $scope.prepare_adding = function() {
            $scope.is_adding = true;
        };

        $scope.cancel_adding = function(force) {
            if ($scope._out_of_editing == true || force) {
                $scope.is_adding = false;
            }
        };

        $scope.show_creating = function(){
            return $scope.is_adding;
        };
    }

    app.controller("DayPlanController", DayPlanController)
        .controller("OnePlanController", OnePlanController)
        .controller("AddPlanController", AddPlanController);

})(angular);