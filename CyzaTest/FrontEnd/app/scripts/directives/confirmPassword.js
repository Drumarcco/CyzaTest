(function() {
  'use strict';
  angular.module('cyzaTestApp').directive('confirmPassword', function() {
    return {
      require: 'ngModel',
      scope: {
        reference: '=confirmPassword'
      },
      link: function (scope, elm, attrs, ctrl) {
        ctrl.$parsers.unshift(function(viewValue) {
          var noMatch = viewValue !== scope.reference;
          ctrl.$setValidity('confirm-password', !noMatch);
          return viewValue;
        });

        scope.$watch('reference', function(value) {
          ctrl.$setValidity('confirm-password', value === ctrl.$viewValue);
        });
      }
    };
  });
})();
