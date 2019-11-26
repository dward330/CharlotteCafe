import { ResponsiveService } from './../../_common/services/Responsive.service';
import { OrderActions } from './../../_state/actions/order.actions';
/**
 * TODO: once we have valid services returning model class instances we can further type
 * protect the currentUser variables as instances of User class
 */
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';
import { IAppState } from '../../_state/IAppState';
import { SessionActions } from '../../_state/actions/session.actions';

@Component({
  selector: 'app-online-ordering-page',
  templateUrl: './online-ordering-page.component.html',
  styleUrls: ['./online-ordering-page.component.css']
})
export class OnlineOrderingPageComponent implements OnInit {
  pinnedList: string = 'pinnedList';
  showPinnedList = false;
  currentUser: any;
  currentStation: any;
  currentItem: any;

  @select('currentUser')
  currentUser$: Observable<any>

  @select('currentStation')
  currentStation$: Observable<any>

  @select('currentItem')
  currentItem$: Observable<any>

  get pinnedListItems() {
    return this.currentUser.value.pinnedItems
  }

  get pinnedItemCount() {
    return this.currentUser.value.pinnedItems.length;
  }

  get hasPinnedItems() {
    return this.currentUser.value.pinnedItems.length > 0;
  }
  get listItemsToShow() {
    if (this.currentStation) {
      return this.currentStation.items;
    }
  }
  get add() {
    return "add";
  }
  isSmallScreen = false;
  updateResponsiveVariable(){
    this.isSmallScreen = this.responsiveService.isSmallScreen();
  }
  constructor(
    private ngRedux: NgRedux<IAppState>,
    private sessionActions: SessionActions,
    private orderActions: OrderActions,
    private responsiveService: ResponsiveService
  ) {
    this.responsiveService.registerChangeCallback(this.updateResponsiveVariable.bind(this))
   }

  ngOnInit() {
    this.ngRedux.select<boolean>('showPinnedList')
      .subscribe(pinnedListStatus => this.showPinnedList = pinnedListStatus);

    this.ngRedux.dispatch(this.sessionActions.getCurrentUser());
    this.ngRedux.dispatch(this.orderActions.getCurrentStation());

    this.currentUser$.subscribe((user) => { this.currentUser = user; })
    this.currentStation$.subscribe((station) => { console.log('This is the station',station); this.currentStation = station; })
    this.currentItem$.subscribe((item) => { this.currentItem = item; })
  }
}
