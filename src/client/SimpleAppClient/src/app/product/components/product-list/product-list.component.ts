import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { NotificationService } from 'src/app/message/services/notification.service';


@Component({
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{

    private _listFilter:string = '';

    public pageTitle: string = "This is product list page!";    
    public products: Product[] = [];
    public filteredProducts: Product[];
    public showImage:boolean = false;
    
    get listFilter(){
        return this._listFilter;
    }
    set listFilter(filter: string){
        this._listFilter = filter;
        this.filteredProducts = this._listFilter ? this.applyFilterOnProductList() : this.products;
    }
    

    constructor(private productService:ProductService,
        private notificationService: NotificationService
        ){
               
    }

    ngOnInit(): void {
        this.productService.getAllProducts()
        .subscribe(data => {
            this.products = data;
            this.filteredProducts = this.products; 
        }, (error) => this.notificationService.displayError(error)
        );
    }
    
    toggleImage(){
        this.showImage = !this.showImage;
    }

    private applyFilterOnProductList() : Product[]{
        return this.products.filter(product => 
                product.productName.toLocaleLowerCase().indexOf(this._listFilter.toLocaleLowerCase()) > -1
            );
    }

}
