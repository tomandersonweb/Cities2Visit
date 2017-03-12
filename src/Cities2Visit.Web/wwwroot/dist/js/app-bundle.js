(function () {

    var module = angular.module("app");

    module.component("citiesComponent", {
        templateUrl: "/app/components/cities.component.html",
        controllerAs: "model",
        controller: ["citiesService", controller]
    });

    function controller(citiesService) {

        var model = this;

        model.cities = [];

        model.$onInit = function () {
            model.listCities();
            model.getQtyVisitedCities();
        };

        model.listCities = function () {
            citiesService.getCities()
                .then(function (response) {
                    model.cities = response;
                })
                .catch(function (error) {
                    //ngToast.danger(error);
                });
        };

        model.addCity = function (newCity) {
            citiesService.addCity(newCity)
                .then(function (response) {
                    model.cities = [];
                })
                .catch(function (error) {
                    //ngToast.danger(error);
                });
        };

        model.getQtyVisitedCities = function () {
            citiesService.getQtyVisitedCities()
                .then(function (response) {
                    model.getQtyVisitedCities = response;
                })
                .catch(function (error) {
                    //ngToast.danger(error);
                });
        };

    }

}());
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