import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ItemDialogComponent } from './item-dialog/item-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from './item.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  addMode: boolean = false;
  updateMode: boolean = false;
  deleteMode: boolean = false;
  selectedItemId: number = null;

  FilterItemName: string;
  itemArr = this.itemService.itemArray;
  subscriptionItem: Subscription;

  constructor(
    private itemService: ItemService,
    public matDialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.updateItemList();
  }

  updateItemList(){
    this.itemService
    .getItems()
    .subscribe((items) => {
      this.itemArr = items;
    });
  }

  onItemsChanged() {
    this.addMode = false;
    this.updateMode = false;
    this.deleteMode = false;
  }

  openDialog(mode: 'add' | 'edit' | 'delete', id?: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.height = '250px';
    dialogConfig.width = '450px';
    dialogConfig.data = { mode, id };

    const dialogRef = this.matDialog.open(ItemDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((result) => {
      if (result && result.newMode) {
        this.onItemsChanged();
        // this.itemService.getItems(); // Optionally refresh the list from the server
        this.updateItemList();
      }
    });
  }

  goBack() {
    this.router.navigate(['/product-management/categories']);
  }

  ngOnDestroy() {
    this.subscriptionItem.unsubscribe();
  }
}
