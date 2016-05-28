(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('RestockCtrl', StockCtrl);

  function StockCtrl($scope, SupplierService, StockMovementService, $mdToast) {
    $scope.suppliers = [];
    $scope.products = [];

    $scope.restockMovement = {
      SupplierId : 0,
      ProductId: 0,
      Quantity: 1
    };

    $scope.restock = function() {
      StockMovementService.restock($scope.restockMovement).then(function() {
        $mdToast.showSimple('Stock updated successfully');
      });
    };

    $scope.loadProducts = function() {
      SupplierService.getProducts($scope.restockMovement.SupplierId).then(
        function(response) {
          $scope.products = response.data;
        }
      );
    };

    SupplierService.getAll().then(function(response) {
      $scope.suppliers = response.data;
    });


  }
})();
