(function () {

    var module = angular.module("app");

    module.factory("citiesService", ["$http", "$q", function ($http, $q) {

        return {
            getCities: getCities,
            addCity: addCity,
            editCity: editCity,
            getQtyVisitedCities: getQtyVisitedCities
        };

        function getCities() {
            return $http.get(config.baseUri + 'cities')
                .then(function (response) {
                    return response.data;
                })
                .catch(function (response) {
                    return $q.reject("Response status: " + response.status + " (" + response.statusText + ")<br /> " + response.data.message);
                });
        }

        function addCity(name) {
            return $http.post(config.baseUri + 'cities/' + name)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (response) {
                    return $q.reject("Response status: " + response.status + " (" + response.statusText + ")<br /> " + response.data.message);
                });
        }

        function editCity(name, city) {
            return $http.put(config.baseUri + 'cities/' + name)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (response) {
                    return $q.reject("Response status: " + response.status + " (" + response.statusText + ")<br /> " + response.data.message);
                });
        }

        function getQtyVisitedCities() {
            return $http.get(config.baseUri + 'cities/visited')
                .then(function (response) {
                    return response.data;
                })
                .catch(function (response) {
                    return $q.reject("Response status: " + response.status + " (" + response.statusText + ")<br /> " + response.data.message);
                });
        }

    }]);

}());