import { DashboardService } from './../dashboard.service';
import { IAd } from './../../Shared/IAd';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-edit-media',
  templateUrl: './add-edit-media.component.html',
  styleUrls: ['./add-edit-media.component.css'],
  providers:[MessageService]
})
export class AddEditMediaComponent implements OnInit {

@Input() media :IAd;

meidaForm: FormGroup;

  constructor(private fm: FormBuilder,
    private dashboardServe:DashboardService,
    private messageService:MessageService) { }

  ngOnInit(): void {
    this.createMediaForm();
    this.getMedia();
    debugger
    console.log(this.media);
  }


  createMediaForm() {
    this.meidaForm = this.fm.group({
      image: [null],
      video: [null],
      from_time: [null, [Validators.required]],
      to_time: [null, [Validators.required]],
  
      id: [0]
    })
  }





  addMedia() {
    debugger;
    console.log(this.meidaForm.value);
    
    this.dashboardServe.CreateAd(this.meidaForm.value).subscribe((res) => {
      console.log(res);
      this.alertMessage("Ad Create Success","success");

    },err=>{
      console.log(err);
      this.alertMessage("Some thing Wrong", "error");
    });
  }


  updateMedia() {
    debugger;
    console.log(this.meidaForm.value);
    this.dashboardServe.UpdateAd(this.meidaForm.value).subscribe((res) => {
      console.log(res);
      this.alertMessage("Ad Updated Success","success");

    },err=>{
      console.log(err);  
      this.alertMessage("Some thing Wrong", "error");

    });
  }



getMedia(){
  if(this.media.id > 0)
  {
    this.meidaForm.patchValue(this.media); console.log(this.meidaForm.value);
    debugger;
    this.meidaForm.controls.from_time.setValue(new Date(this.media.from_time));
    this.meidaForm.controls.to_time.setValue(new Date(this.media.to_time));
  }


  
}
    //alert Message
    alertMessage(message: string, alertType: string) {
      this.messageService.add({
        key: 'ImageSaveSuccess',
        severity: alertType,
        summary: 'Penta Value',
        detail: message,
      });
    }

}
