(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('SuppliersCtrl', SuppliersCtrl);

  function SuppliersCtrl($scope, SupplierService, $mdToast) {
    $scope.suppliers = [];

    SupplierService.getAll().then(function(response) {
      $scope.suppliers = response.data;
    });

    $scope.delete = function (supplier) {
      var index = $scope.products.indexOf(supplier);
      if(index !== -1) {
        SupplierService.delete(supplier.Id).then(function() {
          $scope.products.splice( index, 1 );
          $mdToast.showSimple('Product deleted successfully.');
        });
      }
    };

  }
})();
