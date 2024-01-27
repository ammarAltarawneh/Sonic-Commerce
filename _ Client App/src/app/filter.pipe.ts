import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterNumber'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, filterOperationType: number, operationTypeId: number): any {
    if (filterOperationType== 0 || filterOperationType == null) {
      return value;
    }

    const resultArr = [];

    for (const item of value) {
      if (item[operationTypeId] == filterOperationType) {
        resultArr.push(item);    
      } 
           
    }
    
    return resultArr;
  }
}
