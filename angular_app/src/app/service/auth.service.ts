import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {DoktorVMGet} from "../models/doktorVMGet";
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:7011/api";
  constructor(private http : HttpClient, private fb:FormBuilder) { }

  formModel = this.fb.group({
    ime : ['', [Validators.required, Validators.pattern('[A-ZŠĐĆČŽ]{1}[a-zšđćčž]{1,19}')]],
    prezime : ['', [Validators.required, Validators.pattern('[A-ZŠĐĆČŽ]{1}[a-zšđćčž]{1,29}')]],
    emailAdresa : ['', [Validators.required, Validators.email]],
    korisnickoIme : ['', [Validators.required, Validators.pattern('[A-Za-z0-9]{5,15}')]],
    lozinke : this.fb.group({
      lozinka1 : ['',[Validators.required, Validators.pattern('^((?=\\S*?[A-Z])(?=\\S*?[a-z])(?=\\S*?[0-9]).{8,})\\S$')]],
      lozinka2 : ['',Validators.required]
    }, {validator: this.uporediLozinke}),
    jmbg : ['',[Validators.required, Validators.pattern('[0-9]{13}')]],
    telefon : ['',[Validators.required, Validators.pattern('[0-9]{9,10}')]],
    datumRodjenja : ['',Validators.required],
    adresa : ['',Validators.required],
    longitude : ['',Validators.required],
    latitude : ['',Validators.required]


  });

  formModelZakaziTermin = this.fb.group({
    napomena : [''],
    doktorId : ['', Validators.required],
    datum : ['', Validators.required],
    vrijeme : ['',Validators.required],
    pacijentId : ['']
  })
 

  uporediLozinke(fg:FormGroup){
    let potvrdiLoz2 = fg.get('lozinka2');
    if (potvrdiLoz2?.errors == null || 'passwordMismatch' in potvrdiLoz2?.errors){
      if (fg.get('lozinka1')?.value != potvrdiLoz2?.value){
        potvrdiLoz2?.setErrors({passwordMismatch:true});
      }else{
        potvrdiLoz2?.setErrors(null);
      }
    }
  }

  //reg
  register(){
    let body = {
      ime: this.formModel.value.ime,
      prezime: this.formModel.value.prezime,
      korisnickoIme: this.formModel.value.korisnickoIme,
      email: this.formModel.value.emailAdresa,
      lozinka: this.formModel.value.lozinke.lozinka2,
      jmbg: this.formModel.value.jmbg,
      datumRodjenja: this.formModel.value.datumRodjenja,
      lokacija: {id: 0, adresa: this.formModel.value.adresa, longitude: this.formModel.value.longitude, latitude: this.formModel.value.latitude}
    };
    return this.http.post<any>(`${this.baseUrl}/Pacijent/Registracija`,body);
  }

  //login
  login(loginObj: any)
  {
    return this.http.post<any>(`${this.baseUrl}/korisnickiNalog/Login`,loginObj)
  }

  roleMatch(allowedRoles : string[]) : boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach((element:any)=>{
        if (userRole == element){
          isMatch = true;
          return;
        }
      }
    );
    return isMatch;
  }

  getUserProfile(){
    return this.http.get(this.baseUrl+'/korisnickiNalog/GetUserProfile');
  }

  getSveDoktore(){
    return this.http.get<DoktorVMGet[]>(this.baseUrl+'/Doktor/GetSveDoktore');
  }

  isLoggedIn(){
    if (localStorage.getItem('token') != null){
      return true;
    }else{
      return false;
    }
  }

  isAdministrator(){
    if (this.isLoggedIn() && this.roleMatch(['Administrator'])){
      return true;
    }else{
      return false;
    }
  }

  isPacijent(){
    if (this.isLoggedIn() && this.roleMatch(['Pacijent'])){
      return true; 
    }else{
      return false;
    }
  }

  isDoktor(){
    if (this.isLoggedIn() && this.roleMatch(['Doktor'])){
      return true;
    }else{
      return false;
    }
  }

  isMedicinskaSestraTehnicar(){
    if (this.isLoggedIn() && this.roleMatch(['MedicinskaSestraTehnicar'])){
      return true;
    }else{
      return false;
    }
  }
}
