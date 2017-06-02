var myApp = angular.module('myApp', []);
myApp.controller('FoodCtrl', function ($scope, $http) {

    $scope.fooditems = "";
    $scope.food = { "Title": "", "Item": "", "Price": "" }

    //Get Food Item
    $http.get("/Food/GetFoodData").then(Success, Error);

    function Success(data) {
        $scope.fooditems = data.data;
    }
    function Error(data) {
        console.log(data);
    }

    //Add Food Item
    $scope.savedata = function (food) {
        $http.post("/Food/AddFoodData", { foodmodeldata: food }).then(Success, Error);

        function Success(data) {
            $scope.fooditems = data.data;
            $scope.food = { "Title": "", "Item": "", "Price": "" }
        }
        function ErrorCallBack(data) {
            console.log(data);
        }
    }

    //Update Food Item
    $scope.updatedata = function (food) {
        debugger;
        $http.post("/Food/UpdateFoodData", { foodmodeldata: food }).then(Success, Error);
        function Success(data) {
            $scope.fooditems = data.data;
            $scope.food = { "Title": "", "Item": "", "Price": "" }
        }
        function ErrorCallBack(data) {
            console.log(data);
        }
    }

    //Select FoodItem By ID
    $scope.selectfood = function (id) {
        $http.post("/Food/GetFoodByID", { foodid: id }).then(Success, Error);
        function Success(data) {
            $scope.food = data.data;
        }
        function ErrorCallBack(data) {
            console.log(data);
        }
    }

    //Delete Food Item
    $scope.deletefood=function(id) {
        $http.post("/Food/DeleteFoodData", { foodid: id }).then(Success, Error);
        function Success(data) {
            $scope.fooditems = data.data;
            $scope.food = { "Title": "", "Item": "", "Price": "" }
        }
        function ErrorCallBack(data) {
            console.log(data);
        }
    }

    $scope.clear = function (food) {
        $scope.food = { "Title": "", "Item": "", "Price": "" };
    }
});