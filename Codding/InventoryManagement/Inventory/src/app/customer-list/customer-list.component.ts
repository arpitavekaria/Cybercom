import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from '../model/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers : Customer[] = []
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;

  constructor(private customerService: CustomerService, private route : Router) { }

  showLoader = true;

  ngOnInit(): void {
    this.getCustomersData();
  }

  pageChanged(PageNo:any){
    this.page = PageNo;
    this.getCustomersData();
  }

  getCustomersData() {
    this.getTotalRecords();
    this.customerService.getAllCustomers(this.page, this.itemsPerPage).subscribe((cust : any) => {
      this.customers = cust;
      this.showLoader = false;
    })
  }

  getTotalRecords(){
    this.customerService.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  deleteCustomer(id : number) {
  
    if(confirm("Are you sure want to delete this record?")) {
      this.customerService.deleteCustomer(id).subscribe((res) => {
        this.getCustomersData();
      });
    } else {
      return;
    }
  }

  updateCustomer(id : any) {
    this.route.navigate(['/customer/edit/' + btoa(id)])
  }

  searchCustomer(text:any){
    if(text.target.value != null){
      this.customerService.searchCustomerName(this.page, this.itemsPerPage, text.target.value.trim())
        .subscribe(res => {
          if(res !== "No have any Data"){
            this.customers = res as Customer[];
          } else{
            this.customers = null as any;
          }
        });
    } else {
      this.getCustomersData();
    }
  }

}
