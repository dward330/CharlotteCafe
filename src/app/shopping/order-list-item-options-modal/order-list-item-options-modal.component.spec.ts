import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderListItemOptionsModalComponent } from './order-list-item-options-modal.component';

describe('OrderListItemOptionsModalComponent', () => {
  let component: OrderListItemOptionsModalComponent;
  let fixture: ComponentFixture<OrderListItemOptionsModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderListItemOptionsModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderListItemOptionsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
