import { Component, OnInit } from '@angular/core';
import { IDashboard } from '../models/dashboard';
import { DashboardService } from '../services/dashboard.service';
import { NotificationService } from 'src/app/common/services/notification.service';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit{
    public dashboard: IDashboard;
    constructor(private dashboardService: DashboardService, private notificationService: NotificationService){

    }

    ngOnInit(): void {
        this.dashboardService.get().subscribe(
            data => this.dashboard = data, 
            error => this.notificationService.notify(error)
            );
    }
}