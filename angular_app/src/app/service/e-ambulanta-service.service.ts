import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {JavnaNabavka} from "../models/javnaNabavka.model";
import {Observable} from "rxjs";
import {Odluka} from "../models/odluka.model";
import {OdlukeComponent} from "../odluke/odluke.component";
import {Oglas} from "../models/oglas.model";
import { Posjeta } from '../models/posjete.model';
import {query} from "@angular/animations";
import {Pregled} from "../models/pregled";
import {Novost} from "../models/novost.model";
import {Navigation} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class EAmbulantaServiceService {

  baseUrl = 'https://localhost:7011/api';
  constructor(private http: HttpClient) { }

  //JavneNabavke-------------------------------------
  getAllJavneNabavke() : Observable<JavnaNabavka[]>{
    return this.http.get<JavnaNabavka[]>(this.baseUrl + "/JavnaNabavka/GetAll");
  }

  updateJavnaNabavka(jn : JavnaNabavka) : Observable<JavnaNabavka>{
    return this.http.put<JavnaNabavka>(this.baseUrl + "/JavnaNabavka/Update/" + jn.id,{id: jn.id, opis: jn.opis});
  }

  deleteJavnaNabavka(id : number) : Observable<JavnaNabavka>{
    return this.http.delete<JavnaNabavka>(this.baseUrl + "/JavnaNabavka/Delete/" + id);
  }

  addJavnaNabavka(jn : JavnaNabavka){
    return this.http.post(this.baseUrl + "/JavnaNabavka/Add", {"opis": jn.opis, "pdfFajl": jn.pdfFajl, "administratorID": jn.administratorID});
  }

  //Odluke-------------------------------------
  getAllOdluke() : Observable<Odluka[]>{
    return this.http.get<Odluka[]>(this.baseUrl + "/Odluka/GetAll");
  }

  updateOdluke(odl : Odluka) : Observable<Odluka>{
    return this.http.put<Odluka>(this.baseUrl + "/Odluka/Update/" + odl.id, {id: odl.id, opis: odl.opis});
  }

  deleteOdluka(id : number) : Observable<Odluka>{
    return this.http.delete<Odluka>(this.baseUrl + "/Odluka/Delete/" + id);
  }

  addOdluka(odl : Odluka){
    return this.http.post(this.baseUrl + "/Odluka/Add", {"opis": odl.opis, "pdfFajl": odl.pdfFajl, "administratorID": odl.administratorID});
  }

  //Oglasi----------------------------------------------------------------
  getAllOglasi() : Observable<Oglas[]>{
    return this.http.get<Oglas[]>(this.baseUrl + "/Oglas/GetAll");
  }

  updateOglas(ogl : Oglas) : Observable<Oglas>{
    return this.http.put<Oglas>(this.baseUrl + "/Oglas/Update/" + ogl.id, {naziv: ogl.naziv, sadrzaj: ogl.sadrzaj});
  }

  deleteOglas(id : number) : Observable<Oglas>{
    return this.http.delete<Oglas>(this.baseUrl + "/Oglas/Delete/" + id);
  }

  addOglas(ogl : Oglas) {
    return this.http.post(this.baseUrl + "/Oglas/Add", {
      "naziv": ogl.naziv,
      "sadrzaj": ogl.sadrzaj,
      "administratorID": ogl.administratorID
    });
  }

    //Posjete-------------------------------------
   getAllPosjete() : Observable<Posjeta[]>{
    return this.http.get<Posjeta[]>(this.baseUrl + "/Posjeta/GetAll");
  }
  getMojePosjete() : Observable<Posjeta[]>{
    return this.http.get<Posjeta[]>(this.baseUrl + "/Posjeta/getMojePosjete");
  }
  

  updatePosjete(id: string, posj : Posjeta) : Observable<Posjeta>{
    return this.http.put<Posjeta>(this.baseUrl + "/Posjeta/Update/" + id, posj);
  }

  deletePosjete(id : string) : Observable<Posjeta>{
    return this.http.delete<Posjeta>(this.baseUrl + "/Posjeta/Delete/" + id);
  }

  addPosjete(posj : Posjeta){
    return this.http.post(this.baseUrl + "/Posjeta/Add", {"napomena": posj.napomena, "medicinskaSestraTehnicarID": posj.medicinskaSestraTehnicarID, "pacijentID": posj.pacijentID});
  }
  getPosjeta(id : string) : Observable<Posjeta>{
    return this.http.get<Posjeta>(this.baseUrl + "/Posjeta/Get/" + id);
  }

  //Pregledi--------------------------------------------------------------------------------------------------

  //Pregledi - pacijent
  getPreglediZaDatum(datum : string, id : string) : Observable<string[]>{
    return this.http.get<string[]>(this.baseUrl+"/Pregled/GetPreglediZaDatum", {params: new HttpParams().append("datum", datum).append("id", id)});
  }

  addPregled(body : any){
    return this.http.post(this.baseUrl + "/Pregled/Add", {"datum": body.datum, "vrijeme": body.vrijeme, "napomena": body.napomena, "doktorId": body.doktorId, "pacijentId": body.pacijentId});
  }

  getTerminiKojiCekajuNaOdobrenje() : Observable<Pregled[]>{
    return this.http.get<Pregled[]>(this.baseUrl + "/Pregled/GetTerminiKojiCekajuNaOdobrenje");
  }

  getNadolazeciTermini() : Observable<Pregled[]>{
    return this.http.get<Pregled[]>(this.baseUrl + "/Pregled/GetNadolazeciTermini");
  }

  getTerminUskoro() : Observable<Pregled>{
    return this.http.get<Pregled>(this.baseUrl + "/Pregled/GetTerminUskoro");
  }

  getPrethodniTermini() : Observable<Pregled[]>{
    return this.http.get<Pregled[]>(this.baseUrl+"/Pregled/GetPrethodniTermini");
  }

  deletePregled(id : number) : Observable<Pregled>{
    return this.http.delete<Pregled>(this.baseUrl + "/Pregled/Delete/" + id);
  }

  //Pregledi - doktor
  getTerminiKojiCekajuNaOdobrenjeDoktor() : Observable<Pregled[]>{
    return this.http.get<Pregled[]>(this.baseUrl + "/Pregled/GetTerminiKojiCekajuNaOdobrenjeDoktor");
  }

  getTerminiDanas() : Observable<Pregled[]>{
    return this.http.get<Pregled[]>(this.baseUrl + "/Pregled/GetTerminiDanas");
  }

  odobriPregled(pregled : any){
    return this.http.put(this.baseUrl + "/Pregled/Odobri", {"id" : pregled.id, "odobreno" : pregled.odobreno, "odgovor" : pregled.odgovor});
  }

  //Novosti
  getNovosti() : Observable<Novost[]>{
    return this.http.get<Novost[]>(this.baseUrl + "/Novost/GetAll");
  }

  getPretrazivanjeNovosti(input : string) : Observable<Novost[]>{
    return this.http.get<Novost[]>(this.baseUrl + "/Novost/GetAllPretrazivanje", {params: new HttpParams().append("input", input)});
  }

  getNovostiNajstarije() : Observable<Novost[]>{
    return this.http.get<Novost[]>(this.baseUrl + "/Novost/GetAllNajstarije");
  }

  getNovost(id : number) : Observable<Novost>{
    return this.http.get<Novost>(this.baseUrl + "/Novost/GetNovost", {params: new HttpParams().append("id", id)});
  }

  addNovost(body : any){
    return this.http.post(this.baseUrl + "/Novost/Add", {"naziv": body.naziv, "opis": body.opis, "sadrzaj": body.sadrzaj, "datum": body.datum, "vrijeme": body.vrijeme, "slika":body.slika, "administratorID": body.administratorID});
  }

  deleteNovost(id : number) : Observable<Novost>{
    return this.http.delete<Novost>(this.baseUrl + "/Novost/Delete/" + id);
  }
}
