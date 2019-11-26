import { SessionActions } from './../../../_state/actions/session.actions';
import { NgRedux } from '@angular-redux/store';
import { Component, OnInit } from '@angular/core';
import { IAppState } from '../../../_state/IAppState';
import { Adal6Service } from 'adal-angular6';
const config = {
  tenant: '72f988bf-86f1-41af-91ab-2d7cd011db47',
  clientId: '52a616db-31ec-4d02-8742-9b6f090dd619',
  redirectUri: window.location.origin + '/order',
};


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent{
  isAuthenticated = false;
  userInfo: any;

  constructor(private authservice: Adal6Service){
    this.authservice.init(config);
    this.isAuthenticated = this.authservice.userInfo.authenticated;
  }

  ngOnInit(){
    this.authservice.handleWindowCallback();
    this.userInfo = this.authservice.userInfo;
  }

  login(){
    this.authservice.login();
  }
  logout(){
    this.authservice.logOut();
    this.isAuthenticated = false;
  }
}
