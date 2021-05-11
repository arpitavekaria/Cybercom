import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../model/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products : Product[] = []
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;
  constructor(private productService: ProductService, private route : Router) { }

  showLoader = true;

  ngOnInit(): void {
    this.getProductsData();
  }

  pageChanged(PageNo:any){
    this.page = PageNo;
    this.getProductsData();
  }

  getProductsData() {
    this.getTotalRecords();
    this.productService.getAllProducts(this.page, this.itemsPerPage).subscribe((cust : any) => {
      this.products = cust;
      this.showLoader = false;
    })
  }

  getTotalRecords(){
    this.productService.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  deleteProduct(id : number) {
  
    if(confirm("Are you sure want to delete this record?")) {
      this.productService.deleteProduct(id).subscribe((res) => {
        this.getProductsData();
      });
    } else {
      return;
    }
  }

  updateProduct(id : any) {
    this.route.navigate(['/product/edit/' + btoa(id)])
  }

  searchProduct(text:any){
    if(text.target.value != null){
      this.productService.searchProductName(this.page, this.itemsPerPage, text.target.value.trim())
        .subscribe(res => {
          if(res !== "No have any Data"){
            this.products = res as Product[];
          } else{
            this.products = null as any;
          }
        });
    } else {
      this.getProductsData();
    }
  }

}
