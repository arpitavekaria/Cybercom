import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router) { }

username!: string;
password!: string;

  ngOnInit() {
  }

  login() : void {
    if(this.username === 'Admin@user.com' && this.password === 'Admin@12345'){
      debugger;
      sessionStorage.setItem("admin" , "admin")
     this.router.navigate(['']);
    }else {
      alert("Invalid credentials");
    }
  }
  
}
