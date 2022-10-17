import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomePageComponent } from './home-page/home-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  { path: 'categories',
  loadChildren: () => import('./Northwind/categories/categories.module').then(m => m.CategoriesModule)},
  { path: 'suppliers',
  loadChildren: () => import('./Northwind/suppliers/suppliers.module').then(m => m.SuppliersModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
