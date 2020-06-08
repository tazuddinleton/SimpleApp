import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { LoginModel, LoginResponse } from '../models/login.model';
import { Observable, throwError } from 'rxjs';
import { User } from '../models/user';
import { Router, CanActivate } from '@angular/router';
import { catchError } from 'rxjs/operators';




@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate{
  // api should be injected here
  apiBase: string = 'http://localhost:2020/api/';
  user: User
  constructor(
    private http: HttpClient, 
    private router: Router, 
    ) {}
  canActivate(): boolean  {
    return this.isLoggedIn;
  }
// Todo : detect 
  login(model: LoginModel): Observable<any>{
      return this.http.post(this.apiBase + "account/login", model);
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

  
  handleError(error: HttpErrorResponse, caught: Observable<any>) : any{
    // log the error to a remote error loging system
    let errorMsg: string = "An error occured. " + error.message;
    console.log(errorMsg);
    return throwError(errorMsg);
}
}
