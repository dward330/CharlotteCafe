import { Order } from './../../_state/models/order.model';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent {
  @Input()
  orderList:Order

  constructor() { }


}
