var User = [];

function addUser() 
{       
    if (localStorage.getItem('user')) {
        User = JSON.parse(localStorage.getItem('user'));
    }
    var userObj = {};
    userObj.name = document.getElementById("name").value;
    userObj.email = document.getElementById("email").value;
    userObj.password = document.getElementById("password").value;
    userObj.birthdate = document.getElementById("Birthdate").value;
    User.push(userObj);
    localStorage.setItem("user", JSON.stringify(User));
    alert("user added");
}

function displayUserData() 
{
    console.log(User)


    if (localStorage.getItem('user')) {
        User = JSON.parse(localStorage.getItem('user'));
    }
    display();
    function display() {
        if (User === []) 
        {
            document.getElementById("displaytable").innerHTML = "<tr><td>No User Found</td></tr>";
        }
        else 
        {
        for (var i in User) {
            document.getElementById("displaytable").innerHTML = document.getElementById("displaytable").innerHTML + "<tr id="+i+"><td>" + 
            User[i].name + "</td><td>" + User[i].email + "</td><td>" + User[i].password + "</td><td>" + User[i].birthdate + 
            "</td><td><button id=" + i + " onclick='editUser(id)'>edit</button></td><td><button id=" + i + " onclick='deleteUser(id)'>delete</button></td></tr>";

            }

        }
    }
}

function editUser(id) 
{
    console.log("edit" + id);
    if (localStorage.getItem('user')) {
        User = JSON.parse(localStorage.getItem('user'));
    }

    document.getElementById("name").value = User[id].name;
    document.getElementById("email").value = User[id].email;
    document.getElementById("password").value = User[id].password;
    document.getElementById("Birthdate").value = User[id].birthdate;
    document.getElementById("addUser").style.visibility = "hidden";
    document.getElementById("update").innerHTML = "<button id=" + id + " onclick='updateUser(id)'>Update</button>"
    document.getElementById("update").style.visibility = "visible"

}

