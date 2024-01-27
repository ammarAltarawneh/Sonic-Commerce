import { RouterModule, Routes } from "@angular/router";
import { ProductManagementComponent } from "./product-management.component";
import { ItemsComponent } from "./items/items.component";
import { CategoriesComponent } from "./categories/categories.component";
import { NgModule } from "@angular/core";

const routes:Routes=[
    {path: '', component:ProductManagementComponent},
    {path:'items', component:ItemsComponent},
    {path:'categories', component:CategoriesComponent}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ProductManagementRoutingModule {
}