import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SuppliersModule } from './suppliers/suppliers.module';
import { CategoriesModule } from './categories/categories.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CategoriesModule,
    SuppliersModule
  ]
})
export class NorthwindModule { }
