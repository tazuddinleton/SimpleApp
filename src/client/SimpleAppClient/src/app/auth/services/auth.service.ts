import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel, LoginResponse } from '../models/login.model';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Router, CanActivate } from '@angular/router';



@Injectable()
export class AuthService implements CanActivate{
  // api should be injected here
  apiBase: string = 'http://localhost:2020/api/';
  user: User
  constructor(private http: HttpClient, private router: Router) {}
  canActivate(): boolean  {
    return this.isLoggedIn;
  }

  login(model: LoginModel): void{
      this.http.post(this.apiBase + "account/login", model)
      .subscribe((success:LoginResponse) => {
        localStorage.setItem('bearer_token', success.token);
        localStorage.setItem('token_expires', JSON.stringify(success.expires));
        this.router.navigate(['/dashboard']);
        this.user = {name: model.username};
        localStorage.setItem('username', model.username);
      },this.handleError);
  }
  
  get isLoggedIn():boolean {
    return !!this.user;
  }

  logOut(){
    this.user = null;
    localStorage.clear();
    this.router.navigate(['/']);
  }

  logUserInOnRefresh(){
    const token = localStorage.getItem('bearer_token');
    if(token){
      this.user = {name: localStorage.getItem('username')};
    }
  }

  private handleError(error: any){
    this.user = null;
  }  
}
