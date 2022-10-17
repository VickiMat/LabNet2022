import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoriesResponse } from '../models/categoriesResponse';
import { CategoriesRequest } from '../models/categoriesRequest';


@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  endpoint: string = 'categories';
  url: string = environment.apiBase + this.endpoint;


  constructor(private http: HttpClient) {}

  public addCategories(categoriesRequest: CategoriesRequest): Observable<Object> {
    return this.http.post(this.url, categoriesRequest);
  }

  public updateCategories(categoriesRequest: CategoriesRequest): Observable<Object> {
    return this.http.put(this.url, categoriesRequest);
  }

  public getCategories(): Observable<Array<CategoriesResponse>> {
    return this.http.get<Array<CategoriesResponse>>(this.url);
  }

  public deleteCategories(categID: number): Observable<Object> {
    return this.http.delete<number>(this.url + "/" + categID);
  }

  public getCategoriesById(categID: number): Observable<CategoriesResponse> {
    return this.http.get<CategoriesResponse>(this.url + "/" + categID);
  }
}
