import { OrderItem } from './../../_state/models/orderItem.model';
import { IAppState } from './../../_state/IAppState';
import { Component, OnInit, Input } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { OrderActions } from '../../_state/actions/order.actions';
import { MenuItem } from '../../_state/models/menuItem.model';

@Component({
  selector: 'app-order-list-item-options',
  templateUrl: './order-list-item-options.component.html',
  styleUrls: ['./order-list-item-options.component.css']
})
export class OrderListItemOptionsComponent implements OnInit {
  ngOnInit(): void {
    this.orderItem = {
      menuItem: this.item,
      quantity: 1,
      additionalInstructions: '',
      size: 'md'
    };
  }

  @Input()
  item: MenuItem;

  @Input()
  itemChange: string;

  additionalRequests: string = "Please add 3 ice cubes";
  itemCount: number = 2;
  orderItem;

  constructor(
    private ngRedux: NgRedux<IAppState>,
    private orderActions: OrderActions) {
  }


  onIncrementClick() {
    this.orderItem.quantity++;
  }
  onChangeSize(sizeString) {
    this.orderItem.size = sizeString;
  }
  onDecrementClick() {
    this.orderItem.quantity > 0 ? this.orderItem.quantity-- : 0;
  }

  onCancelOptions() {
    this.ngRedux.dispatch(this.orderActions.setCurrentItem(null))
  }
  onAddToCart() {
    if (this.itemChange == "edit") {
      this.ngRedux.dispatch(this.orderActions.updateItem(this.item));
      return;
    }
    console.log(this.orderItem)
    this.ngRedux.dispatch(this.orderActions.addMenuItemToOrder(this.orderItem));
    this.ngRedux.dispatch(this.orderActions.setCurrentItem(null))
  }
}
