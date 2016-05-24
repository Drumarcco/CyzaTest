(function() {
    'use strict';
    angular.module('cyzaTestApp').controller('SupplierSaveCtrl', SupplierSaveCtrl);

    function SupplierSaveCtrl($scope, SupplierService, $routeParams, $mdToast, $location) {
      $scope.supplier = {
        Id: 0,
        Name: ''
      };

      if ($routeParams.id) {
        SupplierService.get($routeParams.id).then(function(response) {
          $scope.supplier = response.data;
        });
      }

      $scope.save = function() {
        if ($scope.supplier.Id === 0) {
          SupplierService.post($scope.supplier).then(success);
        } else {
          SupplierService.put($scope.supplier).then(success);
        }

        function success() {
          $mdToast.showSimple('Saved successfully');
          $location.path('/suppliers');
        }
      };
    }
  })();
