import { MenuItem } from './../../_state/models/menuItem.model';
import { Component, Input } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';
import { OrderActions } from '../../_state/actions/order.actions';
import { OrderItem } from '../../_state/models/orderItem.model';

@Component({
  selector: 'app-pinned-list-item',
  templateUrl: './pinned-list-item.component.html',
  styleUrls: ['./pinned-list-item.component.css']
})
export class PinnedListItemComponent {
  @Input()
  listItem: OrderItem;

  constructor(
  private ngRedux: NgRedux<IAppState>,
    private orderActions: OrderActions
  ){}
  addToOrder(){
    this.ngRedux.dispatch(this.orderActions.addPresetToOrder(this.listItem))
  }
}
