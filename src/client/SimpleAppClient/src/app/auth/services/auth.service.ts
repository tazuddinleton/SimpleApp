import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../models/loginModel';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {
    apiBase: 'http://localhost:2020/api/'
  constructor(private http: HttpClient) {}

  login(model: LoginModel): Observable<any>  {
      return this.http.post(this.apiBase + "account/login", model);
  }
}
