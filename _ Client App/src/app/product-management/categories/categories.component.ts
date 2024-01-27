import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { CategoryDialogComponent } from './category-dialog/category-dialog.component';
import { Router } from '@angular/router';
import { CategoryService } from './category.service';
import { Subscription } from 'rxjs';
import { AuthService } from '../../auth/auth.service';
import { ItemService } from '../items/item.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  addMode: boolean = false;
  updateMode: boolean = false;
  deleteMode: boolean = false;
  selectedCategoryId: number = null;

  canDelete: boolean = false;

  FilterCategoryName;
  categoryArr = this.categoryService.categoryArray;
  itemArr = this.itemService.itemArray;
  userArr= this.authService.usersArray;
  subscriptionCategory: Subscription;
  

  constructor(
    private categoryService: CategoryService,
    private authService:AuthService,
    private itemService: ItemService,
    public matDialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.updateCategoryList();

    this.authService
    .getAllUsers()
    .subscribe((users) => {
      this.userArr = users;
    });

    this.itemService
    .getItems()
    .subscribe((items) => {
      this.itemArr = items;
    });
  }

  updateCategoryList(){
    this.subscriptionCategory = this.categoryService
    .getCategories()
    .subscribe((categories) => {
      this.categoryArr = categories;
    });
  }

  onCategoriesChanged() {
    this.addMode = false;
    this.updateMode = false;
    this.deleteMode = false;
  }

  getUserById(userId: number): string {
    const user = this.userArr.find(u => u.userId === userId);
    return user ? user.userName : 'N/A'; // If user is not found, display 'N/A' or handle it as per your requirement
  }

  canDeleteCategory(id?: number): boolean{
    
      for(let item of this.itemArr){      
        if(item.categoryId===id){
          this.canDelete =true;  
          return this.canDelete;
        }
      }       
  }

  openDialog(mode: 'add' | 'edit' | 'delete', id?: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.height = '250px';
    dialogConfig.width = '450px';
    dialogConfig.data = { mode, id };

    const dialogRef = this.matDialog.open(CategoryDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((result) => {
      if (result && result.newMode) {
        this.onCategoriesChanged();
        this.updateCategoryList();
      }
    });
  }

  goBack() {
    this.router.navigate(['/product-management/items']);
  }

  ngOnDestroy() {
    this.subscriptionCategory.unsubscribe();
  }
}
