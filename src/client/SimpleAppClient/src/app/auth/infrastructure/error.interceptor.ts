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
          errorMsg = `Error Code: ${err.status}\nMessage: ${err.message}`;
        }
        return throwError(errorMsg);
        })
    );
  }
}
