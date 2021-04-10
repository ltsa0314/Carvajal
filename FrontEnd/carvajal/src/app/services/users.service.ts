import { User } from './../models/user.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class UsersService {
  url: string = environment.urlApi;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  insert(model: User) {
    return this.http.post<User>(
      `${this.url}/users`,
      JSON.stringify(model),
      this.httpOptions
    );
  }

  update(model: User) {
    return  this.http.put<any>(
      `${this.url}/users`,
      JSON.stringify(model),
      this.httpOptions
    );
  }

  delete(id: number) {
    return this.http.delete<any>(`${this.url}/users/${id}`, this.httpOptions);
  }

  getAll() {
    return this.http.get<User[]>(`${this.url}/users`, this.httpOptions);
  }

  getById(id: number) {
    return this.http.get<User>(`${this.url}/users/${id}`, this.httpOptions);
  }
}
