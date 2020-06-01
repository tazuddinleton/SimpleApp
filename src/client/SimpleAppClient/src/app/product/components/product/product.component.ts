import { OnInit, Component } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/productService';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/common/services/notification.service';

@Component({    
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit{
    public product: Product;
    public errorMsg: string;
    constructor(private productService: ProductService, 
        private route: ActivatedRoute,
        private router: Router,
        private notificationService: NotificationService
        ){
        
    }
    
    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');
        this.getProduct(+id);
    }

    getProduct(id: number){        
        this.productService.getProductById(id).subscribe(data => {
            this.product = data;
        }, error => this.errorMsg = error);
    }

    saveProduct(){
        this.productService.saveProduct(this.product).subscribe(id => {
            if(!this.product.productId){
                this.product.productId = id;
            }
            this.notificationService.notify("Product saved successfully");
            this.router.navigate(['/products']);
        }, error => this.errorMsg = error)
    }
}