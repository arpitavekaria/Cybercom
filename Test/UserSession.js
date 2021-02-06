var User = [];
function sessionDisplay() {

    if (localStorage.getItem('user')) {
        User = JSON.parse(localStorage.getItem('user'));
    }
    var start = new Date(Date.UTC(2012, 02, 30));
    var end = new Date(Date.UTC(2021, 02, 30));
    for (var i in User) {
        document.getElementById("displaytable").innerHTML = document.getElementById("displaytable").innerHTML + "<tr><td>" + User[i].name + "</td><td>" + start + "</td><td>" + end + "</td></tr>";

    }

}