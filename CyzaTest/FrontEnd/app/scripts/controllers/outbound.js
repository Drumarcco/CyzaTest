(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('OutboundCtrl', OutboundCtrl);

  function OutboundCtrl($scope, $routeParams, ProductService, StockMovementService,
  $mdToast) {
    $scope.product = {};
    $scope.outboundMovement = {
      ProductId: $routeParams.productId,
      Quantity: 1
    };

    $scope.outbound = function() {
      StockMovementService.outbound($scope.outboundMovement).then(function() {
        $mdToast.showSimple('Outbound registered successfully');
      });
    };

    ProductService.get($routeParams.productId).then(function(response) {
      $scope.product = response.data;
    });
  }
})();
