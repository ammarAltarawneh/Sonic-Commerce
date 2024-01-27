import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrl: './product-management.component.css'
})
export class ProductManagementComponent {
  
  constructor(private route: ActivatedRoute,
              private router: Router){}
 
  onOpenItems(){
    this.router.navigate(['items'], {relativeTo: this.route});
  }

  onOpenCategories(){
    this.router.navigate(['categories'], {relativeTo: this.route});
  }
}
