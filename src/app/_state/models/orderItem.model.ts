import { MenuItem } from "./menuItem.model";

export interface OrderItem{
    menuItem:MenuItem;
    options:any[];
    cost:string;
    quantity:number;
    size:string;
    additionalInstructions:string;

}