import { UsersModel } from "../../auth/users.model";

export class CategoryModel{
    public categoryId: number;
    public categoryName: string;
    public userId: UsersModel["userId"];
    constructor(categoryId:number, categoryName:string, userId: UsersModel["userId"]){
        this.categoryId = categoryId;
        this.categoryName = categoryName;
        this.userId = userId;
    }
}