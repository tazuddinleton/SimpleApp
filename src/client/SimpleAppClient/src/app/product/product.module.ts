import { NgModule } from '@angular/core';
import { ProductComponent } from './components/product/product.component';
import {RouterModule} from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AuthService } from '../auth/services/auth.service';
import { ProductService } from './services/productService';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@NgModule({
    declarations: [
        ProductListComponent,
        ProductComponent 
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            {path: 'products', component: ProductListComponent, canActivate: [AuthService]},
            {path: 'products/:id/edit', component: ProductComponent, canActivate: [AuthService]}
        ])
    ],
   
    providers:[
        ProductService
    ]
})
export class ProductModule{

}