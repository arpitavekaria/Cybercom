var admin = [];
function AdminCheck() 
{
    if (localStorage.getItem('admin')) 
    {
        alert("Already Registered!!!");
        window.location.href = "Login.html";
    }
}

function AdminRegister() 
{
    var regadmin = {};

    regadmin.name = document.getElementById("name").value;
    regadmin.email = document.getElementById("email").value;
    regadmin.password = document.getElementById("password").value;
    regadmin.confirmPwd = document.getElementById("confirmPassword").value;
    regadmin.city = document.getElementById("selectCity").value;
    regadmin.state = document.getElementById("selectState").value;
    
    admin.push(regadmin);
    localStorage.setItem("admin", JSON.stringify(admin));
    window.location.href = "Login.html";
}