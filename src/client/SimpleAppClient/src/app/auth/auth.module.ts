import { NgModule, Pipe } from '@angular/core';

import {RouterModule} from '@angular/router';
import { LoginComponent } from './components/login.component';
import { SharedModule } from '../_shared/shared.module';

@NgModule({
    imports: [        
        SharedModule,
        RouterModule.forChild([
            {path: 'login', component: LoginComponent}
        ])        
    ],
    declarations: [
        LoginComponent        
    ]        
})
export class AuthModule{

}