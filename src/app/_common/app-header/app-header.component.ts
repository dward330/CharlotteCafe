import { Component, OnInit } from '@angular/core';
import { Adal6Service } from 'adal-angular6';

const config = {
  tenant: '72f988bf-86f1-41af-91ab-2d7cd011db47',
  clientId: '52a616db-31ec-4d02-8742-9b6f090dd619',
  redirectUri: window.location.origin + '/order',
};
@Component({
  selector: 'app-app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.css']
})
export class AppHeaderComponent implements OnInit {

  isAuthenticated = false;
  userInfo: any;

  constructor(private authservice: Adal6Service) {
    this.authservice.init(config);
    this.isAuthenticated = this.authservice.userInfo.authenticated;
  }

  ngOnInit() {
    this.authservice.handleWindowCallback();
    this.userInfo = this.authservice.userInfo;
  }
  logout(){
    this.authservice.logOut();
    this.isAuthenticated = false;
  }
}
