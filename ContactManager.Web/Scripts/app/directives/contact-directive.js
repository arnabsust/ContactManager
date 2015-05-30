var app = angular.module('contactManager.directives.contact', []);

app.directive('contactForm', function () {
    return {
        restrict: 'E',
        templateUrl: '/Scripts/app/views/contactForm.html',
        scope: {
            contactModel: '=contactModel',
            errorMessage: "=errorMessage"
        }
    };
});

app.directive("fileUpload", ["$parse",
    function ($parse) {
        return {
            restrict: "A",
            link: function (scope, element, attrs) {
                var model = $parse(attrs.fileUpload);
                var modelSetter = model.assign;
                element.bind("change", function () {
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);