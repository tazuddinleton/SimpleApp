export interface IDashboard {
    totalNumOfProducts: number;
    numOfProductByUser: number;
    productCategories: IProductCategories[];        
}

export interface IProductCategories {
    category: string;
    numberOfProducts: number;
}