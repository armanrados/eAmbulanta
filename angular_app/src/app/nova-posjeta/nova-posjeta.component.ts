import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Posjeta } from '../models/posjete.model';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {AuthService} from "../service/auth.service";

@Component({
  selector: 'app-nova-posjeta',
  templateUrl: './nova-posjeta.component.html',
  styleUrls: ['./nova-posjeta.component.css']
})
export class NovaPosjetaComponent implements OnInit {

  addPosjetaRequest : Posjeta =
  {
    id: '',
    napomena: '',
    odgovor: '',
    odobreno: true,
    pacijentID: '',
    medicinskaSestraTehnicarID: '5a66499b-5461-4f49-8c5a-2ac6c900b53c'
  }
  userDetails : any;

  constructor(private eAmbulantaService : EAmbulantaServiceService,private router: Router, public authService : AuthService) {

  }


  ngOnInit(): void {
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
      }
    );
  }

  addPosjete()
  {
    this.addPosjetaRequest.pacijentID = this?.userDetails?.id;
    this.eAmbulantaService.addPosjete(this.addPosjetaRequest)
    .subscribe({
      next:(posjeta) =>
      {
        this.router.navigate(['posjete'])
      }
    })
  }
}
