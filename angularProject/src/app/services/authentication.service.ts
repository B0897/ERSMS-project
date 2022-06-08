import { Injectable } from '@angular/core';
import { User } from '../models/user.model'
import { HttpClient } from '@angular/common/http'
import {Router} from '@angular/router';
import { NgForm } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  loggedUser: string = '';

  constructor(private http: HttpClient, private router: Router) {
      this.formData = new User();
  }

  readonly baseURL = 'https://ersms.azurewebsites.net/api/login';

  formData: User = new User();

  tryLogin() {
    console.log('tries to login');
    console.log(this.formData);
    return this.http.post(this.baseURL, this.formData).subscribe(result => {
      console.log(result)
      localStorage.setItem('SessionID', result.toString())
      console.log(localStorage)
      this.router.navigateByUrl('/listing');
      
    },
      err => alert('Wprowadzono nieprawidlowe dane!')
    );
  }

  getCurrentUser() {
    return this.loggedUser;
  }

}
