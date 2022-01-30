import { Component, OnInit } from '@angular/core';

import firebase from 'firebase/app';
import 'firebase/auth';
import 'firebase/firestore';
import { Router } from '@angular/router';


let config = {
  apiKey: "AIzaSyC20giYRdIiqDMspG9vNIX7oKYIIg0KkbU",
  authDomain: "mobile-auth-task.firebaseapp.com",
  projectId: "mobile-auth-task",
  storageBucket: "mobile-auth-task.appspot.com",
  messagingSenderId: "354350160620",
  appId: "1:354350160620:web:8e69ec9e3324b02ffae3c9"
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  mobileNumber: any;
  reCaptureVerifier: any;

  isSendedCodeSuccess: boolean = false


  constructor(private router: Router) { }

  ngOnInit() {
    firebase.initializeApp(config);
  }

  getOTP() {
    this.reCaptureVerifier = new firebase.auth.RecaptchaVerifier('login-btn', { size: 'invisible' });

    console.log(this.reCaptureVerifier);
    console.log(this.mobileNumber);


    //fetch promise
    firebase.auth()
      .signInWithPhoneNumber(this.mobileNumber, this.reCaptureVerifier)
      .then((confirmationResult) => {
        localStorage.setItem('verificationId',JSON.stringify(confirmationResult.verificationId));

        //active shown verification code input
        this.isSendedCodeSuccess = true;

      }).catch((err) => {
        console.log(err.message);
      });



  }



}
