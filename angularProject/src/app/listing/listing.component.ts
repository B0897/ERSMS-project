import { Component } from '@angular/core';
import { AnimalDetailsService } from '../services/animal-details.service';
import { Animal } from '../models/animal.model';
import { OnInit } from '@angular/core';
import { single } from 'rxjs-compat/operator/single';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.css']
})

export class Listing {

  fromValue: any;
  toValue: any;

  filters = [
    { id: '01', name: 'Rasa', type: 'text', maxLength: '30', labelFrom: true, labelTo: false, textFrom: 'Podaj rasę psa: ', textTo: '' },
    { id: '05', name: 'Lokalizacja', type: 'number', labelFrom: true, labelTo: true, textFrom: 'Od: ', textTo: 'Do: ', min: '5', max: '10000' },
    { id: '10', name: 'Wiek', type: 'number', labelFrom: true, labelTo: true, textFrom: 'Od: ', textTo: 'Do: ', min: '0', max: '99' },
  ];

  sortItems = ['Cena', 'Lokalizacja'];
  currentFilter: any;

  constructor(public animalDetailsService: AnimalDetailsService) {
    
  }

  ngOnInit(): void {
    this.carts = [];
    let followIds: any;

    try {
      let storage = localStorage.getItem('follow');
      followIds = storage ? JSON.parse(storage) : null;
    } catch { }

    this.animalDetailsService.getAllAnimals().subscribe(animals => {
      animals.forEach((singleAnimal) => {
        let newElement = { animal: singleAnimal, isFollow: false };
        this.carts.push(newElement);
      }, this);

      let followFlag: boolean;
      this.carts.forEach(function (el: any) {
        if (followIds != null) {
          followFlag = followIds.includes(el.animal.id);
          el.isFollow = followFlag;
        } else {
          followFlag = false;
        }
      }, this);

    });
  }

  carts: any;

  currentCartsCollection: any;

  openFilter(filterId: string) {
    this.currentFilter = this.filters.find(element => element.id === filterId);

  }

  onSubmit(event: any) {
    //this.carts.filter(element => element['dateOfBirth'] >= this.fromValue && element['dateOfBirth'] <= this.toValue);
  }


  sortCollection(sortValue: string) {
    this.carts.sort();

  }

  openDetails(id: string) {
    const id2 = id.toString();
  }


  handleFollow(id: string) {
    try {

      let newFollowValue = !(this.carts.find((element: { animal: { id: string; }; }) => element.animal.id === id).isFollow);
      this.carts.find((element: { animal: { id: string; }; }) => element.animal.id === id).isFollow = newFollowValue;
      
      let storage = localStorage.getItem('follow');
      let followIds = storage ? JSON.parse(storage) : null;

      if (followIds != null) {
        if (newFollowValue && !followIds.includes(id)) {
          followIds.push(id);
        } else if (!newFollowValue && followIds.includes(id)) {
          followIds = followIds.filter((item: string) => item !== id);
        }
        localStorage.setItem('follow', JSON.stringify(followIds));

      } else {
        if (newFollowValue) {
          followIds = Array<String>();
          followIds.push(id);
          localStorage.setItem('follow', JSON.stringify(followIds));
        }
      }
    } catch (err) { console.log(err); }
  }

  get wrappersLength() {
    return this.carts.length;
  }
}
