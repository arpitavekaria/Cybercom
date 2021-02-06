var admin = [];
function checkAdmin() {
    if (localStorage.getItem('admin')) {
        alert("Already Registered..");
        window.location.href = "Login.html";
    }
}

function registerAdmin() {
    var adminObject = {};
    adminObject.name = document.getElementById("name").value;
    adminObject.email = document.getElementById("email").value;
    adminObject.password = document.getElementById("password").value;
    adminObject.confirmPwd = document.getElementById("confirmPwd").value;
    adminObject.city = document.getElementById("selectCity").value;
    adminObject.state = document.getElementById("selectState").value;
    admin.push(adminObject);
    localStorage.setItem("admin", JSON.stringify(admin));//stores data on local storage
    window.location.href = "Login.html";
}