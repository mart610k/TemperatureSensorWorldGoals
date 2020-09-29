import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorbannerComponent } from './sensorbanner.component';

describe('SensorbannerComponent', () => {
  let component: SensorbannerComponent;
  let fixture: ComponentFixture<SensorbannerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SensorbannerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorbannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
