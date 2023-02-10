import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OdlukeComponent } from './odluke/odluke.component';
import { OglasiComponent } from './oglasi/oglasi.component';
import { LoginComponent } from './login/login.component';
import { JavneNabavkeComponent } from './javne-nabavke/javne-nabavke.component';
import { ZakaziTerminComponent } from './zakazi-termin/zakazi-termin.component';
import { PregledTerminaComponent } from './pregled-termina/pregled-termina.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ContentWrapperComponent } from './content-wrapper/content-wrapper.component';
import { ControlSidebarComponent } from './control-sidebar/control-sidebar.component';
import { MainSidebarComponent } from './main-sidebar/main-sidebar.component';
import { NovostiComponent } from './novosti/novosti.component';
import { PosjeteComponent } from './posjete/posjete.component';
import { NovaPosjetaComponent } from './nova-posjeta/nova-posjeta.component';
import { UrediPosjetuComponent } from './uredi-posjetu/uredi-posjetu.component';
import { PregledPosjetaComponent } from './pregled-posjeta/pregled-posjeta.component';
import {RegistrationComponent} from "./registration/registration.component";
import {AuthGuard} from "./auth/auth.guard";
import {ProfileComponent} from "./profile/profile.component";
import {PregledNovostComponent} from "./pregled-novost/pregled-novost.component";
import { SvgPDFComponent } from './svg-pdf/svg-pdf.component';

const routes: Routes = [

  {path: '', redirectTo: 'content-wrapper', pathMatch: 'full' },
  {path:'odluke', component:OdlukeComponent},
  {path:'oglasi', component:OglasiComponent},
  {path:'javne-nabavke', component:JavneNabavkeComponent},
  {path:'zakazi-termin', component:ZakaziTerminComponent, canActivate:[AuthGuard], data:{permittedRoles:['Pacijent']}},
  {path:'pregled-termina', component:PregledTerminaComponent, canActivate:[AuthGuard]},
  {path:'navbar', component:NavbarComponent},
  {path:'content-wrapper', component:ContentWrapperComponent},
  {path:'control-sidebar', component:ControlSidebarComponent},
  {path:'main-sidebar', component:MainSidebarComponent},
  {path:'login', component:LoginComponent},
  {path:'novosti', component:NovostiComponent},
  {path:'posjete', component:PosjeteComponent, canActivate:[AuthGuard], data:{permittedRoles:['Pacijent']}},
  {path:'nova-posjeta', component:NovaPosjetaComponent},
  {path:'uredi-posjetu/:id', component:UrediPosjetuComponent},
  {path:'pregled-posjeta', component:PregledPosjetaComponent},
  {path:'registracija', component:RegistrationComponent},
  {path:'profil', component: ProfileComponent, canActivate:[AuthGuard]},
  {path:'pregled-novost', component:PregledNovostComponent},
  {path:'svgPdf', component:SvgPDFComponent}















];

@NgModule({

  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
