app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider, configService) {
    $locationProvider.hashPrefix('');
    $routeProvider.when('/', { templateUrl: '/app/grafo/grafo.html', controller: 'grafoCtrl as vm' });
}]);
