import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';
@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService){

  }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    
    return next.handle(req)
    .pipe(        
        catchError((err: HttpErrorResponse) => {
            let errorMsg = '';

        //https://developer.mozilla.org/en-US/docs/Web/API/ErrorEvent
        // The ErrorEvent interface represents events providing information related to errors in scripts or in files.
        if (err.error instanceof ErrorEvent) {
          errorMsg = `Error: ${err.error.message}`;
        }
        // server side error
        else {
          if(err.status === 417){
            errorMsg += 'Errors: ';
            err.error.Errors.forEach(msg => {
              errorMsg += msg + '\n';
            })
          }
          else if(err.status === 401){
            const token = this.authService.getToken();
            if(token){
              errorMsg = "Session expired please login again!"
            }else{
              errorMsg = "Username or Password does not match!";
            }            
            this.authService.logOut();
          }
          else{
            errorMsg = `Error: ${err.error.message}`;
          }          
        }
        return throwError(errorMsg);
        })
    );
  }
}
