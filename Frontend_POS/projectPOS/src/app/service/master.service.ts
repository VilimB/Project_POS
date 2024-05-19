import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class MasterService {

  constructor(private http:HttpClient) { }
GetCustomer(){
  return this.http.get("http://localhost:5045/api/Kupac");

}
GetCustomercbycode(code:any){
  return this.http.get("http://localhost:5045/api/Kupac/"+code);

}
GetProduct(){
  return this.http.get("http://localhost:5045/api/Proizvod");

}
GetProductbycode(code:any){
  return this.http.get("http://localhost:5045/api/Proizvod/"+code);

}
GetAllInvoice(){
  return this.http.get("http://localhost:5045/api/StavkeRacuna");
}
GetInvoiceHeaderbycode(invoiceno:any){
  return this.http.get("http://localhost:5045/api/StavkeRacuna/"+invoiceno);
}

RemoveInvoice(invoiceno:any){
  return this.http.delete("http://localhost:5045/api/StavkeRacuna/"+invoiceno);
}

}
