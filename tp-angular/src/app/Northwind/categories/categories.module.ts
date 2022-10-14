import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


import { CategoriesComponent } from './categories/categories.component';
import { FormCategoriesComponent } from './form-categories/form-categories.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { HttpClientModule } from '@angular/common/http';

import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    CategoriesComponent,
    FormCategoriesComponent,

  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CategoriesRoutingModule,
    HttpClientModule,
    MatButtonModule
  ]
})
export class CategoriesModule { }
