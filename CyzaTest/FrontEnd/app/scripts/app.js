'use strict';

angular
  .module('cyzaTestApp', [
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngMaterial',
    'LocalStorageModule'
  ])
  .config(function ($routeProvider, ACCESS_LEVELS) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        access_level: ACCESS_LEVELS.pub
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl',
        access_level: ACCESS_LEVELS.pub
      })
      .when('/dashboard', {
        templateUrl: 'views/dashboard.html',
        controller: 'DashboardCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/login', {
        templateUrl: 'views/login.html',
        controller: 'LoginCtrl',
        access_level: ACCESS_LEVELS.pub
      })
      .when('/products', {
        templateUrl: 'views/products.html',
        controller: 'ProductsCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/products/create', {
        templateUrl: 'views/product-save.html',
        controller: 'ProductSaveCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/products/update/:id', {
        templateUrl: 'views/product-save.html',
        controller: 'ProductSaveCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/suppliers', {
        templateUrl: 'views/suppliers.html',
        controller: 'SuppliersCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/suppliers/create', {
        templateUrl: 'views/supplier-save.html',
        controller: 'SupplierSaveCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/suppliers/update/:id', {
        templateUrl: 'views/supplier-save.html',
        controller: 'SupplierSaveCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/suppliers/details/:id', {
        templateUrl: 'views/supplier-details.html',
        controller: 'SupplierDetailsCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .when('/suppliers/:id/AddProduct', {
        templateUrl: 'views/supplier-save-product.html',
        controller: 'SupplierSaveProductCtrl',
        access_level: ACCESS_LEVELS.user
      })
      .otherwise({
        redirectTo: '/'
      });
  })
  .config(function($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    var interceptor =
    function($q, $rootScope, Auth) {
      return {
        'response': function(resp) {
          if (resp.config.url === '/api/login') {
            Auth.setToken(resp.data.token);
          }
          return resp;
        },
        'responseError': function(rejection) {
          switch(rejection.status) {
            case 401:
              if (rejection.config.url !== 'api/login') {
                $rootScope.$broadcast('auth:loginRequired');
              }
              break;

            case 403:
              $rootScope.$broadcast('auth:forbidden');
              break;

            case 404:
              $rootScope.$broadcast('page:notFound');
              break;

            case 500:
              $rootScope.$broadcast('server:error');
              break;
          }

          return $q.reject(rejection);
        },
        'request': function(req) {
          req.headers = req.headers || {};
          if (!req.headers.Authorization) {
            req.headers.Authorization = Auth.getToken();
          }
          return req;
        },
        'requestError': function(reqErr) {
          return reqErr;
        }
      };
    };

    $httpProvider.interceptors.push(interceptor);
  })
  .run(function($rootScope, $location, Auth) {
    $rootScope.$on('$routeChangeStart',
    function(evt, next) {
      var nextPath = next.$$route.originalPath;
      if ((nextPath === '/login' || nextPath === '/') && Auth.isLoggedIn()) {
        $location.path('/dashboard');
      }

      if (!Auth.isAuthorized(next.$$route.access_level)) {
        if (Auth.isLoggedIn()) {
          $location.path('/dashboard');
        } else {
          $location.path('/login');
        }
      }
    });
  })
  .value('basePath', 'http://localhost:60691/');
