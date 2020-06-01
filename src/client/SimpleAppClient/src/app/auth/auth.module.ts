import { NgModule, Pipe } from '@angular/core';

import {RouterModule} from '@angular/router';
import { LoginComponent } from './components/login.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            {path: 'login', component: LoginComponent}
        ])        ,
        CommonModule
    ],
    declarations: [
        LoginComponent        
    ]    
})
export class AuthModule{

}