import { Component, Output, EventEmitter, ElementRef } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss'],
  exportAs: 'modal'
})
export class ModalComponent {
  @Output() modalClose: EventEmitter<any> = new EventEmitter<any>();
  /**
   * TODO Use child element lookup to see if there is a header
   */
  showHeader = false;
  showFooter = false;
  constructor(private elt:ElementRef, private router: Router) { }

  ngAfterViewInit(){

  }
  /**
   * TODO need to generalize the router redirect
   */
  closeModal($event) {
    console.log('closed the modal component');
    this.router.navigate([{ outlets: { modal: null } }])
      .then(() => this.router.navigate(['/order']));;
    this.modalClose.next($event);
  }
}