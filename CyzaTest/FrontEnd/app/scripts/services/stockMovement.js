(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('StockMovementService', StockMovementService);

  function StockMovementService($http, basePath) {
    return {
      restock: restock,
      outbound: outbound
    };

    function restock(stockMovement) {
      return $http.post(basePath + 'api/StockMovement/Inbound', stockMovement);
    }

    function outbound(stockMovement) {
      return $http.post(basePath + 'api/StockMovement/Outbound', stockMovement);
    }
  }
})();
