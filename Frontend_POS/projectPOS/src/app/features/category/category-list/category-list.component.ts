import { Component, OnInit } from '@angular/core';
import { MasterService } from '../../../service/master.service';
import { Product } from '../models/product-model'; // Provjeri putanju do modela
import { NotificationService } from '../../../service/notification.service'; // Koristi SignalR servis

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  products: Product[] = [];

  constructor(
    private masterService: MasterService,
    private notificationService: NotificationService // Injektovanje SignalR servisa
  ) {}

  ngOnInit(): void {
    this.loadProducts();
   /* this.initializeSignalRConnection(); */// Povezivanje na SignalR
  }

  loadProducts() {
    this.masterService.GetProduct().subscribe(
      (response: Product[]) => {
        this.products = response;
      },
      (error) => {
        console.error('Greška prilikom učitavanja proizvoda:', error);
      }
    );
  }

  deleteProduct(productId: number) {
    if (confirm('Da li ste sigurni da želite obrisati ovaj proizvod?')) {
      this.masterService.DeleteProduct(productId).subscribe(
        (response) => {
          this.loadProducts();
        },
        (error) => {
          console.error('Greška prilikom brisanja proizvoda:', error);
        }
      );
    }
  }
/*
  // SignalR konekcija za ažuriranje liste proizvoda
  initializeSignalRConnection() {
    this.notificationService.startConnection();
    this.notificationService.addUpdateListener((message: string) => {
      const updatedProduct: Product = JSON.parse(message);
      const index = this.products.findIndex(p => p.proizvodId === updatedProduct.proizvodId);
      if (index !== -1) {
        this.products[index] = updatedProduct; // Ažuriranje postojećeg proizvoda
      } else {
        this.products.push(updatedProduct); // Dodavanje novog proizvoda
      }
    });
  }*/

  // Ažuriranje stanja proizvoda
  azurirajStanje(product: Product) {
    if (product.novoStanje && product.novoStanje > 0) {
      const updateProductDTO = {
        nazivProizvod: product.nazivProizvod,
        cijenaProizvod: product.cijenaProizvod,
        stanje: product.stanje + product.novoStanje,
        jedinicaMjere: product.jedinicaMjere,
        sifraProizvod: product.sifraProizvod
      };

      this.masterService.UpdateProduct(product.proizvodId, updateProductDTO).subscribe(
        (response) => {
          this.loadProducts();
        },
        (error) => {
          console.error('Greška prilikom ažuriranja stanja:', error);
        }
      );
    } else {
      console.warn('Unesite ispravno stanje');
    }
  }
}
