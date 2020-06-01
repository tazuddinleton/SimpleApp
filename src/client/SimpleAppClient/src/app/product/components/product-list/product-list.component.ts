import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{

    public pageTitle: string = "This is product list page!";    
    public products: Product[] = [];
    constructor(private productService:ProductService){
        
    }
    ngOnInit(): void {
        this.productService.getAllProducts().subscribe(data => {
            this.products = data;

        });
    }
}