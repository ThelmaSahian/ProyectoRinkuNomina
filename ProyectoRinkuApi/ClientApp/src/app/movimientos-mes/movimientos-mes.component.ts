import { Component, OnInit, ViewChild, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {DxDataGridComponent } from 'devextreme-angular';
import { FormularioEntregasEmpleadoComponent } from 'src/app/formulario-entregas-empleado/formulario-entregas-empleado.component';

@Component({
  selector: 'app-movimientos-mes',
  templateUrl: './movimientos-mes.component.html',
  styleUrls: ['./movimientos-mes.component.css']
})
export class MovimientosMesComponent implements OnInit {
  @ViewChild('entregasGrid') dataGrid: DxDataGridComponent;
  @ViewChild('agregarEntrega') formulario: FormularioEntregasEmpleadoComponent;

  modalReference: any;
  empleados: any[];
  model: any = {};
  listaEmpleados: any[];
  groupValidationEmpleado = 'groupValidationEmpleado';
  _http: HttpClient;
  abrirModal: boolean = false;
  _baseUrl: string;
  data: any[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this._http = http;
   this._baseUrl = baseUrl;
   this.consultaEntrega();
  }

  ngOnInit(): void {
  }

  abrirModalAgregarMovmiento(){
    this.formulario.open();
  }

  consultaEntrega(){
    this._http.get<any[]>(this._baseUrl + 'api/EntregasEmpleado/GetAll').subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }
}
