import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  displayNav:boolean=true;
  username: string = this.authService.userSubject.value.userName;

  constructor(private authService:AuthService){}


  onAdminMode():boolean{
    if(this.authService.userSubject.value.role!=="admin"){
      this.displayNav = false;
    }
    return this.displayNav;
  }

  onLogout(){
    this.authService.logout();  
  }
}
