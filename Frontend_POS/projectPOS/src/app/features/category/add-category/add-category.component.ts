import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

  model = {
      sifraProizvoda: '',
      naziv: '',
      kolicina: 1,
      cijena: 1,
      stanje: 1,
  };

  constructor(private http: HttpClient) {}

  onFormSubmit() {
    this.http.post<any>('http://localhost:5045/api/Proizvod', this.model).subscribe(
      response => {

        console.log('Uspješno dodan proizvod:', response);
      },
      error => {

        console.error('Greška prilikom dodavanja proizvoda:', error);
      }
    );
  }
}
