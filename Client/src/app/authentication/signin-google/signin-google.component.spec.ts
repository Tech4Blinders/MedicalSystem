import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SigninGoogleComponent } from './signin-google.component';

describe('SigninGoogleComponent', () => {
  let component: SigninGoogleComponent;
  let fixture: ComponentFixture<SigninGoogleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SigninGoogleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SigninGoogleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
