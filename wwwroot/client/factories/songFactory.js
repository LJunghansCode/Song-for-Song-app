app.factory('songFactory',['$http', '$location','$route', function(http, location, route){
	var factory = {};


	factory.all_songs = function(callback)
	{
		http.get('/allSongs').then(function(returned_data){
			if(returned_data){
				callback(returned_data);
			}
		});
	};
	factory.new_song = function(song)
	{	
		http.post("/new_song", song)
			  	.then(function(returned_data){		
				 console.log(returned_data);	    
		});
	};
	factory.getOne = function(id, callback)
	{
		http.post("/getOneSong/" + id.id)
		.then(function(returned_data){
			callback(returned_data.data);
		});
	};
	return factory;
}]);