
var app = angular.module("myApp", []).controller("myCtrl1", function ($scope) {

    $scope.firstname = "yinglin";
    $scope.lastname = "xu";
    $scope.fullname = "xuyinglin";
    $scope.sayHello = function () {
        $scope.greeting =$scope.fullname+ "  你好！";
    }

})