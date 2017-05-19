'use strict';

var app = angular.module('app', ['ngSanitize', 'ui.select']);

angular.module('app')
.controller('ctrl', ['$scope', function ($scope) {

    $scope.Classify = {
        getList: []
    };
    $scope.initClassify = function () {

        $scope.Classify.getList = [
            { id: 1, name: '分类一' },
            { id: 2, name: '分类二' },
            { id: 3, name: '分类三' },
            { id: 4, name: '分类四' }
        ];


        $scope.Classify.getList.selected = {
            "id": 4,
            "name": '分类四'
        }

        $scope.Classify2 = {
            getList: []
        };
        $scope.Classify2.getList.selected = {
            id: 1,
            name: '分类一'
        }
    }
    $scope.initClassify();


    //$scope.selectedItem = $scope.itemArray[4];
}]);