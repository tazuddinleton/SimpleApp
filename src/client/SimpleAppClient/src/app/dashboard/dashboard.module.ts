import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard.component';
import { AuthService } from '../auth/services/auth.service';
import { DashboardService } from './services/dashboard.service';
import { SharedModule } from '../_shared/shared.module';

@NgModule({   
    imports: [       
        SharedModule,
        RouterModule.forChild([
            {path: 'dashboard', component: DashboardComponent, canActivate: [AuthService]}
        ])
    ],
    declarations: [
        DashboardComponent
    ], 
    
    providers: [
        DashboardService
    ]
})
export class DashboardModule{

}