import { NgModule } from '@angular/core';
import { ProductComponent } from './components/product/product.component';
import {RouterModule} from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AuthService } from '../auth/services/auth.service';
import { ProductService } from './services/product.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService } from './services/category.service';


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
        ProductService,
        CategoryService
    ]
})
export class ProductModule{

}