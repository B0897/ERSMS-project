import { Injectable } from '@angular/core';
import { Picture } from '../models/picture.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class PictureService
{
  constructor(private http: HttpClient) {
    this.formData = new Picture();
  }

  readonly baseURL = 'https://ersms.azurewebsites.net/api/picture';

  formData: Picture = new Picture();

  postPicDetails()
  {
    console.log(this.formData)

    return this.http.post(this.baseURL, this.formData);
  }
}

export enum FormMode {
  VIEW,
  CREATE,
  EDIT
}
