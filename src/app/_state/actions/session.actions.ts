import { Injectable } from '@angular/core';
import { Action } from 'redux';
import { UserService } from '../services/user.service';

@Injectable()
export class SessionActions {
  static LOG_IN_USER = 'LOG_IN_USER';
  static GET_CURRENT_USER = 'GET_CURRENT_USER';
  constructor(
    private userService: UserService
  ) {

  }
  logInUser(email: string, password: string) {
    return {
      type: SessionActions.LOG_IN_USER,
      payload: this.userService.loginUser(email, password)
    };
  }
  getCurrentUser(){
    return {
      type:SessionActions.GET_CURRENT_USER,
      payload:this.userService.getLoggedInUser()
    }
  }
}