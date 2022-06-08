import { Component } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class Form {

  formName = 'personalInput';

  inputItems = [
    { id: '01', name: 'Imie', type: 'text', maxLength: '30', textFrom: 'Podaj rasę psa: ', textTo: '' },
    { id: '05', name: 'Nazwisko', type: 'number', textFrom: 'Od: ', textTo: 'Do: ', min: '5', max: '10000' },
    { id: '10', name: 'Adres email', type: 'number', textFrom: 'Od: ', textTo: 'Do: ', min: '0', max: '99' },
  ];

  onSubmit() {
    //console.log();
  } 

}
