import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';
import { ErrorDialogComponent } from '../../error-dialog/error-dialog.component';
import { SuppliersResponse } from '../models/suppliersResponse';
import { SuppliersService } from '../services/suppliers.service';

import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {

  dialogRef?: MatDialogRef<ConfirmationDialogComponent>;
  dialogError?: MatDialogRef<ErrorDialogComponent>;

  public supList: Array<SuppliersResponse> = []

  constructor(
    private _suppliersService: SuppliersService,
    private _snackBar: MatSnackBar,
    private _dialog: MatDialog) { }

    openSnackBar(message: string, action: string, duration: number = 10000) {
      this._snackBar.open(message, action, { duration: duration });
    }

  ngOnInit(): void {
    this.getSuppliers();
  }

  getSuppliers(){
    this._suppliersService.getSuppliers().subscribe(res =>{
      this.supList = res;
    }, (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)})
  }

  private deleteCategory(supId: number){
    this._suppliersService.deleteSupplier(supId).subscribe( sup =>{
      this.getSuppliers();
    },
    (err: HttpErrorResponse) => {this.openErrorDialog("Status code: " + err.status + " - " + err.error)})
  }

  openErrorDialog(messageError: string){
    this.dialogError = this._dialog.open(ErrorDialogComponent,{
      disableClose: false
    });
    this.dialogError.componentInstance.errorMessage = messageError;
  }

  openConfirmationDialog(supId: number) {
    this.dialogRef = this._dialog.open(ConfirmationDialogComponent, {
      disableClose: false
    });
    this.dialogRef.componentInstance.confirmMessage = "Are you sure you want to delete the supplier with id " + supId + "?";
    this.dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.deleteCategory(supId);
        this.openSnackBar("The supplier was succesfully deleted", 'Dismiss');
      }
    });
  }




}
