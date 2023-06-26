import { Component, OnInit, ViewChild, Inject, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-formulario-entregas-empleado',
  templateUrl: './formulario-entregas-empleado.component.html',
  styleUrls: ['./formulario-entregas-empleado.component.css']
})
export class FormularioEntregasEmpleadoComponent implements OnInit {
  @ViewChild('content') content: any;
  @Output() consultarEntrega: EventEmitter<any> = new EventEmitter();
  modalReference: any;
  empleados: any[];
  model: any = {};
  listaEmpleados: any[];
  groupValidationEntrega = 'groupValidationEntrega';
  _http: HttpClient;
  abrirModal: boolean = false;
  _baseUrl: string;
  tiposRoles: any[];

  constructor(private modalService: NgbModal, http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._http = http;
    this._baseUrl = baseUrl;
     http.get<any[]>(baseUrl + 'api/Empleados/GetComboEmpleados').subscribe(result => {
       this.listaEmpleados = result;
     }, error => console.error(error));
     http.get<any[]>(baseUrl + 'api/Roles/GetCombo').subscribe(result => {
      this.tiposRoles = result;
    }, error => console.error(error));
 }

  ngOnInit(): void {
  }

  open(){
    this.modalReference = this.modalService.open(this.content, {
      size: 'xl', scrollable: true, backdrop: 'static',
      keyboard: false
    });
  }

  guardar(event: any){
    const validator = event.validationGroup.validate();
    if (!validator.isValid) {
      notify("Revise campos faltantes", 'error', 2000);
      return;
    }
    let obj = {
      idEmpleado: this.model.idEmpleado,
      fechaEntrega: this.model.mes,
      cantidadEntregas: this.model.cantidadEntregas
    }


    try{
      this._http.post<number>(this._baseUrl + 'api/EntregasEmpleado/CreateEntregasEmpleado', obj).subscribe(result => {
        if(result == 0){
          notify('Entregas guardadas con éxito.', 'success');
          this.cancelarModal();
          this.consultarEntrega.emit();
        }
        else if(result == 1)
          notify('El empleado ya tiene sus entregas registradas para este mes.', 'error', 2000);
        else if(result == 2)
          notify('Hubo un error al guardar las entregas.', 'error', 2000);
      }, 
      error =>{
        notify(error, 'error', 200)
      }
      )
    } catch(e){
      notify(e, 'error', 2000);
    }
  }

  cancelarModal(){
    this.abrirModal = false;
    this.modalReference.close(false);
    this.limpiarFormulario();
  }

  limpiarFormulario(){
    this.model.idEmpleado = null;
    this.model.nombre = null;
    this.model.numeroEmpleado = null;
    this.model.idRol = null;
    this.model.mes = null;
    this.model.cantidadEntregas = null;
  }

  changeEmpleado(event: any){
    let empleado = this.listaEmpleados.find(x => event.value == x.id);
    this.model.nombre = empleado.text;
    this.model.numeroEmpleado = empleado.numeroEmpleado;
    this.model.idRol = empleado.idRol;
  }

  changeDate(event: any){
    this.model.mes = event.value;
  }

  restriccionLetrasYPuntos(e: any) {
    const event = e.event;
    const str = event.key || String.fromCharCode(event.which);
    if (/^[-.,e+]$/.test(str)) {
      event.preventDefault();
    }
  }
}
