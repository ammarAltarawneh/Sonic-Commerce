import { CustomerModel } from "../Shared/customer.model";
import { OperationDetailsModel } from "../operation-entry/operation-details.model";
import { OperationTypeModel } from "../Shared/operationtype.model";
import { UsersModel } from "../auth/users.model";

export class OperationModel {
    public operationId : number;
    public userId : UsersModel['userId'];
    public operationTypeId : OperationTypeModel["operationTypeId"];
    public customerId : CustomerModel["customerId"];
    public operationDate : Date;
    public taxTotal : number;
    public discountTotal : number;
    public grossTotal : number;
    public netTotal : number;
    // public operationDetails : OperationDetailsModel[];

    constructor(operationId: number, userId: UsersModel['userId'], operationTypeId: OperationTypeModel["operationTypeId"],
    customerId: CustomerModel["customerId"], operationDate: Date, taxTotal:number, discountTotal: number, 
    grossTotal:number,netTotal: number) {
            this.operationId=operationId;
            this.userId=userId;
            this.operationTypeId=operationTypeId;
            this.customerId=customerId;
            this.operationDate=operationDate;
            this.taxTotal=taxTotal;
            this.discountTotal=discountTotal;
            this.grossTotal=grossTotal;
            this.netTotal=netTotal;
         }
}