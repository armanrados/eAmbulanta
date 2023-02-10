import { Component } from '@angular/core';
import {Pregled} from "../models/pregled";
import {AuthService} from "../service/auth.service";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import Swal from "sweetalert2";

@Component({
  selector: 'app-pregled-termina',
  templateUrl: './pregled-termina.component.html',
  styleUrls: ['./pregled-termina.component.css']
})
export class PregledTerminaComponent {
  terminiKojiCekajuNaOdobrenjeDoktor : Pregled[] = [];
  terminiDanas : Pregled[] = [];

  constructor(public authService : AuthService, public service : EAmbulantaServiceService) {
  }

  ngOnInit(){
    this.pozivTerminiKojiCekajuNaOdobrenjeDoktor();
    this.pozivGetTerminiDanas();
  }

  pozivTerminiKojiCekajuNaOdobrenjeDoktor(){
    this.service.getTerminiKojiCekajuNaOdobrenjeDoktor().subscribe(
      res=>{
        this.terminiKojiCekajuNaOdobrenjeDoktor = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  pozivGetTerminiDanas(){
    this.service.getTerminiDanas().subscribe(
      res=>{
        this.terminiDanas = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  pozivOdobriPregled(ind : number){
    Swal.fire({
      title: 'Dodajte odgovor pacijentu ukoliko želite',
      input: 'text',
      inputAttributes: {
        autocapitalize: 'off'
      },
      showCancelButton: true,
      confirmButtonText: 'Potvrdi',
      showLoaderOnConfirm: true,
      preConfirm: (inputValue) => {
        let pr = {
          id : this.terminiKojiCekajuNaOdobrenjeDoktor[ind].id,
          odobreno : true,
          odgovor : inputValue
        }
        return this.service.odobriPregled(pr).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno odobren termin!',
              showConfirmButton: false,
              timer: 2500
            });
            this.pozivTerminiKojiCekajuNaOdobrenjeDoktor();
            this.pozivGetTerminiDanas();
          }
        )
      },
      allowOutsideClick: false
    });
  }
}
