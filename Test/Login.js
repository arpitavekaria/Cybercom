console.log("hello");
function loginAdmin() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;


    var admin = JSON.parse(localStorage.getItem("admin"));

    if (email === admin[0].email && password === admin[0].password) 
    {
        window.location.href = "Dashboard.html";
    }
}
function redirectRegister() 
{
    // redirect to registration page
    window.location.href = "Registration.html";
}
function hideRegister() 
{
    //to hide register now button
    if (localStorage.getItem('admin')) {
        document.getElementById("register").style.visibility = "hidden";
    }
}