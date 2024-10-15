import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from '../features/category/models/product-model';


@Injectable({
  providedIn: 'root'
})
export class MasterService {
  RemoveProduct(id: number) {
    throw new Error('Method not implemented.');
  }
  warning(arg0: string, arg1: string) {
    throw new Error('Method not implemented.');
  }
  constructor(private http: HttpClient) {}

  // Metode za rad sa kupcima
  GetCustomer(): Observable<any> {
    return this.http.get("http://localhost:5045/api/Kupac");
  }

  GetCustomercbycode(code: any): Observable<any> {
    return this.http.get("http://localhost:5045/api/Kupac/" + code);
  }

  // Metode za rad sa proizvodima
  GetProduct(): Observable<Product[]> { // Tipiziraj kao niz proizvoda
    return this.http.get<Product[]>("http://localhost:5045/api/Proizvod");
  }

  SaveProduct(productData: Product): Observable<Product> { // Tipiziraj kao proizvod
    return this.http.post<Product>("http://localhost:5045/api/Proizvod", productData);
  }

  GetProductbycode(code: any): Observable<Product> { // Tipiziraj kao proizvod
    return this.http.get<Product>("http://localhost:5045/api/Proizvod/" + code);
  }
  DeleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`http://localhost:5045/api/Proizvod/${id}`);
  }
  UpdateProduct(id: number, updateDTO: any): Observable<any> {
    return this.http.put(`http://localhost:5045/api/Proizvod/${id}`, updateDTO);
  }

  generateERacun(zaglavljeId: number): Observable<any> {
    return this.http.post(`http://localhost:5045/api/racun/generate-e-racun`, { zaglavljeId });
  }
  sendERacunByEmail(zaglavljeId: number, email: string): Observable<any> {
    return this.http.post(`http://localhost:5045/api/racun/generate-e-racun`, { zaglavljeId, email });
  }




  // Metode za rad sa računima
  GetAllInvoice(): Observable<any> {
    return this.http.get("http://localhost:5045/api/StavkeRacuna");
  }

  GetInvoiceHeaderbycode(invoiceno: any): Observable<any> {
    return this.http.get("http://localhost:5045/api/StavkeRacuna/" + invoiceno);
  }

  RemoveInvoice(invoiceno: any): Observable<any> {
    return this.http.delete("http://localhost:5045/api/StavkeRacuna/" + invoiceno);
  }
  DeleteInvoice(id: number): Observable<void> {
    return this.http.delete<void>(`http://localhost:5045/api/StavkeRacuna/${id}`);
  }

  /*saveInvoice(invoiceData: any): Observable<any> {
    return this.http.post("http://localhost:5045/api/StavkeRacuna", invoiceData);
  }*/

  saveInvoice(proizvodId: any, zaglavljeId: any, invoiceData: any): Observable<any> {
    invoiceData.proizvodId = proizvodId;
    invoiceData.zaglavljeId = zaglavljeId;

    return this.http.post("http://localhost:5045/api/StavkeRacuna", invoiceData);
}




  saveZaglavlje(invoiceData: any, kupacId: any): Observable<any> {
    return this.http.post("http://localhost:5045/api/ZaglavljeRacuna/" + kupacId, invoiceData);
  }
}
