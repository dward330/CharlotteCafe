import { OrderItem } from "./orderItem.model";

export interface Order{
    items:OrderItem[];
    total:string;
    createdAt:Date;
}