import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable()
export class CategoryService {
    // todo: make it injected
    apiBase: string = 'http://localhost:2020/api/';
    constructor(private http: HttpClient){

    }

    getAllCategories(): Observable<Category[]>{
        return this.http.get<Category[]>(this.apiBase + "category");
    }
}