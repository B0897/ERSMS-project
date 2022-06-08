import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormMode } from '../services/animal-details.service'
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  mode: FormMode = FormMode.VIEW;


  constructor(public service: AuthenticationService) { }

  ngOnInit(): void {
  }

  onSave(form: NgForm) {
    this.service.tryLogin();
  }

}
