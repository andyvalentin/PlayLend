namespace PlayLend {
    
    angular.module('PlayLend', ['ngRoute']);

    angular.module('PlayLend').factory('authInterceptor',
        ($q: ng.IQService, $window: ng.IWindowService, $location: ng.ILocationService) => {
            return {
                request: (config) => {
                    config.headers = config.headers || {};
                    let token = $window.localStorage.getItem('token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                },
                responseError: (response) => {
                    if (response.status === 401) {
                        $location.path('/');
                    }
                    return response || $q.reject(response);
                }
            };
        });

    angular.module('PlayLend')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');

            $routeProvider
                .when('/login', {
                    templateUrl: "Presentation/ngApp/views/login.html",
                    controller: PlayLend.Controllers.AuthController,
                    controllerAs: "c"
                })
                .when('/register', {
                    templateUrl: "Presentation/ngApp/views/register.html",
                    controller: PlayLend.Controllers.AuthController,
                    controllerAs: "c"
                })
                .when('/boardgamelist', {
                    templateUrl: "Presentation/ngApp/views/boardGameList.html",
                    controller: PlayLend.Controllers.BoardGameListController,
                    controllerAs: "c"
                })
                .when('/', {
                    templateUrl: "Presentation/ngApp/views/home.html",
                })
                .when('/userprofile', {
                    templateUrl: "Presentation/ngApp/views/userProfile.html",
                    controller: PlayLend.Controllers.UserProfileController,
                    controllerAs: "c"
                });                
        });
}