import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-main-list',
  templateUrl: './main-list.component.html',
  styleUrls: ['./main-list.component.css']
})
export class MainListComponent {
  @Input()
  type:string;

  @Input()
  listItems: any[]

  get isPinnedList(){
    return this.type == 'pinnedList'
  }
}
