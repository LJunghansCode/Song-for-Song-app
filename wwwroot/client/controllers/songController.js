app.controller('songController',['$scope', '$location', '$route','$routeParams', 'songFactory', 'youtubeFactory', 'userFactory',  function(scope, location, route, routeParams, songFact, YTfactory, userFact){
	var all_songs = function(){
		songFact.all_songs(function(returned_data){
			scope.songs = returned_data.data;	
		});
		 scope.getEmbed = function(embedLink)
	{
        return( 'http://www.youtube.com/embed/' + embedLink );
    };
	};
	scope.new_song = function(){
			if(!scope.userFirstName){
			scope.errors = "Please Login/Register to submit Music";
			}
			if(!scope.newSong.Title || !scope.newSong.Artist || !scope.newSong.Genre || !scope.newSong.Description) 
			{
			scope.errors = "Looks like you missed a field... Please fill out all fields";
			}
			else if(scope.newSong.Description.length < 5)
			{
			scope.errors = "Please enter a proper definition.";
			}
			else if(!scope.newSong.EmbedLink && scope.userFirstName)
			{	
			scope.newSong.EmbedLink = 	
				YTfactory.getVideosFromSearchByParams({
					q: (scope.newSong.Artist + scope.newSong.Title),
						key : 'AIzaSyBvvYhxfqfmmQ3CDGSTvO0CDpD0aJVIkG8',
						order : 'relevance'
					})
					.then(function(data)
					{
						scope.newSong.EmbedLink = data.data.items[0].id.videoId;
						songFact.new_song(scope.newSong);
						route.reload();
					});
			}
			else
			{
				if(!scope.userFirstName){
				scope.errors = "Please Login/Register to submit Music";
					}
 			route.reload();
			}

	
	}; 
	if(routeParams.id){
		songFact.getOne(routeParams, function(data){
			console.log(data);
			scope.showOne = data;
		});
	}
        var cur_user = function(data)
        {
            userFact.getCurUser(function(returned_data){
                if(returned_data.data)
                {
                console.log(returned_data.data);
                scope.userFirstName = returned_data.data.firstName;
                }
            });
        };
    cur_user();
	all_songs();
}]);