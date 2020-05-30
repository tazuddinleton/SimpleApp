import { LoginModel } from '../models/loginModel';
import { Component } from '@angular/core';


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent{
    constructor(){

    }

    login(model: LoginModel){

    }
}