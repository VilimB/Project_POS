import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterService } from '../../../service/master.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  pagetitle = "Dodaj račun";

  invoiceform !: FormGroup;
  proizvodip!: FormArray;
  invoiceproduct!: FormGroup;

  masterCustomer:any;
  masterProduct:any;
  isedit = false;
  selectedUser:any;

  constructor(private builder: FormBuilder, private service:MasterService, private router:Router,private alert: MasterService) { }

  ngOnInit(): void {
    this.invoiceform = this.builder.group({
      broj: ['', Validators.required],
      nazivKupac:this.builder.control('',Validators.required),
      adresa: '',
      mjesto:this.builder.control(''),
      datum: '',
      napomena: '',
      sifraKupac: '',
      proizvodip: this.builder.array([]),
      popust: { value: 0, disabled: false },
      iznosPopusta: { value: 0, disabled: true },
      vrijednost:{ value: 0, disabled: false },

    });
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.GetCustomer();
    this.GetProduct();
  }
  GetCustomer(){
    this.service.GetCustomer().subscribe(res=>{
      console.log(res)
      this.masterCustomer=res;
    })
  }
  GetProduct(){
    this.service.GetProduct().subscribe(res=>{
      this.masterProduct=res;
    })
  }
  customerChange(value: any){
    console.log(value)
    let customercode= value;
    this.service.GetCustomercbycode(customercode).subscribe(res=>{
      let custdata: any;
      custdata=res;
      if(custdata!=null){
        this.invoiceform.get("adresa")?.setValue(custdata.adresa)
        this.invoiceform.get("sifraKupac")?.setValue(custdata.sifraKupac)
        this.invoiceform.get("mjesto")?.setValue(custdata.mjesto)
      }
    });
  }
  productChange(index:any){
    console.log(index)
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let productcode= this.invoiceproduct.get("nazivProizvod")?.value;
    this.service.GetProductbycode(productcode).subscribe(res=>{
      let productcode: any;
      productcode=res;
      if(productcode!=null){
        this.invoiceproduct.get("sifraProizvod")?.setValue(productcode.sifraProizvod)
        this.invoiceproduct.get("kolicina")?.setValue(productcode.kolicina)
        this.invoiceproduct.get("cijenaProizvod")?.setValue(productcode.cijenaProizvod)
        this.invoiceproduct.get("stanje")?.setValue(productcode.stanje)
        this.Itemcalcyulation(index);

      }
    });
  }
  SaveInvoice() {
    if (this.invoiceform.valid) {
      this.service.saveInvoice(this.invoiceform.getRawValue()).subscribe(res=>{
        let result:any;
        result=res;
        console.log(result);
      })
      } else {
      this.alert.warning('Please enter values in all mandatory filed', 'Validation');
    }

  }

  addnewproduct(): void {
    // Dodaj novi proizvod u proizvodi FormArray
    const proizvodGroup = this.builder.group({
      sifraProizvod: '',
      nazivProizvod: '',
      kolicina: 1,
      cijenaProizvod: 0,
      stanje: 1,
      cijenaStavka:0,
    });
    this.proizvodip.push(proizvodGroup);
  }

  Itemcalcyulation(index:any){
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let kolicina= this.invoiceproduct.get("kolicina")?.value;
    let cijenaProizvod= this.invoiceproduct.get("cijenaProizvod")?.value;
    let cijenaStavka=kolicina*cijenaProizvod;
    this.invoiceproduct.get("cijenaStavke")?.setValue(cijenaStavka);
    this.summaryCalculation();

  }
  summaryCalculation(){
    let array=this.invoiceform.getRawValue().proizvodip;
    let sumtotal=0;
    array.forEach((x:any)=>{
      sumtotal=sumtotal+x.cijenaStavka;

    });
    this.invoiceform.get("vrijednost")?.setValue(sumtotal);
    let popust = this.invoiceform.get('popust')?.value;

  let iznosPopusta = (popust / 100) * sumtotal;

  this.invoiceform.get('iznosPopusta')?.setValue(iznosPopusta);
  let ukupnaVrijednostSPopustom = sumtotal - iznosPopusta;
  this.invoiceform.get('vrijednost')?.setValue(ukupnaVrijednostSPopustom);
}




  removeProduct(i: number): void {
    this.proizvodip.removeAt(i);
  }
}


/*import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterService } from '../../../service/master.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  pagetitle = "Dodaj račun";

  invoiceform !: FormGroup;
  proizvodip!: FormArray;
  invoiceproduct!: FormGroup;

  masterCustomer:any;
  masterProduct:any;
  isedit = false;

  constructor(private builder: FormBuilder, private service:MasterService, private router:Router,private alert: MasterService) { }

  ngOnInit(): void {
    this.invoiceform = this.builder.group({
      broj: ['', Validators.required],
      nazivKupac:this.builder.control('',Validators.required),
      adresa: '',
      mjesto:this.builder.control(''),
      datum: '',
      napomena: '',
      sifraKupac: '',
      proizvodip: this.builder.array([]),
      popust: { value: 0, disabled: false },
      iznosPopusta: { value: 0, disabled: true },
      vrijednost:{ value: 0, disabled: false },

    });
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.GetCustomer();
    this.GetProduct();
  }
  GetCustomer(){
    this.service.GetCustomer().subscribe(res=>{
      this.masterCustomer=res;
    })
  }
  GetProduct(){
    this.service.GetProduct().subscribe(res=>{
      this.masterProduct=res;
    })
  }
  customerChange(){
    let customercode= this.invoiceform.get("nazivKupac")?.value;
    this.service.GetCustomercbycode(customercode).subscribe(res=>{
      let custdata: any;
      custdata=res;
      if(custdata!=null){
        this.invoiceform.get("adresa")?.setValue(custdata.adresa)
        this.invoiceform.get("sifraKupac")?.setValue(custdata.sifraKupac)
        this.invoiceform.get("mjesto")?.setValue(custdata.mjesto)
      }
    });
  }
  productChange(index:any){
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let productcode= this.invoiceproduct.get("nazivProizvod")?.value;
    this.service.GetProductbycode(productcode).subscribe(res=>{
      let productcode: any;
      productcode=res;
      if(productcode!=null){
        this.invoiceproduct.get("sifraProizvod")?.setValue(productcode.sifraProizvod)
        this.invoiceproduct.get("kolicina")?.setValue(productcode.kolicina)
        this.invoiceproduct.get("cijenaProizvod")?.setValue(productcode.cijenaProizvod)
        this.invoiceproduct.get("stanje")?.setValue(productcode.stanje)
        this.Itemcalcyulation(index);

      }
    });
  }
  SaveInvoice() {
    if (this.invoiceform.valid) {
      this.service.saveInvoice(this.invoiceform.getRawValue()).subscribe(res=>{
        let result:any;
        result=res;
        console.log(result);
      })
      } else {
      this.alert.warning('Please enter values in all mandatory filed', 'Validation');
    }

  }

  addnewproduct(): void {
    // Dodaj novi proizvod u proizvodi FormArray
    const proizvodGroup = this.builder.group({
      sifraProizvod: '',
      nazivProizvod: '',
      kolicina: 1,
      cijenaProizvod: 0,
      stanje: 1,
      cijenaStavka:0,
    });
    this.proizvodip.push(proizvodGroup);
  }

  Itemcalcyulation(index:any){
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let kolicina= this.invoiceproduct.get("kolicina")?.value;
    let cijenaProizvod= this.invoiceproduct.get("cijenaProizvod")?.value;
    let cijenaStavka=kolicina*cijenaProizvod;
    this.invoiceproduct.get("cijenaStavka")?.setValue(cijenaStavka);
    this.summaryCalculation();

  }
  summaryCalculation(){
    let array=this.invoiceform.getRawValue().proizvodip;
    let sumtotal=0;
    array.forEach((x:any)=>{
      sumtotal=sumtotal+x.cijenaStavka;

    });
    this.invoiceform.get("vrijednost")?.setValue(sumtotal);
    let popust = this.invoiceform.get('popust')?.value;

  let iznosPopusta = (popust / 100) * sumtotal;

  this.invoiceform.get('iznosPopusta')?.setValue(iznosPopusta);
  let ukupnaVrijednostSPopustom = sumtotal - iznosPopusta;
  this.invoiceform.get('vrijednost')?.setValue(ukupnaVrijednostSPopustom);
}




  removeProduct(i: number): void {
    this.proizvodip.removeAt(i);
  }
}*/
