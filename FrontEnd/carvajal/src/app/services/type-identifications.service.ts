import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TypeIdentification } from '../models/type-identification.model';

@Injectable({
  providedIn: 'root'
})
export class TypeIdentificationsService {
  url: string = environment.urlApi;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<TypeIdentification[]>(`${this.url}/typeidentifications`, this.httpOptions);
  }
}
