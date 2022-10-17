import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { CategoriesComponent } from './categories/categories.component';
import { FormCategoriesComponent } from './form-categories/form-categories.component';
import { CategoriesRoutingModule } from './categories-routing.module';

import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { NgxPaginationModule } from 'ngx-pagination';

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
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatSnackBarModule,
    NgxPaginationModule
  ]
})
export class CategoriesModule { }
