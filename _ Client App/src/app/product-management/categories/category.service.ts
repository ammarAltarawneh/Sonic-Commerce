import { Injectable, OnInit } from '@angular/core';
import { CategoryModel } from './category.model';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs-compat';

@Injectable({
  providedIn: 'root'
})
export class CategoryService{

  categoryArray: CategoryModel[] = [];
  private apiUrl = "https://localhost:44347";

  constructor(private http: HttpClient ) {}
  
  getCategories(): Observable<CategoryModel[]> {
   return this.http.get<CategoryModel[]>(`${this.apiUrl}/api/Category`);
  }
  
  createCategory(category:CategoryModel){
    this.http.post<CategoryModel>(this.apiUrl+"/api/Category", category)
    .subscribe(() => {
       this.getCategories();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateCategory(category: CategoryModel, id: number) {
    this.http.put<CategoryModel>(`${this.apiUrl}/api/Category/${id}`, category).subscribe(
      (response: CategoryModel) => {
        const updatedIndex = this.categoryArray.findIndex(item => item.categoryId === id);
        this.categoryArray[updatedIndex] = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteCategory(id: number) {
        this.http.delete<CategoryModel>(`${this.apiUrl}/api/Category/${id}`).subscribe(
          () => {
            this.categoryArray.findIndex(item => item.categoryId === id);
          },
          (error) => {
            console.error(error);
          }
        );    
    }
}