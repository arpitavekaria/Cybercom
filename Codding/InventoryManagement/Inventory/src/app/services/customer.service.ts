import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../model/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private baseUrl = "http://localhost:1966/api/";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private http: HttpClient) { }

  getTotalRecord() : Observable<Customer[]>{
    return this.http.get<Customer[]>(this.baseUrl + "Customer"  , this.httpOptions);
  }

  getAllCustomers(page:number, itemPerPage:number) : Observable<Customer[]>{
    return this.http.get<Customer[]>(this.baseUrl + "Customer" + '?PageNo=' + page + '&PageSize=' + itemPerPage , this.httpOptions);
  }

  searchCustomerName(page:number, itemPerPage:number, searchtxt:any){
    return this.http.get(this.baseUrl + "Customer" + '?PageNo=' + page + '&PageSize=' + itemPerPage + '&SearchText=' + searchtxt);
  }

  getCustomerById(id : number) : Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl + "Customer/" + id, this.httpOptions);
  }

  addCustomer(cust : Customer) : Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl + "Customer" , JSON.stringify(cust), this.httpOptions);
  }

  updateCustomer(id: number, cust: Customer) : Observable<Customer> {
    return this.http.put<Customer>(this.baseUrl + "Customer/" + id , JSON.stringify(cust), this.httpOptions);
  }

  deleteCustomer(id : number) {
    return this.http.delete(this.baseUrl + "Customer/" + id, this.httpOptions);
  }

  

}
