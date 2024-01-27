import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CategoryService } from '../category.service';
import { AuthService } from '../../../auth/auth.service';
import { UsersModel } from '../../../auth/users.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category-dialog',
  templateUrl: './category-dialog.component.html',
  styleUrls: ['./category-dialog.component.css']
})
export class CategoryDialogComponent implements OnInit {  
  @Output() categoriesChanged = new EventEmitter<boolean>();

  newMode: boolean = false;

  newCategoryName: string;
  categoryId: number;
  newUserId:number; 
  subscriptionUser: Subscription;
  
  userArr = this.authService.usersArray;
  
   ngOnInit(): void {
    this.subscriptionUser = this.authService
    .getAllUsers()
    .subscribe((users) => {
      this.userArr = users;
    });
   }

  constructor(
    private categoryService: CategoryService,
    private authService: AuthService,
    public dialogRef: MatDialogRef<CategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { mode: 'add' | 'edit' | 'delete', id?: number }
  ) {
    if (data.id) {
      this.categoryId = data.id;
    }
  }

  onSubmitCategory() {
    const category = {
      categoryId: this.categoryId,
      categoryName: this.newCategoryName,
      userId: this.newUserId
    };
    if (this.data.mode === 'add') {
      this.categoryService.createCategory(category);
    } else if (this.data.mode === 'edit') {
      this.categoryService.updateCategory(category, this.categoryId);
    } else if (this.data.mode === 'delete') {
      this.categoryService.deleteCategory(this.data.id);
    }

    this.newMode = true;
    this.categoriesChanged.emit(true);
    this.onClose();
  }

  onClose() {
    this.dialogRef.close({ newMode: this.newMode });
  }
}
