export class OperationTypeModel{
    public operationTypeId: number;
    public operationTypeName: string;
    constructor(operationTypeId:number, operationTypeName:string){
        this.operationTypeId = operationTypeId;
        this.operationTypeName = operationTypeName;
    }
}