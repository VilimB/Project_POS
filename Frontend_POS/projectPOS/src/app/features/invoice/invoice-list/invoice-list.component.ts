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
  masterService: any;

  constructor(
    private service: MasterService,
    private toastr: ToastrService,
    private modalService: BsModalService // ngx-bootstrap modal servis
  ) {}

  ngOnInit(): void {
    this.LoadInvoice();
  }

  LoadInvoice() {
    this.service.GetAllInvoice().subscribe(
      res => {
        console.log('Invoice data:', res);
        this.Invoiceheader = res;
      },
      err => {
        console.log('Error:', err);
        this.toastr.error('Failed to load invoices');
      }
    );
  }

  // Funkcija za otvaranje ngx-bootstrap modala i postavljanje odabranog broja računa
  openEmailModal(template: TemplateRef<any>, invoiceId: number) {
    this.selectedInvoiceId = invoiceId;
    this.modalRef = this.modalService.show(template); // Prikaz modala
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
    }}

  // Funkcija za slanje e-računa na unesenu email adresu
  sendERacunByEmail() {
    const zaglavljeId = this.selectedInvoiceId;  // Get the selected invoice ID

    if (this.email && zaglavljeId) {
      // Payload includes the necessary ID and email
      const payload = {
        zaglavljeId: zaglavljeId,
        email: this.email
      };

      // Log the payload to see what is being sent
      console.log('Payload for generating e-racun:', payload);

      // First, generate the e-invoice
      this.service.generateERacun(payload.zaglavljeId).subscribe(
        (res) => {
          // Log the response from e-racun generation
          console.log('E-racun generation successful:', res);
          this.toastr.success('E-račun je uspješno generiran!');

          // After generating the e-invoice, send it via email
          console.log('Sending e-racun via email to:', this.email);  // Log email being used
          this.service.sendERacunByEmail(payload).subscribe(
            (emailRes) => {
              // Log the response from sending the email
              console.log('E-racun successfully sent via email:', emailRes);
              this.toastr.success(`E-račun je poslan na ${this.email}`);
            },
            (emailError) => {
              // Log any errors during the email sending process
              console.error('Error during e-racun email sending:', emailError);
              this.toastr.error('Greška prilikom slanja e-računa.');
            }
          );
        },
        (error) => {
          // Log any errors during e-racun generation
          console.error('Error during e-racun generation:', error);
          this.toastr.error('Greška prilikom generiranja e-računa.');
        }
      );
    } else {
      this.toastr.warning('Unesite email adresu.');
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





