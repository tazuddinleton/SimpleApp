import { Injectable } from '@angular/core';
import { IDashboard } from '../models/dashboard';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class DashboardService {
    apiBase: string = 'http://localhost:2020/api/';
    constructor(private http: HttpClient){
        
    }

    get(): Observable<IDashboard>{
        return this.http.get<IDashboard>(this.apiBase + "dashboard");
    }
}