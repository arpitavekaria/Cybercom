import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdertypeAddEditComponent } from './ordertype-add-edit.component';

describe('OrdertypeAddEditComponent', () => {
  let component: OrdertypeAddEditComponent;
  let fixture: ComponentFixture<OrdertypeAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdertypeAddEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdertypeAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
