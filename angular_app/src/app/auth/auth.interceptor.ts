import {HttpInterceptor, HttpRequest, HttpHandler, HttpEvent} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {tap} from "rxjs";
import {Router} from "@angular/router";

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
  constructor(private router: Router) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (localStorage.getItem('token') != null){
      const clonedReq = req.clone({headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
      });
      return next.handle(clonedReq).pipe(tap(
        succ=>{},
        err=>{
          if (err.status == 401){
            this.router.navigate(['content-wrapper']);
          }else if (err.status == 403){
            this.router.navigate(['content-wrapper']);
          }
        }
      ))
    }else{
      return next.handle(req.clone());
    }
  }
}
