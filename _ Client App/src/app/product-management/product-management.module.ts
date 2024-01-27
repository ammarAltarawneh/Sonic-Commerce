import { NgModule } from "@angular/core";
import { ProductManagementComponent } from "./product-management.component";
import { CategoriesComponent } from "./categories/categories.component";
import { ItemsComponent } from "./items/items.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ProductManagementRoutingModule } from "./product-management-routing.module";
import { CommonModule } from "@angular/common";
import { ItemDialogComponent } from './items/item-dialog/item-dialog.component';
import { CategoryDialogComponent } from './categories/category-dialog/category-dialog.component';
import { FilterItemPipe } from "../filter-item.pipe";
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
    declarations:[
        ProductManagementComponent,
        CategoriesComponent,
        ItemsComponent,
        ItemDialogComponent,
        CategoryDialogComponent,
        FilterItemPipe
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        ProductManagementRoutingModule, 
        MatButtonModule,
        MatDialogModule
    ],
    exports:[
        ProductManagementComponent,
        CategoriesComponent,
        ItemsComponent
    ]
})
export class ProductManagementModule {}