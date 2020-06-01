import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/components/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ProductModule } from './product/product.module';
import { AuthModule } from './auth/auth.module';
import { DashboardModule } from './dashboard/dashboard.module';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { AuthService } from './auth/services/auth.service';
import { AuthInterceptor } from './auth/infrastructure/auth.interceptor';
import { NotificationService } from './message/services/notification.service';
import { NotificationComponent } from './message/components/notification.component';



@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,    
    HomeComponent,
    NotificationComponent
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule, 
    AppRoutingModule,     
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
    AuthService,
    NotificationService,
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
