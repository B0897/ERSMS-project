import { RegisterService } from './../services/register.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})


export class RegisterComponent implements OnInit {

  
  constructor(public service: RegisterService, private router: Router) { }

  registered: boolean = false;

  param: string = "";
  userID: string = "";
  kod: string = "";
  position: String;

  ngOnInit(): void {
    this.getUserLocation()
    var checkBox = document.getElementById("isInstitution");
    checkBox?.addEventListener("click", (e:Event) => this.checkCheckbox());
    
  }


  getUserLocation() {
    navigator.geolocation.getCurrentPosition( (position) => {
      this.position = `${position.coords.latitude} ${position.coords.longitude}`
    } )
  }

  display = false;
  checkCheckbox() {
    this.display = !this.display;
  }

  isDisplay() {
    return this.display;
  }

  onSave(form: any) {

    
    form.Coord = this.position
    form.Secret = ""
    form.Paypal = ""

    var emailReg =  /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if(!emailReg.test(form.Email)){
      alert('Wprowadź poprawny adres email!');
      return false;			
    }

    if(this.display) {
      form.Name = "Null"
      form.Surname = "Null"
    }
    else {
      form.InstitutionName = "Null"
    }

    form.isInstitution = this.display
    this.createUser(form)
    return true;
  }

  createUser(form: NgForm) {
    console.log(form)
    this.service.postUserDetails(form).subscribe(result => {
      this.registered = true
      console.log(result);
      var str = result.split(" ", 2);
      this.param = str[0];
      this.userID = str[1]; 
    }, err => {console.log(err)})
  }

  onSave2(form: any) {
    this.kod = form.Kod;
    this.service.postCode(this.kod, this.userID).subscribe(result => {
      console.log(result)
      alert('Konto zostało utworzone')
    }, err => { alert('Wprowadzono nieprawidlowe dane!') })
    this.router.navigateByUrl('/login');
  }

  isRegistered() {
    return this.registered;
  }
}
