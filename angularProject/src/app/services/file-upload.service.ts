import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { AnimalDetailsService } from './animal-details.service';


@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  baseApiUrl = "http://localhost:61236/api/AnimalDetails";
  animalService: AnimalDetailsService;

  constructor(private http: HttpClient, animalService: AnimalDetailsService) {
    this.animalService = animalService;
   }

  upload(file: any) {
    // const formData = new FormData();
    // formData.append("file", file, file.name);
    this.animalService.addPhoto(file);


    // return this.http.post(this.baseApiUrl, formData);
  }

}
