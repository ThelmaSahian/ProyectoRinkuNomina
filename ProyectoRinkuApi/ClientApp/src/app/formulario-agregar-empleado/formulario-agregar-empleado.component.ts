import { Component, OnInit, ViewChild, Inject, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';
import notify from 'devextreme/ui/notify';
import { outputAst } from '@angular/compiler';

@Component({
  selector: 'app-formulario-agregar-empleado',
  templateUrl: './formulario-agregar-empleado.component.html',
  styleUrls: ['./formulario-agregar-empleado.component.css']
})
export class FormularioAgregarEmpleadoComponent implements OnInit {
  @ViewChild('content') content: any;
  @Output() consultarEmpleado: EventEmitter<any> = new EventEmitter();
  modalReference: any;
  empleados: any[];
  model: any = {};
  tiposRoles: any[];
  groupValidationEmpleado = 'groupValidationEmpleado';
  _http: HttpClient;
  abrirModal: boolean = false;
  _baseUrl: string;

  constructor(private modalService: NgbModal, http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
   this._http = http;
   this._baseUrl = baseUrl;
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

  guardarEmpleado(event: any){
    const validator = event.validationGroup.validate();
    if (!validator.isValid) {
      notify("Revise campos faltantes", 'error', 2000);
      return;
    }
    let obj = {
      nombre: this.model.nombre,
      apellidoPaterno: this.model.apellidoPaterno,
      apellidoMaterno: this.model.apellidoMaterno,
      numeroEmpleado: this.model.numeroEmpleado,
      idRol: this.model.idRol,
    }


    try{
      this._http.post<number>(this._baseUrl + 'api/Empleados/CreateEmpleado', obj).subscribe(result => {
        if(result == 0){
          notify('Empleado guardado con éxito.', 'success');
          this.cancelarModal();
          this.consultarEmpleado.emit();
        }
        else if(result == 1)
          notify('El número de empleado ya se encuentra registrado.', 'error', 2000);
        else if(result == 2)
          notify('Hubo un error al guardar el empleado.', 'error', 2000);
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
    this.model.nombre = null;
    this.model.apellidoPaterno = null;
    this.model.apellidoMaterno = null;
    this.model.numeroEmpleado = null;
    this.model.idRol = null;
  }

  restriccionLetrasYPuntos(e: any) {
    const event = e.event;
    const str = event.key || String.fromCharCode(event.which);
    if (/^[-.,e]$/.test(str)) {
      event.preventDefault();
    }
  }
}
