import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterItem'
})
export class FilterItemPipe implements PipeTransform {

  transform(value: any, FilterItemName: string, itemNamee: string): any {
    if (FilterItemName== '' || FilterItemName == null) {
      return value;
    }

    const resultArr = [];
    
    for (const item of value) {
      if (item[itemNamee].toLowerCase().includes(FilterItemName.toLowerCase())) {
        resultArr.push(item);    
      } 
           
    }
    
    return resultArr;
  }
}
