(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('SupplierSaveProductCtrl', SupplierSaveProductCtrl);

  function SupplierSaveProductCtrl($scope, $routeParams, SupplierService, $mdToast, $location) {
    $scope.products = [];
    $scope.supplierProduct = {
      SupplierId: $routeParams.id,
      ProductId: $routeParams.productId || 0,
      Price: 0
    };

    if ($routeParams.productId) {
      SupplierService.getProduct($routeParams.id, $routeParams.productId).then(function(response) {
        $scope.supplierProduct = response.data;
        $scope.products.push(response.data);
      });
    } else {
      SupplierService.getUnassignedProducts($routeParams.id).then(function(response) {
        $scope.products = response.data;
      });
    }

    $scope.save = function() {
      if ($routeParams.productId) {
        SupplierService.putProduct($scope.supplierProduct)
        .then(function() {
          $mdToast.showSimple('Product by supplier updated successfully.');
          $location.path('/suppliers/details/' + $routeParams.id);
        });
      } else {
        SupplierService.postProduct($scope.supplierProduct)
        .then(function() {
          $mdToast.showSimple('Product by supplier saved.');
          $location.path('/suppliers/details/' + $routeParams.id);
        });
      }
    };
  }
})();
