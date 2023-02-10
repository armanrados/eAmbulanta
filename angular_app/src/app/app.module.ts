import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MainSidebarComponent } from './main-sidebar/main-sidebar.component';
import { ContentWrapperComponent } from './content-wrapper/content-wrapper.component';
import { ControlSidebarComponent } from './control-sidebar/control-sidebar.component';
import { NovostiComponent } from './novosti/novosti.component';
import { JavneNabavkeComponent } from './javne-nabavke/javne-nabavke.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import {FormsModule} from "@angular/forms";
import {OdlukeComponent} from "./odluke/odluke.component";
import { PosjeteComponent } from './posjete/posjete.component';
import { NovaPosjetaComponent } from './nova-posjeta/nova-posjeta.component';
import { UrediPosjetuComponent } from './uredi-posjetu/uredi-posjetu.component';
import { PregledPosjetaComponent } from './pregled-posjeta/pregled-posjeta.component';

import {OglasiComponent} from "./oglasi/oglasi.component";
import { RegistrationComponent } from './registration/registration.component';
import {AuthService} from "./service/auth.service";
import {AuthInterceptor} from "./auth/auth.interceptor";
import { ProfileComponent } from './profile/profile.component';
import {ZakaziTerminComponent} from "./zakazi-termin/zakazi-termin.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import {PregledTerminaComponent} from "./pregled-termina/pregled-termina.component";
import { PregledNovostComponent } from './pregled-novost/pregled-novost.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { SvgPDFComponent } from './svg-pdf/svg-pdf.component';




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    MainSidebarComponent,
    ContentWrapperComponent,
    ControlSidebarComponent,
    NovostiComponent,
    JavneNabavkeComponent,
    LoginComponent,
    OdlukeComponent,
    PosjeteComponent,
    NovaPosjetaComponent,
    UrediPosjetuComponent,
    PregledPosjetaComponent,

    OglasiComponent,
       RegistrationComponent,
       ProfileComponent,
    ZakaziTerminComponent,
    PregledTerminaComponent,
    PregledNovostComponent,
    SvgPDFComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    SweetAlert2Module,
    NgxPaginationModule

 
  ],
  providers: [AuthService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
