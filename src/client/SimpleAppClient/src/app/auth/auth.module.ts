import { NgModule } from '@angular/core';

import {RouterModule} from '@angular/router';
import { LoginComponent } from './components/login.component';



@NgModule({
    imports: [
        RouterModule.forChild([
            {path: 'login', component: LoginComponent}
        ])
    ],
    declarations: [
     
    ]
})
export class AuthModule{

}