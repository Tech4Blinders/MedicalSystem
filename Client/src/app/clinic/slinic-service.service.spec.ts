import { TestBed } from '@angular/core/testing';

import { ClinicServiceService } from './clinic-service.service';

describe('SlinicServiceService', () => {
  let service: ClinicServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClinicServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
