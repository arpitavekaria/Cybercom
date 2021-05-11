import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-add-edit',
  templateUrl: './customer-add-edit.component.html',
  styleUrls: ['./customer-add-edit.component.css']
})
export class CustomerAddEditComponent implements OnInit {

  customerForm !: FormGroup;
  submitted = false;
  id !: any;
  isAddMode !: boolean;

  constructor(private fb: FormBuilder, 
              private customerService : CustomerService,
              private router : Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.InitializeformControls();
  }

  InitializeformControls() {
    if(this.route.snapshot.params['id'] != null){
      this.id = parseInt(atob(this.route.snapshot.params['id']));
    }
    this.isAddMode = !this.id;

    this.customerForm = this.fb.group({
      CustomerName: ['', Validators.required],
      Email: ['', [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      Phone: ['', [Validators.required,Validators.pattern("^[0-9]{10}$")]]
    })

    if(!this.isAddMode) {
      this.customerService.getCustomerById(this.id).subscribe((cust) => {
        this.customerForm.patchValue(cust);
      })
    }
  }

  get _form(){
    return this.customerForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if(this.customerForm.invalid) {
      return;
    } 

    if (this.isAddMode) {
      this.addCustomer();
  } else {
      this.updateCustomer();
  }

  }

  addCustomer (){
    this.customerService.addCustomer(this.customerForm.value).subscribe((res) => {
      this.customerForm.reset();
      this.router.navigate(['/customer']);
    })
  }

  updateCustomer() {
    this.customerService.updateCustomer(this.id, this.customerForm.value).subscribe((res) => {
      this.customerForm.reset();
      this.router.navigate(['/customer']);
    })
  }

}
