import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CategoriesRequest } from '../models/categoriesRequest';
import { CategoriesService } from '../services/categories.service';
import { ActivatedRoute } from '@angular/router';
import { CategResponse } from '../models/categResp';


@Component({
  selector: 'app-form-categories',
  templateUrl: './form-categories.component.html',
  styleUrls: ['./form-categories.component.css'],
})

export class FormCategoriesComponent implements OnInit {
  categoriesForm!: FormGroup;
  updateData!: CategResponse;
  addMode: boolean = true;

  constructor(
    private fb: FormBuilder,
    private categoriesService: CategoriesService,
    private _snackBar: MatSnackBar,
    private _route: ActivatedRoute) {}

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

  ngOnInit() {
    this.editOrAdd();
    this.categoriesForm = this.fb.group({
      ID: [{ value: null, disabled: true }],
      name: ['',Validators.compose([Validators.required, Validators.maxLength(15)])],
      description: ['', Validators.maxLength(300)],
    });
  }

  onSubmit() {}

  editOrAdd() {
    let id = Number(this._route.snapshot.paramMap.get('id'));
    if (id != 0) {
      this.loadUpdateData(id);
      this.addMode = false;
    }
  }

  private loadUpdateData(id: number) {
    this.categoriesService.getCategoriesById(id).subscribe((res) => {
      this.updateData = res;
      this.categoriesForm.patchValue({
        name: this.updateData.Name,
        description: this.updateData.Description,
      });
    });
  }

  saveCategory() {
    var category = new CategoriesRequest();
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
    this.categoriesService.addCategories(category).subscribe((res) => {
    this.categoriesForm.reset();
    this.openSnackBar('The category was add succesfully', 'Dismiss');
    });
  }

  private updateCategory(category: CategoriesRequest){
    let id = Number(this._route.snapshot.paramMap.get('id'));
    category.ID = id;
    this.categoriesService.updateCategories(category).subscribe((res) => {
      this.categoriesForm.reset();
      this.openSnackBar('The category was update succesfully', 'Dismiss');
    });
  }

}
