import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard.component';
import { AuthService } from '../auth/services/auth.service';

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild([
            {path: 'dashboard', component: DashboardComponent, canActivate: [AuthService]}
        ])
    ]
})
export class DashboardModule{

}