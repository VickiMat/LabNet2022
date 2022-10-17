import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { SuppliersRequest } from '../models/suppliersRequest';
import { SuppliersResponse } from '../models/suppliersResponse';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {
  endpoint: string = 'suppliers';
  url: string = environment.apiBase + this.endpoint;

  constructor(private http: HttpClient) { }

  public getSuppliers(): Observable<Array<SuppliersResponse>> {
    return this.http.get<Array<SuppliersResponse>>(this.url);
  }

  public getSupplierById(supId: number): Observable<SuppliersResponse> {
    return this.http.get<SuppliersResponse>(this.url + "/" + supId);
  }

  public getSuppliersByCity(city: string): Observable<Array<SuppliersResponse>> {
    return this.http.get<Array<SuppliersResponse>>(this.url + "/" + city);
  }

  public addSupplier(suppliersRequest: SuppliersRequest): Observable<Object> {
    return this.http.post(this.url, suppliersRequest);
  }

  public updateSupplier(suppliersRequest: SuppliersRequest): Observable<Object> {
    return this.http.put(this.url, suppliersRequest);
  }

  public deleteSupplier(supId: number): Observable<number> {
    return this.http.delete<number>(this.url + "/" + supId);
  }

}
