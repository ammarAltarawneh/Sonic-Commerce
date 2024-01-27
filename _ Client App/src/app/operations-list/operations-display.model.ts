export class OperationsDisplayModel {
    public operationId : number;
    public operationTypeName : string;
    public customerName : string;
    public operationDate : Date;
    public grossTotal : number;
    public netTotal : number;

    constructor(operationId: number, operationTypeName: string, customerName: string, 
                operationDate: Date, grossTotal:number,netTotal: number) {

            this.operationId=operationId;
            this.operationTypeName=operationTypeName;
            this.customerName=customerName;
            this.operationDate=operationDate;
            this.grossTotal=grossTotal;
            this.netTotal=netTotal;
         }
}