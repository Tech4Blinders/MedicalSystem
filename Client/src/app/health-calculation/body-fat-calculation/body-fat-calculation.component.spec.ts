import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFatCalculationComponent } from './body-fat-calculation.component';

describe('BodyFatCalculationComponent', () => {
  let component: BodyFatCalculationComponent;
  let fixture: ComponentFixture<BodyFatCalculationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BodyFatCalculationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BodyFatCalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
