import { Component } from '@angular/core';
import {AuthService} from "../service/auth.service";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {DoktorVMGet} from "../models/doktorVMGet";
import Swal from "sweetalert2";
import {Pregled} from "../models/pregled";

@Component({
  selector: 'app-zakazi-termin',
  templateUrl: './zakazi-termin.component.html',
  styleUrls: ['./zakazi-termin.component.css']
})
export class ZakaziTerminComponent {
  minDate = new Date();
  minDateString = new Date().toLocaleDateString('en-CA');
  doktori : DoktorVMGet[] = [];
  vrijemePregleda : string[] = ['7:30', '8:00', '8:30', '9:00', '9:30', '10:00', '10:30', '11:00', '11:30', '12:00', '12:30', '13:00', '13:30', '14:00', '14:30', '15:00', '15:30'];
  preglediZaDatum : string[] = [];
  moguceVrijemePregleda : string[] = [];
  pacijent : any;
  preglediKojiCekajuNaOdobrenje : Pregled[] = [];
  nadolazeciPregledi : Pregled[] = [];
  terminUskoro : Pregled;
  prethodniTermini : Pregled[] = [];
  /*defaultPregled : Pregled = {
    datum: "",
    dijagnoza: "",
    doktorId: "",
    id: 0,
    napomena: "",
    obavljeno: false,
    odgovor: "",
    odobreno: false,
    pacijentId: "",
    terapija: "",
    vrijeme: ""
  }*/

  constructor(public authService: AuthService, private service : EAmbulantaServiceService) {
    /*this.prethodniTermini.push(this.defaultPregled);
    this.nadolazeciPregledi.push(this.defaultPregled);
    this.preglediKojiCekajuNaOdobrenje.push(this.defaultPregled);*/
  }

  ngOnInit(){
    this.authService.getSveDoktore().subscribe(
      res=>{
        this.doktori = res;
    },
      error => {
        console.log(error);
      });
    this.authService.getUserProfile().subscribe(
      res=>{
        this.pacijent = res;
      },
      err=>{
        console.log(err);
      }
    );
    this.pozivTerminiKojiCekajuNaOdobrenje();
    this.pozivNadolazeciTermini();
    this.pozivTerminUskoro();
    this.pozivPrethodniTermini();
  }

  pozivPrethodniTermini(){
    this.service.getPrethodniTermini().subscribe(
      res => {
        this.prethodniTermini = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  pozivTerminiKojiCekajuNaOdobrenje(){
    this.service.getTerminiKojiCekajuNaOdobrenje().subscribe(
      res => {
        this.preglediKojiCekajuNaOdobrenje = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  pozivNadolazeciTermini(){
    this.service.getNadolazeciTermini().subscribe(
      res => {
        this.nadolazeciPregledi = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  pozivTerminUskoro(){
    this.service.getTerminUskoro().subscribe(
      res => {
        this.terminUskoro = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSubmit() {
    if (this.authService.formModelZakaziTermin.value.napomena == null){
      this.authService.formModelZakaziTermin.value.napomena = "";
    }
    let body = {
      datum: this.authService.formModelZakaziTermin.value.datum,
      vrijeme: this.authService.formModelZakaziTermin.value.vrijeme,
      napomena: this.authService.formModelZakaziTermin.value.napomena,
      doktorId: this.authService.formModelZakaziTermin.value.doktorId,
      pacijentId: this.pacijent.id
    }
    this.service.addPregled(body).subscribe(
      res=>{
        this.dodajNoviTerminForm();
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno poslan zahtjev za termin!',
          showConfirmButton: false,
          timer: 2500
        })
        this.pozivTerminiKojiCekajuNaOdobrenje();
      },
      err=>{
        console.log(err);
        Swal.fire({
          position: 'top-end',
          icon: 'error',
          title: 'Termin nije dodan, kontaktirajte podršku korisnika!',
          showConfirmButton: false,
          timer: 2500
        })
      }
    );
  }

  pozivDeletePregled(id : number){
    Swal.fire({
      title: 'Otkazivanje zahtjeva',
      text: "Jeste li sigurni da želite otkazati zahtjev?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Da, siguran sam!',
      cancelButtonText: "Odustani"
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deletePregled(id).subscribe(
          res=>{
            Swal.fire(
              'Obrisano!',
              'Zahtjev je uspješno obrisan.',
              'success'
            );
            this.pozivTerminiKojiCekajuNaOdobrenje();
            this.pozivNadolazeciTermini();
            this.pozivTerminUskoro();
          },
          err=>{
            console.log(err);
          }
        );
      }
    });
  }

  dodajNoviTerminForm() {
    if (document.getElementById("divNoviTermin")!.style.display === "none") {
      this.authService.formModelZakaziTermin.reset();
      document.getElementById("divNoviTermin")!.style.display = "block";
      document.getElementById("btnDodajNoviTermin")!.style.display = "none";
    } else {
      document.getElementById("divNoviTermin")!.style.display = "none"
      document.getElementById("btnDodajNoviTermin")!.style.display = "block";
    }
  }

  loadPreglediZaDatum(){
    this.service.getPreglediZaDatum(this.authService!.formModelZakaziTermin!.value!.datum!.toString(), this.authService!.formModelZakaziTermin!.value!.doktorId!.toString()).subscribe(
      res=>{
        this.preglediZaDatum = res;
      },
      error => {
        console.log(error);
      }
    )
    this.moguceVrijemePregleda = [];
    let zauzeto = false;
    for (let i = 0; i < this.vrijemePregleda.length; i++) {
      for (let j = 0; j < this.preglediZaDatum.length; j++) {
        if (this.vrijemePregleda[i] == this.preglediZaDatum[j]) {
          zauzeto = true;
        }
      }
      if (!zauzeto) {
        this.moguceVrijemePregleda.push(this.vrijemePregleda[i]);
      }
      zauzeto = false;
    }
  }

  emptyMoguceVrijemePregleda(){
    this.moguceVrijemePregleda = [];
  }
}
