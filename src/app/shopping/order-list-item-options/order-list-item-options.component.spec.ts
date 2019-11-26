import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderListItemOptionsComponent } from './order-list-item-options.component';

describe('OrderListItemOptionsComponent', () => {
  let component: OrderListItemOptionsComponent;
  let fixture: ComponentFixture<OrderListItemOptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderListItemOptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderListItemOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
