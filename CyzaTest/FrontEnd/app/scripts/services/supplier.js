(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('SupplierService', SupplierService);

  function SupplierService($http, basePath) {
    return {
      get: get,
      getAll: getAll,
      post: post,
      put: put,
      delete: deleteSupplier
    };

    function deleteSupplier(id) {
      return $http.delete(basePath + 'api/Supplier/' + id);
    }

    function get(id) {
      return $http.get(basePath + 'api/Supplier/' + id);
    }

    function getAll() {
      return $http.get(basePath + 'api/Supplier');
    }

    function post(supplier) {
      return $http.post(basePath + 'api/Supplier', supplier);
    }

    function put(supplier) {
      return $http.put(basePath + 'api/Supplier', supplier);
    }
  }
})();
