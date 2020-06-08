import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export class HttpErrorInterceptor implements HttpInterceptor {
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
            errorMsg = "Username or Password does not match!";
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
