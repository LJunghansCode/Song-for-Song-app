app.controller('userController',['$scope', '$location', '$route', 'userFactory', 'youtubeFactory', function(scope, location, route, userFact, YTfactory){

	scope.new_user = function(){
            if(!scope.newUser.FirstName || !scope.newUser.LastName || !scope.newUser.Password || !scope.newUser.Email || !scope.newUser.Confirm)
			{
			scope.errors = "Looks like you missed a field... Please fill out all fields";
            }
			else if(scope.newUser.FirstName.length < 2 || scope.newUser.LastName.length < 2)
			{
			scope.errors = "Please enter a proper Name.";
			}
			else if(scope.newUser.Password.length < 8)
			{	
	        scope.errors = "Please enter a password with 8 char or more.";
			}else{
			userFact.new_user(scope.newUser);
            route.reload();}
			};

        scope.login_user = function()
        {   
            userFact.login_user(scope.loginUser, function(data){
                if(!data){
                    scope.errors = "Sorry, something went wrong" ;
                    }
            console.log(data.FirstName);
            });
        };
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
}]);