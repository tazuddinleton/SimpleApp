import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard.component';

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild([
            {path: 'dashboard', component: DashboardComponent}
        ])
    ]
})
export class DashboardModule{

}