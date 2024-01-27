import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../Shared/shared.service';
// import { OperationEntry } from './operation-entry.model';
import { Subscription } from 'rxjs';
import { OperationListService } from './operation-list.service';
import { AuthService } from '../auth/auth.service';


@Component({
  selector: 'app-operations-list',
  templateUrl: './operations-list.component.html',
  styleUrl: './operations-list.component.css'
})
export class OperationsListComponent implements OnInit {
  FilterOperationType : string= null;
  operationArr = this.opeartionListService.operationArray;
  subscriptionOperation: Subscription;
  operationsToDisplay = this.opeartionListService.operationsToDisplay;

  operationTypeArr= this.sharedService.operationType;
  customerArr= this.sharedService.operationCustomer;
  
  constructor(private router: Router,
              private sharedService: SharedService,
              private opeartionListService: OperationListService
              ){}

  ngOnInit(){
    this.opeartionListService
    .getOperations()
    .subscribe((operations) => {
      this.operationsToDisplay = operations;
    });
  }
  
  onLoadOperationEntry(){
    this.router.navigate(['/operation-entry']);
  }

}
