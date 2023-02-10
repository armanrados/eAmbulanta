import { Component } from '@angular/core';
import {AuthService} from "../service/auth.service";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  constructor(public service : AuthService) {
  }

  ngOnInit(){
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.register()
      .subscribe(
        (res:any) =>{
        if (res.succeeded){
          this.service.formModel.reset();
        }else{
          res.errors.forEach((element:any) =>{
            switch (element.code){
              case 'DuplicateUserName':

                break;
              default:
                break;
            }
          })
        }
      },
      err =>{
        console.log(err);
      }
    );
  }
}
