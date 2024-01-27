export class UsersModel{
    public userId: number;
    public role?: string;
    public userName: string;
    public passwordd: string;
    public token?: string;

    constructor(userId:number,role:string,userName: string, passwordd: string, token: string){
        this.userId=userId;
        this.role=role;
        this.userName=userName;
        this.passwordd=passwordd;
        this.token=token;
    }
}