import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private baseUrl = "http://localhost:1966/api/";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private http: HttpClient) { }

  getTotalRecord() : Observable<any[]>{
    return this.http.get<any[]>(this.baseUrl + "Orders"  , this.httpOptions);
  }

  getAllOrders(page:number, itemPerPage:number, asc:any) : Observable<any[]>{
    return this.http.get<any[]>(this.baseUrl + "Orders" + '?PageNo=' + page + '&PageSize=' + itemPerPage +  '&Dir=' + asc , this.httpOptions);
  }

  // getAllOrders(){
  //   return this.http.get(this.baseUrl + "Orders" , this.httpOptions);
  // }

  getAllBySearchDate(data:any){
    return this.http.post(this.baseUrl + "Orders", data);
  }
}
