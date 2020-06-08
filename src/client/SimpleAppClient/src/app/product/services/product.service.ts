import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Product } from '../models/product';
import { Observable, throwError } from 'rxjs';
import {catchError, tap} from 'rxjs/operators';

@Injectable()
export class ProductService {
    // todo: make it injected
    apiBase: string = 'http://localhost:2020/api/';
    constructor(private http: HttpClient){

    }

    getAllProducts(): Observable<Product[]>{
        return this.http.get<Product[]>(this.apiBase + "product")
        .pipe(
            tap(data => console.log(data)),
            catchError(this.handleError)
        );
        ;
    }

    getProductById(id: number): Observable<Product>{
        return this.http.get<Product>(this.apiBase + "product/"+id.toString());
    }

    saveProduct(product: Product){        
        return this.http.post<number>(this.apiBase + "product", product);
    }

    handleError(error: HttpErrorResponse, caught: Observable<any>) : any{
        // log the error to a remote error loging system
        let errorMsg: string = "An error occured. " + error.message;
        console.log(errorMsg);
        throwError(errorMsg);
    }

    
}