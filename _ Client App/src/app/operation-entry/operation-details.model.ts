import { OperationModel } from "../operations-list/operation.model";
import { ItemModel } from "../product-management/items/item.model";

export class OperationDetailsModel{
    public operationId : OperationModel["operationId"];
    public itemId: ItemModel["itemId"];
    public quantity:number;
    constructor(operationId : OperationModel["operationId"],itemId: ItemModel["itemId"], quantity: number) {
        this.operationId = operationId;
        this.itemId = itemId;
        this.quantity=quantity;
    }
}