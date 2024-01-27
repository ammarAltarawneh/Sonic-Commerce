import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../Shared/shared.service';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit {
  loginForm : FormGroup;
  errorMessage: string;
  displayNav:boolean=true;

  constructor(private authService: AuthService){}

  ngOnInit(){
    this.loginForm = new FormGroup({
      'username': new FormControl(null,Validators.required),
      'password': new FormControl(null,[Validators.required,Validators.minLength(6)])
    })
  }
  
  displayNavButtons(){
    if(this.authService){

    }
  }

  onSubmit(){
    if (this.loginForm.valid) {
      this.authService.login({
        userId: 0,
        userName: this.loginForm.value.username,
        passwordd: this.loginForm.value.password
      });
      
      if (this.authService.errorMessage) {
        this.authService.errorMessage.subscribe(
          (error) => (
            this.errorMessage = error,
            console.log(this.errorMessage)
            )
        );
      }
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
