var app = angular.module('contactManager.services.contact', []);

app.service('contactService', ['$http', function ($http) {
    var getModelAsFormData = function (data) {
        var dataAsFormData = new FormData();
        angular.forEach(data, function (value, key) {
            dataAsFormData.append(key, value);
        });
        return dataAsFormData;
    };

	this.getAllContacts = function(){
		return $http({
			url: '/contact/get',
			method: 'GET'
		});
	};

	this.getContact = function(contactID){
		return $http({
		    url: '/contact/getdetails',
			method: 'GET',
			params: {contactID: contactID}
		});
	};

	this.saveContact = function (contactModel) {
		return $http({
		    url: '/contact/create',
		    method: 'POST',
		    data: getModelAsFormData(contactModel),
		    transformRequest: angular.identity,
		    headers: { 'Content-Type': undefined }
		});
	};

	this.updateContact = function(contactModel){
	    return $http({
	        url: '/contact/update',
	        method: 'POST',
	        data: getModelAsFormData(contactModel),
	        transformRequest: angular.identity,
	        headers: { 'Content-Type': undefined }
	    });
	};
}])