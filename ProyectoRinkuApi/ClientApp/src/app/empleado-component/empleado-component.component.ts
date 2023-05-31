import { Component, ViewChild, Inject, OnInit } from '@angular/core';
import {DxDataGridComponent } from 'devextreme-angular';
import { HttpClient } from '@angular/common/http';
import { FormularioAgregarEmpleadoComponent } from 'src/app/formulario-agregar-empleado/formulario-agregar-empleado.component';

@Component({
  selector: 'app-empleado-component',
  templateUrl: './empleado-component.component.html',
  styleUrls: ['./empleado-component.component.css']
})
export class EmpleadoComponentComponent {
  @ViewChild('empleadoGrid') dataGrid: DxDataGridComponent;
  @ViewChild('agregarEmpleado') formulario: FormularioAgregarEmpleadoComponent;
  data: any = [];
  _http: HttpClient;
  result: boolean = false;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.consultaEmpleados();
  }
  
  abrirModalAgregarEmpleado(){
    this.formulario.open();
  }

  consultaEmpleados(){
    this._http.get<any[]>(this._baseUrl + 'api/Empleados/GetAll').subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }
}
