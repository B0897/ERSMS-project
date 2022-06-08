import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import { AnimalDetailsService, FormMode } from '../../services/animal-details.service'
import { Animal } from '../../models/animal.model';
import { Picture } from '../../models/picture.model';
import { AnimalDetailsComponent } from '../animal-details.component'
import { PictureService } from '../../services/picture-details.service'
import { Subscription } from "rxjs/Rx";
import { Router } from '@angular/router';


@Component({
  selector: 'app-animal-details-form',
  templateUrl: './animal-details-form.component.html',
  styles: [
  ]
})
export class AnimalDetailsFormComponent implements OnInit {

  mode: FormMode = FormMode.VIEW;
  showPhotoUpload: boolean = false;

  private routeSub: Subscription;

  constructor(public service: AnimalDetailsService, private route: ActivatedRoute, private router: Router) { }  

  ngOnInit(): void {


    this.route.queryParams.subscribe(params => {
      console.log('gets animal with id: ' + params['id']);
      if (params != null && params != undefined && params['id'] != undefined) {
        this.service.getAnimal(params['id']);
      }
    });
  }

  onSave(form: NgForm) {
    console.log(form);
    this.service.postAnimalDetails();
    this.router.navigateByUrl('/listing');
  }

  onEdit(form: NgForm) {
    console.log('edit form')
    this.mode = FormMode.EDIT;
  }

  reset(form: NgForm) {
    console.log('reset form');
    form.form.reset();
    this.service.formData = new Animal();
  }

  isFormReadOnly() {
    return this.mode === FormMode.VIEW;
  }

  uploadPhoto(form: NgForm) {
    this.showPhotoUpload = true;
  }

  doShowPhotoUpload(): boolean {
    return this.showPhotoUpload;
  }

}
