import { LoginModel, LoginResponse } from '../models/login.model';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/message/services/notification.service';
import { MessageType } from 'src/app/message/models/notification.type';


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: []

})
export class LoginComponent{

    errorMsg: string;
    loginModel: LoginModel;

    constructor(private authService: AuthService, 
        private router: Router,
        private notificationService: NotificationService
        ){

    }

    login(form: NgForm){        
        if(!form || !form.valid){
            return;
        }

        const username = form.value.username ;
        const password = form.value.password ;

        if(!username || !password){
            return;
        }
        
        this.loginModel = {username, password};
            this.authService.login(this.loginModel)
            .subscribe(
                (success:LoginResponse) => {
                    this.handleLoginSuccess(success)
                },
                error => {
                    this.errorMsg = error
                    this.handleError(this.errorMsg);
                }
                );
    }

    handleLoginSuccess(success:LoginResponse){
        localStorage.setItem('bearer_token', success.token);
        localStorage.setItem('token_expires', JSON.stringify(success.expires));
        this.router.navigate(['/dashboard']);
        this.authService.user = {name: this.loginModel.username};
        localStorage.setItem('username', this.loginModel.username);
    }
    
    handleError(error: any){
    if(error.status == 401){
      this.notificationService.notify({type: MessageType.error, message: "Username/Password does not match"});    
    }else{
      this.notificationService.notify({type: MessageType.error, message: error});    
    }    
    this.authService.user = null;
  }
}