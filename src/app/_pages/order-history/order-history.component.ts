import { Component, OnInit } from '@angular/core';
import { select, NgRedux } from '@angular-redux/store';
import { Observable } from 'rxjs';
import { SessionActions } from '../../_state/actions/session.actions';
import { IAppState } from '../../_state/IAppState';
import { OrderActions } from '../../_state/actions/order.actions';
import { Adal6Service } from 'adal-angular6';
const config = {
  tenant: '72f988bf-86f1-41af-91ab-2d7cd011db47',
  clientId: '52a616db-31ec-4d02-8742-9b6f090dd619',
  redirectUri: window.location.origin + '/order',
};
@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.scss']
})
export class OrderHistoryComponent implements OnInit {

  @select('currentUser')
  currentUser$: Observable<any>
  currentUser;
  isAuthenticated: boolean;
  userInfo: any;
  get pinnedItemCount(){
    return this.currentUser.value.pinnedItems.length;
  }
  constructor(
    private ngRedux: NgRedux<IAppState>,
    private sessionActions: SessionActions,
    private orderActions: OrderActions,
    private authservice: Adal6Service
  ) {
    this.authservice.init(config);
    this.isAuthenticated = this.authservice.userInfo.authenticated;
  }

  ngOnInit() {
    this.ngRedux.dispatch(this.sessionActions.getCurrentUser());
    this.currentUser$.subscribe((user) => { this.currentUser = user; })
    this.authservice.handleWindowCallback();
    this.userInfo = this.authservice.userInfo;
  }

}
