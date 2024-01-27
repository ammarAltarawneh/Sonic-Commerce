import { ItemModel } from "../product-management/items/item.model";

export class ItemWithQuantityModel {
    public item: ItemModel;
    public quantity: number | null;
    constructor(item: ItemModel, quantity: number | null) {
        this.item = item;
        this.quantity= quantity;
    }
}