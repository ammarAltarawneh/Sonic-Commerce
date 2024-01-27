import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ItemService } from '../item.service';
import { CategoryService } from '../../categories/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-item-dialog',
  templateUrl: './item-dialog.component.html',
  styleUrls: ['./item-dialog.component.css']
})
export class ItemDialogComponent implements OnInit {  
  @Output() itemsChanged = new EventEmitter<boolean>();

  newMode: boolean = false;
  subscriptionCategory:Subscription;

 
  categoryArr = this.categoryService.categoryArray;

  itemId: number;
  newItemName: string;
  newItemCategoryId: number;
  newItemPrice: number;
  newItemDiscount: number;
  newItemTax: number;

  ngOnInit() {
    this.subscriptionCategory = this.categoryService
    .getCategories()
    .subscribe((categories) => {
      this.categoryArr = categories;
    });
  }

  constructor(
    private itemService: ItemService,
    private categoryService: CategoryService,
    public dialogRef: MatDialogRef<ItemDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { mode: 'add' | 'edit' | 'delete', id?: number }
  ) {
    if (data.id) {
      this.itemId = data.id;
    }
  }

  onSubmitItem() {
    const item = {
      itemId: this.itemId,
      categoryId: +this.newItemCategoryId,
      itemName: this.newItemName,      
      price: this.newItemPrice,
      discount: this.newItemDiscount/100,
      tax: this.newItemTax/100
    };
    
    if (this.data.mode === 'add') {
      this.itemService.createItem(item);
    } else if (this.data.mode === 'edit') {
      this.itemService.updateItem(item, this.itemId);
    } else if (this.data.mode === 'delete') {
      this.itemService.deleteItem(this.data.id);
    }

    this.newMode = true;
    this.itemsChanged.emit(true);
    this.onClose();
  }

  onClose() {
    this.dialogRef.close({ newMode: this.newMode });
  }
}
