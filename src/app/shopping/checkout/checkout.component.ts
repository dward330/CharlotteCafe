import { ModalComponent } from './../../_common/modal/modal.component';
// LOOK into a named route to get a modal in the route
// https://netbasal.com/give-your-modals-url-address-with-auxiliary-routes-in-angular-eb76497c0bca
import { Observable } from 'rxjs';
import { Component, OnInit, ContentChild, ContentChildren, ViewChild } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';
import { OrderActions } from '../../_state/actions/order.actions';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  @select('currentOrder')
  currentOrder$:Observable<any>;

  currentOrder;

  @ViewChild(ModalComponent)
  modalComponent:ModalComponent;


  @select('orderIsDone')
  orderIsDone$:Observable<any>;

  orderIsDone: boolean;

  constructor(private ngRedux: NgRedux<IAppState>,
    private orderActions: OrderActions) { }

  ngOnInit() {
    this.currentOrder$.subscribe((order)=>{
      this.currentOrder = order;
    })
    this.orderIsDone$.subscribe((orderIsDone)=>{
      this.orderIsDone = orderIsDone;
    })
  }
  submitAndClose($event){
    this.ngRedux.dispatch(this.orderActions.completeOrder(this.currentOrder));
    this.ngRedux.dispatch(this.orderActions.clearOrders());
    this.currentOrder = true;

    // If we close it here, then Thank You message won't get displayed.
    // I'm commenting it out for now. We can discuss how this logic has to be and then decide to keep it or remove it.

    // console.log('send the dispatched action',this.modalComponent);
    // this.modalComponent.closeModal($event);
  }
  modalClose($event){ }
}