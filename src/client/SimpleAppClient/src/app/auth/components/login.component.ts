import { LoginModel } from '../models/loginModel';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']    
})
export class LoginComponent{
    constructor(private authService: AuthService){

    }

    login(form: NgForm){        
        console.log(form);
    }
}