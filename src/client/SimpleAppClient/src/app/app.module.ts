import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

import { NavigationComponent } from './navigation/navigation.component';
import { ProductModule } from './product/product.module';
import { AuthModule } from './auth/auth.module';
import { DashboardModule } from './dashboard/dashboard.module';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { AuthInterceptor } from './auth/infrastructure/auth.interceptor';
import { NotificationService } from './message/services/notification.service';
import { NotificationComponent } from './message/components/notification.component';
import { HttpErrorInterceptor } from './auth/infrastructure/error.interceptor';
import { SharedModule } from './_shared/shared.module';
import { HomeComponent } from './home/components/landing/home.component';
import { HomeModule } from './home/home.module';



@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,        
    NotificationComponent
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    AppRoutingModule,     
    SharedModule,
    HomeModule,
    AuthModule,
    DashboardModule, 
    ProductModule,    
    
    RouterModule.forRoot([      
      {path: 'home', component: HomeComponent},      
      {path: '', redirectTo: 'home', pathMatch: 'full'},
      {path: '**', redirectTo: 'home'}
    ]),         
  ],
  providers: [
    NotificationService,
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
