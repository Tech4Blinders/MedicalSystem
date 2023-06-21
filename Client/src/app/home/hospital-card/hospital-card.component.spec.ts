import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospitalCardComponent } from './hospital-card.component';

describe('HospitalCardComponent', () => {
  let component: HospitalCardComponent;
  let fixture: ComponentFixture<HospitalCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospitalCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HospitalCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
