import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl = "http://localhost:1966/api/";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private http: HttpClient) { }

  getTotalRecord() : Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl + "Product"  , this.httpOptions);
  }

  getAllProducts(page:number, itemPerPage:number) : Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl + "Product" + '?PageNo=' + page + '&PageSize=' + itemPerPage , this.httpOptions);
  }

  searchProductName(page:number, itemPerPage:number, searchtxt:any){
    return this.http.get(this.baseUrl + "Product" + '?PageNo=' + page + '&PageSize=' + itemPerPage + '&SearchText=' + searchtxt);
  }


  getProductById(id : number) : Observable<Product> {
    return this.http.get<Product>(this.baseUrl + "Product/" + id, this.httpOptions);
  }

  addProduct(pro : Product) : Observable<Product> {
    return this.http.post<Product>(this.baseUrl + "Product" , JSON.stringify(pro), this.httpOptions);
  }

  updateProduct(id: number, pro: Product) : Observable<Product> {
    return this.http.put<Product>(this.baseUrl + "Product/" + id , JSON.stringify(pro), this.httpOptions);
  }

  deleteProduct(id : number) {
    return this.http.delete(this.baseUrl + "Product/" + id, this.httpOptions);
  }

}
