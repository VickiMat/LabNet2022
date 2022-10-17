import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSuppliersComponent } from './form-suppliers.component';

describe('FormSuppliersComponent', () => {
  let component: FormSuppliersComponent;
  let fixture: ComponentFixture<FormSuppliersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormSuppliersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSuppliersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
