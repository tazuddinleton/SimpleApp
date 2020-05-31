import { LoginModel } from '../models/login.model';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: []

})
export class LoginComponent{
    constructor(private authService: AuthService){

    }

    login(form: NgForm){        
        if(form && form.valid){
           const username = form.value.username ;
           const password = form.value.password ;
           if(username && password){
            this.authService.login({username, password});
           }           
        }      
    }
}