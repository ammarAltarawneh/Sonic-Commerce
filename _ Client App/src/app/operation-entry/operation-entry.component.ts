import { Component, ElementRef, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../Shared/shared.service';
import { OperationModel } from '../operations-list/operation.model';
import { ItemService } from '../product-management/items/item.service';
import { OperationListService } from '../operations-list/operation-list.service';
import { Subscription } from 'rxjs';
import { OperationDetailsModel } from './operation-details.model';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-operation-entry',
  templateUrl: './operation-entry.component.html',
  styleUrl: './operation-entry.component.css'
})
export class OperationEntryComponent implements OnInit {

  itemArr = this.itemService.itemArray;
  itemWithQuantity = this.operationListService.itemWithQuantityArray;
  operationDetailArr = this.operationListService.operationDetailArray;
  operationArr = this.operationListService.operationArray;
  operationCustomer = this.sharedService.operationCustomer;
  operationTypee = this.sharedService.operationType;
  subscriptionOperation: Subscription;
  
  constructor(private router: Router, 
              private sharedService: SharedService,
              private itemService: ItemService,
              private authService:AuthService,
              private operationListService: OperationListService) {}

  ngOnInit(){
    // this.operationListService.getItemsWithQuantity();
    // this.subscriptionOperation = this.operationListService.itemWithQuantityChange.subscribe((data) => {
    //   this.itemWithQuantity = data;
    // }); 
    this.subscriptionOperation = this.operationListService
    .getItemsWithQuantity()
    .subscribe((data) => {
      this.itemWithQuantity = data;
    });  
  }

  calculateTotal(): number {
    for (const i of this.itemWithQuantity) {
        return ((i.item.price - i.item.price * i.item.discount) +
        (i.item.price - i.item.price * i.item.discount) * i.item.tax) * (i.quantity || 0);      
      
    }
  }

  calculateGrossTotal(): number {
    let total = 0;
    for (const i of this.itemWithQuantity) {
      total += i.item.price * (i.quantity || 0);
    }
  
    return total;
  }

  calculateDiscountTotal(): number {
    let totalDisc = 0;
    for (const i of this.itemWithQuantity) {
      totalDisc += i.item.discount * i.item.price * (i.quantity || 0);
    }
    return totalDisc;
  }

  calculateTaxTotal(): number {
    let total = 0;
    for (const i of this.itemWithQuantity) {
      total += (i.item.price - i.item.discount * i.item.price) * i.item.tax * (i.quantity || 0);
    }
    return total;
  }

  calculateTotalAmount(): number {
    return this.calculateGrossTotal() - this.calculateDiscountTotal() + this.calculateTaxTotal();
  }

  calculateTotalItemCount(): number {
    let totalCount: number = 0;

    for (const i of this.itemWithQuantity) {
      if (i.quantity != null && i.quantity > 0) {
        totalCount += 1;
      }
    }
    return totalCount;
  }

  calculateTotalQuantity(): number {
    let totalQuantity: number = 0;

    for (const i of this.itemWithQuantity) {
      if (i.quantity != null && i.quantity > 0) {
        totalQuantity += +i.quantity;
      }
    }
    return totalQuantity;
  }

  getOperationDetails(): OperationDetailsModel[]{  
      
    for (const i of this.itemWithQuantity) {
      if (i.quantity != null && i.quantity > 0) {
        this.operationDetailArr.push(
          {
            operationId:0,///// here
            itemId: i.item.itemId,
            quantity: i.quantity
          })
      }
    }
    return this.operationDetailArr;

  }

  onSave(selectedCustomerId: number, selectedOperationTypeId: number) {
    const newOperationWithDetails = {
      operationId: 0,
      userId: this.authService.userSubject.value.userId,
      operationTypeId: +selectedOperationTypeId,
      customerId: +selectedCustomerId,  
      operationDate:new Date(),
      taxTotal:this.calculateTaxTotal(),
      discountTotal:this.calculateDiscountTotal(),
      grossTotal:this.calculateGrossTotal(),
      netTotal:this.calculateTotalAmount(),
      operationDetail:this.getOperationDetails()
    };

    this.operationListService.createOperation(newOperationWithDetails);
    
    this.router.navigate(['/operations-list']);
  }

  onReturnToOperationList(){
    this.router.navigate(['/operations-list']);
  }

  onClear() {
    for (let i of this.itemWithQuantity) {
      i.quantity = null;
    }
  }
}
