import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterService } from '../../../service/master.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NotificationService } from '../../../service/notification.service';
import { Product } from '../../category/models/product-model';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  pagetitle = "Dodaj račun";

  invoiceform!: FormGroup;
  proizvodip!: FormArray;
  invoiceproduct!: FormGroup;

  masterCustomer: any;
  masterProduct: any;
  isedit = false;
  selectedUser: any;
  userId: any;
  selectedProductId: string | undefined;

  constructor(
    private builder: FormBuilder,
    private service: MasterService,
    private router: Router,
    private toastr: ToastrService,
    private notificationService: NotificationService // Injektovanje SignalR servisa
  ) {}

  ngOnInit(): void {
    this.invoiceform = this.builder.group({
      broj:'',
      nazivKupac: this.builder.control('', Validators.required),
      adresa: '',
      mjesto: this.builder.control(''),
      datum: '',
      napomena: '',
      sifracKupac: '',
      proizvodip: this.builder.array([]),
      popust: { value: 0, disabled: false },
      iznosPopusta: { value: 0, disabled: true },
      vrijednost: { value: 0, disabled: false },
    });

    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.GetCustomer();
    this.GetProduct();
  }

  GetCustomer() {
    this.service.GetCustomer().subscribe(res => {
      this.masterCustomer = res;
    });
  }



  GetProduct() {
    this.service.GetProduct().subscribe(res => {
      this.masterProduct = res;
    });
  }

  customerChange(value: any) {
    let customercode = value;
    this.service.GetCustomercbycode(customercode).subscribe(res => {
      let custdata: any = res;
      if (custdata != null) {
        this.userId = custdata.kupacId;
        this.invoiceform.get("adresa")?.setValue(custdata.adresa);
        this.invoiceform.get("sifracKupac")?.setValue(custdata.sifraKupac);
        this.invoiceform.get("mjesto")?.setValue(custdata.mjesto);
      }
    });
  }
  /*productChange(event: any, index: any) {
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    let selectedValue = event;
    if (selectedValue) {
      this.service.GetProductbycode(selectedValue).subscribe((res: any) => {
        if (res) {
          this.proizvodip.controls[index].get("sifraProizvod")?.setValue(res.sifraProizvod);
          this.proizvodip.controls[index].get("kolicina")?.setValue(res.kolicina);
          this.proizvodip.controls[index].get("cijenaProizvod")?.setValue(res.cijenaProizvod);
          this.proizvodip.controls[index].get("stanje")?.setValue(res.stanje);

          // Postavite naziv proizvoda u formu
          this.invoiceform.get('nazivProizvod')?.setValue(res.nazivProizvod);
        }
      });
        }*/
      productChange(selectedValue: string, index: number) {
        // Konvertiranje string vrijednosti u broj
        const selectedProductId = Number(selectedValue);

        // Pronađi proizvod
        const selectedProduct = this.masterProduct.find((p: { proizvodId: number; }) => p.proizvodId === selectedProductId);

        console.log('Odabrani proizvod:', selectedProduct); // Ispis odabranog proizvoda

        if (selectedProduct) {
          console.log(selectedProduct);

          this.proizvodip.controls[index].patchValue({
            sifraProizvod: selectedProduct.sifraProizvod,
            nazivProizvod: selectedProduct.nazivProizvod, // Provjerite da li naziv postoji
            cijenaProizvod: selectedProduct.cijenaProizvod,
            stanje: selectedProduct.stanje
          });
        }

      }

      SaveInvoice() {
        if (this.invoiceform.valid) {
          const broj = this.invoiceform.get('broj')?.value;

          // Sačuvaj zaglavlje računa
          this.service.saveZaglavlje(this.invoiceform.getRawValue(), this.userId).subscribe(res => {
            this.toastr.success('Račun je uspješno sačuvan!');

            // Nakon uspješnog spremanja pozovemo API za generiranje e-računa
            this.service.generateERacun(broj).subscribe(res => {
              this.toastr.success('E-račun je uspješno generiran!');
              this.updateStock(); // Ažuriraj stanje proizvoda putem SignalR-a
            });
          });
        } else {
          this.toastr.warning('Unesite sve obavezne podatke!', 'Validacija');
        }
      }



  updateStock() {
    this.proizvodip.controls.forEach((control) => {
      let proizvodId = control.get("sifraProizvod")?.value;
      let kolicina = control.get("kolicina")?.value;

      this.service.UpdateProduct(proizvodId, kolicina).subscribe(res => {
        console.log('Ažurirano stanje za proizvod:', res);
        this.notificationService.sendUpdate(JSON.stringify(res)); // Slanje ažuriranja putem SignalR-a
      });
    });
  }

  addnewproduct(): void {
    const proizvodGroup = this.builder.group({
      sifraProizvod: '',
      nazivProizvod: '',
      kolicina: 1,
      cijenaProizvod: 0,
      stanje: 1,
      cijenaStavka: 0,
    });
    this.proizvodip.push(proizvodGroup);
  }

  Itemcalculation(index: any) {
    this.proizvodip = this.invoiceform.get('proizvodip') as FormArray;
    this.invoiceproduct = this.proizvodip.at(index) as FormGroup;
    let kolicina = this.invoiceproduct.get("kolicina")?.value;
    let cijenaProizvod = this.invoiceproduct.get("cijenaProizvod")?.value;
    let cijenaStavka = kolicina * cijenaProizvod;
    this.proizvodip.at(index).get("cijenaStavka")?.setValue(cijenaStavka);
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
