import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentsShellComponent } from './students-shell.component';

describe('StudentsShellComponent', () => {
  let component: StudentsShellComponent;
  let fixture: ComponentFixture<StudentsShellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentsShellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentsShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
