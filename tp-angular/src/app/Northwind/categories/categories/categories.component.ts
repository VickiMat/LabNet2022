import { Component, OnInit } from '@angular/core';
import { CategResponse } from '../models/categResp';
import { CategoriesService } from '../services/categories.service';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  public categList: Array<CategResponse> = []

  constructor(private categoriesService: CategoriesService) { }

  ngOnInit():void {
    this.getCategories();
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe(res =>{
      this.categList = res;
    })
  }

}
