import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  constructor(http: HttpClient) {
  //  http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  }

  title = 'angularProject';

  ngOnInit() {
    if (!navigator.geolocation) {
      console.log('location is not supproted');
    }
    navigator.geolocation.getCurrentPosition((postition) => {
      console.log(`lat: ${postition.coords.latitude}, lon: ${postition.coords.longitude}`
      );
    });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
