import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { CategoriesRequest } from '../models/categoriesRequest';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-form-categories',
  templateUrl: './form-categories.component.html',
  styleUrls: ['./form-categories.component.css']
})
export class FormCategoriesComponent implements OnInit {

  categoriesForm!: FormGroup;

  constructor(private fb: FormBuilder, private categoriesService: CategoriesService) { }

  ngOnInit() {
    this.categoriesForm = this.fb.group({
      name: [''],
      description: ['']
    });
  }

  onSubmit(){

  }

  saveCategory(){
    var category = new CategoriesRequest();
    category.Name = this.categoriesForm.get('name')?.value;
    category.Description = this.categoriesForm.get('description')?.value;

    this.categoriesService.addCategories(category).subscribe(res =>{
      this.categoriesForm.reset();
    })
  }
}
