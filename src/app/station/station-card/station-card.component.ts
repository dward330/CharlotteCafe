import { Station } from './../../_state/models/station.model';
import { Component, OnInit, Input } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { OrderActions } from '../../_state/actions/order.actions';
import { IAppState } from '../../_state/IAppState';

@Component({
  selector: 'app-station-card',
  templateUrl: './station-card.component.html',
  styleUrls: ['./station-card.component.css']
})
export class StationCardComponent {
  @Input()
  showPinnedListLink:boolean;

  @Input()
  pinnedItemCount:boolean;

  @Input()
  station:Station

  @Input()
  pinnedSectionOpen:false;

  get pinnedMessage(){
    return this.pinnedSectionOpen ? 'Hide Favorite': 'Show Favorite'
  }
  constructor(
    private ngRedux: NgRedux<IAppState>,
    private actions: OrderActions
  ) { }

  onIconClick() {
    this.ngRedux.dispatch(this.actions.togglePinnedList())
  }

}
