import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimientosMesComponent } from './movimientos-mes.component';

describe('MovimientosMesComponent', () => {
  let component: MovimientosMesComponent;
  let fixture: ComponentFixture<MovimientosMesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimientosMesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovimientosMesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
