import { Component, OnInit, TemplateRef } from '@angular/core';
import { IAd } from '../Shared/IAd';
import { DashboardService } from './dashboard.service';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [ConfirmationService, MessageService]
})
export class DashboardComponent implements OnInit {


  ads: IAd[];
  phoneNumber: any = null;

  media: IAd;
  ActivateAddEdit: boolean = false;
  modalTitle: string;

  constructor(private dashboardServe: DashboardService
    , private angularFireAuth: AngularFireAuth
    , private router: Router
    , private confirmService: ConfirmationService
    , private messageService: MessageService) { }


  ngOnInit(): void {
    this.getCurrentUser();
    this.getAllAds();
  }




  getCurrentUser() {
    let user_data = JSON.parse(localStorage.getItem("user_data") || '{}');

    console.log(user_data);

    if (user_data != {})
      this.phoneNumber = user_data.user.phoneNumber;
  }

  getAllAds() {
    this.dashboardServe.getAllAds().subscribe((res: IAd[]) => {
      this.ads = res;
    });
  }

  logout() {
    this.angularFireAuth.signOut().then(() => {
      this.router.navigateByUrl("/");
    });
  }


  addNewClick() {
    this.modalTitle = 'Add New Ad';
    this.ActivateAddEdit = true;

    this.media = {
      id: 0,
      image: '',
      video: '',
      from_time: new Date,
      to_time: new Date,
    }
  }


  editClick(mediaInfo: any) {
    this.modalTitle = 'Edit Ad';

    debugger;
    this.media = mediaInfo;
    this.ActivateAddEdit = true;
  }

  closeModal() {
    this.getAllAds();
    this.media = null;
    this.ActivateAddEdit = false;
  }


  confirm(AdId: any) {
    this.confirmService.confirm({
      message: 'Are you sure that you want to delete Ad?',
      header: 'Penta Value',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {

        this.dashboardServe.DeleteAd(AdId).subscribe(res => {
          this.messageService.add({ key: 'del', severity: 'success', summary: 'Penta Value', detail: 'Deleted Success' });
          this.getAllAds();
        }, err => {
          console.log(err);

        })
      }
    });
  }
}
