import { CategoryModel } from "../categories/category.model";

export class ItemModel {
    public itemId: number;
    public categoryId: CategoryModel["categoryId"];
    public itemName: string;
    public price:number;
    public discount: number;
    public tax: number;
    constructor(itemId: number,categoryId:CategoryModel["categoryId"], itemName: string, price:number,
        discount: number, tax: number) {
            this.itemId = itemId;
            this.categoryId=categoryId;
            this.itemName = itemName;
            this.price = price;
            this.discount = discount;
            this.tax=tax;
        }
}