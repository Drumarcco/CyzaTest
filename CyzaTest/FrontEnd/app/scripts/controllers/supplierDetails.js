(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('SupplierDetailsCtrl', SupplierDetailsCtrl);

  function SupplierDetailsCtrl($scope, SupplierService, $routeParams, $mdToast) {
    $scope.supplier = {};
    $scope.products = [];

    if ($routeParams.id) {
      SupplierService.get($routeParams.id).then(function(response) {
        $scope.supplier = response.data;
      });

      SupplierService.getProducts($routeParams.id).then(function(response) {
        $scope.products = response.data;
      });
    }

    $scope.deleteSupplierProduct = function (product) {
      var index = $scope.products.indexOf(product);
      console.log(index);
      if (index !== -1) {
        SupplierService.deleteProduct($routeParams.id, product.ProductId).then(function() {
          $scope.products.splice(index, 1);
          $mdToast.showSimple('Deleted successfuly');
        });
      }
    };
  }
})();
