import { BrowserModule } from '@angular/platform-browser';
import { NgModule,NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { EmpleadoComponentComponent } from './empleado-component/empleado-component.component';
import { DevextremeModule } from './devextreme/devextreme.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormularioAgregarEmpleadoComponent } from './formulario-agregar-empleado/formulario-agregar-empleado.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {CommonModule} from '@angular/common';
import { MovimientosMesComponent } from './movimientos-mes/movimientos-mes.component';
import { FormularioEntregasEmpleadoComponent } from './formulario-entregas-empleado/formulario-entregas-empleado.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmpleadoComponentComponent,
    FormularioAgregarEmpleadoComponent,
    MovimientosMesComponent,
    FormularioEntregasEmpleadoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'movimientos', component: MovimientosMesComponent },
    ]),
    DevextremeModule,
    FontAwesomeModule,
    NgbModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
