import { OrderActions } from './../actions/order.actions';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ActionsObservable } from 'redux-observable';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const BASE_URL = 'http://onlinecafeapi20180725041737.azurewebsites.net/api';

@Injectable()
export class OrderEpics {
    constructor(private http: Http) { }
    saveCurrentOrder = (action$: ActionsObservable<any>) => {
        return action$.ofType(OrderActions.PERSIST_CURRENT_ORDER)
            .mergeMap(({ payload }) => {
                console.log('Here is the payload', payload);
                let price = payload.items.reduce((a, b) => {
                    console.log(a)
                    return 10;
                }, 0)
                let newPayload = {
                    Status: "New",
                    UserID: "1",
                    Price: price,
                    LineItems: [],
                    Instructions:""
                };
                payload.items.forEach((item) => {
                    console.log('Item info', item)
                    let itemObject = {
                        "MenuItemId": item.menuItem.id,
                        "Price": item.menuItem.price,
                        "Quantity": item.menuItem.quantity,
                        "Favorite": "false",
                        "ItemSize": "Tall"
                    }
                    newPayload.LineItems.push(itemObject);
                })
                console.log('Here is what im sending', newPayload);
                return this.http.post(`${BASE_URL}/order/save`, newPayload)
                    .map((result) => {
                        console.log('From server',result)
                        return {
                            type: OrderActions.PERSIST_CURRENT_ORDER_SUCCESS
                        }
                    )
            })
    }
    getStation = (action$: ActionsObservable<any>) => {
        return action$.ofType(OrderActions.GET_CURRENT_STATION)
            .mergeMap(({ payload }) => {
                return this.http.get(`${BASE_URL}/menu/menuitems/all`, payload)
                    .map(result => ({
                        type: OrderActions.GET_CURRENT_STATION_SUCCESS,
                        payload: result.json()
                    }))
                    .catch(error => Observable.of({
                        type: OrderActions.GET_CURRENT_STATION_ERROR
                    }));
            });
    }
}