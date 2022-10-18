import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoriesComponent } from './categories/categories.component';
import { FormCategoriesComponent } from './form-categories/form-categories.component';


const routes: Routes = [
  {
    path: '',
    component: CategoriesComponent
  },
  {
    path: 'formCategories',
    component: FormCategoriesComponent
  },
  {
    path: 'formCategories/:id',
    component:FormCategoriesComponent,
    pathMatch: 'full'
  }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class CategoriesRoutingModule {}
