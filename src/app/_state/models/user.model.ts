import { MenuItem } from './menuItem.model';
import { Order } from './order.model';
import { OrderItem } from './orderItem.model';

export interface User{
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
    firstName: string;
    lastName: string;
    phone:string;
    orders:OrderItem[];
    pinnedItems:OrderItem[];
}