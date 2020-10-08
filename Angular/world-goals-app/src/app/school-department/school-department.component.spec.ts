import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolDepartmentComponent } from './school-department.component';

describe('SchoolDepartmentComponent', () => {
  let component: SchoolDepartmentComponent;
  let fixture: ComponentFixture<SchoolDepartmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolDepartmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
