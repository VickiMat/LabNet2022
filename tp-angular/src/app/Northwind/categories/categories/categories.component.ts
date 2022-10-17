import { Component, OnInit } from '@angular/core';
import { CategoriesResponse } from '../models/categoriesResponse';
import { CategoriesService } from '../services/categories.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorDialogComponent } from '../../error-dialog/error-dialog.component';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  dialogRef?: MatDialogRef<ConfirmationDialogComponent>;
  dialogError?: MatDialogRef<ErrorDialogComponent>;

  public categList: Array<CategoriesResponse> = []

  constructor(
    private categoriesService: CategoriesService,
    private _snackBar: MatSnackBar,
    private dialog: MatDialog) { }

  openSnackBar(message: string, action: string, duration: number = 10000) {
    this._snackBar.open(message, action, { duration: duration });
  }

  ngOnInit():void {
    this.getCategories();
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe(res =>{
      this.categList = res;
    }, (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)})
  }

  openErrorDialog(messageError: string){
    this.dialogError = this.dialog.open(ErrorDialogComponent,{
      disableClose: false
    });
    this.dialogError.componentInstance.errorMessage = messageError;
  }

  openConfirmationDialog(categId: number) {
    this.dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      disableClose: false
    });
    this.dialogRef.componentInstance.confirmMessage = "Are you sure you want to delete the category with id " + categId + "?";

    this.dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.deleteCategory(categId);
        this.openSnackBar("The category was succesfully deleted", 'Dismiss');
      }
    });
  }

  private deleteCategory(categId: number){
    this.categoriesService.deleteCategories(categId).subscribe( categ =>{
      this.getCategories();
    },
    (err: HttpErrorResponse) => {this.openErrorDialog("Status code: " + err.status + " - " + err.error)})
  };

}
