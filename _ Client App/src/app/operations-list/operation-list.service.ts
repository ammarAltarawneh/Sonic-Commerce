import { Injectable } from '@angular/core';
import { OperationModel } from './operation.model';
import { SharedService } from '../Shared/shared.service';
import { ItemService } from '../product-management/items/item.service';
import { OperationDetailsModel } from '../operation-entry/operation-details.model';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ItemWithQuantityModel } from '../operation-entry/item-with-quantity.model';
import { ItemModel } from '../product-management/items/item.model';
import { OperationWithDetailsModel } from '../operation-entry/operation-with-detail.model';
import { OperationsDisplayModel } from './operations-display.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OperationListService {

  itemArray = this.itemService.itemArray; 
  operationType = this.sharedService.operationType;
  operationCustomer = this.sharedService.operationCustomer;

  operationArray: OperationModel[] = [];
  operationDetailArray : OperationDetailsModel[] =[];
  operationsToDisplay: OperationsDisplayModel[] = [];  

  itemWithQuantityArray: ItemWithQuantityModel[] = [];    

  private apiUrl = "https://localhost:44347";
  // itemWithQuantityChange = new Subject<ItemWithQuantityModel[]>();
  // operationChange = new Subject<OperationModel[]>();
  // operationsToDisplayChange = new Subject<OperationsDisplayModel[]>();

  constructor(private http: HttpClient,
              private sharedService:SharedService,
              private itemService: ItemService) {}
  
  getOperations(): Observable<OperationsDisplayModel[]> {
  return this.http.get<OperationsDisplayModel[]>(`${this.apiUrl}/api/Operation`);
  }

  getItemsWithQuantity(): Observable<ItemWithQuantityModel[]> {
    return this.http.get<ItemModel[]>(`${this.apiUrl}/api/Item`).pipe(
      map((items: ItemModel[]) => {
        return items.map(item => new ItemWithQuantityModel(item, null));
      })
    );
  }

  createOperation(operation: OperationWithDetailsModel) {
    this.http.post<OperationWithDetailsModel>(`${this.apiUrl}/api/Operation`, operation)
      .subscribe(() => {
        this.getOperations();
        this.operationDetailArray = [];//reset
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
