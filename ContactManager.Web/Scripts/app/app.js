var app = angular.module('contactManager', [
	'ui.router',
	'contactManager.controllers.contact'
]);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
		.state('contacts', {
		    url: '/',
		    templateUrl: '/Scripts/app/views/contacts.html',
		    controller: 'contactListCtrl'
		})
		.state('contactDetails', {
		    url: '^/details/:contactID',
		    templateUrl: '/Scripts/app/views/contactDetails.html',
		    controller: 'contactDetailsCtrl'
		})
		.state('addContact', {
		    url: '^/add',
		    templateUrl: '/Scripts/app/views/addContact.html',
		    controller: 'addContactCtrl'
		})
        .state('editContact', {
            url: '^/edit/:contactID',
            templateUrl: '/Scripts/app/views/editContact.html',
            controller: 'editContactCtrl'
        })
}]);