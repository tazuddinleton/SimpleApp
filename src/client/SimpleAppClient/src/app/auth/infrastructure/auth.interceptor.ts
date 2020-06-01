import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

// todo: implement logout on unauthorized response
export class AuthInterceptor implements HttpInterceptor{
    intercept(
        req: HttpRequest<any>, 
        next: HttpHandler): Observable<HttpEvent<any>> {            
            const token = localStorage.getItem('bearer_token');
            if(token){                
                const request = req.clone({
                    setHeaders: {
                        Authorization: 'Bearer '+token
                    }
                });
                return next.handle(request);
            }
            return next.handle(req);            
    }
}