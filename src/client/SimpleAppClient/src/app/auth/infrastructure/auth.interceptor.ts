import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';

// todo: implement logout on unauthorized response
@Injectable()
export class AuthInterceptor implements HttpInterceptor{

    constructor(private authService: AuthService){

    }
    intercept(
        req: HttpRequest<any>, 
        next: HttpHandler): Observable<HttpEvent<any>> {            
            const token = this.authService.getToken();            
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