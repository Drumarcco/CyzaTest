(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('ProductsCtrl', ProductsCtrl);

  function ProductsCtrl($scope, ProductService, $mdToast){
    $scope.products = [];

    $scope.delete = function (product) {
      var index = $scope.products.indexOf(product);
      if(index !== -1) {
        ProductService.delete(product.Id).then(function() {
          $scope.products.splice( index, 1 );
          $mdToast.showSimple('Product deleted successfully.');
        });
      }
    };

    ProductService.getAll().then(function(response) {
      $scope.products = response.data;
    });
  }
})();
