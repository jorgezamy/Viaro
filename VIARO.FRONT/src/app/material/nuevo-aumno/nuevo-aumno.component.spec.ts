import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoAumnoComponent } from './nuevo-aumno.component';

describe('NuevoAumnoComponent', () => {
  let component: NuevoAumnoComponent;
  let fixture: ComponentFixture<NuevoAumnoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NuevoAumnoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoAumnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
