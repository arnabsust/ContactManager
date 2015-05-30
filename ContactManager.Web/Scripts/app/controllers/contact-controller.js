var app = angular.module('contactManager.controllers.contact', [
    'ngSanitize',
	'contactManager.services.contact',
    'contactManager.directives.contact'
]);

app.controller('contactListCtrl', ['$scope', 'contactService', function ($scope, contactService) {
    $scope.contactList = [];

    $scope.orderByField = 'Name';
    $scope.reverseSort = false;

    $scope.init = function () {
        contactService.getAllContacts().then(function (res) {
            $scope.contactList = res.data;
        });
    }
}]);

app.controller('contactDetailsCtrl', ['$scope', '$stateParams', 'contactService',
function ($scope, $stateParams, contactService) {
    $scope.contactModel = {};

    $scope.init = function () {
        contactService.getContact($stateParams.contactID).then(function (res) {
            $scope.contactModel = res.data;
        });
    }
}]);

app.controller('addContactCtrl', ['$scope', '$state', '$sce', 'contactService',
function ($scope, $state, $sce, contactService) {
    $scope.contactModel = {};
    $scope.errorMessage = "";

    $scope.submit = function (isValid) {
        if (isValid) {
            contactService.saveContact($scope.contactModel).then(function (res) {
                if (res.data.Success) {
                    $state.go('contacts');
                } else {
                    if (res.data.ErrorMessage) {
                        $scope.errorMessage = $sce.trustAsHtml(res.data.ErrorMessage);
                    }
                }
            });
        }
    };
}]);

app.controller('editContactCtrl', ['$scope', '$state', '$sce', '$stateParams', 'contactService',
function ($scope, $state, $sce, $stateParams, contactService) {
    $scope.contactModel = {};
    $scope.errorMessage = "";

    $scope.init = function () {
        contactService.getContact($stateParams.contactID).then(function (res) {
            $scope.contactModel = res.data;
        });
    };

    $scope.submit = function (isValid) {
        if (isValid) {
            contactService.updateContact($scope.contactModel).then(function (res) {
                if (res.data.Success) {
                    $state.go('contacts');
                } else {
                    if (res.data.ErrorMessage) {
                        $scope.errorMessage = $sce.trustAsHtml(res.data.ErrorMessage);
                    }
                }
            });
        }
    };
}]);