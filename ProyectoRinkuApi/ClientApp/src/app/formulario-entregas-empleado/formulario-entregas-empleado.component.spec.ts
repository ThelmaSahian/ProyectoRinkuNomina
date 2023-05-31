import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioEntregasEmpleadoComponent } from './formulario-entregas-empleado.component';

describe('FormularioEntregasEmpleadoComponent', () => {
  let component: FormularioEntregasEmpleadoComponent;
  let fixture: ComponentFixture<FormularioEntregasEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioEntregasEmpleadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioEntregasEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
