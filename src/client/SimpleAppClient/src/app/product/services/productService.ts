import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable()
export class ProductService {
    // todo: make it injected
    apiBase: string = 'http://localhost:2020/api/';
    constructor(private http: HttpClient){

    }

    getAllProducts(): Observable<Product[]>{
        return this.http.get<Product[]>(this.apiBase + "product");
    }

    getProductById(id: number): Observable<Product>{
        return this.http.get<Product>(this.apiBase + "product/"+id.toString());
    }

    saveProduct(product: Product){
        return this.http.post<number>(this.apiBase + "product", product);
    }
}