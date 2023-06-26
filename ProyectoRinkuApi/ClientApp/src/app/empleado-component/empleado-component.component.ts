import { Component, ViewChild, Inject, OnInit } from '@angular/core';
import {DxDataGridComponent } from 'devextreme-angular';
import { HttpClient } from '@angular/common/http';
import { FormularioAgregarEmpleadoComponent } from 'src/app/formulario-agregar-empleado/formulario-agregar-empleado.component';
import { exportDataGrid } from 'devextreme/excel_exporter';
import * as ExcelJS from "exceljs";
import * as saveAs from "file-saver";
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

  onToolbarPreparing(e: any) {
    e.toolbarOptions.items.push({
      widget: 'dxButton',
      showText: 'always',
      options: {
        icon: 'fas fa-file-excel',
        text: 'Excel',
        onClick: function () {
          e.component.exportToExcel(false);
        }
      },
      location: 'after'
    });
  }
  onExporting(e: any) {
    const workbook = new ExcelJS.Workbook();
    const worksheet = workbook.addWorksheet('Amparos');

    exportDataGrid({
      component: e.component,
      worksheet: worksheet,
      autoFilterEnabled: true
    }).then(() => {
      workbook.xlsx.writeBuffer().then((buffer: any) => {
        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Empleados.xlsx');
      });
    });
    e.cancel = true;
  }
}
