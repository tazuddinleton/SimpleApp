export class Product {
    productId?: number;
    categoryId:number;
    productName:string;
    description:string;
    unitPrice:number;

    constructor(){
        this.productId = 0;
        this.categoryId = 0;
        this.productName = null;
        this.description = null;
        this.unitPrice = 0;
    }
}
