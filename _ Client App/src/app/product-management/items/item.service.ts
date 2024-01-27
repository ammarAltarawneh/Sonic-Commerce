import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ItemModel } from './item.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  itemArray: ItemModel[] = [];
  private apiUrl = 'https://localhost:44347';

  // itemChange = new Subject<ItemModel[]>();

  constructor(private http: HttpClient) {}

  getItems() : Observable<ItemModel[]> {
   return this.http.get<ItemModel[]>(`${this.apiUrl}/api/Item`);
  }

  createItem(item: ItemModel) {
    this.http.post<ItemModel>(`${this.apiUrl}/api/Item`, item).subscribe(
      () => {
        this.getItems();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateItem(item: ItemModel, id: number) {
    this.http.put<ItemModel>(`${this.apiUrl}/api/Item/${id}`, item).subscribe(
      () => {
        this.itemArray.findIndex((it) => it.itemId === id);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteItem(id: number) {
    this.http.delete<ItemModel>(`${this.apiUrl}/api/Item/${id}`).subscribe(
      () => {
        this.itemArray.findIndex((it) => it.itemId === id);
        this.getItems();
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
