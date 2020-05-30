import { OnInit, Component } from '@angular/core';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit{
    constructor(){

    }
    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }

}