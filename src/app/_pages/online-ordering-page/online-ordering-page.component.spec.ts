import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineOrderingPageComponent } from './online-ordering-page.component';

describe('OnlineOrderingPageComponent', () => {
  let component: OnlineOrderingPageComponent;
  let fixture: ComponentFixture<OnlineOrderingPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OnlineOrderingPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineOrderingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
