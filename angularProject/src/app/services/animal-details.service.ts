import { Injectable } from '@angular/core';
import { Animal } from '../models/animal.model';
import { Picture } from '../models/picture.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AnimalDetailsService {

  constructor(private http: HttpClient) {
      
      this.formData = new Animal();
  }

  readonly baseURL = 'https://ersms.azurewebsites.net/api/addinganimal';

  formData: Animal = new Animal();

  postAnimalDetails() {
    console.log('POOSTING ANIMAL');
    navigator.geolocation.getCurrentPosition((postition) => {
      this.formData.Coord = `${postition.coords.latitude} ${postition.coords.longitude}`
    });
    this.formData.Description = "asd";
    this.formData.UserID = 0;
    console.log(this.formData);
    return this.http.post(this.baseURL, this.formData).subscribe(result=>console.log(result));
  }

  getAnimal(id: string) {
    // TODO backend
    if (id === '04') {
      console.log('set cat');
      this.formData = this.randomAnimal();
    } else {
      console.log('set dog')
      this.formData = this.randomAnimal2();
    }
  }


  readonly urlAllAnimal = 'https://ersms.azurewebsites.net/api/animal';


  getAllAnimals() {
    // /api/animal
    return this.http.get<Animal[]>(this.urlAllAnimal);

    // this.http.get<Animal[]>(this.baseURL).subscribe(value => {
    //   return value;
    // });

    // this.http.get<Animal[]>(this.baseURL).subscribe(animals => {
    //   return animals;
    // }
  }

  randomAnimal(): Animal {
    const animal = new Animal();
    animal.ID = 3;
    animal.Price = 300;
    animal.AnimalType = 'kot';
    animal.Breed = 'dachowiec';
    animal.Age = 1;
    return animal;
  }

  randomAnimal2(): Animal {
    const animal = new Animal();
    animal.ID = 2;
    animal.Price = 300;
    animal.AnimalType = 'pies';
    animal.Breed = 'burek';
    animal.Age = 1;
    return animal;
  }

  addPhoto(data: File) {
    console.log('add photo');
    console.log(data);
    this.formData.Photo = data;
  }

  getPhoto(data: FormData) {
    console.log('get photo');
    console.log(data);
  }

}

export enum FormMode {
  VIEW,
  CREATE,
  EDIT
}
