import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlideClincComponent } from './slide-clinc.component';

describe('SlideClincComponent', () => {
  let component: SlideClincComponent;
  let fixture: ComponentFixture<SlideClincComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SlideClincComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SlideClincComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
