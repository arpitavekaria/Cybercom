var User = [];

function AddUser() 
{       
    if (localStorage.getItem('user')) 
    {
        User = JSON.parse(localStorage.getItem('user'));
    }

    var newUser = {};
    newUser.name = document.getElementById("name").value;
    newUser.email = document.getElementById("email").value;
    newUser.password = document.getElementById("password").value;
    newUser.birthdate = document.getElementById("Birthdate").value;
    User.push(newUser);
    localStorage.setItem("user", JSON.stringify(User));
    alert("User added successfully!!");
}

function UserDisplay() 
{
    if (localStorage.getItem('user')) 
    {
        User = JSON.parse(localStorage.getItem('user'));
    }
    display();
    function display() 
    {
        if (User === []) 
        {
            document.getElementById("displaytable").innerHTML = "<tr><td>User Not Found</td></tr>";
        }
        else 
        {
            for (var i in User) 
            {
                document.getElementById("displaytable").innerHTML = document.getElementById("displaytable").innerHTML + "<tr id="+i+"><td>" + 
                User[i].name + "</td><td>" + User[i].email + "</td><td>" + User[i].password + "</td><td>" + User[i].birthdate + 
                "</td><td><button id=" + i + " onclick='EditUser(id)'>edit</button></td><td><button id=" + i + " onclick='DeleteUser(id)'>delete</button></td></tr>";
            }
        }
    }
}

function DeleteUser(id) 
{
    console.log(id);
    var tableRowCount = document.getElementById("displaytable").rows.length;
    if(tableRowCount==2)
    {
        document.getElementById("displaytable").deleteRow(1);
    }
    else
    {
        document.getElementById("displaytable").deleteRow(id+1);
    } 
    localStorage.removeItem(User[id]);
    console.log(User[id]);
}

function EditUser(id) 
{
    if (localStorage.getItem('user')) 
    {
        User = JSON.parse(localStorage.getItem('user'));
    }

    document.getElementById("name").value = User[id].name;
    document.getElementById("email").value = User[id].email;
    document.getElementById("password").value = User[id].password;
    document.getElementById("Birthdate").value = User[id].birthdate;
    document.getElementById("addUser").style.visibility = "hidden";
    document.getElementById("updateUser").innerHTML = "<button id=" + id + " onclick='UpdateUser(id)'>Update</button>"
    document.getElementById("updateUser").style.visibility = "visible"

}

function UpdateUser(id)
{
    console.log(document.getElementById("name").value);
    if (localStorage.getItem('user')) 
    {
        User = JSON.parse(localStorage.getItem('user'));
    }

    User[id].name = document.getElementById("name").value;
    User[id].email = document.getElementById("email").value;
    User[id].password = document.getElementById("password").value;
    User[id].birthdate = document.getElementById("Birthdate").value;
    localStorage.setItem("user", JSON.stringify(User));
    console.log(User[id].name);
    window.location.href = "User.html";
}
