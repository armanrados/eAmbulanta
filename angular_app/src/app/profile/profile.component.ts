
import { Component, OnInit } from '@angular/core';
import {AuthService} from "../service/auth.service";
import {Router} from "@angular/router";
import {Loader} from '@googlemaps/js-api-loader';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    title = "google-maps";
    private map: google.maps.Map;
  public role : string = "";
  userDetails : any;
  constructor(public authService : AuthService, private router : Router) {
  }

  ngOnInit() : void{
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
    this.role = payLoad.role;
    
    this.authService.getUserProfile().subscribe(
      res=>{
        this.userDetails = res;
            let loader = new Loader({
        apiKey:'AIzaSyDoBmO8cWsCadVaMhiG0IP1bKhyJb_lcjg'
      });
  
      loader.load().then(() => {
        console.log(this.userDetails)

        this.map = new google.maps.Map(document.getElementById("map") as HTMLElement , {
          center: {lat:parseFloat(this.userDetails.lok.longitude), lng:parseFloat(this.userDetails.lok.latitude)},
          zoom: 6,
          gestureHandling: 'greedy'
        })
        const marker = new google.maps.Marker({
          position: {lat:parseFloat(this.userDetails.lok.longitude), lng:parseFloat(this.userDetails.lok.latitude)},
          map: this.map
        });
        
      })
  
      }); 
    }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['content-wrapper']);
  }

}
