var User = [];

function displaySession() 
{
	
    if (localStorage.getItem('user')) 
    {
        User = JSON.parse(localStorage.getItem('user'));
    }

    var startSession = new Date(Date.UTC(2021,02,05));
    var endSession = new Date(Date.UTC(2021, 02, 06));

    for (var i in User) 
    {
        document.getElementById("displaytable").innerHTML = document.getElementById("displaytable").innerHTML +
         "<tr><td>" + User[i].name + "</td><td>" + startSession + "</td><td>" + endSession + "</td></tr>";

    }

}