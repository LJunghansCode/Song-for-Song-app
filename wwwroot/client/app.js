var app = angular.module('app', ['ngRoute', 'ngSanitize', 'jtt_youtube', 'youtube-embed']);

app.config(function($routeProvider) {
		$routeProvider
		    .when('/Song/:id', {
				templateUrl : '/client/partials/singleSong.html'
			})
			.when('/User/:id', {
				templateUrl : '/client/partials/singleSong.html'
			})
			.when('/AllSongs', {
				templateUrl : '/client/partials/AllSongs.html'
			})	
			.when('/Register', {
				templateUrl: ("/client/partials/register.html")
			})
			.when('/homeLogin', {
				templateUrl: ("/client/partials/login.html")
			})
			.when('/Songs', {
				templateUrl: ("/client/partials/mainSong.html")
			})
			.otherwise('/', {
				redirect: ("/Shared/Index.cshtml")
			});
});

app.filter('trusted', ['$sce', function ($sce) {
    return function(url){
        return $sce.trustAsResourceUrl(url);
    };
}]);
