import { Component, ViewChild, ElementRef } from '@angular/core';
import {jsPDF} from "jspdf";
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-svg-pdf',
  templateUrl: './svg-pdf.component.html',
  styleUrls: ['./svg-pdf.component.css']
})
export class SvgPDFComponent {
  currentDate = new Date();
  @ViewChild('content', {static:false}) el!: ElementRef;
  makePDF()
  {
    let pdf = new jsPDF('p', 'pt','a4');
    pdf.html(this.el.nativeElement,{
      callback:(pdf)=>{
    pdf.save("Potvrda.pdf");

      }
    });
  }
 

}

