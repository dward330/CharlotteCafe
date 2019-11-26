import { Order } from './../../_state/models/order.model';
import { Observable } from 'rxjs';
import { OrderActions } from './../../_state/actions/order.actions';
import { Component, OnInit } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';

@Component({
  selector: 'app-cart-icon',
  templateUrl: './cart-icon.component.html',
  styleUrls: ['./cart-icon.component.css']
})
export class CartIconComponent implements OnInit {

  @select('currentOrder')
  currentOrder$: Observable<any>

  currentOrder: Order
  get totalItemsInCart() {
    if (this.currentOrder) {
      return this.currentOrder.items.length;
    }
    return false;
  }
  constructor(private ngRedux: NgRedux<IAppState>) {

  }
  ngOnInit(): void {

    this.currentOrder$.subscribe((order) => {
      this.currentOrder = order
    })
  }
}
