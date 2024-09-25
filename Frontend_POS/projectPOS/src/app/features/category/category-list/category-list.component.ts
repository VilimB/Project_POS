import { Component, OnInit } from '@angular/core';
import { MasterService } from '../../../service/master.service';
import { Product } from '../models/product-model'; // Provjeri putanju do modela

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  products: Product[] = []; // Inicijaliziramo praznim nizom

  constructor(private masterService: MasterService) {}

  ngOnInit(): void {
    this.loadProducts(); // Učitaj proizvode prilikom inicijalizacije komponente
  }

  // Metoda za učitavanje svih proizvoda
  loadProducts() {
    this.masterService.GetProduct().subscribe(
      (response: Product[]) => {
        console.log('Učitali smo proizvode:', response); // Ispis u konzolu
        this.products = response; // Dodela proizvoda odgovoru sa servera
      },
      (error) => {
        console.error('Greška prilikom učitavanja proizvoda:', error); // Ispis greške
      }
    );
  }

  // Metoda za brisanje proizvoda
  deleteProduct(productId: number) {
    if (confirm('Da li ste sigurni da želite obrisati ovaj proizvod?')) {
      this.masterService.DeleteProduct(productId).subscribe(
        (response) => {
          console.log('Uspješno obrisan proizvod:', response); // Ispis u konzolu
          this.loadProducts(); // Ponovno učitaj proizvode nakon brisanja
        },
        (error) => {
          console.error('Greška prilikom brisanja proizvoda:', error); // Ispis greške
        }
      );
    }
  }
  /*azurirajStanje(product: Product) {
    // Proveri da li novo stanje postoji i da li je veće od 0
    if (product.novoStanje && product.novoStanje > 0) {
      const updateProductDTO = {
        nazivProizvod: product.nazivProizvod,
        cijenaProizvod: product.cijenaProizvod,
        stanje: product.novoStanje,
        jedinicaMjere: product.jedinicaMjere,
        sifraProizvod: product.sifraProizvod // Zadrži šifru proizvoda
      };

      this.masterService.UpdateProduct(product.proizvodId, updateProductDTO).subscribe(
        (response) => {
          console.log('Uspješno ažurirano stanje proizvoda', response);
          this.loadProducts(); // Ponovo učitaj proizvode nakon ažuriranja
        },
        (error) => {
          console.error('Greška prilikom ažuriranja stanja:', error);
        }
      );
    } else {
      console.warn('Unesite ispravno stanje');
    }
  }*/
    azurirajStanje(product: Product) {
      // Proveri da li novo stanje postoji i da li je veće od 0
      if (product.novoStanje && product.novoStanje > 0) {
        const updateProductDTO = {
          nazivProizvod: product.nazivProizvod,
          cijenaProizvod: product.cijenaProizvod,
          // Dodaj novo stanje postojećem stanju
          stanje: product.stanje + product.novoStanje,
          jedinicaMjere: product.jedinicaMjere,
          sifraProizvod: product.sifraProizvod // Zadrži šifru proizvoda
        };

        this.masterService.UpdateProduct(product.proizvodId, updateProductDTO).subscribe(
          (response) => {
            console.log('Uspješno ažurirano stanje proizvoda', response);
            this.loadProducts(); // Ponovo učitaj proizvode nakon ažuriranja
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
