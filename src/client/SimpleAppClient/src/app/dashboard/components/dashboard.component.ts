import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit{

    public message: string;
    public items: number[] = [];

    ngOnInit(): void {
        this.message = 'Dashboard will be shown here';
        this.items = [1,2,3];
    }    
}