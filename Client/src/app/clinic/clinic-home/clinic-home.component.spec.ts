import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicHomeComponent } from './clinic-home.component';

describe('ClinicHomeComponent', () => {
  let component: ClinicHomeComponent;
  let fixture: ComponentFixture<ClinicHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClinicHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
