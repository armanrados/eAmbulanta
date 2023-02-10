import { Component } from '@angular/core';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {JavnaNabavka} from "../models/javnaNabavka.model";
import {style} from "@angular/animations";
import { Buffer } from 'buffer';
import {AuthService} from "../service/auth.service";

@Component({
  selector: 'app-javne-nabavke',
  templateUrl: './javne-nabavke.component.html',
  styleUrls: ['./javne-nabavke.component.css']
})
export class JavneNabavkeComponent {
  JavneNabavke : JavnaNabavka[] = [];
  javnaNabavka : JavnaNabavka = {
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
    this.getAllJavneNabavkePozovi();
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
      }
    );
  }

  getAllJavneNabavkePozovi(){
    this.eAmbulantaService.getAllJavneNabavke()
    .subscribe(
      response => {
        this.JavneNabavke = response;
      }
    );
  }

  updateJavnaNabavkaPozovi(jn : JavnaNabavka, ind : number){
    jn.opis = document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].getElementsByTagName("textarea")[0].value;
    this.eAmbulantaService.updateJavnaNabavka(jn)
      .subscribe(
        response => {
          this.getAllJavneNabavkePozovi();
        }
      )
  }

  deleteJavnaNabavkaPozovi(id : number){
    this.eAmbulantaService.deleteJavnaNabavka(id)
      .subscribe(
        response =>{
          this.getAllJavneNabavkePozovi();
        }
      )
  }

  dodajJavnaNabavkaForm(){
    if (document.getElementById("divNovaJavnaNabavka")!.style.display === "none"){
      document.getElementById("divNovaJavnaNabavka")!.style.display = "block";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].style.border = "grey 1px solid";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].placeholder = "Opis...";
      document.getElementById("txtAreaOpisDiv")!.getElementsByTagName("textarea")[0].value = "";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("input")[0].value = "";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.innerText = "Odaberite PDF fajl";
      document.getElementById("pdfFajlUploadDiv")!.getElementsByTagName("label")[0]!.style.border = "grey 1px solid";
      document.getElementById("btnDodajJavnuNabavku")!.style.display = "none";
    }else{
      document.getElementById("divNovaJavnaNabavka")!.style.display = "none"
      document.getElementById("btnDodajJavnuNabavku")!.style.display = "block";
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
      console.log(that.encodedPdf);
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
    this.javnaNabavka.opis = txtOpis.value;
    this.javnaNabavka.pdfFajl = this.encodedPdf;
    this.javnaNabavka.administratorID = this?.userDetails?.id;
    this.eAmbulantaService.addJavnaNabavka(this.javnaNabavka)
      .subscribe(
        response => {
          this.getAllJavneNabavkePozovi();
          }
        )
    this.dodajJavnaNabavkaForm();
  }

  editEnabled(ind : number, jn : JavnaNabavka){

    if (document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display === "none"){
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].style.display = "none";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].className = "btn btn-block bg-gradient-info btn-lg";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].getElementsByTagName("i")[0].className = "fa fa-bars";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display = "block";
    }else{
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].style.display = "block";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[0].getElementsByTagName("textarea")[0].value = jn.opis;
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].className = "btn btn-block bg-gradient-danger btn-lg";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[3].getElementsByTagName("button")[0].getElementsByTagName("i")[0].className = "fa fa-times";
      document.getElementById("javnaNabavkaTable")!.getElementsByTagName("tr")[ind]!.getElementsByTagName("td")[1].style.display = "none";
    }

  }

  otvoriPdf(jn : JavnaNabavka){
    let buff = Buffer.from(jn.pdfFajl, "base64");
    let blob = new Blob([buff], {type: 'application/pdf'});
    let blobURL = URL.createObjectURL(blob);
    window.open(blobURL);
  }
}

