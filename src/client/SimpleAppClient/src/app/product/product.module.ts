import { NgModule } from '@angular/core';
import { ProductComponent } from './components/product/product.component';
import {RouterModule} from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            {path: 'products', component: ProductListComponent}
        ])
    ],
    declarations: [
        ProductComponent
    ]
})
export class ProductModule{

}