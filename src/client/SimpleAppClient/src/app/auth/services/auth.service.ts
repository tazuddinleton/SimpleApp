import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel, LoginResponse } from '../models/login.model';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Router, CanActivate } from '@angular/router';
import { NotificationService } from 'src/app/message/services/notification.service';
import { Message } from 'src/app/message/models/notification';
import { MessageType } from 'src/app/message/models/notification.type';




@Injectable()
export class AuthService implements CanActivate{
  // api should be injected here
  apiBase: string = 'http://localhost:2020/api/';
  user: User
  constructor(
    private http: HttpClient, 
    private router: Router, 
    private notificationService: NotificationService) {}
  canActivate(): boolean  {
    return this.isLoggedIn;
  }
// Todo : detect 
  login(model: LoginModel): void{
      this.http.post(this.apiBase + "account/login", model)
      .subscribe((success:LoginResponse) => {
        localStorage.setItem('bearer_token', success.token);
        localStorage.setItem('token_expires', JSON.stringify(success.expires));
        this.router.navigate(['/dashboard']);
        this.user = {name: model.username};
        localStorage.setItem('username', model.username);
      },(err) => {
        this.handleError(err);
      });
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
    if(error.status == 401){
      this.notificationService.notify({type: MessageType.error, message: "Username/Password does not match"});    
    }else{
      this.notificationService.notify({type: MessageType.error, message: "Something went wrong along the way"});    
    }
    
    this.user = null;
  }  
}
