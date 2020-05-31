import { OnInit, Component } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/productService';

@Component({    
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit{
    product: Product;
    constructor(private productService: ProductService){
        
    }
    
    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }

}