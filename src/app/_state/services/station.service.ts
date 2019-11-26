import { HttpClient } from '@angular/common/http';
import { MenuItem } from './../models/menuItem.model';
import { Http } from '@angular/http';
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { Station } from "../models/station.model";
import { Menu } from '../models/menu.model';

@Injectable()
export class StationService {
    MOCK_STATION = <Station>{
        name: 'Coffee Station',
        hours: '11:00 am to 3:00pm',
        imagePath: 'https://c1.staticflickr.com/7/6182/6052083456_38ffd14f11_b.jpg',
        menus: [
            <Menu>{
                name: 'Coffee Station Menu',
                description: '',
                items: [
                    <MenuItem>{
                        name: 'Cafe Americano',
                        description: 'A shot of espresso with iced or hot water',
                        price: '2.50',
                        imageUrl: 'https://i.dietdoctor.com/wp-content/uploads/2017/02/DD-347-2.jpg?auto=compress%2Cformat&w=600&h=900&fit=crop%20600w',
                    },
                    <MenuItem>{
                        name: 'Cafe Latte',
                        description: 'A shot of espresso with iced or hot water',
                        price: '2.50',
                        imageUrl: 'https://c1.staticflickr.com/5/4208/34874657734_bc9225fd32_k.jpg',
                    }
                ]
            }
        ]
    }
    constructor(private http: HttpClient) { }

}