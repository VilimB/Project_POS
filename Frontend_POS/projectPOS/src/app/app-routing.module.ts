import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { InvoiceListComponent } from './features/invoice/invoice-list/invoice-list.component';
import { AddInvoiceComponent } from './features/invoice/add-invoice/add-invoice.component';
import { LoginComponent } from './features/login/login.component';
import { HomeComponent } from './features/home/home.component';
import { RegistrationComponent } from './features/registration/registration.component';


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
  {
  path:'transakcije/kasa',
    component:AddInvoiceComponent
  },
  {
    path:'login',
      component:LoginComponent
    },
    {
      path:'dodaj',
      component:AddCategoryComponent
    },
    {
    path:'dodaj/proizvodi',
    component:CategoryListComponent
    },

    {
    path: 'register', // Add this route for the registration component
    component: RegistrationComponent
  },
    {
      path:'',
        component:HomeComponent
      },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
