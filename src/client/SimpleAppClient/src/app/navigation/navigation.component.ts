import { Component } from '@angular/core';
import { AuthService } from '../auth/services/auth.service';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  get isLoggedIn():boolean{
    return this.authService.isLoggedIn;
  }
  isExpanded = false;

  constructor(private authService: AuthService){

  }
  
  
  logOut(){
    this.authService.logOut();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
