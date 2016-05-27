(function() {
  'use strict';
  angular.module('cyzaTestApp').controller('AppCtrl', AppCtrl);

  function AppCtrl($rootScope, $scope, Auth, $mdToast) {
    $scope.isLoggedIn = Auth.isLoggedIn;

    if (Auth.isLoggedIn()) {
      $rootScope.username = Auth.getUser().username;
    }

    $scope.logout = function() {
      Auth.logout();
    };

    $rootScope.$on('server:error', function() {
      $mdToast.showSimple('Oops! Something unexpected happened in our servers.');
    });
  }
})();
