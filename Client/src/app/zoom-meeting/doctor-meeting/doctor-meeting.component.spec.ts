import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorMeetingComponent } from './doctor-meeting.component';

describe('DoctorMeetingComponent', () => {
  let component: DoctorMeetingComponent;
  let fixture: ComponentFixture<DoctorMeetingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorMeetingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
