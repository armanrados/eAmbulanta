import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';





@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],

})


export class LoginComponent implements OnInit {

  type : string ="password";
  isText: boolean = false;
  eyeIcon: string ="fa-eye-slash";
  loginForm! : FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router){}

  ngOnInit(): void {
    if (localStorage.getItem('token')!=null){
      this.router.navigate(['content-wrapper']);
    }

    this.loginForm = this.fb.group({
      korisnickoIme:['',Validators.required],
      lozinka:['',Validators.required]
    })

  }
  hideShowPass()
  {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon="fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";

  }

  onLogin()
  {
    if(this.loginForm.valid)
    {
        console.log(this.loginForm.value);
        this.auth.login(this.loginForm.value)
        .subscribe({
          next:(res) =>{
            localStorage.setItem('token', res.token);
            alert("Uspjesno ste se logirali.");
            this.router.navigate(['content-wrapper']);
          },
          error:(err) =>{
            if (err.status == 400) {
              alert("Netacno korisnicko ime i/ili lozinka.");
            }else{
              console.log(err);
            }
          }
        })
    }
    else
    {
      console.log("Forma nije validna!");
      this.validateAllFormFields(this.loginForm);

    }
  }

  private validateAllFormFields(frmGroup: FormGroup)
  {
    Object.keys(frmGroup.controls).forEach(field => {
      const control = frmGroup.get(field);
      if(control instanceof FormControl)
      {
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup)
      {
        this.validateAllFormFields(control)
      }
    })
  }
}
