import { Order } from './../models/order.model';
import { Injectable } from '@angular/core';
import { Action } from 'redux';
import { StationService } from '../services/station.service';

@Injectable()
export class OrderActions {


  static TOGGLE_PINNED_LIST = 'TOGGLE_PINNED_LIST';
  static GET_CURRENT_STATION = 'GET_CURRENT_STATION';
  static GET_CURRENT_STATION_SUCCESS = 'GET_CURRENT_STATION_SUCCESS';
  static GET_CURRENT_STATION_ERROR = 'GET_CURRENT_STATION_ERROR';
  static ADD_PRESET_TO_ORDER = 'ADD_PRESET_TO_ORDER';
  static ADD_MENU_ITEM_TO_ORDER = 'ADD_MENU_ITEM_TO_ORDER';
  static SET_CURRENT_ITEM = 'SET_CURRENT_ITEM';
  static UPDATE_CURRENT_ITEM = 'UPDATE_CURRENT_ITEM';
  static CLEAR_ORDERS = 'CLEAR_ORDERS';
  static EDIT_ORDER = 'EDIT_ORDER';
  static PERSIST_CURRENT_ORDER = 'PERSIST_CURRENT_ORDER';
  static PERSIST_CURRENT_ORDER_SUCCESS = 'PERSIST_CURRENT_ORDER_SUCCESS';

  constructor(private stationService: StationService) { }

  togglePinnedList(): Action {
    return {
      type: OrderActions.TOGGLE_PINNED_LIST
    }
  }
  completeOrder(orderObject) {
    return {
      type: OrderActions.PERSIST_CURRENT_ORDER,
      payload: orderObject
    }
  }
  addMenuItemToOrder(orderObject) {
    return {
      type: OrderActions.ADD_MENU_ITEM_TO_ORDER,
      payload: orderObject
    }
  }
  addPresetToOrder(orderItem) {
    return {
      type: OrderActions.ADD_PRESET_TO_ORDER,
      payload: orderItem
    }
  }

  updateItem(orderItem) {
    return {
      type: OrderActions.UPDATE_CURRENT_ITEM,
      payload: orderItem
    }
  }

  setCurrentItem(orderItem) {
    return {
      type: OrderActions.SET_CURRENT_ITEM,
      payload: orderItem
    }
  }

  getCurrentStation() {
    return {
      type: OrderActions.GET_CURRENT_STATION,
      // payload: this.stationService.getCurrentStation()
    }
  }

  clearOrders() {
    return {
      type: OrderActions.CLEAR_ORDERS
    }
  }


  editOrder() {
    return {
      type: OrderActions.EDIT_ORDER
    }
  }
}