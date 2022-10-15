import { Component, OnInit } from '@angular/core';
import { CategResponse } from '../models/categResp';
import { CategoriesService } from '../services/categories.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  dialogRef?: MatDialogRef<ConfirmationDialogComponent>;

  public categList: Array<CategResponse> = []

  constructor(private categoriesService: CategoriesService, public dialog: MatDialog, private _snackBar: MatSnackBar) { }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

  ngOnInit():void {
    this.getCategories();
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe(res =>{
      this.categList = res;
    })
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
    })
  }

}
