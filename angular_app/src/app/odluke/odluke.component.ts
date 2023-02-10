import { Component } from '@angular/core';
import {Odluka} from "../models/odluka.model";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {JavnaNabavka} from "../models/javnaNabavka.model";
import {Buffer} from "buffer";
import {AuthService} from "../service/auth.service";

@Component({
  selector: 'app-odluke',
  templateUrl: './odluke.component.html',
  styleUrls: ['./odluke.component.css']
})
export class OdlukeComponent {
  Odluke : Odluka[] = [];
  odluka : Odluka = {
    id: 0,
    opis: "",
    pdfFajl: "",
    administratorID: ""
  };
  encodedPdf : string = "";
  userDetails : any;

  constructor(private eAmbulantaService : EAmbulantaServiceService, public authService : AuthService) {

  }

  ngOnInit(){
    this.getAllOdlukePozovi();
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
      }
    );
  }

  getAllOdlukePozovi(){
    this.eAmbulantaService.getAllOdluke()
      .subscribe(
        response => {
          this.Odluke = response;
        }
      );
  }

  updateOdlukePozovi(odluka : Odluka, ind : number){
    odluka.opis = document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].getElementsByTagName("textarea")[0].value;
    this.eAmbulantaService.updateOdluke(odluka)
      .subscribe(
        response => {
          this.getAllOdlukePozovi();
        }
      )
  }

  editEnabled(ind : number, odl : Odluka){

    if (document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display === "none"){
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].style.display = "none";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].className = "btn btn-block bg-gradient-info btn-lg";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].getElementsByTagName("i")[0].className = "fa fa-bars";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display = "block";
    }else{
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].style.display = "block";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].getElementsByTagName("textarea")[0].value = odl.opis;
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].className = "btn btn-block bg-gradient-danger btn-lg";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].getElementsByTagName("i")[0].className = "fa fa-times";
      document.getElementById("OdlukaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display = "none";
    }

  }

  otvoriPdf(odluka : Odluka){
    let buff = Buffer.from(odluka.pdfFajl, "base64");
    let blob = new Blob([buff], {type: 'application/pdf'});
    let blobURL = URL.createObjectURL(blob);
    window.open(blobURL);
  }

  deleteOdlukaPozovi(id : number){
    this.eAmbulantaService.deleteOdluka(id)
      .subscribe(
        response =>{
          this.getAllOdlukePozovi();
        }
      )
  }

  dodajOdlukaForm(){
    if (document.getElementById("divNovaOdluka")!.style.display === "none"){
      document.getElementById("divNovaOdluka")!.style.display = "block";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].placeholder = "Opis...";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("input")[0].value = "";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Odaberite PDF fajl";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
      document.getElementById("btnDodajOdluku")!.style.display = "none";
    }else{
      document.getElementById("divNovaOdluka")!.style.display = "none"
      document.getElementById("btnDodajOdluku")!.style.display = "block";
    }
  }

  onFileSelected(){
    const f = document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("input")[0].files;

    let reader = new FileReader();
    let that = this;

    reader.onload = function (e){
      let encoded = Buffer.from(<ArrayBuffer>e.target!.result).toString('base64');
      that.encodedPdf = encoded;
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = f![0].name;
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
    }

    if (f != null) {
      reader.readAsArrayBuffer(f[0]);
    }
  }

  onUpload(){
    let txtOpis = document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0];
    if (txtOpis.value.length <= 0){
      txtOpis.style.border = "red 2px solid";
      txtOpis.placeholder = "Opis je obavezan...";
      return;
    }else{
      txtOpis.style.border = "grey 1px solid";
      txtOpis.placeholder = "Opis...";
    }

    let fajl = document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("input")[0];
    if (fajl.value.length <= 0){
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "PDF fajl je obavezan!";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "red 2px solid";
      return;
    }else{
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Odaberite PDF fajl";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
    }

    this.onFileSelected();
    this.odluka.opis = txtOpis.value;
    this.odluka.pdfFajl = this.encodedPdf;
    this.odluka.administratorID = this?.userDetails?.id;
    this.eAmbulantaService.addOdluka(this.odluka)
      .subscribe(
        response => {
          this.getAllOdlukePozovi();
        }
      )
    this.dodajOdlukaForm();
  }
}
