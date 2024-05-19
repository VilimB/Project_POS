import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterService } from '../../../service/master.service';
import { Router } from '@angular/router';

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

  constructor(private builder: FormBuilder, private service:MasterService, private router:Router,) { }

  ngOnInit(): void {
    this.invoiceform = this.builder.group({
      broj: ['', Validators.required],
      nazivKupca:this.builder.control('',Validators.required),
      adresa: '',
      mjesto:this.builder.control(''),
      datum: '',
      napomena: '',
      sifra: '',
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
    let customercode= this.invoiceform.get("nazivKupca")?.value;
    this.service.GetCustomercbycode(customercode).subscribe(res=>{
      let custdata: any;
      custdata=res;
      if(custdata!=null){
        this.invoiceform.get("adresa")?.setValue(custdata.adresa)
        this.invoiceform.get("sifra")?.setValue(custdata.sifra)
        this.invoiceform.get("mjesto")?.setValue(custdata.mjesto)
      }
    });
  }
  productChange(index:any){
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let productcode= this.invoiceproduct.get("naziv")?.value;
    this.service.GetProductbycode(productcode).subscribe(res=>{
      let productcode: any;
      productcode=res;
      if(productcode!=null){
        this.invoiceproduct.get("sifraProizvoda")?.setValue(productcode.sifraProizvoda)
        this.invoiceproduct.get("kolicina")?.setValue(productcode.kolicina)
        this.invoiceproduct.get("cijena")?.setValue(productcode.cijena)
        this.invoiceproduct.get("stanje")?.setValue(productcode.stanje)
        this.Itemcalcyulation(index);

      }
    });


  }


  SaveInvoice(): void {
    console.log(this.invoiceform.value);
  }

  addnewproduct(): void {
    // Dodaj novi proizvod u proizvodi FormArray
    const proizvodGroup = this.builder.group({
      sifraProizvoda: '',
      naziv: '',
      kolicina: 1,
      cijena: 0,
      stanje: 1,
      cijenaStavke:0,
    });
    this.proizvodip.push(proizvodGroup);
  }

  Itemcalcyulation(index:any){
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct=this.proizvodip.at(index) as FormGroup;
    let kolicina= this.invoiceproduct.get("kolicina")?.value;
    let cijena= this.invoiceproduct.get("cijena")?.value;
    let cijenaStavke=kolicina*cijena;
    this.invoiceproduct.get("cijenaStavke")?.setValue(cijenaStavke);
    this.summaryCalculation();

  }
  summaryCalculation(){
    let array=this.invoiceform.getRawValue().proizvodip;
    let sumtotal=0;
    array.forEach((x:any)=>{
      sumtotal=sumtotal+x.cijenaStavke;

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

 /*this.proizvodi.push(newProductGroup);


  get proizvodi(): FormArray {
    return this.invoiceform.get('proizvodi') as FormArray;
  }*/
/*import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  pagetitle = "Dodaj račun";
  invoiceform !: FormGroup;
  invoiceproizvodi!: FormArray<any>;

  constructor(private builder: FormBuilder) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.invoiceform = this.builder.group({
      broj: ['', Validators.required],
      nazivKupca: ['', Validators.required],
      adresa: [''],
      datum: [''],
      napomena: [''],
      sifra: [''],
      proizvodi: this.builder.array([]), // FormArray za tablični unos proizvoda
      popust: [''],
      naziv: [''],
      iznosPopusta: [''],
      vrijednost: ['']
    });
  }

  SaveInvoice(): void {
    console.log(this.invoiceform.value);
  }

  addnewproduct(): void {
    // Dodaj novi proizvod u FormArray
    const newProductGroup = this.builder.group({
      sifraProizvoda: [''],
      nazivProizvoda: [''],
      kolicina: [''],
      cijena: [''],
      stanje: ['']
    });
    (this.invoiceform.get('proizvodi') as FormArray).push(newProductGroup);
  }

  removeProduct(i: number): void {
    const proizvodiArray = this.invoiceform.get('proizvodi') as FormArray;
    proizvodiArray.removeAt(i);
  }
}
*/
/*import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators, } from '@angular/forms';
import { table } from 'console';
@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrl: './add-invoice.component.css'
})
export class AddInvoiceComponent implements OnInit{
constructor(private builder:FormBuilder){}
pagetitle="Dodaj račun"

  ngOnInit(): void {
  }
  invoiceform=this.builder.group({
    broj:this.builder.control('',Validators.required),
    nazivKupca:this.builder.control('',Validators.required),
    adresa:this.builder.control(''),
    datum:this.builder.control(''),
    napomena:this.builder.control(''),
    sifra:this.builder.control(''),
    table: this.builder.group({
      sifraProizvoda: this.builder.control(''),
      naziv: this.builder.control(''),
      kolicina: this.builder.control(''),
      cijena: this.builder.control(''),
      stanje: this.builder.control(''),
      uredi: this.builder.control(''),
    }as any),
    popust:this.builder.control(''),
    iznosPopusta:this.builder.control(''),
    vrijednost:this.builder.control(''),


  });

  SaveInvoice(){
    console.log(this.invoiceform.value)

  }
  addnewproduct(): void {
    // Dodavanje novog proizvoda u formularsku grupu table
    const tableGroup = this.invoiceform.get('table') as FormGroup;
    if (tableGroup) {
      tableGroup.addControl('noviProizvod', this.builder.group({
        sifraProizvoda: [''],
        nazivProizvoda: [''],
        kolicina: [''],
        cijena: [''],
        stanje: [''],
        uredi: ['']
      }));
  }}

}*/
