(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('SupplierSaveProductCtrl', SupplierSaveProductCtrl);

  function SupplierSaveProductCtrl($scope, $routeParams, SupplierService, $mdToast, $location) {
    $scope.products = [];
    $scope.supplierProduct = {
      SupplierId: $routeParams.id,
      ProductId: 0,
      Price: 0
    };

    $scope.save = function() {
      SupplierService.postProduct($scope.supplierProduct)
        .then(function() {
          $mdToast.showSimple('Product by supplier saved.');
          $location.path('/#/suppliers/details/' + $routeParams.id);
        });
    };

    SupplierService.getUnassignedProducts($routeParams.id).then(function(response) {
      $scope.products = response.data;
    });
  }
})();
