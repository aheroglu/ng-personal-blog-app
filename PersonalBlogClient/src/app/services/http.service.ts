import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { api } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class HttpService<T> {

  constructor(private http: HttpClient) { }

  getAll(endPoint: string): Observable<T[]> {
    return this.http.get<T[]>(`${api}/${endPoint}/GetAll`);
  }

  getById(endPoint: string, id: number): Observable<T> {
    return this.http.get<T>(`${api}/${endPoint}/GetById?id=${id}`);
  }

  getByUrl(endPoint: string, url: string): Observable<T> {
    return this.http.get<T>(`${api}/${endPoint}/GetByUrl?postUrl=${url}`);
  }

  create(endPoint: string, model: T): Observable<T> {
    return this.http.post<T>(`${api}/${endPoint}/Create`, model);
  }

  update(endPoint: string, model: T): Observable<T> {
    return this.http.put<T>(`${api}/${endPoint}/Update`, model);
  }

  delete(endPoint: string, id: number): Observable<T> {
    return this.http.delete<T>(`${api}/${endPoint}/Delete?id=${id}`);
  }

  login(endPoint: string, model: T): Observable<T> {
    return this.http.post<T>(`${api}/${endPoint}/Login`, model);
  }

}
