import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserService } from '../_state/services/user.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private user: UserService,private router: Router) {}

  canActivate() {

    // if(!this.user.isLoggedIn())
    // {
    //    this.router.navigate(['/login']);
    //    return false;
    // }

    return true;
  }
}