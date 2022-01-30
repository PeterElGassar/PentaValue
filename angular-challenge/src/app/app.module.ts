import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


// Firebase services + enviorment module
import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFirestoreModule } from '@angular/fire/firestore';

import { environment } from '../environments/environment';
import { NgOtpInputModule } from 'ng-otp-input';
import { VerifyCodeComponent } from './login/verify-code/verify-code.component';
import { AddEditMediaComponent } from './dashboard/add-edit-media/add-edit-media.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//primeng
import {InputTextModule} from 'primeng/inputtext';
import {InputMaskModule} from 'primeng/inputmask';
import {ToastModule} from 'primeng/toast';
import {CalendarModule} from 'primeng/calendar';
import {ConfirmDialogModule} from 'primeng/confirmdialog';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    VerifyCodeComponent,
    AddEditMediaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule,
    AngularFirestoreModule,
    NgOtpInputModule,
    ReactiveFormsModule,

    CalendarModule,
    InputMaskModule,
    InputMaskModule,
    InputTextModule,
    ToastModule,
    ConfirmDialogModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
