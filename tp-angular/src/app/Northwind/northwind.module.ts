import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SuppliersModule } from './suppliers/suppliers.module';
import { CategoriesModule } from './categories/categories.module';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import {MatButtonModule} from '@angular/material/button';



@NgModule({
  declarations: [
    ConfirmationDialogComponent
  ],
  imports: [
    CommonModule,
    CategoriesModule,
    SuppliersModule,
    MatButtonModule
  ],
  entryComponents: [ConfirmationDialogComponent]
})
export class NorthwindModule { }
