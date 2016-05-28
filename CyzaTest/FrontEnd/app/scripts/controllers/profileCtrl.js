(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('ProfileCtrl', ProfileCtrl);

  function ProfileCtrl($scope, StockMovementService, ProductService, SupplierService) {
    $scope.stockMovements = [];

    StockMovementService.getByUser().then(function(response) {
      $scope.stockMovements = response.data;
      $scope.stockMovements.forEach(function(sm) {
        ProductService.get(sm.ProductId).then(function(response) {
          sm.ProductName = response.data.Name;
        });

        if (sm.SupplierId) {
          SupplierService.get(sm.SupplierId).then(function(response) {
            sm.SupplierName = response.data.Name;
          });
        }
      });
    });
  }
})();
