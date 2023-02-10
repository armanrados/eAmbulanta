import { Component } from '@angular/core';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {Novost} from "../models/novost.model";
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from "../service/auth.service";
import Swal from "sweetalert2";

@Component({
  selector: 'app-pregled-novost',
  templateUrl: './pregled-novost.component.html',
  styleUrls: ['./pregled-novost.component.css']
})
export class PregledNovostComponent {
  novost : Novost = {
    administratorID : "",
    datumIVrijemeObjave : "",
    id : 0,
    naziv : "",
    opis : "",
    sadrzaj : "",
    slika : ""
  };

  constructor(public service : EAmbulantaServiceService, public router : Router, public route : ActivatedRoute, public authService : AuthService) {
  }

  ngOnInit(){
    this.route.queryParams
      .subscribe(params => {
          this.novost.id = params.id;
        }
      );
    this.service.getNovost(this.novost.id).subscribe(
      res=>{
        this.novost = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  deleteNovostPozovi(){
    Swal.fire({
      title: 'Jeste li sigurni da želite obrisati ovu novost?',
      showCancelButton: true,
      cancelButtonText: "Ne želim obrisati novost",
      confirmButtonText: 'Potvrdi',
      showLoaderOnConfirm: true,
      preConfirm: (inputValue) => {
        return this.service.deleteNovost(this.novost.id).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno obrisana novost!',
              showConfirmButton: false,
              timer: 2500
            });
            this.router.navigate(['/novosti']);
          }
        )
      },
      allowOutsideClick: false
    });
  }

}
