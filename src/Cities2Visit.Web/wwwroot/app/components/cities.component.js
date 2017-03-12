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