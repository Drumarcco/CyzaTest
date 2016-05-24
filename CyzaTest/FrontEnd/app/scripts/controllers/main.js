(function() {
  'use strict';
  angular.module('cyzaTestApp')
    .controller('MainCtrl', function ($scope, AccountService) {
      $scope.user = {
        Email: '',
        Password: '',
        ConfirmPassword: ''
      };

      $scope.signUp = function() {
        AccountService.signUp($scope.user);
      };
    });
})();
