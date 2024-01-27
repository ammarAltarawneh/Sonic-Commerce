import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterString'
})
export class FilterStringPipe implements PipeTransform {

  transform(value: any, FilterName: string, operationTypeName: string): any {
    if (FilterName== '' || FilterName == null) {
      return value;
    }

    const resultArr = [];

    for (const item of value) {
      if (item[operationTypeName].toLowerCase().includes(FilterName.toLowerCase())) {
        resultArr.push(item);    
      } 
           
    }
    
    return resultArr;
  }
}
