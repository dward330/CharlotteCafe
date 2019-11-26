import { Component, Input } from '@angular/core';
import { MenuItem } from '../../_state/models/menuItem.model';
import { NgRedux } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';
import { OrderActions } from '../../_state/actions/order.actions';

@Component({
  selector: 'app-main-list-item',
  templateUrl: './main-list-item.component.html',
  styleUrls: ['./main-list-item.component.css']
})
export class MainListItemComponent {
  @Input()
  listItem: MenuItem;

  constructor(private ngRedux:NgRedux<IAppState>, private orderActions:OrderActions){
  }
  setCurrentItem(){
    this.ngRedux.dispatch(this.orderActions.setCurrentItem(this.listItem))
  }
}
