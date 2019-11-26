import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainListItemComponent } from './main-list-item.component';

describe('MainListItemComponent', () => {
  let component: MainListItemComponent;
  let fixture: ComponentFixture<MainListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
