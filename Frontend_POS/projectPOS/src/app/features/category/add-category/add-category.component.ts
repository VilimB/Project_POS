import { Component } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.models';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {

  model: AddCategoryRequest;

  constructor(){
    this.model ={
      sifra: 0,
      name: '',
      mjera: 0,
      cijena: 0,
      stanje: 0,

    }
  }


  onFormSubmit(){

  }

}
