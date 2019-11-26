import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PinnedListItemComponent } from './pinned-list-item.component';

describe('PinnedListItemComponent', () => {
  let component: PinnedListItemComponent;
  let fixture: ComponentFixture<PinnedListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PinnedListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PinnedListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
