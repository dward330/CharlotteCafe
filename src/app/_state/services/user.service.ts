import { Http } from '@angular/http';
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, of } from "rxjs";
import { User } from "../models/user.model";
import { MenuItem } from '../models/menuItem.model';
import { OrderItem } from '../models/orderItem.model';

@Injectable()
export class UserService {
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    MOCK_TOKEN = "alsdfhagjdfjhuyuiy123123$@#$";
    MOCK_USER = <User>{
        userName: 'fevargas',
        email: 'fevargas@microsoft.com',
        firstName: 'Fernando',
        lastName: 'Vargas',
        phone: '9802190610',
        orders:[
            <OrderItem>{
                options: [],
                cost: '2.50',
                menuItem: <MenuItem>{
                    name: 'Cafe Americano',
                    description: 'A shot of espresso with iced or hot water',
                    price: '2.50',
                    imageUrl: 'https://cdn.theatlantic.com/static/mt/assets/food/assets_c/2011/08/3148083795_076bb5d62e_b_wide-thumb-600x350-59621.jpg',
                },
            },
            <OrderItem>{
                options: [],
                cost: '2.50',
                menuItem: <MenuItem>{
                    name: 'Cafe Latte',
                    description: 'A shot of espresso with iced or hot water',
                    price: '2.50',
                    imageUrl: 'https://cdn.theatlantic.com/static/mt/assets/food/assets_c/2011/08/3148083795_076bb5d62e_b_wide-thumb-600x350-59621.jpg',
                }
            }
        ],
        pinnedItems: [
            <OrderItem>{
                additionalInstructions:'Two shots of espresso',
                size:'md',
                quantity:1,
                cost: '2.50',
                menuItem: <MenuItem>{
                    name: 'Cafe Americano',
                    description: 'A shot of espresso with iced or hot water',
                    price: '2.50',
                    imageUrl: 'https://cdn.theatlantic.com/static/mt/assets/food/assets_c/2011/08/3148083795_076bb5d62e_b_wide-thumb-600x350-59621.jpg',
                },
            },
            <OrderItem>{
                additionalInstructions:'Two creams and two sugars',
                size:'md',
                quantity:1,
                cost: '2.50',
                menuItem: <MenuItem>{
                    name: 'Cafe Latte',
                    description: 'A shot of espresso with iced or hot water',
                    price: '2.50',
                    imageUrl: 'https://cdn.theatlantic.com/static/mt/assets/food/assets_c/2011/08/3148083795_076bb5d62e_b_wide-thumb-600x350-59621.jpg',
                }
            }

        ]
    }
    authNavStatus$ = this._authNavStatusSource.asObservable();
    private loggedIn = false;

    constructor() {
        this.loggedIn = !!localStorage.getItem('auth_token');
        this._authNavStatusSource.next(this.loggedIn);
    }
    isLoggedIn(): boolean {
        return this.loggedIn;
    }
    loginUser(email: string, password: string): Observable<User> {
        localStorage.setItem('auth_token', this.MOCK_TOKEN);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return of(this.MOCK_USER);
    }
    getLoggedInUser() {
        return of(this.MOCK_USER);
    }
}