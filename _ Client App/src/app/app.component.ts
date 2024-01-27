import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  showNav:boolean=true;
  constructor(private router: Router) {}

  ngOnInit(){
    this.shouldShowHeader();
  }  

  shouldShowHeader(): boolean {
    if(this.router.url === '/' || this.router.url === '/auth'){
      this.showNav = false;
    } 
    else{
      this.showNav = true;
    }
    return this.showNav;
  }
}
