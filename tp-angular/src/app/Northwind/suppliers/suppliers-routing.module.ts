import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SuppliersComponent } from './suppliers/suppliers.component';

import { FormSuppliersComponent } from './form-suppliers/form-suppliers.component';

const routes: Routes = [
  {
    path: '',
    component: SuppliersComponent
  },
  {
    path: 'formSuppliers',
    component: FormSuppliersComponent
  },
  {
    path: 'formSuppliers/:id',
    component: FormSuppliersComponent,
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
export class SuppliersRoutingModule { }
