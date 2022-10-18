import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SuppliersModule } from './suppliers/suppliers.module';
import { CategoriesModule } from './categories/categories.module';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ErrorDialogComponent } from './error-dialog/error-dialog.component';

import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    ErrorDialogComponent
  ],
  imports: [
    CommonModule,
    CategoriesModule,
    SuppliersModule,
    MatButtonModule,
    RouterModule
  ],
  entryComponents: [ConfirmationDialogComponent]
})
export class NorthwindModule { }
