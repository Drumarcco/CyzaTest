(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('LoginCtrl', LoginCtrl);

  function LoginCtrl($scope, AccountService) {
    $scope.user = {
      username: '',
      password: ''
    };

    $scope.login = function() {
      AccountService.login($scope.user);
    };
  }
})();
