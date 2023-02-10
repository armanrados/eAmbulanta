import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {AuthService} from "../service/auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router : Router, private service : AuthService) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token')!=null) {
      let roles = next.data['permittedRoles'] as Array<string>;
      if (roles){
        if (this.service.roleMatch(roles)){
          return true;
        }else{
          this.router.navigate(['content-wrapper']);
          return false;
        }
      }
      return true;
    }else{
      this.router.navigate(['login']);
      return false;
    }
  }

}
