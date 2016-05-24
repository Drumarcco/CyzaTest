(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('ProductSaveCtrl', ProductSaveCtrl);

  function ProductSaveCtrl($scope, ProductService, $routeParams, $mdToast, $location){
    $scope.product = {
      Id: 0,
      Name: ''
    };

    if ($routeParams.id) {
      ProductService.get($routeParams.id).then(function(response) {
        $scope.product = response.data;
      });
    }

    $scope.save = function() {
      if ($scope.product.Id === 0) {
        ProductService.post($scope.product).then(success);
      } else {
        ProductService.put($scope.product).then(success);
      }

      function success() {
        $mdToast.showSimple('Saved successfully');
        $location.path('/products');
      }
    };
  }
})();
