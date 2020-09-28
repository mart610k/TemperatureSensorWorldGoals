import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorsShowerComponent } from './sensors-shower.component';

describe('SensorsShowerComponent', () => {
  let component: SensorsShowerComponent;
  let fixture: ComponentFixture<SensorsShowerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SensorsShowerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorsShowerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
