import { NgModule } from '@angular/core';
import { ProductComponent } from './components/product/product.component';
import {RouterModule} from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AuthService } from '../auth/services/auth.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            {path: 'products', component: ProductListComponent, canActivate: [AuthService]}
        ])
    ],
    declarations: [
        ProductComponent
    ]
})
export class ProductModule{

}