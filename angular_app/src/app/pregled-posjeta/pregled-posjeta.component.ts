import { Component, OnInit } from '@angular/core';
import { Posjeta } from '../models/posjete.model';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import { Router } from '@angular/router';
@Component({
  selector: 'app-pregled-posjeta',
  templateUrl: './pregled-posjeta.component.html',
  styleUrls: ['./pregled-posjeta.component.css']
})
export class PregledPosjetaComponent implements OnInit {

  Posjete : Posjeta[] = [];
  p:any;
  constructor(private eAmbulantaService : EAmbulantaServiceService, private router: Router) {

  }

  ngOnInit(): void
  {    this.getAllPosjetePozovi();

  }
  getAllPosjetePozovi(){
    this.eAmbulantaService.getAllPosjete()
      .subscribe(
        response => {
          this.Posjete = response;
        }
      );
  }
  deletePosjete(id : string){
    this.eAmbulantaService.deletePosjete(id)
      .subscribe(
        response =>{
          this.router.navigate(['pregled-posjeta']);
        }
      )
  }
}
