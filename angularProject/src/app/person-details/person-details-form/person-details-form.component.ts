import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PersonDetailsService } from '../../services/person-details.service'
import { FormMode } from '../../services/animal-details.service';


@Component({
  selector: 'app-person-details-form',
  templateUrl: './person-details-form.component.html',
  styles: [
  ]
})
export class PersonDetailsFormComponent implements OnInit {

  mode: FormMode = FormMode.VIEW;

  constructor(public service: PersonDetailsService) { }

  ngOnInit(): void {

    this.service.getAccount();
  }

  onSave(form: NgForm) {
    console.log(localStorage)


    this.service.postAccountnDetails().subscribe(result => {
      console.log('User updated')
      console.log(localStorage)
    }, err => { console.log(err); });
  }

  onEdit(form: NgForm) {
    this.mode = FormMode.EDIT;
  }

  reset(form: NgForm) {
    form.form.reset();
    this.mode = FormMode.VIEW;
  }

  isFormReadOnly() {
    return this.mode === FormMode.VIEW;
  }

  isFormEdited() {
    return this.mode === FormMode.EDIT;
  }

  isInst(form: NgForm) {
    const isInst = form.controls['isInstitution'];
    return isInst == undefined ? false : isInst.value;
  }

  logout() {
    console.log('logs out')
  }

}
