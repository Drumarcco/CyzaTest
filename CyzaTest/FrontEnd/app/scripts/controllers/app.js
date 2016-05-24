(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('AppCtrl', AppCtrl);

  function AppCtrl($rootScope, $scope, Auth) {
    $scope.isLoggedIn = Auth.isLoggedIn;

    if (Auth.isLoggedIn()) {
      $rootScope.username = Auth.getUser().username;
    }
    
    $scope.logout = function() {
      Auth.logout();
    };
  }
})();
