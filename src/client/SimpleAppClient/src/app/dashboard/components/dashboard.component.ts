import {
  Component,
  OnInit,
  AfterViewInit,
  AfterViewChecked,
} from '@angular/core';
import { IDashboard } from '../models/dashboard';
import { DashboardService } from '../services/dashboard.service';
import { NotificationService } from 'src/app/message/services/notification.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit, AfterViewChecked {
  public dashboard: IDashboard;

  public categories: string[];
  public numberOfProducts: number[];

  public barChart: any;
  public pieChart: any
  constructor(
    private dashboardService: DashboardService,
    private notificationService: NotificationService
  ) {}
  ngAfterViewChecked(): void {
    this.draBarChart();
  }

  draBarChart(): void {
    if (this.barChart) {
      return;
    }

    if (!this.dashboard) {
      return;
    }

    let categories = this.dashboard.productCategories.map((pc) => pc.category);
    let numberOfProducts = this.dashboard.productCategories.map(
      (pc) => pc.numberOfProducts
    );

    let context = document.getElementById('categoryWiseProducts');

    this.barChart = new Chart(context, {
      type: 'bar',
      data: {
        labels: categories,
        datasets: [
          {
            data: numberOfProducts,
            borderWidth: 1,
          },
        ],
      },
      options: {
        legend: {
          display: false,
        },
        scalses: {
          xAxes: [{ display: true }],
          yAxes: [{ display: true }],
        },
      },
    });
  }

  draPieChart(): void {
    if (this.pieChart) {
      return;
    }

    if (!this.dashboard) {
      return;
    }

    let categories = this.dashboard.productCategories.map((pc) => pc.category);
    let numberOfProducts = this.dashboard.productCategories.map(
      (pc) => pc.numberOfProducts
    );

    let context = document.getElementById('pieChart');

    this.barChart = new Chart(context, {
      type: 'pie',
      data: {
        labels: categories,
        datasets: [
          {
            data: numberOfProducts,
            borderWidth: 1,
          },
        ],
      },
      options: {
        legend: {
          display: false,
        },
        scalses: {
          xAxes: [{ display: true }],
          yAxes: [{ display: true }],
        },
      },
    });
  }

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard() {
    this.dashboardService.get().subscribe(
      (data) => (this.dashboard = data),
      (error) => this.notificationService.notify(error)
    );
  }
}
