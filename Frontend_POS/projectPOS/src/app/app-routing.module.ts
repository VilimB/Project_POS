import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { InvoiceListComponent } from './features/invoice/invoice-list/invoice-list.component';
import { AddInvoiceComponent } from './features/invoice/add-invoice/add-invoice.component';

const routes: Routes = [
  {
    path:'proizvodi',
    component:CategoryListComponent
  },
  {
    path:'proizvodi/dodaj',
    component:AddCategoryComponent
  },
  {
    path:'transakcije',
    component:InvoiceListComponent
  },
  {
    path:'kasa',
    component:AddInvoiceComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
