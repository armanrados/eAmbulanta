import { Component } from '@angular/core';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {Novost} from "../models/novost.model";
import {Route, Router, RouterModule} from "@angular/router";
import {routerLink} from "@angular/core/schematics/migrations/router-link-with-href/util";
import {PregledNovostComponent} from "../pregled-novost/pregled-novost.component";
import {AuthService} from "../service/auth.service";
import Swal from "sweetalert2";
import {Buffer} from "buffer";
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-novosti',
  templateUrl: './novosti.component.html',
  styleUrls: ['./novosti.component.css']
})
export class NovostiComponent {
  novosti: Novost[] = [];
  novaNovost : Novost = new class implements Novost {
    administratorID: string = "";
    datumIVrijemeObjave: string = "";
    id: number = 0;
    naziv: string = "";
    opis: string = "";
    sadrzaj: string = "";
    slika: string = "";
  };
  userDetails : any;
  encodedSlika:string="";

  constructor(public service : EAmbulantaServiceService, private router : Router, public authService : AuthService,private sanitizer: DomSanitizer) {
  }

  ngOnInit(){
    this.pozoviGetNovosti();
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
      }
    );
  }

  pozoviGetNovosti(){
    this.service.getNovosti().subscribe(
      res=>{
        this.novosti = res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  pozoviGetNovostiNajstarije(){
    this.service.getNovostiNajstarije().subscribe(
      res=>{
        this.novosti = res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  otvoriNovost(id : number){
    this.router.navigate(['pregled-novost'], {queryParams: {id : id}});
  }

  pretrazivanjeNovosti(){
    let input = document.getElementById("pretrazivanjeDiv")!.getElementsByTagName("input")[0].value;
    if (input == "" || input == null){
      this.pozoviGetNovosti();
      document.getElementById("sortNovosti")!.getElementsByTagName("select")[0].value = "1";
      return;
    }
    this.service.getPretrazivanjeNovosti(input).subscribe(
      res=>{
        this.novosti = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  sortiraj(){
    if (document.getElementById("sortNovosti")!.getElementsByTagName("select")[0].value == "2"){
      this.novosti.sort(
        (n1, n2) => new Date(n1.datumIVrijemeObjave).getTime() - new Date(n2.datumIVrijemeObjave).getTime(),
      );
    }else{
      this.novosti.sort(
        (n1, n2) => new Date(n2.datumIVrijemeObjave).getTime() - new Date(n1.datumIVrijemeObjave).getTime(),
      );
    }
  }


  dodajNovostForm(){
    if (document.getElementById("divNovaNovost")!.style.display === "none"){
      document.getElementById("divNovaNovost")!.style.display = "block";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].placeholder = "Opis...";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("textarea")[0].placeholder = "Naziv...";
      document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].placeholder = "Sadrzaj...";
      document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("input")[0].value = "";
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Odaberite sliku";
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
      document.getElementById("btnDodajNovost")!.style.display = "none";
    }else{
      document.getElementById("divNovaNovost")!.style.display = "none"
      document.getElementById("btnDodajNovost")!.style.display = "block";
    }
  }

  onFileSelected(){
    const f = document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("input")[0].files;

    let reader = new FileReader();
    let that = this;

    reader.onload = function (e){
      let encoded = Buffer.from(<ArrayBuffer>e.target!.result).toString('base64');
      that.encodedSlika = encoded;
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = f![0].name;
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
    }

    if (f != null) {
      reader.readAsArrayBuffer(f[0]);
    }
  }

  onUpload(){
    let txtNaziv = document.getElementById("txtAreaNazivDiv")!.getElementsByTagName("textarea")[0];
    let txtOpis = document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0];
    let txtSadrzaj = document.getElementById("txtAreaSadrzajDiv")!.getElementsByTagName("textarea")[0];
    if (txtNaziv.value.length <= 0){
      txtNaziv.style.border = "red 2px solid";
      txtNaziv.placeholder = "Naziv je obavezan...";
      return;
    }else{
      txtNaziv.style.border = "grey 1px solid";
      txtNaziv.placeholder = "Naziv...";
    }
    if (txtOpis.value.length <= 0){
      txtOpis.style.border = "red 2px solid";
      txtOpis.placeholder = "Opis je obavezan...";
      return;
    }else{
      txtOpis.style.border = "grey 1px solid";
      txtOpis.placeholder = "Opis...";
    }
    if (txtSadrzaj.value.length <= 0){
      txtSadrzaj.style.border = "red 2px solid";
      txtSadrzaj.placeholder = "Sadrzaj je obavezan...";
      return;
    }else{
      txtSadrzaj.style.border = "grey 1px solid";
      txtSadrzaj.placeholder = "Sadrzaj...";
    }
    let fajl = document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("input")[0];
    if (fajl.value.length <= 0){
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Slika je obavezna!";
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "red 2px solid";
      return;
    }else{
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Odaberite sliku";
      document.getElementById("slikaFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
    }
    this.onFileSelected();
    this.novaNovost.naziv = txtNaziv.value;
    this.novaNovost.opis = txtOpis.value;
    this.novaNovost.sadrzaj = txtSadrzaj.value;
    this.novaNovost.slika = this.encodedSlika;
    this.novaNovost.datumIVrijemeObjave = new Date().toLocaleDateString('en-CA');
    this.novaNovost.administratorID = this?.userDetails?.id;
    let body = {
      naziv: this.novaNovost.naziv,
      opis: this.novaNovost.opis,
      sadrzaj: this.novaNovost.sadrzaj,
      slika: this.novaNovost.slika,
      datum:  new Date().toLocaleDateString('en-CA'),
      vrijeme: new Date().getUTCHours().toString() + ":" + new Date().getUTCMinutes().toString(),
      administratorID: this.novaNovost.administratorID
    }
    
    console.log(body);
    this.service.addNovost(body)
      .subscribe(
        response => {
          this.pozoviGetNovosti();
          Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Uspješno dodana novost!',
            showConfirmButton: false,
            timer: 2500
          });
          this.dodajNovostForm();
        }
      );
  }

}
