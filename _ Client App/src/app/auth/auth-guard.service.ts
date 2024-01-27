import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    
    if (this.authService.isAuthenticated()) {
      const user = this.authService.userSubject.value;

    if (user) {
      if (next.data.roles) {
        if (next.data.roles.includes(user.role)) {
          return true;
        
        } else {
          this.router.navigate(['/operations-list']);
          return false;
        }
      }
      return true;
    }
  }

  this.router.navigate(['/auth']);
  return false;
  }
}