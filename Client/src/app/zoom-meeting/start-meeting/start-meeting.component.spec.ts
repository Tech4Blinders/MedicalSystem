import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StartMeetingComponent } from './start-meeting.component';

describe('StartMeetingComponent', () => {
  let component: StartMeetingComponent;
  let fixture: ComponentFixture<StartMeetingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StartMeetingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StartMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
