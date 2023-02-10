import { Component } from '@angular/core';
import {Oglas} from "../models/oglas.model";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {AuthService} from "../service/auth.service";

@Component({
  selector: 'app-oglasi',
  templateUrl: './oglasi.component.html',
  styleUrls: ['./oglasi.component.css']
})
export class OglasiComponent {
  Oglasi : Oglas[] = [];
  oglas : Oglas = {
    id: 0,
    naziv: "",
    sadrzaj: "",
    administratorID: ""
  };
  userDetails : any;

  constructor(private eAmbulantaService : EAmbulantaServiceService, public authService : AuthService) {

  }

  ngOnInit(){
    this.getAllOglasiPozovi();
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
      }
    );
  }

  getAllOglasiPozovi() {
    this.eAmbulantaService.getAllOglasi()
      .subscribe(
        response => {
          this.Oglasi = response;
        }
      );
  }

  uredjivanjeOglasa(ind : number, ogl : Oglas){
    let tblRow = document.getElementById("tabelaOglasi")!.getElementsByTagName("tbody")[0].getElementsByTagName("tr")[ind];
    let collBtn = tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("button")[0];
    let nzvH3 = tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("h3")[0];
    let inputNzv = tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("input")[0];
    let txtSadrzaj = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("textarea")[0];
    let urediBtn = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[0];
    let odbaciBtn = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[1];
    let spremiBtn = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[2];
    if (!collBtn.hidden){
      collBtn.hidden = true;
      nzvH3.hidden = true;
      inputNzv.hidden = false;
      inputNzv.value = ogl.naziv;
      txtSadrzaj.disabled = false;
      urediBtn.hidden = true;
      odbaciBtn.hidden = false;
      spremiBtn.hidden = false;
    }else{
      collBtn.hidden = false;
      nzvH3.hidden = false;
      inputNzv.hidden = true;
      txtSadrzaj.disabled = true;
      urediBtn.hidden = false;
    }
  }

  odbaciPromjene(ind : number, ogl : Oglas){
    let tblRow = document.getElementById("tabelaOglasi")!.getElementsByTagName("tbody")[0].getElementsByTagName("tr")[ind];
    tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("button")[0].hidden = false;
    tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("h3")[0].hidden = false;
    tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("input")[0].hidden = true;
    tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("textarea")[0].disabled = true;
    tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("textarea")[0].value = ogl.sadrzaj;
    tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[0].hidden = false;
    tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[1].hidden = true;
    tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("button")[2].hidden = true;

  }

  spremiPromjene(ind : number, ogl : Oglas){
    let tblRow = document.getElementById("tabelaOglasi")!.getElementsByTagName("tbody")[0].getElementsByTagName("tr")[ind];
    let inputNzv = tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("input")[0];
    let txtSadrzaj = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("textarea")[0];
    if (inputNzv.value.length <= 0 || txtSadrzaj.value.length <= 0){
      return;
    }
    ogl.naziv =inputNzv.value;
    ogl.sadrzaj = txtSadrzaj.value;
    this.updateOglasPozovi(ogl);
    this.getAllOglasiPozovi();
  }

  updateOglasPozovi(ogl : Oglas){
    this.eAmbulantaService.updateOglas(ogl)
      .subscribe(
        response => {
          this.getAllOglasiPozovi();
        }
      )
  }

  promjenaBrdrNzv( ind : number){
    let tblRow = document.getElementById("tabelaOglasi")!.getElementsByTagName("tbody")[0].getElementsByTagName("tr")[ind];
    let inputNzv = tblRow.getElementsByTagName("div")[0].getElementsByTagName("div")[0].getElementsByTagName("input")[0];
    if (inputNzv.value.length <= 0){
      inputNzv.style.border = "red 2px solid";
      inputNzv.placeholder = "Naziv je obavezan!";
      return;
    }else{
      inputNzv.style.border = "grey 1px solid";
      inputNzv.placeholder = "";
    }
  }

  promjenaBrdrSadrzaj(ind : number){
    let tblRow = document.getElementById("tabelaOglasi")!.getElementsByTagName("tbody")[0].getElementsByTagName("tr")[ind];
    let txtSadrzaj = tblRow.getElementsByTagName("div")[0].getElementsByClassName("card-body")[0].getElementsByTagName("textarea")[0];
    if (txtSadrzaj.value.length <= 0){
      txtSadrzaj.style.border = "red 2px solid";
      txtSadrzaj.placeholder = "Sadrzaj je obavezan!";
      return;
    }else{
      txtSadrzaj.style.border = "grey 1px solid";
      txtSadrzaj.placeholder = "";
    }
  }

  dodajOglasForm(){
    if (document.getElementById("divNoviOglas")!.style.display === "none"){
      document.getElementById("divNoviOglas")!.style.display = "block";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("input")[0].value = "";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("input")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("input")[0].placeholder = "";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].placeholder = "Sadrzaj...";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("btnDodajOglas")!.style.display = "none";
    }else{
      document.getElementById("divNoviOglas")!.style.display = "none"
      document.getElementById("btnDodajOglas")!.style.display = "block";
    }
  }

  deleteOglasPozovi(id : number){
    this.eAmbulantaService.deleteOglas(id)
      .subscribe(
        response =>{
          this.getAllOglasiPozovi();
        }
      )
  }


  dodajNoviOglas(){
    let naziv = document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("input")[0];
    let sadrzaj = document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0];
    if (naziv.value.length <= 0){
      naziv.style.border = "red 2px solid";
      naziv.placeholder = "Naziv je obavezan...";
      return;
    }else {
      naziv.style.border = "grey 1px solid";
      naziv.placeholder = "";
    }
    if(sadrzaj.value.length <= 0){
      sadrzaj.style.border = "red 2px solid";
      sadrzaj.placeholder = "Sadrzaj je obavezan...";
      return;
    }else{
      sadrzaj.style.border = "grey 1px solid";
      sadrzaj.placeholder = "";
    }

    this.oglas.naziv = naziv.value;
    this.oglas.sadrzaj = sadrzaj.value;
    this.oglas.administratorID = this?.userDetails?.id;
    this.eAmbulantaService.addOglas(this.oglas)
      .subscribe(
        response => {
          this.getAllOglasiPozovi();
        }
      )
    this.dodajOglasForm();
  }
}
