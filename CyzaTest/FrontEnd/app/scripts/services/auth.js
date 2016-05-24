(function() {
  'use strict';
  angular.module('cyzaTestApp').factory('Auth', AuthService);

  function AuthService(localStorageService, ACCESS_LEVELS, $location) {

    return {
      isAuthorized: isAuthorized,
      setUser: setUser,
      isLoggedIn: isLoggedIn,
      getUser: getUser,
      getId: getId,
      getToken: getToken,
      logout: logout,
    };

    function logout() {
      localStorageService.cookie.remove('user');
      $location.path('/');
    }

    function getToken() {
      var _user = getUser();
      return _user ? _user.token : '';
    }

    function getId() {
      var _user = getUser();
      return _user ? _user._id : null;
    }

    function getUser() {
      return localStorageService.cookie.get('user');
    }

    function isLoggedIn() {
      var _user = getUser();
      return _user ? true : false;
    }

    function isAuthorized(lvl) {
      var _user = getUser();
      if (lvl === 1) { return true; }
      if (!_user) { return false; }
      return _user.role >= lvl;
    }

    function setUser(user) {
      if (!user.role || user.role < 0) {
        user.role = ACCESS_LEVELS.pub;
      }
      localStorageService.cookie.set('user', user);
    }
  }
})();
