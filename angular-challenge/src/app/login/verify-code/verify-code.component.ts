import { Component, OnInit } from '@angular/core';
import firebase from 'firebase/app';
import 'firebase/auth';
import 'firebase/firestore';
import { Router } from '@angular/router';


@Component({
  selector: 'app-verify-code',
  templateUrl: './verify-code.component.html',
  styleUrls: ['./verify-code.component.css']
})
export class VerifyCodeComponent implements OnInit {

  verifyCode: string;
  otp!: string;

  config = {
    allowNumbersOnly: true,
    length: 6,
    isPasswordInput: false,
    disableAutoFocus: false,
    placeholder: '',
    inputStyles: {
      width: '50px',
      height: '50px',
    },
  };

  constructor(private router: Router) { }

  ngOnInit(): void {

    this.verifyCode = JSON.parse(localStorage.getItem('verificationId') || '{}');
    console.log(this.verifyCode);

  }


  onOtpChange(otpCode: any) {
    this.otp = otpCode;
  }

  clickVerifyEvent() {
    //create Credentials
    // console.log(this.verifyCode);
    console.log(this.otp);

    var credential = firebase.auth.PhoneAuthProvider.credential(
      this.verifyCode,
      this.otp
    );
    console.log(credential);

    firebase
      .auth().signInWithCredential(credential)
      .then((response) => {
        console.log(response);
        localStorage.setItem('user_data', JSON.stringify(response));
        this.router.navigateByUrl("/dashboard");
      }).catch((error) => {
        console.log(error);
        alert(error.message);
      });

  }

}
