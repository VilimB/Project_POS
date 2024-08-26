import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class MasterService {
  warning(arg0: string, arg1: string) {
    throw new Error('Method not implemented.');
  }
  error(arg0: string, arg1: string) {
    throw new Error('Method not implemented.');
  }
  success(arg0: string, arg1: string) {
    throw new Error('Method not implemented.');
  }
  getIdsFromCodes(sifraProizvoda: any, brojZaglavlja: any) {
    throw new Error('Method not implemented.');
  }

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
SaveProduct(categoryData: any){
  return this.http.post("http://localhost:5045/api/Proizvod", categoryData);

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
saveInvoice(invoiceData: any) {
  return this.http.post("http://localhost:5045/api/StavkeRacuna", invoiceData);
}

saveZaglavlje(invoiceData: any, kupacId: any){
  return this.http.post("http://localhost:5045/api/ZaglavljeRacuna/"+ kupacId, invoiceData);
}

}
