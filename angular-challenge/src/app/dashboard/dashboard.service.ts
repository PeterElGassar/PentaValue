import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {


  }




  createAd(value: any) {


    return this.http.post(this.baseUrl, value)
  }

  updatedAd(value: any) {

    return this.http.post(this.baseUrl, value)
  }


  getAllAds() {
    return this.http.get(this.baseUrl + "media");
  }

  getMedia(id:any) {
    return this.http.get(this.baseUrl + `media/getMedia?id=${id}`);
  }


  CreateAd(val :any) {
    return this.http.post(this.baseUrl + "media",val);
  }


  UpdateAd(val :any) {
    return this.http.put(this.baseUrl + "media",val);
  }


  DeleteAd(id :any) {
    return this.http.delete(this.baseUrl + `media?id=${id}`);
  }





}
