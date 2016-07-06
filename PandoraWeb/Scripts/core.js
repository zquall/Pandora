
var yourNamespace = {

    foo: function () {
        console.log("Foo!");
    },

    bar: function () {
        console.log("Bar!");
    }
};

var CustomerManager = {
    LoadCustomer: function (s, e) {
        var customerId = s.GetSelectedItem().value;
        console.log("Loading Customer! " + customerId);
    }
};

// Angular JS Code

// (function () {

var pandora = angular.module("pandora", ["dx"]);

// Register Controllers 
pandora.controller("documentController", function ($scope, $http) {

        $scope.Customer.Id = "";

        // Promises
        var onLoadCustomer = function (response) {
            $scope.Customer = response.data;
        };

        var onError = function(response) {
            $scope.error = response.message;
        };

        $scope.search = function() {
            $http.get("Pithos/api/Customer/" + $scope.Customer.Id).then(onLoadCustomer, onError);
        };
    }
);

// }());