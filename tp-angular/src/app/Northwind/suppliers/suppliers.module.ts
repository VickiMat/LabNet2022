import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { SuppliersComponent } from './suppliers/suppliers.component';
import { FormSuppliersComponent } from './form-suppliers/form-suppliers.component';
import { SuppliersRoutingModule } from './suppliers-routing.module';

import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    SuppliersComponent,
    FormSuppliersComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SuppliersRoutingModule,
    HttpClientModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatSnackBarModule
  ]
})
export class SuppliersModule { }
