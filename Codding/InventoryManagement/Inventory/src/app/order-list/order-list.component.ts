import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrdersService } from '../services/orders.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  orders : any = [];
  searchForm !: FormGroup;
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;
  asc : any = true;

  constructor(private orderService : OrdersService,private fb: FormBuilder) { }

  showLoader = true;
  
  ngOnInit(): void {
    this.getTotalRecords();
    this.getAllOrderList();
    this.InitializeFormControls();
  }

  InitializeFormControls(){
    this.searchForm = this.fb.group({
      FromDate : ['', Validators.required],
      ToDate : ['', Validators.required]
    })
  }

  get _form(){
    return this.searchForm.controls;
  }

  pageChanged(PageNo:any){
    this.page = PageNo;
    this.getAllOrderList();
  }

  getAllOrderList(){
    this.orderService.getAllOrders(this.page, this.itemsPerPage, this.asc).subscribe((res:any) => {
      this.orders = res;
      this.showLoader = false;
    })
  }

  getTotalRecords(){
    this.orderService.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  searchOrder(){
    if(this.searchForm.valid){
      debugger;
      this.orderService.getAllBySearchDate(this.searchForm.value)
        .subscribe((ord:any) => {
          console.log(ord);
          debugger;
          this.orders = ord;
        });
    }
  }

  reset(){
    this.getAllOrderList();
  }

  ascDesc(){
    this.asc = !this.asc;
    this.getAllOrderList();
  }
}
