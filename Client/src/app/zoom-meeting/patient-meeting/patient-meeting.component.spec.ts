import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientMeetingComponent } from './patient-meeting.component';

describe('PatientMeetingComponent', () => {
  let component: PatientMeetingComponent;
  let fixture: ComponentFixture<PatientMeetingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientMeetingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
