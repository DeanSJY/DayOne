(function(angular) {
    "use strict";

    function DayPlanController($scope) {

    }

    function OnePlanController($scope, $http, paging, ngDialog) {
        $scope.plans = ["aaaaaaaaaaaa", "dddddd", "sssssss",
            "sdfsdfdsfsdfsdf"
        ];
        $scope.paging = paging;
        $scope.title = "日计划";
        $scope.plantype = $scope.plantype || "day";

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
            $scope.refresh_task_list();
        };

        $scope.completeList = function() {
            var completes = [];
            angular.forEach($scope.plans, function(val, key) {
                if (val.IsCompleted) {
                    completes.push(val);
                }
            });
            return completes;
        };

        $scope.workingList = function() {
            var workings = [];
            angular.forEach($scope.plans, function(val, key) {
                if (!val.IsCompleted) {
                    workings.push(val);
                }
            });
            return workings;
        };

        $scope.refresh_task_list = function() {
            $http.get('/dayplan/list?start=0&limit=1000&&type=' + $scope.plantype)
                .then(paging.on_request_completed)
                .then(function(response) {
                    $scope.plans = response.data.DataList;
                });
        };

        $scope.toggleCompleted = function(plan) {
            $http.get('/dayplan/ToggleCompleted?planId=' + plan.PlanId)
                .then(function(response) {
                    plan.IsCompleted = response.data;
                });
        };

        $scope.editing = function(plan) {
            var scope = $scope.$new();
            scope.creating = angular.copy(plan);

            ngDialog.open({
                template: '/dayplan/plan/edit.html',
                className: 'ngdialog-theme-default',
                showClose: false,
                scope: scope
            }).closePromise.then(function(result) {
                $http.post('/dayplan/update', result.value)
                    .then(function(newval) {
                        for (var i in $scope.plans) {
                            if ($scope.plans[i].PlanId == newval.data.PlanId) {
                                return $scope.plans[i] = newval.data;
                            } else {
                                console.log($scope.plans[i].PlanId);
                            }
                        }
                        //angular.extend(plan, newval);
                    });
            });
        };

        $scope.deleting = function(plan, index) {
            var scope = $scope.$new();
            scope.deleting = plan;

            ngDialog.open({
                template: '/dayplan/plan/delete.html',
                showClose: false,
                scope: scope
            }).closePromise.then(function(result) {
                if (!!!result.value) return;
                $http.delete('/dayplan/delete?planId=' + plan.PlanId)
                    .then(function(response) {
                        if (response.data) {
                            delete $scope.plans[index];
                        }
                    });
            });
        };

        $scope.sharing = function(plan, index) {
            var scope = $scope.$new();
            scope.sharing = plan;

            ngDialog.open({
                template: '/dayplan/plan/sharing.html',
                showClose: false,
                scope: scope
            }).closePromise.then(function(result) {
                if (!!!result.value) return;
                $http.get('/dayplan/ToggleShareOrNot?planId=' + plan.PlanId)
                    .then(function(response) {
                        plan.ShareOrNot = response.data;
                    });
            });
        };

        $scope.toggleLove = function(plan, index) {
            $http.delete('/dayplan/ToggleLoveOrNot?planId=' + plan.PlanId)
                .then(function(response) {
                    plan.LoveOrNot = !!response.data;
                });
        };

        $scope.$on('reload', $scope.refresh_task_list);
    }

    function AddPlanController($scope, $http) {
        $scope.is_adding = false;
        $scope._out_of_editing = true;
        $scope._on_focus = false;

        $scope.creating = {
            PlanType: $scope.$parent.plantype,
            Content: '',
            ExpectEndAt: '',
            LoveOrNot: false
        };

        $scope.prepare_adding = function() {
            $scope.is_adding = true;
            $scope.creating = {
                PlanType: $scope.$parent.plantype,
                Content: '',
                ExpectEntAt: '',
                LoveOrNot: false
            };
        };

        $scope.cancel_adding = function(force) {
            if ($scope._out_of_editing == true || force) {
                $scope.is_adding = false;
            }
        };

        $scope.post_create = function() {
            console.log($scope.creating);
            $http.post("/dayplan/AddPlan", $scope.creating)
                .then(function() {
                    $scope.$emit('reload');
                    console.log(arguments);
                });
        };

        $scope.show_creating = function() {
            return $scope.is_adding;
        };
    }

    app.controller("DayPlanController", DayPlanController)
        .controller("OnePlanController", ['$scope', '$http', 'paging', 'ngDialog', OnePlanController])
        .controller("AddPlanController", ['$scope', '$http', AddPlanController]);

})(angular);