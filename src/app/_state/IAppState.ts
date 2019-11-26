import { OrderItem } from './models/orderItem.model';
import { MenuItem } from './models/menuItem.model';
import { Order } from "./models/order.model";
import { Menu } from './models/menu.model';
import { User } from './models/user.model';
import { Station } from './models/station.model';

export interface IAppState {
    showPinnedList: boolean;
    orderIsDone: boolean;
    editingOrder: boolean;
    currentListItem?: MenuItem;
    currentMenu?: Menu;
    currentStation?: Station;
    pinnedItems?: OrderItem[];
    currentOrder?: Order;
    user?: User;
}