import { OnInit, Component } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/message/services/notification.service';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../models/category';
import {MessageType} from '../../../message/models/notification.type';

@Component({    
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit{
    public product: Product;
    public categories: Category[];
    public errorMsg: string;
    constructor(private productService: ProductService, 
        private categoryService: CategoryService,
        private route: ActivatedRoute,
        private router: Router,
        private notificationService: NotificationService
        ){
        this.product = new Product();
    }
    
    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');
        this.categoryService.getAllCategories().subscribe(data => this.categories = data);
        this.getProduct(+id);
    }

    getProduct(id: number){        
        if(id === 0){
            this.product = new Product();
            return;
        }
        this.productService.getProductById(id).subscribe(data => {
            this.product = data;
        }, error => this.errorMsg = error);
    }

    saveProduct(){
        this.product.categoryId = +this.product.categoryId;
        this.productService.saveProduct(this.product).subscribe(id => {
            if(!this.product.productId){
                this.product.productId = id;
            }
            this.notificationService.displaySuccess("Product saved successfully");
            this.router.navigate(['/products']);
        }, error => {
            this.errorMsg = error;
            this.notificationService.displayError(this.errorMsg);
        })
    }
}