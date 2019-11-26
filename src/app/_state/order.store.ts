import { SessionActions } from './actions/session.actions';
import { OrderActions } from './actions/order.actions';
import { IAppState } from './IAppState';
import { Order } from './models/order.model';
import { OrderItem } from './models/orderItem.model';
export const INITIAL_STATE: IAppState = {
    showPinnedList: false,
    orderIsDone: false,
    editingOrder: false,
};

function getNewState(lastState, changeMap) {
    return Object.assign({}, lastState, changeMap)
}

function addPresetToOrder(lastState, orderItem) {
    var stateInstance = <IAppState>Object.assign({}, lastState)
    stateInstance.currentOrder = stateInstance.currentOrder ? stateInstance.currentOrder : <Order>{ items: [] }
    stateInstance.currentOrder.items.push(orderItem)
    stateInstance.orderIsDone = false;
    return stateInstance;
}
function addMenuItemToOrder(lastState, orderObject) {
    var stateInstance = <IAppState>Object.assign({}, lastState)
    var orderItem = <OrderItem>{
        menuItem: orderObject.menuItem,
        quantity: orderObject.quantity,
        additionalInstructions: orderObject.additionalInstructions,
        size: orderObject.size
    }
    stateInstance.currentOrder = stateInstance.currentOrder ? stateInstance.currentOrder : <Order>{ items: [] }
    stateInstance.currentOrder.items.push(orderItem)
    stateInstance.orderIsDone = false;
    return stateInstance;
}

function updateItem(lastState, menuItem) {
    var stateInstance = <IAppState>Object.assign({}, lastState)
    var orderItem = <OrderItem>{
        menuItem: menuItem
    }

    var index = stateInstance.currentOrder.items.indexOf(menuItem);
    stateInstance.currentOrder.items.splice(index,1);

    stateInstance.currentOrder = stateInstance.currentOrder ? stateInstance.currentOrder : <Order>{ items: [] }
    stateInstance.currentOrder.items.push(orderItem)
    stateInstance.orderIsDone = false;
    stateInstance.editingOrder = true;
    return stateInstance;
}

function clearOrders(lastState)
{
    var stateInstance = <IAppState>Object.assign({}, lastState)
    stateInstance.currentOrder = <Order>{ items: [] }
    stateInstance.orderIsDone = true;
    return stateInstance;
}

function editOrder(lastState)
{
    var stateInstance = <IAppState>Object.assign({}, lastState)
    stateInstance.editingOrder = true;
    return stateInstance;
}

export function rootReducer(lastState: IAppState, action: any): IAppState {
    switch (action.type) {
        case OrderActions.SET_CURRENT_ITEM:
            return getNewState(lastState, {
                currentItem: action.payload
            })
        case OrderActions.ADD_PRESET_TO_ORDER:
            return addPresetToOrder(lastState, action.payload);

        case OrderActions.ADD_MENU_ITEM_TO_ORDER:
            return addMenuItemToOrder(lastState, action.payload);

        case OrderActions.UPDATE_CURRENT_ITEM:
            return updateItem(lastState, action.payload);

        case OrderActions.TOGGLE_PINNED_LIST:
            return getNewState(lastState, {
                showPinnedList: !lastState.showPinnedList
            });
        case OrderActions.GET_CURRENT_STATION_SUCCESS:

            return getNewState(lastState, {
                currentStation: action.payload
            });
        case OrderActions.CLEAR_ORDERS:
            return clearOrders(lastState);

        case OrderActions.EDIT_ORDER:
            return editOrder(lastState);
        case SessionActions.LOG_IN_USER:
        case SessionActions.GET_CURRENT_USER:
            return getNewState(lastState, {
                currentUser: action.payload
            });
    }
    return lastState;
}