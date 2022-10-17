import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { ErrorDialogComponent } from '../../error-dialog/error-dialog.component';
import { SuppliersResponse } from '../models/suppliersResponse';
import { SuppliersService } from '../services/suppliers.service';
import { SuppliersRequest } from '../models/suppliersRequest';

import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-form-suppliers',
  templateUrl: './form-suppliers.component.html',
  styleUrls: ['./form-suppliers.component.css']
})
export class FormSuppliersComponent implements OnInit {
  suppliersForm!: FormGroup;
  updateData!: SuppliersResponse;
  addMode: boolean = true;
  dialogError?: MatDialogRef<ErrorDialogComponent>;
  modeTitle: string = 'Add';

  constructor(
    private _fb: FormBuilder,
    private _suppliersService: SuppliersService,
    private _snackBar: MatSnackBar,
    private _route: ActivatedRoute,
    private _router: Router,
    private _dialog: MatDialog) {}

  openSnackBar(message: string, action: string, duration: number = 10000) {
    this._snackBar.open(message, action, { duration: duration });
  }

  ngOnInit(): void {
    this.editOrAdd();
    this.suppliersForm = this._fb.group({
      ID: [null],
      companyName: ['', [Validators.required, Validators.maxLength(40)]],
      contactName: ['', Validators.maxLength(30)],
      city: ['', [Validators.required, Validators.maxLength(15)]],
      country: ['', [Validators.required, Validators.maxLength(15)]],
    });
  }

  onSubmit() {}

  editOrAdd() {
    let id = Number(this._route.snapshot.paramMap.get('id'));
    if (id != 0) {
      this.loadUpdateData(id);
      this.addMode = false;
      this.modeTitle = 'Update';
    }
  }

  private loadUpdateData(id: number) {
    this._suppliersService.getSupplierById(id).subscribe((res) => {
      this.updateData = res;
      this.suppliersForm.patchValue({
        ID: this.updateData.Id,
        companyName: this.updateData.CompanyName,
        contactName: this.updateData.ContactName,
        city: this.updateData.City,
        country: this.updateData.Country
      })
    },
    (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)});
  }

  saveSupplier() {
    var supplier = new SuppliersRequest();
    supplier.Id = this.suppliersForm.get('ID')?.value;
    supplier.CompanyName = this.suppliersForm.get('companyName')?.value;
    supplier.ContactName = this.suppliersForm.get('contactName')?.value;
    supplier.City = this.suppliersForm.get('city')?.value;
    supplier.Country = this.suppliersForm.get('country')?.value;

    if (this.addMode) {
     this.addSupplier(supplier)
    }
    else if (!this.addMode) {
      this.updateSupplier(supplier)
    }
  }

  private addSupplier(supplier: SuppliersRequest){
    this._suppliersService.addSupplier(supplier).subscribe((res) => {
    this.suppliersForm.reset();
    this.openSnackBar(res.toString(), 'Dismiss');
    this._router.navigate(['suppliers']);
    },
    (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)});
  }

  private updateSupplier(supplier: SuppliersRequest){
    this._suppliersService.updateSupplier(supplier).subscribe((res) => {
      this.suppliersForm.reset();
      this.openSnackBar(res.toString(), 'Dismiss');
      this._router.navigate(['categories']);
    },
    (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)});
  }

  openErrorDialog(messageError: string){
    this.dialogError = this._dialog.open(ErrorDialogComponent,{
      disableClose: false
    });
    this.dialogError.componentInstance.errorMessage = messageError;
  }


}
