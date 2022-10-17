import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { ErrorDialogComponent } from '../../error-dialog/error-dialog.component';
import { CategoriesResponse } from '../models/categoriesResponse';
import { CategoriesRequest } from '../models/categoriesRequest';
import { CategoriesService } from '../services/categories.service';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-form-categories',
  templateUrl: './form-categories.component.html',
  styleUrls: ['./form-categories.component.css'],
})

export class FormCategoriesComponent implements OnInit {
  categoriesForm!: FormGroup;
  updateData!: CategoriesResponse;
  addMode: boolean = true;
  dialogError?: MatDialogRef<ErrorDialogComponent>;
  modeTitle: string = 'Add';

  constructor(
    private _fb: FormBuilder,
    private _categoriesService: CategoriesService,
    private _snackBar: MatSnackBar,
    private _route: ActivatedRoute,
    private _router: Router,
    private _dialog: MatDialog) {}

  openSnackBar(message: string, action: string, duration: number = 10000) {
    this._snackBar.open(message, action, { duration: duration });
  }

  ngOnInit() {
    this.editOrAdd();
    this.categoriesForm = this._fb.group({
      ID: [null],
      name: ['', [Validators.required, Validators.maxLength(15)]],
      description: ['', Validators.maxLength(300)],
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
    this._categoriesService.getCategoriesById(id).subscribe((res) => {
      this.updateData = res;
      this.categoriesForm.patchValue({
        ID: this.updateData.ID,
        name: this.updateData.Name,
        description: this.updateData.Description
      })
    },
    (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)});
  }

  saveCategory() {
    var category = new CategoriesRequest();
    category.ID = this.categoriesForm.get('ID')?.value;
    category.Name = this.categoriesForm.get('name')?.value;
    category.Description = this.categoriesForm.get('description')?.value;

    if (this.addMode) {
     this.addCategory(category)
    }
    else if (!this.addMode) {
      this.updateCategory(category)
    }
  }

  private addCategory(category: CategoriesRequest){
    this._categoriesService.addCategories(category).subscribe((res) => {
    this.categoriesForm.reset();
    this.openSnackBar(res.toString(), 'Dismiss');
    this._router.navigate(['categories']);
    },
    (err: HttpErrorResponse)=>{ this.openErrorDialog("Status code: " + err.status + " - " + err.error)});
  }

  private updateCategory(category: CategoriesRequest){
    this._categoriesService.updateCategories(category).subscribe((res) => {
      this.categoriesForm.reset();
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
