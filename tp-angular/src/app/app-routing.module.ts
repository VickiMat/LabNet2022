import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CategoriesComponent } from './Northwind/categories/categories/categories.component';
import { FormCategoriesComponent } from './Northwind/categories/form-categories/form-categories.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  /*{
    path: "categories", component: CategoriesComponent
  },
  {
    path: "categories/form", component: FormCategoriesComponent
  }*/
  { path: 'categories',
  loadChildren: () => import('./Northwind/categories/categories.module').then(m => m.CategoriesModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
