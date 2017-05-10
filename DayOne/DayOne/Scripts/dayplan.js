(function(angular) {
    "use strict";

    function DayPlanController($scope) {

    }

    function OnePlanController($scope, $http, paging) {
        $scope.plans = ["aaaaaaaaaaaa", "dddddd", "sssssss",
            "sdfsdfdsfsdfsdf"
        ];
        $scope.paging = paging;
        $scope.title = "日计划";
        $scope.plantype = "day";

        $scope.setplantype = function(plantype) {
            switch (plantype) {
                case "day":
                    $scope.title = "日计划";
                    break;
                case "week":
                    $scope.title = "周计划";
                    break;
                case "month":
                    $scope.title = "周计划";
                    break;
                case "year":
                    $scope.title = "年计划";
                    break;
            }
            this.plantype = plantype;
        };

        $scope.refresh_task_list = function() {
            $http.get('/dayplan/list?start=0&limit=1000&&type=' + $scope.plantype)
                .then(paging.on_request_completed)
                .then(function(response) {
                    $scope.plans = response.data.DataList;
                });
        };

        $scope.refresh_task_list();
    }

    function AddPlanController($scope) {
        $scope.is_adding = false;
        $scope._out_of_editing = true;
        $scope._on_focus = false;

        $scope.creating = {
            PlanType : $scope.$parent.plantype,
            Content : '',
            ExpectEntAt: '',
            LoveOrNot: false
        };

        $scope.prepare_adding = function() {
            $scope.is_adding = true;
            $scope.creating = {
                PlanType : $scope.$parent.plantype,
                Content : '',
                ExpectEntAt: '',
                LoveOrNot: false
            };
        };

        $scope.cancel_adding = function(force) {
            if ($scope._out_of_editing == true || force) {
                $scope.is_adding = false;
            }
        };

        $scope.post_create = function(){
            console.log($scope.creating);
            $http.post("/dayplan/AddPlan", $scope.creating)
                .then(function(){
                    console.log(arguments);
                });
        };

        $scope.show_creating = function() {
            return $scope.is_adding;
        };
    }

    app.controller("DayPlanController", DayPlanController)
        .controller("OnePlanController", OnePlanController)
        .controller("AddPlanController", AddPlanController);

})(angular);