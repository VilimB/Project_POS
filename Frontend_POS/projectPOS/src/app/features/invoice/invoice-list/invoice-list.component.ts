import { Component, OnInit, TemplateRef } from '@angular/core';
import { MasterService } from '../../../service/master.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent implements OnInit {
  Invoiceheader: any;
  selectedInvoiceId: number = 0; // Za pohranu odabranog broja računa
  email: string = ''; // Za pohranu email adrese
  modalRef?: BsModalRef; // Referenca na ngx-bootstrap modal

  constructor(
    private service: MasterService,
    private toastr: ToastrService,
    private modalService: BsModalService // ngx-bootstrap modal servis
  ) {}

  ngOnInit(): void {
    this.LoadInvoice();
  }

  deleteInvoice(stavkaId: number) {
    if (confirm('Da li ste sigurni da želite obrisati ovaj proizvod?')) {
      this.service.DeleteInvoice(stavkaId).subscribe(
        () => {
          this.LoadInvoice();
        },
        (error: any) => {
          console.error('Greška prilikom brisanja proizvoda:', error);
        }
      );
    }
  }

  LoadInvoice() {
    this.service.GetAllInvoice().subscribe(
      res => {
        console.log('Invoice data:', res); // Debugging line
        this.Invoiceheader = res;
      },
      err => {
        console.log('Error:', err); // Debugging line
        this.toastr.error('Failed to load invoices');
      }
    );
  }

  // Funkcija za otvaranje ngx-bootstrap modala i postavljanje odabranog broja računa
  openEmailModal(template: TemplateRef<any>, invoiceId: number) {
    this.selectedInvoiceId = invoiceId;
    this.modalRef = this.modalService.show(template); // Prikaz modala
  }

  // Funkcija za slanje e-računa na unesenu email adresu
  sendERacun() {
    if (this.email) {
      this.service.sendERacunByEmail(this.selectedInvoiceId, this.email).subscribe(res => {
        this.toastr.success('E-račun je poslan na ' + this.email);
        this.modalRef?.hide(); // Zatvori modal nakon slanja
      }, error => {
        this.toastr.error('Greška prilikom slanja e-računa.');
      });
    } else {
      this.toastr.warning('Unesite ispravnu email adresu.');
    }
  }
}

/*import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MasterService } from '../../../service/master.service';
import { ToastrService } from 'ngx-toastr'
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent {
  Invoiceheader: any;
  zaglavljeRacunaId: number | undefined;
  email: string | undefined;

  constructor(private service: MasterService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.LoadInvoice();
  }

  LoadInvoice() {
    this.service.GetAllInvoice().subscribe(res => {
      this.Invoiceheader = res;
    });
  }

  openEmailModal(invoiceId: number) {
    this.zaglavljeRacunaId = invoiceId;
    // Otvori modal (jQuery ili neki drugi način otvaranja modala)
    $('#emailModal').modal('show');
  }

  sendERacun(zaglavljeId: number) {
    if (this.email) {
      this.service.sendERacunByEmail(zaglavljeId, this.email).subscribe(res => {
        this.toastr.success('E-račun je poslan na ' + this.email);
        $('#emailModal').modal('hide');
      }, error => {
        this.toastr.error('Greška prilikom slanja e-računa.');
      });
    } else {
      this.toastr.warning('Unesite ispravnu email adresu.');
    }
    deleteInvoice(stavkaId: number) {
      if (confirm('Da li ste sigurni da želite obrisati ovaj proizvod?')) {
        this.masterService.DeleteInvoice(stavkaId).subscribe(
          () => {
            this.LoadInvoice();
          },
          (error: any) => {
            console.error('Greška prilikom brisanja proizvoda:', error);
          }
        );
      }
}

/* */
  /*invoiceremove(invoiceno: any) {
    if (confirm('Do you want to remove this Invoice :' + invoiceno)) {
      this.service.RemoveInvoice(invoiceno).subscribe(res => {
        let result: any;
        result = res;
        if (result.result == 'pass') {
          this.alert.success('Removed Successfully.', 'Remove Invoice')
          this.LoadInvoice();
        } else {
          this.alert.error('Failed to Remove.', 'Invoice');
        }
      });
    }
  }

  Editinvoice(invoiceno: any) {
    this.router.navigateByUrl('/editinvoice/' + invoiceno);
  }*/





