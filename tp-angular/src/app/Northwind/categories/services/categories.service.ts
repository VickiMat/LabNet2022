import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategResponse } from '../models/categResp';
import { CategoriesRequest } from '../models/categoriesRequest';


@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  endpoint: string = 'categories';
  url: string = environment.apiBase + this.endpoint;


  constructor(private http: HttpClient) {}

  public addCategories(categoriesRequest: CategoriesRequest): Observable<any> {
    return this.http.post(this.url, categoriesRequest);
  }

  public updateCategories(categoriesRequest: CategoriesRequest): Observable<any> {
    return this.http.put(this.url, categoriesRequest);
  }

  public getCategories(): Observable<Array<CategResponse>> {
    return this.http.get<Array<CategResponse>>(this.url);
  }

  public deleteCategories(categID: number): Observable<number> {
    return this.http.delete<number>(this.url + "/" + categID);
  }

  public getCategoriesById(categID: number): Observable<CategResponse> {
    return this.http.get<CategResponse>(this.url + "/" + categID);
  }
}
