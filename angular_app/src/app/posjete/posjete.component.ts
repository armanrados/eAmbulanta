import { Component, OnInit } from '@angular/core';
import {Posjeta} from 'src/app/models/posjete.model';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";

@Component({
  selector: 'app-posjete',
  templateUrl: './posjete.component.html',
  styleUrls: ['./posjete.component.css']
})
export class PosjeteComponent implements OnInit {

  Posjete : Posjeta[] = [];
  posjeta : Posjeta = {
    id: '',
    napomena: "",
    odgovor: "",
    pacijentID: '',
    odobreno: true,
    medicinskaSestraTehnicarID: ''
  };
  p:any;

  constructor(private eAmbulantaService : EAmbulantaServiceService) {

  }



  ngOnInit(): void
  {    this.getAllPosjetePozovi();

  }
  getAllPosjetePozovi(){
     this.eAmbulantaService.getMojePosjete()
       .subscribe(
         response => {
           this.Posjete = response;
        }
       );
 
      
  }


}
