import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard.component';
import { AuthService } from '../auth/services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({   
    declarations: [
        DashboardComponent
    ], 
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            {path: 'dashboard', component: DashboardComponent, canActivate: [AuthService]}
        ])
    ]
})
export class DashboardModule{

}