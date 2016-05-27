(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('SupplierService', SupplierService);

  function SupplierService($http, basePath) {
    return {
      get: get,
      getAll: getAll,
      post: post,
      postProduct: postProduct,
      put: put,
      delete: deleteSupplier,
      getProduct: getProduct,
      getProducts: getProducts,
      deleteProduct: deleteProduct,
      putProduct: putProduct,
      getUnassignedProducts: getUnassignedProducts
    };

    function putProduct(supplierProduct) {
      return $http.put(basePath + 'api/Supplier/Product', supplierProduct);
    }

    function getProduct(supplierId, productId) {
      return $http.get(basePath + 'api/Supplier/' + supplierId + '/Product/' + productId);
    }

    function deleteProduct(supplierId, productId) {
      return $http.delete(basePath + 'api/Supplier/' + supplierId + '/Product/' + productId);
    }

    function deleteSupplier(id) {
      return $http.delete(basePath + 'api/Supplier/' + id);
    }

    function get(id) {
      return $http.get(basePath + 'api/Supplier/' + id);
    }

    function getProducts(id) {
      return $http.get(basePath + 'api/Supplier/' + id + '/Products');
    }

    function getUnassignedProducts(id) {
      return $http.get(basePath + 'api/Supplier/' + id + '/UnassignedProducts');
    }

    function getAll() {
      return $http.get(basePath + 'api/Supplier');
    }

    function post(supplier) {
      return $http.post(basePath + 'api/Supplier', supplier);
    }

    function postProduct(supplierProduct) {
      return $http.post(basePath + 'api/Supplier/Product', supplierProduct);
    }

    function put(supplier) {
      return $http.put(basePath + 'api/Supplier', supplier);
    }
  }
})();
