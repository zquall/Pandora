

angular.module('Pandora.controllers', [])
    .controller('HomeCtrl',  ['$scope', function ($scope) {
        $scope.greeting = 'Hello World';
    }])
     .controller('DocumentCtrl', ['$scope', function ($scope) {
         
        $scope.searchClientConfig = {
            searchPlaceholder: 'algo',
            placeholder: 'Seleccione un cliente...', 
            hint: 'Seleccione un cliente', dataSource: [],
            displayExpr: 'customerName', 
            title: 'Buscar Cliente',
            searchEnabled: true,
            width: 200
        };
    }])
    .controller('AboutCtrl', function() {
    });