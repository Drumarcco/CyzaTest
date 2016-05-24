(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('ProductService', ProductService);

  function ProductService($http, basePath) {
    return {
      get: get,
      getAll: getAll,
      post: post,
      put: put,
      delete: deleteProduct
    };

    function deleteProduct(id) {
      return $http.delete(basePath + 'api/Product/' + id);
    }

    function get(id) {
      return $http.get(basePath + 'api/Product/' + id);
    }

    function getAll() {
      return $http.get(basePath + 'api/Product');
    }

    function post(product) {
      return $http.post(basePath + 'api/Product', product);
    }

    function put(product) {
      return $http.put(basePath + 'api/Product', product);
    }
  }
})();
