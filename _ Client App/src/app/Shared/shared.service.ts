import { Injectable} from '@angular/core';
import { ItemModel } from '../product-management/items/item.model';
import { OperationDetailsModel } from '../operation-entry/operation-details.model';
import { OperationModel } from '../operations-list/operation.model';
import { CustomerModel } from './customer.model';
import { OperationTypeModel } from './operationtype.model';
import { UsersModel } from '../auth/users.model';
import { CategoryModel } from '../product-management/categories/category.model';
// import { OperationEntry } from './operations-list/operation-entry.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService{
  id = 3;

  operationCustomer: CustomerModel[]=[
    new CustomerModel(1,'C1'),
    new CustomerModel(2,'C2'),
    new CustomerModel(3,'C3'),
    new CustomerModel(4,'C4'),
  ];
  operationType: OperationTypeModel[]=[
    new OperationTypeModel(1, 'Buy'),
    new OperationTypeModel(2, 'Return')
  ];


  onGenerateId(){
    this.id +=1;
    return this.id;
  }
}
