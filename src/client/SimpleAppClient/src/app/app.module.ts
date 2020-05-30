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
import {HttpClientModule} from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,    
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    HttpClientModule,
    RouterModule.forRoot([      
      {path: 'home', component: HomeComponent},
      {path: '', redirectTo: 'home', pathMatch: 'full'},
      {path: '**', redirectTo: 'home'}
    ]),
    AuthModule,
    DashboardModule, 
    ProductModule        
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
