app.factory('userFactory',['$http', '$location','$route', function(http, location, route){
	var factory = {};



	factory.new_user = function(user)
	{	
		http.post("/Register", user)
			  	.then(function(returned_data){		
                      if(returned_data){
                          
                      }    
		});
	};
    factory.login_user = function(user, callback)
    {
        http.post("/Login", user)
            .then(function(returned_data){
               callback(returned_data.data);
               location.url('/Songs');
            });           
    };
    factory.getCurUser = function(callback)
    {
        http.post("/getCurUser")
            .then(function(returned_data){
                callback(returned_data);
            });
    };
	return factory;
}]);