import { Injectable } from '@angular/core';
import { UsersModel } from './users.model';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  usersArray: UsersModel[] = [];
  errorMessage = new Subject<string>();
  isAuthSubject = new BehaviorSubject<boolean>(false);
  userSubject = new BehaviorSubject<UsersModel | null>(null);
  private apiUrl = 'https://localhost:44347';

  constructor(private router: Router, private http: HttpClient) {}

  login(user: UsersModel): void {
    this.http.post<UsersModel>(this.apiUrl + '/api/User/login', user).subscribe(
      (response) => {
        if (response.token) {
          localStorage.setItem('token', response.token);
          this.isAuthSubject.next(true);
          this.userSubject.next(response); 
          this.router.navigate(['/operations-list']);
        } else {
          this.errorMessage.next('The email and password are not correct');
        }
      },
      (error) => {
        console.error('Error fetching users: ', error);
        this.errorMessage.next(error);
      }
    );
  }

  getAllUsers(): Observable<UsersModel[]> {
   return this.http.get<UsersModel[]>(`${this.apiUrl}/api/User`);
  }

  logout() {
    this.isAuthSubject.next(false);
    this.userSubject.next(null);
    localStorage.removeItem('token');
    this.router.navigate(['/auth']);
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
}
