(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('StockMovementService', StockMovementService);

  function StockMovementService($http, basePath) {
    return {
      restock: restock
    };

    function restock(stockMovement) {
      return $http.post(basePath + 'api/StockMovement/Inbound', stockMovement);
    }
  }
})();
