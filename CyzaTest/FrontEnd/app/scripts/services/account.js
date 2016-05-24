(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('AccountService', AccountService);

  function AccountService($http, Auth, basePath, $location, $rootScope, ACCESS_LEVELS) {
    return {
      signUp: signUp,
      login: login
    };

    function signUp(user) {
      return $http.post(basePath + 'api/account/Register', user).then(function() {
        $location.path('/login');
      });
    }

    function login(user) {
      var data = 'grant_type=password&username=' + user.username +
        '&password=' + user.password;

      $http.post(basePath + 'Token', data, {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded'
        }
      })
      .then(function(response) {
        $rootScope.username = user.username;
        Auth.setUser({
          username: user.username,
          token: 'Bearer ' + response.data.access_token,
          role: ACCESS_LEVELS.user
        });

        $location.path('/dashboard');
      });
    }
  }
})();
