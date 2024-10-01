import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MasterService } from '../../../service/master.service';
import { ToastrService } from 'ngx-toastr'
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrl: './invoice-list.component.css'
})
export class InvoiceListComponent {
  masterService: any;

  constructor(private service: MasterService, private toastr: ToastrService) { }

 Invoiceheader: any;

  ngOnInit(): void {
    this.LoadInvoice();

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





}
