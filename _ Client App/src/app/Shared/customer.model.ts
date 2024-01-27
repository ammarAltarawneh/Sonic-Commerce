export class CustomerModel{
    public customerId: number;
    public customerName: string;
    constructor(customerId:number, customerName:string){
        this.customerId = customerId;
        this.customerName = customerName;
    }
}