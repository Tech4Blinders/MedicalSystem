import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignoutGoogleComponent } from './signout-google.component';

describe('SignoutGoogleComponent', () => {
  let component: SignoutGoogleComponent;
  let fixture: ComponentFixture<SignoutGoogleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignoutGoogleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignoutGoogleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
