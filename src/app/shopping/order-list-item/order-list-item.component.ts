import { OrderItem } from './../../_state/models/orderItem.model';
import { Component, OnInit, Input } from '@angular/core';
import { Order } from '../../_state/models/order.model';
import { Observable } from 'rxjs';
import { NgRedux, select } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';
import { OrderActions } from '../../_state/actions/order.actions';

@Component({
  selector: 'app-order-list-item',
  templateUrl: './order-list-item.component.html',
  styleUrls: ['./order-list-item.component.css']
})
export class OrderListItemComponent implements OnInit {
  @Input()
  item:OrderItem;

  @Input()
  order:Order;
  get edit(){
    return "edit";
  }

  @select('editingOrder')
  editingOrder$:Observable<any>;

  editingOrder: boolean;

  public showEdit: boolean;
  public editOptions: boolean;
  constructor(private ngRedux: NgRedux<IAppState>,
    private orderActions: OrderActions) { }

  ngOnInit() {
    this.showEdit = false;
    this.editOptions = false;

    
    this.editingOrder$.subscribe((editingOrder)=>{
      this.editingOrder = editingOrder;
    })
  }

  ToggleEdit()
  {
    this.showEdit = true;
  }

  EditItem()
  {
    this.showEdit = false;
    this.editOptions = true;
    
    this.ngRedux.dispatch(this.orderActions.editOrder());
  }

  RemoveItem()
  {
    var index=this.order.items.indexOf(this.item);
    this.order.items.splice(index,1);
  }

}
