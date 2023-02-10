import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import { Posjeta } from '../models/posjete.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-uredi-posjetu',
  templateUrl: './uredi-posjetu.component.html',
  styleUrls: ['./uredi-posjetu.component.css']
})
export class UrediPosjetuComponent implements OnInit {

posjetaDetalji : Posjeta = {
  id: '',
  odobreno: true,
  odgovor: '',
  napomena: '',
  pacijentID: "",
  medicinskaSestraTehnicarID: ""

}
constructor(private route: ActivatedRoute, private eAmbulantaService : EAmbulantaServiceService, private router: Router){

}

ngOnInit(): void {
  this.route.paramMap.subscribe({
    next:(params) =>
    {
      const id = params.get('id');
      if(id)
      {
        this.eAmbulantaService.getPosjeta(id)
        .subscribe({
          next: (response) =>
          {
            this.posjetaDetalji = response;
          }
        })
      }
    }
  })
}

updatePosjete()
{
  this.eAmbulantaService.updatePosjete(this.posjetaDetalji.id,this.posjetaDetalji)
  .subscribe({
    next: (response) =>
    {
      this.router.navigate(['pregled-posjeta'])
    }
  });
}



}
