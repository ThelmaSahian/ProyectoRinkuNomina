import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioAgregarEmpleadoComponent } from './formulario-agregar-empleado.component';

describe('FormularioAgregarEmpleadoComponent', () => {
  let component: FormularioAgregarEmpleadoComponent;
  let fixture: ComponentFixture<FormularioAgregarEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioAgregarEmpleadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioAgregarEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
