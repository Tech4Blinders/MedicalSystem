import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Section6Component } from './section6.component';

describe('Section6Component', () => {
  let component: Section6Component;
  let fixture: ComponentFixture<Section6Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Section6Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Section6Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
