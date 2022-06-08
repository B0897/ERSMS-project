import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class RegisterService {
  postCode(kod: string, userID: string) {
    var fd = new FormData();
    fd.append("OTP", kod)
    fd.append("ID", userID)
      console.log(fd)
    return this.http.post(this.baseURL + "/OTP", fd, { responseType: 'text' })
    }

  constructor(private http: HttpClient) {
   }

   readonly baseURL = 'https://ersms.azurewebsites.net/api/user'; 

   postUserDetails(form: any) {
     return this.http.post(this.baseURL, form, {responseType: 'text'})
   }
  }
